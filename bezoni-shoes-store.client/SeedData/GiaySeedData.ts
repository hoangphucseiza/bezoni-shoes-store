import type { IGiayCategory } from "~/interface/Response/IGiayCategory";
import type { IProductCard } from "~/interface/Response/IProductCard";
const imageurl =
  "https://scontent.fsgn5-15.fna.fbcdn.net/v/t39.30808-6/440403525_421500740830834_675789255585767640_n.jpg?_nc_cat=111&ccb=1-7&_nc_sid=127cfc&_nc_eui2=AeFIIoXaPB0rjf1twqS3l_5ICEHwCdFFy_kIQfAJ0UXL-dg35GcM3VgBEH3WYvD7sdJ1wEigVJzxBqulWILdcP8n&_nc_ohc=44fKOCNkccUQ7kNvgHNypbO&_nc_zt=23&_nc_ht=scontent.fsgn5-15.fna&_nc_gid=AWAXS99uhOX9tyw3JUPkNzP&oh=00_AYAGIx5ExsURAw2soX58cr8UwJvrH4_n-HAng7FajRHBNg&oe=671D4873";
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
