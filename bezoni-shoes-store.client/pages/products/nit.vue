<template>
    <div class="py-[20px]">
      <div class="flex flex-row gap-2 text-[20px] mb-[20px] items-center">
        <Icon name="heroicons-solid:home" class="text-[25px] text-[#F36123]" />
        <NuxtLink
          to="/"
          class="font-bold cursor-pointer text-[#F36123] hover:underline"
          >Home /</NuxtLink
        >
        <div class="font-semibold">Nịt</div>
      </div>
      <div class="flex grid grid-cols-10 gap-5">
        <div
          class="flex flex-col gap-5 max-h-[400px] col-span-2 border rounded-xl"
        >
          <div
            class="flex justify-center items-center rounded-t-xl p-4 font-bold text-white cursor-pointer text-[20px] bg-[#F36123]"
          >
            Bộ lọc
          </div>
          <div class="flex flex-col gap-4">
            <div class="flex flex-col items-center gap-2">
              <div class="text-[17px] font-[500]">Khoảng giá</div>
              <div>
                <input
                  type="text"
                  placeholder="Từ"
                  class="w-[100px] h-[20px] border border-gray-300 rounded-md p-4"
                />
                <!-- Line -->
                <div class="inline-block w-[20px] border text-center"></div>
                <input
                  type="text"
                  placeholder="Đến"
                  class="w-[100px] h-[20px] border border-gray-300 rounded-md p-4"
                />
              </div>
            </div>
            <div class="flex flex-col items-center gap-2">
              <div class="text-[17px] font-[500]">Voucher</div>
              <div class="flex gap-2 relative">
                <select
                  class="w-[200px] h-[20px] border border-gray-300 rounded-md p-4"
                  v-model.number="selectedVoucher"
                >
                  <option :value="0">Mặc định</option>
                  <option :value="1">Tăng dần</option>
                  <option :value="2">Giảm dần</option>
                </select>
                <!-- Hiển thị giá trị được chọn -->
                <span
                  class="absolute left-1/2 top-1/2 transform cursor-pointer -translate-x-1/2 -translate-y-1/2"
                  >{{ selectedVoucherText }}</span
                >
              </div>
            </div>
            <!-- Button tìm kiếm -->
  
            <div
              class="h-[40px] mx-[40px] bg-[#F36123] text-white rounded-lg flex items-center font-bold justify-center cursor-pointer hover:shadow-xl"
              @click="handleSearchProducts"
              >
              Tìm kiếm
            </div>
            <!-- Line -->
            <div class="border-b"></div>
            <div class="flex flex-col items-center gap-2">
              <div class="text-[17px] font-[500]">Sắp xếp</div>
              <div class="flex gap-2 relative">
                <select
                  class="w-[200px] h-[20px] border border-gray-300 rounded-md p-4"
                  v-model.number="selectedSort"
                >
                  <option :value="0">Mặc định</option>
                  <option :value="1">Tăng dần</option>
                  <option :value="2">Giảm dần</option>
                </select>
                <!-- Hiển thị giá trị được chọn -->
                <span
                  class="absolute left-1/2 top-1/2 transform cursor-pointer -translate-x-1/2 -translate-y-1/2"
                  >{{ selectedSortText }}</span
                >
              </div>
            </div>
          </div>
        </div>
        <div class="col-span-8 flex flex-col gap-10">
          <div class="min-h-[500px] grid grid-cols-4 gap-20">
            <div v-for="p in giayProducts" :key="p.id">
              <ProductCard :product="p" />
            </div>
          </div>
          <!-- Phân trang -->
          <div class="flex justify-center gap-2">
            <div
              class="flex justify-center items-center w-[40px] h-[40px] rounded-full border border-gray-300 cursor-pointer"
            >
              <Icon name="heroicons-solid:chevron-left" class="text-[20px]" />
            </div>
            <div
              class="flex justify-center items-center w-[40px] h-[40px] rounded-full border border-gray-300 cursor-pointer bg-[#F36123] text-white"
            >
              1
            </div>
            <div
              class="flex justify-center items-center w-[40px] h-[40px] rounded-full border border-gray-300 cursor-pointer"
            >
              2
            </div>
            <div
              class="flex justify-center items-center w-[40px] h-[40px] rounded-full border border-gray-300 cursor-pointer"
            >
              3
            </div>
            <div
              class="flex justify-center items-center w-[40px] h-[40px] rounded-full border border-gray-300 cursor-pointer"
            >
              4
            </div>
            <div
              class="flex justify-center items-center w-[40px] h-[40px] rounded-full border border-gray-300 cursor-pointer"
            >
              <Icon name="heroicons-solid:chevron-right" class="text-[20px]" />
            </div>
          </div>
        </div>
      </div>
    </div>
  </template>
  
  <script setup lang="ts">
  import { GiaySeedData } from "~/SeedData/GiaySeedData";
  
  const route = useRoute();
  const selectedVoucher = ref(0); // Default value is 0 (Mặc định)
  const selectedSort = ref(0);
  
  // Computed property to return the text for the selected option
  const selectedVoucherText = computed(() => {
    switch (selectedVoucher.value) {
      case 1:
        return "Tăng dần";
      case 2:
        return "Giảm dần";
      default:
        return "Mặc định";
    }
  });
  const selectedSortText = computed(() => {
    switch (selectedSort.value) {
      case 1:
        return "Tăng dần";
      case 2:
        return "Giảm dần";
      default:
        return "Mặc định";
    }
  });
  
  const handleSearchProducts = () => {
    
  };
  
  const giayProducts = reactive(GiaySeedData);
  
  // Hàm làm tròn lên đến số thập phân thứ 1
  const roundNumber = (num: number) => {
    return Math.round(num * Math.pow(10, 1)) / Math.pow(10, 1);
  };
  // Change if selectedSort Change
  watch(selectedSort, () => {
    switch (selectedSort.value) {
      case 1:
        giayProducts.sort((a, b) => roundNumber(a.price * (1 - a.voucher / 100)) - roundNumber(b.price * (1 - b.voucher / 100)));
        break;
      case 2:
        giayProducts.sort((a, b) => roundNumber(b.price * (1 - b.voucher / 100)) - roundNumber(a.price * (1 - a.voucher / 100)));
        break;
      default:
          // Default when giayProducts call first time
        break;
    }
  });
  </script>
  
  <style scoped></style>
  