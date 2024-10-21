import { defineStore } from "pinia";

export const useMyStore = defineStore("myStore", () => {
  const SuccesToastInfo = ref({
    isShow: false,
    message: "",
  }); 
    const ErrorToastInfo = ref({
    isShow: false,
    message: "",
    });
  const isLoadingPage = ref(false);


  return { SuccesToastInfo, ErrorToastInfo, isLoadingPage };
});
