import { defineStore } from "pinia";

export const useCommonStore = defineStore("commonStore", () => {
  // Function add price  to 000.000đ
  const formatPrice = (price: number) => {
    return price.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".");
  };

  // Hàm làm tròn lên đến số thập phân thứ 1
  const roundNumber = (num: number) => {
    return Math.round(num * Math.pow(10, 1)) / Math.pow(10, 1);
  };
  const convertToUnsignedString = (input: string) => {
    const lowerCaseString = input.toLowerCase();

    const normalizedString = lowerCaseString
      .normalize("NFD")
      .replace(/[\u0300-\u036f]/g, "");
    const result = normalizedString.replace(/[\s,]+/g, "");

    return result;
  };
  return {formatPrice, roundNumber, convertToUnsignedString};
});
