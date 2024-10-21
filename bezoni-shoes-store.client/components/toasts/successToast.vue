<template>
  <div
    class="flex justify-between items-center fixed top-0 right-0 bg-[#b6eacd] p-5 text-black rounded-md min-h-[70px] min-w-[400px] mt-[10px] border-[#0ca95c] border-b-4"
    v-if="isShow"
  >
    <div class="flex gap-4 justify-between items-center">
      <Icon
        name="clarity:success-standard-solid"
        class="text-[#0ca95c] text-[30px]"
      />
      <div>
        <div class="font-bold">Success</div>
        <div class="font-thin">{{ message }}</div>
      </div>
    </div>
    <div @click="closeToast">
      <Icon name="carbon:close" class="text-[30px] cursor-pointer" />
    </div>
  </div>
</template>

<script setup>
const { isShow, message } = defineProps({
  isShow: Boolean,
  message: String,
});
const emit = defineEmits(["update:isShow"]);

const closeToast = () => {
  emit("update:isShow", false);
};
</script>

<style scoped></style>
