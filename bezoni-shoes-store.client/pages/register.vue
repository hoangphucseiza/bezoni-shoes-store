<template>
    <div
      class="bg-gradient-to-t from-[#D74177] to-[#FFE98A] h-full flex items-center justify-center"
    >
      <div
        class="w-1/4.5 h-4/5 bg-[white] rounded-2xl border border-gray-300 shadow-lg p-4 flex flex-col p-[50px] items-center gap-10"
      >
        <div class="text-[35px] font-bold mb-[50px] cursor-pointer ">Register</div>
        <div class="relative flex flex-col gap-6 mb-[50px]">
          <div
            class="flex gap-2 items-center justify-center border-b-2 border-gray-300 pb-[2px]"
          >
            <Icon name="material-symbols:person" class="text-[23px]" />
            <input
              type="text"
              class="w-[250px] h-[40px] px-2 focus:outline-none"
              placeholder="email"
            />
          </div>
          <div
            class="flex gap-2 items-center justify-center border-b-2 border-gray-300 pb-[2px]"
          >
            <Icon name="mynaui:lock-password-solid" class="text-[23px]" />
            <input
              type="password"
              class="w-[250px] h-[40px] px-2 focus:outline-none"
              placeholder="password"
            />
          </div>
          <Nuxtlink
            class="absolute bottom-0 right-0 translate-y-8 text-base underline cursor-pointer"
            >forgot password</Nuxtlink
          >
        </div>
        <div
          class="w-[300px] h-[40px] bg-[#D74177] text-white rounded-lg flex items-center font-bold justify-center cursor-pointer hover:bg-[#db5382]"
        >
        REGISTER
        </div>
        <div class="flex flex-col items-center gap-2 mb-[20px] ">
          <div>or sign in using</div>
          <div class="flex gap-10 cursor-pointer">
            <Icon name="logos:facebook" class="text-[35px]" />
            <Icon name="devicon:google" class="text-[35px]" />
          </div>
        </div>
        <NuxtLink to="/login" class="cursor-pointer hover:underline">you have an account?</NuxtLink>
      </div>
    </div>
  </template>
  
  <script setup lang="ts">
  definePageMeta({
    layout: "auth",
  });
  </script>
  
  <style scoped></style>
  