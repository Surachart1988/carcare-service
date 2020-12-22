import Cookies from "js-cookie";
export default {
  data() {
    return {
      resourceRefresh: null,
      reTokenCount: 0
    };
  },
  computed: {
    accessToken() {
      if (this.$store.state.auth) {
        return this.$store.state.auth.AccessToken;
      }
    },
    refreshToken() {
      if (this.$store.state.auth) {
        return this.$store.state.auth.RefreshToken;
      }
    }
  },
  methods: {
    async reToken() {
      console.log("reToken()");

        let res = await this.$axios
          .$post(
            `/api/v1/refreshtoken`,
            {
              AccessToken: this.accessToken,
              RefreshToken: this.refreshToken
            },
            {
              headers: {
                "Access-Control-Allow-Origin": "*"
              }
            }
          )
          .catch(function(error) {
            if (error.response) {
              console.log(error.response.status);
            }
          });

        console.log("reToken()", res);
        let { StatusCode, Resource } = res;

        if (StatusCode == 200) {
          this.resourceRefresh = await Resource;

          let cspAuth = {
            AccessToken: this.resourceRefresh.AccessToken,
            RefreshToken: this.resourceRefresh.RefreshToken
          };
          localStorage.setItem("cspAuth", JSON.stringify(cspAuth));

          this.$store.commit("setAuth", cspAuth);

          console.log("refreshToken success");
        }
        if ( StatusCode == 498 || StatusCode == 400 || StatusCode == 401 || StatusCode == 403 || StatusCode == 404 || res == undefined || res == null) {
          console.log("logoutToLogin");
          this.logoutToLogin();
        }

    },
    logoutToLogin() {
      Cookies.remove("cspAuth");
      localStorage.removeItem("cspAuth");
      this.$store.commit("setAuth", "");
      this.$router.push("/login");
    }
  }
};