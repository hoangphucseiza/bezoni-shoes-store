<template>
  <div
    class="fixed top-0 right-0 left-0 bottom-0 bg-[##F3F5FB] flex items-center justify-center bg-[#000000] bg-opacity-50"
    v-if="alertStore.ModalWarning.isShow"
  >
    <div
      class="min-h-[200px] min-w-[450px] flex p-5 px-7 flex-col bg-[#FFFFFF] border-[2px] rounded-2xl"
    >
      <div class="font-bold mb-4 text-[20px]">Warning Message</div>
      <div
        class="py-8 px-3 flex items-center gap-2 border-gray-300 border-t-[1px] border-b-[1px]"
      >
        <Icon
          name="material-symbols:cancel-rounded"
          class="text-[#f5422b] text-[30px]"
        />

        <div class="text-base font-[400]">
          {{ alertStore.ModalWarning.message }}
        </div>
      </div>
      <div class="flex mt-[15px] justify-center gap-10">
        <button
          class=" bg-[#35cd2a] text-white rounded-[1233px] px-7 py-3 text-[13px] font-bold"
          @click="alertStore.handleOkModalWarning"
        >
          Ok
        </button>
        <button
          class=" bg-[#000000] text-white rounded-[1233px] px-7 py-3 text-[13px] font-bold"
          @click="alertStore.handleCloseModalWarning"
        >
          Close
        </button>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { useAlertStore } from "~/store/alertStore";

const alertStore = useAlertStore();
</script>

<style scoped></style>
