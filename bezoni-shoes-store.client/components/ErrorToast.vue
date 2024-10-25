<template>
  <div
    class="flex justify-between items-center fixed top-0 right-0 bg-[#fee3e3] p-5 text-black rounded-md min-h-[70px] min-w-[400px] mt-[10px] border-[#f5422b] border-b-4"
    v-if="alertStore.ErrorToastInfo.isShow"
  >
    <div class="flex gap-4 justify-between items-center">
      <Icon
        name="material-symbols:cancel-rounded"
        class="text-[#f5422b] text-[30px]"
      />
      <div>
        <div class="font-bold">Error</div>
        <div class="font-thin">{{ alertStore.ErrorToastInfo.message }}</div>
      </div>
    </div>
    <div @click="alertStore.handleCloseErrorToast">
      <Icon name="carbon:close" class="text-[30px] cursor-pointer" />
    </div>
  </div>
</template>

<script setup lang="ts">
import { useAlertStore } from "../store/alertStore";
const alertStore = useAlertStore();
</script>

<style scoped></style>
