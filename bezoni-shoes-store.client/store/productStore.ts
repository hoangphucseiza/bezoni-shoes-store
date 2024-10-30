import { defineStore } from "pinia";
import { ref } from "vue";
import type { IAddProductBody } from "~/interface/RequestBody/IAddProductBody";
import type { IProduct } from "~/interface/RequestBody/IProduct";
import { useAlertStore } from "./alertStore";
import { useAuthStore } from "./authStore";
import { callApi, HttpMethods } from "~/ApiConfig/fetchData";
import type { IErrorSystem } from "~/interface/ErrorResponse/IErrorSystem";

export const useProductStore = defineStore("productStore", () => {
  // Initial state
  const products = ref<IProduct[]>([]);

  const alertStore = useAlertStore();
  const authStore = useAuthStore();

  // Actions
  const handleAddProduct = async (product: IAddProductBody) => {
    try {
      alertStore.handleLoadingPage(true);
      const accessToken = authStore.user.token;
      const res = (await callApi(
        "Admin/AddProduct",
        HttpMethods.POST,
        product,
        accessToken
      )) as any;
      alertStore.handleLoadingPage(false);
      //   products.value.push(newProduct);
      alertStore.handleOpenSucessToast("Thêm Sản Phẩm Thành Công");
    } catch (error: any) {
      if (error.response) {
        const errorData: IErrorSystem = error.response._data;
        alertStore.handleLoadingPage(false);
        alertStore.handleOpenErrorToast(errorData.title);
      }
    }
  };
  return {
    products,
    handleAddProduct,
  };
});
