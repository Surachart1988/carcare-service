<template>
  <div class="component-wrapper">
    <HeaderPage>
      กำหนดข้อมูลหลัก
      <!-- <template v-slot:subheader>
      xxx
      </template>-->
    </HeaderPage>

    <MasterDataMenu style="margin-top:-20px"></MasterDataMenu>

    <div layout="row" layout-align="center center">
      <SearchDataTable :select="formItem.select" :columns="tableColumns1" select-width="300px"></SearchDataTable>
    </div>

    <HeaderPage :userAvatar="false" :buttonAdd="true" :divider="false">หัวข้อการประเมิน</HeaderPage>

    <DataTable :tableColumns="tableColumns1" pageType="assessment" searchField searchValue></DataTable>

    <Modal v-model="modalAddData" :mask-closable="false" width="680" @on-cancel="closeModalAdd()">
      <p slot="header">
        <span>เพิ่มข้อมูลหัวข้อการประเมิน</span>
      </p>
      <Form
        :model="formItem"
        :label-width="150"
        layout="row"
        layout-wrap
        layout-align="center center"
      >
        <div layout="row" flex="100" flex-gt-lg="80">
          <FormItem label="ชื่อหัวข้อการประเมิน">
            <Input size="large" v-model="formItem.field1" placeholder></Input>
          </FormItem>

          <FormItem label="สถานะการใช้งาน" flex="100">
            <i-switch size="large" v-model="formItem.field2">
              <span slot="open">เปิดใช้งาน</span>
              <span slot="close">ปิดใช้งาน</span>
            </i-switch>
          </FormItem>

          <FormItem label="จำนวนตัวเลือก">
            <RadioGroup size="large" v-model="formItem.field3">
              <Radio label="5">5 ตัวเลือก</Radio>
              <Radio label="3">3 ตัวเลือก</Radio>
              <Radio label="2">2 ตัวเลือก</Radio>
            </RadioGroup>
          </FormItem>

          <FormItem label="ตัวเลือกที่ 5">
            <Input size="large" v-model="formItem.field4" placeholder></Input>
          </FormItem>

          <FormItem label="ตัวเลือกที่ 4">
            <Input size="large" v-model="formItem.field5" placeholder></Input>
          </FormItem>

          <FormItem label="ตัวเลือกที่ 3">
            <Input size="large" v-model="formItem.field6" placeholder></Input>
          </FormItem>

          <FormItem label="ตัวเลือกที่ 2">
            <Input size="large" v-model="formItem.field7" placeholder></Input>
          </FormItem>

          <FormItem label="ตัวเลือกที่ 1">
            <Input size="large" v-model="formItem.field8" placeholder></Input>
          </FormItem>
        </div>
      </Form>
      <div slot="footer">
        <div layout="row" layout-align="center center">
          <Button
            type="primary"
            shape="circle"
            size="large"
            @click="handleSubmit('inputForm')"
          >บันทึก</Button>
          <Button type="error" shape="circle" size="large" @click="closeModalAdd()">ยกเลิก</Button>
        </div>
      </div>
    </Modal>
  </div>
</template>

<script>
import HeaderPage from '@/components/HeaderPage'
import MasterDataMenu from '@/components/MasterDataMenu'
import DataTable from '@/components/DataTable'
import SearchDataTable from '@/components/SearchDataTable'
export default {
  components: {
    HeaderPage,
    DataTable,
    MasterDataMenu,
    SearchDataTable
  },
  data() {
    return {
      formItem: {
        field1: '',
        field2: ''
      },
      modalAddData: false,
      searchBox: '',
      tableColumns1: [
        {
          title: 'หัวข้อการประเมินความพึงพอใจลูกค้า',
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
  mounted() {},
  methods: {
    openModalAdd() {
      this.modalAddData = true
    },
    closeModalAdd() {
      this.modalAddData = false
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
      let apiUrl = `api/v1/MasterData?pageType=assessment`

      let res = await this.$axios
        .$post(
          `${apiUrl}`,
          {
            Name: this.formItem.field1
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
            console.log(error.response.data)
            console.log(error.response.status)
            console.log(error.response.headers)
          } else if (error.request) {
            console.log(error.request)
          } else {
            console.log('Error', error.message)
          }
          console.log(error.config)
        })

      console.log('saveData()', res)

      if (res.Success) {
        this.closeModalAdd()
      }
    }
  }
}
</script>

<style lang="scss" scoped>
</style>