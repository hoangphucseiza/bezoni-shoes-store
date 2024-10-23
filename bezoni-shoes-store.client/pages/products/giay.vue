<template>
    <div class="py-[20px]">
        <div class="flex flex-row gap-2 text-[18px]">
            <NuxtLink to="/" class="font-bold cursor-pointer text-[#F36123] hover:underline">Home   /</NuxtLink>
            <div class="font-semibold">Giày</div>
        </div>
        <div class="flex gap-2">
            <div>Giá</div>
            <div>Vouncher</div>
        </div>
        <div>ListProduct</div>
    </div>
</template>

<script setup lang="ts">
 const route = useRoute();
console.log(route);
</script>

<style scoped>

</style>