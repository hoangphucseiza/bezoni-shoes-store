import { defineStore } from "pinia";

export const useAlertStore = defineStore("AlertStore", () => {
  // Initial state
  const SuccesToastInfo = ref({
    isShow: false,
    message: "",
  });
  const ErrorToastInfo = ref({
    isShow: false,
    message: "",
  });
  const isLoadingPage = ref(false);

  //Actions
  const handleOpenSucessToast = (message: string) => {
    ErrorToastInfo.value.isShow = false;
    ErrorToastInfo.value.message = "";
    SuccesToastInfo.value.isShow = true;
    SuccesToastInfo.value.message = message;
  };

  const handleCloseSucessToast = () => {
    SuccesToastInfo.value.isShow = false;
    SuccesToastInfo.value.message = "";
  };
  const handleOpenErrorToast = (message: string) => {
    SuccesToastInfo.value.isShow = false;
    SuccesToastInfo.value.message = "";
    ErrorToastInfo.value.isShow = true;
    ErrorToastInfo.value.message = message;
  };
  const handleCloseErrorToast = () => {
    ErrorToastInfo.value.isShow = false;
    ErrorToastInfo.value.message = "";
  };
  const handleLoadingPage = (isLoading: boolean) => {
    isLoadingPage.value = isLoading;
  };

  return {
    SuccesToastInfo,
    ErrorToastInfo,
    isLoadingPage,
    handleOpenSucessToast,
    handleOpenErrorToast,
    handleLoadingPage,
    handleCloseSucessToast,
    handleCloseErrorToast,
  };
});
