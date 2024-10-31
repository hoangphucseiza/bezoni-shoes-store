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
            <option value="" disabled selected>Chọn danh mục</option>
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
        <!-- Danh sách Product -->
        <div class="flex flex-col gap-2">
          <div class="flex items-center gap-5">
            <div class="font-semibold text-[20px]">Danh sách sản phẩm:</div>
            <!-- Search -->
            <!-- <div class="flex flex-row gap-2">
              <input
                type="text"
                class="border border-gray-300 rounded-md p-2 w-full"
                placeholder="Tìm kiếm sản phẩm"
                v-model="search"
              />
            </div> -->
          </div>
          <div
            class="flex flex-col gap-2 border p-3 rounded-xl overflow-y-scroll max-h-[200px]"
          >
            <!-- Bảng sản phẩm -->
            <div class="flex flex-row gap-2">
              <div class="w-[100px] font-semibold">STT</div>
              <div class="w-[200px] font-semibold">Tên sản phẩm</div>
              <div class="w-[100px] font-semibold">Giá</div>
              <div class="w-[100px] font-semibold">Voucher(%)</div>
              <div class="w-[200px] font-semibold">Mô tả</div>
              <div class="w-[200px] font-semibold">Danh mục</div>
              <div class="w-[200px] font-semibold">Chức năng</div>
            </div>
            <div class="flex flex-col gap-2" v-if="listProduct">
              <div
                v-for="(product, index) in listProduct"
                :key="index"
                class="flex flex-row gap-2"
              >
                <div class="w-[100px]">{{ index + 1 }}</div>
                <div class="w-[200px]">{{ product.name }}</div>
                <div class="w-[100px]">
                  {{ commonStore.formatPrice(product.price) }}đ
                </div>
                <div class="w-[100px]">{{ product.voucher }}</div>
                <div class="w-[200px]">{{ product.description }}</div>
                <div class="w-[200px]">{{ product.categoryName }}</div>
                <div class="w-[200px] flex gap-4">
                  <div
                    class="text-white bg-[#F36123] p-1 rounded-md cursor-pointer"
                    @click="handleUpdateProduct(product.id)"
                  >
                    Sửa
                  </div>
                  <div
                    class="text-white bg-[#F36123] p-1 rounded-md cursor-pointer"
                    @click="handleDeleteProduct(product.id, product.name)"
                  >
                    Xóa
                  </div>
                </div>
              </div>
            </div>

            <!-- ICon Loading -->
            <div v-else class="flex justify-center">
              <Icon
                name="line-md:loading-loop"
                class="text-[#f36123df] text-[30px] cursor-pointer"
              />
            </div>
          </div>
        </div>
      </div>
    </div>
    <ErrorToast />
    <SuccessToast />
    <LoadingPage />
    <modal-warning />
    <ModalUpdateProduct
      :isModalUpdateProduct="isModalUpdateProduct"
      :handleCloseModalUpdateProduct="handleCloseModalUpdateProduct"
    />
  </div>
</template>
<script setup lang="ts">
import { defineProps, ref, computed, onMounted, watch, reactive } from "vue";
import { Form, Field, ErrorMessage, useForm } from "vee-validate";
import { string, number } from "yup";
import { useAuthStore } from "~/store/authStore";
import { useAlertStore } from "~/store/alertStore";
import { useCategoryStore } from "~/store/categoryStore";
import { useProductStore } from "~/store/productStore";
import { useCommonStore } from "~/store/commonStore";
import type { IAddProductBody } from "~/interface/RequestBody/IAddProductBody";

// Định nghĩa các props của component
const props = defineProps<{
  IsModalAddProduct: boolean;
  handleCloseModalAddProduct: () => void;
}>();

// Store
const authStore = useAuthStore();
const alertStore = useAlertStore();
const categoryStore = useCategoryStore();
const productStore = useProductStore();
const commonStore = useCommonStore();

// State
// const search = ref<string>("");
// const filteredProducts = ref<any[]>([]);
const selectedCategory = ref<string>("");
const isModalUpdateProduct = ref(false);

// Computed properties
const listCategory = computed(() => categoryStore.categories);
const listProduct = computed(() => productStore.products);

// Watchers
// watch(
//   () => listProduct.value,
//   (newProducts) => {
//     filteredProducts.value = newProducts.filter((product) =>
//       product.name.toLowerCase().includes(search.value.toLowerCase())
//     );
//   },
//   { immediate: true }
// );

// watch(search, (newSearch) => {
//   filteredProducts.value = listProduct.value.filter((product) =>
//     product.name.toLowerCase().includes(newSearch.toLowerCase())
//   );
// });

// Lifecycle hooks
watchEffect(async () => {
  await productStore.handleGetProducts();
  await categoryStore.getAllCategory();
});

// Validation schema
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

// Methods
const { handleSubmit } = useForm({
  validationSchema: schema,
});

const handleUpdateProduct = (id: string) => {
  isModalUpdateProduct.value = true;
  productStore.handleSetProductUpdate(id);
};

const handleCloseModalUpdateProduct = () => {
  isModalUpdateProduct.value = false;
};

const handleDeleteProduct = async (id: string, name: string) => {
  const isConfirmed = window.confirm(
    `Bạn có chắc chắn muốn xóa sản phẩm ${name} không?`
  );
  if (!isConfirmed) return; // Nếu người dùng nhấn Cancel thì dừng tại đây
  await productStore.handleDeleteProduct(id);
};

// Handle form submission
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
</script>
