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
      <div class="text-[35px] font-bold mb-[10px] cursor-pointer">Register</div>
      <div class="relative flex flex-col gap-[40px] mb-[20px]">
        <div
          class="flex gap-2 items-center justify-center border-b-2 border-gray-300 pb-[2px] relative"
        >
          <Icon name="material-symbols-light:mail" class="text-[23px]" />
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
          <Icon name="material-symbols:person-pin" class="text-[23px]" />
          <input
            type="text"
            class="w-[250px] h-[40px] px-2 focus:outline-none"
            placeholder="username"
            v-model="username"
          />
          <div class="text-red-500 absolute bottom-0 left-0 translate-y-[30px]">
            {{ usernameError }}
          </div>
        </div>
        <div
          class="flex gap-2 items-center justify-center border-b-2 border-gray-300 pb-[2px] relative"
        >
          <Icon name="material-symbols:person" class="text-[23px]" />
          <input
            type="text"
            class="w-[250px] h-[40px] px-2 focus:outline-none"
            placeholder="full name"
            v-model="fullName"
          />
          <div class="text-red-500 absolute bottom-0 left-0 translate-y-[30px]">
            {{ fullNameError }}
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

        <div
          class="flex gap-2 items-center justify-center border-b-2 border-gray-300 pb-[2px] relative"
        >
          <Icon name="mynaui:lock-password-solid" class="text-[23px]" />
          <input
            type="password"
            class="w-[250px] h-[40px] px-2 focus:outline-none"
            placeholder="confirm password"
            v-model="confirmPassword"
          />
          <div class="text-red-500 absolute bottom-0 left-0 translate-y-[30px]">
            {{ confirmPasswordError }}
          </div>
        </div>
      </div>
      <div
        @click="submitForm"
        class="py-5 w-[300px] h-[40px] bg-[#D74177] text-white rounded-lg flex items-center font-bold justify-center cursor-pointer hover:bg-[#db5382]"
      >
        REGISTER
      </div>
      <NuxtLink to="/login" class="cursor-pointer hover:underline"
        >you have an account?</NuxtLink
      >
    </div>
  </div>
</template>

<script setup lang="ts">
definePageMeta({
  layout: "auth",
});

import { string, object, ref as yupRef } from "yup";
import { useField, useForm } from "vee-validate";

const schema = object({
  email: string().email("Invalid email").required("Email is required"),
  username: string()
    .min(3, "Username must be at least 3 characters")
    .required("Username is required"),
  fullName: string().required("Full name is required"),
  password: string()
    .min(6, "Password must be at least 6 characters")
    .required("Password is required"),
  confirmPassword: string()
    .oneOf([yupRef("password")], "Passwords do not match")
    .required("Confirm password is required"),
});

// Set up form with schema validation
const { handleSubmit } = useForm({
  validationSchema: schema,
});

// Field validation setup
const { value: email, errorMessage: emailError } = useField("email");
const { value: username, errorMessage: usernameError } = useField("username");
const { value: fullName, errorMessage: fullNameError } = useField("fullName");
const { value: password, errorMessage: passwordError } = useField("password");
const { value: confirmPassword, errorMessage: confirmPasswordError } =
  useField("confirmPassword");
interface RegisterBody {
  email: string;
  username: string;
  fullName: string;
  password: string;
}
// Form submission
const submitForm = handleSubmit((values: any) => {
  const body: RegisterBody = {
    email: values.email,
    username: values.username,
    fullName: values.fullName,
    password: values.password,
  };
 
});
</script>

<style scoped></style>
