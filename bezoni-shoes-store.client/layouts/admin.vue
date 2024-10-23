<template>
  <div class="grid grid-cols-7 h-screen">
    <div class="col-span-1 bg-[#d4b3953c] border-[1px] shadow-lg">
      <img
        src="/assets/images/header/logoxoaphong.png"
        alt="logo"
        class="rounded-3xl p-5"
      />
      <!-- Line border -->

      <div class="flex flex-col">
        <div
          v-for="(nav, index) in listNagivate"
          :key="index"
          @click="chooseNav(index)"
        >
          <div
            class="cursor-pointer flex flex-col justify-center items-center h-[70px] text-[18px] font-medium"
          >
            <NuxtLink
              :to="nav.path"
              :class="{ 'bg-[#F36123] text-white': nav.isChoose }"
              class="w-full h-full flex justify-center items-center cursor-pointer"
              >{{ nav.name }}</NuxtLink
            >
          </div>
        </div>
      </div>
    </div>
    <div class="col-span-6">
      <div class="bg-[#d4b3953c] flex justify-between p-5 px-6 shadow-lg items-center">
        <Icon
          name="material-symbols:filter-list"
          class="text-[25px] cursor-pointer"
        />
        <div class="flex flex-row gap-6 items-center">
          <Icon
            name="material-symbols:notifications-unread"
            class="text-[25px] cursor-pointer text-[#F36123]"
          />
          <div class="flex gap-2 items-center cursor-pointer">
           <img src="/assets/images/header/logouser.jpg" alt="avatar" class="w-[40px] h-[40px] rounded-full" />
            <div class="">
              <div class="font-medium">Nguyễn Hoàng Phúc</div>
              <div class="">hoangphucseiza</div>
            </div>
          </div>
        </div>
      </div>
      <div class="p-5"><slot /></div>
    </div>
  </div>
</template>

<script setup lang="ts">
const listNagivate = ref([
  {
    name: "Dashboard",
    path: "/admin",
    isChoose: true,
  },
  {
    name: "Manage Products",
    path: "/admin/products",
    isChoose: false,
  },
  {
    name: "Manage Users",
    path: "/admin/users",
    isChoose: false,
  },
  {
    name: "Manage Orders",
    path: "/admin/orders",
    isChoose: false,
  },
  {
    name: "Manage Vouchers",
    path: "/admin/vouchers",
    isChoose: false,
  },
  {
    name: "Manage Blogs",
    path: "/admin/blogs",
    isChoose: false,
  },
  {
    name: "Manage Settings",
    path: "/admin/settings",
    isChoose: false,
  },
]);
const chooseNav = (index: number) => {
  listNagivate.value.forEach((item) => (item.isChoose = false));
  listNagivate.value[index].isChoose = true;
};
// animation for sidebar
</script>

<style scoped></style>
