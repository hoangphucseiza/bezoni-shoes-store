// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  compatibilityDate: "2024-04-03",
  devtools: { enabled: true },
  modules: ["@nuxtjs/tailwindcss", "@nuxt/icon", "@vee-validate/nuxt"],
  css: ["~/assets/scss/main.scss"],
  veeValidate: {
    // disable or enable auto imports
    autoImports: true,
  },
});
