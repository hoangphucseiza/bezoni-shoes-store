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
          v-for="(nav, index) in adminLayoutStore.listNagivation"
          :key="index"
          @click="adminLayoutStore.chooseNav(index)"
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
      <div
        class="bg-[#d4b3953c] flex justify-between p-5 px-6 shadow-lg items-center"
      >
        <NuxtLink
          class="flex items-center gap-1 justify-center text-black hover:text-[#F36123] hover:underline cursor-pointer"
          to="/"
        >
          <Icon
            name="material-symbols:home-rounded"
            class="text-[25px] cursor-pointer"
          />
          <div class="text-[20px] font-medium">Go Home</div>
        </NuxtLink>
        <div class="flex flex-row gap-6 items-center">
          <Icon
            name="material-symbols:notifications-unread"
            class="text-[25px] cursor-pointer text-[#F36123]"
          />
          <div class="flex gap-2 items-center cursor-pointer">
            <img
              :src="authStore.user?.avatar"
              alt="avatar"
              class="w-[40px] h-[40px] rounded-full"
            />
            <div class="">
              <div class="font-medium">{{ authStore.user.fullName }}</div>
              <div class="">{{ authStore.user.userName }}</div>
            </div>
          </div>
        </div>
      </div>
      <div class="p-5"><slot /></div>
    </div>
    <LoadingPage />
  </div>
</template>

<script setup lang="ts">
import { callApi, HttpMethods } from "~/ApiConfig/fetchData";
import { useAdminLayoutStore } from "~/store/adminLayoutStore";
import { useAlertStore } from "~/store/alertStore";
import { useAuthStore } from "~/store/authStore";

const router = useRouter();
const alertStore = useAlertStore();
const adminLayoutStore = useAdminLayoutStore();
const authStore = useAuthStore();
const checkRole = async () => {
  alertStore.handleLoadingPage(true);
  const accessToken = localStorage.getItem("accessToken");
  try {
    if (accessToken) {
      const role = (await callApi(
        `Admin/GetRoleByAccessToken?request=${accessToken}`,
        HttpMethods.GET
      )) as string;
      if (role) {
        if (role === "Admin") {
          console.log("Admin");
          alertStore.handleLoadingPage(false);
        } else {
          router.push("/");
          alertStore.handleLoadingPage(false);
        }
      }
    }
  } catch (error: any) {
    console.log(error);
    alertStore.handleLoadingPage(false);
  }
};
const checkNavigation = () => {
  const path = router.currentRoute.value.path;
  adminLayoutStore.checkPath(path);
};
onMounted(() => {
  checkRole();
  checkNavigation();
});
</script>

<style scoped></style>
