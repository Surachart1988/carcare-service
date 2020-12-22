<template>
  <div class="component-wrapper">
    <HeaderPage>
      ทะเบียนสินค้าชุด
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
        label="ค้นหา จากวันที่"
        flex-xs="100"
        flex-sm="100"
        flex-md="100"
        flex-gt-md="50"
      >
        <DatePicker
          size="large"
          type="date"
          placeholder="เลือกวันที่"
          v-model="formItem.field1"
        ></DatePicker>
      </FormItem>
      <FormItem
        label="ถึงวันที่"
        flex-xs="100"
        flex-sm="100"
        flex-md="100"
        flex-gt-md="50"
      >
        <DatePicker
          size="large"
          type="date"
          placeholder="เลือกวันที่"
          v-model="formItem.field2"
        ></DatePicker>
      </FormItem>
    </Form>

    <div layout="row" layout-align="center center">
      <SearchDataTable
        :select="formItem.select"
        :columns="tableColumns1"
        select-width="300px"
      ></SearchDataTable>
    </div>

    <HeaderPage :userAvatar="false" :buttonAdd="true" :divider="false">
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
        <span>เพิ่มทะเบียนสินค้าชุด</span>
      </p>

      <Form
        ref="inputForm"
        :model="formItem"
        :rules="ruleValidate"
        layout="row"
        layout-wrap
        :label-width="150"
        label-position="left"
      >
        
          <FormItem
            label="ชื่อรายการ"
            prop="field1"
            flex-xs="100"
            flex-sm="100"
            flex-md="100"
            flex-gt-md="30"
            flex-offset-gt-md="0"
          >
            <Input size="large" v-model="formItem.field1"></Input>
          </FormItem>

          <FormItem
            label="วันที่เริ่ม"
            prop="field2"
            flex-xs="100"
            flex-sm="100"
            flex-md="100"
            flex-gt-md="30"
            flex-offset-gt-md="5"
          >
            <DatePicker
              size="large"
              type="date"
              placeholder="เลือกวันที่"
              v-model="formItem.field2"
            ></DatePicker>
          </FormItem>

          <FormItem
            label="วันที่สิ้นสุด"
            prop="field3"
            flex-xs="100"
            flex-sm="100"
            flex-md="100"
            flex-gt-md="30"
            flex-offset-gt-md="5"
          >
            <DatePicker
              size="large"
              type="date"
              placeholder="เลือกวันที่"
              v-model="formItem.field3"
            ></DatePicker>
          </FormItem>
        
        <section layout="row" flex="100">
          <FormItem
            label="ราคาขายสินค้าชุด"
            prop="field4"
            flex-xs="100"
            flex-sm="100"
            flex-md="100"
            flex-gt-md="30"
            flex-offset-gt-md="0"
          >
            <Input disabled size="large" v-model="formItem.field4"></Input>
          </FormItem>
          </section>
          <section layout="row" flex="100">
            <FormItem
            label="การเข้าร่วมโปรโมชั่นการขาย"
            label-width="220"
            prop="field5"
            flex-xs="100"
            flex-sm="100"
            flex-md="100"
            flex-gt-md="60"
            flex-offset-gt-md="0"
          >
            <RadioGroup layout="row" size="large" v-model="formItem.field5">
              <Radio label="ไม่สามารถใช้ได้กับโปรโมชั่น">ไม่สามารถใช้ได้กับโปรโมชั่น</Radio>
              <Radio label="สามารถใช้ร่วมกับโปรโมชั่นอื่นได้">สามารถใช้ร่วมกับโปรโมชั่นอื่นได้</Radio>
            </RadioGroup>
          </FormItem>
          </section>
      </Form>

      <Divider class="main-divider" />

      <Form
        ref="inputForm2"
        :model="formItem"
        :rules="ruleValidate"
        layout="row"
        layout-wrap
        :label-width="130"
       
      >
        
          <FormItem
            label="ชื่อรายการ"
            prop="field6"
            flex-xs="100"
            flex-sm="100"
            flex-md="100"
            flex-gt-md="30"
            flex-offset-gt-md="0"
          >
            <Input
              disabled
              size="large"
              icon="ios-folder-open-outline"
              v-model="formItem.field6"
            ></Input>
          </FormItem>
          <FormItem
            label="ชื่อสินค้า"
            prop="field7"
            flex-xs="100"
            flex-sm="100"
            flex-md="100"
            flex-gt-md="30"
            flex-offset-gt-md="0"
          >
            <Input disabled size="large" v-model="formItem.field7"></Input>
          </FormItem>
          <FormItem
            label="จำนวน"
            prop="field8"
            flex-xs="100"
            flex-sm="100"
            flex-md="100"
            flex-gt-md="20"
            flex-offset-gt-md="0"
          >
            <Input size="large" v-model="formItem.field8"></Input>
          </FormItem>
          <FormItem
            label="ราคา/หน่วย"
            prop="field9"
            flex-xs="100"
            flex-sm="100"
            flex-md="100"
            flex-gt-md="20"
            flex-offset-gt-md="0"
          >
            <Input size="large" v-model="formItem.field9"></Input>
          </FormItem>
          <section layout="row" layout-align="end center" flex="100">
          <Button
            flex-xs="100"
            flex-sm="100"
            flex-md="100"
            flex-offset-gt-md="5"
            type="success"
            shape="circle"
            size="large"
            @click="handleSubmit('inputForm2')"
            ><Icon type="md-add" />เพิ่มรายการ</Button
          >
          </section>
      </Form>

      <Divider class="main-divider" />

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

      <div slot="footer">
        <div layout="row" layout-align="center center">
          <Button type="success" shape="circle" size="large" @click="handleSubmit('inputForm')"
            >บันทึก</Button
          >
          <Button type="error" shape="circle" size="large" @click
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
        field1: [{ required: true, message: "กรุณากรอกข้อมูล", trigger: "blur" }],
        field2: [{ required: true, message: "กรุณากรอกข้อมูล", trigger: "blur" }],
        field3: [{ required: true, message: "กรุณากรอกข้อมูล", trigger: "blur" }],
        // field4: [{ required: true, message: "กรุณากรอกข้อมูล", trigger: "blur" }],
        // field5: [{ required: true, message: "กรุณากรอกข้อมูล", trigger: "blur" }],
        field6: [{ required: true, message: "กรุณากรอกข้อมูล", trigger: "blur" }],
        field7: [{ required: true, message: "กรุณากรอกข้อมูล", trigger: "blur" }],
        field8: [{ required: true, message: "กรุณากรอกข้อมูล", trigger: "blur" }],
        field9: [{ required: true, message: "กรุณากรอกข้อมูล", trigger: "blur" }]
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
      tableData1: [],
      tableColumns1: [
        {
          title: "รหัสสินค้าชุด",
          key: "code",
          align: "center",
          sortable: true,
        },
        {
          title: "ชื่อสินค้าชุด",
          key: "name",
          align: "center",
          sortable: true,
        },
        {
          title: "วันที่เริ่ม",
          key: "nStartDate",
          align: "center",
          sortable: true,
        },
        {
          title: "วันที่สิ้นสุด",
          key: "nEndDate",
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
      tableColumns2: [
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
          title: "จำนวน",
          key: "quantity",
          align: "center",
          sortable: true,
        },
        {
          title: "ราคา/หน่วย",
          key: "price",
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
  computed: {
    apiUrl() {
      return `api/v1/set-product-registration?pageType=null&pageNumber=${this.dataCurrentPage}&pageSize=${this.dataPageSize}&orderAsc=${this.dataSortBy.order}&orderBy=${this.dataSortBy.key}`;
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
      this.$Modal.info({
        title: "User Info",
        content: `Name：${this.tableColumns1[index].name}<br>Age：${this.tableColumns1[index].age}<br>Address：${this.tableColumns1[index].address}`,
      });
    },
    handleSubmit(name) {
      this.$refs[name].validate((valid) => {
        if (valid) {
          this.$Message.success("Success!");
        } else {
          this.$Message.error("มีบางอย่างผิดพลาด!");
        }
      });
    }
  },
};
</script>

<style lang="scss" scoped>
</style>