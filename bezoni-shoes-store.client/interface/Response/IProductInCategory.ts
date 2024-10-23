export interface IProductCategoryInfo {
    id: string;
    name: string;
    price: number;
    vouncher: number;
    image: string;
}

export interface IProductInCategory {
    productList: IProductCategoryInfo[];
}