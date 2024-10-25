<template>
  <div class="py-[20px]">
    <div class="flex flex-row gap-2 text-[20px] mb-[20px] items-center">
      <Icon name="heroicons-solid:home" class="text-[25px] text-[#F36123]" />
      <NuxtLink
        to="/"
        class="font-bold cursor-pointer text-[#F36123] hover:underline"
        >Home /</NuxtLink
      >
      <div class="font-semibold">Bài viết</div>
    </div>
    <div class="grid grid-cols-10 gap-10">
      <div
        class="col-span-2 flex flex-col gap-5 text-[20px] border rounded-2xl p-4 max-h-min"
      >
        <div class="font-bold">Tìm kiếm bài viết</div>

        <input
          type="text"
          class="h-[20px] p-4 border border-gray-300 rounded-md"
          placeholder="Tìm kiếm bài viết"
        />
        <!-- Tìm kiếm -->
        <div
          class="bg-[#F36123] text-white text-[15px] py-2 px-2 rounded-lg flex items-center font-bold justify-center cursor-pointer hover:shadow-xl"
        >
          Search
        </div>
      </div>
      <div class="col-span-8 flex flex-col gap-5 px-[150px]">
        <div class="flex flex-col" v-for="b in blogData" :key="b.id">
          <BlogCardPage :blog="b" />
        </div>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { BlogSeedData } from "~/SeedData/BlogSeedData";
import { useDefaultLayoutStore } from "~/store/defaultLayoutStore";

const blogData = reactive(BlogSeedData);
const usedefaultLayout = useDefaultLayoutStore();
onMounted(() => {
  usedefaultLayout.chooseNav(4);
});
</script>

<style scoped></style>
