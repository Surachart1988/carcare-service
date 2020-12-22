<template>
  <div class="component-wrapper">
    <!-- <div>menuID {{menuID}}</div>
    <div>cPermisson {{cPermisson}}</div>
    <div>ePermisson {{ePermisson}}</div>
    <div>vPermisson {{vPermisson}}</div>
    <div>dPermisson {{dPermisson}}</div>
    <div>pPermisson {{pPermisson}}</div>-->

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
        :delete-subfix="true"
      ></SearchDataTable>
    </div>

    <HeaderPage :userAvatar="false" :buttonAdd="true" :divider="false">บริการครั้งถัดไปย่อย</HeaderPage>

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
        page-type="subnextservice"
        ref="dataTable"
        :mode-search="modeSearch"
      ></DataTable>

    <Modal v-model="modalAddData" :mask-closable="false" width="60%" @on-cancel="closeModalAdd()">
      <p slot="header">
        <span>เพิ่มข้อมูลบริการครั้งถัดไปย่อย</span>
      </p>
      <Form
        ref="formValidate"
        :model="formItem"
        :rules="ruleValidate"
        :label-width="320"
        layout="row" layout-wrap layout-align="center center"
      >
      <div layout="row" flex="100" flex-gt-lg="80">
        <FormItem prop="NextServiceID" :label="tableColumns1[1].title">
          <Select size="large" v-model="formItem.NextServiceID">
            <Option v-for="(e, index) in getDataNextService" :key="index" :value="e.Id">{{e.Name}}</Option>
          </Select>
        </FormItem>
        <FormItem prop="Name" :label="tableColumns1[2].title">
          <Input size="large" v-model="formItem.Name" placeholder></Input>
        </FormItem>
        <FormItem prop="CountMileage" :label="tableColumns1[3].title">
          <Input size="large" v-model="formItem.CountMileage" placeholder></Input>
        </FormItem>
        <FormItem prop="NextDaysCount" :label="tableColumns1[4].title">
          <Input size="large" v-model="formItem.NextDaysCount" placeholder></Input>
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
      componentKey: 0,

      formItem: {
        NextServiceID: "",
        Name: "",
        CountMileage: "",
        NextDaysCount: ""
      },
      getDataNextService: [],
      ruleValidate: {
        NextServiceID: [
          { type: 'number', required: true, message: "กรุณากรอกข้อมูล", trigger: "change" },
        ],
        Name: [
          { required: true, message: "กรุณากรอกข้อมูล", trigger: "blur" },
        ],
        CountMileage: [
          { required: true, message: "กรุณากรอกข้อมูล", trigger: "blur" },
        ],
        NextDaysCount: [
          { required: true, message: "กรุณากรอกข้อมูล", trigger: "blur" },
        ]
      },
      tableColumns1: [
        {
          title: 'ลำดับ',
          type: 'index',
          width: 120,
          align: 'center'
        },
        {
          title: "บริการครั้งถัดไป",
          key: "NextServiceID", //มาจากตารางอื่น
          align: "center",
          sortable: true,
        },
        {
          title: "บริการครั้งถัดไปย่อย",
          key: "name",
          align: "center",
          sortable: true,
        },
        {
          title: "จำนวนกิโลเมตรสำหรับบริการครั้งถัดไปย่อย",
          key: "countMileage",
          align: "center",
          sortable: true,
        },
        {
          title: "จำนวนวันสำหรับบริการครั้งถัดไปย่อย",
          key: "countDate",
          align: "center",
          sortable: true,
        },
        {
          title: "คำสั่ง",
          slot: "action",
          width: 150,
          align: "center",
        },
      ],
    };
  },
  computed: {},
  mounted() {
    this.checkPermission()
    this.nextserviceFromAPI()
  },
  methods: {
    async nextserviceFromAPI() {
      console.log('nextserviceFromAPI()')

      let apiWithQuery = 'api/v1/MasterData/nextservice'

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

      console.log('nextserviceFromAPI()', res)

      let { StatusCode, Resource } = await res

      if (StatusCode == 200) {
        this.getDataNextService = await Resource
      }

      if (res == undefined) {
        await this.reToken()
        await this.nextserviceFromAPI()
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
    },
    closeModalAdd() {
      this.modalAddData = false

      if (this.modeEdit) {
        this.clearFormItem()
      }
    },
    openModalEdit() {
      this.modalAddData = true

      if (this.modeEdit) {
      }
    },
    async editData(id) {
      this.itemID = id
      let apiWithQuery = `${'api/v1/MasterData/' + id + '?pageType=subnextservice'}`

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
        this.formItem.NextServiceID = Resource.NextServiceID
        this.formItem.Name = Resource.Name
        this.formItem.CountMileage = Resource.CountMileage
        this.formItem.NextDaysCount = Resource.NextDaysCount

        this.openModalEdit()
      }

      if (res == undefined) {
        await this.reToken()
        await this.editData(id)
      }
    },
    async saveData() {
      this.$refs.dataTable.loading = true
      let apiUrl = `api/v1/MasterData?pageType=subnextservice`
      let apiEditMode = `${'api/v1/MasterData' + '/' + this.itemID + '?pageType=subnextservice'}`

      if (this.modeEdit == false) {
        let res = await this.$axios
          .$post(
            `${apiUrl}`,
            {
              NextServiceID: this.formItem.NextServiceID,
              Name: this.formItem.Name,
              CountMileage: this.formItem.CountMileage,
              NextDaysCount: this.formItem.NextDaysCount
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
              NextServiceID: this.formItem.NextServiceID,
              Name: this.formItem.Name,
              CountMileage: this.formItem.CountMileage,
              NextDaysCount: this.formItem.NextDaysCount
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
      this.formItem.Name = null
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