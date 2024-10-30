import { defineStore } from "pinia";
import { callApi, HttpMethods } from "~/ApiConfig/fetchData";
import type { ICategoryResponse } from "~/interface/Response/ICategoryResponse";
import { ref } from "vue";
import type { IAddCategoryBody } from "~/interface/RequestBody/IAddCategoryBody";
import { useAlertStore } from "./alertStore";
import { useAuthStore } from "./authStore";
import type { IErrorSystem } from "~/interface/ErrorResponse/IErrorSystem";
import type { IUpdateCategoryBody } from "~/interface/RequestBody/IUpdateCategoryBody";

export const useCategoryStore = defineStore("categoryStore", () => {
  // Initial state
  const categories = ref<ICategoryResponse[]>([]);

  // Actions
  const getAllCategory = async () => {
    const accessToken = localStorage.getItem("accessToken") as
      | string
      | undefined;
    try {
      const fetchedCategories = (await callApi(
        "Admin/GetAllCategory",
        HttpMethods.GET,
        null,
        accessToken
      )) as ICategoryResponse[];
      categories.value = fetchedCategories; // Update state
    } catch (error: any) {
      console.log(error);
    }
  };
  const alertStore = useAlertStore();
  const authStore = useAuthStore();
  //   Add category
  const handleAddCategory = async (values: any) => {
    const body: IAddCategoryBody = {
      name: values.categoryName,
    };
    try {
      alertStore.handleLoadingPage(true);
      const accessToken = authStore.user.token;
      const res: any = await callApi(
        "Admin/AddCategory",
        HttpMethods.POST,
        body,
        accessToken
      );
      alertStore.handleLoadingPage(false);
      const message: string = res.message;
      alertStore.handleOpenSucessToast(message);
      //   Get newcategory by name
      const newCategory = await getAPICategoryByName(values.categoryName);
      categories.value.push(newCategory);
    } catch (error: any) {
      if (error.response) {
        const errorData: IErrorSystem = error.response._data;
        alertStore.handleLoadingPage(false);
        alertStore.handleOpenErrorToast(errorData.title);
      }
    }
  };
  //   Get category by name
  const getAPICategoryByName = async (name: string) => {
    let category: ICategoryResponse = {
      id: "",
      name: "",
    };
    try {
      const accessToken = authStore.user.token;

      category = (await callApi(
        `Admin/GetCategoryByName?name=${name}`,
        HttpMethods.GET,
        null,
        accessToken
      )) as ICategoryResponse;
    } catch (error: any) {
      console.log(error);
    }
    return category;
  };
  // Delete category
  const handleDeleteCategory = async (id: string, name: string) => {
    const isConfirmed = window.confirm(
      `Bạn có chắc chắn muốn xóa danh mục ${name} không?`
    );
    if (!isConfirmed) return; // Nếu người dùng nhấn Cancel thì dừng tại đây
    try {
      alertStore.handleLoadingPage(true);
      const accessToken = authStore.getAccesToken();
      await callApi(
        `Admin/DeleteCategory?id=${id}`,
        HttpMethods.DELETE,
        null,
        accessToken
      );
      alertStore.handleLoadingPage(false);
      alertStore.handleOpenSucessToast("Danh mục đã được xóa!");
      categories.value = categories.value.filter(
        (category) => category.id !== id
      );
    } catch (error: any) {
      if (error.response) {
        const errorData: IErrorSystem = error.response._data;
        alertStore.handleLoadingPage(false);
        alertStore.handleOpenErrorToast(errorData.title);
      }
    }
  };

  // Update category
  const handleUpdateCategory = async (id: string, name: string) => {
    const isConfirmed = window.confirm(
      `Bạn có chắc chắn muốn cập nhật danh mục ${name} không?`
    );
    if (!isConfirmed) return; // Nếu người dùng nhấn Cancel thì dừng tại đây
    try {
      alertStore.handleLoadingPage(true);
      const accessToken = authStore.getAccesToken();
      const body: IUpdateCategoryBody = {
        id: id,
        name: name,
      };
      await callApi(
        `Admin/UpdateCategory?id=${id}`,
        HttpMethods.PUT,
        body,
        accessToken
      );
      alertStore.handleLoadingPage(false);
      alertStore.handleOpenSucessToast("Danh mục đã được cập nhật!");
      categories.value = categories.value.map((category) => {
        if (category.id === id) {
          return {
            ...category,
            name: name,
          };
        }
        return category;
      });
    } catch (error: any) {
      if (error.response) {
        const errorData: IErrorSystem = error.response._data;
        alertStore.handleLoadingPage(false);
        alertStore.handleOpenErrorToast(errorData.title);
      }
    }
  };
  return {
    categories,
    getAllCategory,
    handleAddCategory,
    handleDeleteCategory,
    handleUpdateCategory,
  };
});
