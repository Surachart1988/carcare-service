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

    <MasterDataMenu style="margin-top:-20px"></MasterDataMenu>

    <div layout="row" layout-align="center center">
      <SearchDataTable
        :columns="tableColumns1"
        searchbox-width="300px"
        select-width="200px"
        :delete-prefix="true"
        :delete-subfix="true"
      ></SearchDataTable>
    </div>

    <HeaderPage :userAvatar="false" :buttonAdd="true" :divider="false">ตำแหน่งหน้าที่</HeaderPage>

    <div v-if="vPermisson == null">
      <content-placeholders :rounded="true">
        <content-placeholders-heading />
        <content-placeholders-text :lines="4" />
      </content-placeholders>
    </div>
    <section v-if="vPermisson">
      <DataTable
        :key="componentKey"
        :table-columns="tableColumns1"
        api-end-point="MasterData"
        page-type="position"
        ref="dataTable"
        :mode-search="modeSearch"
      ></DataTable>

      <Modal v-model="modalAddData" :mask-closable="false" width="90%" @on-cancel="closeModalAdd()">
        <p slot="header">
          <span>เพิ่มข้อมูลตำแหน่งหน้าที่</span>
        </p>
        <Form
          ref="formValidate"
          :model="formItem"
          :rules="ruleValidate"
          :label-width="120"
          layout="row"
          layout-align="center center"
        >
          <FormItem
            label="ตำแหน่งหน้าที่"
            flex-xs="100"
            flex-sm="80"
            flex-md="60"
            flex-lg="40"
            flex-gt-lg="30"
            prop="field1"
          >
            <Input size="large" v-model="formItem.field1" placeholder></Input>
          </FormItem>
        </Form>

        <Divider>กำหนดสิทธิ์การใช้งาน</Divider>
        <Collapse simple v-model="activeCollapse">
          <!-- <Panel name="1">
            ค้นหาข้อมูล
            <div slot="content">
              <Table
                stripe
                size="large"
                :columns="tableColumnsMenu1"
                :data="tableDataMenu1"
                :loading="loading"
              ></Table>
            </div>
          </Panel> -->
          <Panel name="2">
            ขาย
            <div slot="content">
              <Table
                stripe
                size="large"
                :columns="tableColumnsMenu2"
                :data="tableDataMenu2"
                :loading="loading"
              ></Table>
            </div>
          </Panel>
          <!-- <Panel name="3">
            จัดซื้อ
            <div slot="content">
              <Table
                stripe
                size="large"
                :columns="tableColumnsMenu3"
                :data="tableDataMenu3"
                :loading="loading"
              ></Table>
            </div>
          </Panel> -->
          <!-- <Panel name="4">
            คลังสินค้า
            <div slot="content">
              <Table
                stripe
                size="large"
                :columns="tableColumnsMenu4"
                :data="tableDataMenu4"
                :loading="loading"
              ></Table>
            </div>
          </Panel> -->
          <!-- <Panel name="5">
            ค่าใช้จ่าย/วัสดุสิ้นเปลือง
            <div slot="content">
              <Table
                stripe
                size="large"
                :columns="tableColumnsMenu5"
                :data="tableDataMenu5"
                :loading="loading"
              ></Table>
            </div>
          </Panel> -->
          <!-- <Panel name="6">
            ใบหักภาษี ณ ที่จ่าย
            <div slot="content">
              <Table
                stripe
                size="large"
                :columns="tableColumnsMenu6"
                :data="tableDataMenu6"
                :loading="loading"
              ></Table>
            </div>
          </Panel> -->
          <Panel name="7">
            ข้อมูลหลัก
            <div slot="content">
              <Table
                stripe
                size="large"
                :columns="tableColumnsMenu7"
                :data="tableDataMenu7"
                :loading="loading"
              ></Table>
            </div>
          </Panel>
          <!-- <Panel name="8">
            ตารางนัดหมาย
            <div slot="content">
              <Table
                stripe
                size="large"
                :columns="tableColumnsMenu8"
                :data="tableDataMenu8"
                :loading="loading"
              ></Table>
            </div>
          </Panel> -->
          <!-- <Panel name="9">
            ลูกค้าสัมพันธ์/โปรแกรมพิเศษ
            <div slot="content">
              <Table
                stripe
                size="large"
                :columns="tableColumnsMenu9"
                :data="tableDataMenu9"
                :loading="loading"
              ></Table>
            </div>
          </Panel> -->
          <!-- <Panel name="10">
            รับ-จ่ายเงินสด/ปิดสิ้นวัน
            <div slot="content">
              <Table
                stripe
                size="large"
                :columns="tableColumnsMenu10"
                :data="tableDataMenu10"
                :loading="loading"
              ></Table>
            </div>
          </Panel> -->
          <!-- <Panel name="11">
            การจัดการเจ้าหนี้
            <div slot="content">
              <Table
                stripe
                size="large"
                :columns="tableColumnsMenu11"
                :data="tableDataMenu11"
                :loading="loading"
              ></Table>
            </div>
          </Panel> -->
          <!-- <Panel name="12">
            การจัดการลูกหนี้
            <div slot="content">
              <Table
                stripe
                size="large"
                :columns="tableColumnsMenu12"
                :data="tableDataMenu12"
                :loading="loading"
              ></Table>
            </div>
          </Panel> -->
          <!-- <Panel name="13">
            เช็คธนาคาร
            <div slot="content">
              <Table
                stripe
                size="large"
                :columns="tableColumnsMenu13"
                :data="tableDataMenu13"
                :loading="loading"
              ></Table>
            </div>
          </Panel> -->
          <Panel name="14">
            รายงาน
            <div slot="content">
              <Table
                stripe
                size="large"
                :columns="tableColumnsMenu14"
                :data="tableDataMenu14"
                :loading="loading"
              ></Table>
            </div>
          </Panel>
          <Panel name="15">
            ข้อมูลระบบ
            <div slot="content">
              <Table
                stripe
                size="large"
                :columns="tableColumnsMenu15"
                :data="tableDataMenu15"
                :loading="loading"
              ></Table>
            </div>
          </Panel>
        </Collapse>

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

import mixinTableMenu1 from '@/mixins/page-permission/mixin-tableMenu1'
import mixinTableMenu2 from '@/mixins/page-permission/mixin-tableMenu2'
import mixinTableMenu3 from '@/mixins/page-permission/mixin-tableMenu3'
import mixinTableMenu4 from '@/mixins/page-permission/mixin-tableMenu4'
import mixinTableMenu5 from '@/mixins/page-permission/mixin-tableMenu5'
import mixinTableMenu6 from '@/mixins/page-permission/mixin-tableMenu6'
import mixinTableMenu7 from '@/mixins/page-permission/mixin-tableMenu7'
import mixinTableMenu8 from '@/mixins/page-permission/mixin-tableMenu8'
import mixinTableMenu9 from '@/mixins/page-permission/mixin-tableMenu9'
import mixinTableMenu10 from '@/mixins/page-permission/mixin-tableMenu10'
import mixinTableMenu11 from '@/mixins/page-permission/mixin-tableMenu11'
import mixinTableMenu12 from '@/mixins/page-permission/mixin-tableMenu12'
import mixinTableMenu13 from '@/mixins/page-permission/mixin-tableMenu13'
import mixinTableMenu14 from '@/mixins/page-permission/mixin-tableMenu14'
import mixinTableMenu15 from '@/mixins/page-permission/mixin-tableMenu15'

import mixinEditMenu1 from '@/mixins/page-permission/mixin-editMenu1'
import mixinEditMenu2 from '@/mixins/page-permission/mixin-editMenu2'
import mixinEditMenu3 from '@/mixins/page-permission/mixin-editMenu3'
import mixinEditMenu4 from '@/mixins/page-permission/mixin-editMenu4'
import mixinEditMenu5 from '@/mixins/page-permission/mixin-editMenu5'
import mixinEditMenu6 from '@/mixins/page-permission/mixin-editMenu6'
import mixinEditMenu7 from '@/mixins/page-permission/mixin-editMenu7'
import mixinEditMenu8 from '@/mixins/page-permission/mixin-editMenu8'
import mixinEditMenu9 from '@/mixins/page-permission/mixin-editMenu9'
import mixinEditMenu10 from '@/mixins/page-permission/mixin-editMenu10'
import mixinEditMenu11 from '@/mixins/page-permission/mixin-editMenu11'
import mixinEditMenu12 from '@/mixins/page-permission/mixin-editMenu12'
import mixinEditMenu13 from '@/mixins/page-permission/mixin-editMenu13'
import mixinEditMenu14 from '@/mixins/page-permission/mixin-editMenu14'
import mixinEditMenu15 from '@/mixins/page-permission/mixin-editMenu15'

import mixinCrudpMenu from '@/mixins/page-permission/mixin-crudpMenu'
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
  mixins: [
    mixinRefreshToken,
    mixinNotice,
    mixinTableMenu1,
    mixinTableMenu2,
    mixinTableMenu3,
    mixinTableMenu4,
    mixinTableMenu5,
    mixinTableMenu6,
    mixinTableMenu7,
    mixinTableMenu8,
    mixinTableMenu9,
    mixinTableMenu10,
    mixinTableMenu11,
    mixinTableMenu12,
    mixinTableMenu13,
    mixinTableMenu14,
    mixinTableMenu15,
    mixinEditMenu1,
    mixinEditMenu2,
    mixinEditMenu3,
    mixinEditMenu4,
    mixinEditMenu5,
    mixinEditMenu6,
    mixinEditMenu7,
    mixinEditMenu8,
    mixinEditMenu9,
    mixinEditMenu10,
    mixinEditMenu11,
    mixinEditMenu12,
    mixinEditMenu13,
    mixinEditMenu14,
    mixinEditMenu15,
    mixinCrudpMenu,
    mixinCheckPermission
  ],
  data() {
    return {
      positionID: null,
      modeEdit: false,
      modeSearch: false,
      MasterPermisson: null,
      loading: false,
      modalAddData: false,
      componentKey: 0,

      activeCollapse: ['1', '2', '3', '4', '5', '6', '7', '8', '9', '10', '11', '12', '13', '14', '15'],
      formItem: {
        field1: '',
        field2: ''
      },
      ruleValidate: {
        field1: { required: true, message: 'กรุณากรอกข้อมูล', trigger: 'blur' }
      },
      tableColumns1: [
        {
          title: 'ลำดับที่',
          align: 'center',
          type: 'index',
          width: 200
        },
        {
          title: 'ตำแหน่งหน้าที่',
          key: 'Name',
          minWidth : 160,
          align: 'center',
          sortable: true
        },
        {
          title: 'คำสั่ง',
          slot: 'action',
          width: 150,
          fixed: 'right',
          align: 'center'
        }
      ],
      permissionCol: {
        title: 'สิทธิ์การใช้งาน',
        create: 'สร้างข้อมูล',
        edit: 'แก้ไขข้อมูล',
        view: 'ดูข้อมูล',
        delete: 'ลบข้อมูล',
        print: 'พิมพ์ข้อมูล'
      },

      tableDataMenu1: this.mockTableDataMenu1(),
      tableColumnsMenu1: [],
      tableDataMenu2: this.mockTableDataMenu2(),
      tableColumnsMenu2: [],
      tableDataMenu3: this.mockTableDataMenu3(),
      tableColumnsMenu3: [],
      tableDataMenu4: this.mockTableDataMenu4(),
      tableColumnsMenu4: [],
      tableDataMenu5: this.mockTableDataMenu5(),
      tableColumnsMenu5: [],
      tableDataMenu6: this.mockTableDataMenu6(),
      tableColumnsMenu6: [],
      tableDataMenu7: this.mockTableDataMenu7(),
      tableColumnsMenu7: [],
      tableDataMenu8: this.mockTableDataMenu8(),
      tableColumnsMenu8: [],
      tableDataMenu9: this.mockTableDataMenu9(),
      tableColumnsMenu9: [],
      tableDataMenu10: this.mockTableDataMenu10(),
      tableColumnsMenu10: [],
      tableDataMenu11: this.mockTableDataMenu11(),
      tableColumnsMenu11: [],
      tableDataMenu12: this.mockTableDataMenu12(),
      tableColumnsMenu12: [],
      tableDataMenu13: this.mockTableDataMenu13(),
      tableColumnsMenu13: [],
      tableDataMenu14: this.mockTableDataMenu14(),
      tableColumnsMenu14: [],
      tableDataMenu15: this.mockTableDataMenu15(),
      tableColumnsMenu15: [],

      dummyMasterPermisson: []
    }
  },
  computed: {},
  mounted() {
    this.checkPermission()
  },
  methods: {
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

      //reser data
      this.formItem.field1 = null
      this.tableDataMenu1 = this.mockTableDataMenu1()
      this.tableDataMenu2 = this.mockTableDataMenu2()
      this.tableDataMenu3 = this.mockTableDataMenu3()
      this.tableDataMenu4 = this.mockTableDataMenu4()
      this.tableDataMenu5 = this.mockTableDataMenu5()
      this.tableDataMenu6 = this.mockTableDataMenu6()
      this.tableDataMenu7 = this.mockTableDataMenu7()
      this.tableDataMenu8 = this.mockTableDataMenu8()
      this.tableDataMenu9 = this.mockTableDataMenu9()
      this.tableDataMenu10 = this.mockTableDataMenu10()
      this.tableDataMenu11 = this.mockTableDataMenu11()
      this.tableDataMenu12 = this.mockTableDataMenu12()
      this.tableDataMenu13 = this.mockTableDataMenu13()
      this.tableDataMenu14 = this.mockTableDataMenu14()
      this.tableDataMenu15 = this.mockTableDataMenu15()

      //map data
      this.tableColumnsMenu1 = this.mockTableColumnsMenu1()
      this.tableColumnsMenu2 = this.mockTableColumnsMenu2()
      this.tableColumnsMenu3 = this.mockTableColumnsMenu3()
      this.tableColumnsMenu4 = this.mockTableColumnsMenu4()
      this.tableColumnsMenu5 = this.mockTableColumnsMenu5()
      this.tableColumnsMenu6 = this.mockTableColumnsMenu6()
      this.tableColumnsMenu7 = this.mockTableColumnsMenu7()
      this.tableColumnsMenu8 = this.mockTableColumnsMenu8()
      this.tableColumnsMenu9 = this.mockTableColumnsMenu9()
      this.tableColumnsMenu10 = this.mockTableColumnsMenu10()
      this.tableColumnsMenu11 = this.mockTableColumnsMenu11()
      this.tableColumnsMenu12 = this.mockTableColumnsMenu12()
      this.tableColumnsMenu13 = this.mockTableColumnsMenu13()
      this.tableColumnsMenu14 = this.mockTableColumnsMenu14()
      this.tableColumnsMenu15 = this.mockTableColumnsMenu15()
    },
    closeModalAdd() {
      this.modalAddData = false
    },
    openModalEdit() {
      this.modalAddData = true
      this.tableColumnsMenu1 = this.mockTableColumnsMenu1()
      this.tableColumnsMenu2 = this.mockTableColumnsMenu2()
      this.tableColumnsMenu3 = this.mockTableColumnsMenu3()
      this.tableColumnsMenu4 = this.mockTableColumnsMenu4()
      this.tableColumnsMenu5 = this.mockTableColumnsMenu5()
      this.tableColumnsMenu6 = this.mockTableColumnsMenu6()
      this.tableColumnsMenu7 = this.mockTableColumnsMenu7()
      this.tableColumnsMenu8 = this.mockTableColumnsMenu8()
      this.tableColumnsMenu9 = this.mockTableColumnsMenu9()
      this.tableColumnsMenu10 = this.mockTableColumnsMenu10()
      this.tableColumnsMenu11 = this.mockTableColumnsMenu11()
      this.tableColumnsMenu12 = this.mockTableColumnsMenu12()
      this.tableColumnsMenu13 = this.mockTableColumnsMenu13()
      this.tableColumnsMenu14 = this.mockTableColumnsMenu14()
      this.tableColumnsMenu15 = this.mockTableColumnsMenu15()
    },
    async editData(id) {
      this.positionID = id
      let apiWithQuery = `${'api/v1/MasterData/' + id + '?pageType=position'}`

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
      let { StatusCode, Resource } = res

      if (StatusCode == 200) {
        this.modeEdit = true
        this.MasterPermisson = await Resource.MasterPermisson
        this.formItem.field1 = Resource.Name
        this.tableDataMenu1 = this.mockTableDataMenu1()
        this.tableDataMenu2 = this.mockTableDataMenu2()
        this.tableDataMenu3 = this.mockTableDataMenu3()
        this.tableDataMenu4 = this.mockTableDataMenu4()
        this.tableDataMenu5 = this.mockTableDataMenu5()
        this.tableDataMenu6 = this.mockTableDataMenu6()
        this.tableDataMenu7 = this.mockTableDataMenu7()
        this.tableDataMenu8 = this.mockTableDataMenu8()
        this.tableDataMenu9 = this.mockTableDataMenu9()
        this.tableDataMenu10 = this.mockTableDataMenu10()
        this.tableDataMenu11 = this.mockTableDataMenu11()
        this.tableDataMenu12 = this.mockTableDataMenu12()
        this.tableDataMenu13 = this.mockTableDataMenu13()
        this.tableDataMenu14 = this.mockTableDataMenu14()
        this.tableDataMenu15 = this.mockTableDataMenu15()
        this.openModalEdit()
      }

      if (res == undefined) {
        await this.reToken()
        await this.editData(id)
      }
    },
    handleSubmit(name) {
      this.$refs[name].validate(valid => {
        if (valid) {
          this.saveData()
        } else {
          this.$Message.error('มีบางอย่างผิดพลาด!')
        }
      })
    },
    async saveData() {
      this.$refs.dataTable.loading = true
      let apiUrl = `api/v1/MasterData?pageType=position`
      let apiEditMode = `${'api/v1/MasterData' + '/' + this.positionID + '?pageType=position'}`

      this.editTableDataMenu1(this.positionID)
      this.editTableDataMenu2(this.positionID)
      this.editTableDataMenu3(this.positionID)
      this.editTableDataMenu4(this.positionID)
      this.editTableDataMenu5(this.positionID)
      this.editTableDataMenu6(this.positionID)
      this.editTableDataMenu7(this.positionID)
      this.editTableDataMenu8(this.positionID)
      this.editTableDataMenu9(this.positionID)
      this.editTableDataMenu10(this.positionID)
      this.editTableDataMenu11(this.positionID)
      this.editTableDataMenu12(this.positionID)
      this.editTableDataMenu13(this.positionID)
      this.editTableDataMenu14(this.positionID)
      this.editTableDataMenu15(this.positionID)

      if (this.modeEdit == false) {
        let res = await this.$axios
          .$post(
            `${apiUrl}`,
            {
              Name: this.formItem.field1,
              MasterPermisson: this.dummyMasterPermisson
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
          }
        }
      }

      if (this.modeEdit == true) {
        let res = await this.$axios
          .$put(
            `${apiEditMode}`,
            {
              Name: this.formItem.field1,
              MasterPermisson: this.dummyMasterPermisson
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
          }
        }
      }
    }
  }
}
</script>

<style lang="scss">
.ivu-icon-md-checkmark-circle {
  position: relative;
  width: 32px;
  height: 32px;
}
.ivu-icon-md-checkmark-circle::before {
  position: absolute;
  top: -4px;
  left: -4px;
}
</style>
