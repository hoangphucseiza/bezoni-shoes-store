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

  const handleCloseSucessToast = () => {
    SuccesToastInfo.value.isShow = false;
    SuccesToastInfo.value.message = "";
  };
  const handleCloseErrorToast = () => {
    console.log("close error toast");
    ErrorToastInfo.value.isShow = false;
    ErrorToastInfo.value.message = "";
  }

  return { SuccesToastInfo, ErrorToastInfo, isLoadingPage , handleCloseSucessToast, handleCloseErrorToast};
});
