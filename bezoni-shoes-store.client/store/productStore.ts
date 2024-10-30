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
  const productUpdate = ref<IProduct | null>(null);

  const alertStore = useAlertStore();
  const authStore = useAuthStore();

  // Actions

  const handleSetProductUpdate = (product: IProduct) => {
    productUpdate.value = product;
  };
  const handleAddProduct = async (product: IAddProductBody) => {
    try {
      alertStore.handleLoadingPage(true);
      const accessToken = authStore.user.token;
      const newProduct = (await callApi(
        "Admin/AddProduct",
        HttpMethods.POST,
        product,
        accessToken
      )) as IProduct;
      alertStore.handleLoadingPage(false);
      console.log(newProduct);
      products.value.push(newProduct);
      alertStore.handleOpenSucessToast("Thêm Sản Phẩm Thành Công");
    } catch (error: any) {
      if (error.response) {
        const errorData: IErrorSystem = error.response._data;
        alertStore.handleLoadingPage(false);
        alertStore.handleOpenErrorToast(errorData.title);
      }
    }
  };

  const handleGetProducts = async () => {
    try {
      const fetchedProducts = (await callApi(
        "Admin/GetAllProduct",
        HttpMethods.GET
      )) as IProduct[];
      products.value = fetchedProducts; // Update state
    } catch (error: any) {
      console.log(error);
    }
  };
  const handleDeleteProduct = async (id: string) => {
    try {
      alertStore.handleLoadingPage(true);
      const accessToken = authStore.user.token;
      await callApi(
        `Admin/DeleteProduct?id=${id}`,
        HttpMethods.DELETE,
        null,
        accessToken
      );
      alertStore.handleLoadingPage(false);
      products.value = products.value.filter((product) => product.id !== id);
      alertStore.handleOpenSucessToast("Xóa Sản Phẩm Thành Công");
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
    productUpdate,
    handleSetProductUpdate,
    handleAddProduct,
    handleGetProducts,
    handleDeleteProduct,
  };
});
