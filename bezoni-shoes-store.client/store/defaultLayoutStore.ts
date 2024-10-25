import { defineStore } from "pinia";

export const useDefaultLayoutStore = defineStore("defaultLayoutStore", () => {
  // Initial state
  const listNagivation = ref([
    { name: "Home", path: "/", isChoose: true },
    { name: "Giày", path: "/products/giay", isChoose: false },
    { name: "Ví", path: "/products/vi", isChoose: false },
    { name: "Nịt", path: "/products/nit", isChoose: false },
    { name: "Bài viết", path: "/blogs", isChoose: false },
  ]);

  //Actions
  const chooseNav = (index: number) => {
    listNagivation.value.forEach((item) => (item.isChoose = false));
    listNagivation.value[index].isChoose = true;
  };
  const convertToUnsignedString = (input: string) => {
    const lowerCaseString = input.toLowerCase();

    const normalizedString = lowerCaseString
      .normalize("NFD")
      .replace(/[\u0300-\u036f]/g, "");
    const result = normalizedString.replace(/[\s,]+/g, "");

    return result;
  };

  return { listNagivation, chooseNav, convertToUnsignedString };
});
