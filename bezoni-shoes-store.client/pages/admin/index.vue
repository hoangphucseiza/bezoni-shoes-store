<template>
  <div>
    <div class="flex justify-center items-center h-screen">
      <div class="text-4xl font-bold">Admin Page</div>
    </div>
    <LoadingPage />
    <ErrorToast />
    <SuccessToast />
  </div>
</template>

<script setup lang="ts">
definePageMeta({
  layout: "admin",
});
onMounted(() => {
  window.location.href = "/admin/products";
});
</script>
