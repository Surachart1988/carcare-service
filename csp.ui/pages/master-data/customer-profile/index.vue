<template>
  <div class="component-wrapper">
    <!-- <div>menuID {{menuID}}</div>
    <div>cPermisson {{cPermisson}}</div>
    <div>ePermisson {{ePermisson}}</div>
    <div>vPermisson {{vPermisson}}</div>
    <div>dPermisson {{dPermisson}}</div>
    <div>pPermisson {{pPermisson}}</div>-->

    <HeaderPage>
      ทะเบียนลูกค้า
      <!-- <template v-slot:subheader>
      xxx
      </template>-->
    </HeaderPage>

    <div layout="row" layout-align="center center">
      <SearchDataTable
        :columns="tableColumns1"
        searchbox-width="300px"
        select-width="200px"
        :delete-subfix="true"
      ></SearchDataTable>
    </div>

    <HeaderPage :userAvatar="false" :buttonAdd="true" :divider="false">
      <!-- ทะเบียนลูกค้า -->
      <!-- <template v-slot:subheader>
      xxx
      </template>-->
    </HeaderPage>

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
        api-end-point="Customer"
        ref="dataTable"
        :mode-search="modeSearch"
        :not-delete="true"
      ></DataTable>

      <Modal
        class="fullsize-modal"
        v-show="modalAddData"
        v-model="resloveSlowInput"
        :mask-closable="false"
        width="90%"
        @on-cancel="closeModalAdd()"
      >
      <!-- modeEdit {{modeEdit}} -->
        <button @click="debug()">debug</button>

        <p slot="header">
          <span>เพิ่มทะเบียนลูกค้า</span>
        </p>

        <Form ref="formValidate" :model="formItem" :rules="ruleValidate" layout="row" layout-wrap>
          <FormItem
            :label-width="85"
            prop="Code"
            label="รหัสลูกค้า"
            flex="100"
            flex-lg="20"
            flex-gt-lg="15"
          >
            <Input disabled size="large" v-model="formItem.Code"></Input>
          </FormItem>
          <FormItem
            :label-width="115"
            prop="PrefixId"
            label="คำนำหน้าชื่อ"
            flex="100"
            flex-lg="20"
            flex-gt-lg="20"
          >
            <Select
              clearable
              size="large"
              v-model="formItem.PrefixId"
              placeholder="เลือกคำนำหน้าชื่อ"
              @on-open-change="prefixnameFromAPI()"
            >
              <Option v-for="(e, index) in getDataPrefixName" :key="index" :value="e.Id">{{e.Name}}</Option>
            </Select>
          </FormItem>
          <FormItem
            :label-width="120"
            prop="Name"
            label="ชื่อ - นามสกุล"
            flex="100"
            flex-lg="30"
            flex-gt-lg="25"
          >
            <Input size="large" v-model="formItem.Name"></Input>
          </FormItem>
          <FormItem
            :label-width="170"
            prop="TaxId"
            label="เลขประจำตัวผู้เสียภาษี"
            flex="100"
            flex-lg="30"
            flex-gt-lg="20"
          >
            <Input size="large" v-model="formItem.TaxId"></Input>
          </FormItem>
          <FormItem
            :label-width="85"
            label-position="right"
            prop="Active"
            label="สถานะ"
            flex="100"
            flex-lg="100"
            flex-gt-lg="20"
          >
            <i-switch size="large" v-model="formItem.Active">
              <span slot="open">ดำเนิการ</span>
              <span slot="close">ยกเลิก</span>
            </i-switch>
          </FormItem>

          <Divider class="main-divider" />
          <!-- <div>หห{{formItem.Active}}</div> -->

          <Tabs :animated="false" id="tab-customers-registration" value="tab1" style="width:100%">
            <TabPane label="ข้อมูลลูกค้า" name="tab1">
              <Form
                ref="formValidateTab1"
                :model="formItemTab1"
                :rules="ruleValidateTab1"
                :label-width="140"
                layout="row"
                layout-wrap
              >
                <section
                  class="secction-form with-border"
                  flex="100"
                  flex-lg="33"
                  flex-gt-lg="30"
                  flex-offset-lg="0"
                  flex-offset-gt-lg="0"
                >
                  <FormItem prop="ContactTypeId" label="กลุ่มลูกค้า" flex="100">
                    <Select
                      clearable
                      size="large"
                      v-model="formItemTab1.ContactTypeId"
                      placeholder="เลือกกลุ่มลูกค้า"
                      @on-open-change="customergroupFromAPI()"
                    >
                      <Option
                        v-for="(e, index) in getDataCustomerGroup"
                        :key="index"
                        :value="e.Id"
                      >{{e.Name}}</Option>
                    </Select>
                  </FormItem>

                  <FormItem prop="CustomerType" label="ประเภทลูกค้า" flex="100">
                    <RadioGroup size="large" v-model="formItemTab1.CustomerType">
                      <Radio :label="0">บุคคลทั่วไป</Radio>
                      <Radio :label="1">นิติบุคคล</Radio>
                    </RadioGroup>
                  </FormItem>

                  <div flex="100" layout="row">
                    <FormItem prop="TaxBranch" label="สถานประกอบการ" flex="auto">
                      <Input size="large" v-model="formItemTab1.TaxBranch"></Input>
                    </FormItem>

                    <FormItem
                      prop="TaxBranchNo"
                      :label-width="50"
                      label-position="right"
                      label="สาขา"
                      flex-offset-gt-md="10"
                      flex="50"
                    >
                      <Input size="large" v-model="formItemTab1.TaxBranchNo"></Input>
                    </FormItem>
                  </div>

                  <FormItem prop="BirthDate" label="วัน/เดือน/ปี เกิด" flex="100">
                    <DatePicker
                      size="large"
                      type="date"
                      placeholder="เลือกวัน/เดือน/ปี เกิด"
                      v-model="formItemTab1.BirthDate"
                    ></DatePicker>
                  </FormItem>

                  <FormItem prop="Sex" label="เพศ" flex="100">
                    <RadioGroup size="large" v-model="formItemTab1.Sex">
                      <Radio :label="0">ชาย</Radio>
                      <Radio :label="1">หญิง</Radio>
                    </RadioGroup>
                  </FormItem>

                  <FormItem prop="CusContactName" label="ชื่อผู้ติดต่อ" flex="100">
                    <Input size="large" v-model="formItemTab1.CusContactName"></Input>
                  </FormItem>

                  <FormItem prop="BussTypeId" label="ประเภทธุรกิจ" flex="100">
                    <Select
                      clearable
                      size="large"
                      v-model="formItemTab1.BussTypeId"
                      placeholder="เลือกประเภทธุรกิจ"
                      flex="100"
                      @on-open-change="businesstypeFromAPI()"
                    >
                      <Option
                        v-for="(e, index) in getDataBusinessType"
                        :key="index"
                        :value="e.Id"
                      >{{e.Name}}</Option>
                    </Select>
                  </FormItem>
                </section>

                <section
                  class="secction-form"
                  flex="100"
                  flex-lg="33"
                  flex-gt-lg="30"
                  flex-offset-lg="0"
                  flex-offset-gt-lg="5"
                >
                  <FormItem prop="FirstContactDate" label="วันติดต่อครั้งแรก" flex="100">
                    <DatePicker
                      disabled
                      size="large"
                      type="date"
                      placeholder="เลือกวันติดต่อครั้งแรก"
                      v-model="formItemTab1.FirstContactDate"
                    ></DatePicker>
                  </FormItem>

                  <FormItem prop="LastContactDate" label="วันติดต่อครั้งล่าสุด" flex="100">
                    <DatePicker
                      disabled
                      size="large"
                      type="date"
                      placeholder="เลือกวันติดต่อครั้งล่าสุด"
                      v-model="formItemTab1.LastContactDate"
                    ></DatePicker>
                  </FormItem>

                  <FormItem prop="CancelAt" label="วันที่ยกเลิก" flex="100">
                    <DatePicker
                      disabled
                      size="large"
                      type="date"
                      placeholder="เลือกวันที่ยกเลิก"
                      v-model="formItemTab1.CancelAt"
                    ></DatePicker>
                  </FormItem>

                  <FormItem prop="Note" label="หมายเหตุ" flex="100">
                    <Input
                      disabled
                      size="large"
                      v-model="formItemTab1.Note"
                      type="textarea"
                      :autosize="{minRows: 1,maxRows: 3}"
                      placeholder="ใส่หมายเหตุ..."
                    ></Input>
                  </FormItem>

                  <FormItem prop="Address" label="ที่อยู่" flex="100">
                    <Input size="large" v-model="formItemTab1.Address"></Input>
                  </FormItem>

                  <div flex="100" layout="row">
                    <FormItem prop="AddressNo" label="เลขที่" flex="auto">
                      <Input size="large" v-model="formItemTab1.AddressNo"></Input>
                    </FormItem>

                    <FormItem
                      prop="AddressMoo"
                      :label-width="50"
                      label-position="right"
                      label="หมู่ที่"
                      flex-offset-gt-md="10"
                      flex="50"
                    >
                      <Input size="large" v-model="formItemTab1.AddressMoo"></Input>
                    </FormItem>
                  </div>

                  <FormItem prop="Phone" label="หมายเลขติดต่อ" flex="100">
                    <Input size="large" v-model="formItemTab1.Phone"></Input>
                  </FormItem>
                </section>

                <section
                  class="secction-form"
                  flex="100"
                  flex-lg="33"
                  flex-gt-lg="30"
                  flex-offset-lg="0"
                  flex-offset-gt-lg="5"
                >
                  <FormItem prop="AddressTrog" label="ตรอก" flex="100">
                    <Input size="large" v-model="formItemTab1.AddressTrog"></Input>
                  </FormItem>

                  <FormItem prop="AddressSoi" label="ซอย" flex="100">
                    <Input size="large" v-model="formItemTab1.AddressSoi"></Input>
                  </FormItem>

                  <FormItem prop="AddressRoad" label="ถนน" flex="100">
                    <Input size="large" v-model="formItemTab1.AddressRoad"></Input>
                  </FormItem>

                  <FormItem prop="ProvinceId" label="จังหวัด" flex="100">
                    <Select
                      filterable
                      clearable
                      size="large"
                      v-model="formItemTab1.ProvinceId"
                      placeholder="เลือกจังหวัด"
                      @on-open-change="provinceFromAPI()"
                    >
                      <Option
                        v-for="(e, index) in getDataProvince"
                        :key="index"
                        :value="e.Id"
                      >{{e.Name}}</Option>
                    </Select>
                  </FormItem>

                  <FormItem prop="DistrictId" label="เขต/อำเภอ" flex="100">
                    <Select
                      filterable
                      clearable
                      size="large"
                      v-model="formItemTab1.DistrictId"
                      placeholder="เลือกเขต/อำเภอ"
                      @on-open-change="districtFromAPI()"
                    >
                      <Option
                        v-for="(e, index) in getDataDistrict"
                        :key="index"
                        :value="e.Id"
                      >{{e.Name}}</Option>
                    </Select>
                  </FormItem>

                  <FormItem prop="SubDistrictId" label="แขวง/ตำบล" flex="100">
                    <Select
                      filterable
                      clearable
                      size="large"
                      v-model="formItemTab1.SubDistrictId"
                      placeholder="เลือกแขวง/ตำบล"
                      @on-open-change="subdistrictFromAPI()"
                    >
                      <Option
                        v-for="(e, index) in getDataSubdistrict"
                        :key="index"
                        :value="e.Id"
                      >{{e.Name}}</Option>
                    </Select>
                  </FormItem>

                  <FormItem prop="ZipCodeId" label="รหัสไปรษณีย์" flex="100">
                    <Input size="large" v-model="formItemTab1.ZipCodeId"></Input>
                  </FormItem>
                </section>
              </Form>
            </TabPane>

            <TabPane label="ข้อมูลการติดต่อ" name="tab2">
              <Form
                ref="formValidateTab2"
                :model="formItemTab2"
                :rules="ruleValidateTab2"
                :label-width="105"
                layout="row"
                layout-wrap
                layout-align="center center"
              >
                <section class="secction-form" flex="100" flex-md="50" flex-lg="30" flex-gt-lg="20">
                  <FormItem prop="Phone1" label="โทรศัพท์ 1" flex="100">
                    <Input size="large" v-model="formItemTab2.Phone1"></Input>
                  </FormItem>
                  <FormItem prop="Phone2" label="โทรศัพท์ 2" flex="100">
                    <Input size="large" v-model="formItemTab2.Phone2"></Input>
                  </FormItem>
                  <FormItem prop="Phone3" label="โทรศัพท์ 3" flex="100">
                    <Input size="large" v-model="formItemTab2.Phone3"></Input>
                  </FormItem>
                  <FormItem prop="Fax" label="โทรสาร (Fax)" flex="100">
                    <Input size="large" v-model="formItemTab2.Fax"></Input>
                  </FormItem>
                </section>

                <section class="secction-form" flex="100" flex-md="50" flex-lg="30" flex-gt-lg="20">
                  <FormItem prop="Moblie1" label="มือถือ 1" flex="100">
                    <Input size="large" v-model="formItemTab2.Moblie1"></Input>
                  </FormItem>
                  <FormItem prop="Moblie2" label="มือถือ 2" flex="100">
                    <Input size="large" v-model="formItemTab2.Moblie2"></Input>
                  </FormItem>
                  <FormItem prop="Moblie3" label="มือถือ 3" flex="100">
                    <Input size="large" v-model="formItemTab2.Moblie3"></Input>
                  </FormItem>
                  <FormItem prop="Email" label="E-mail" flex="100">
                    <Input size="large" v-model="formItemTab2.Email"></Input>
                  </FormItem>
                </section>

                <Divider style="margin: 30px 0 70px 0">ต้องการรับข่าวสาร</Divider>

                <div flex="100" layout="row" layout-align="center center">
                  <section
                    class="secction-form"
                    flex="100"
                    flex-md="33"
                    flex-lg="23"
                    flex-gt-lg="18"
                    flex-offset-lg="0"
                    flex-offset-gt-lg="0"
                  >
                    <div
                      :class="(formItemTab2.subscribeMail.status) ? 'subscribe-box-active' : 'subscribe-box'"
                    >
                      <div layout="column" layout-align="center center">
                        <!-- {{formItemTab2.subscribeMail.status}} -->
                        <Checkbox
                          :label="false"
                          size="large"
                          v-model="formItemTab2.subscribeMail.status"
                          @click.prevent.native="checkVauleSubscribe('mail')"
                          style="margin-top: -20px"
                        ></Checkbox>
                        <div class="subscribe-icon" layout="row" layout-align="center center">
                          <svg
                            id="mailbox"
                            xmlns="http://www.w3.org/2000/svg"
                            width="80.948"
                            height="84.851"
                            viewBox="0 0 80.948 84.851"
                          >
                            <path
                              class="a"
                              id="Path_341"
                              data-name="Path 341"
                              d="M87.679,18.707a1.242,1.242,0,1,0-1.732,1.782A14.043,14.043,0,0,1,90.238,30.64V50.393a.415.415,0,0,1-.414.414H59.092V30.64a16.642,16.642,0,0,0-7.9-14.153H76.085a14.065,14.065,0,0,1,5.433,1.08,1.242,1.242,0,1,0,.955-2.294A16.54,16.54,0,0,0,76.085,14H60.74V11.153h9.271a2.073,2.073,0,0,0,2.071-2.071V3.23A2.073,2.073,0,0,0,70.012,1.16H60.736a1.242,1.242,0,0,0-2.481.083V14H42.431a16.664,16.664,0,0,0-12.177,5.325H14.674a2.9,2.9,0,0,0-2.9,2.9v15.6a2.9,2.9,0,0,0,2.9,2.9H25.815v4.083H20.258a2.239,2.239,0,0,0-2.236,2.236v4.015a2.239,2.239,0,0,0,2.236,2.236H54.126V74.98a5.613,5.613,0,0,1-1.3,3.591l-2.407,2.882a2.071,2.071,0,0,0,1.589,3.4H67.9a2.071,2.071,0,0,0,1.589-3.4l-2.407-2.882a5.613,5.613,0,0,1-1.3-3.591v-1.3a1.242,1.242,0,0,0-2.485,0v1.3a8.1,8.1,0,0,0,1.88,5.184l1.84,2.2H52.891l1.84-2.2a8.1,8.1,0,0,0,1.88-5.184V53.292H63.3v14.4a1.242,1.242,0,0,0,2.485,0v-14.4H89.824a2.9,2.9,0,0,0,2.9-2.9V30.64a16.508,16.508,0,0,0-5.045-11.934ZM69.6,8.668H60.74V3.644H69.6ZM36.66,21.813,26.244,31.048a.414.414,0,0,1-.55,0L15.278,21.813ZM14.26,37.823V24.23l9.786,8.677a2.9,2.9,0,0,0,3.847,0l9.786-8.677V37.823a.415.415,0,0,1-.414.414H14.674a.415.415,0,0,1-.414-.414Zm6.247,12.984V47.29H44.766a1.242,1.242,0,0,0,0-2.485H28.3V40.722h8.964a2.9,2.9,0,0,0,2.9-2.9v-15.6a2.9,2.9,0,0,0-2.9-2.9H33.952A14.15,14.15,0,0,1,56.607,30.64V44.805H50.668a1.242,1.242,0,0,0,0,2.485h5.939v3.518Z"
                              transform="translate(-11.775 0)"
                            />
                          </svg>
                        </div>
                        <div>รับข่าวสาร</div>
                        <div>ทางจดหมาย</div>

                        <Divider />

                        <div style="margin-bottom:10px">เลือกสถานที่จัดส่ง</div>

                        <Select
                          :disabled="(!formItemTab2.subscribeMail.status)"
                          clearable
                          size="large"
                          v-model="formItemTab2.subscribeMail.value"
                          @on-open-change="letterTo()"
                        >
                          <Option :value="true">ส่งไปที่บริษัท</Option>
                          <Option :value="false">ส่งไปที่บ้าน</Option>
                        </Select>
                      </div>
                    </div>
                  </section>
                  <section
                    class="secction-form"
                    flex="100"
                    flex-md="33"
                    flex-lg="23"
                    flex-gt-lg="18"
                    flex-offset-lg="0"
                    flex-offset-gt-lg="5"
                  >
                    <div
                      :class="(formItemTab2.subscribeEmail.status) ? 'subscribe-box-active' : 'subscribe-box'"
                    >
                      <div layout="column" layout-align="center center">
                        <Checkbox
                          :label="false"
                          size="large"
                          v-model="formItemTab2.subscribeEmail.status"
                          @click.prevent.native="checkVauleSubscribe('email')"
                          style="margin-top: -20px"
                        ></Checkbox>
                        <div class="subscribe-icon" layout="row" layout-align="center center">
                          <svg
                            id="email"
                            xmlns="http://www.w3.org/2000/svg"
                            width="84.851"
                            height="56.567"
                            viewBox="0 0 84.851 56.567"
                          >
                            <g
                              class="a"
                              id="Group_539"
                              data-name="Group 539"
                              transform="translate(0 0)"
                            >
                              <path
                                class="a"
                                id="Path_340"
                                data-name="Path 340"
                                d="M80.5,85.333H4.351A4.364,4.364,0,0,0,0,89.684v47.865A4.364,4.364,0,0,0,4.351,141.9H80.5a4.364,4.364,0,0,0,4.351-4.351V89.684A4.364,4.364,0,0,0,80.5,85.333ZM78.867,88.6,44.929,114.052a4.549,4.549,0,0,1-5.006,0L5.984,88.6ZM60.738,115.731l18.493,22.845c.019.023.041.04.061.061H5.559c.02-.022.042-.038.061-.061l18.493-22.845a1.632,1.632,0,0,0-2.537-2.054L3.263,136.3V90.636l34.7,26.026a7.789,7.789,0,0,0,8.92,0l34.7-26.026V136.3L63.275,113.677a1.632,1.632,0,0,0-2.537,2.054Z"
                                transform="translate(0 -85.333)"
                              />
                            </g>
                          </svg>
                        </div>
                        <div>รับข่าวสาร</div>
                        <div>ทาง E-mail</div>
                      </div>
                    </div>
                  </section>
                  <section
                    class="secction-form"
                    flex="100"
                    flex-md="33"
                    flex-lg="23"
                    flex-gt-lg="18"
                    flex-offset-lg="0"
                    flex-offset-gt-lg="5"
                  >
                    <div
                      :class="(formItemTab2.subscribeSms.status) ? 'subscribe-box-active' : 'subscribe-box'"
                    >
                      <div layout="column" layout-align="center center">
                        <Checkbox
                          :label="false"
                          size="large"
                          v-model="formItemTab2.subscribeSms.status"
                          @click.prevent.native="checkVauleSubscribe('sms')"
                          style="margin-top: -20px"
                        ></Checkbox>
                        <div class="subscribe-icon" layout="row" layout-align="center center">
                          <svg
                            id="email"
                            xmlns="http://www.w3.org/2000/svg"
                            width="84.851"
                            height="56.567"
                            viewBox="0 0 84.851 56.567"
                          >
                            <g
                              class="a"
                              id="Group_539"
                              data-name="Group 539"
                              transform="translate(0 0)"
                            >
                              <path
                                class="a"
                                id="Path_340"
                                data-name="Path 340"
                                d="M80.5,85.333H4.351A4.364,4.364,0,0,0,0,89.684v47.865A4.364,4.364,0,0,0,4.351,141.9H80.5a4.364,4.364,0,0,0,4.351-4.351V89.684A4.364,4.364,0,0,0,80.5,85.333ZM78.867,88.6,44.929,114.052a4.549,4.549,0,0,1-5.006,0L5.984,88.6ZM60.738,115.731l18.493,22.845c.019.023.041.04.061.061H5.559c.02-.022.042-.038.061-.061l18.493-22.845a1.632,1.632,0,0,0-2.537-2.054L3.263,136.3V90.636l34.7,26.026a7.789,7.789,0,0,0,8.92,0l34.7-26.026V136.3L63.275,113.677a1.632,1.632,0,0,0-2.537,2.054Z"
                                transform="translate(0 -85.333)"
                              />
                            </g>
                          </svg>
                        </div>
                        <div>รับข่าวสาร</div>
                        <div>ทาง SMS</div>
                      </div>
                    </div>
                  </section>
                </div>
              </Form>
            </TabPane>

            <TabPane label="ข้อมูลการชำระ" name="tab3">
              <Form
                ref="formValidateTab3"
                :model="formItemTab3"
                :rules="ruleValidateTab3"
                :label-width="150"
                layout="row"
                layout-wrap
                layout-align="center center"
              >
                <section flex="100" flex-md="50" flex-gt-md="30" flex-offset-gt-md="0">
                  <FormItem prop="ContactPayTypeId" label="ประเภทการชำระ" flex="100">
                    <Select
                      clearable
                      size="large"
                      v-model="formItemTab3.ContactPayTypeId"
                      placeholder="เลือกประเภทการชำระ"
                    >
                      <Option :value="1">เครดิต</Option>
                      <Option :value="2">เงินสด</Option>
                    </Select>
                  </FormItem>
                </section>

                <section flex="100" flex-md="50" flex-gt-md="30" flex-offset-gt-md="10">
                  <FormItem prop="VatRateId" label="อัตราภาษี (%)" flex="100">
                    <Select
                      clearable
                      size="large"
                      v-model="formItemTab3.VatRateId"
                      placeholder="เลือกอัตราภาษี (%)"
                      @on-open-change="vatRateFromAPI()"
                    >
                      <Option
                        v-for="(e, index) in getDataVatRate"
                        :key="index"
                        :value="e.Id"
                      >{{e.Name}} ({{e.Cost}})</Option>
                    </Select>
                  </FormItem>
                </section>

                <section
                  flex="100"
                  flex-gt-md="70"
                  layout="row"
                  layout-wrap
                  layout-align="center center"
                >
                  <Divider class="main-divider"></Divider>
                </section>

                <div flex="100" layout="row" layout-align="center center">
                  <section flex="100" flex-md="50" flex-gt-md="30" flex-offset-gt-md="0">
                    <FormItem prop="CreditLimitlabel" label="วงเงินเครดิต" flex="100">
                      <Input disabled size="large" v-model="formItemTab3.CreditLimit"></Input>
                    </FormItem>

                    <FormItem prop="CreditTerm" label="ระยะเวลาชำระ (วัน)" flex="100">
                      <Input disabled size="large" v-model="formItemTab3.CreditTerm"></Input>
                    </FormItem>

                    <FormItem prop="DayBillPay" label="วันที่วางบิล (วัน)" flex="100">
                      <Input disabled size="large" v-model="formItemTab3.DayBillPay"></Input>
                    </FormItem>

                    <FormItem prop="DayReceiveChq" label="วันที่เก็บเช็ค (วัน)" flex="100">
                      <Input disabled size="large" v-model="formItemTab3.DayReceiveChq"></Input>
                    </FormItem>
                  </section>

                  <section flex="100" flex-md="50" flex-gt-md="30" flex-offset-gt-md="10">
                    <FormItem prop="CreditBalance" label="วงเงินคงเหลือ" flex="100">
                      <Input disabled size="large" v-model="formItemTab3.CreditBalance"></Input>
                    </FormItem>

                    <FormItem prop="Overdue" label="ค้างชำระ" flex="100">
                      <Input disabled size="large" v-model="formItemTab3.Overdue"></Input>
                    </FormItem>

                    <FormItem prop="DepositAmount" label="เงินมัดจำ" flex="100">
                      <Input disabled size="large" v-model="formItemTab3.DepositAmount"></Input>
                    </FormItem>
                  </section>
                </div>
              </Form>
            </TabPane>
            <TabPane label="ข้อมูลบริษัท" name="tab4">
              <Form
                ref="formValidateTab4"
                :model="formItemTab4"
                :rules="ruleValidateTab4"
                :label-width="140"
                layout="row"
                layout-wrap
              >
                <section
                  class="secction-form with-border"
                  flex="100"
                  flex-lg="33"
                  flex-gt-lg="30"
                  flex-offset-lg="0"
                  flex-offset-gt-lg="0"
                >
                  <FormItem prop="WorkCompany" label="ชื่อบริษัท" flex="auto">
                    <Input size="large" v-model="formItemTab4.WorkCompany"></Input>
                  </FormItem>

                  <FormItem prop="WorkTypeId" label="ประเภทธุรกิจ" flex="100">
                    <Select
                      clearable
                      size="large"
                      v-model="formItemTab4.WorkTypeId"
                      placeholder="เลือกประเภทธุรกิจ"
                      flex="100"
                      @on-open-change="businesstypeFromAPI()"
                    >
                      <Option
                        v-for="(e, index) in getDataBusinessType"
                        :key="index"
                        :value="e.Id"
                      >{{e.Name}}</Option>
                    </Select>
                  </FormItem>

                  <FormItem prop="WorkPosition" label="ตำแหน่ง" flex="100">
                    <Input size="large" v-model="formItemTab4.WorkPosition"></Input>
                  </FormItem>

                  <FormItem prop="WorkSection" label="แผนก" flex="100">
                    <Input size="large" v-model="formItemTab4.WorkSection"></Input>
                  </FormItem>

                  <FormItem prop="WorkTower" label="หมู่บ้าน/อาคาร" flex="100">
                    <Input size="large" v-model="formItemTab4.WorkTower"></Input>
                  </FormItem>

                  <div flex="100" layout="row">
                    <FormItem prop="WorkNo" label="หมู่ที่" flex="auto">
                      <Input size="large" v-model="formItemTab4.WorkNo"></Input>
                    </FormItem>

                    <FormItem
                      prop="WorkFloor"
                      :label-width="50"
                      label="เลขที่"
                      flex-offset-gt-md="10"
                      flex="50"
                    >
                      <Input size="large" v-model="formItemTab4.WorkFloor"></Input>
                    </FormItem>
                  </div>

                  <FormItem prop="WorkTrog" label="ตรอก" flex="100">
                    <Input size="large" v-model="formItemTab4.WorkTrog"></Input>
                  </FormItem>
                </section>

                <section
                  class="secction-form"
                  flex="100"
                  flex-lg="33"
                  flex-gt-lg="30"
                  flex-offset-lg="0"
                  flex-offset-gt-lg="5"
                >
                  <FormItem prop="WorkSoi" label="ซอย" flex="100">
                    <Input size="large" v-model="formItemTab4.WorkSoi"></Input>
                  </FormItem>

                  <FormItem prop="WorkRoad" label="ถนน" flex="100">
                    <Input size="large" v-model="formItemTab4.WorkRoad"></Input>
                  </FormItem>

                  <FormItem prop="WorkProvinceId" label="จังหวัด" flex="100">
                    <Select
                      filterable
                      clearable
                      size="large"
                      v-model="formItemTab4.WorkProvinceId"
                      placeholder="เลือกจังหวัด"
                      @on-open-change="provinceFromAPI()"
                    >
                      <Option
                        v-for="(e, index) in getDataProvince"
                        :key="index"
                        :value="e.Id"
                      >{{e.Name}}</Option>
                    </Select>
                  </FormItem>

                  <FormItem prop="WorkDistrictId" label="เขต/อำเภอ" flex="100">
                    <Select
                      filterable
                      clearable
                      size="large"
                      v-model="formItemTab4.WorkDistrictId"
                      placeholder="เลือกเขต/อำเภอ"
                      @on-open-change="districtFromAPI()"
                    >
                      <Option
                        v-for="(e, index) in getDataDistrict"
                        :key="index"
                        :value="e.Id"
                      >{{e.Name}}</Option>
                    </Select>
                  </FormItem>

                  <FormItem prop="WorkSubDistrictId" label="แขวง/ตำบล" flex="100">
                    <Select
                      filterable
                      clearable
                      size="large"
                      v-model="formItemTab4.WorkSubDistrictId"
                      placeholder="เลือกแขวง/ตำบล"
                      @on-open-change="subdistrictFromAPI()"
                    >
                      <Option
                        v-for="(e, index) in getDataSubdistrict"
                        :key="index"
                        :value="e.Id"
                      >{{e.Name}}</Option>
                    </Select>
                  </FormItem>

                  <FormItem prop="WorkZipCodeId" label="รหัสไปรษณีย์" flex="100">
                    <Input size="large" v-model="formItemTab4.WorkZipCodeId"></Input>
                  </FormItem>
                </section>

                <section
                  class="secction-form"
                  flex="100"
                  flex-lg="33"
                  flex-gt-lg="30"
                  flex-offset-lg="0"
                  flex-offset-gt-lg="5"
                >
                  <FormItem prop="WorkPhone1" label="โทรศัพท์ 1" flex="100">
                    <Input size="large" v-model="formItemTab4.WorkPhone1"></Input>
                  </FormItem>

                  <FormItem prop="WorkPhone2" label="โทรศัพท์ 2" flex="100">
                    <Input size="large" v-model="formItemTab4.WorkPhone2"></Input>
                  </FormItem>

                  <FormItem prop="WorkPhone3" label="โทรศัพท์ 3" flex="100">
                    <Input size="large" v-model="formItemTab4.WorkPhone3"></Input>
                  </FormItem>

                  <FormItem prop="WorkFax" label="โทรสาร (Fax)" flex="100">
                    <Input size="large" v-model="formItemTab4.WorkFax"></Input>
                  </FormItem>

                  <FormItem prop="WorkMoblie1" label="มือถือ 1" flex="100">
                    <Input size="large" v-model="formItemTab4.WorkMoblie1"></Input>
                  </FormItem>

                  <FormItem prop="WorkMoblie2" label="มือถือ 2" flex="100">
                    <Input size="large" v-model="formItemTab4.WorkMoblie2"></Input>
                  </FormItem>

                  <FormItem prop="WorkMoblie3" label="มือถือ 3" flex="100">
                    <Input size="large" v-model="formItemTab4.WorkMoblie3"></Input>
                  </FormItem>

                  <FormItem prop="WorkEmail" label="E-mail" flex="100">
                    <Input size="large" v-model="formItemTab4.WorkEmail"></Input>
                  </FormItem>
                </section>
              </Form>
            </TabPane>
          </Tabs>
        </Form>

        <div slot="footer">
          <div layout="row" layout-align="center center">
            <Button
              type="primary"
              ghost
              shape="circle"
              size="large"
              @click="handleSubmit('formValidate'); handleSubmitTab1('formValidateTab1');"
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
import dayjs from 'dayjs'
import utc from 'dayjs/plugin/utc'
dayjs.extend(utc)

import HeaderPage from '@/components/HeaderPage'
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
      resloveSlowInput: true,
      componentKey: 0,

      ruleValidate: {
        PrefixId: [{ type: 'number', required: true, message: 'กรุณากรอกข้อมูล', trigger: 'change' }],
        Name: [{ required: true, message: 'กรุณากรอกข้อมูล', trigger: 'blur' }]
      },
      ruleValidateTab1: {
        ContactTypeId: [{ type: 'number', required: true, message: 'กรุณากรอกข้อมูล', trigger: 'change' }],
        BussTypeId: [{ type: 'number', required: true, message: 'กรุณากรอกข้อมูล', trigger: 'change' }],
        ProvinceId: [{ type: 'number', required: true, message: 'กรุณากรอกข้อมูล', trigger: 'change' }],
        DistrictId: [{ type: 'number', required: true, message: 'กรุณากรอกข้อมูล', trigger: 'change' }],
        SubDistrictId: [{ type: 'number', required: true, message: 'กรุณากรอกข้อมูล', trigger: 'change' }]
      },
      ruleValidateTab2: {},
      ruleValidateTab3: {},
      formItem: {
        Code: null,
        PrefixId: null,
        Name: null,
        Active: true
      },
      getDataPrefixName: null,
      getDataCustomerGroup: null,
      getDataBusinessType: null,
      getDataProvince: null,
      getDataDistrict: null,
      getDataSubdistrict: null,
      getDataVatRate: null,
      formItemTab1: {
        ContactTypeId: null,
        CustomerType: null,
        TaxBranch: null,
        TaxBranchNo: null,
        BirthDate: null,
        Sex: null,
        CusContactName: null,
        BussTypeId: null,
        FirstContactDate: null,
        LastContactDate: null,
        CancelAt: null,
        Note: null,
        Address: null,
        AddressNo: null,
        AddressMoo: null,
        Phone: null,
        AddressTrog: null,
        AddressSoi: null,
        AddressRoad: null,
        ProvinceId: null,
        DistrictId: null,
        SubDistrictId: null,
        ZipCodeId: null
      },
      formItemTab2: {
        Phone1: null,
        Phone2: null,
        Phone3: null,
        Fax: null,
        Moblie1: null,
        Moblie2: null,
        Moblie3: null,
        Email: null,
        subscribeMail: {
          status: false,
          value: null
        },
        subscribeEmail: {
          status: null
        },
        subscribeSms: {
          status: null
        },
        NewsSentTypes: null,
        NewsLetterType: null
      },
      formItemTab3: {
        ContactPayTypeId: null,
        VatRateId: null,
        CreditLimit: null,
        CreditTerm: null,
        DayBillPay: null,
        DayReceiveChq: null,
        CreditBalance: null,
        Overdue: null,
        DepositAmount: null
      },
      formItemTab4: {
        WorkCompany: null,
        WorkTypeId: null,
        WorkPosition: null,
        WorkSection: null,
        WorkTower: null,
        WorkNo: null,
        WorkFloor: null,
        WorkTrog: null,
        WorkSoi: null,
        WorkRoad: null,
        WorkProvinceId: null,
        WorkDistrictId: null,
        WorkSubDistrictId: null,
        WorkZipCodeId: null,
        WorkPhone1: null,
        WorkPhone2: null,
        WorkPhone3: null,
        WorkFax: null,
        WorkMoblie1: null,
        WorkMoblie2: null,
        WorkMoblie3: null,
        WorkEmail: null
      },
      modalAddData: false,
      searchBox: null,
      loading: false,
      tableColumns1: [
        {
          title: 'รหัสลูกค้า',
          key: 'Code',
          width: 150,
          align: 'center',
          sortable: true
        },
        {
          title: 'คำนำหน้า',
          key: 'PrefixName',
          width: 150,
          align: 'center',
          sortable: true
        },
        {
          title: 'ชื่อ - นามสกุล',
          key: 'Name',
          minWidth: 200,
          align: 'center',
          sortable: true
        },
        {
          title: 'โทรศัพท์',
          key: 'Phone',
          width: 150,
          align: 'center',
          sortable: true
        },
        {
          title: 'มือถือ',
          key: 'Moblie1',
          width: 150,
          align: 'center',
          sortable: true
        },
        {
          title: 'จังหวัด',
          key: 'ProvinceName',
          width: 200,
          align: 'center',
          sortable: true
        },
        {
          title: 'กลุ่มลูกค้า',
          key: 'ContactTypeName',
          minWidth: 150,
          align: 'center',
          sortable: true
        },
        {
          title: 'สถานะ',
          slot: 'status',
          width: 150,
          align: 'center',
          sortable: true
        },
        {
          title: 'คำสั่ง',
          slot: 'action',
          width: 130,
          fixed: 'right',
          align: 'center'
        }
      ],
      val0: false,
      valTab1: false,
      valTab2: false,
      valTab3: false,
      valTab4: false
    }
  },
  mounted() {
    this.checkPermission()
  },
  methods: {
    debug() {
      let testData = {
        Id: +this.itemID,
        PrefixId: +this.formItem.PrefixId,
              Name: this.formItem.Name,
              TaxId: this.formItem.TaxId,
              Active: this.formItem.Active,

              ContactTypeId: +this.formItemTab1.ContactTypeId,
              CustomerType: this.formItemTab1.CustomerType,
              TaxBranch: this.formItemTab1.TaxBranch,
              TaxBranchNo: this.formItemTab1.TaxBranchNo,
              BirthDate: this.formItemTab1.BirthDate ? dayjs(this.formItemTab1.BirthDate).add(1, 'day').utc().format('YYYY-MM-DDTHH:mm:ss.SSS[Z]'): null,
              Sex: this.formItemTab1.Sex,
              CusContactName: this.formItemTab1.CusContactName,
              BussTypeId: +this.formItemTab1.BussTypeId,
              FirstContactDate: this.formItemTab1.FirstContactDate ? dayjs(this.formItemTab1.FirstContactDate).add(1, 'day').utc().format('YYYY-MM-DDTHH:mm:ss.SSS[Z]'): null,
              LastContactDate: this.formItemTab1.LastContactDate ? dayjs(this.formItemTab1.LastContactDate).add(1, 'day').utc().format('YYYY-MM-DDTHH:mm:ss.SSS[Z]'): null,
              Note: this.formItemTab1.Note,
              Address: this.formItemTab1.Address,
              AddressNo: this.formItemTab1.AddressNo,
              AddressMoo: this.formItemTab1.AddressMoo,
              Phone: this.formItemTab1.Phone,
              AddressTrog: this.formItemTab1.AddressTrog,
              AddressSoi: this.formItemTab1.AddressSoi,
              AddressRoad: this.formItemTab1.AddressRoad,
              ProvinceId: +this.formItemTab1.ProvinceId,
              DistrictId: +this.formItemTab1.DistrictId,
              SubDistrictId: +this.formItemTab1.SubDistrictId,
              ZipCodeId: +this.formItemTab1.ZipCodeId,

              Phone1: this.formItemTab2.Phone1,
              Phone2: this.formItemTab2.Phone2,
              Phone3: this.formItemTab2.Phone3,
              Moblie1: this.formItemTab2.Moblie1,
              Moblie2: this.formItemTab2.Moblie2,
              Moblie3: this.formItemTab2.Moblie3,
              Fax: this.formItemTab2.Fax,
              Email: this.formItemTab2.Email,
              NewsSentTypes: this.formItemTab2.NewsSentTypes,
              NewsLetterType: this.formItemTab2.NewsLetterType,

              ContactPayTypeId: +this.formItemTab3.ContactPayTypeId,
              VatRateId: +this.formItemTab3.VatRateId,
              CreditLimit: this.formItemTab3.CreditLimit,
              CreditTerm: this.formItemTab3.CreditTerm,
              DayBillPay: this.formItemTab3.DayBillPay,
              DayReceiveChq: this.formItemTab3.DayReceiveChq,
              CreditBalance: this.formItemTab3.CreditBalance,
              Overdue: this.formItemTab3.Overdue,
              DepositAmount: this.formItemTab3.DepositAmount,

              WorkCompany: this.formItemTab4.WorkCompany,
              WorkTypeId: ''+this.formItemTab4.WorkTypeId,
              WorkPosition: this.formItemTab4.WorkPosition,
              WorkSection: this.formItemTab4.WorkSection,
              WorkTower: this.formItemTab4.WorkTower,
              WorkNo: this.formItemTab4.WorkNo,
              WorkFloor: this.formItemTab4.WorkFloor,
              WorkTrog: this.formItemTab4.WorkTrog,
              WorkSoi: this.formItemTab4.WorkSoi,
              WorkRoad: this.formItemTab4.WorkRoad,
              WorkProvinceId: +this.formItemTab4.WorkProvinceId,
              WorkDistrictId: +this.formItemTab4.WorkDistrictId,
              WorkSubDistrictId: +this.formItemTab4.WorkSubDistrictId,
              WorkZipCodeId: +this.formItemTab4.WorkZipCodeId,
              WorkPhone1: this.formItemTab4.WorkPhone1,
              WorkPhone2: this.formItemTab4.WorkPhone2,
              WorkPhone3: this.formItemTab4.WorkPhone3,
              WorkMoblie1: this.formItemTab4.WorkMoblie1,
              WorkMoblie2: this.formItemTab4.WorkMoblie2,
              WorkMoblie3: this.formItemTab4.WorkMoblie3,
              WorkFax: this.formItemTab4.WorkFax,
              WorkEmail: this.formItemTab4.WorkEmail
      }
      console.log(testData)
    },
    async vatRateFromAPI() {
      if (this.getDataVatRate == null) {
        console.log('vatRateFromAPI()')

        let apiWithQuery = `${'api/v1/MasterData/vatrate'}`

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

        console.log('vatRateFromAPI()', res)
        let { StatusCode, Resource } = await res

        if (StatusCode == 200) {
          this.getDataVatRate = await res.Resource
        }

        if (res == undefined) {
          await this.reToken()
          await this.vatRateFromAPI()
        }
      }
    },
    async subdistrictFromAPI() {
      if (this.getDataSubdistrict == null) {
        console.log('subdistrictFromAPI()')

        let apiWithQuery = await `${
          'api/v1/MasterData/province/' +
          this.formItemTab1.ProvinceId +
          '/' +
          'district/' +
          this.formItemTab1.DistrictId +
          '/' +
          'subdistrict'
        }`
        console.log(apiWithQuery)

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

        console.log('subdistrictFromAPI', res)
        let { StatusCode, Resource } = await res

        if (StatusCode == 200) {
          this.getDataSubdistrict = await res.Resource
        }

        if (res == undefined) {
          await this.reToken()
          await this.subdistrictFromAPI()
        }
      }
    },
    async districtFromAPI() {
      if (this.getDataDistrict == null) {
        console.log('districtFromAPI()')

        let apiWithQuery = await `${'api/v1/MasterData/province/' + this.formItemTab1.ProvinceId + '/' + 'district'}`
        console.log(apiWithQuery)

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

        console.log('districtFromAPI', res)
        let { StatusCode, Resource } = await res

        if (StatusCode == 200) {
          this.getDataDistrict = await res.Resource
        }

        if (res == undefined) {
          await this.reToken()
          await this.districtFromAPI()
        }
      }
    },
    async provinceFromAPI() {
      if (this.getDataProvince == null) {
        console.log('provinceFromAPI()')

        let apiWithQuery = `${'api/v1/MasterData/province'}`

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

        console.log('provinceFromAPI', res)
        let { StatusCode, Resource } = await res

        if (StatusCode == 200) {
          this.getDataProvince = await res.Resource
        }

        if (res == undefined) {
          await this.reToken()
          await this.provinceFromAPI()
        }
      }
    },
    async businesstypeFromAPI() {
      if (this.getDataBusinessType == null) {
        console.log('businesstypeFromAPI()')

        let apiWithQuery = `${'api/v1/MasterData/bussinesstype'}`

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

        console.log('businesstypeFromAPI()', res)
        let { StatusCode, Resource } = await res

        if (StatusCode == 200) {
          this.getDataBusinessType = await res.Resource
        }

        if (res == undefined) {
          await this.reToken()
          await this.businesstypeFromAPI()
        }
      }
    },
    async customergroupFromAPI() {
      if (this.getDataCustomerGroup == null) {
        console.log('customergroupFromAPI()')

        let apiWithQuery = `${'api/v1/MasterData/contacttype'}`

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

        console.log('customergroupFromAPI()', res)
        let { StatusCode, Resource } = await res

        if (StatusCode == 200) {
          this.getDataCustomerGroup = await res.Resource
        }

        if (res == undefined) {
          await this.reToken()
          await this.customergroupFromAPI()
        }
      }
    },
    async prefixnameFromAPI() {
      if (this.getDataPrefixName == null) {
        console.log('prefixnameFromAPI()')

        let apiWithQuery = `${'api/v1/MasterData/prefix'}`

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

        console.log('prefixnameFromAPI()', res)
        let { StatusCode, Resource } = await res

        if (StatusCode == 200) {
          this.getDataPrefixName = await res.Resource
        }

        if (res == undefined) {
          await this.reToken()
          await this.prefixnameFromAPI()
        }
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
      this.resloveSlowInput = true

      this.prefixnameFromAPI()
      this.customergroupFromAPI()
      this.businesstypeFromAPI()
      this.vatRateFromAPI()
    },
    closeModalAdd() {
      this.modalAddData = false
      this.resloveSlowInput = false

      if (this.modeEdit) {
        this.clearFormItem()
      }
    },
    openModalEdit() {
      this.modalAddData = true
      this.resloveSlowInput = true

      this.prefixnameFromAPI()
      this.customergroupFromAPI()
      this.businesstypeFromAPI()
      this.vatRateFromAPI()

      if (this.modeEdit) {
        this.provinceFromAPI()
        setTimeout(() => {
          this.districtFromAPI()
          this.subdistrictFromAPI()
        }, 300)
      }
    },
    async editData(id) {
      this.itemID = id
      let apiWithQuery = `${'api/v1/Customer/' + id + '?pageType='}`

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

        this.formItem.Code = Resource.Code
        this.formItem.PrefixId = Resource.PrefixId
        this.formItem.Name = Resource.Name
        this.formItem.TaxId = Resource.TaxId

        this.formItemTab1.ContactTypeId = Resource.ContactTypeId
        this.formItemTab1.CustomerType = Resource.CustomerType
        this.formItemTab1.TaxBranch = Resource.TaxBranch
        this.formItemTab1.TaxBranchNo = Resource.TaxBranchNo
        this.formItemTab1.BirthDate = Resource.BirthDate
        this.formItemTab1.Sex = Resource.Sex
        this.formItemTab1.CusContactName = Resource.CusContactName
        this.formItemTab1.BussTypeId = Resource.BussTypeId
        this.formItemTab1.FirstContactDate = Resource.FirstContactDate
        this.formItemTab1.LastContactDate = Resource.LastContactDate
        this.formItemTab1.CancelAt = Resource.CancelAt
        this.formItemTab1.Note = Resource.Note
        this.formItemTab1.Address = Resource.Address
        this.formItemTab1.AddressNo = Resource.AddressNo
        this.formItemTab1.AddressMoo = Resource.AddressMoo
        this.formItemTab1.Phone = Resource.Phone
        this.formItemTab1.AddressTrog = Resource.AddressTrog
        this.formItemTab1.AddressSoi = Resource.AddressSoi
        this.formItemTab1.AddressRoad = Resource.AddressRoad
        this.formItemTab1.ProvinceId = Resource.ProvinceId
        this.formItemTab1.DistrictId = Resource.DistrictId
        this.formItemTab1.SubDistrictId = Resource.SubDistrictId
        this.formItemTab1.ZipCodeId = Resource.ZipCodeId

        this.formItemTab2.Phone1 = Resource.Phone1
        this.formItemTab2.Phone2 = Resource.Phone2
        this.formItemTab2.Phone3 = Resource.Phone3
        this.formItemTab2.Moblie1 = Resource.Moblie1
        this.formItemTab2.Moblie2 = Resource.Moblie2
        this.formItemTab2.Moblie3 = Resource.Moblie3
        this.formItemTab2.Fax = Resource.Fax
        this.formItemTab2.Email = Resource.Email
        this.formItemTab2.NewsSentTypes = Resource.NewsSentTypes
        this.formItemTab2.NewsLetterType = Resource.NewsLetterType
        if (Resource.NewsSentTypes == 0) {
          this.formItemTab2.subscribeMail.status = true
        }
        if (Resource.NewsLetterType == true) {
          this.formItemTab2.subscribeMail.value = true
        }

        this.formItemTab3.ContactPayTypeId = Resource.ContactPayTypeId
        this.formItemTab3.VatRateId = Resource.VatRateId
        this.formItemTab3.CreditLimit = Resource.CreditLimit
        this.formItemTab3.CreditTerm = Resource.CreditTerm
        this.formItemTab3.DayBillPay = Resource.DayBillPay
        this.formItemTab3.DayReceiveChq = Resource.DayReceiveChq
        this.formItemTab3.CreditBalance = Resource.CreditBalance
        this.formItemTab3.Overdue = Resource.Overdue
        this.formItemTab3.DepositAmount = Resource.DepositAmount
        this.formItemTab3.VatRateId = Resource.VatRateId

        this.formItemTab4.WorkCompany = Resource.WorkCompany
        this.formItemTab4.WorkTypeId = +Resource.WorkTypeId
        this.formItemTab4.WorkPosition = Resource.WorkPosition
        this.formItemTab4.WorkSection = Resource.WorkSection
        this.formItemTab4.WorkTower = Resource.WorkTower
        this.formItemTab4.WorkNo = Resource.WorkNo
        this.formItemTab4.WorkFloor = Resource.WorkFloor
        this.formItemTab4.WorkTrog = Resource.WorkTrog
        this.formItemTab4.WorkSoi = Resource.WorkSoi
        this.formItemTab4.WorkRoad = Resource.WorkRoad
        this.formItemTab4.WorkProvinceId = Resource.WorkProvinceId
        this.formItemTab4.WorkDistrictId = Resource.WorkDistrictId
        this.formItemTab4.WorkSubDistrictId = Resource.WorkSubDistrictId
        this.formItemTab4.WorkZipCodeId = Resource.WorkZipCodeId
        this.formItemTab4.WorkPhone1 = Resource.WorkPhone1
        this.formItemTab4.WorkPhone2 = Resource.WorkPhone2
        this.formItemTab4.WorkPhone3 = Resource.WorkPhone3
        this.formItemTab4.WorkMoblie1 = Resource.WorkMoblie1
        this.formItemTab4.WorkMoblie2 = Resource.WorkMoblie2
        this.formItemTab4.WorkMoblie3 = Resource.WorkMoblie3
        this.formItemTab4.WorkFax = Resource.WorkFax
        this.formItemTab4.WorkEmail = Resource.WorkEmail

        this.openModalEdit()
      }

      if (res == undefined) {
        await this.reToken()
        await this.editData(id)
      }
    },
    async saveData() {
      this.$refs.dataTable.loading = true
      let apiUrl = `api/v1/Customer`
      let apiEditMode = `${'api/v1/Customer'}`

      if (this.modeEdit == false) {
        let res = await this.$axios
          .$post(
            `${apiUrl}`,
            {
              PrefixId: +this.formItem.PrefixId,
              Name: this.formItem.Name,
              TaxId: this.formItem.TaxId,
              Active: this.formItem.Active,

              ContactTypeId: +this.formItemTab1.ContactTypeId,
              CustomerType: this.formItemTab1.CustomerType,
              TaxBranch: this.formItemTab1.TaxBranch,
              TaxBranchNo: this.formItemTab1.TaxBranchNo,
              BirthDate: this.formItemTab1.BirthDate ? dayjs(this.formItemTab1.BirthDate).add(1, 'day').utc().format('YYYY-MM-DDTHH:mm:ss.SSS[Z]'): null,
              Sex: this.formItemTab1.Sex,
              CusContactName: this.formItemTab1.CusContactName,
              BussTypeId: +this.formItemTab1.BussTypeId,
              FirstContactDate: this.formItemTab1.FirstContactDate ? dayjs(this.formItemTab1.FirstContactDate).add(1, 'day').utc().format('YYYY-MM-DDTHH:mm:ss.SSS[Z]'): null,
              LastContactDate: this.formItemTab1.LastContactDate ? dayjs(this.formItemTab1.LastContactDate).add(1, 'day').utc().format('YYYY-MM-DDTHH:mm:ss.SSS[Z]'): null,
              Note: this.formItemTab1.Note,
              Address: this.formItemTab1.Address,
              AddressNo: this.formItemTab1.AddressNo,
              AddressMoo: this.formItemTab1.AddressMoo,
              Phone: this.formItemTab1.Phone,
              AddressTrog: this.formItemTab1.AddressTrog,
              AddressSoi: this.formItemTab1.AddressSoi,
              AddressRoad: this.formItemTab1.AddressRoad,
              ProvinceId: +this.formItemTab1.ProvinceId,
              DistrictId: +this.formItemTab1.DistrictId,
              SubDistrictId: +this.formItemTab1.SubDistrictId,
              ZipCodeId: +this.formItemTab1.ZipCodeId,

              Phone1: this.formItemTab2.Phone1,
              Phone2: this.formItemTab2.Phone2,
              Phone3: this.formItemTab2.Phone3,
              Moblie1: this.formItemTab2.Moblie1,
              Moblie2: this.formItemTab2.Moblie2,
              Moblie3: this.formItemTab2.Moblie3,
              Fax: this.formItemTab2.Fax,
              Email: this.formItemTab2.Email,
              NewsSentTypes: this.formItemTab2.NewsSentTypes,
              NewsLetterType: this.formItemTab2.NewsLetterType,

              ContactPayTypeId: +this.formItemTab3.ContactPayTypeId,
              VatRateId: +this.formItemTab3.VatRateId,
              CreditLimit: this.formItemTab3.CreditLimit,
              CreditTerm: this.formItemTab3.CreditTerm,
              DayBillPay: this.formItemTab3.DayBillPay,
              DayReceiveChq: this.formItemTab3.DayReceiveChq,
              CreditBalance: this.formItemTab3.CreditBalance,
              Overdue: this.formItemTab3.Overdue,
              DepositAmount: this.formItemTab3.DepositAmount,

              WorkCompany: this.formItemTab4.WorkCompany,
              WorkTypeId: ''+this.formItemTab4.WorkTypeId,
              WorkPosition: this.formItemTab4.WorkPosition,
              WorkSection: this.formItemTab4.WorkSection,
              WorkTower: this.formItemTab4.WorkTower,
              WorkNo: this.formItemTab4.WorkNo,
              WorkFloor: this.formItemTab4.WorkFloor,
              WorkTrog: this.formItemTab4.WorkTrog,
              WorkSoi: this.formItemTab4.WorkSoi,
              WorkRoad: this.formItemTab4.WorkRoad,
              WorkProvinceId: +this.formItemTab4.WorkProvinceId,
              WorkDistrictId: +this.formItemTab4.WorkDistrictId,
              WorkSubDistrictId: +this.formItemTab4.WorkSubDistrictId,
              WorkZipCodeId: +this.formItemTab4.WorkZipCodeId,
              WorkPhone1: this.formItemTab4.WorkPhone1,
              WorkPhone2: this.formItemTab4.WorkPhone2,
              WorkPhone3: this.formItemTab4.WorkPhone3,
              WorkMoblie1: this.formItemTab4.WorkMoblie1,
              WorkMoblie2: this.formItemTab4.WorkMoblie2,
              WorkMoblie3: this.formItemTab4.WorkMoblie3,
              WorkFax: this.formItemTab4.WorkFax,
              WorkEmail: this.formItemTab4.WorkEmail
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
              Id: +this.itemID,
              PrefixId: +this.formItem.PrefixId,
              Name: this.formItem.Name,
              TaxId: this.formItem.TaxId,
              Active: this.formItem.Active,

              ContactTypeId: +this.formItemTab1.ContactTypeId,
              CustomerType: this.formItemTab1.CustomerType,
              TaxBranch: this.formItemTab1.TaxBranch,
              TaxBranchNo: this.formItemTab1.TaxBranchNo,
              BirthDate: this.formItemTab1.BirthDate ? dayjs(this.formItemTab1.BirthDate).add(1, 'day').utc().format('YYYY-MM-DDTHH:mm:ss.SSS[Z]'): null,
              Sex: this.formItemTab1.Sex,
              CusContactName: this.formItemTab1.CusContactName,
              BussTypeId: +this.formItemTab1.BussTypeId,
              FirstContactDate: this.formItemTab1.FirstContactDate ? dayjs(this.formItemTab1.FirstContactDate).add(1, 'day').utc().format('YYYY-MM-DDTHH:mm:ss.SSS[Z]'): null,
              LastContactDate: this.formItemTab1.LastContactDate ? dayjs(this.formItemTab1.LastContactDate).add(1, 'day').utc().format('YYYY-MM-DDTHH:mm:ss.SSS[Z]'): null,
              Note: this.formItemTab1.Note,
              Address: this.formItemTab1.Address,
              AddressNo: this.formItemTab1.AddressNo,
              AddressMoo: this.formItemTab1.AddressMoo,
              Phone: this.formItemTab1.Phone,
              AddressTrog: this.formItemTab1.AddressTrog,
              AddressSoi: this.formItemTab1.AddressSoi,
              AddressRoad: this.formItemTab1.AddressRoad,
              ProvinceId: +this.formItemTab1.ProvinceId,
              DistrictId: +this.formItemTab1.DistrictId,
              SubDistrictId: +this.formItemTab1.SubDistrictId,
              ZipCodeId: +this.formItemTab1.ZipCodeId,

              Phone1: this.formItemTab2.Phone1,
              Phone2: this.formItemTab2.Phone2,
              Phone3: this.formItemTab2.Phone3,
              Moblie1: this.formItemTab2.Moblie1,
              Moblie2: this.formItemTab2.Moblie2,
              Moblie3: this.formItemTab2.Moblie3,
              Fax: this.formItemTab2.Fax,
              Email: this.formItemTab2.Email,
              NewsSentTypes: this.formItemTab2.NewsSentTypes,
              NewsLetterType: this.formItemTab2.NewsLetterType,

              ContactPayTypeId: +this.formItemTab3.ContactPayTypeId,
              VatRateId: +this.formItemTab3.VatRateId,
              CreditLimit: this.formItemTab3.CreditLimit,
              CreditTerm: this.formItemTab3.CreditTerm,
              DayBillPay: this.formItemTab3.DayBillPay,
              DayReceiveChq: this.formItemTab3.DayReceiveChq,
              CreditBalance: this.formItemTab3.CreditBalance,
              Overdue: this.formItemTab3.Overdue,
              DepositAmount: this.formItemTab3.DepositAmount,

              WorkCompany: this.formItemTab4.WorkCompany,
              WorkTypeId: ''+this.formItemTab4.WorkTypeId,
              WorkPosition: this.formItemTab4.WorkPosition,
              WorkSection: this.formItemTab4.WorkSection,
              WorkTower: this.formItemTab4.WorkTower,
              WorkNo: this.formItemTab4.WorkNo,
              WorkFloor: this.formItemTab4.WorkFloor,
              WorkTrog: this.formItemTab4.WorkTrog,
              WorkSoi: this.formItemTab4.WorkSoi,
              WorkRoad: this.formItemTab4.WorkRoad,
              WorkProvinceId: +this.formItemTab4.WorkProvinceId,
              WorkDistrictId: +this.formItemTab4.WorkDistrictId,
              WorkSubDistrictId: +this.formItemTab4.WorkSubDistrictId,
              WorkZipCodeId: +this.formItemTab4.WorkZipCodeId,
              WorkPhone1: this.formItemTab4.WorkPhone1,
              WorkPhone2: this.formItemTab4.WorkPhone2,
              WorkPhone3: this.formItemTab4.WorkPhone3,
              WorkMoblie1: this.formItemTab4.WorkMoblie1,
              WorkMoblie2: this.formItemTab4.WorkMoblie2,
              WorkMoblie3: this.formItemTab4.WorkMoblie3,
              WorkFax: this.formItemTab4.WorkFax,
              WorkEmail: this.formItemTab4.WorkEmail,
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
    letterTo() {
      this.formItemTab2.NewsLetterType = this.formItemTab2.subscribeMail.value
    },
    checkVauleSubscribe(type) {
      if (type == 'mail') {
        this.formItemTab2.NewsSentTypes = 1
        this.formItemTab2.subscribeMail.status = !this.formItemTab2.subscribeMail.status
        if (this.formItemTab2.subscribeMail.status == true) {
          this.formItemTab2.subscribeEmail.status = false
          this.formItemTab2.subscribeSms.status = false
        }
      }

      if (type == 'email') {
        this.formItemTab2.NewsSentTypes = 2
        this.formItemTab2.NewsLetterType = null
        this.formItemTab2.subscribeEmail.status = !this.formItemTab2.subscribeEmail.status
        if (this.formItemTab2.subscribeEmail.status == true) {
          this.formItemTab2.subscribeMail.status = false
          this.formItemTab2.subscribeSms.status = false

          this.formItemTab2.subscribeMail.value = ''
        }
      }

      if (type == 'sms') {
        this.formItemTab2.NewsSentTypes = 3
        this.formItemTab2.NewsLetterType = null
        this.formItemTab2.subscribeSms.status = !this.formItemTab2.subscribeSms.status
        if (this.formItemTab2.subscribeSms.status == true) {
          this.formItemTab2.subscribeMail.status = false
          this.formItemTab2.subscribeEmail.status = false

          this.formItemTab2.subscribeMail.value = ''
        }
      }
    },
    async clearFormItem() {
      this.formItem.code = null
      this.formItem.positionId = ''
      this.formItem.active = false
      this.formItem.password = ''
      this.formItem.loginName = null
      this.formItem.employeeType = null
      this.formItem.salaryPerDay = null
      this.formItem.firstName = null
      this.formItem.lastName = null
      this.formItem.nickName = null
      this.formItem.idCard = null
      this.formItem.registerDate = null
      this.formItem.expireDate = null
      this.formItem.birthDate = null
      this.formItem.blood = null
      this.formItem.address = null
      this.formItem.addressNo = null
      this.formItem.addressMoo = null
      this.formItem.addressTrog = null
      this.formItem.addressRoad = null
      this.formItem.provinceId = ''
      this.formItem.districtId = ''
      this.formItem.subDistrictId = ''
      this.formItem.zipCodeId = null
      this.formItem.phone = null
      this.formItem.email = null
    },
    handleSubmit(name) {
      this.$refs[name].validate(valid => {
        if (valid) {
          this.val0 = true

          if (this.val0 && this.valTab1) {
            this.saveData()
          }
        } else {
          this.$Message.error('มีบางอย่างผิดพลาด!')
          this.val0 = false
        }
      })
    },
    handleSubmitTab1(name) {
      this.$refs[name].validate(valid => {
        if (valid) {
          this.valTab1 = true

          if (this.val0 && this.valTab1) {
            this.saveData()
          }
        } else {
          this.$Message.error('มีบางอย่างผิดพลาด!')
          this.valTab2 = false
        }
      })
    }
  }
}
</script>

<style lang="scss" scoped>
.second-label {
  margin: 5px 10px 0px 15px;
}

.subscribe-box,
.subscribe-box-active {
  border-radius: 10px;
  font-size: $fontSize-1;
  padding: 0 15px 40px 15px;
  height: 350px;

  .subscribe-icon {
    min-width: 85px;
    min-height: 85px;
    margin: 15px 0px;
  }
}

.subscribe-box-active {
  background-color: $color_font-main;
  border: 2px solid $color_font-main;
  color: $color_font-1;

  .a {
    fill: #f9f9f9;
  }
  .no-fill {
    .a {
      fill: none;
      stroke: #f9f9f9;
    }
  }
}

.subscribe-box {
  border: 2px solid $color_font-2;
  color: $color_font-2;

  .a {
    fill: #9c9c9c;
  }
  .no-fill {
    .a {
      fill: none;
      stroke: #9c9c9c;
    }
  }

  .ivu-divider {
    background: rgba($color_font-2, 0.5);
  }
}
</style>