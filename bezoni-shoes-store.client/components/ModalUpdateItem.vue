<template>
  <div
    v-if="IsModalUpdateItem"
    class="bg-[#ebe6e662] absolute top-0 left-0 right-0 bottom-0 flex justify-center items-center"
  >
    <div
      class="flex flex-col min-h-fit min-w-[800px] bg-white rounded-xl p-5 border gap-5"
    >
      <div class="flex justify-between items-center border-b pb-2">
        <div class="mx-auto font-semibold text-[20px]">Chỉnh sửa Item</div>
        <div @click="handleCloseModalUpdateItem">
          <Icon
            name="material-symbols:close"
            class="text-[#f36123df] text-[30px] cursor-pointer"
          />
        </div>
      </div>
      <div :validation-schema="schema" class="flex flex-col gap-5">
        <div class="flex flex-col gap-2">
          <label class="text-[20px] font-semibold">Tên Item:</label>
          <Field
            name="name"
            type="text"
            class="border border-gray-300 rounded-md p-2 w-full"
          />
          <ErrorMessage name="name" class="text-red-500" />
        </div>
        <div class="flex flex-col gap-2">
          <label class="text-[20px] font-semibold">Ảnh Item:</label>
          <!-- Input upload Image -->
          <input
            type="file"
            name="file"
            id="file_up"
            class="border border-gray-300 rounded-md p-2 w-full"
            accept="image/*"
            @change="handleFileUpload"
          />
          <img
            v-if="imgUrl"
            :src="imgUrl"
            alt="preview"
            class="w-[100px] h-[100px] object-cover"
          />
        </div>
        <div class="flex flex-col gap-2">
          <label class="text-[20px] font-semibold">Màu sắc Item:</label>
          <Field
            name="color"
            type="text"
            class="border border-gray-300 rounded-md p-2 w-full"
          />
          <ErrorMessage name="color" class="text-red-500" />
        </div>
        <div class="flex flex-col gap-2">
          <label class="text-[20px] font-semibold">Size:</label>
          <Field
            name="size"
            type="text"
            class="border border-gray-300 rounded-md p-2 w-full"
          />
          <ErrorMessage name="size" class="text-red-500" />
        </div>
        <div class="flex flex-col gap-2">
          <label class="text-[20px] font-semibold">Loại:</label>
          <input
            type="text"
            class="border border-gray-300 rounded-md p-2 w-full"
            v-model="typeOfItem"
          />
        </div>
        <div class="flex flex-col gap-2">
          <label class="text-[20px] font-semibold">Số lượng:</label>
          <Field
            name="quantity"
            type="number"
            class="border border-gray-300 rounded-md p-2 w-full"
          />
          <ErrorMessage name="quantity" class="text-red-500" />
        </div>
        <div class="flex flex-col gap-2">
          <label class="text-[20px] font-semibold"
            >Item thuộc sản phẩm nào:</label
          >
          <select
            class="border border-gray-300 rounded-md p-2"
            v-model="selectedProduct"
          >
            <option value="" disabled selected>Chọn sản phẩm</option>
            <option
              v-for="(product, index) in listProduct"
              :key="index"
              :value="product.id"
            >
              {{ product.name }}
            </option>
          </select>
          <ErrorMessage name="categoryID" class="text-red-500" />
        </div>
        <div
          class="flex justify-center items-center bg-[#F36123] text-white text-[20px] font-bold rounded-xl p-2 cursor-pointer hover:bg-[#f36123df] hover:shadow-xl"
          @click="submitForm"
        >
          Chỉnh sửa Item
        </div>
      </div>
    </div>
    <ErrorToast />
    <SuccessToast />
    <LoadingPage />
    <modal-warning />
  </div>
</template>
    <script setup lang="ts">
import { defineProps, ref, computed, onMounted, watch, reactive } from "vue";
import { Form, Field, ErrorMessage, useForm } from "vee-validate";
import { string, number } from "yup";
import { useAlertStore } from "~/store/alertStore";
import { useProductStore } from "~/store/productStore";
import { useCommonStore } from "~/store/commonStore";
import type { IAddProductBody } from "~/interface/RequestBody/IAddProductBody";
import type { ICreateItemBody } from "~/interface/RequestBody/ICreateItemBody";
import { useItemStore } from "~/store/itemStore";
import type { IUpdateItemBody } from "~/interface/RequestBody/IUpdateItemBody";

// Định nghĩa các props của component
const props = defineProps<{
  IsModalUpdateItem: boolean;
  handleCloseModalUpdateItem: () => void;
}>();

// Store
const alertStore = useAlertStore();
const productStore = useProductStore();

// Computed properties
const listProduct = computed(() => productStore.products);

watchEffect(async () => {
  await productStore.handleGetProducts();
});

// Validation schema
const schema = reactive({
  name: string().required("Tên Item không được để trống"),
  color: string().required("Màu sắc Item không được để trống"),
  size: string().required("Size không được để trống"),
  quantity: number()
    .required("Số lượng không được để trống")
    .min(0, "Số lượng phải lớn hơn hoặc bằng 0"),
});
const selectedProduct = ref<string>("");
const imgUrl = ref<string>("");
const typeOfItem = ref<string>("");

// Methods
const { handleSubmit } = useForm({
  validationSchema: schema,
});

// Handle file upload
const handleFileUpload = async (e: Event) => {
  const file = (e.target as HTMLInputElement).files?.[0];

  if (file) {
    // Clear previous image preview
    imgUrl.value = "";

    // Check if the file format is valid
    if (!/\.(jpeg|jpg|png)$/i.test(file.name)) {
      alertStore.handleOpenErrorToast("File không đúng định dạng");
      return;
    }

    // Display the selected image preview URL
    const reader = new FileReader();
    reader.onload = () => {
      if (typeof reader.result === "string") {
        imgUrl.value = reader.result; // Sets the preview URL
      }
    };
    reader.readAsDataURL(file);

    try {
      // Prepare form data for Cloudinary upload
      const formData = new FormData();
      formData.append("file", file);
      formData.append("upload_preset", "l8kug72o");
      formData.append("cloud_name", "daivzvim9");

      // Perform the Cloudinary upload
      const res = await fetch(
        "https://api.cloudinary.com/v1_1/daivzvim9/image/upload",
        {
          method: "POST",
          body: formData,
        }
      );

      // Handle Cloudinary response
      if (!res.ok) {
        throw new Error("Upload failed");
      }
      const data = await res.json();

      // Optionally: Update `imgUrl` with the secure URL from Cloudinary
      imgUrl.value = data.secure_url || imgUrl.value;
    } catch (error) {
      alertStore.handleOpenErrorToast("Image upload failed");
      console.error("Error during Cloudinary upload:", error);
    }
  }
};
const itemStore = useItemStore();
// Handle form submission
const submitForm = handleSubmit(async (values) => {
  if (!imgUrl.value || imgUrl.value === "") {
    alertStore.handleOpenErrorToast("Vui lòng chọn ảnh trước khi thêm.");
    return;
  }
  if (!selectedProduct.value || selectedProduct.value === "") {
    alertStore.handleOpenErrorToast("Vui lòng chọn sản phẩm trước khi thêm.");
    return;
  }

  const updateItemBody: IUpdateItemBody = {
    id: itemStore.updateItem?.id || "",
    name: values.name,
    color: values.color,
    size: values.size,
    quantity: values.quantity,
    type: typeOfItem.value,
    productID: selectedProduct.value,
    image: imgUrl.value,
  };
  await itemStore.handleUpdateItem(updateItemBody);
});
const { setFieldValue } = useForm();
const updateItem = computed(() => itemStore.updateItem);
const handleUpdateItemToForm = () => {
  if (updateItem.value) {
    // Populate the image URL and item type fields
    imgUrl.value = updateItem.value.image;
    typeOfItem.value = updateItem.value.type;
    selectedProduct.value = updateItem.value.productID;

    // Use VeeValidate's `setFieldValue` to update the form fields
    setFieldValue("name", updateItem.value.name);
    setFieldValue("color", updateItem.value.color);
    setFieldValue("size", updateItem.value.size);
    setFieldValue("quantity", updateItem.value.quantity);
  }
};
watchEffect(() => {
  handleUpdateItemToForm();
});
</script>
    