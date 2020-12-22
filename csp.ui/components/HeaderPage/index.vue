<template>
  <div class="component-wrapper">
    <!-- menuID {{menuID}}
    <div>cPermisson {{$parent.cPermisson}}</div>
    <div>ePermisson {{$parent.ePermisson}}</div>
    <div>vPermisson {{$parent.vPermisson}}</div>
    <div>dPermisson {{$parent.dPermisson}}</div>
    <div>pPermisson {{$parent.pPermisson}}</div> -->
    <div layout="row" :class="{noDivider: !divider}">
      <div flex="auto" layout-align="start center">
        <h1 class="title-headder">
          <slot></slot>
        </h1>
        <div class="sub-headder">
          <slot name="subheader"></slot>
        </div>
      </div>
      <div flex="none">
        <Dropdown id="user-info" placement="bottom-end">
          <Avatar
            v-if="userAvatar"
            :src="require('@/assets/images/icon/user.svg')"
            style="background-color: rgba(0, 147, 69, 0.2) padding: 8px;
display: flex;"
            size="large"
          />
          <DropdownMenu slot="list">
            <DropdownItem disabled id="info-data">{{userFirstname}} {{userLastname}}</DropdownItem>
            <DropdownItem>
              <div layout="row" layout-align="start center">
                <svg
                  id="user"
                  xmlns="http://www.w3.org/2000/svg"
                  width="19.004"
                  height="19.004"
                  viewBox="0 0 19.004 19.004"
                >
                  <g id="Group_1" data-name="Group 1" transform="translate(0)">
                    <path
                      id="Path_1"
                      data-name="Path 1"
                      d="M2.783,12.285A9.466,9.466,0,0,1,6.394,10.02a5.493,5.493,0,1,1,6.216,0A9.517,9.517,0,0,1,19,19H17.52A8.017,8.017,0,0,0,1.485,19H0A9.44,9.44,0,0,1,2.783,12.285ZM9.5,9.5A4.009,4.009,0,1,0,5.493,5.493,4.013,4.013,0,0,0,9.5,9.5Z"
                      transform="translate(0)"
                      fill="#fff"
                    />
                  </g>
                </svg>
                Profile
              </div>
            </DropdownItem>
            <DropdownItem>
              <div layout="row" layout-align="start center">
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  width="18.977"
                  height="18.882"
                  viewBox="0 0 18.977 18.882"
                >
                  <g id="edit" transform="translate(0 -0.261)">
                    <path
                      id="Path_337"
                      data-name="Path 337"
                      d="M17.515,49.182a.473.473,0,0,0-.473.473v4.2a1.419,1.419,0,0,1-1.418,1.418H2.363A1.419,1.419,0,0,1,.945,53.851V41.535a1.42,1.42,0,0,1,1.418-1.418h4.2a.473.473,0,0,0,0-.945h-4.2A2.366,2.366,0,0,0,0,41.535V53.852a2.366,2.366,0,0,0,2.363,2.363H15.625a2.366,2.366,0,0,0,2.363-2.363v-4.2a.473.473,0,0,0-.473-.473Zm0,0"
                      transform="translate(0 -37.072)"
                      fill="#fff"
                    />
                    <path
                      id="Path_338"
                      data-name="Path 338"
                      d="M120.877.884a2.127,2.127,0,0,0-3.008,0l-8.432,8.432a.472.472,0,0,0-.121.208l-1.109,4a.473.473,0,0,0,.582.582l4-1.109a.473.473,0,0,0,.208-.121l8.432-8.432a2.129,2.129,0,0,0,0-3.008Zm-10.41,8.739,6.9-6.9,2.226,2.226-6.9,6.9Zm-.445.892,1.778,1.778-2.46.681Zm10.741-6.737-.5.5-2.226-2.226.5-.5a1.181,1.181,0,0,1,1.671,0l.555.555A1.183,1.183,0,0,1,120.764,3.778Zm0,0"
                      transform="translate(-103.077)"
                      fill="#fff"
                    />
                  </g>
                </svg>
                Manage account
              </div>
            </DropdownItem>
            <DropdownItem>
              <div layout="row" layout-align="start center" @click="logout()">
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  width="14.147"
                  height="18.999"
                  viewBox="0 0 14.147 18.999"
                >
                  <g id="Group_605" data-name="Group 605" transform="translate(-42.299 -0.435)">
                    <path
                      id="Path_664"
                      data-name="Path 664"
                      d="M56.446,108.866a7.068,7.068,0,0,0-3.132-5.875.865.865,0,0,0-.965,1.435,5.344,5.344,0,1,1-5.964.007A.865.865,0,0,0,45.417,103a7.074,7.074,0,1,0,11.029,5.865Z"
                      transform="translate(0 -96.506)"
                      fill="#fff"
                    />
                    <path
                      id="Path_665"
                      data-name="Path 665"
                      d="M149.444,14.612a.922.922,0,0,1-.922-.922V1.357a.922.922,0,1,1,1.845,0V13.689A.922.922,0,0,1,149.444,14.612Z"
                      transform="translate(-100.099)"
                      fill="#fff"
                    />
                  </g>
                </svg>
                Logout
              </div>
            </DropdownItem>
          </DropdownMenu>
        </Dropdown>

        <Button
          :disabled="$parent.cPermisson == false"
          v-if="buttonAdd"
          @click="$parent.openModalAdd()"
          type="primary"
          shape="circle"
          size="large"
          style="margin-left:15px;"
        >
          <Icon type="md-add" />เพิ่มข้อมูล
        </Button>
      </div>
    </div>

    <Divider v-if="divider" class="main-divider" />
  </div>
</template>

<script>
import Cookies from 'js-cookie'
import mixinCheckPermission from '@/mixins/mixin-checkPermission'

export default {
  mixins: [mixinCheckPermission],
  props: {
    title: {
      default: 'หัวเรื่อง'
    },
    suntitle: {
      default: 'รายละเอียด'
    },
    userAvatar: {
      default: true
    },
    buttonAdd: {
      default: false
    },
    divider: {
      default: true
    }
  },
  data() {
    return {}
  },
  computed: {
    jwtDecode() {
      if (this.$store.state.auth) {
        return this.$jwt.decode(this.$store.state.auth.AccessToken)
      }
    },
    userFirstname() {
      if (this.jwtDecode) {
        return this.jwtDecode.Firstname
      }
    },
    userLastname() {
      if (this.jwtDecode) {
        return this.jwtDecode.Lastname
      }
    }
  },
  methods: {
    logout() {
      Cookies.remove('cspAuth')
      localStorage.removeItem('cspAuth')
      this.$store.commit('setAuth', '')
      this.$router.push('/login')
    }
  }
}
</script>

<style lang="scss" scoped>
@function rem($size) {
  @return $size / 16px * 1rem;
}

.title-headder {
  font-size: $fontSize-Header;
  color: $color_font-main;
}

.sub-headder {
  font-size: $fontSize-1;
  color: $color_font-2;
  margin: 5px 0 0 10px;
}

.noDivider {
  margin-bottom: 22px;
}

.ivu-avatar {
  background-color: rgba($color_font-main, 0.25);
  padding: 8px;
}
</style>