<template>
  <div>
    <h1>This is secret page.</h1>
    <NuxtLink to="/">
      Back home2
    </NuxtLink>

    <div >
      <content-placeholders>
        <content-placeholders-heading/>
        <content-placeholders-text :lines="3" />
      </content-placeholders>
    </div>
    <!-- <div v-if="post != ''">
      <h1>{{ post.title }}</h1>
      <div>{{ post.body }}</div>
      <author :author-id="post.userId"/>
    </div> -->

    <button @click="logout">
        Logout
      </button>
  </div>
</template>

<script>
import Cookies from 'js-cookie'

export default {
  middleware: 'authenticated',
  computed: {},
  mounted () {
  },
  methods: {
    logout () {
      Cookies.remove('cspAuth')
      localStorage.removeItem('cspAuth')
      this.$store.commit('setAuth', '')
      this.$router.push('/login')
    }
  }
}
</script>
