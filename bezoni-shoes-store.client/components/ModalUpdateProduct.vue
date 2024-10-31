<template>
  <!-- Modal -->
  <div v-if="isModalUpdateProduct">
    <!-- Modal panel -->
    <div
      class="flex flex-col fixed inset-0 my-8 mx-auto w-full max-h-fit max-w-3xl bg-white rounded-xl p-5 border-2 border-[#f36123df] shadow-2xl gap-5"
    >
      <div>
        <h2 class="text-[20px] font-semibold text-center border-b pb-2">
          Chỉnh sửa sản phẩm
        </h2>
      </div>
      <div class="flex flex-col gap-5">
        <!-- Product Name -->
        <div class="flex flex-col gap-2">
          <label class="text-[20px] font-semibold text-start"
            >Tên sản phẩm:</label
          >
          <input
            type="text"
            class="border border-gray-300 rounded-md p-2 w-full"
            placeholder="Tên sản phẩm"
            v-model="productUpdate.name"
          />
        </div>

        <!-- Price -->
        <div class="flex flex-col gap-2">
          <label class="text-[20px] font-semibold text-start"
            >Giá sản phẩm:</label
          >
          <input
            type="number"
            class="border border-gray-300 rounded-md p-2 w-full"
            placeholder="Giá sản phẩm"
            v-model="productUpdate.price"
          />
        </div>

        <!-- Voucher -->
        <div class="flex flex-col gap-2 text-start">
          <label class="text-[20px] font-semibold">Voucher sản phẩm (%):</label>
          <input
            type="number"
            class="border border-gray-300 rounded-md p-2 w-full"
            placeholder="Voucher sản phẩm"
            v-model="productUpdate.voucher"
          />
        </div>

        <!-- Description -->
        <div class="flex flex-col gap-2">
          <label class="text-[20px] font-semibold text-start">Mô tả:</label>
          <input
            type="text"
            class="border border-gray-300 rounded-md p-2 w-full"
            placeholder="Mô tả"
            v-model="productUpdate.description"
          />
        </div>

        <!-- Category -->
        <div class="flex flex-col gap-2">
          <label class="text-[20px] font-semibold text-start"
            >Sản phẩm thuộc danh mục nào:</label
          >
          <select
            class="border border-gray-300 rounded-md p-2"
            v-model="productUpdate.categoryID"
          >
            <option value="" disabled>Chọn danh mục</option>
            <option
              v-for="category in categoryStore.categories"
              :key="category.id"
              :value="category.id"
            >
              {{ category.name }}
            </option>
          </select>
        </div>
      </div>
      <div class="flex justify-center items-center gap-10 py-3 mt-5">
        <button
          @click="handleCloseModalUpdateProduct"
          class="bg-[#000000df] text-white font-semibold py-2 px-4 rounded-md"
        >
          Đóng
        </button>
        <!-- Button Update -->
        <button
          class="bg-[#f36123df] text-white font-semibold py-2 px-4 rounded-md"
          @click="handleUpdateProduct"
        >
          Cập nhật
        </button>
      </div>
    </div>
  </div>
</template>

  <script setup lang="ts">
import { number, string } from "yup";
import type { IProductUpdate } from "~/interface/RequestBody/IProductUpdate";
import { useCategoryStore } from "~/store/categoryStore";
import { useProductStore } from "~/store/productStore";

const props = defineProps<{
  isModalUpdateProduct: boolean;
  handleCloseModalUpdateProduct: () => void;
}>();

const handleUpdateProduct = () => {
  productStore.handleUpdateProduct(productUpdate.value);
};

const productStore = useProductStore();
const categoryStore = useCategoryStore();

const productUpdate = computed(
  () => productStore.productUpdate
) as Ref<IProductUpdate>;
</script> 

  <style scoped>
</style>