<template>
  <div class="py-[20px]">
    <div class="flex flex-row gap-2 text-[20px] mb-[20px] items-center">
      <Icon name="heroicons-solid:home" class="text-[25px] text-[#F36123]" />
      <NuxtLink
        to="/"
        class="font-bold cursor-pointer text-[#F36123] hover:underline"
        >Home /</NuxtLink
      >
      <div class="font-semibold">Thanh toán</div>
    </div>
    <div class="grid grid-cols-5 gap-10">
      <div class="col-span-3 flex flex-col gap-10 p-5 border rounded-md">
        <div class="flex flex-col gap-3">
          <div class="text-[20px] font-bold">1. Thông tin liên hệ</div>
          <div class="px-3 flex flex-col gap-3 text-[17px]">
            <span
              >Bezoni dùng email này để gửi thông tin và cập nhật về đơn đặt
              hàng của bạn.</span
            >
            <input
              type="text"
              class="h-[40px] border border-gray-300 rounded-md p-4"
              placeholder="Địa chỉ email"
            />
            <div class="flex gap-2">
              <div>Bạn chưa có tài khoản?</div>
              <NuxtLink
                to="/register"
                class="text-[#F36123] font-bold hover:underline"
                >Đăng ký ngay!</NuxtLink
              >
            </div>
          </div>
        </div>
        <div class="flex flex-col gap-3">
          <div class="text-[20px] font-bold">2. Địa chỉ giao hàng</div>
          <div class="px-3 flex flex-col gap-3 text-[17px]">
            <span>Nhập địa chỉ nơi bạn muốn đơn hàng của mình được giao.</span>
            <input
              type="text"
              class="h-[40px] border border-gray-300 rounded-md p-4"
              placeholder="Họ và tên"
            />
            <input
              type="text"
              class="h-[40px] border border-gray-300 rounded-md p-4"
              placeholder="Địa chỉ"
            />
            <input
              type="text"
              class="h-[40px] border border-gray-300 rounded-md p-4"
              placeholder="Số điên thoại"
            />
          </div>
        </div>
        <div class="flex flex-col gap-3">
          <div class="text-[20px] font-bold">3. Tùy chọn thanh toán</div>

          <div class="flex justify-between px-3 gap-3 text-[17px]">
            <div class="flex gap-2">
              <input type="radio" name="payment" />
              <span>Thanh toán khi nhận hàng</span>
            </div>
            <div class="flex gap-2">
              <input type="radio" name="payment" />
              <span>Thanh toán qua thẻ ngân hàng</span>
            </div>
            <div class="flex gap-2">
              <input type="radio" name="payment" />
              <span>Thanh toán qua ví điện tử</span>
            </div>
          </div>
        </div>
        <div>
          <div
            class="bg-[#F36123] text-white text-[15px] py-2 px-2 rounded-lg flex items-center font-bold justify-center cursor-pointer hover:shadow-xl"
            @click="handlePayment"
          >
            Đặt hàng
          </div>
        </div>
      </div>
      <div class="col-span-2 p-5 border rounded-xl flex flex-col gap-5">
        <div class="text-[20px] font-bold flex justify-center">
          <div>Đơn hàng của bạn</div>
        </div>
        <div class="border-b"></div>
        <div class="flex flex-row justify-between items-center font-normal">
          <div class="text-[17px] flex items-center gap-4">
            <span>1</span>
            <span class="text-[15px]">x</span>
            <div class="flex flex-col px-5">
              <img
                src="https://scontent.fsgn5-15.fna.fbcdn.net/v/t39.30808-6/440403525_421500740830834_675789255585767640_n.jpg?_nc_cat=111&ccb=1-7&_nc_sid=127cfc&_nc_eui2=AeFIIoXaPB0rjf1twqS3l_5ICEHwCdFFy_kIQfAJ0UXL-dg35GcM3VgBEH3WYvD7sdJ1wEigVJzxBqulWILdcP8n&_nc_ohc=44fKOCNkccUQ7kNvgHNypbO&_nc_zt=23&_nc_ht=scontent.fsgn5-15.fna&_nc_gid=AWAXS99uhOX9tyw3JUPkNzP&oh=00_AYAGIx5ExsURAw2soX58cr8UwJvrH4_n-HAng7FajRHBNg&oe=671D4873"
                alt=""
                class="w-[100px] h-[100px] object-cover"
              />
              <div>
                Bezoni Be Efficient Belt – Thắt Lưng Da Vachetta May 3 Lớp Đầu
                Kim
              </div>
            </div>
          </div>
          <div class="text-[17px]">100.000đ</div>
        </div>
        <!-- Line border -->
        <div class="border-b"></div>
        <div class="text-[20px] font-bold">Mã giảm giá</div>
        <div class="border-b"></div>

        <div class="flex flex-col gap-2">
          <div class="text-[20px] font-bold">Giao hàng</div>
          <div class="flex justify-between text-[17px]">
            <div>Đồng giá toàn quốc</div>
            <div>30.000đ</div>
          </div>
        </div>
        <div class="border-b"></div>

        <div class="text-[20px] font-bold flex justify-between">
          <div>Tổng cộng</div>
          <div>130.000đ</div>
        </div>
      </div>
    </div>
    <LoadingPage />
  </div>
</template>

<script setup lang="ts">
import { useMyStore } from "~/store/myStore";

const store = useMyStore();
const handlePayment = () => {
  // Set time out for 2s loading
  store.isLoadingPage = true;
  setTimeout(() => {
    store.isLoadingPage = false;
  }, 2000);
};
</script>

<style scoped></style>
