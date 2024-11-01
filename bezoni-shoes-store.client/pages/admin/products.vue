<template>
  <div
    class="flex flex-col gap-5 border h-screen p-4 shadow-sm rounded-md relative bg-[#F5EDE6]"
  >
    <div
      class="flex justify-between items-center border-b-[1px] border-[#F36123] pb-5"
    >
      <div class="flex items-center gap-3">
        <div class="font-semibold">Danh mục</div>
        <select
          class="border border-gray-300 rounded-md p-2"
          v-model="selectedCategory"
        >
          <option value="0">Tất cả</option>
          <option
            v-for="(category, index) in listCategory"
            :key="index"
            :value="category.id"
          >
            {{ category.name }}
          </option>
        </select>
        <input
          type="text"
          placeholder="Tìm kiếm sản phẩm Item"
          class="border min-w-[300px] border-gray-300 rounded-md p-2"
          v-model="searchItem"
        />
        <!-- Button Tìm kiếm -->
        <div
          class="flex items-center gap-2 bg-[#F36123] text-white text-[15px] font-bold rounded-md p-2 cursor-pointer hover:bg-[#f36123df] hover:shadow-xl"
          @click="handleSearchItem"
        >
          <div>Tìm kiếm</div>
        </div>
      </div>
      <div class="flex gap-5">
        <div
          class="flex items-center gap-2 bg-[#F36123] text-white text-[15px] font-bold rounded-md p-2 cursor-pointer hover:bg-[#f36123df] hover:shadow-xl"
          @click="IsModalAddItem = true"
        >
          <div>Thêm item sản phẩm</div>
        </div>
        <div
          class="flex items-center gap-2 bg-[#F36123] text-white text-[15px] font-bold rounded-md p-2 cursor-pointer hover:bg-[#f36123df] hover:shadow-xl"
          @click="IsModalAddProduct = true"
        >
          <div>Quản lý sản phẩm</div>
        </div>
        <div
          class="flex items-center gap-2 bg-[#F36123] text-white text-[15px] font-bold rounded-md p-2 cursor-pointer hover:bg-[#f36123df] hover:shadow-xl"
          @click="IsModalAddCategory = true"
        >
          <div>Quản lý danh mục</div>
        </div>
      </div>
    </div>
    <div>
      <!-- Bảng sản phẩm -->
      <table
        class="min-w-full bg-white border border-gray-200 rounded-lg shadow-md"
      >
        <thead class="bg-[#F36123] text-white">
          <tr>
            <th class="py-3 px-4 text-left">STT</th>
            <th class="py-3 px-4 text-left">Tên danh mục</th>
            <th class="py-3 px-4 text-left">Tên sản phẩm</th>
            <th class="py-3 px-4 text-left">Tên Item</th>
            <th class="py-3 px-4 text-left">Hình ảnh</th>
            <th class="py-3 px-4 text-left">Màu sắc</th>
            <th class="py-3 px-4 text-left">Size</th>
            <th class="py-3 px-4 text-left">Loại</th>
            <th class="py-3 px-4 text-left">Số lượng</th>
            <th class="py-3 px-4 text-left">Giá</th>
            <th class="py-3 px-4 text-left">Voucher</th>
            <th class="py-3 px-4 text-left">Chức năng</th>
          </tr>
        </thead>
        <tbody v-if="listItem && listItem.length > 0">
          <template v-for="(item, index) in listItem" :key="index">
            <tr class="hover:bg-[#F5EDE6] transition duration-200">
              <td class="py-3 px-4 border-t">{{ index + 1 }}</td>
              <td class="py-3 px-4 border-t">{{ item.categoryName }}</td>
              <td class="py-3 px-4 border-t">{{ item.productName }}</td>
              <td class="py-3 px-4 border-t">{{ item.itemName }}</td>
              <td class="py-3 px-4 border-t">
                <img
                  :src="item.image"
                  alt="Hình ảnh"
                  class="w-[100px] h-[100px] rounded-md"
                />
              </td>
              <td class="py-3 px-4 border-t">{{ item.color }}</td>
              <td class="py-3 px-4 border-t">{{ item.size }}</td>
              <td class="py-3 px-4 border-t">{{ item.type }}</td>
              <td class="py-3 px-4 border-t">{{ item.quantity }}</td>
              <td class="py-3 px-4 border-t">{{ item.price }}</td>
              <td class="py-3 px-4 border-t">{{ item.voucher }}%</td>
              <td class="py-3 px-4 border-t">
                <div class="flex gap-4">
                  <div
                    class="text-white bg-[#F36123] p-1 rounded-md cursor-pointer"
                    @click="handleUpdateItem(item.id)"
                  >
                    Sửa
                  </div>
                  <div
                    class="text-white bg-[#F36123] p-1 rounded-md cursor-pointer"
                    @click="handleDeleteItem(item.id)"
                  >
                    Xóa
                  </div>
                </div>
              </td>
            </tr>
          </template>
        </tbody>
        <tbody v-else>
          <tr>
            <td colspan="12" class="py-3 px-4 text-center">
              <Icon
                name="line-md:loading-loop"
                class="text-[#f36123df] text-[30px] cursor-pointer"
              />
            </td>
          </tr>
        </tbody>
      </table>

      <!-- pagination -->
      <div class="flex justify-center items-center gap-5 mt-5">
        <div
          class="flex items-center gap-2 bg-[#F36123] text-white text-[15px] font-bold rounded-md p-2 cursor-pointer hover:bg-[#f36123df] hover:shadow-xl"
          @click="handlePreviousPage"
        >
          <div>Trang trước</div>
        </div>
        <div
          class="flex items-center gap-2 bg-[#F36123] text-white text-[15px] font-bold rounded-md p-2 cursor-pointer hover:bg-[#f36123df] hover:shadow-xl"
        >
          <div>{{ pagination }}</div>
        </div>
        <div
          class="flex items-center gap-2 bg-[#F36123] text-white text-[15px] font-bold rounded-md p-2 cursor-pointer hover:bg-[#f36123df] hover:shadow-xl"
          @click="handleNextPage"
        >
          <div>Trang sau</div>
        </div>
      </div>
    </div>
    <ModalAddCategory
      :IsModalAddCategory="IsModalAddCategory"
      :handleCloseModalAddCategory="handleCloseModalAddCategory"
    />
    <ModalAddProduct
      :IsModalAddProduct="IsModalAddProduct"
      :handleCloseModalAddProduct="handleCloseModalAddProduct"
    />
    <ModalAddItem
      :IsModalAddItem="IsModalAddItem"
      :handleCloseModalAddItem="handleCloseModalAddItem"
    />
    <ModalUpdateItem
      :IsModalUpdateItem="IsModalUpdateItem"
      :handleCloseModalUpdateItem="handleCloseModalUpdateItem"
    />
  </div>
</template>

<script setup lang="ts">
import { useAlertStore } from "~/store/alertStore";
import { useAuthStore } from "~/store/authStore";
import { useCategoryStore } from "~/store/categoryStore";
import { useCommonStore } from "~/store/commonStore";
import { useItemStore } from "~/store/itemStore";
import { useProductStore } from "~/store/productStore";

const categoryStore = useCategoryStore();
definePageMeta({
  layout: "admin",
});

const IsModalAddCategory = ref(false);
const IsModalAddProduct = ref(false);

const handleCloseModalAddCategory = () => {
  IsModalAddCategory.value = false;
};
const handleCloseModalAddProduct = () => {
  IsModalAddProduct.value = false;
};

const handleCloseModalAddItem = () => {
  IsModalAddItem.value = false;
};
const IsModalUpdateItem = ref(false);
const handleCloseModalUpdateItem = () => {
  IsModalUpdateItem.value = false;
};
const IsModalAddItem = ref(false);
const authStore = useAuthStore();
const alertStore = useAlertStore();
const productStore = useProductStore();
const itemStore = useItemStore();
// Bind `listCategory` to the `categories` state in the store
const listCategory = computed(() => categoryStore.categories);
const listItem = computed(() => itemStore.items);
const commonStore = useCommonStore();

const handleUpdateItem = async (id: string) => {
  IsModalUpdateItem.value = true;
  await itemStore.handleSetUpdateItem(id);
};

const handleDeleteItem = async (id: string) => {
  //  Window.confirm("Bạn có chắc chắn muốn xóa item này không?");
  const isConfirm = window.confirm("Bạn có chắc chắn muốn xóa item này không?");
  if (!isConfirm) return;
  await itemStore.handleDeleteItem(id);
};

const selectedCategory = ref("0");
const searchItem = ref("");
const pagination = ref(1);

const handleNextPage = async () => {
  pagination.value += 1;
  await itemStore.handleSearchItem(
    pagination.value,
    selectedCategory.value,
    searchItem.value
  );
};
const handlePreviousPage = async () => {
  if (pagination.value === 1) return;
  pagination.value -= 1;
  await itemStore.handleSearchItem(
    pagination.value,
    selectedCategory.value,
    searchItem.value
  );
};
const handleSearchItem = async () => {
  await itemStore.handleSearchItem(
    pagination.value,
    selectedCategory.value,
    searchItem.value
  );
};

onMounted(async () => {
  await categoryStore.getAllCategory();
  await itemStore.handleGetAllItem();
});
// after mounted
</script>

<style scoped></style>
