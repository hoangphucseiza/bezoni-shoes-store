<template>
  <div
    v-if="IsModalAddCategory"
    class="bg-[#ebe6e662] absolute top-0 left-0 right-0 bottom-0 flex justify-center items-center"
  >
    <div
      class="flex flex-col min-h-fit min-w-[800px] bg-white rounded-xl p-5 border gap-5 -translate-y-[100px]"
    >
      <div class="flex justify-between items-center border-b pb-2">
        <div class="mx-auto font-semibold text-[20px]">Thêm danh mục</div>
        <div @click="handleCloseModalAddCategory">
          <Icon
            name="material-symbols:close"
            class="text-[#f36123df] text-[30px] cursor-pointer"
          />
        </div>
      </div>
      <div :validation-schema="schema" class="flex flex-col gap-5">
        <div class="flex flex-col gap-2">
          <label class="text-[20px] font-semibold">Tên danh mục:</label>
          <Field
            name="categoryName"
            type="text"
            class="border border-gray-300 rounded-md p-2 w-full"
          />
          <ErrorMessage name="categoryName" class="text-red-500" />
        </div>
        <div
          @click="submitForm"
          class="flex justify-center items-center bg-[#F36123] text-white text-[20px] font-bold rounded-xl p-2 cursor-pointer hover:bg-[#f36123df] hover:shadow-xl"
        >
          Thêm danh mục
        </div>
        <!-- Danh sách Category -->
        <div v-if="listCategory" class="flex flex-col gap-2">
          <div class="font-semibold text-[20px]">Danh sách danh mục:</div>
          <div class="flex flex-col gap-2 border p-3 rounded-xl">
            <div
              v-for="(category, index) in listCategory"
              :key="index"
              class="flex justify-between items-center border-b pb-2 text-[18px]"
            >
              <!-- input for category name -->
              <input
                type="text"
                class="border border-gray-300 rounded-md p-2"
                :value="
                  editingCategory?.id === category.id
                    ? editingCategory.name
                    : category.name
                "
                @input="handleInputChange($event, category.id)"
              />
              <div class="flex gap-4">
                <Icon
                  name="material-symbols:delete"
                  class="text-[#f36123df] text-[30px] cursor-pointer"
                  @click="
                    categoryStore.handleDeleteCategory(
                      category.id,
                      category.name
                    )
                  "
                />
                <Icon
                  name="material-symbols:edit"
                  class="text-[#f36123df] text-[30px] cursor-pointer"
                  @click="handleEditCategory(category.id)"
                />
              </div>
            </div>
          </div>
        </div>
        <div v-else class="text-[20px] font-semibold">
          Không có danh mục nào
        </div>
      </div>
    </div>
    <ErrorToast />
    <SuccessToast />
    <LoadingPage />
  </div>
</template>
  
  <script setup lang="ts">
import { defineProps } from "vue";
import { Form, Field, ErrorMessage, useForm } from "vee-validate";
import { string, object } from "yup";
import type { IAddCategoryBody } from "~/interface/RequestBody/IAddCategoryBody";
import { callApi, HttpMethods } from "~/ApiConfig/fetchData";
import { useAuthStore } from "~/store/authStore";
import type { IErrorSystem } from "~/interface/ErrorResponse/IErrorSystem";
import { useAlertStore } from "~/store/alertStore";
import type { ICategoryResponse } from "~/interface/Response/ICategoryResponse";
import type { IUpdateCategoryBody } from "~/interface/RequestBody/IUpdateCategoryBody";
import { useCategoryStore } from "~/store/categoryStore";

// Định nghĩa các props của component
const { IsModalAddCategory, handleCloseModalAddCategory } = defineProps<{
  IsModalAddCategory: boolean;
  handleCloseModalAddCategory: () => void;
}>();

const listCategory = computed(() => categoryStore.categories);
onMounted(async () => {
  await categoryStore.getAllCategory();
});
const categoryStore = useCategoryStore();
// Schema xác thực
const schema = object({
  categoryName: string().required("Tên danh mục không được bỏ trống"),
});

// Xử lý sự kiện gửi form
const { handleSubmit } = useForm({
  validationSchema: schema,
});
const authStore = useAuthStore();
const alertStore = useAlertStore();

const submitForm = handleSubmit(async (values) => {
  await categoryStore.handleAddCategory(values);
});

// Khai báo trạng thái
const editingCategory = ref<{ id: string; name: string } | null>(null);

// Hàm cập nhật giá trị input khi chỉnh sửa
const handleInputChange = (event: Event, id: string) => {
  const target = event.target as HTMLInputElement;
  editingCategory.value = { id, name: target.value };
};

// Hàm xử lý chỉnh sửa danh mục
const handleEditCategory = async (id: string) => {
  if (editingCategory.value && editingCategory.value.id === id) {
    try {
      await categoryStore.handleUpdateCategory(id, editingCategory.value.name);
    } catch (error: any) {
      alertStore.handleLoadingPage(false);
      if (error.response) {
        const errorData: IErrorSystem = error.response._data;
        alertStore.handleLoadingPage(false);
        alertStore.handleOpenErrorToast(errorData.title);
      }
    }
  } else {
    alertStore.handleOpenErrorToast("Không có gì thay đổi!");
  }
};
</script>
  
  