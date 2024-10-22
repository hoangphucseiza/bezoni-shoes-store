<template>
  <div
    class="flex flex-col min-h-[420px] min-w-[270px] border-[3px] border-[#a68660] rounded-2xl bg-[#F2F2F2] p-1 shadow-xl cursor-pointer hover:shadow-2xl"
  >
    <img
      :src="products.product.image"
      alt="product"
      class="w-[260px] h-[280px] object-fit"
    />
    <div class="flex flex-col p-3">
      <div class="font-bold text-[19px]">{{ products.product.name }}</div>
      <div class="flex flex-col">
        <div class="line-through text-[18px] font-medium opacity-50">
          {{ products.product.price }}đ
        </div>
        <div class="flex gap-2 items-center">
          <div class="text-[#F36123] text-[24px] font-bold">
            {{
              formatPrice(
                products.product.price * (1 - products.product.vouncher / 100)
              )
            }}
          </div>
          <div class="bg-[#FBD0BD] rounded-lg border-[1px] border-[#F36123] flex items-center  ">
            <div class="text-[#F36123] font-[700] text-base px-3 ">
              {{ products.product.vouncher }}%
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import type { IProductHomeInfo } from "~/interface/Response/IProductShowHome";

const products = defineProps<{
  product: IProductHomeInfo;
}>();

// Function add price  to 000.000đ
const formatPrice = (price: number) => {
  return price.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".");
};
</script>

<style scoped></style>
