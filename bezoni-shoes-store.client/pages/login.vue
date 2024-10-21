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
    <errorToast />
    <successToast />
    <div v-if="store.isLoadingPage">
      <loadingPage />
    </div>
  </div>
</template>

<script setup lang="ts">
import { string, object, ref as yupRef } from "yup";
import { useField, useForm } from "vee-validate";
import type { LoginBody } from "~/interface/RequestBody/LoginBody";
import type { IAuthenticationRespone } from "~/interface/Response/AuthenticationRespone";
import successToast from "~/components/toasts/successToast.vue";
import errorToast from "~/components/toasts/errorToast.vue";
import loadingPage from "~/components/loadingPage.vue";
import { useMyStore } from "~/store/myStore";
import { callApi, HttpMethods } from "~/ApiConfig/fetchData";

const router = useRouter();
const store = useMyStore();

definePageMeta({
  layout: "auth",
});

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

  try {
    // const data  = await postDataAPI("Authentication/Login", body) as IAuthenticationRespone;
    store.isLoadingPage = true;
    const data = (await callApi(
      "Authentication/Login",
      HttpMethods.POST,
      body
    )) as IAuthenticationRespone;
    store.isLoadingPage = false;
    store.ErrorToastInfo.isShow = false;
    store.SuccesToastInfo.isShow = true;
    store.SuccesToastInfo.message = "Login Success";
    if (data.role === "Admin") {
      router.push("/admin");
    } else {
      router.push("/");
    }
  } catch (error: any) {
    store.isLoadingPage = false;
    store.SuccesToastInfo.isShow = false;
    store.ErrorToastInfo.isShow = true;
    store.ErrorToastInfo.message = error.response._data.title;
  }
});
</script>
