import { defineStore } from "pinia";
import { ref } from "vue";
import type { IAddProductBody } from "~/interface/RequestBody/IAddProductBody";
import type { IProduct } from "~/interface/RequestBody/IProduct";
import { useAlertStore } from "./alertStore";
import { useAuthStore } from "./authStore";
import { callApi, HttpMethods } from "~/ApiConfig/fetchData";
import type { IErrorSystem } from "~/interface/ErrorResponse/IErrorSystem";
import type { IProductUpdate } from "~/interface/RequestBody/IProductUpdate";
import type { IItemResponse } from "~/interface/Response/IItemResponse";
import type { ICreateItemBody } from "~/interface/RequestBody/ICreateItemBody";
import type { IUpdateItemBody } from "~/interface/RequestBody/IUpdateItemBody";

export const useItemStore = defineStore("itemStore", () => {
  // Initial state
  const items = ref<IItemResponse[]>([]);
  // Actions
  const alertStore = useAlertStore();
  const authStore = useAuthStore();
  //update item
  const updateItem = ref<IUpdateItemBody>();

  //Actions
  const handleSetUpdateItem = async (id: string) => {
    try {
      alertStore.handleLoadingPage(true);
      const accessToken = authStore.user.token;
      const item = (await callApi(
        `Admin/GetItemByID?id=${id}`,
        HttpMethods.GET,
        null,
        accessToken
      )) as IUpdateItemBody;
      updateItem.value = item;
      alertStore.handleLoadingPage(false);
    } catch (error: any) {
      if (error.response) {
        const errorData: IErrorSystem = error.response._data;
        alertStore.handleLoadingPage(false);
        alertStore.handleOpenErrorToast(errorData.title);
      }
    }
  };
  const handleCreateItem = async (item: ICreateItemBody) => {
    try {
      alertStore.handleLoadingPage(true);
      const accessToken = authStore.user.token;
      const newItem = (await callApi(
        "Admin/CreateItem",
        HttpMethods.POST,
        item,
        accessToken
      )) as IItemResponse;
      alertStore.handleLoadingPage(false);
      items.value.push(newItem);
      alertStore.handleOpenSucessToast("Thêm Sản Phẩm Thành Công");
    } catch (error: any) {
      if (error.response) {
        const errorData: IErrorSystem = error.response._data;
        alertStore.handleLoadingPage(false);
        alertStore.handleOpenErrorToast(errorData.title);
      }
    }
  };
  const handleGetAllItem = async () => {
    try {
      alertStore.handleLoadingPage(true);
      const accessToken = authStore.user.token;
      const item = (await callApi(
        `Admin/GetAllItemsPagination?pageSize=1&selectedCategory=0`,
        HttpMethods.GET,
        null,
        accessToken
      )) as IItemResponse[];
      items.value = item;
      alertStore.handleLoadingPage(false);
    } catch (error: any) {
      if (error.response) {
        const errorData: IErrorSystem = error.response._data;
        alertStore.handleLoadingPage(false);
        alertStore.handleOpenErrorToast(errorData.title);
      }
    }
  };

  const handleSearchItem = async (
    pageSize: number,
    selectedCategory: string,
    searchItem: string
  ) => {
    try {
      alertStore.handleLoadingPage(true);
      const accessToken = authStore.user.token;
      const item = (await callApi(
        `Admin/GetAllItemsPagination?pageSize=${pageSize}&selectedCategory=${selectedCategory}&searchItem=${searchItem}`,
        HttpMethods.GET,
        null,
        accessToken
      )) as IItemResponse[];
      items.value = item;
      alertStore.handleLoadingPage(false);
    } catch (error: any) {
      if (error.response) {
        const errorData: IErrorSystem = error.response._data;
        alertStore.handleLoadingPage(false);
        alertStore.handleOpenErrorToast(errorData.title);
      }
    }
  };
  const handleDeleteItem = async (id: string) => {
    try {
      alertStore.handleLoadingPage(true);
      const accessToken = authStore.user.token;
      await callApi(
        `Admin/DeleteItem?id=${id}`,
        HttpMethods.DELETE,
        null,
        accessToken
      );
      items.value = items.value.filter((item) => item.id !== id);
      alertStore.handleLoadingPage(false);
      alertStore.handleOpenSucessToast("Xóa Item Thành Công");
    } catch (error: any) {
      if (error.response) {
        const errorData: IErrorSystem = error.response._data;
        alertStore.handleLoadingPage(false);
        alertStore.handleOpenErrorToast(errorData.title);
      }
    }
  };

  const handleUpdateItem = async (item: IUpdateItemBody) => {
    try {
      alertStore.handleLoadingPage(true);
      const accessToken = authStore.user.token;
      const newItem = (await callApi(
        "Admin/UpdateItem",
        HttpMethods.PUT,
        item,
        accessToken
      )) as IItemResponse;
      items.value = items.value.map((i) => {
        if (i.id === newItem.id) {
          return newItem;
        }
        return i;
      });
      alertStore.handleLoadingPage(false);
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
    items,
    updateItem,
    handleSearchItem,
    handleCreateItem,
    handleGetAllItem,
    handleDeleteItem,
    handleUpdateItem,
    handleSetUpdateItem,
  };
});
