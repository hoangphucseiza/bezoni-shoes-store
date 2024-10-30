<template>
  <div
    class="flex flex-col gap-5 border h-screen p-4 shadow-sm rounded-md relative bg-[#F5EDE6]"
  >
    <div
      class="flex justify-between items-center border-b-[1px] border-[#F36123] pb-5"
    >
      <div class="flex items-center gap-3">
        <div class="font-semibold">Danh mục</div>
        <select class="border border-gray-300 rounded-md p-2">
          <option value="0">Tất cả</option>
          <option
            v-for="(category, index) in listCategory"
            :key="index"
            :value="category.id"
          >
            {{ category.name }}
          </option>
        </select>
        <input
          type="text"
          placeholder="Tìm kiếm sản phẩm"
          class="border min-w-[300px] border-gray-300 rounded-md p-2"
        />
        <!-- Button Tìm kiếm -->
        <div
          class="flex items-center gap-2 bg-[#F36123] text-white text-[15px] font-bold rounded-md p-2 cursor-pointer hover:bg-[#f36123df] hover:shadow-xl"
        >
          <div>Tìm kiếm</div>
        </div>
      </div>
      <div class="flex gap-5">
        <div
          class="flex items-center gap-2 bg-[#F36123] text-white text-[15px] font-bold rounded-md p-2 cursor-pointer hover:bg-[#f36123df] hover:shadow-xl"
        >
          <div>Thêm item sản phẩm</div>
        </div>
        <div
          class="flex items-center gap-2 bg-[#F36123] text-white text-[15px] font-bold rounded-md p-2 cursor-pointer hover:bg-[#f36123df] hover:shadow-xl"
          @click="IsModalAddProduct = true"
          >
          <div>Thêm sản phẩm</div>
        </div>
        <div
          class="flex items-center gap-2 bg-[#F36123] text-white text-[15px] font-bold rounded-md p-2 cursor-pointer hover:bg-[#f36123df] hover:shadow-xl"
          @click="IsModalAddCategory = true"
        >
          <div>Thêm danh mục</div>
        </div>
      </div>
    </div>
    <div>Tables</div>
    <ModalAddCategory
      :IsModalAddCategory="IsModalAddCategory"
      :handleCloseModalAddCategory="handleCloseModalAddCategory"
    />
    <ModalAddProduct :IsModalAddProduct="IsModalAddProduct" :handleCloseModalAddProduct="handleCloseModalAddProduct" />
  </div>
</template>

<script setup lang="ts">
import { callApi, HttpMethods } from "~/ApiConfig/fetchData";
import type { IErrorSystem } from "~/interface/ErrorResponse/IErrorSystem";
import type { ICategoryResponse } from "~/interface/Response/ICategoryResponse";
import { useAlertStore } from "~/store/alertStore";
import { useAuthStore } from "~/store/authStore";
import { useCategoryStore } from "~/store/categoryStore";

const categoryStore = useCategoryStore();
definePageMeta({
  layout: "admin",
});

const IsModalAddCategory = ref(false);
const IsModalAddProduct = ref(false);

const handleCloseModalAddCategory = () => {
  IsModalAddCategory.value = false;
};
const handleCloseModalAddProduct = () => {
  IsModalAddProduct.value = false;
};
const authStore = useAuthStore();
const alertStore = useAlertStore();

// Bind `listCategory` to the `categories` state in the store
const listCategory = computed(() => categoryStore.categories);

onMounted(async () => {
  await categoryStore.getAllCategory();
});
// after mounted
</script>

<style scoped></style>
