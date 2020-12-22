<template>
  <div class="component-wrapper">
    <HeaderPage>
      ใบสั่งซ่อม
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
        <span>สร้างใบสั่งซ่อม</span>
      </p>

      <Form
      ref="inputForm"
        :model="formItem"
        :rules="ruleValidate"
        layout="row"
        layout-wrap
        :label-width="170"
      >
        <section
          layout="row"
          flex-xs="100"
          flex-sm="100"
          flex-md="100"
          flex-gt-md="33"
          flex-offset-gt-md="0"
        >
          <FormItem label="ทะเบียนรถ / จังหวัด" prop="field1" flex="auto">
            <Input
              size="large"
              v-model="formItem.field1"
              icon="ios-folder-open-outline"
            ></Input>
          </FormItem>
          <FormItem prop="field2" flex="30" :label-width="10">
            <Input disabled size="large" v-model="formItem.field2"></Input>
          </FormItem>
        </section>
        <FormItem
          label="ยี่ห้อ"
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
          label="รุ่น"
          prop="field4"
          flex-xs="100"
          flex-sm="100"
          flex-md="100"
          flex-gt-md="33"
          flex-offset-gt-md="0"
        >
          <Input disabled size="large" v-model="formItem.field4"></Input>
        </FormItem>
        <FormItem
          label="เลขไมล์"
          prop="field5"
          flex-xs="100"
          flex-sm="100"
          flex-md="100"
          flex-gt-md="33"
          flex-offset-gt-md="0"
        >
          <Input size="large" v-model="formItem.field5"></Input>
        </FormItem>
        <FormItem
          label="เลขไมล์ครั้งก่อน"
          prop="field6"
          flex-xs="100"
          flex-sm="100"
          flex-md="100"
          flex-gt-md="33"
          flex-offset-gt-md="0"
        >
          <Input disabled size="large" v-model="formItem.field6"></Input>
        </FormItem>
        <FormItem
          label="เลขไมล์เฉลี่ย / วัน"
          prop="field7"
          flex-xs="100"
          flex-sm="100"
          flex-md="100"
          flex-gt-md="33"
          flex-offset-gt-md="0"
        >
          <Input disabled size="large" v-model="formItem.field7"></Input>
        </FormItem>
        <FormItem
          label="ชื่อ-นามสกุล"
          prop="field8"
          flex-xs="100"
          flex-sm="100"
          flex-md="100"
          flex-gt-md="33"
          flex-offset-gt-md="0"
        >
          <Input
            size="large"
            v-model="formItem.field8"
            icon="ios-folder-open-outline"
          ></Input>
        </FormItem>
        <FormItem
          label="ผู้แจ้งซ่อม"
          prop="field9"
          flex-xs="100"
          flex-sm="100"
          flex-md="100"
          flex-gt-md="33"
          flex-offset-gt-md="0"
        >
          <Input size="large" v-model="formItem.field9"></Input>
        </FormItem>
        <FormItem
          label="หมายเลขโทรศัพท์"
          prop="field10"
          flex-xs="100"
          flex-sm="100"
          flex-md="100"
          flex-gt-md="33"
          flex-offset-gt-md="0"
        >
          <Input size="large" v-model="formItem.field10"></Input>
        </FormItem>
        <FormItem
          label="ประเภทเอกสาร"
          prop="field11"
          flex-xs="100"
          flex-sm="100"
          flex-md="100"
          flex-gt-md="33"
          flex-offset-gt-md="0"
        >
          <Input disabled size="large" v-model="formItem.field11"></Input>
        </FormItem>
        <FormItem
          label="ประเภทภาษี"
          prop="field12"
          flex-xs="100"
          flex-sm="100"
          flex-md="100"
          flex-gt-md="33"
          flex-offset-gt-md="0"
        >
          <Input disabled size="large" v-model="formItem.field12"></Input>
        </FormItem>
        <FormItem
          label="อัตราภาษี (%)"
          prop="field13"
          flex-xs="100"
          flex-sm="100"
          flex-md="100"
          flex-gt-md="33"
          flex-offset-gt-md="0"
        >
          <Input disabled size="large" v-model="formItem.field13"></Input>
        </FormItem>
        <FormItem
          label="เลขที่การจอง"
          prop="field13"
          flex-xs="100"
          flex-sm="100"
          flex-md="100"
          flex-gt-md="33"
          flex-offset-gt-md="0"
        >
          <Input disabled size="large" v-model="formItem.field13"></Input>
        </FormItem>
        <div flex="33" />
        <section layout="row" layout-align="end" flex-xs="100"
          flex-sm="100"
          flex-md="100"
          flex-gt-md="33"
          flex-offset-gt-md="0">
        <FormItem
          label="สถานะ"
          prop="field14"
          flex-xs="100"
          flex-sm="100"
          flex-md="100"
          flex-gt-md="70"
          flex-offset-gt-md="0"
        >
          <Card
            style="background: #eb8e02; color: white; text-align: center"
            :padding="0"
            ><b>รอชำระ</b></Card
          >
        </FormItem>
        </section>
        <Divider class="main-divider" />

        <Tabs
          :animated="false"
          id="tab-service-request"
          value="tab1"
          style="width: 100%"
        >
          <TabPane label="สินค้า/บริการ" name="tab1">
            <Modal
              class="fullsize-modal"
              v-model="modalAddDataTab1"
              :mask-closable="false"
              width="90%"
              @on-cancel="closeModalAddTab1()"
            >
              <p slot="header">
                <span>เพิ่มรายการ</span>
              </p>
              <Form
                :model="formItemTab1"
                :rules="ruleValidateTab1"
                :label-width="150"
                layout="row"
                layout-wrap
              >
                <FormItem
                  label="รหัสสินค้า/บริการ"
                  prop="field1"
                  flex-xs="100"
                  flex-sm="100"
                  flex-md="100"
                  flex-gt-md="33"
                  flex-offset-gt-md="0"
                >
                  <Input
                    size="large"
                    v-model="formItemTab1.field1"
                    icon="ios-folder-open-outline"
                  ></Input>
                </FormItem>
                <FormItem
                  label="ชื่อสินค้า/บริการ"
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
                    v-model="formItemTab1.field2"
                  ></Input>
                </FormItem>
                <FormItem
                  label="ที่เก็บ"
                  prop="field3"
                  flex-xs="100"
                  flex-sm="100"
                  flex-md="100"
                  flex-gt-md="33"
                  flex-offset-gt-md="0"
                >
                  <Input
                    disabled
                    size="large"
                    v-model="formItemTab1.field3"
                  ></Input>
                </FormItem>
                <FormItem
                  label="หน่วยสินค้า"
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
                    v-model="formItemTab1.field4"
                  ></Input>
                </FormItem>
                <FormItem
                  label="DOT"
                  prop="field5"
                  flex-xs="100"
                  flex-sm="100"
                  flex-md="100"
                  flex-gt-md="33"
                  flex-offset-gt-md="0"
                >
                  <Input
                    disabled
                    size="large"
                    v-model="formItemTab1.field5"
                  ></Input>
                </FormItem>
                <FormItem
                  label="จำนวน"
                  prop="field6"
                  flex-xs="100"
                  flex-sm="100"
                  flex-md="100"
                  flex-gt-md="33"
                  flex-offset-gt-md="0"
                >
                  <Input size="large" v-model="formItemTab1.field6"></Input>
                </FormItem>
                <FormItem
                  label="ราคา/หน่วย"
                  prop="field7"
                  flex-xs="100"
                  flex-sm="100"
                  flex-md="100"
                  flex-gt-md="33"
                  flex-offset-gt-md="0"
                >
                  <Input size="large" v-model="formItemTab1.field7"></Input>
                </FormItem>
                <FormItem
                  label="ช่างซ่อม"
                  prop="field8"
                  flex-xs="100"
                  flex-sm="100"
                  flex-md="100"
                  flex-gt-md="33"
                  flex-offset-gt-md="0"
                >
                  <Input
                    size="large"
                    v-model="formItemTab1.field8"
                    icon="ios-folder-open-outline"
                  ></Input>
                </FormItem>
              </Form>
            </Modal>

            <section
              layout="row"
              layout-align="end"
              style="padding-bottom: 20px"
            >
              <Button
                flex-xs="100"
                flex-sm="100"
                flex-md="100"
                type="success"
                shape="circle"
                size="large"
                @click="openModalAddTab1()"
                ><Icon type="md-add" />เพิ่มรายการ</Button
              >
            </section>
            <Table
              stripe
              size="large"
              :columns="tableColumnsTab1"
              :data="tableDataTab1"
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
            <section layout="row" style="margin-top:30px">
              <section flex="50">
                <FormItem label="หมายเหตุ" prop="field9" >
                  <Input
                    type="textarea"
                    :autosize="{ minRows: 5, maxRows: 10 }"
                    size="large"
                    v-model="formItemTab2.field9"
                  ></Input>
                </FormItem>
              </section>
              <section flex="45">
                <FormItem label="รวมเงิน" prop="field10" >
                  <Input
                    disabled
                    size="large"
                    v-model="formItemTab1.field10"
                  ><span slot="append">บาท</span></Input>
                </FormItem>
                <FormItem label="ภาษีมูลค่าเพิ่ม" prop="field11" >
                  <Input
                    disabled
                    size="large"
                    v-model="formItemTab1.field11"
                  ><span slot="append">บาท</span></Input>
                </FormItem>
                <FormItem label="ยอดรวมสุทธิ" prop="field12">
                  <Input
                    disabled
                    size="large"
                    v-model="formItemTab1.field12"
                  ><span slot="append">บาท</span></Input>
                </FormItem>
              </section>
            </section>
          </TabPane>
          <TabPane
            label="ลูกค้า"
            name="tab2"
            layout="row"
            layout-align="center center"
          >
            <Form
              :model="formItemTab2"
              :rules="ruleValidateTab2"
              :label-width="180"
              layout="row"
              layout-wrap
              flex="80"
            >
              <section
                flex-xs="100"
                flex-sm="100"
                flex-md="100"
                flex-gt-md="50"
              >
                <FormItem label="เลขประจำตัวผู้เสียภาษี" prop="field1">
                  <Input
                    disabled
                    size="large"
                    v-model="formItemTab2.field1"
                  ></Input>
                </FormItem>
                <FormItem label="สถานประกอบการ" prop="field2">
                  <Input
                    disabled
                    size="large"
                    v-model="formItemTab2.field2"
                  ></Input>
                </FormItem>
                <FormItem label="เลขที่สาขา" prop="field3">
                  <Input
                    disabled
                    size="large"
                    v-model="formItemTab2.field3"
                  ></Input>
                </FormItem>
                <FormItem label="ประเภทลูกค้า" prop="field4">
                  <Input
                    disabled
                    size="large"
                    v-model="formItemTab2.field4"
                  ></Input>
                </FormItem>
                <FormItem label="ที่อยู่" prop="field5">
                  <Input
                    disabled
                    type="textarea"
                    :autosize="{ minRows: 5, maxRows: 10 }"
                    size="large"
                    v-model="formItemTab2.field5"
                  ></Input>
                </FormItem>
                <FormItem label="มือถือ" prop="field6">
                  <Input
                    disabled
                    size="large"
                    v-model="formItemTab2.field6"
                  ></Input>
                </FormItem>
                <FormItem label="E-mail" prop="field7">
                  <Input
                    disabled
                    size="large"
                    v-model="formItemTab2.field7"
                  ></Input>
                </FormItem>
              </section>
              <section
                flex-xs="100"
                flex-sm="100"
                flex-md="100"
                flex-gt-md="50"
              >
                <div
                  layout="row"
                  layout-align="center center"
                  style="margin-bottom: 24px"
                >
                  <label style="color: #9c9c9c; font-size: 28px"
                    >ข้อมูลการชำระเงิน</label
                  >
                </div>
                <div
                  style="
                    border: 1px solid #c9c9c9;
                    border-radius: 5px;
                    margin-left: 16px;
                    margin-right: 16px;
                    padding: 16px;
                  "
                >
                  <FormItem label="เลขประจำตัวผู้เสียภาษี" prop="field8">
                    <Input
                      disabled
                      size="large"
                      v-model="formItemTab2.field8"
                    ></Input>
                  </FormItem>
                  <FormItem label="สถานประกอบการ" prop="field9">
                    <Input
                      disabled
                      size="large"
                      v-model="formItemTab2.field9"
                    ></Input>
                  </FormItem>
                  <FormItem label="เลขที่สาขา" prop="field10">
                    <Input
                      disabled
                      size="large"
                      v-model="formItemTab2.field10"
                    ></Input>
                  </FormItem>
                  <FormItem label="ประเภทลูกค้า" prop="field11">
                    <Input
                      disabled
                      size="large"
                      v-model="formItemTab2.field11"
                    ></Input>
                  </FormItem>
                  <FormItem label="ประเภทลูกค้า" prop="field12">
                    <Input
                      disabled
                      size="large"
                      v-model="formItemTab2.field12"
                    ></Input>
                  </FormItem>
                  <FormItem label="ที่อยู่" prop="field13">
                    <Input
                      disabled
                      type="textarea"
                      :autosize="{ minRows: 5, maxRows: 10 }"
                      size="large"
                      v-model="formItemTab2.field13"
                    ></Input>
                  </FormItem>
                </div>
              </section>
            </Form>
          </TabPane>
          <TabPane
            label="เอกสาร"
            name="tab3"
            layout="row"
            layout-align="center center"
          >
            <Form
              :model="formItemTab3"
              :rules="ruleValidateTab3"
              :label-width="180"
              layout="row"
              layout-wrap
              flex="80"
            >
              <section layout="row" layout-wrap>
                <FormItem
                  label="เลขที่ใบเสนอราคา"
                  prop="field1"
                  flex-xs="100"
                  flex-sm="100"
                  flex-md="100"
                  flex-gt-md="50"
                >
                  <Input
                    disabled
                    size="large"
                    v-model="formItemTab3.field1"
                  ></Input>
                </FormItem>
                <FormItem
                  label="วันที่ใบเสนอราคา"
                  prop="field2"
                  flex-xs="100"
                  flex-sm="100"
                  flex-md="100"
                  flex-gt-md="50"
                >
                  <Input
                    disabled
                    size="large"
                    v-model="formItemTab3.field2"
                  ></Input>
                </FormItem>
                <FormItem
                  label="เลขที่ใบรับเงินมัดจำ"
                  prop="field3"
                  flex-xs="100"
                  flex-sm="100"
                  flex-md="100"
                  flex-gt-md="50"
                >
                  <Input
                    disabled
                    size="large"
                    v-model="formItemTab3.field3"
                  ></Input>
                </FormItem>
                <FormItem
                  label="วันที่รับเงินมัดจำ"
                  prop="field4"
                  flex-xs="100"
                  flex-sm="100"
                  flex-md="100"
                  flex-gt-md="50"
                >
                  <Input
                    disabled
                    size="large"
                    v-model="formItemTab3.field4"
                  ></Input>
                </FormItem>
              </section>
              <section
                flex-xs="100"
                flex-sm="100"
                flex-md="100"
                flex-gt-md="50"
              >
                <FormItem label="พนักงานขาย" prop="field5">
                  <Input
                    size="large"
                    v-model="formItemTab3.field5"
                    icon="ios-folder-open-outline"
                  ></Input>
                </FormItem>
                <FormItem label="ผู้ควบคุม" prop="field6">
                  <Input
                    size="large"
                    v-model="formItemTab3.field6"
                    icon="ios-folder-open-outline"
                  ></Input>
                </FormItem>
                <FormItem label="ผู้ช่วย 1" prop="field7">
                  <Input
                    size="large"
                    v-model="formItemTab3.field7"
                    icon="ios-folder-open-outline"
                  ></Input>
                </FormItem>
                <FormItem label="ผู้ช่วย 2" prop="field8">
                  <Input
                    size="large"
                    v-model="formItemTab3.field8"
                    icon="ios-folder-open-outline"
                  ></Input>
                </FormItem>
              </section>
              <section
                flex-xs="100"
                flex-sm="100"
                flex-md="100"
                flex-gt-md="50"
              >
                <section layout="row">
                  <FormItem label="วันที่แจ้งซ่อม" prop="field9" flex="auto">
                    <DatePicker
                      size="large"
                      type="date"
                      placeholder="เลือกวันที่"
                      v-model="formItemTab3.field9"
                    ></DatePicker>
                  </FormItem>
                  <FormItem
                    label="เวลา"
                    prop="field10"
                    flex="30"
                    :label-width="60"
                  >
                    <TimePicker
                      size="large"
                      format="HH:mm"
                      placeholder="เลือกเวลา"
                      v-model="formItemTab3.field10"
                    ></TimePicker>
                  </FormItem>
                </section>
                <section layout="row">
                  <FormItem label="วันที่ซ่อมเสร็จ" prop="field11" flex="auto">
                    <DatePicker
                      size="large"
                      type="date"
                      placeholder="เลือกวันที่"
                      v-model="formItemTab3.field11"
                    ></DatePicker>
                  </FormItem>
                  <FormItem
                    label="เวลา"
                    prop="field12"
                    flex="30"
                    :label-width="60"
                  >
                    <TimePicker
                      size="large"
                      format="HH:mm"
                      placeholder="เลือกเวลา"
                      v-model="formItemTab3.field12"
                    ></TimePicker>
                  </FormItem>
                </section>
                <section layout="row">
                  <FormItem label="วันที่นัดรับรถ" prop="field13" flex="auto">
                    <DatePicker
                      size="large"
                      type="date"
                      placeholder="เลือกวันที่"
                      v-model="formItemTab3.field13"
                    ></DatePicker>
                  </FormItem>
                  <FormItem
                    label="เวลา"
                    prop="field14"
                    flex="30"
                    :label-width="60"
                  >
                    <TimePicker
                      size="large"
                      format="HH:mm"
                      placeholder="เลือกเวลา"
                      v-model="formItemTab3.field14"
                    ></TimePicker>
                  </FormItem>
                </section>
                <section layout="row">
                  <FormItem label="วันที่ส่งมอบ" prop="field15" flex="auto">
                    <DatePicker
                      size="large"
                      type="date"
                      placeholder="เลือกวันที่"
                      v-model="formItemTab3.field15"
                    ></DatePicker>
                  </FormItem>
                  <FormItem
                    label="เวลา"
                    prop="field16"
                    flex="30"
                    :label-width="60"
                  >
                    <TimePicker
                      size="large"
                      format="HH:mm"
                      placeholder="เลือกเวลา"
                      v-model="formItemTab3.field16"
                    ></TimePicker>
                  </FormItem>
                </section>
              </section>
            </Form>
          </TabPane>
          <TabPane
            label="รถยนต์"
            name="tab4"
            layout="row"
            layout-align="center center"
          >
            <Form
              :model="formItemTab4"
              :rules="ruleValidateTab4"
              :label-width="180"
              layout="row"
              layout-wrap
              flex="80"
            >
              <section
                flex-xs="100"
                flex-sm="100"
                flex-md="100"
                flex-gt-md="50"
              >
                <FormItem label="เลขเครื่อง" prop="field1">
                  <Input
                    disabled
                    size="large"
                    v-model="formItemTab4.field1"
                  ></Input>
                </FormItem>
                <FormItem label="เลขตัวถัง" prop="field2">
                  <Input
                    disabled
                    size="large"
                    v-model="formItemTab4.field2"
                  ></Input>
                </FormItem>
                <FormItem label="ประเภทรถ" prop="field3">
                  <Input
                    disabled
                    size="large"
                    v-model="formItemTab4.field3"
                  ></Input>
                </FormItem>
                <FormItem label="ขนาดเครื่องยนต์ CC" prop="field4">
                  <Input
                    disabled
                    size="large"
                    v-model="formItemTab4.field4"
                  ></Input>
                </FormItem>
                <FormItem label="สีรถ" prop="field5">
                  <Input
                    disabled
                    size="large"
                    v-model="formItemTab4.field5"
                  ></Input>
                </FormItem>
              </section>
              <section
                flex-xs="100"
                flex-sm="100"
                flex-md="100"
                flex-gt-md="50"
              >
                <FormItem label="วันที่ติดต่อล่าสุด" prop="field6">
                  <Input
                    disabled
                    size="large"
                    v-model="formItemTab4.field6"
                  ></Input>
                </FormItem>
                <FormItem label="วันที่ติดต่อครั้งแรก" prop="field7">
                  <Input
                    disabled
                    size="large"
                    v-model="formItemTab4.field7"
                  ></Input>
                </FormItem>
                <FormItem label="เลขไมล์ครั้งแรก" prop="field8">
                  <Input
                    disabled
                    size="large"
                    v-model="formItemTab4.field8"
                  ></Input>
                </FormItem>
                <FormItem label="เฉลี่ย/เดือน" prop="field9">
                  <Input
                    disabled
                    size="large"
                    v-model="formItemTab4.field9"
                  ></Input>
                </FormItem>
              </section>
            </Form>
          </TabPane>
          <TabPane
            label="รูปประกอบ"
            name="tab5"
            layout="row"
            layout-align="center center"
          >
            <Upload
              ref="upload"
              :show-upload-list="false"
              :format="['jpg', 'jpeg', 'png']"
              :max-size="2048"
              multiple
              type="drag"
              action="//jsonplaceholder.typicode.com/posts/"
              style="display: inline-block; width: 58px"
            >
              <div style="width: 58px; height: 58px; line-height: 58px">
                <Icon type="ios-camera" size="20"></Icon>
              </div>
            </Upload>
          </TabPane>
        </Tabs>
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
        field5: [
          { required: true, message: "กรุณากรอกข้อมูล", trigger: "blur" },
        ],
        field6: [{ message: "กรุณากรอกข้อมูล", trigger: "blur" }],
        field7: [{ message: "กรุณากรอกข้อมูล", trigger: "blur" }],
        field8: [{ message: "กรุณากรอกข้อมูล", trigger: "blur" }],
        field9: [{ message: "กรุณากรอกข้อมูล", trigger: "blur" }],
        field10: [{ message: "กรุณากรอกข้อมูล", trigger: "blur" }],
        field11: [{ message: "กรุณากรอกข้อมูล", trigger: "blur" }],
        field12: [{ message: "กรุณากรอกข้อมูล", trigger: "blur" }],
        field13: [{ message: "กรุณากรอกข้อมูล", trigger: "blur" }],
        field14: [{ message: "กรุณากรอกข้อมูล", trigger: "blur" }],
      },
      ruleValidateTab1: {
        field1: [
          { required: true, message: "กรุณากรอกข้อมูล", trigger: "blur" },
        ],
        field2: [{ message: "กรุณากรอกข้อมูล", trigger: "blur" }],
        field3: [{ message: "กรุณากรอกข้อมูล", trigger: "blur" }],
        field4: [{ message: "กรุณากรอกข้อมูล", trigger: "blur" }],
        field5: [{ message: "กรุณากรอกข้อมูล", trigger: "blur" }],
        field6: [
          { required: true, message: "กรุณากรอกข้อมูล", trigger: "blur" },
        ],
        field7: [
          { required: true, message: "กรุณากรอกข้อมูล", trigger: "blur" },
        ],
        field8: [{ message: "กรุณากรอกข้อมูล", trigger: "blur" }],
      },
      ruleValidateTab2: {},
      ruleValidateTab3: {},
      ruleValidateTab4: {},
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
        field10: "",
        field11: "",
        field12: "",
        field13: "",
        field14: "",
      },
      formItemTab1: {
        field1: "",
        field2: "",
        field3: "",
        field4: "",
        field5: "",
        field6: "",
        field7: "",
        field8: "",
        field9: "",
        field10: "",
        field11: "",
        field12: ""
      },
      formItemTab2: {
        field1: "",
        field2: "",
        field3: "",
        field4: "",
        field5: "",
        field6: "",
        field7: "",
        field8: "",
        field9: "",
        field10: "",
        field11: "",
        field12: "",
        field13: "",
      },
      formItemTab3: {
        field1: "",
        field2: "",
        field3: "",
        field4: "",
        field5: "",
        field6: "",
        field7: "",
        field8: "",
        field9: "",
        field10: "",
        field11: "",
        field12: "",
        field13: "",
        field14: "",
        field15: "",
        field16: "",
      },
      formItemTab4: {
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
      modalAddData: false,
      modalAddDataTab1: false,
      searchBox: "",
      loading: false,
      dataTotal: 0,
      dataPageSize: 10,
      dataCurrentPage: 1,
      dataSortBy: {
        key: "",
        order: "",
      },
      tableData1:[],
      tableColumns1: [
        {
          title: "เลขที่ใบสั่งซ่อม",
          key: "code",
          minWidth : 160,
          align: "center",
          sortable: true,
        },
        {
          title: "วันที่",
          key: "field1",
          width: 150,
          align: "center",
          sortable: true,
        },
        {
          title: "รหัสลูกค้า",
          key: "field2",
          width: 150,
          align: "center",
          sortable: true,
        },
        {
          title: "ชื่อ - นามสกุล",
          key: "field3",
          minWidth : 160,
          align: "center",
          sortable: true,
        },
        {
          title: "เลขทะเบียน",
          key: "field4",
          minWidth : 160,
          align: "center",
          sortable: true,
        },
        {
          title: "จำนวน",
          key: "field5",
          minWidth : 160,
          align: "center",
          sortable: true,
        },
        {
          title: "ราคารวม",
          key: "field6",
          minWidth : 160,
          align: "center",
          sortable: true,
        },
        {
          title: "ปิด",
          slot: "closeBox",
          width: 150,
          align: "center",
          sortable: true,
        },
        {
          title: "คำสั่ง",
          slot: "action",
          width: 150,
          Fixed: 'right',
          align: "center",
        },
      ],
      tableDataTab1:[],
      tableColumnsTab1: [
        {
          title: "รหัสสินค้า",
          key: "code",
          width: 150,
          align: "center",
        },
        {
          title: "ชื่อสินค้า",
          key: "field1",
          minWidth : 160,
          align: "center",
        },
        {
          title: "หน่วย",
          key: "field2",
          minWidth : 160,
          align: "center",
        },
        {
          title: "ที่เก็บ",
          key: "field3",
          minWidth : 160,
          align: "center",
        },
        {
          title: "DOT",
          key: "field4",
          width: 150,
          align: "center",
        },
        {
          title: "จำนวน",
          key: "field5",
          minWidth : 160,
          align: "center",
        },
        {
          title: "ราคา/หน่วย",
          key: "field6",
          minWidth : 160,
          align: "center",
        },
        {
          title: "จำนวนเงิน",
          key: "field7",
          minWidth : 160,
          align: "center",
        },
        {
          title: "ช่างซ่อม",
          key: "field8",
          minWidth : 160,
          align: "center",
        },
        {
          title: "คำสั่ง",
          slot: "action",
          width: 150,
          Fixed: 'right',
          align: "center",
        }
      ]
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
    openModalAddTab1() {
      this.modalAddDataTab1 = true;
      this.modalAddData = false;
    },
    closeModalAddTab1() {
      this.modalAddDataTab1 = false;
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