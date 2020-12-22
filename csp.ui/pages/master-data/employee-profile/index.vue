<template>
  <div class="component-wrapper">
    <!-- <div>menuID {{menuID}}</div>
    <div>cPermisson {{cPermisson}}</div>
    <div>ePermisson {{ePermisson}}</div>
    <div>vPermisson {{vPermisson}}</div>
    <div>dPermisson {{dPermisson}}</div>
    <div>pPermisson {{pPermisson}}</div>-->

    <HeaderPage>
      ทะเบียนพนักงาน {{formItem.field22}}
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
        <content-placeholders-heading/>
        <content-placeholders-text :lines="4" />
      </content-placeholders>
    </div>
    <section v-if="vPermisson">
      <DataTable
        :key="componentKey"
        :table-columns="tableColumns1"
        api-end-point="User"
        ref="dataTable"
        :mode-search="modeSearch"
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
        <!-- <button @click="debug()">debug</button> -->

        <p slot="header">
          <span>เพิ่มข้อมูลพนักงาน</span>
        </p>

        <Form
          ref="formValidate"
          :model="formItem"
          :rules="ruleValidate"
          layout="row"
          layout-wrap
          :label-width="130"
        >
          <section layout="row" flex="100">
            <FormItem
              label="รหัสพนักงาน"
              flex-xs="100"
              flex-sm="100"
              flex-md="100"
              flex-gt-md="30"
              flex-offset-gt-md="0"
            >
              <Input disabled size="large" v-model="formItem.code" placeholder="username"></Input>
            </FormItem>

            <FormItem
              prop="positionId"
              label="ตำแหน่ง/หน้าที่"
              flex-xs="100"
              flex-sm="100"
              flex-md="100"
              flex-gt-md="30"
              flex-offset-gt-md="5"
            >
              <Select
                filterable
                clearable
                size="large"
                v-model="formItem.positionId"
                placeholder="กรุณาเลือกตำแหน่งพนักงาน"
                @on-open-change="positionFromAPI()"
              >
                <Option v-for="(e, index) in getDataPosition" :key="index" :value="e.Id">{{e.Name}}</Option>
              </Select>
            </FormItem>

            <FormItem
              flex-xs="100"
              flex-sm="100"
              flex-md="100"
              flex-gt-md="30"
              flex-offset-gt-md="5"
              label="สถานะการใช้งาน"
            >
              <div layout="row" layout-align="end center">
                <i-switch size="large" v-model="formItem.active">
                  <span slot="open">อนุญาต</span>
                  <span slot="close">ไม่อนุญาต</span>
                </i-switch>
              </div>
            </FormItem>
          </section>

          <section layout="row" flex="100">
            <FormItem
              prop="loginName"
              label="User Login"
              flex-xs="100"
              flex-sm="100"
              flex-md="100"
              flex-gt-md="30"
              flex-offset-gt-md="0"
            >
              <Input size="large" v-model="formItem.loginName"></Input>
            </FormItem>

            <FormItem
              prop="password"
              label="รหัสผ่าน"
              flex-xs="100"
              flex-sm="100"
              flex-md="100"
              flex-gt-md="30"
              flex-offset-gt-md="5"
            >
              <Input type="password" size="large" v-model="formItem.password"></Input>
            </FormItem>

            <FormItem
              prop="checkPassword"
              label="ยืนยันรหัสผ่าน"
              flex-xs="100"
              flex-sm="100"
              flex-md="100"
              flex-gt-md="30"
              flex-offset-gt-md="5"
            >
              <Input type="password" size="large" v-model="formItem.checkPassword"></Input>
            </FormItem>
          </section>

          <section layout="row" flex="100">
            <FormItem
              label="รูปแบบ"
              flex-xs="100"
              flex-sm="100"
              flex-md="100"
              flex-gt-md="30"
              flex-offset-gt-md="0"
            >
              <RadioGroup size="large" v-model="formItem.employeeType">
                <Radio :label="true">Full time</Radio>
                <Radio :label="false">Part time</Radio>
              </RadioGroup>
            </FormItem>

            <FormItem
              v-if="formItem.employeeType == true"
              label="ค่าแรง/เงินเดือน"
              flex-xs="100"
              flex-sm="100"
              flex-md="100"
              flex-gt-md="30"
              flex-offset-gt-md="5"
            >
              <InputNumber
                disabled
                size="large"
                v-model="salaryPerMonth"
                :formatter="value => `${value}`.replace(/\B(?=(\d{3})+(?!\d))/g, ',')"
                :parser="value => value.replace(/\s?|(,*)/g, '')"
              >
                <span slot="append">ต่อเดือน</span>
              </InputNumber>
            </FormItem>

            <FormItem
              v-if="formItem.employeeType != null"
              label="ค่าแรง/รายวัน"
              flex-xs="100"
              flex-sm="100"
              flex-md="100"
              flex-gt-md="30"
              flex-offset-gt-md="5"
            >
              <InputNumber
                size="large"
                v-model="formItem.salaryPerDay"
                :formatter="value => `${value}`.replace(/\B(?=(\d{3})+(?!\d))/g, ',')"
                :parser="value => value.replace(/\s?|(,*)/g, '')"
              >
                <span slot="append">ต่อวัน</span>
              </InputNumber>
            </FormItem>
          </section>

          <section layout="row" flex="100"></section>

          <Divider class="main-divider" />

          <section
            layout="column"
            flex-xs="100"
            flex-sm="100"
            flex-md="100"
            flex-gt-md="30"
            flex-offset-gt-md="0"
          >
            <FormItem prop="firstName" label="ชื่อพนักงาน" flex="100">
              <Input size="large" v-model="formItem.firstName"></Input>
            </FormItem>

            <FormItem prop="lastName" label="นามสกุล" flex="100">
              <Input size="large" v-model="formItem.lastName"></Input>
            </FormItem>

            <FormItem prop="nickName" label="ชื่อเล่น" flex="100">
              <Input size="large" v-model="formItem.nickName"></Input>
            </FormItem>

            <FormItem prop="idCard" label="เลขบัตรประชาชน" flex="100">
              <Input size="large" v-model="formItem.idCard"></Input>
            </FormItem>

            <FormItem prop="registerDate" label="วันที่ออกบัตร" flex="100">
              <DatePicker
                size="large"
                type="date"
                placeholder="เลือกวันที่ออกบัตร"
                v-model="formItem.registerDate"
              ></DatePicker>
            </FormItem>

            <FormItem prop="expireDate" label="วันบัตรหมดอายุ" flex="100">
              <DatePicker
                size="large"
                type="date"
                placeholder="เลือกวันบัตรหมดอายุ"
                v-model="formItem.expireDate"
              ></DatePicker>
            </FormItem>
          </section>

          <section
            layout="column"
            flex-xs="100"
            flex-sm="100"
            flex-md="100"
            flex-gt-md="30"
            flex-offset-gt-md="5"
          >
            <FormItem prop="birthDate" label="วัน/เดือน/ปี เกิด" flex="100">
              <DatePicker
                size="large"
                type="date"
                placeholder="วัน/เดือน/ปี เกิด"
                v-model="formItem.birthDate"
              ></DatePicker>
            </FormItem>

            <FormItem label="กรุ๊ปเลือด" flex="100">
              <Select clearable size="large" v-model="formItem.blood" placeholder="เลือกกรุ๊ปเลือด">
                <Option :value="0">A</Option>
                <Option :value="1">B</Option>
                <Option :value="2">O</Option>
                <Option :value="3">AB</Option>
              </Select>
            </FormItem>
            <!-- 0 = a
            1 = b
            2 = ab
            3 = o-->

            <FormItem label="หมู่บ้าน/อาคาร" flex="100">
              <Input size="large" v-model="formItem.address"></Input>
            </FormItem>

            <div flex="100" layout="row">
              <FormItem label="เลขที่" flex="auto">
                <Input size="large" v-model="formItem.addressNo"></Input>
              </FormItem>

              <FormItem
                prop="addressMoo"
                :label-width="50"
                label-position="right"
                label="หมู่ที่"
                flex-offset-gt-md="10"
                flex="50"
              >
                <Input size="large" v-model="formItem.addressMoo"></Input>
              </FormItem>
            </div>

            <FormItem label="ตรอก" flex="100">
              <Input size="large" v-model="formItem.addressTrog"></Input>
            </FormItem>

            <FormItem label="ถนน" flex="100">
              <Input size="large" v-model="formItem.addressRoad"></Input>
            </FormItem>
          </section>

          <section
            layout="column"
            flex-xs="100"
            flex-sm="100"
            flex-md="100"
            flex-gt-md="30"
            flex-offset-gt-md="5"
          >
            <FormItem prop="provinceId" label="จังหวัด" flex="100">
              <Select
                filterable
                clearable
                size="large"
                v-model="formItem.provinceId"
                placeholder="เลือกจังหวัด"
                @on-open-change="provinceFromAPI()"
              >
                <Option v-for="(e, index) in getDataProvince" :key="index" :value="e.Id">{{e.Name}}</Option>
              </Select>
            </FormItem>
            <FormItem prop="districtId" label="เขต/อำเภอ" flex="100">
              <Select
                filterable
                :disabled="formItem.provinceId == ''"
                clearable
                size="large"
                v-model="formItem.districtId"
                placeholder="เลือกเขต/อำเภอ"
                @on-open-change="districtFromAPI()"
              >
                <Option v-for="(e, index) in getDataDistrict" :key="index" :value="e.Id">{{e.Name}}</Option>
              </Select>
            </FormItem>

            <FormItem prop="subDistrictId" label="แขวง/ตำบล" flex="100">
              <Select
                filterable
                :disabled="formItem.districtId == ''"
                clearable
                size="large"
                v-model="formItem.subDistrictId"
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

            <FormItem prop="zipCodeId" label="รหัสไปรษณีย์" flex="100">
              <InputNumber size="large" v-model="formItem.zipCodeId"></InputNumber>
            </FormItem>

            <FormItem prop="phone" label="หมายเลขติดต่อ" flex="100">
              <Input size="large" v-model="formItem.phone"></Input>
            </FormItem>

            <FormItem prop="email" label="E-mail" flex="100">
              <Input size="large" v-model="formItem.email"></Input>
            </FormItem>
          </section>
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
    const validatePass = (rule, value, callback) => {
      if (value === '') {
        callback(new Error('กรุณากรอกข้อมูล รหัสผ่าน'))
      } else if (value) {
        Function.debounce(
          setTimeout(() => {
            let re2 = /^(?=.*\d)(?=.*[a-zA-Zกขฃคฅฆงจฉชซฌญฎฏฐฑฒณดตถทธนบปผฝพฟภมยรฤลฦวศษสหฬอฮฯะัาำิีึืฺุูเแโใไๅๆ็่้๊๋์]).{6,15}$/
            let data2 = re2.test(value)
            if (data2 == false) {
              callback(new Error('ต้องมีตัวเลขและตัวอักษร รวมกันอย่างน้อย 6-15 ตัว'))
            } else {
              callback()
            }
          }, 0),
          500
        )
      } else {
        callback()
        
        if (this.formItem.passwdCheck !== '') {
          this.$refs.formValidate.validateField('passwdCheck')
        }
      }
    }

    const validatePassCheck = (rule, value, callback) => {
      if (value === '') {
        callback(new Error('กรุณากรอกข้อมูล ยืนยันรหัสผ่าน'))
      } else if (value !== this.formItem.password) {
        callback(new Error('รหัสผ่านไม่ตรงกัน!'))
      } else {
        callback()
      }
    }
    const validateText = (rule, value, callback) => {
      let re = /[^A-Za-zกขฃคฅฆงจฉชซฌญฎฏฐฑฒณดตถทธนบปผฝพฟภมยรฤลฦวศษสหฬอฮฯะัาำิีึืฺุูเแโใไๅๆ็่้๊๋์]+/g
      let data =  re.test(value)
      if (value === '') {
        callback(new Error('กรุณากรอกข้อมูล รหัสผ่าน'))
      } else {
        callback()
      }
    }

    const validatePhone = (rule, value, callback) => {
      if (!value) {
        return callback(new Error('กรุณากรอกข้อมูล"'))
      } else if (value) {
        Function.debounce(setTimeout(() => {
        let re = /[0-9]/
        let data = re.test(Number(value))
        if (data == false) {
          callback(new Error('เฉพาะตัวเลขเท่านั้น ห้ามมีอักขระ'))
        } else {
          let re2 = /^[0]{0,1}[0-9]{8,9}$/g
          let data2 = re2.test(Number(value))
          if (data2 == false) {
            callback(new Error('หมายเลขติดต่อไม่ถูกต้อง'))
          } else {
            callback()
          }
        }
      }, 0), 500)
      } else {
        callback()
      }
    }

    const validateIdCard = (rule, value, callback) => {
      if (!value) {
        return callback(new Error('กรุณากรอกข้อมูล"'))
      } else if (value) {
        Function.debounce(setTimeout(() => {
        let re = /[0-9]/
        let data = re.test(Number(value))
        if (data == false) {
          callback(new Error('เฉพาะตัวเลขเท่านั้น ห้ามมีอักขระ'))
        } else {
          let re2 = /^[[0-9]{13,13}$/g
          let data2 = re2.test(Number(value))
          if (data2 == false) {
            callback(new Error('เลขบัตรประชาชนต้องมี 13 ตัว'))
          } else {
            callback()
          }
        }
      }, 0), 500)
      } else {
        callback()
      }
    }

    const validateZipCode = (rule, value, callback) => {
      if (!value) {
        return callback(new Error('กรุณากรอกข้อมูล"'))
      } else if (value) {
        Function.debounce(setTimeout(() => {
        let re = /[0-9]/
        let data = re.test(Number(value))
        if (data == false) {
          callback(new Error('เฉพาะเบอร์โทรเท่านั้น ห้ามมีอักขระ'))
        } else {
          let re2 = /^[0-9]{5,5}$/g
          let data2 = re2.test(Number(value))
          if (data2 == false) {
            callback(new Error('รหัสไปรษณีย์ไม่ถูกต้อง'))
          } else {
            callback()
          }
        }
      }, 0), 500)
      } else {
        callback()
      }
    }

    return {
      userID: null,
      modeEdit: false,
      modeSearch: false,
      MasterPermisson: null,
      loading: false,
      modalAddData: false,
      resloveSlowInput: true,
      componentKey: 0,

      formItem: {
        code: null,
        positionId: '',
        active: false,
        loginName: null,
        password: '',
        checkPassword: '',
        employeeType: null,
        salaryPerDay: 0,
        firstName: null,
        lastName: null,
        nickName: null,
        idCard: null,
        registerDate: null,
        expireDate: null,
        birthDate: null,
        blood: null,
        address: null,
        addressNo: null,
        addressMoo: null,
        addressTrog: null,
        addressRoad: null,
        provinceId: '',
        districtId: '',
        subDistrictId: '',
        zipCodeId: null,
        phone: null,
        email: null
      },
      getDataPosition: null,
      getDataProvince: null,
      getDataDistrict: null,
      getDataSubdistrict: null,
      ruleValidate: {
        positionId: [{ type: 'number', required: true, message: 'กรุณากรอกข้อมูล', trigger: 'change' }],
        loginName: [{ required: true, message: 'กรุณากรอกข้อมูล', trigger: 'blur' }],
        password: [{ validator: validatePass, trigger: 'blur' }],
        checkPassword: [{ validator: validatePassCheck, trigger: 'blur' }],
        provinceId: [{ type: 'number', required: true, message: 'กรุณากรอกข้อมูล', trigger: 'change' }],
        districtId: [{ type: 'number', required: true, message: 'กรุณากรอกข้อมูล', trigger: 'change' }],
        subDistrictId: [{ type: 'number', required: true, message: 'กรุณากรอกข้อมูล', trigger: 'change' }],
        email: [{ type: 'email', message: 'รูปแบบ E-mail ไม่ถูกต้อง', trigger: 'blur' }],
        zipCodeId: [{ validator: validateZipCode, trigger: 'blur' }],
        phone: [{ validator: validatePhone, trigger: 'blur' }],
        idCard: [{ validator: validateIdCard, trigger: 'blur' }],
      },
      tableColumns1: [
        {
          title: 'รหัสพนักงาน',
          key: 'Code',
          minWidth : 160,
          align: 'center',
          sortable: true
        },
        {
          title: 'ชื่อ',
          key: 'FirstName',
          minWidth : 160,
          align: 'center',
          sortable: true
        },
        {
          title: 'นามสกุล',
          key: 'Lastname',
          minWidth : 160,
          align: 'center',
          sortable: true
        },
        {
          title: 'ตำแหน่งหน้าที่',
          key: 'PositionName',
          minWidth : 160,
          align: 'center',
          sortable: true
        },
        {
          title: 'เบอร์ติดต่อ',
          key: 'Phone',
          width: 140,
          minWidth : 160,
          align: 'center',
          sortable: true
        },
        {
          title: 'สถานะ',
          slot: 'status',
          width : 160,
          align: 'center'
        },
        {
          title: 'คำสั่ง',
          slot: 'action',
          width: 130,
          fixed: 'right',
          align: 'center'
        }
      ]
    }
  },
  computed: {
    salaryPerMonth() {
      return this.formItem.salaryPerDay * 30
    }
  },
  mounted() {
    this.checkPermission()
    this.provinceFromAPI()
  },
  methods: {
    debug() {
      // console.log(this.formItem.birthDate)
      // var vr = dayjs(this.formItem.birthDate).add(1, 'day').utc().format('YYYY-MM-DDTHH:mm:ss.SSS[Z]')
      // console.log('vr', vr)
      // var now = dayjs(this.formItem.birthDate).utc().format()
      // console.log('now', now)

      // let testData = {
      //   Id: +this.userID,
      //   Code: this.formItem.code,
      //   PositionId: +this.formItem.positionId,
      //   Active: this.formItem.active,
      //   Password: this.formItem.password,
      //   LoginName: this.formItem.loginName,
      //   EmployeeType: this.formItem.employeeType,
      //   SalaryPerDay: +this.formItem.salaryPerDay,
      //   FirstName: this.formItem.firstName,
      //   Lastname: this.formItem.lastName,
      //   NickName: this.formItem.nickName,
      //   Idcard: this.formItem.idCard,
      //   RegisterDate: dayjs(this.formItem.registerDate).add(1, 'day').utc().format('YYYY-MM-DDTHH:mm:ss.SSS[Z]'),
      //   ExpireDate: dayjs(this.formItem.expireDate).add(1, 'day').utc().format('YYYY-MM-DDTHH:mm:ss.SSS[Z]'),
      //   BirthDate: dayjs(this.formItem.birthDate).add(1, 'day').utc().format('YYYY-MM-DDTHH:mm:ss.SSS[Z]'),
      //   Blood: +this.formItem.blood,
      //   Address: this.formItem.address,
      //   AddressNo: this.formItem.addressNo,
      //   AddressMoo: this.formItem.addressMoo,
      //   AddressTrog: this.formItem.addressTrog,
      //   AddressRoad: this.formItem.addressRoad,
      //   ProvinceId: +this.formItem.provinceId,
      //   DistrictId: +this.formItem.districtId,
      //   SubDistrictId: +this.formItem.subDistrictId,
      //   ZipCodeId: +this.formItem.zipCodeId,
      //   Phone: this.formItem.phone,
      //   Email: this.formItem.email
      // }
      // console.log(testData)
    },
    async subdistrictFromAPI() {
      if (this.getDataSubdistrict == null) {
        console.log('subdistrictFromAPI()')

        let apiWithQuery = await `${
          'api/v1/MasterData/province/' +
          this.formItem.provinceId +
          '/' +
          'district/' +
          this.formItem.districtId +
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

        let apiWithQuery = await `${'api/v1/MasterData/province/' + this.formItem.provinceId + '/' + 'district'}`
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
    async positionFromAPI() {
      if (this.getDataPosition == null) {
      console.log('positionFromAPI()')

      let apiWithQuery = 'api/v1/MasterData/position'

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

      console.log('positionFromAPI()', res)

      let { StatusCode, Resource } = await res

      if (StatusCode == 200) {
        this.getDataPosition = await Resource
        console.log('positionFromAPI()', this.getDataPosition)
      }

      if (res == undefined) {
        await this.reToken()
        await this.positionFromAPI()
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

      this.positionFromAPI()
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

      this.positionFromAPI()

      if (this.modeEdit) {
        this.provinceFromAPI()
        setTimeout(() => {
          this.districtFromAPI()
          this.subdistrictFromAPI()
        }, 300);
      }
    },
    async editData(id) {
      this.userID = id
      let apiWithQuery = `${'api/v1/User/' + id + '?pageType='}`

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

        this.formItem.code = Resource.Code
        this.formItem.positionId = Resource.PositionId
        this.formItem.active = Resource.Active
        this.formItem.password = Resource.Password
        this.formItem.loginName = Resource.LoginName
        this.formItem.employeeType = Resource.EmployeeType
        this.formItem.salaryPerDay = Resource.SalaryPerDay
        this.formItem.firstName = Resource.FirstName
        this.formItem.lastName = Resource.Lastname
        this.formItem.nickName = Resource.NickName
        this.formItem.idCard = Resource.Idcard
        this.formItem.registerDate = Resource.RegisterDate
        this.formItem.expireDate = Resource.ExpireDate
        this.formItem.birthDate = Resource.BirthDate
        this.formItem.blood = Resource.Blood
        this.formItem.address = Resource.Address
        this.formItem.addressNo = Resource.AddressNo
        this.formItem.addressMoo = Resource.AddressMoo
        this.formItem.addressTrog = Resource.AddressTrog
        this.formItem.addressRoad = Resource.AddressRoad
        this.formItem.provinceId = Resource.ProvinceId
        this.formItem.districtId = Resource.DistrictId
        this.formItem.subDistrictId = Resource.SubDistrictId
        this.formItem.zipCodeId = Resource.ZipCodeId
        this.formItem.phone = Resource.Phone
        this.formItem.email = Resource.Email

        this.openModalEdit()
      }

      if (res == undefined) {
        await this.reToken()
        await this.editData(id)
      }
    },
    async saveData() {
      this.$refs.dataTable.loading = true
      let apiUrl = `api/v1/User?pageType=position`
      let apiEditMode = `${'api/v1/User'}`

      if (this.modeEdit == false) {
        let res = await this.$axios
          .$post(
            `${apiUrl}`,
            {
              Code: this.formItem.code,
              PositionId: +this.formItem.positionId,
              Active: this.formItem.active,
              Password: this.formItem.password,
              LoginName: this.formItem.loginName,
              EmployeeType: this.formItem.employeeType,
              SalaryPerDay: +this.formItem.salaryPerDay,
              FirstName: this.formItem.firstName,
              Lastname: this.formItem.lastName,
              NickName: this.formItem.nickName,
              Idcard: this.formItem.idCard,
              RegisterDate: dayjs(this.formItem.registerDate).add(1, 'day').utc().format('YYYY-MM-DDTHH:mm:ss.SSS[Z]'),
              ExpireDate: dayjs(this.formItem.expireDate).add(1, 'day').utc().format('YYYY-MM-DDTHH:mm:ss.SSS[Z]'),
              BirthDate: dayjs(this.formItem.birthDate).add(1, 'day').utc().format('YYYY-MM-DDTHH:mm:ss.SSS[Z]'),
              Blood: +this.formItem.blood,
              Address: this.formItem.address,
              AddressNo: this.formItem.addressNo,
              AddressMoo: this.formItem.addressMoo,
              AddressTrog: this.formItem.addressTrog,
              AddressRoad: this.formItem.addressRoad,
              ProvinceId: +this.formItem.provinceId,
              DistrictId: +this.formItem.districtId,
              SubDistrictId: +this.formItem.subDistrictId,
              ZipCodeId: +this.formItem.zipCodeId,
              Phone: this.formItem.phone,
              Email: this.formItem.email
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
            this.noticeError('User Login นี้มีอยู่แล้วในระบบ')
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
        // let oo = {
        //   Id: +this.userID,
        //   Code: this.formItem.code,
        //   PositionId: +this.formItem.positionId,
        //   Active: this.formItem.active,
        //   Password: this.formItem.password,
        //   LoginName: this.formItem.loginName,
        //   EmployeeType: this.formItem.employeeType,
        //   SalaryPerDay: +this.formItem.salaryPerDay,
        //   FirstName: this.formItem.firstName,
        //   Lastname: this.formItem.lastName,
        //   NickName: this.formItem.nickName,
        //   Idcard: this.formItem.idCard,
        //   RegisterDate: dayjs(this.formItem.registerDate).utc().format(),
        //   ExpireDate: dayjs(this.formItem.expireDate).utc().format(),
        //   BirthDate: dayjs(this.formItem.birthDate).utc().format(),
        //   Blood: +this.formItem.blood,
        //   Address: this.formItem.address,
        //   AddressNo: this.formItem.addressNo,
        //   AddressMoo: this.formItem.addressMoo,
        //   AddressTrog: this.formItem.addressTrog,
        //   AddressRoad: this.formItem.addressRoad,
        //   ProvinceId: +this.formItem.provinceId,
        //   DistrictId: +this.formItem.districtId,
        //   SubDistrictId: +this.formItem.subDistrictId,
        //   ZipCodeId: +this.formItem.zipCodeId,
        //   Phone: this.formItem.phone,
        //   Email: this.formItem.email
        // }

        // console.log(oo)

        let res = await this.$axios
          .$put(
            `${apiEditMode}`,
            {
              Id: +this.userID,
              Code: this.formItem.code,
              PositionId: +this.formItem.positionId,
              Active: this.formItem.active,
              Password: this.formItem.password,
              LoginName: this.formItem.loginName,
              EmployeeType: this.formItem.employeeType,
              SalaryPerDay: +this.formItem.salaryPerDay,
              FirstName: this.formItem.firstName,
              Lastname: this.formItem.lastName,
              NickName: this.formItem.nickName,
              Idcard: this.formItem.idCard,
              RegisterDate: dayjs(this.formItem.registerDate).add(1, 'day').utc().format('YYYY-MM-DDTHH:mm:ss.SSS[Z]'),
              ExpireDate: dayjs(this.formItem.expireDate).add(1, 'day').utc().format('YYYY-MM-DDTHH:mm:ss.SSS[Z]'),
              BirthDate: dayjs(this.formItem.birthDate).add(1, 'day').utc().format('YYYY-MM-DDTHH:mm:ss.SSS[Z]'),
              Blood: +this.formItem.blood,
              Address: this.formItem.address,
              AddressNo: this.formItem.addressNo,
              AddressMoo: this.formItem.addressMoo,
              AddressTrog: this.formItem.addressTrog,
              AddressRoad: this.formItem.addressRoad,
              ProvinceId: +this.formItem.provinceId,
              DistrictId: +this.formItem.districtId,
              SubDistrictId: +this.formItem.subDistrictId,
              ZipCodeId: +this.formItem.zipCodeId,
              Phone: this.formItem.phone,
              Email: this.formItem.email
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
      this.formItem.code = null
      this.formItem.positionId = ''
      this.formItem.active = false
      this.formItem.password = ''
      this.formItem.checkPassword = ''
      this.formItem.loginName = null
      this.formItem.employeeType = null
      this.formItem.salaryPerDay = 0
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
          this.saveData()
        } else {
          this.$Message.error('มีบางอย่างผิดพลาด!')
        }
      })
    }
  }
}
</script>

<style lang="scss" scoped></style>
