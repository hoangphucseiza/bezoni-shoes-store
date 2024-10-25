<template>
  <div>
    <LoadingPage />
    <ErrorToast />
    <SuccessToast />
    <div class="flex justify-center items-center h-screen">
      <div class="text-4xl font-bold">Admin Page</div>
    </div>
  </div>
</template>

<script setup lang="ts">
definePageMeta({
  layout: "admin",
});
</script>
