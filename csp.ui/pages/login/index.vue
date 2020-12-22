<template>
  <main class="login-page" layout="column" layout-align="center center">
    <div flex="grow" layout="column" layout-align="center center" style="padding-top: 50px;">
      <img class="logo" src="@/assets/images/logo.svg" alt />

      <Form ref="loginValidate" :model="formItem" :rules="ruleValidate">
        <FormItem
          prop="username"
          flex="100"
          layout="row"
          layout-align="center center"
          class="relative"
        >
          <img class="prefix-icon" src="@/assets/images/icon/login-user.svg" alt />
          <Input size="large" v-model="formItem.username" placeholder="username"></Input>
        </FormItem>

        <FormItem
          prop="password"
          flex="100"
          layout="row"
          layout-align="center center"
          class="relative"
        >
          <img class="prefix-icon" src="@/assets/images/icon/login-password.svg" alt />
          <Input type="password" size="large" v-model="formItem.password" placeholder="password"></Input>
        </FormItem>

        <div layout="row" layout-align="center center">
          <Button
            @click="handleSubmit('loginValidate')"
            class="btn-login"
            type="default"
            ghost
            shape="circle"
            size="large"
          >LOGIN</Button>

          <Button
            @click="formItem.username = 'superadmin'; formItem.password = 'P@ssw0rd'"
            class="btn-login"
            type="default"
            ghost
            shape="circle"
            size="large"
          >auto key</Button>

        </div>
      </Form>
    </div>

    <div
      flex="none"
      class="copyright"
      layout="row"
      layout-align="center center"
    >Copyright 2020 Proconsultplus co.,ltd. All Rights Reserved.</div>
  </main>
</template>

<script>
import Cookies from 'js-cookie'

export default {
  layout: 'login',
  middleware: 'notAuthenticated',
  data() {
    return {
      resource: '',
      formItem: {
        username: '',
        password: ''
      },
      ruleValidate: {
        username: [{ required: true, message: 'กรุณากรอกข้อมูล', trigger: 'blur' }],
        password: [{ required: true, message: 'กรุณากรอกข้อมูล', trigger: 'blur' }]
      }
    }
  },
  computed: {
  },
  methods: {
    handleSubmit(name) {
      this.$refs[name].validate(valid => {
        if (valid) {
          this.login()
        } else {
          this.$Message.error('กรอกข้อมูลไม่ครบ!')
        }
      })
    },
    async login() {

      let apiUrl = `/api/v1/login`
      let res = await this.$axios
        .$post(
          `${apiUrl}`,
          {
            LoginName: this.formItem.username,
            Password: this.formItem.password
          },
          {
            headers: {
              'Access-Control-Allow-Origin': '*'
            }
          }
        )
        .catch(function (error) {
          if (error.response) {
            console.log(error.response.status)
          }
        })

        console.log('login()', res)

      let { StatusCode, Resource } = res

      if (StatusCode == 200) {
        this.resource = Resource
        this.authLogin()
      }
      if (StatusCode != 200) {
        this.$Message.error('มีบางอย่างผิดพลาด!')
      }
    },
    authLogin() {
      if (process.client) {
        let cspAuth = {
          AccessToken: this.resource.AccessToken,
          RefreshToken: this.resource.RefreshToken
        }
        localStorage.setItem('cspAuth', JSON.stringify(cspAuth))

        const auth = 'logged-in'
        Cookies.set('cspAuth', auth)
        this.$router.push('/')
      }
    }
  }
}
</script>

<style lang="scss">
@function rem($size) {
  @return $size / 16px * 1rem;
}

.login-page {
  min-height: 100vh;

  // only login page
  .logo {
    transform: scale(2, 2);
    margin-top: 40px;
    margin-bottom: 120px;
  }

  .ivu-input-large {
    height: 46px;
    border-radius: 50px;
    padding: 10px 60px;
    border-color: darken($color_background, 5%);
    min-width: 323px;
    max-width: 100%;
    text-align: center;
  }

  ::-webkit-input-placeholder {
    text-align: center;
    font-size: $fontSize-1;
    color: $color_font-2;
  }

  :-moz-placeholder {
    /* Firefox 18- */
    text-align: center;
    font-size: $fontSize-1;
    color: $color_font-2;
  }

  ::-moz-placeholder {
    /* Firefox 19+ */
    text-align: center;
    font-size: $fontSize-1;
    color: $color_font-2;
  }

  :-ms-input-placeholder {
    text-align: center;
    font-size: $fontSize-1;
    color: $color_font-2;
  }

  .prefix-icon {
    position: absolute;
    z-index: 9;
    transform: translateY(calc(50% + 3px));
    left: 30px;
  }

  .btn-login {
    margin-top: 50px;
  }

  .ivu-btn {
    border-width: 2px;
    font-weight: bold;
  }

  .copyright {
    font-size: 14px;
    color: #f9f9f9;
    margin: 40px 0;
  }

  .ivu-form-item-error-tip {
    color: #f3db57;
  }

  .ivu-btn-ghost.ivu-btn-dashed:hover,
  .ivu-btn-ghost.ivu-btn-default:hover {
    color: #f3db57;
    border-color: #f3db57;
  }
}
</style>
