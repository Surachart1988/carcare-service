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
        :delete-subfix="true"
      ></SearchDataTable>
    </div>

    <HeaderPage :userAvatar="false" :buttonAdd="true" :divider="false">ที่เก็บ DOT</HeaderPage>

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
        page-type="dot"
        ref="dataTable"
        :mode-search="modeSearch"
      ></DataTable>

    <Modal v-model="modalAddData" :mask-closable="false" width="60%" @on-cancel="closeModalAdd()">
      <!-- modeEdit {{modeEdit}} -->
      <!-- <button @click="debug()">debug</button> -->

      <p slot="header">
        <span>เพิ่มข้อมูลที่เก็บ DOT</span>
      </p>
      <Form
        ref="formValidate"
        :model="formItem"
        :rules="ruleValidate"
        :label-width="120"
      >
        <FormItem prop="Name" label="ปี DOT">
          <Select size="large" v-model="formItem.Name">
            <Option value="2015">2015</Option>
            <Option value="2016">2016</Option>
            <Option value="2017">2017</Option>
            <Option value="2018">2018</Option>
            <Option value="2019">2019</Option>
            <Option value="2020">2020</Option>
            <Option value="2021">2021</Option>
            <Option value="2022">2022</Option>
            <Option value="2023">2023</Option>
            <Option value="2024">2024</Option>
            <Option value="2025">2025</Option>
          </Select>
        </FormItem>
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
        Name: ''
      },
      ruleValidate: {
        Name: [
          { required: true, message: "กรุณากรอกข้อมูล", trigger: "change" },
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
          title: 'ที่เก็บ DOT',
          key: 'name',
          align: 'center',
          sortable: true
        },
        {
          title: 'คำสั่ง',
          slot: 'action',
          width: 150,
          align: 'center'
        }
      ]
    }
  },
  computed: {},
  mounted() {
    this.checkPermission()
  },
  methods: {
    debug() {
      let testData = {
        Name: +this.formItem.Name
      }
      console.log(testData)
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
      let apiWithQuery = `${'api/v1/MasterData/' + id + '?pageType=dot'}`

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

        this.formItem.Name = Resource.Name

        this.openModalEdit()
      }

      if (res == undefined) {
        await this.reToken()
        await this.editData(id)
      }
    },
    async saveData() {
      this.$refs.dataTable.loading = true
      let apiUrl = `api/v1/MasterData?pageType=dot`
      let apiEditMode = `${'api/v1/MasterData' + '/' + this.itemID + '?pageType=dot'}`

      if (this.modeEdit == false) {
        let res = await this.$axios
          .$post(
            `${apiUrl}`,
            {
              Name: '' + this.formItem.Name
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
              Name: '' + this.formItem.Name
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