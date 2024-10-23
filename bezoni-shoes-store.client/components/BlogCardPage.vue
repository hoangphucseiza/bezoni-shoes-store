<template>
  <div class="p-4 border rounded-xl shadow flex flex-col gap-3">
    <img :src="blog.image" alt="blog image" class="rounded-xl" />
    <div class="font-bold text-[30px]">{{ blog.title }}</div>
    <div>{{ blog.description }}</div>
    <div class="">
      <div
        class="float-right px-4 py-3 border rounded-2xl bg-[#F36123] text-white font-bold cursor-pointer hover:bg-[#f36123ed] transition-all duration-200"
        @click="() => $router.push(`/blogs/${blog.id}`)"
        >
        XEM THÊM
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import type { IBlogCard } from "~/interface/Response/IBlogCard";

const { blog } = defineProps<{
  blog: IBlogCard;
}>();
</script>
