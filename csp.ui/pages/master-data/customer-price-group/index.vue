<template>
  <div class="component-wrapper">
    <HeaderPage>
      กำหนดราคาต่อกลุ่มลูกค้า
      <!-- <template v-slot:subheader>
      xxx
      </template>-->
    </HeaderPage>

    <Form
      :model="formItem"
      :rules="ruleValidate"
      layout="row"
      layout-align="start center"
      :label-width="120"
      layout-wrap
    >
      <FormItem
        label="กลุ่มสินค้า"
        flex-xs="100"
        flex-sm="100"
        flex-md="100"
        flex-gt-md="33"
      >
        <Select
          clearable
          size="large"
          v-model="formItem.field1"
          placeholder="เลือกกลุ่มสินค้า"
        >
          <Option value="test01">test01</Option>
        </Select>
      </FormItem>
      <FormItem
        label="ประเภทสินค้า"
        flex="33"
        flex-xs="100"
        flex-sm="100"
        flex-md="100"
        flex-gt-md="33"
      >
        <Select
          clearable
          size="large"
          v-model="formItem.field2"
          placeholder="เลือกประเภทสินค้า"
        >
          <Option value="test01">test01</Option>
        </Select>
      </FormItem>
      <FormItem
        label="ยี่ห้อ"
        flex="33"
        flex-xs="100"
        flex-sm="100"
        flex-md="100"
        flex-gt-md="33"
      >
        <Select
          clearable
          size="large"
          v-model="formItem.field3"
          placeholder="เลือกยี่ห้อ"
        >
          <Option value="test01">test01</Option>
        </Select>
      </FormItem>
      <FormItem
        label="รุ่น"
        flex="33"
        flex-xs="100"
        flex-sm="100"
        flex-md="100"
        flex-gt-md="33"
      >
        <Select
          clearable
          size="large"
          v-model="formItem.field4"
          placeholder="เลือกรุ่น"
        >
          <Option value="test01">test01</Option>
        </Select>
      </FormItem>
      <FormItem
        label="ขนาดสินค้า"
        flex="33"
        flex-xs="100"
        flex-sm="100"
        flex-md="100"
        flex-gt-md="33"
      >
        <Select
          clearable
          size="large"
          v-model="formItem.field5"
          placeholder="เลือกขนาดสินค้า"
        >
          <Option value="test01">test01</Option>
        </Select>
      </FormItem>
      <FormItem
        label="สถานะสินค้า"
        flex="33"
        flex-xs="100"
        flex-sm="100"
        flex-md="100"
        flex-gt-md="33"
      >
        <Select
          clearable
          size="large"
          v-model="formItem.field6"
          placeholder="เลือกสถานะสินค้า"
        >
          <Option value="test01">test01</Option>
        </Select>
      </FormItem>
    </Form>

    <div layout="row" layout-align="center center">
      <SearchDataTable
        :select="formItem.select"
        :columns="tableColumns1"
        select-width="300px"
      ></SearchDataTable>
    </div>

    <HeaderPage :userAvatar="false" :buttonAdd="false" :divider="false">
      <!-- ทะเบียนลูกค้า -->
      <!-- <template v-slot:subheader>
      xxx
      </template>-->
    </HeaderPage>

    <Table
      stripe
      size="large"
      :columns="tableColumns1"
      :data="tableData1"
      :loading="loading"
      @on-sort-change="changeSort($event)"
    >
      <template slot-scope="{ row, index }" slot="action">
        <div layout="row" layout-align="center center">
          <Tooltip
            placement="top"
            content="แก้ไขข้อมูล"
            layout="row"
            layout-align="center center"
          >
            <svg
              class="btn-action"
              @click="editRowData(index)"
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
        </div>
      </template>
    </Table>

    <div style="margin: 10px; overflow: hidden">
      <div style="float: right">
        <Page
          :total="100"
          :current="1"
          @on-change="changePage($event)"
          @on-page-size-change="changePageSize($event)"
          show-elevator
          show-sizer
          show-total
        ></Page>
      </div>
    </div>

    <Modal
      class="fullsize-modal"
      v-model="modalAddData"
      :mask-closable="false"
      width="90%"
      @on-cancel="closeModalAdd()"
    >
      <p slot="header">
        <span>กำหนดราคาต่อกลุ่มลูกค้า</span>
      </p>

      <Form
        ref="inputForm"
        :model="formItem"
        :rules="ruleValidate"
        layout="row"
        layout-wrap
        :label-width="180"
      >
        <FormItem
          label="รหัสสินค้า"
          prop="field1"
          flex-xs="100"
          flex-sm="100"
          flex-md="100"
          flex-gt-md="33"
          flex-offset-gt-md="0"
        >
          <Input disabled size="large" v-model="formItem.field1"></Input>
        </FormItem>
        <FormItem
          label="ชื่อสินค้า"
          prop="field2"
          flex-xs="100"
          flex-sm="100"
          flex-md="100"
          flex-gt-md="33"
          flex-offset-gt-md="0"
        >
          <Input disabled size="large" v-model="formItem.field2"></Input>
        </FormItem>
        <FormItem
          label="ราคาปกติ"
          prop="field3"
          flex-xs="100"
          flex-sm="100"
          flex-md="100"
          flex-gt-md="33"
          flex-offset-gt-md="0"
        >
          <Input disabled size="large" v-model="formItem.field3"></Input>
        </FormItem>
        <FormItem
          label="กลุ่มลูกค้า"
          prop="field4"
          flex-xs="100"
          flex-sm="100"
          flex-md="100"
          flex-gt-md="33"
          flex-offset-gt-md="0"
        >
        <Select
          clearable
          size="large"
          v-model="formItem.field4"
          placeholder="เลือกกลุ่มลูกค้า"
        >
          <Option value="test01">test01</Option>
        </Select>
        </FormItem>
        <FormItem
          label="ชื่อลูกค้า"
          prop="field5"
          flex-xs="100"
          flex-sm="100"
          flex-md="100"
          flex-gt-md="33"
          flex-offset-gt-md="0"
        >
        <Select
          clearable
          size="large"
          v-model="formItem.field5"
          placeholder="เลือกชื่อลูกค้า"
        >
          <Option value="test01">test01</Option>
        </Select>
        </FormItem>
        <FormItem
          label="ราคาขาย"
          prop="field6"
          flex-xs="100"
          flex-sm="100"
          flex-md="100"
          flex-gt-md="33"
          flex-offset-gt-md="0"
        >
          <Input size="large" v-model="formItem.field6"></Input>
        </FormItem>
        <FormItem
          label="วันที่เริ่มมีผล"
          prop="field7"
          flex-xs="100"
          flex-sm="100"
          flex-md="100"
          flex-gt-md="33"
          flex-offset-gt-md="0"
        >
          <DatePicker
            size="large"
            type="date"
            placeholder="เลือกวันที่"
            v-model="formItem.field7"
          ></DatePicker>
        </FormItem>
        <FormItem
          label="วันที่สิ้นสุด"
          prop="field8"
          flex-xs="100"
          flex-sm="100"
          flex-md="100"
          flex-gt-md="33"
          flex-offset-gt-md="0"
        >
          <DatePicker
            size="large"
            type="date"
            placeholder="เลือกวันที่"
            v-model="formItem.field8"
          ></DatePicker>
        </FormItem>
        <FormItem
          label="ราคาขาย %"
          prop="field9"
          flex-xs="100"
          flex-sm="100"
          flex-md="100"
          flex-gt-md="33"
          flex-offset-gt-md="0"
        >
          <Input size="large" v-model="formItem.field9"></Input>
        </FormItem>
        <Divider class="main-divider" style="margin-bottom: 30px" />
      </Form>

      <Table
        stripe
        size="large"
        :columns="tableColumns2"
        :data="tableData2"
        :loading="loading"
        @on-sort-change="changeSort($event)"
      >
        <template slot-scope="{ row, index }" slot="action">
          <div layout="row" layout-align="center center">
            <Tooltip
              placement="top"
              content="แก้ไขข้อมูล"
              layout="row"
              layout-align="center center"
            >
              <svg
                class="btn-action"
                @click="editRowData2(index)"
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
          </div>
        </template>
      </Table>

      <div slot="footer">
        <div layout="row" layout-align="center center">
          <Button
            type="success"
            shape="circle"
            size="large"
            @click="handleSubmit('inputForm')"
            >บันทึก</Button
          >
          <Button
            type="error"
            shape="circle"
            size="large"
            @click="closeModalAdd()"
            >ยกเลิก</Button
          >
        </div>
      </div>
    </Modal>
  </div>
</template>

<script>
import HeaderPage from "@/components/HeaderPage";
import MasterDataMenu from "@/components/MasterDataMenu";
import SearchDataTable from "@/components/SearchDataTable";

export default {
  components: {
    HeaderPage,
    MasterDataMenu,
    SearchDataTable,
  },
  data() {
    return {
      ruleValidate: {
        field1: [{ message: 'กรุณากรอกข้อมูล', trigger: 'blur' }],
        field2: [{ message: 'กรุณากรอกข้อมูล', trigger: 'blur' }],
        field3: [{ message: 'กรุณากรอกข้อมูล', trigger: 'blur' }],
        field4: [{ required: true, message: 'กรุณากรอกข้อมูล', trigger: 'change' }],
        field5: [{ message: 'กรุณากรอกข้อมูล', trigger: 'change' }],
        field6: [{ required: true, message: 'กรุณากรอกข้อมูล', trigger: 'blur' }],
        field7: [{ required: true, type:"date", message: 'กรุณากรอกข้อมูล', trigger: 'change' }],
        field8: [{ required: true, type:"date", message: 'กรุณากรอกข้อมูล', trigger: 'change' }],
        field9: [{ message: 'กรุณากรอกข้อมูล', trigger: 'blur' }]
      },
      formItem: {
        field1: "",
        field2: "",
        field3: "",
        field4: "",
        field5: "",
        field6: "",
        field7: "",
        field8: "",
        field9: ""
      },
      modalAddData: false,
      searchBox: "",
      loading: false,
      dataTotal: 0,
      dataPageSize: 10,
      dataCurrentPage: 1,
      dataSortBy: {
        key: "",
        order: "",
      },
      // tableData1: [],
      tableData1: [
        {
          ID: '0',
          code: 'P001',
          name: 'ยาง',
          field1: 'บริการ',
          field2: 'Bridestone',
          field3: 'BB01',
          field4: 'ใหญ่มาก',
        }
      ],
      tableColumns1: [
        {
          title: "รหัสสินค้า",
          key: "code",
          align: "center",
          sortable: true,
        },
        {
          title: "ชื่อสินค้า",
          key: "name",
          align: "center",
          sortable: true,
        },
        {
          title: "ประเภทสินค้า",
          key: "field1",
          align: "center",
          sortable: true,
        },
        {
          title: "ยี่ห้อสินค้า",
          key: "field2",
          align: "center",
          sortable: true,
        },
        {
          title: "รุ่นสินค้า",
          key: "field3",
          align: "center",
          sortable: true,
        },
        {
          title: "ขนาดสินค้า",
          key: "field4",
          align: "center",
          sortable: true,
        },
        {
          title: "ปรับราคาต่อกลุ่มลูกค้า",
          slot: "action",
          width: 150,
          align: "center",
        },
      ],
      tableData2: [
        {
          ID: '0',
          code: 'เครดิต',
          name: 'ออฟ ปองศักดิ์',
          field1: '800',
          field2: '1,000',
          field3: '20/11/2020',
          field4: '24/12/2020',
        }
      ],
      tableColumns2: [
        {
          title: "กลุ่มลูกค้า",
          key: "code",
          align: "center",
          sortable: true,
        },
        {
          title: "ชื่อลูกค้า",
          key: "name",
          align: "center",
          sortable: true,
        },
        {
          title: "ราคาปกติ",
          key: "field1",
          align: "center",
          sortable: true,
        },
        {
          title: "ราคาขาย",
          key: "field2",
          align: "center",
          sortable: true,
        },
        {
          title: "วันที่เริ่มมีผล",
          key: "field3",
          align: "center",
          sortable: true,
        },
        {
          title: "วันที่สิ้นสุด",
          key: "field4",
          align: "center",
          sortable: true,
        },
        {
          title: "แก้ไข",
          slot: "action",
          width: 150,
          align: "center",
        },
      ],
    };
  },
  computed: {
    apiUrl() {
      return `api/v1/customer-price-group?pageType=null&pageNumber=${this.dataCurrentPage}&pageSize=${this.dataPageSize}&orderAsc=${this.dataSortBy.order}&orderBy=${this.dataSortBy.key}`;
    },
  },
  mounted() {
    this.getData();
  },
  methods: {
    async getData() {
      let res = await this.$axios.$get(`${this.apiUrl}`, {});
      this.tableData1 = res.resource;
      this.dataTotal = res.totalRecords;
      this.dataPageSize = res.pageSize;
      this.dataCurrentPage = res.pageNumber;
      this.dataSortBy.key = res.orderBy;
      this.dataSortBy.order = res.orderAsc;
      console.log("/api/v1/master/project", res);
    },
    async changeSort(event) {
      this.dataSortBy.key = event.key;
      this.dataSortBy.order = event.order;
      let res = await this.$axios.$get(`${this.apiUrl}`, {});
      this.tableData1 = res.resource;
      this.dataTotal = res.totalRecords;
      this.dataPageSize = res.pageSize;
      this.dataCurrentPage = res.pageNumber;
      console.log("changeSort", event);
    },
    async changePage(event) {
      this.dataCurrentPage = event;
      let res = await this.$axios.$get(`${this.apiUrl}`, {});
      this.tableData1 = res.resource;
      this.dataTotal = res.totalRecords;
      this.dataPageSize = res.pageSize;
      this.dataSortBy.key = res.orderBy;
      this.dataSortBy.order = res.orderAsc;
      console.log("changePage", event);
    },
    async changePageSize(event) {
      this.dataPageSize = event;
      let res = await this.$axios.$get(`${this.apiUrl}`, {});
      this.tableData1 = res.resource;
      this.dataTotal = res.totalRecords;
      this.dataCurrentPage = res.pageNumber;
      this.dataSortBy.key = res.orderBy;
      this.dataSortBy.order = res.orderAsc;
      console.log("changePageSize", event);
    },
    openModalAdd() {
      this.modalAddData = true;
    },
    closeModalAdd() {
      this.modalAddData = false;
    },
    editRowData(index) {
      this.modalAddData = true;
      // this.$Modal.info({
      //   title: "User Info",
      //   content: `Name：${this.tableColumns1[index].name}<br>Age：${this.tableColumns1[index].age}<br>Address：${this.tableColumns1[index].address}`,
      // });
    },
    editRowData2(index) {
      this.$Message.success("แก้ไข!");
    },
    handleSubmit(name) {
      this.$refs[name].validate((valid) => {
        if (valid) {
          this.$Message.success("Success!");
        } else {
          this.$Message.error("มีบางอย่างผิดพลาด!");
        }
      });
    },
  },
};
</script>

<style lang="scss" scoped>
</style>