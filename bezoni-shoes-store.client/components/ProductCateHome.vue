<template>
  <div class="flex flex-col items-center gap-[40px]">
    <div class="flex gap-2 text-3xl font-[600]">
      <div>SẢN PHẨM</div>
      <div class="text-[#F36123]">{{ productCate.categoryName.toUpperCase() }}</div>
    </div>
    <div class="flex flex-row gap-[60px] items-center justify-center">
      <div v-for="product in productCate.productList" :key="product.id">
        <ProductCard :product="product" />
      </div>
    </div>
    <div
      @click="
        router.push(`/products/${convertToPlainString(productCate.categoryName)}`)
      "
      class="bg-[#F36123] p-5 font-[500] text-white text-medium rounded-full cursor-pointer shadow-xl"
    >
      XEM THÊM SẢN PHẨM VỀ {{ productCate.categoryName.toUpperCase() }}
    </div>
  </div>
</template>

<script setup lang="ts">
import { defineProps } from "vue";
import type { IProductOfCategoryHome } from "~/interface/Response/IProductShowHome";
function convertToPlainString(input: string): string {
  const lowerCaseString = input.toLowerCase();

  const normalizedString = lowerCaseString
    .normalize("NFD")
    .replace(/[\u0300-\u036f]/g, "");
  const result = normalizedString.replace(/[\s,]+/g, "");

  return result;
}
const router = useRouter();
const { productCate } = defineProps<{
  productCate: IProductOfCategoryHome;
}>();
</script>

<style scoped></style>
