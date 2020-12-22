<template>
  <div class="login-container" :style="{ backgroundImage: `url(${bgLogin})` }">
    <div layout="row">
      <div flex="grow">
        <Nuxt />
      </div>
    </div>
  </div>
</template>

<script>
import backgroundImage from '@/assets/images/bg-login.webp'

export default {
  components: {
  },
  data() {
    return {
      bgLogin: backgroundImage
    }
  },
  computed: {
  },
  async mounted() {},
  methods: {}
}
</script>

<style lang="scss" scoped>
@function rem($size) {
  @return $size / 16px * 1rem;
}

.login-container {
background-size: cover;
  background-repeat: no-repeat;
  background-attachment: fixed;
  background-position: center;
  background-image: linear-gradient(125deg, #009345 0%, #00898e 90%, #0081cb 100%);
  min-height: 100vh;
}

</style>
