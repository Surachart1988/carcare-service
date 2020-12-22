<template>
  <div class="page-container">
    <div layout="row">
      <div flex="auto" class="aside-menu">
        <div layout="row" layout-align="center center">
          <img class="logo" src="@/assets/images/logo.svg" alt />
        </div>
        <Divider class="under-logo" />
        <AsideMenu></AsideMenu>
      </div>
      <div flex="grow" class="main-contenter">
        <Nuxt />
      </div>
    </div>
    <BackTop :height="60" :bottom="30">
      <div class="top">
        <Icon type="ios-arrow-up" />
      </div>
    </BackTop>
  </div>
</template>

<script>
import Cookies from 'js-cookie'
import AsideMenu from '@/components/AsideMenu'

export default {
  components: {
    AsideMenu
  },
  data() {
    return {}
  },
  computed: {},
  async mounted() {
    this.checkLogin()
    if (localStorage.cspAuth) {
      let cspAuth = JSON.parse(localStorage.getItem('cspAuth'))

      this.$store.commit('setAuth', cspAuth)
    }
  },
  methods: {
    checkLogin() {
      console.log(process.client)
      if (process.client) {
        let valueCookie = Cookies.get('cspAuth')
        if (valueCookie == 'logged-in') {
          this.$store.commit('setAuth', 'logged-in')
        }

        if (valueCookie != 'logged-in') {
          this.$store.commit('setAuth', '')
        }
      }
    }
  }
}
</script>

<style lang="scss">
.page-container {
  padding: 50px 34px 50px 26px;
  background: rgb(0, 147, 69);
  background: linear-gradient(115deg, #009345 0%, #006e63 40%, #027294 50%, #00898e 70%, #0081cb 100%);
  min-height: 100vh;
}

.aside-menu {
  min-width: 246px;
  max-width: 246px;
  padding-right: 15px;
  margin-bottom: 40px;
}

.main-contenter {
  background-color: #f5f5f5;
  border-radius: 40px;
  padding: 25px 37px 35px 37px;
  word-break: break-word;
  min-height: calc(100vh - 100px);
  max-width: calc(100vw - 323px);
}

.under-logo {
  margin: 8px 0 15px 0;
}

.ivu-divider {
  background: rgba(249, 249, 249, 0.5);
}

.top {
  padding: 3px;
  background: rgba($color_font-2, 0.7);
  color: #fff;
  text-align: center;
  border-radius: 10px;
}
</style>
