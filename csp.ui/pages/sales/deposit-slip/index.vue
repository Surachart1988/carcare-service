<template>
  <div class="component-wrapper">
    <HeaderPage>
      ใบรับมัดจำ
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
      <template slot-scope="{ row, index }" slot="add">
        <Button :size="buttonSize" icon="md-add" shape="circle"></Button>
      </template>

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

          <div class="v-divider"></div>

          <Tooltip
            placement="top"
            content="ลบข้อมูล"
            layout="row"
            layout-align="center center"
          >
            <svg
              class="btn-action"
              @click="removeRowData(index)"
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
        <span>สร้างใบรับมัดจำ</span>
      </p>

      <Form
        ref="inputForm"
        :model="formItem"
        :rules="ruleValidate"
        layout="row"
        layout-wrap
        :label-width="170"
      >
        <FormItem
          label="ทะเบียนรถ จังหวัด"
          prop="field1"
          flex-xs="100"
          flex-sm="100"
          flex-md="100"
          flex-gt-md="33"
          flex-offset-gt-md="0"
        >
          <Input
            disabled
            size="large"
            v-model="formItem.field1"
            icon="ios-folder-open-outline"
          ></Input>
        </FormItem>
        <FormItem
          label="ยี่ห้อ"
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
          label="รุ่น"
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
          label="ชื่อ - สกุล"
          prop="field4"
          flex-xs="100"
          flex-sm="100"
          flex-md="100"
          flex-gt-md="33"
          flex-offset-gt-md="0"
        >
          <Input
            disabled
            size="large"
            v-model="formItem.field4"
            icon="ios-folder-open-outline"
          ></Input>
        </FormItem>
        <FormItem
          label="กลุ่มลูกค้า"
          prop="field5"
          flex-xs="100"
          flex-sm="100"
          flex-md="100"
          flex-gt-md="33"
          flex-offset-gt-md="0"
        >
          <Input disabled size="large" v-model="formItem.field5"></Input>
        </FormItem>
        <FormItem
          label="ประเภทภาษี"
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
          label="เอกสารอ้างอิง"
          prop="field7"
          flex-xs="100"
          flex-sm="100"
          flex-md="100"
          flex-gt-md="33"
          flex-offset-gt-md="0"
        >
          <Input size="large" v-model="formItem.field7"></Input>
        </FormItem>
        <FormItem
          label="วันที่อ้างอิง"
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
          label="อัตราภาษี (%)"
          prop="field9"
          flex-xs="100"
          flex-sm="100"
          flex-md="100"
          flex-gt-md="33"
          flex-offset-gt-md="0"
        >
          <Input disabled size="large" v-model="formItem.field9"></Input>
        </FormItem>

        <Divider class="main-divider" />

        <Modal
          class="fullsize-modal"
          v-model="modalAddDataList"
          :mask-closable="false"
          width="90%"
          @on-cancel="closeModalAddList()"
        >
          <p slot="header">
            <span>เพิ่มรายการ</span>
          </p>
          <Form
            ref="inputForm2"
            :model="formItemModalList"
            :rules="ruleValidateModalList"
            :label-width="150"
            layout="row"
            layout-wrap
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
              <Input
                size="large"
                v-model="formItemModalList.field1"
                icon="ios-folder-open-outline"
              ></Input>
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
              <Input
                disabled
                size="large"
                v-model="formItemModalList.field2"
              ></Input>
            </FormItem>
            <FormItem
              label="ราคา"
              prop="field3"
              flex-xs="100"
              flex-sm="100"
              flex-md="100"
              flex-gt-md="33"
              flex-offset-gt-md="0"
            >
              <Input disabled size="large" v-model="formItemModalList.field3"></Input>
            </FormItem>
            <FormItem
              label="จำนวน"
              prop="field4"
              flex-xs="100"
              flex-sm="100"
              flex-md="100"
              flex-gt-md="33"
              flex-offset-gt-md="0"
            >
              <Input size="large" v-model="formItemModalList.field4"></Input>
            </FormItem>
            <FormItem
              label="ยอดเงินรวม"
              prop="field5"
              flex-xs="100"
              flex-sm="100"
              flex-md="100"
              flex-gt-md="33"
              flex-offset-gt-md="0"
            >
              <Input disabled size="large" v-model="formItemModalList.field5"></Input>
            </FormItem>
            <FormItem
              label="มัดจำ(บาท)"
              prop="field6"
              flex-xs="100"
              flex-sm="100"
              flex-md="100"
              flex-gt-md="33"
              flex-offset-gt-md="0"
            >
              <Input disabled size="large" v-model="formItemModalList.field6"></Input>
            </FormItem>
            <FormItem
              label="มัดจำ(%)"
              prop="field7"
              flex-xs="100"
              flex-sm="100"
              flex-md="100"
              flex-gt-md="33"
              flex-offset-gt-md="0"
            >
              <Input disabled size="large" v-model="formItemModalList.field7"></Input>
            </FormItem>
          </Form>
          <div slot="footer">
            <div layout="row" layout-align="center center">
              <Button
                type="success"
                shape="circle"
                size="large"
                @click="handleSubmit('inputForm2')"
                >บันทึก</Button
              >
              <Button
                type="error"
                shape="circle"
                size="large"
                @click="closeModalAddList()"
                >ยกเลิก</Button
              >
            </div>
          </div>
        </Modal>
        <section
          layout="row"
          layout-align="end"
          flex="100"
          style="padding-bottom: 20px"
        >
          <Button
            flex-xs="100"
            flex-sm="100"
            flex-md="100"
            type="success"
            shape="circle"
            size="large"
            @click="openModalAddList()"
            ><Icon type="md-add" />เพิ่มรายการ</Button
          >
        </section>
        <Table
          stripe
          size="large"
          :columns="tableColumns2"
          :data="tableData2"
          :loading="loading"
          @on-sort-change="changeSort($event)"
        >
          <template slot-scope="{ row, index }" slot="closeBox">
            <Checkbox></Checkbox>
          </template>

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

              <div class="v-divider"></div>

              <Tooltip
                placement="top"
                content="ลบข้อมูล"
                layout="row"
                layout-align="center center"
              >
                <svg
                  class="btn-action"
                  @click="removeRowData(index)"
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
        <section layout="row" style="margin-top: 30px" flex="100">
          <section flex="50">
            <FormItem label="หมายเหตุ" prop="field13">
              <Input
                type="textarea"
                :autosize="{ minRows: 5, maxRows: 10 }"
                size="large"
                v-model="formItem.field13"
              ></Input>
            </FormItem>
          </section>
          <section flex="45">
            <FormItem label="รวมเงิน" prop="field14">
              <Input disabled size="large" v-model="formItem.field14"
                ><span slot="append">บาท</span></Input
              >
            </FormItem>
            <FormItem label="ภาษีมูลค่าเพิ่ม" prop="field15">
              <Input disabled size="large" v-model="formItem.field15"
                ><span slot="append">บาท</span></Input
              >
            </FormItem>
            <FormItem label="ยอดรวมสุทธิ" prop="field16">
              <Input disabled size="large" v-model="formItem.field16"
                ><span slot="append">บาท</span></Input
              >
            </FormItem>
          </section>
        </section>
      </Form>

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
        field1: [
          { required: true, message: "กรุณากรอกข้อมูล", trigger: "blur" },
        ],
        field2: [{ message: "กรุณากรอกข้อมูล", trigger: "blur" }],
        field3: [{ message: "กรุณากรอกข้อมูล", trigger: "blur" }],
        field4: [{ message: "กรุณากรอกข้อมูล", trigger: "blur" }],
        field5: [{ message: "กรุณากรอกข้อมูล", trigger: "blur" }],
        field6: [{ message: "กรุณากรอกข้อมูล", trigger: "blur" }],
        field7: [{ message: "กรุณากรอกข้อมูล", trigger: "blur" }],
        field8: [{ message: "กรุณากรอกข้อมูล", trigger: "blur" }],
        field9: [{ message: "กรุณากรอกข้อมูล", trigger: "blur" }],
      },
      ruleValidateModalList: {
        field1: [
          { required: true, message: "กรุณากรอกข้อมูล", trigger: "blur" },
        ],
        field2: [{ message: "กรุณากรอกข้อมูล", trigger: "blur" }],
        field3: [{ message: "กรุณากรอกข้อมูล", trigger: "blur" }],
        field4: [
          { required: true, message: "กรุณากรอกข้อมูล", trigger: "blur" },
        ],
        field5: [
          { message: "กรุณากรอกข้อมูล", trigger: "blur" },
        ],
        field6: [{ required: true, message: "กรุณากรอกข้อมูล", trigger: "blur" }],
        field7: [{ required: true, message: "กรุณากรอกข้อมูล", trigger: "blur" }],
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
        field9: "",
      },
      formItemModalList: {
        field1: "",
        field2: "",
        field3: "",
        field4: "",
        field5: "",
        field6: "",
        field7: ""
      },
      modalAddData: false,
      modalAddDataList: false,
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
          title: "เลขที่ใบรับเงินมัดจำ",
          key: "code",
          align: "center",
          sortable: true,
        },
        {
          title: "วันที่",
          key: "field1",
          align: "center",
          sortable: true,
        },
        {
          title: "รหัสลูกค้า",
          key: "field2",
          align: "center",
          sortable: true,
        },
        {
          title: "ชื่อลูกค้า",
          key: "field3",
          align: "center",
          sortable: true,
        },
        {
          title: "จำนวน",
          key: "field4",
          align: "center",
          sortable: true,
        },
        {
          title: "ราคารวม",
          key: "field5",
          align: "center",
          sortable: true,
        },
        {
          title: "เลขที่ใบสั่งซ่อม",
          slot: "add",
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
      tableData2: [],
      tableColumns2: [
        {
          title: "รหัสสินค้า",
          key: "code",
          align: "center",
        },
        {
          title: "ชื่อสินค้า",
          key: "field1",
          align: "center",
        },
        {
          title: "จำนวน",
          key: "field2",
          align: "center",
        },
        {
          title: "ยอดเงินรวม",
          key: "field3",
          align: "center",
        },
        {
          title: "มัดจำ(บาท)",
          key: "field4",
          align: "center",
        },
        {
          title: "มัดจำ(%)",
          key: "field5",
          align: "center",
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
      return `api/v1/setting-promotion?pageType=null&pageNumber=${this.dataCurrentPage}&pageSize=${this.dataPageSize}&orderAsc=${this.dataSortBy.order}&orderBy=${this.dataSortBy.key}`;
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
    openModalAddList() {
      this.modalAddDataList = true;
      this.modalAddData = false;
    },
    closeModalAddList() {
      this.modalAddDataList = false;
      this.modalAddData = true;
    },
    editRowData(index) {
      this.$Modal.info({
        title: "User Info",
        content: `Name：${this.tableColumns1[index].name}<br>Age：${this.tableColumns1[index].age}<br>Address：${this.tableColumns1[index].address}`,
      });
    },
    removeRowData(index) {
      this.tableColumns1.splice(index, 1);
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