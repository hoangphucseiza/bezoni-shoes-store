<template>
  <div class="flex flex-col pb-5 gap-5">
    <div class="flex flex-row gap-2 text-[20px] mb-[20px] items-center">
      <Icon name="heroicons-solid:home" class="text-[25px] text-[#F36123]" />
      <NuxtLink
        to="/"
        class="font-bold cursor-pointer text-[#F36123] hover:underline"
        >Home /</NuxtLink
      >
      <NuxtLink
        class="font-semibold hover:underline"
        :to="`/products/${convertToPlainString(product.categoryName)}`"
        >{{ product.categoryName }} /</NuxtLink
      >
      <div class="font-semibold">{{ product.name }}</div>
    </div>
    <div class="flex px-10 gap-10">
      <div class=" ">
        <swiper :effect="'cards'" :grabCursor="true" class="mySwiper">
          <swiper-slide
            v-for="(image, index) in images"
            :key="index"
            class="flex justify-center items-center"
          >
            <img :src="image" alt="product-image" class="object-contain" />
          </swiper-slide>
        </swiper>
      </div>
      <div class="flex-1 flex flex-col gap-6">
        <div class="flex flex-col">
          <div class="text-[30px] font-bold">{{ product.name }}</div>

          <div class="line-through text-[18px] font-medium opacity-50">
            {{ formatPrice(product.price) }}đ
          </div>
        </div>
        <div class="text-[#F36123] text-[24px] font-bold">
          {{
            formatPrice(
              roundNumber(product.price * (1 - product.voucher / 100))
            )
          }}đ
        </div>
        <div class="flex flex-col gap-4 mt-3 text-[16px]">
          <div v-if="product.listItem[0].color" class="flex gap-4">
            <div class="text-[20px] font-bold">Màu sắc:</div>
            <div class="flex gap-2">
              <div class="flex gap-2">
                <div v-for="(item, index) in product.listItem" :key="index">
                  <div class="p-1 border rounded-sm cursor-pointer">
                    {{ item.color }}
                  </div>
                </div>
              </div>
            </div>
          </div>
          <div v-if="product.listItem[0].size" class="flex gap-4">
            <div class="text-[20px] font-bold">Size:</div>
            <div class="flex gap-2">
              <div class="flex gap-2">
                <div v-for="(item, index) in product.listItem" :key="index">
                  <div class="p-1 border rounded-sm cursor-pointer">
                    {{ item.size }}
                  </div>
                </div>
              </div>
            </div>
          </div>
          <div v-if="product.listItem[0].type" class="flex gap-4">
            <div class="text-[20px] font-bold">Loại:</div>
            <div class="flex gap-2">
              <div class="flex gap-2">
                <div v-for="(item, index) in product.listItem" :key="index">
                  <div class="p-1 border rounded-sm cursor-pointer">
                    {{ item.type }}
                  </div>
                </div>
              </div>
            </div>
          </div>
          <div class="flex gap-5 items-center py-2">
            <div class="font-bold text-[20px]">Số lượng:</div>
            <input
              type="number"
              id="quantity"
              class="w-[100px] h-[40px] border border-gray-300 rounded-md p-4"
              value="1"
              min="1"
              max="100"
              step="1"
            />
          </div>
        </div>
        <div
          class="w-1/3 gap-2 bg-[#F36123] flex justify-center items-center py-2 text-white text-[20px] font-bold rounded-xl hover:bg-[#f36123df] hover:shadow-xl"
        >
          <Icon
            name="material-symbols:add-shopping-cart-outline-rounded"
            class="text-white text-[30px]"
          />
          <button class="">Thêm vào giỏ hàng</button>
        </div>
      </div>
    </div>
    <div class="text-[20px] flex flex-col items-center">
      <div class="text-[30px] font-bold">Mô tả sản phẩm</div>
      <div class="" id="productDescription"></div>
      <img
        src="https://bezoni.vn/wp-content/uploads/2024/ProductDescription/Service.webp"
        alt="product-image"
        class="object-contain"
      />
    </div>
  </div>
</template>

<script setup lang="ts">
import { string } from "yup";
import { ProductDetailSeedData } from "~/SeedData/ProductDetailSeedData";
import { Swiper, SwiperSlide } from "swiper/vue";

// Import Swiper styles
import "swiper/css";

import "swiper/css/effect-cards";

// import required modules
import { EffectCards } from "swiper/modules";
const route = useRoute();

const product = reactive(ProductDetailSeedData);

function convertToPlainString(input: string): string {
  const lowerCaseString = input.toLowerCase();

  const normalizedString = lowerCaseString
    .normalize("NFD")
    .replace(/[\u0300-\u036f]/g, "");
  const result = normalizedString.replace(/[\s,]+/g, "");

  return result;
}
// Function to update the inner HTML of the BlogContent div
const updateProductDescription = () => {
  const blogContentElement = document.getElementById("productDescription");
  if (blogContentElement) {
    blogContentElement.innerHTML = product.description;
  }
};

// Set initial content when the component is mounted
onMounted(() => {
  updateProductDescription();
});
// watch
watch(
  () => product,
  () => {
    updateProductDescription();
  }
);

// Function to GetAll Imgaes from Product in array
const getAllImages = () => {
  let images: string[] = [];
  product.listItem.forEach((item) => {
    item.images.forEach((image) => {
      images.push(image);
    });
  });
  return images;
};
// Function add price  to 000.000đ
const formatPrice = (price: number) => {
  return price.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".");
};

// Hàm làm tròn lên đến số thập phân thứ 1
const roundNumber = (num: number) => {
  return Math.round(num * Math.pow(10, 1)) / Math.pow(10, 1);
};
const images = getAllImages();
</script>

<style scoped>
.swiper {
  width: 400px;
  height: 500px;
}

.swiper-slide {
  display: flex;
  align-items: center;
  justify-content: center;
  border-radius: 18px;
  font-size: 22px;
  font-weight: bold;
  color: #fff;
}

.swiper-slide:nth-child(1n) {
  background-color: rgb(206, 17, 17);
}

.swiper-slide:nth-child(2n) {
  background-color: rgb(0, 140, 255);
}

.swiper-slide:nth-child(3n) {
  background-color: rgb(10, 184, 111);
}

.swiper-slide:nth-child(4n) {
  background-color: rgb(211, 122, 7);
}

.swiper-slide:nth-child(5n) {
  background-color: rgb(118, 163, 12);
}

.swiper-slide:nth-child(6n) {
  background-color: rgb(180, 10, 47);
}

.swiper-slide:nth-child(7n) {
  background-color: rgb(35, 99, 19);
}

.swiper-slide:nth-child(8n) {
  background-color: rgb(0, 68, 255);
}

.swiper-slide:nth-child(9n) {
  background-color: rgb(218, 12, 218);
}

.swiper-slide:nth-child(10n) {
  background-color: rgb(54, 94, 77);
}
</style>
