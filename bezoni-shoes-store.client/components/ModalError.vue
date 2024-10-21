<template>
  <div
    class="fixed top-0 right-0 left-0 bottom-0 bg-[##F3F5FB] flex items-center justify-center"
    v-if="isShow"
    >
    <div
      class="min-h-[200px] min-w-[450px] flex p-5 px-7 flex-col bg-[#FFFFFF] border-[2px] rounded-2xl"
    >
      <div class="font-bold mb-4 text-[20px]">Error Message</div>
      <div
        class="py-8 px-3 flex items-center gap-2 border-gray-300 border-t-[1px] border-b-[1px]"
      >
      <Icon name="material-symbols:cancel-rounded" class="text-[#f5422b] text-[30px]" />


        <div class="text-base font-[400]">{{ message }}</div>
      </div>
      <div class="flex mt-[15px]" @click="isShow=false">
        <button
          class="ml-auto bg-[#E32340] text-white rounded-[1233px] px-7 py-3 text-[13px] font-bold"
        >
          Close
        </button>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
const isShow = ref(true);
interface Props {
  message: string;
}
const props = withDefaults(defineProps<Props>(), {
  message: "Error",
});
</script>

<style scoped></style>
