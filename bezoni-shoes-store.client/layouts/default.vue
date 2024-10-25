<template>
  <div class="default_layout flex flex-col">
    <div
      class="relative default_layout_header flex flex-row justify-between py-[30px] px-[100px] border-black rounded-md items-center shadow"
    >
      <div class="flex flex-row gap-5" @click="defaultLayoutStore.chooseNav(0)">
        <!-- <img src="/assets/images/header/logo.png" alt="logo" class="w-[100px] h-[100px]" /> -->
        <NuxtLink
          to="/"
          class="text-[#F36123] text-4xl font-bold cursor-pointer"
        >
          Bezoni
        </NuxtLink>
      </div>
      <div
        class="flex flex-row gap-10 text-lg font-medium absolute left-1/2 transform -translate-x-1/2"
      >
        <NuxtLink
          v-for="(item, index) in defaultLayoutStore.listNagivation"
          :key="index"
          :to="item.path"
          class="cursor-pointer"
          :class="{ 'text-[#F36123]': item.isChoose }"
          @click="defaultLayoutStore.chooseNav(index)"
        >
          {{ item.name }}
        </NuxtLink>
      </div>
      <div class="flex flex-row gap-5 justify-between items-center">
        <div class="flex items-center justify-center gap-2">
          <div class="flex flex-col relative">
            <input
              v-if="isSearch"
              type="text"
              ref="searchInput"
              class="h-[35px] w-[300px] border-[2px] border-[#F36123] rounded-lg px-4 focus:outline-none animate-search"
              :class="isSearch ? 'animate-search-open' : ''"
              placeholder="Tìm kiếm sản phẩm"
              @keyup.enter="handleSearchProduct"
            />
            <div
              class="absolute right-0 top-10 z-50 w-full max-h-[200px] border rounded flex flex-col bg-white shadow-lg p-2 overflow-y-scroll gap-2 cursor-pointer"
              v-if="isSearch && modalSearch"
            >
              <div v-for="(item, index) in productSearch" :key="index">
                <div @click="handleClickProductSearch(item.id)">
                  <ProductSearch :item="item" :key="item.id" />
                </div>
              </div>
            </div>
          </div>
          <Icon
            class="cursor-pointer text-[25px]"
            name="uil:search"
            @click="toggleSearch"
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
        <div
          class="flex items-center justify-center cursor-pointer relative"
          @click="handleClickUser"
        >
          <Icon
            class="text-[30px]"
            name="material-symbols:account-circle"
            style="color: black"
          />
          <div v-if="dropDownUser" class="z-50">
            <div
              class="absolute top-[40px] right-0 w-[150px] bg-white border border-gray-300 rounded-lg shadow-lg flex flex-col text-[15px]"
            >
              <NuxtLink
                to="/admin"
                class="cursor-pointer p-2 hover:bg-[#F36123] hover:text-white rounded-lg flex gap-2 items-center"
              >
                <Icon
                  name="icon-park-twotone:dashboard-one"
                  class="text-[20px]"
                />
                <div>Dashboard</div>
              </NuxtLink>
              <NuxtLink
                to="/profile"
                class="cursor-pointer p-2 hover:bg-[#F36123] hover:text-white rounded-lg flex gap-2 items-center"
              >
                <Icon name="material-symbols:account-box" class="text-[20px]" />
                <div>Profile</div>
              </NuxtLink>
              <NuxtLink
                to="/login"
                class="cursor-pointer p-2 hover:bg-[#F36123] hover:text-white rounded-lg flex gap-2 items-center"
              >
                <Icon name="material-symbols:key-rounded" class="text-[20px]" />
                <div>Login</div>
              </NuxtLink>
              <NuxtLink
                to="/"
                @click="handleLogout"
                class="cursor-pointer p-2 hover:bg-[#F36123] hover:text-white rounded-lg flex gap-2 items-center"
              >
                <Icon name="lucide:log-out" class="text-[20px]" />
                <div>Logout</div>
              </NuxtLink>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="default_layout_content px-[100px] my-2 min-h-[900px]">
      <slot />
    </div>
    <div
      class="default_layout_footer flex flex-col gap-10 py-[30px] px-[100px] min-h-[550px] border-black rounded-md shadow-sm bg-[#F36123] text-white"
    >
      <div class="flex flex-row gap-5">
        <div class="flex-1 flex flex-col gap-5">
          <div class="font-bold text-[30px]">Bezoni</div>
          <div class="flex flex-row gap-5">
            <img
              src="/assets/images/header/logofooter.jpg"
              alt="logoFooter"
              class="w-[150px] h-[150px] rounded-xl"
            />
            <div class="max-w-[500px] text-[18px]">
              Bezoni luôn chú trọng đổi mới và cải thiện không ngừng nhằm mang
              tới cho quý Khách Hàng chất lượng sản phẩm, dịch vụ tốt nhất. Sự
              tin tưởng và đồng hành của quý Khách Hàng là tài sản lớn nhất của
              chúng tôi.
            </div>
          </div>
          <div class="flex gap-5">
            <Icon
              class="cursor-pointer text-[35px]"
              name="logos:facebook"
              @click="navigateToFacebook"
            />
            <Icon
              class="cursor-pointer text-[35px]"
              name="lineicons:tiktok"
              style="color: black"
            />
            <Icon
              class="cursor-pointer text-[35px]"
              name="skill-icons:instagram"
            />
          </div>
          <div class="flex flex-col">
            <div class="font-bold text-[30px]">0865 257 828</div>
            <div>Tổng đài CSKH, Góp ý & Khiếu nại (08:00 – 17:00)</div>
          </div>
          <div class="flex flex-col">
            <div class="font-bold text-[30px]">0395 474 765</div>
            <div>Hỗ trợ đơn hàng online (08:00 – 17:00)</div>
          </div>
        </div>
        <div class="flex-1 flex flex-col gap-[40px]">
          <div class="flex flex-row justify-between">
            <div class="flex flex-col gap-4">
              <div class="font-bold text-[20px]">VỀ CHÚNG TÔI</div>
              <div class="flex flex-col gap-2">
                <NuxtLink to="/blogs" class="cursor-pointer hover:underline"
                  >Giới thiệu</NuxtLink
                >
                <NuxtLink to="/blogs" class="cursor-pointer hover:underline"
                  >Liên hệ, thanh toán</NuxtLink
                >
              </div>
            </div>
            <div class="flex flex-col gap-4">
              <div class="font-bold text-[20px]">CHÍNH SÁCH</div>
              <div class="flex flex-col gap-2">
                <NuxtLink to="/blogs" class="cursor-pointer hover:underline"
                  >Vận chuyển</NuxtLink
                >
                <NuxtLink to="/blogs" class="cursor-pointer hover:underline"
                  >Bảo hành</NuxtLink
                >
                <NuxtLink to="/blogs" class="cursor-pointer hover:underline"
                  >Đổi trả</NuxtLink
                >
                <NuxtLink to="/blogs" class="cursor-pointer hover:underline"
                  >Khách hàng thân thiết</NuxtLink
                >
                <NuxtLink to="/blogs" class="cursor-pointer hover:underline"
                  >Bảo mật thông tin</NuxtLink
                >
              </div>
            </div>
            <div class="flex flex-col gap-4">
              <div class="font-bold text-[20px]">HƯỚNG DẪN</div>
              <div class="flex flex-col gap-2">
                <NuxtLink to="/blogs" class="cursor-pointer hover:underline"
                  >Đo size</NuxtLink
                >
                <NuxtLink to="/blogs" class="cursor-pointer hover:underline"
                  >Bảo quản sản phẩm</NuxtLink
                >
              </div>
            </div>
          </div>
          <div class="flex flex-col gap-2">
            <div class="font-bold text-[20px]">ĐỊA CHỈ</div>
            <div
              class="hover:underline cursor-pointer"
              @click="handleClickLocation"
            >
              Hiệu Giày Tân Tiến, Khu Vực Trung Tâm xã Bình Hòa, Bình Sơn, Quảng
              Ngãi
            </div>
            <div>
              <iframe
                src="https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d18180.279216311294!2d108.832612!3d15.293592000000002!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31684bdcef396c27%3A0x3836c7dd468ba4ca!2zSGnhu4d1IEdpw6B5IFTDom4gVGnhur9u!5e1!3m2!1sen!2sus!4v1729627375020!5m2!1sen!2sus"
                width="600"
                height="300"
                style="border: 0"
                allowfullscreen="true"
                loading="lazy"
                referrerpolicy="no-referrer-when-downgrade"
              ></iframe>
            </div>
          </div>
        </div>
      </div>
      <div class="flex justify-center">
        Bezoni Copyright © 2024. Bezoni. Provide by hoangphucseiza
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ProductSearchSeedData } from "~/SeedData/ProductSearchSeedData";
import { useAuthStore } from "~/store/authStore";
import { useDefaultLayoutStore } from "~/store/defaultLayoutStore";

const defaultLayoutStore = useDefaultLayoutStore();
const authStore = useAuthStore();

const router = useRouter();
const isSearch = ref(false);

const modalSearch = ref(false);
const handleSearchProduct = () => {
  modalSearch.value = true;
};

const handleLogout = () => {
  localStorage.removeItem("accessToken");
  localStorage.removeItem("refreshToken");
  window.location.href = "/";
};
const handleClickLocation = () => {
  window.location.href =
    "https://www.google.com/maps/place/Hi%E1%BB%87u+Gi%C3%A0y+T%C3%A2n+Ti%E1%BA%BFn/@15.293592,108.832612,4175m/data=!3m1!1e3!4m6!3m5!1s0x31684bdcef396c27:0x3836c7dd468ba4ca!8m2!3d15.2935919!4d108.832612!16s%2Fg%2F11gnt10lsw?hl=en&entry=ttu&g_ep=EgoyMDI0MTAxNi4wIKXMDSoASAFQAw%3D%3D";
};
const navigateToFacebook = () => {
  window.location.href = "https://www.facebook.com/bezonishoes";
};

const toggleSearch = () => {
  isSearch.value = !isSearch.value;

  if (modalSearch.value == true) {
    modalSearch.value = false;
  }
};
const dropDownUser = ref(false);
const handleClickUser = () => {
  dropDownUser.value = !dropDownUser.value;
};

const productSearch = reactive(ProductSearchSeedData);

const handleClickProductSearch = (id: string) => {
  router.push(`/products/${id}`);
  isSearch.value = false;
  modalSearch.value = false;
};
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
