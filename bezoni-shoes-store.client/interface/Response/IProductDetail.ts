import type { IItemDetail } from "./IItemDetail";

export interface IProductDetail {
  id: string;
  price: number;
  name: string;
  voucher: number;
  categoryName: string;
  description: string;
  listItem: IItemDetail[];
}
