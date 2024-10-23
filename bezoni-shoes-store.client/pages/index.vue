<template>
  <div class="flex flex-col gap-[50px]">
    <div>
      <swiper
        :navigation="true"
        :autoplay="{ delay: 3000, disableOnInteraction: false }"
        class="mySwiper"
      >
        <swiper-slide
          ><img
            src="/assets/images/home/5ca66baa-7326-4903-9033-68b40b200e93.jpg"
        /></swiper-slide>
        <swiper-slide
          ><img
            src="/assets/images/home/404669806_122104941896128199_7921417367521277777_n.jpg"
        /></swiper-slide>
        <swiper-slide
          ><img
            src="/assets/images/home/423223674_122126188964128199_5758388165388933959_n.jpg"
        /></swiper-slide>
      </swiper>
    </div>
    <div class="flex flex-col gap-[80px]">
      <div v-for="ProCate in listProductCategory" :key="ProCate.categoryName">
        <ProductCateHome :productCate="ProCate" />
      </div>
    </div>
    <div class="flex flex-col items-center gap-10 pb-10 mt-[80px]">
      <div class="flex gap-2 text-3xl font-[600]">
        <div>TIN TỨC</div>
        <div class="text-[#F36123]">NỔI BẬT</div>
      </div>
      <div>
        <div class="grid grid-cols-4 gap-5">
          <div v-for="blog in blogData" :key="blog.id">
            <BlogCardPage :blog="blog" />
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { Swiper, SwiperSlide } from "swiper/vue";
import { ProductShowHome } from "../SeedData/HomeSeedData";
const listProductCategory = reactive(ProductShowHome);
const blogData = reactive(BlogSeedData);

// Import Swiper styles
import "swiper/css";
import "swiper/css/navigation";
import { BlogSeedData } from "~/SeedData/BlogSeedData";
</script>
