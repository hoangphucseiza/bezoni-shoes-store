import type { IGiayCategory } from "~/interface/Response/IGiayCategory";
import type { IProductCard } from "~/interface/Response/IProductCard";
const imageurl =
  "https://scontent.fsgn19-1.fna.fbcdn.net/v/t39.30808-6/439893345_122144771846128199_1070271491736411668_n.jpg?_nc_cat=100&ccb=1-7&_nc_sid=127cfc&_nc_eui2=AeEgj3ggpbNrRQEEUPJA3Ep6U6BNEDcSpJFToE0QNxKkkckThtYNz75yhtycSIz5WT3uBlumgAEOCN-8U3xFgMQP&_nc_ohc=KSL2lY-d9ucQ7kNvgF-86Mh&_nc_zt=23&_nc_ht=scontent.fsgn19-1.fna&_nc_gid=Apqo1vs6zLu3GcBm-TK-ugF&oh=00_AYBu7vA1SPLr_fLv48zb5d_2FJ1YGRVx7Zf90snXrL9FwA&oe=672A04D2";
export const GiaySeedData: IProductCard[] = [
  { id: "1", name: "Giày Nam 1", price: 200000, voucher: 0, image: imageurl },
  { id: "2", name: "Giày Nam 2", price: 250000, voucher: 15, image: imageurl },
  { id: "3", name: "Giày Nam 3", price: 220000, voucher: 30, image: imageurl },
  { id: "4", name: "Giày Nam 4", price: 210000, voucher: 25, image: imageurl },
  { id: "5", name: "Giày Nam 5", price: 230000, voucher: 50, image: imageurl },
  { id: "6", name: "Giày Nam 6", price: 240000, voucher: 60, image: imageurl },
  { id: "7", name: "Giày Nam 7", price: 260000, voucher: 70, image: imageurl },
  { id: "8", name: "Giày Nam 8", price: 270000, voucher: 80, image: imageurl },
];
