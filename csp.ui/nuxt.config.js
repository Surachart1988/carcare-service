require('dotenv').config()

export default {
  /*
   ** Nuxt rendering mode
   ** See https://nuxtjs.org/api/configuration-mode
   */
  mode: "spa",
  render: {
    resourceHints: false
  },
  /*
   ** Nuxt target
   ** See https://nuxtjs.org/api/configuration-target
   */
  target: "server",
  /*
   ** Headers of the page
   ** See https://nuxtjs.org/api/configuration-head
   */
  head: {
    title: "CAR SERVICE --PLATFORM--",
    meta: [
      { charset: "utf-8" },
      { name: "viewport", content: "width=device-width, initial-scale=1" },
      {
        hid: "description",
        name: "description",
        content: "CAR SERVICE --PLATFORM--"
      }
    ],
    link: [
      { rel: "icon", type: "image/x-icon", href: "/favicon.ico" },
      // {
      //   rel: "stylesheet",
      //   href:
      //     "https://fonts.googleapis.com/css2?family=Prompt:wght@400;600&display=swap"
      // }
    ]
  },
  /*
   ** Global CSS
   */
  css: [
   "tm-iview/dist/styles/iview.css",
   "@assets/scss/main.scss",
   "@assets/scss/flex.scss",
   "@assets/scss/iview-menu.scss",
   "@assets/scss/iview-input.scss",
   "@assets/scss/iview-button.scss",
   "@assets/scss/iview-table.scss",
   "@assets/scss/iview-modal.scss",
   "@assets/scss/iview-form.scss",
   "@assets/scss/iview-tab.scss",
   "@assets/scss/iview-datepicker.scss",
   "@assets/scss/iview-pagination.scss",
   "@assets/scss/iview-divider.scss",
   "@assets/scss/iview-collapse.scss",
   "@assets/scss/iview-radio.scss",
   "@assets/scss/iview-checkbox.scss",
   "@assets/scss/iview-dropdown.scss"
  ],
  /*
   ** Plugins to load before mounting the App
   ** https://nuxtjs.org/guide/plugins
   */
  plugins: [
    "@/plugins/iview",
    { src: "@/plugins/sugar", ssr: false },
    { src: "@/plugins/vue-content-placeholders", ssr: false },
    { src: "@/plugins/vuejs-jwt", ssr: false }
  ],
  /*
   ** Auto import components
   ** See https://nuxtjs.org/api/configuration-components
   */
  components: true,
  /*
   ** Nuxt.js dev-modules
   */
  buildModules: ["@aceforth/nuxt-optimized-images", '@nuxtjs/dotenv'],
  optimizedImages: {
    optimizeImages: true
  },
  /*
   ** Nuxt.js modules
   */
  modules: [
    // Doc: https://axios.nuxtjs.org/usage
    "@nuxtjs/axios",
    "@nuxtjs/style-resources",
    "nuxt-purgecss",
    "nuxt-webfontloader",
  ],
  env: {
    BASE_URL: process.env.BASE_URL
  },
  webfontloader: {
    google: {
      families: ['Kanit:300&display,600&display'] //Loads Lato font with weights 400 and 700
    }
  },
  dayjs: {
    locales: ['th'],
    defaultLocale: 'th',
    plugins: [] // Your Day.js plugin
  },
  purgeCSS: {
    whitelist: () => ["html", "body", "ul", "li", "table", "thead", "th", "tr", "td", "a", "i"],
    whitelistPatterns: () =>  [/ivu*/, /layout*/, /flex*/, /top/, /hide*/],
  },
  styleResources: {
    scss: [
      './assets/scss/vars/*.scss',
      './assets/scss/mixins/*.scss'
      ]
  },
  /*
   ** Axios module configuration
   ** See https://axios.nuxtjs.org/options
   */
  axios: {
    proxy: true
  },
  proxy: {
    "/api/": "http://localhost:5000/",
    //"/api/": "http://cspapi_api_1:5000/",  /* for docker */
    ws: true
  },
  /*
   ** Build configuration
   ** See https://nuxtjs.org/api/configuration-build/
   */
   build: {}
};
