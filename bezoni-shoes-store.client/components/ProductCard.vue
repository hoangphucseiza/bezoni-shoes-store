<template>
  <div
    class="flex flex-col min-h-[420px] min-w-[270px] border-[3px] border-[#a68660] rounded-2xl bg-[#F2F2F2] p-1 shadow-xl cursor-pointer hover:shadow-2xl"
    @click="router.push(`/products/${product.id}`)"
  >
    <img
      :src="product.image"
      alt="product"
      class="w-[260px] h-[280px] object-fit"
    />
    <div class="flex flex-col p-3">
      <div class="font-bold text-[19px]">{{ product.name }}</div>
      <div class="flex flex-col">
        <div class="line-through text-[18px] font-medium opacity-50">
          {{ formatPrice(product.price) }}đ
        </div>
        <div class="flex gap-2 items-center">
          <div class="text-[#F36123] text-[24px] font-bold">
            {{ formatPrice(roundNumber(product.price * (1 - product.voucher / 100))) }}đ
          </div>
          <div
            class="bg-[#FBD0BD] rounded-lg border-[1px] border-[#F36123] flex items-center"
          >
            <div class="text-[#F36123] font-[700] text-base px-3">
              {{ product.voucher }}%
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import type { IProductCard } from "~/interface/Response/IProductCard";
const router = useRouter();
const { product } = defineProps<{
  product: IProductCard;
}>();

// Function add price  to 000.000đ
const formatPrice = (price: number) => {
  return price.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".");
};

// Hàm làm tròn lên đến số thập phân thứ 1
const roundNumber = (num: number) => {
  return Math.round(num * Math.pow(10, 1)) / Math.pow(10, 1);
};
</script>

<style scoped></style>
