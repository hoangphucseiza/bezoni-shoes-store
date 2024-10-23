<template>
  <div class="flex flex-col   pb-5">
    <div class="flex flex-row gap-2 text-[20px] mb-[20px] items-center">
      <Icon name="heroicons-solid:home" class="text-[25px] text-[#F36123]" />
      <NuxtLink
        to="/"
        class="font-bold cursor-pointer text-[#F36123] hover:underline"
        >Home /</NuxtLink
      >
      <NuxtLink class="font-semibold hover:underline" to="/blogs" >Tin tức /</NuxtLink>
      <div class="font-semibold ">{{ blog.title }}</div>
    </div>
    <div class="items-center flex flex-col gap-5">
      <div class="font-[500] text-[30px]">{{ blog.title }}</div>
      <div id="blogContent" class="font-[400] text-[20px]"></div>
      <!-- <div class="font-[500] text-[30px] mt-5">Các bài viết liên quan</div> -->
    </div>
  </div>
</template>

<script setup lang="ts">
import { BlogDetailSeedData } from "~/SeedData/BlogDetailSeedData";
const blog = reactive(BlogDetailSeedData); 

// Function to update the inner HTML of the BlogContent div
const updateBlogContent = () => {
  const blogContentElement = document.getElementById("blogContent");
  if (blogContentElement) {
    blogContentElement.innerHTML = blog.content;
  }
};

// Set initial content when the component is mounted
onMounted(() => {
  updateBlogContent();
});
</script>

<style scoped></style>
