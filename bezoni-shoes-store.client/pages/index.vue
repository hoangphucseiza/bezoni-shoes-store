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
    <div>Bài viết nổi bật</div>
  </div>
</template>

<script setup lang="ts">
import { Swiper, SwiperSlide } from "swiper/vue";
import { Navigation, Pagination, Scrollbar, A11y } from "swiper/modules";
import { ProductShowHome } from "../SeedData/HomeSeedData";
const listProductCategory = reactive(ProductShowHome);

// Import Swiper styles
import "swiper/css";
import "swiper/css/navigation";
</script>

<style scoped>
.swiper {
  width: 100%;
  height: 100%;
}

.swiper-slide {
  text-align: center;
  font-size: 18px;
  background: #fff;

  /* Center slide text vertically */
  display: flex;
  justify-content: center;
  align-items: center;
}

.swiper-slide img {
  display: block;
  width: 100%;
  height: 100%;
  object-fit: cover;
}
</style>
