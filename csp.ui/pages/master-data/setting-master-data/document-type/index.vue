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

    <HeaderPage :userAvatar="false" :buttonAdd="false" :divider="false">ข้อมูลเอกสาร แสดงข้อมูลเอกสารที่มีอยู่</HeaderPage>

    <DataTable :tableColumns="tableColumns1" pageType="documenttype" searchField="" searchValue=""></DataTable>

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
      searchBox: '',
      tableColumns1: [
        {
          title: 'คำอธิบาย',
          key: 'name',
          align: 'center',
          sortable: true
        },
         {
          title: 'รหัสเอกสาร',
          key: 'fcode',
          align: 'center',
          sortable: true
        },
        {
          title: 'เลขที่เอกสาร',
          key: 'code',
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
    }
  }
}
</script>

<style lang="scss" scoped>
</style>