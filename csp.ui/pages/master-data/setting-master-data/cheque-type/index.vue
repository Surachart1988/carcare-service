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
      <SearchDataTable
        :select="formItem.select"
        :columns="tableColumns1"
        select-width="300px"
      ></SearchDataTable>
    </div>

    <HeaderPage :userAvatar="false" :buttonAdd="true" :divider="false">ประเภทเช็ค</HeaderPage>

    <DataTable :tableColumns="tableColumns1" pageType="chequetype" searchField="" searchValue=""></DataTable>

    <Modal v-model="modalAddData" :mask-closable="false" width="480" @on-cancel="closeModalAdd()">
      <p slot="header">
        <span>เพิ่มข้อมูลประเภทเช็ค</span>
      </p>
      <Form
        ref="inputForm"
        :model="formItem"
        :rules="ruleValidate"
        :label-width="140"
        layout="row" layout-wrap layout-align="center center"
      >
      <div layout="row" flex="100" flex-gt-lg="80">
        <FormItem prop="field1" :label="tableColumns1[1].title">
          <Input size="large" v-model="formItem.field1" placeholder></Input>
        </FormItem>
        </div>
      </Form>
      <div slot="footer">
        <div layout="row" layout-align="center center">
          <Button type="primary" shape="circle" size="large" @click="handleSubmit('inputForm')">บันทึก</Button>
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
    MasterDataMenu,
    DataTable,
    SearchDataTable
  },
  data() {
    return {
      formItem: {
        field1: ''
      },
      ruleValidate: {
        field1: [
          { required: true, message: "กรุณากรอกข้อมูล", trigger: "blur" },
        ]
      },
      modalAddData: false,
      searchBox: '',
      tableColumns1: [
        {
          title: 'ลำดับ',
          type: 'index',
          width: 120,
          align: 'center'
        },
        {
          title: 'ประเภทเช็ค',
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
      this.$refs[name].validate((valid) => {
        if (valid) {
          this.saveData();
        } else {
          this.$Message.error("มีบางอย่างผิดพลาด!");
        }
      });
    },
    async saveData() {
      this.$refs.dataTable.loading = true
      let apiUrl = `api/v1/MasterData?pageType=chequetype`

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
        

      // console.log('saveData()', res)

      // if (res.Success) {
      //   this.closeModalAdd()
      // }
    }
  }
}
</script>

<style lang="scss" scoped>
</style>