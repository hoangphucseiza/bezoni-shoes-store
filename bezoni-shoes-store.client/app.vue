<template>
  <div>
    <NuxtLayout>
      <NuxtPage />
    </NuxtLayout>
  </div>
</template>

<script setup lang="ts">
import { callApi, HttpMethods } from "./ApiConfig/fetchData";
import type { IErrorSystem } from "./interface/ErrorResponse/IErrorSystem";
import type { IAuthenticationRespone } from "./interface/Response/IAuthenticationRespone";
import type { IRefreshToken } from "./interface/Response/IRefreshToken";
import { useAuthStore } from "./store/authStore";
const authStore = useAuthStore();
// Validate Token
const validateToken = (token: string | null) : boolean => {
  if (!token) return false;
  // Kiểm tra định dạng JWT
  const tokenParts = token.split(".");
  if (tokenParts.length !== 3) {
    return false;
  }

  // Giải mã payload
  const payload = JSON.parse(atob(tokenParts[1]));

  // Kiểm tra thời gian hết hạn
  const currentTime = Math.floor(Date.now() / 1000);
  if (payload.exp && payload.exp < currentTime) {
    return false;
  }

  return true;
};

const checkToken = async () => {
  const accessToken = localStorage.getItem("accessToken");
  const refreshToken = localStorage.getItem("refreshToken");

  if (validateToken(accessToken) && validateToken(refreshToken)) {
    try {
      const apiToken = (await callApi(
        "Authentication/RefreshToken",
        HttpMethods.POST,
        { refreshToken: refreshToken }
      )) as IRefreshToken;
      if (apiToken) {
        localStorage.setItem("accessToken", apiToken.token);
        localStorage.setItem("refreshToken", apiToken.refreshToken); 
        console.log("Token success");
        try {
          const user = (await callApi(
            `Authentication/GetUserFromToken?token=${apiToken.token}`,
            HttpMethods.GET
          )) as IAuthenticationRespone;
          user.token = apiToken.token;
          user.refreshToken = apiToken.refreshToken;
          authStore.setUser(user);
        } catch (error: any) {
          const err: IErrorSystem = error.response._data;
          console.log(err.title);
        }
      }
    } catch (error: any) {
      const err: IErrorSystem = error.response._data;
      localStorage.removeItem("accessToken");
      localStorage.removeItem("refreshToken");
      console.log(err.title);
    }
  } else {
    localStorage.removeItem("accessToken");
    localStorage.removeItem("refreshToken");
  }
};
onMounted(() => {
  checkToken();
});
</script>
