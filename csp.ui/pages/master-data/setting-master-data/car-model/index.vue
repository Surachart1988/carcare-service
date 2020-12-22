<template>
  <div class="component-wrapper">
    <HeaderPage>
      กำหนดข้อมูลหลัก
      <!-- <template v-slot:subheader>
      xxx
      </template>-->
    </HeaderPage>

    <MasterDataMenu style="margin-top: -20px"></MasterDataMenu>

    <div layout="row" layout-align="center center">
      <SearchDataTable
        :columns="tableColumns1"
        searchbox-width="300px"
        select-width="200px"
        :delete-prefix="true"
        :delete-subfix="true"
      ></SearchDataTable>
    </div>

    <HeaderPage :userAvatar="false" :buttonAdd="true" :divider="false">รุ่นรถยนต์</HeaderPage>

    <div v-if="vPermisson == null">
      <content-placeholders :rounded="true">
        <content-placeholders-heading/>
        <content-placeholders-text :lines="4" />
      </content-placeholders>
    </div>
    <section v-if="vPermisson">
    <DataTable
        :key="componentKey"
        :table-columns="tableColumns1"
        api-end-point="MasterData"
        page-type="carmodel"
        ref="dataTable"
        :mode-search="modeSearch"
      ></DataTable>

    <Modal v-show="modalAddData" v-model="resloveSlowInput" :mask-closable="false" width="60%" @on-cancel="closeModalAdd()">
      <p slot="header">
        <span>เพิ่มข้อมูลรุ่นรถยนต์</span>
      </p>
      <Form
          ref="formValidate"
          :model="formItem"
          :rules="ruleValidate"
          :label-width="120"
          layout="row"
          layout-wrap
          layout-align="center center"
        >
        <div layout="row" layout-wrap flex="100" flex-gt-lg="80">
        <FormItem prop="CarBrandId" :label="tableColumns1[1].title" flex="100" flex-gt-md="50">
          <Select size="large" v-model="formItem.CarBrandId">
            <Option v-for="(e, index) in getDataCarBrand" :key="index" :value="e.Id">{{e.Name}}</Option>
          </Select>
        </FormItem>
        <FormItem prop="Name" :label="tableColumns1[2].title" flex="100" flex-gt-md="50">
          <Input size="large" v-model="formItem.Name" placeholder></Input>
        </FormItem>
        </div>
      </Form>
      
      <div slot="footer">
          <div layout="row" layout-align="center center">
            <Button
              type="primary"
              ghost
              shape="circle"
              size="large"
              @click="handleSubmit('formValidate')"
            >บันทึก</Button>
            <Button type="default" ghost shape="circle" size="large" @click="closeModalAdd()">ยกเลิก</Button>
          </div>
        </div>
    </Modal>
    </section>

    <CustomModal v-if="vPermisson == false" :useModalPermission="true" okButton="ยอมรับ" />
  </div>
</template>

<script>
import HeaderPage from '@/components/HeaderPage'
import MasterDataMenu from '@/components/MasterDataMenu'
import DataTable from '@/components/DataTable'
import SearchDataTable from '@/components/SearchDataTable'
import CustomModal from '@/components/CustomModal'

import mixinRefreshToken from '@/mixins/mixin-refreshToken'
import mixinNotice from '@/mixins/mixin-notice'
import mixinCheckPermission from '@/mixins/mixin-checkPermission'

export default {
  middleware: 'authenticated',
  components: {
    HeaderPage,
    MasterDataMenu,
    DataTable,
    SearchDataTable,
    CustomModal
  },
  mixins: [mixinRefreshToken, mixinNotice, mixinCheckPermission],
  data() {
    return {
      itemID: null,
      modeEdit: false,
      modeSearch: false,
      MasterPermisson: null,
      loading: false,
      modalAddData: false,
      resloveSlowInput: true,
      componentKey: 0,

      formItem: {
        CarBrandId: "",
        Name: "",
      },
      getDataCarBrand: [],
      ruleValidate: {
        CarBrandId: [
          { type: 'number', required: true, message: "กรุณากรอกข้อมูล", trigger: "change" },
        ],
        Name: [
          { required: true, message: "กรุณากรอกข้อมูล", trigger: "blur" },
        ],
      },
      tableColumns1: [
        {
          title: 'ลำดับ',
          type: 'index',
          width: 120,
          align: 'center'
        },
        {
          title: "ยี่ห้อรถยนต์",
          key: "CarBrandName", //มาจากตารางอื่น
          minWidth : 160,
          align: "center",
          sortable: true,
        },
        {
          title: "รุ่นรถยนต์",
          key: "Name",
          minWidth : 160,
          align: "center",
          sortable: true,
        },
        {
          title: "คำสั่ง",
          slot: "action",
          width: 150,
          fixed: 'right',
          align: "center",
        },
      ],
    };
  },
  computed: {},
  mounted() {
    this.checkPermission()
    this.carbrandFromAPI()
  },
  methods: {
    async carbrandFromAPI() {
      console.log('carbrandFromAPI()')

      let apiWithQuery = 'api/v1/MasterData/car/brand'

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

      console.log('carbrandFromAPI()', res)

      let { StatusCode, Resource } = await res

      if (StatusCode == 200) {
        this.getDataCarBrand = await Resource
        console.log('carbrandFromAPI()', this.getDataPosition)
      }

      if (res == undefined) {
        await this.reToken()
        await this.carbrandFromAPI()
      }
    },
    searchOnDatatable(obj) {
      this.modeSearch = true
      this.$refs.dataTable.searchData(obj)
    },
    clearOnDatatable() {
      this.modeSearch = false
      this.$refs.dataTable.getData()
    },
    openModalAdd() {
      this.modeEdit = false
      this.modalAddData = true
      this.resloveSlowInput = true
      if (this.getDataCarBrand == []) {
        this.carbrandFromAPI()
      }
    },
    closeModalAdd() {
      this.modalAddData = false
      this.resloveSlowInput = false

      if (this.modeEdit) {
        this.clearFormItem()
      }
    },
    openModalEdit() {
      this.modalAddData = true
      this.resloveSlowInput = true

      if (this.modeEdit) {
      }
    },
    async editData(id) {
      this.itemID = id
      let apiWithQuery = `${'api/v1/MasterData/' + id + '?pageType=carmodel'}`

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

      console.log('editData()', res)
      let { StatusCode, Resource } = await res

      if (StatusCode == 200) {
        this.modeEdit = true

        console.log('editData()', Resource)

        ;(this.formItem.CarBrandId = Resource.CarBrandId), (this.formItem.Name = Resource.Name)

        this.openModalEdit()
      }

      if (res == undefined) {
        await this.reToken()
        await this.editData(id)
      }
    },
    async saveData() {
      this.$refs.dataTable.loading = true
      let apiUrl = `api/v1/MasterData?pageType=carmodel`
      let apiEditMode = `${'api/v1/MasterData' + '/' + this.itemID + '?pageType=carmodel'}`

      if (this.modeEdit == false) {
        let res = await this.$axios
          .$post(
            `${apiUrl}`,
            {
              CarBrandId: this.formItem.CarBrandId,
              Name: this.formItem.Name
            },
            {
              headers: {
                'Access-Control-Allow-Origin': '*',
                Authorization: `Bearer ${this.accessToken}`
              }
            }
          )
          .catch(function (error) {
            if (error.response) {
              console.log(error.response.status)
            }
          })

        console.log('saveData()', res)

        if (res == undefined) {
          await this.reToken()
          await this.saveData()
        } else {
          if (res.StatusCode == 409) {
            this.noticeError('ข้อมูลนี้มีอยู่แล้วในระบบ')
          }

          if (res.StatusCode == 200) {
            this.componentKey += 1
            this.noticeSuccess('บันทึกสำเร็จ')
            this.closeModalAdd()
            this.clearFormItem()
          }
        }
      }

      if (this.modeEdit == true) {
        let res = await this.$axios
          .$put(
            `${apiEditMode}`,
            {
              CarBrandId: this.formItem.CarBrandId,
              Name: this.formItem.Name
            },
            {
              headers: {
                'Access-Control-Allow-Origin': '*',
                Authorization: `Bearer ${this.accessToken}`
              }
            }
          )
          .catch(function (error) {
            if (error.response) {
              console.log(error.response.status)
            }
          })

        console.log('saveData()', res)

        if (res == undefined) {
          await this.reToken()
          await this.saveData()
        } else {
          if (res.StatusCode == 409) {
            this.noticeError('ข้อมูลนี้มีอยู่แล้วในระบบ')
          }

          if (res.StatusCode == 200) {
            this.componentKey += 1
            this.noticeSuccess('บันทึกสำเร็จ')
            this.closeModalAdd()
            this.clearFormItem()
          }
        }
      }
    },
    async clearFormItem() {
      this.formItem.ProGroupID = null
      this.formItem.Code = null
      this.formItem.Name = ""
      this.formItem.CarBrandId = ""
      
    },
    handleSubmit(name) {
      this.$refs[name].validate(valid => {
        if (valid) {
          this.saveData()
        } else {
          this.$Message.error('มีบางอย่างผิดพลาด!')
        }
      })
    }
  }
}
</script>

<style lang="scss" scoped>
</style>