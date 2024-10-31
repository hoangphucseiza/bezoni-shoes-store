import { defineStore } from "pinia";
import { ref } from "vue";
import type { IAddProductBody } from "~/interface/RequestBody/IAddProductBody";
import type { IProduct } from "~/interface/RequestBody/IProduct";
import { useAlertStore } from "./alertStore";
import { useAuthStore } from "./authStore";
import { callApi, HttpMethods } from "~/ApiConfig/fetchData";
import type { IErrorSystem } from "~/interface/ErrorResponse/IErrorSystem";
import type { IProductUpdate } from "~/interface/RequestBody/IProductUpdate";

export const useProductStore = defineStore("productStore", () => {
  // Initial state
  const products = ref<IProduct[]>([]);
  const productUpdate = ref<IProductUpdate>();
  const alertStore = useAlertStore();
  const authStore = useAuthStore();

  // Actions

  const handleSetProductUpdate = async (id: string) => {
    try {
      alertStore.handleLoadingPage(true);
      const accessToken = authStore.user.token;
      const product = (await callApi(
        `Admin/GetProductById?id=${id}`,
        HttpMethods.GET,
        null,
        accessToken
      )) as IProductUpdate;
      productUpdate.value = product;
      alertStore.handleLoadingPage(false);
    } catch (error: any) {
      if (error.response) {
        const errorData: IErrorSystem = error.response._data;
        alertStore.handleLoadingPage(false);
        alertStore.handleOpenErrorToast(errorData.title);
      }
    }
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
  const handleUpdateProduct = async (product: IProductUpdate) => {
    try {
      alertStore.handleLoadingPage(true);
      const accessToken = authStore.user.token;
      const updatedProduct = (await callApi(
        "Admin/UpdateProduct",
        HttpMethods.PUT,
        product,
        accessToken
      )) as IProduct;
      alertStore.handleLoadingPage(false);
      console.log(updatedProduct);
      const index = products.value.findIndex((p) => p.id === updatedProduct.id);
      products.value[index] = updatedProduct;
      alertStore.handleOpenSucessToast("Cập Nhật Sản Phẩm Thành Công");
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
    handleUpdateProduct,
    handleAddProduct,
    handleGetProducts,
    handleDeleteProduct,
  };
});
