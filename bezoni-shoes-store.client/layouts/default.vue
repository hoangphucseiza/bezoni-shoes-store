<template>
  <div class="default_layout">
    <div
      class="relative default_layout_header flex flex-row justify-between py-[30px] px-[100px] border-black rounded-md items-center shadow-sm"
    >
      <div
        class="flex flex-row gap-5"
        @click="
          listNagivation.forEach((item) => (item.isChoose = false));
          listNagivation[0].isChoose = true;
        "
      >
        <!-- <img src="/assets/images/header/logo.png" alt="logo" class="w-[100px] h-[100px]" /> -->
        <NuxtLink
          to="/"
          class="text-[#F36123] text-4xl font-bold cursor-pointer"
          >Bezoni</NuxtLink
        >
      </div>
      <div
        class="flex flex-row gap-10 text-lg font-medium absolute left-1/2 transform -translate-x-1/2"
      >
        <NuxtLink
          v-for="(item, index) in listNagivation"
          :key="index"
          :to="item.path"
          class="cursor-pointer"
          :class="item.isChoose ? 'text-[#F36123]' : ''"
          @click="
            listNagivation.forEach((item) => (item.isChoose = false));
            item.isChoose = true;
          "
          >{{ item.name }}</NuxtLink
        >
      </div>
      <div class="flex flex-row gap-5 justify-between items-center">
        <div class="flex items-center justify-center gap-2">
          <input
            v-if="isSearch"
            type="text"
            class="h-[35px] w-[300px] border-[2px] border-[#F36123] rounded-lg px-4 focus:outline-none animate-search animate-close-search"
            :class="isSearch ? 'animate-search-open' : ''"
            placeholder="Tìm kiếm"
            @keyup.enter="isSearch = false"
          />
          <Icon
            class="cursor-pointer text-[25px]"
            name="uil:search"
            @click="isSearch = !isSearch"
            style="color: black"
          />
        </div>
        <NuxtLink to="/cart">
          <div
            class="cursor-pointer bg-[#F36123] h-[40px] w-[40px] rounded-lg flex items-center justify-center hover:bg-[#ef855b]"
          >
            <Icon
              class="text-[30px]"
              name="material-symbols-light:shopping-bag"
              style="color: white"
            />
          </div>
        </NuxtLink>
        <Icon
          class="cursor-pointer text-[30px]"
          name="material-symbols:account-circle"
          style="color: black"
        />
      </div>
    </div>
    <div class="default_layout_content px-[100px] my-4 h-screen">
      <slot />
    </div>
    <div class="default_layout_footer">This is footer</div>
  </div>
</template>

<script setup lang="ts">
const isSearch = ref(false);
const listNagivation = ref([
  {
    name: "Home",
    path: "/",
    isChoose: true,
  },
  {
    name: "Giày",
    path: "/products/giay",
    isChoose: false,
  },
  {
    name: "Ví",
    path: "/products/vi",
    isChoose: false,
  },
  {
    name: "Nịt",
    path: "/products/nit",
    isChoose: false,
  },
  {
    name: "Bài viết",
    path: "/blogs",
    isChoose: false,
  },
]);
</script>

<style scoped>
@keyframes search {
  0% {
    width: 0;
  }
  100% {
    width: 300px;
  }
}
.animate-search-open {
  animation: search 0.3s ease forwards;
}
</style>
