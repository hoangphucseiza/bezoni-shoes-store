<template>
  <div
    class="bg-gradient-to-t from-[#D74177] to-[#FFE98A] h-full flex items-center justify-center"
  >
    <div class="absolute left-5 top-[30px]">
      <NuxtLink to="/">
        <Icon
          name="material-symbols:arrow-back"
          class="text-[40px] text-[#f36123] cursor-pointer"
        />
      </NuxtLink>
    </div>
    <div
      class="w-1/4.5 h-4/5 bg-[white] rounded-2xl border border-gray-300 shadow-lg p-4 flex flex-col p-[50px] items-center gap-10"
    >
      <div class="text-[35px] font-bold mb-[50px] cursor-pointer">Login</div>
      <div class="relative flex flex-col gap-10 mb-[50px]">
        <div
          class="flex gap-2 items-center justify-center border-b-2 border-gray-300 pb-[2px] relative"
        >
          <Icon name="material-symbols:person" class="text-[23px]" />
          <input
            type="text"
            class="w-[250px] h-[40px] px-2 focus:outline-none"
            placeholder="email"
            v-model="email"
          />
          <div class="text-red-500 absolute bottom-0 left-0 translate-y-[30px]">
            {{ emailError }}
          </div>
        </div>
        <div
          class="flex gap-2 items-center justify-center border-b-2 border-gray-300 pb-[2px] relative"
        >
          <Icon name="mynaui:lock-password-solid" class="text-[23px]" />
          <input
            type="password"
            class="w-[250px] h-[40px] px-2 focus:outline-none"
            placeholder="password"
            v-model="password"
          />
          <div class="text-red-500 absolute bottom-0 left-0 translate-y-[30px]">
            {{ passwordError }}
          </div>
        </div>
        <Nuxtlink
          class="absolute bottom-0 right-0 translate-y-12 text-base underline cursor-pointer"
          >forgot password</Nuxtlink
        >
      </div>
      <div
        @click="submitForm"
        class="w-[300px] h-[40px] bg-[#D74177] text-white rounded-lg flex items-center font-bold justify-center cursor-pointer hover:bg-[#db5382]"
      >
        LOGIN
      </div>
      <div class="flex flex-col items-center gap-2 mb-[20px]">
        <div>or sign in using</div>
        <div class="flex gap-10 cursor-pointer">
          <Icon name="logos:facebook" class="text-[35px]" />
          <Icon name="devicon:google" class="text-[35px]" />
        </div>
      </div>
      <NuxtLink to="/register" class="cursor-pointer hover:underline"
        >create a account</NuxtLink
      >
    </div>
    <successToast v-model:isShow="isShowSuccess" message="Login Success" />
    <errorToast v-model:isShow="isShowError" :message="messageError" />
    <div v-if="isLoadingPage">
      <loadingPage/>
    </div>
  </div>
</template>

<script setup lang="ts">

import { string, object, ref as yupRef } from "yup";
import { useField, useForm } from "vee-validate";
import type { LoginBody } from "~/interface/RequestBody/LoginBody";
import type { AuthenticationRespone } from "~/interface/Response/AuthenticationRespone";
import { postDataAPI } from "~/ApiConfig/fetchData";
import successToast from "~/components/toasts/successToast.vue";
import errorToast from "~/components/toasts/errorToast.vue";
import loadingPage from "~/components/loadingPage.vue";


definePageMeta({
  layout: "auth",
});
const isShowSuccess = ref(false);
const isShowError = ref(false);
const isLoadingPage = ref(false);

const messageSuccess = ref("");
const messageError = ref("");


const router = useRouter();

const schema = object({
  email: string().email("Invalid email").required("Email is required"),
  password: string()
    .min(6, "Password must be at least 6 characters")
    .required("Password is required"),
});

// Set up form with schema validation
const { handleSubmit } = useForm({
  validationSchema: schema,
});

// Field validation setup
const { value: email, errorMessage: emailError } = useField("email");
const { value: password, errorMessage: passwordError } = useField("password");

// Form submission
const submitForm = handleSubmit(async (values: any) => {
  const body: LoginBody = {
    email: values.email,
    password: values.password,
  };

  // Loading page
  isLoadingPage.value = true;
  const { data, error } = await postDataAPI("Authentication/Login", body);
  isLoadingPage.value = false;
  if (data) {
    isShowError.value = false;
    isShowSuccess.value = true;
    // Push data to pinia store


    if(data.role  == "Admin"){
      //Router to Admin Page
      router.push("/admin");
    } else {
      //Router to User Page
      router.push("/");
    }

  } else {
    isShowSuccess.value = false;
    isShowError.value = true;
    messageError.value = error.title;
  }
});
</script>

<style scoped></style>
