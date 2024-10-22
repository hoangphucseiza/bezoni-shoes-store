<template>
  <div>
    <NuxtLayout>
      <NuxtPage />
    </NuxtLayout>
  </div>
</template>

<script setup lang="ts">
import { callApi, HttpMethods } from "./ApiConfig/fetchData";
import type { ErrorSystem } from "./interface/Response/ErrorSystem";
import type { RefreshToken } from "./interface/Response/RefreshToken";
import { ref, onMounted } from "vue";
const router = useRouter();

// Interface for a successful token validation
interface TokenSuccess {
  message: string;
}

// Helper function to check token validity
const checkToken = async (token: string | null) => {
  if (!token) return null;
  return (await callApi(
    `Authentication/CheckToken?Token=${token}`,
    HttpMethods.GET
  )) as TokenSuccess | ErrorSystem;
};

// Function to refresh the access token using the refresh token
const refreshAccessToken = async (refreshToken: string | null) => {
  if (!refreshToken) return null;
  const newToken = (await callApi(
    "Authentication/Authentication/RefreshTokenFromAccessToken",
    HttpMethods.POST,
    refreshToken
  )) as ErrorSystem | RefreshToken;
  return newToken as RefreshToken | ErrorSystem;
};

// Function to handle token logic
const handleTokenValidation = async () => {
  // Lấy access token từ localStorage
  const accessToken = localStorage.getItem("accessToken");
  const refreshToken = localStorage.getItem("refreshToken");
  // Nếu không có access token thì chuyển hướng về trang login
  if (!accessToken || !refreshToken) {
    router.push("/");
    // Xóa cả access token và refresh token
  }
  // Gọi API Kiểm tra access token
  const checkAccesToken = await checkToken(accessToken);
  // Nếu checkAccesToken khác loại TokenSuccess và không có message là "Valid Token" thì Gọi tới check refresh token
  if (!((checkAccesToken as TokenSuccess).message == "Valid Token")) {
    const checkRefreshToken = await checkToken(refreshToken);
    if (!((checkRefreshToken as TokenSuccess).message == "Valid Token")) {
      router.push("/");
      // Xóa cả access token và refresh token
    } else {
      const newToken = await refreshAccessToken(refreshToken);
      if (newToken as RefreshToken) {
        const newAccessTokenLocalStoge = (newToken as RefreshToken).token;
        const newRefreshTokenLocalStoge = (newToken as RefreshToken)
          .refreshToken;
        localStorage.removeItem("accessToken");
        localStorage.removeItem("refreshToken");
        localStorage.setItem("accessToken", newAccessTokenLocalStoge);
        localStorage.setItem("refreshToken", newRefreshTokenLocalStoge);
      }
    }
  }
};

// Execute token validation when the component is mounted
onMounted(() => {
  handleTokenValidation();
});
</script>
