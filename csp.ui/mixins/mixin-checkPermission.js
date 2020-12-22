export default {
  data() {
    return {
      cPermisson: null,
      ePermisson: null,
      vPermisson: null,
      dPermisson: null,
      pPermisson: null
    };
  },
  computed: {
    menuID() {
      return this.$store.state.menuID;
    },
    auth() {
      if (this.$store.state.auth) {
        return this.$jwt.decode(this.$store.state.auth.AccessToken);
      }
    }
  },
  mounted() {
  },
  methods: {
    async checkPermission() {
      let apiWithQuery = `/api/v1/MasterData/permission/userId`;
      console.log("apiWithQuery", apiWithQuery);

      // let data = {
      //   PositionID: +this.auth.PositionId,
      //   MenuID: +this.menuID
      // };
      let data = {
        PositionID: 2,
        MenuID: 40
      };
      console.log("data", data);

      let res = await this.$axios
        .$post(apiWithQuery, data, {
          headers: {
            "Access-Control-Allow-Origin": "*",
            Authorization: `Bearer ${this.accessToken}`
          }
        })
        .catch(function(error) {
          if (error.response) {
            console.log(error.response.status);
          }
        });

      if (res) {
        console.log("checkPermission()", res);
        let { StatusCode, Resource } = res;

        if (StatusCode == 200) {
          this.cPermisson = Resource.CreatePermisson;
          this.ePermisson = Resource.EditPermisson;
          this.vPermisson = Resource.ViewPermisson;
          this.dPermisson = Resource.DeletePermisson;
          this.pPermisson = Resource.PrintPermisson;
        }
      }

      if (res == undefined) {
        await this.reToken();
        await this.checkPermission();
      }
    }
  }
};
