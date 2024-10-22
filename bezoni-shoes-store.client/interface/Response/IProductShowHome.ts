export interface IProductHomeInfo {
    id: string;
    name: string;
    price: number;
    vouncher: number;
    image: string;
}

export interface IProductShowHome {
  categoryName: string;
  productList: IProductHomeInfo[];
}
