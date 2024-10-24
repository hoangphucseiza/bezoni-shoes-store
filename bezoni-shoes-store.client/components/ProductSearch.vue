<template>
  <div
    class="flex hover:bg-[#f361234f] w-full p-2 rounded-lg items-center space-x-2 justify-between cursor-pointer"
  >
    <div class="text-sm font-semibold">
      <div>{{ item.name }}</div>
      <div class="flex gap-2">
        <span class="text-[#F36123] font-bold"
          >{{
            formatPrice(roundNumber(item.price * (1 - item.voucher / 100)))
          }}đ</span
        >
        <span class="line-through text-gray-400"
          >{{ formatPrice(item.price) }}đ</span
        >
      </div>
    </div>

    <img
      :src="item.image"
      :alt="`Image of ${item.name}`"
      class="w-12 h-12 rounded-lg object-cover"
    />
  </div>
</template>

<script setup lang="ts">
import type { IProductCardSearch } from "~/interface/Response/IProductCardSearch";

const { item } = defineProps<{
  item: IProductCardSearch;
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
