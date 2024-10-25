import { defineStore } from "pinia";
import type { IAuthenticationRespone } from "~/interface/Response/IAuthenticationRespone";

export const useAuthStore = defineStore("authStore", () => {
  //Initial state
  const user = reactive<IAuthenticationRespone>({
    id: "",
    userName: "",
    fullName: "",
    email: "",
    phone: "",
    address: "",
    avatar: "",
    role: "",
    token: "",
    refreshToken: "",
  });
  //Actions
  const setUser = (data: IAuthenticationRespone) => {
    user.id = data.id;
    user.userName = data.userName;
    user.fullName = data.fullName;
    user.email = data.email;
    user.phone = data.phone;
    user.address = data.address;
    user.avatar = data.avatar;
    user.role = data.role;
    user.token = data.token;
    user.refreshToken = data.refreshToken;
  };
  return { user, setUser };
});
