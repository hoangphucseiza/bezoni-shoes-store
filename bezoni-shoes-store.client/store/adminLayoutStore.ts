import { defineStore } from "pinia";

export const useAdminLayoutStore = defineStore("adminLayoutStore", () => {
  // Initial state

  const listNagivation = ref([
    {
      name: "Dashboard",
      path: "/admin",
      isChoose: true,
    },
    {
      name: "Manage Products",
      path: "/admin/products",
      isChoose: false,
    },
    {
      name: "Manage Users",
      path: "/admin/users",
      isChoose: false,
    },
    {
      name: "Manage Orders",
      path: "/admin/orders",
      isChoose: false,
    },
    {
      name: "Manage Vouchers",
      path: "/admin/vouchers",
      isChoose: false,
    },
    {
      name: "Manage Blogs",
      path: "/admin/blogs",
      isChoose: false,
    },
    {
      name: "Manage Settings",
      path: "/admin/settings",
      isChoose: false,
    },
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
  const checkPath = (path: string) => {
    listNagivation.value.forEach((nav) => {
      if (nav.path === path) {
        nav.isChoose = true;
      } else {
        nav.isChoose = false;
      }
    });
  };

  return { listNagivation, chooseNav, convertToUnsignedString, checkPath };
});
