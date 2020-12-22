<template>
  <div>
    <!-- menuID {{menuID}}
    <div>cPermisson {{$parent.cPermisson}}</div>
    <div>ePermisson {{$parent.ePermisson}}</div>
    <div>vPermisson {{$parent.vPermisson}}</div>
    <div>dPermisson {{$parent.dPermisson}}</div>
    <div>pPermisson {{$parent.pPermisson}}</div>-->
    <Table
      stripe
      size="large"
      :columns="tableColumns"
      :data="resource"
      :loading="loading"
      @on-sort-change="changeSort($event)"
    >
      <template slot-scope="{ row, index }" slot="bankAction">
      </template>

      <template slot-scope="{ row, index }" slot="status">
        <span v-if="row.Active == true">Active</span>
        <span v-if="row.Active == false">Dective</span>
      </template>

      <template slot-scope="{ row, index }" slot="tax">
        <span>{{row.Name}} ( {{row.Cost}}% )</span>
      </template>

      <template slot-scope="{ row, index }" slot="action">
        <div layout="row" layout-align="center center">
          <Tooltip placement="top" content="แก้ไขข้อมูล" layout="row" layout-align="center center">
            <svg
              class="btn-action"
              @click="editRowData(row.Id)"
              id="edit"
              xmlns="http://www.w3.org/2000/svg"
              width="18.058"
              height="17.967"
              viewBox="0 0 18.058 17.967"
            >
              <path
                class="a"
                id="Path_751"
                data-name="Path 751"
                d="M16.666,48.7a.45.45,0,0,0-.45.45V53.14a1.351,1.351,0,0,1-1.349,1.349H2.249A1.351,1.351,0,0,1,.9,53.14V41.421a1.351,1.351,0,0,1,1.349-1.349H6.242a.45.45,0,1,0,0-.9H2.249A2.251,2.251,0,0,0,0,41.421V53.14a2.251,2.251,0,0,0,2.249,2.249H14.867a2.251,2.251,0,0,0,2.249-2.249V49.147a.45.45,0,0,0-.45-.45Zm0,0"
                transform="translate(0 -37.422)"
              />
              <path
                class="a"
                id="Path_752"
                data-name="Path 752"
                d="M120.263.854a2.024,2.024,0,0,0-2.862,0l-8.023,8.023a.45.45,0,0,0-.115.2l-1.055,3.809a.45.45,0,0,0,.553.554l3.809-1.055a.45.45,0,0,0,.2-.115l8.023-8.024a2.026,2.026,0,0,0,0-2.862Zm-9.906,8.316L116.924,2.6l2.118,2.118-6.567,6.567Zm-.423.849,1.692,1.692-2.34.648Zm10.22-6.411-.477.477-2.118-2.118.477-.477a1.124,1.124,0,0,1,1.59,0l.528.528A1.126,1.126,0,0,1,120.154,3.607Zm0,0"
                transform="translate(-103.325 -0.261)"
              />
            </svg>
          </Tooltip>

          <div class="v-divider" v-if="notDelete == false"></div>

          <Tooltip placement="top" content="ลบข้อมูล" layout="row" layout-align="center center" v-if="notDelete == false">
            <svg
              class="btn-action"
              @click="removeRowData(row.Id)"
              id="Group_1034"
              data-name="Group 1034"
              xmlns="http://www.w3.org/2000/svg"
              width="15.939"
              height="17.967"
              viewBox="0 0 15.939 17.967"
            >
              <g id="Group_1033" data-name="Group 1033">
                <path
                  class="b"
                  id="Path_749"
                  data-name="Path 749"
                  d="M73.137,114.908H61.481a.461.461,0,0,0-.346.115.392.392,0,0,0-.115.346l1.2,10.434a2.28,2.28,0,0,0,2.28,2h5.8a2.28,2.28,0,0,0,2.3-2.073l.99-10.411a.392.392,0,0,0-.115-.3A.461.461,0,0,0,73.137,114.908Zm-1.451,10.78a1.336,1.336,0,0,1-1.382,1.2H64.5a1.313,1.313,0,0,1-1.359-1.175l-1.152-9.881H72.63Z"
                  transform="translate(-59.339 -109.84)"
                />
                <path
                  class="b"
                  id="Path_750"
                  data-name="Path 750"
                  d="M38.472,2.073H33.727V1.336A1.29,1.29,0,0,0,32.484,0H29.512A1.29,1.29,0,0,0,28.2,1.266q0,.035,0,.07v.737H23.454a.461.461,0,1,0,0,.921H38.472a.461.461,0,1,0,0-.921Zm-5.666-.737v.737H29.12V1.336a.368.368,0,0,1,.392-.415h2.9a.369.369,0,0,1,.394.342A.364.364,0,0,1,32.805,1.336Z"
                  transform="translate(-22.993 0)"
                />
              </g>
            </svg>
          </Tooltip>
        </div>
      </template>
    </Table>

    <div layout="row" style="margin-top:20px">
      <div class="total-only" flex="none">ทั้งหมด {{totalRecords}} รายการ</div>
      <div flex="auto">
        <Page
          style="float: right"
          :current="pageNumber"
          :total="totalPages"
          @on-change="changePage($event)"
          @on-page-size-change="changePageSize($event)"
          show-elevator
          show-sizer
        ></Page>
      </div>
    </div>

    <CustomModal :modalConfirm="modalConfirm" :useModalConfirm="true" />
  </div>
</template>

<script>
import mixinRefreshToken from '@/mixins/mixin-refreshToken'
import mixinNotice from '@/mixins/mixin-notice'
import CustomModal from '@/components/CustomModal'
import mixinCheckPermission from '@/mixins/mixin-checkPermission'

export default {
  props: {
    tableColumns: {
      required: true,
      type: Array
    },
    apiEndPoint: {
      required: true
    },
    pageType: {
      required: true
    },
    modeSearch: {
      required: true,
      default: false
    },
    notDelete: {
      default: false
    }
  },
  mixins: [mixinRefreshToken, mixinNotice, mixinCheckPermission],
  components: {
    CustomModal
  },
  data() {
    return {
      baseID: null,
      modalConfirm: false,
      loading: false,
      totalRecords: 0,
      totalPages: 1,
      pageSize: 10,
      pageNumber: 1,
      orderBy: '',
      orderAsc: false,
      resource: [],
      apiUrl: 'api/v1/',
      objSearchData: null
    }
  },
  computed: {},
  mounted() {
    this.getData()
  },
  methods: {
    async getData() {
      this.modeSearch = await false

      let apiWithQuery

      apiWithQuery = `${
        this.apiUrl +
        this.apiEndPoint +
        '?pageType=' +
        this.pageType +
        '&page=' +
        this.pageNumber +
        '&perPage=' +
        this.pageSize
      }`

      if (this.orderAsc && this.orderBy) {
        apiWithQuery = `${
          this.apiUrl +
          this.apiEndPoint +
          '?pageType=' +
          this.pageType +
          '&page=' +
          this.pageNumber +
          '&perPage=' +
          this.pageSize +
          '&orderAsc=' +
          this.orderAsc +
          '&orderBy=' +
          this.orderBy
        }`
      }

      console.log('apiWithQuery', apiWithQuery)

      let res = await this.$axios
        .$get(apiWithQuery, {
          headers: {
            'Access-Control-Allow-Origin': '*',
            Authorization: `Bearer ${this.accessToken}`
          }
        })
        .catch(function (error) {
          if (error.response) {
            console.log(error.response.status)
          }
        })

      console.log('getData()', res)

      if (res) {
        let { StatusCode, Resource, TotalRecords, TotalPages, PageSize, PageNumber, OrderBy, OrderAsc } = res

        Resource && (this.resource = await Resource)
        TotalRecords && (this.totalRecords = TotalRecords)
        PageSize && (this.pageSize = PageSize)
        TotalPages && (this.totalPages = (await TotalPages) * PageSize)
        PageNumber && (this.pageNumber = PageNumber)
        OrderBy && (this.orderBy = OrderBy)
        OrderAsc != undefined && (this.orderAsc = OrderAsc)
      }

      // console.log('getData()', res)

      if (res == undefined) {
        await this.reToken()
        await this.getData()
      }
    },
    async searchData(obj) {
      this.modeSearch = await true
      if (obj) {
        console.log('searchData()', obj);
        this.objSearchData = obj
      }
      let apiWithQuery

      if (this.modeSearch) {
        apiWithQuery = `${
          this.apiUrl +
          this.apiEndPoint +
          '/Search' +
          '?pageType=' +
          this.pageType +
          '&page=' +
          this.pageNumber +
          '&perPage=' +
          this.pageSize +
          '&orderAsc=' +
          this.orderAsc
        }`

        console.log('apiWithQuery', apiWithQuery)
        console.log('obj', obj || this.objSearchData)
      }

      let res = await this.$axios
        .$post(apiWithQuery, obj || this.objSearchData, {
          headers: {
            'Access-Control-Allow-Origin': '*',
            Authorization: `Bearer ${this.accessToken}`
          }
        })
        .catch(function (error) {
          if (error.response) {
            console.log(error.response.status)
          }
        })

      if (res) {
        let { StatusCode, Resource, TotalRecords, TotalPages, PageSize, PageNumber, OrderBy, OrderAsc } = res

        Resource && (this.resource = await Resource)
        TotalRecords && (this.totalRecords = TotalRecords)
        PageSize && (this.pageSize = PageSize)
        TotalPages && (this.totalPages = (await TotalPages) * PageSize)
        PageNumber && (this.pageNumber = PageNumber)
        OrderBy && (this.orderBy = OrderBy)
        OrderAsc != undefined && (this.orderAsc = OrderAsc)
      }

      console.log('searchData()', res)

      if (res == undefined) {
        await this.reToken()
        await this.searchData()
      }
    },
    async changeSort(event) {
      console.log('changeSort', event)
      this.orderBy = event.key
      if (event.order == 'asc') {
        this.orderAsc = true
      }
      if (event.order == 'desc') {
        this.orderAsc = false
      }

      if (this.modeSearch == false) {
        this.getData()
      }
      if (this.modeSearch == true) {
        this.searchData()
      }
    },
    async changePage(event) {
      console.log('changePage', event)
      this.pageNumber = event

      if (this.modeSearch == false) {
        this.getData()
      }
      if (this.modeSearch == true) {
        this.searchData()
      }
    },
    async changePageSize(event) {
      console.log('changePageSize', event)
      this.pageSize = event

      if (this.modeSearch == false) {
        this.getData()
      }
      if (this.modeSearch == true) {
        this.searchData()
      }
    },
    async editRowData(id) {
      if (this.$parent.ePermisson == false) {
        this.$parent.noticeWarning('คุณไม่ได้รับสิทธิ์ในการแก้ไขข้อมูล')
      }
      if (this.$parent.ePermisson == true) {
      }
      await this.$parent.editData(id)
      this.baseID = id
    },
    removeRowData(id) {
      if (this.$parent.dPermisson == false) {
        this.$parent.noticeWarning('คุณไม่ได้รับสิทธิ์ในการลบข้อมูล')
      }
      if (this.$parent.dPermisson == true) {
        this.modalConfirm = true
        this.baseID = id
      }
    },
    async submitModalConfirm() {
      let apiWithQuery = `${this.apiUrl + this.apiEndPoint + '/' + this.baseID + '?pageType=' + this.pageType}`

      console.log('apiWithQuery', apiWithQuery)

      let res = await this.$axios
        .$delete(apiWithQuery, {
          headers: {
            'Access-Control-Allow-Origin': '*',
            Authorization: `Bearer ${this.accessToken}`,
            'Content-Type': 'application/json'
          }
        })
        .catch(function (error) {
          if (error.response) {
            console.log(error.response.status)
          }
        })

      console.log('ลบข้อมูล ตำแหน่ง', res)

      let { StatusCode, Resource } = res

      if (StatusCode == 200) {
        console.log('remove position complete')
        this.$parent.componentKey += 1
        this.noticeSuccess('ลบข้อมูลสำเร็จ')
        this.modalConfirm = false
      }
      if (res == undefined) {
        await this.reToken()
      }
    },
    closeModalConfirm() {
      this.modalConfirm = false
    }
  }
}
</script>

<style lang="scss">
@function rem($size) {
  @return $size / 16px * 1rem;
}

.total-only {
  // color: $color_font-2;
  font-size: $fontSize-1;

  li {
    display: none;
  }
}
</style>