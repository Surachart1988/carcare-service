<template>
  <main class="container">
    <div>{{auth}}</div>
    <pre>{{token}}</pre>
    <div>menuID {{menuID}}</div>
  </main>
</template>

<script>
export default {
  middleware: 'authenticated',
  components: {},
  data() {
    return {
      
    }
  },
  computed: {
    auth() {
      if (this.$store.state.auth) {
        return this.$jwt.decode(this.$store.state.auth.AccessToken)
      }
    },
    token() {
      return this.$store.state.auth
    },
    menuID() {
      return this.$store.state.menuID
    }
  },
  async mounted() {
  },
  methods: {

  }
}
</script>

<style lang="scss" scoped>
@function rem($size) {
  @return $size / 16px * 1rem;
}

</style>
