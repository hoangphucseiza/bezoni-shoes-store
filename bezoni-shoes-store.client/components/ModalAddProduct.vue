<template>
  <div
    v-if="IsModalAddProduct"
    class="bg-[#ebe6e662] absolute top-0 left-0 right-0 bottom-0 flex justify-center items-center"
  >
    <div
      class="flex flex-col min-h-fit min-w-[800px] bg-white rounded-xl p-5 border gap-5"
    >
      <div class="flex justify-between items-center border-b pb-2">
        <div class="mx-auto font-semibold text-[20px]">Thêm sản phẩm</div>
        <div @click="handleCloseModalAddProduct">
          <Icon
            name="material-symbols:close"
            class="text-[#f36123df] text-[30px] cursor-pointer"
          />
        </div>
      </div>
      <div :validation-schema="schema" class="flex flex-col gap-5">
        <div class="flex flex-col gap-2">
          <label class="text-[20px] font-semibold">Tên sản phẩm:</label>
          <Field
            name="productName"
            type="text"
            class="border border-gray-300 rounded-md p-2 w-full"
          />
          <ErrorMessage name="productName" class="text-red-500" />
        </div>
        <div class="flex flex-col gap-2">
          <label class="text-[20px] font-semibold">Giá sản phẩm:</label>
          <Field
            name="price"
            type="number"
            class="border border-gray-300 rounded-md p-2 w-full"
          />
          <ErrorMessage name="price" class="text-red-500" />
        </div>
        <div class="flex flex-col gap-2">
          <label class="text-[20px] font-semibold">Voucher sản phẩm (%):</label>
          <Field
            name="voucher"
            type="number"
            class="border border-gray-300 rounded-md p-2 w-full"
          />
          <ErrorMessage name="voucher" class="text-red-500" />
        </div>
        <div class="flex flex-col gap-2">
          <label class="text-[20px] font-semibold">Mô tả:</label>
          <Field
            name="description"
            type="text"
            class="border border-gray-300 rounded-md p-2 w-full"
          />
          <ErrorMessage name="description" class="text-red-500" />
        </div>
        <div class="flex flex-col gap-2">
          <label class="text-[20px] font-semibold"
            >Sản phẩm thuộc danh mục nào:</label
          >
          <select
            class="border border-gray-300 rounded-md p-2"
            v-model="selectedCategory"
          >
            <option
              v-for="(category, index) in listCategory"
              :key="index"
              :value="category.id"
            >
              {{ category.name }}
            </option>
          </select>
          <ErrorMessage name="categoryID" class="text-red-500" />
        </div>
        <div
          @click="submitForm"
          class="flex justify-center items-center bg-[#F36123] text-white text-[20px] font-bold rounded-xl p-2 cursor-pointer hover:bg-[#f36123df] hover:shadow-xl"
        >
          Thêm sản phẩm
        </div>
        <!-- Danh sách Category -->
        <div v-if="listCategory" class="flex flex-col gap-2">
          <div class="font-semibold text-[20px]">Danh sách sản phẩm:</div>
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
import { string, object, number } from "yup";
import { useAuthStore } from "~/store/authStore";
import type { IErrorSystem } from "~/interface/ErrorResponse/IErrorSystem";
import { useAlertStore } from "~/store/alertStore";

import { useCategoryStore } from "~/store/categoryStore";
import type { IAddProductBody } from "~/interface/RequestBody/IAddProductBody";
import { useProductStore } from "~/store/productStore";

// Định nghĩa các props của component
const props = defineProps<{
  IsModalAddProduct: boolean;
  handleCloseModalAddProduct: () => void;
}>();

const listCategory = computed(() => categoryStore.categories);
onMounted(async () => {
  await categoryStore.getAllCategory();
});
const categoryStore = useCategoryStore();

const schema = reactive({
  productName: string().required("Tên sản phẩm không được bỏ trống"),
  price: number()
    .required("Giá sản phẩm không được bỏ trống")
    .min(0, "Giá sản phẩm phải lớn hơn 0"),
  voucher: number()
    .required("Voucher sản phẩm không được bỏ trống")
    .min(0, "Voucher sản phẩm phải lớn hơn 0")
    .max(100, "Voucher sản phẩm phải nhỏ hơn 100"),
  description: string().required("Mô tả sản phẩm không được bỏ trống"),
});
const selectedCategory = ref("");

// Xử lý sự kiện gửi form
const { handleSubmit } = useForm({
  validationSchema: schema,
});
const authStore = useAuthStore();
const alertStore = useAlertStore();
const productStore = useProductStore();
const submitForm = handleSubmit(async (values) => {
  const product: IAddProductBody = {
    name: values.productName,
    price: values.price,
    voucher: values.voucher,
    description: values.description,
    categoryID: selectedCategory.value,
  };
  await productStore.handleAddProduct(product);
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
    
    