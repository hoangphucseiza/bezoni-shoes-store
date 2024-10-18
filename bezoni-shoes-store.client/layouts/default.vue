<template>
  <div class="default_layout">
    <div class="default_layout_header flex flex-row justify-between p-5 px-10  border-black rounded-md items-center">
      <div class="flex flex-row gap-5">
        <!-- <img src="/assets/images/header/logo.png" alt="logo" class="w-[100px] h-[100px]" /> -->
        <div class="text-[#F36123] text-4xl font-bold">Bezoni</div>
      </div>
      <div class="flex flex-row gap-10">
        <div>Home</div>
        <div>Giày</div>
        <div>Ví</div>
        <div>Nịt</div>
        <div>Bài viết</div>
      </div>
      <div class="flex flex-row gap-5">
        <div>Search</div>
        <div>Shop Card</div>
        <div>Authen</div>
      </div>
    </div>
    <div class="default_layout_content p-10 ">
      <slot />
    </div>
    <div class="default_layout_footer">This is footer</div>
  </div>
</template>

<script setup lang="ts"></script>

<style scoped></style>
