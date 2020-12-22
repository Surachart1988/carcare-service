<template>
  <div class="component-wrapper">
    <!-- <div>menuID {{menuID}}</div>
    <div>cPermisson {{cPermisson}}</div>
    <div>ePermisson {{ePermisson}}</div>
    <div>vPermisson {{vPermisson}}</div>
    <div>dPermisson {{dPermisson}}</div>
    <div>pPermisson {{pPermisson}}</div>-->

    <HeaderPage>
      ทะเบียนสินค้าและบริการ
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
      style="margin-top:30px"
    >
      <FormItem
        label="กลุ่มสินค้า"
        flex-xs="100"
        flex-sm="100"
        flex-md="100"
        flex-gt-md="30"
        flex-offset-gt-md="0"
      >
        <Select
          clearable
          size="large"
          v-model="search.productGroup"
          placeholder="เลือกกลุ่มสินค้า"
          @on-open-change="productgroupFromAPI()"
        >
          <Option v-for="(e, index) in getDataProductGroup" :key="index" :value="e.Id">{{e.Name}}</Option>
        </Select>
      </FormItem>
      <FormItem
        label="ประเภทสินค้า"
        flex-xs="100"
        flex-sm="100"
        flex-md="100"
        flex-gt-md="30"
        flex-offset-gt-md="5"
      >
        <Select
          clearable
          size="large"
          v-model="search.productType"
          placeholder="เลือกประเภทสินค้า"
          @on-open-change="producttypeFromAPI()"
        >
          <Option v-for="(e, index) in getDataProductType" :key="index" :value="e.Id">{{e.Name}}</Option>
        </Select>
      </FormItem>
      <FormItem
        label="ยี่ห้อ"
        flex-xs="100"
        flex-sm="100"
        flex-md="100"
        flex-gt-md="30"
        flex-offset-gt-md="5"
      >
        <Select
          clearable
          size="large"
          v-model="search.productBrand"
          placeholder="เลือกยี่ห้อ"
          @on-open-change="productbrandFromAPI()"
        >
          <Option v-for="(e, index) in getDataProductBrand" :key="index" :value="e.Id">{{e.Name}}</Option>
        </Select>
      </FormItem>
      <FormItem
        label="รุ่น"
        flex-xs="100"
        flex-sm="100"
        flex-md="100"
        flex-gt-md="30"
        flex-offset-gt-md="0"
      >
        <Select
          :disabled="search.productBrand == null"
          clearable
          size="large"
          v-model="search.productModel"
          placeholder="เลือกรุ่น"
          @on-open-change="productmodelFromAPI(search.productBrand)"
        >
          <Option v-for="(e, index) in getDataProductModel" :key="index" :value="e.Id">{{e.Name}}</Option>
        </Select>
      </FormItem>
      <FormItem
        label="ขนาดสินค้า"
        flex-xs="100"
        flex-sm="100"
        flex-md="100"
        flex-gt-md="30"
        flex-offset-gt-md="5"
      >
        <Select
          clearable
          size="large"
          v-model="search.productSize"
          placeholder="เลือกขนาดสินค้า"
          @on-open-change="productsizeFromAPI()"
        >
          <Option v-for="(e, index) in getDataProductSize" :key="index" :value="e.Id">{{e.Name}}</Option>
        </Select>
      </FormItem>
      <FormItem
        label="สถานะสินค้า"
        flex-xs="100"
        flex-sm="100"
        flex-md="100"
        flex-gt-md="30"
        flex-offset-gt-md="5"
      >
        <Select
          clearable
          size="large"
          v-model="search.productStatus"
          placeholder="เลือกสถานะสินค้า"
        >
          <Option value="1">ใช้งาน</Option>
          <Option value="2">ยกเลิก</Option>
        </Select>
      </FormItem>
    </Form>

    <div layout="row" layout-align="center center">
      <SearchDataTable
        :columns="tableColumns1"
        searchbox-width="300px"
        select-width="200px"
        :delete-prefix="true"
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
        api-end-point="Product/product"
        ref="dataTable"
        :mode-search="modeSearch"
        :not-delete="true"
      ></DataTable>

      <Modal
        v-show="modalAddData"
        v-model="resloveSlowInput"
        :mask-closable="false"
        width="90%"
        @on-cancel="closeModalAdd()"
      >
        <p slot="header">
          <span>เพิ่มทะเบียนสินค้าและบริการ</span>
        </p>

        <Form
          ref="formValidate"
          :model="formItem"
          :rules="ruleValidate"
          layout="row"
          layout-wrap
          :label-width="115"
        >
          <section flex="100" layout="row" layout-wrap layout-align="center center">
            <FormItem
              label="กลุ่มสินค้า"
              prop="ProGroupId"
              flex-xs="100"
              flex-sm="100"
              flex-md="45"
              flex-offset-md="5"
              flex-gt-md="30"
              flex-offset-gt-md="0"
            >
              <Select
                clearable
                size="large"
                v-model="formItem.ProGroupId"
                placeholder="เลือกกลุ่มสินค้า "
                @on-open-change="productgroupFromAPI()"
              >
                <Option
                  v-for="(e, index) in getDataProductGroup"
                  :key="index"
                  :value="e.Id"
                >{{e.Name}}</Option>
              </Select>
            </FormItem>
            <FormItem
              label="ประเภทสินค้า"
              prop="ProTypeId"
              flex-xs="100"
              flex-sm="100"
              flex-md="45"
              flex-offset-md="5"
              flex-gt-md="30"
              flex-offset-gt-md="5"
            >
              <Select
                clearable
                size="large"
                v-model="formItem.ProTypeId"
                placeholder="เลือกประเภทสินค้า"
                @on-open-change="producttypeFromAPI()"
              >
                <Option
                  v-for="(e, index) in getDataProductType"
                  :key="index"
                  :value="e.Id"
                >{{e.Name}}</Option>
              </Select>
            </FormItem>
            <FormItem
              label="ยี่ห้อสินค้า"
              prop="ProBrandId"
              flex-xs="100"
              flex-sm="100"
              flex-md="45"
              flex-offset-md="5"
              flex-gt-md="30"
              flex-offset-gt-md="5"
            >
              <Select
                clearable
                size="large"
                v-model="formItem.ProBrandId"
                placeholder="เลือกยี่ห้อ"
                @on-open-change="productbrandFromAPI()"
              >
                <Option
                  v-for="(e, index) in getDataProductBrand"
                  :key="index"
                  :value="e.Id"
                >{{e.Name}}</Option>
              </Select>
            </FormItem>
            <FormItem
              label="รุ่นสินค้า"
              prop="ProModelId"
              flex-xs="100"
              flex-sm="100"
              flex-md="45"
              flex-offset-md="5"
              flex-gt-md="30"
              flex-offset-gt-md="0"
            >
              <Select
                :disabled="formItem.ProBrandId == null"
                clearable
                size="large"
                v-model="formItem.ProModelId"
                placeholder="เลือกรุ่น"
                @on-open-change="productmodelFromAPI(formItem.ProBrandId)"
              >
                <Option
                  v-for="(e, index) in getDataProductModel"
                  :key="index"
                  :value="e.Id"
                >{{e.Name}}</Option>
              </Select>
            </FormItem>
            <FormItem
              label="ขนาดสินค้า"
              prop="ProSizeId"
              flex-xs="100"
              flex-sm="100"
              flex-md="45"
              flex-offset-md="5"
              flex-gt-md="30"
              flex-offset-gt-md="5"
            >
              <Select
                clearable
                size="large"
                v-model="formItem.ProSizeId"
                placeholder="เลือกขนาดสินค้า"
                @on-open-change="productsizeFromAPI()"
              >
                <Option
                  v-for="(e, index) in getDataProductSize"
                  :key="index"
                  :value="e.Id"
                >{{e.Name}}</Option>
              </Select>
            </FormItem>
            <FormItem
              label="รหัสสินค้า"
              prop="Code"
              flex-xs="100"
              flex-sm="100"
              flex-md="45"
              flex-offset-md="5"
              flex-gt-md="30"
              flex-offset-gt-md="5"
            >
              <Input disabled size="large" v-model="formItem.Code"></Input>
            </FormItem>
            <FormItem
              label="ชื่อสินค้า (ไทย)"
              prop="NameTh"
              flex-xs="100"
              flex-sm="100"
              flex-md="45"
              flex-offset-md="5"
              flex-gt-md="30"
              flex-offset-gt-md="0"
            >
              <Input size="large" v-model="formItem.NameTh"></Input>
            </FormItem>
            <FormItem
              label="ชื่อสินค้า (Eng)"
              prop="NameEn"
              flex-xs="100"
              flex-sm="100"
              flex-md="45"
              flex-offset-md="5"
              flex-gt-md="30"
              flex-offset-gt-md="5"
            >
              <Input size="large" v-model="formItem.NameEn"></Input>
            </FormItem>
            <div hide-md flex-gt-md="30" flex-offset-gt-md="5"></div>
          </section>

          <Divider class="main-divider" style="margin-bottom:40px" />

          <section
            class="secction-form"
            flex="100"
            flex-lg="50"
            flex-gt-lg="60"
            flex-offset-lg="0"
            flex-offset-gt-lg="0"
            layout="row"
            layout-wrap
            layout-align="start start"
          >
            <HeaderPage :userAvatar="false" :buttonAdd="false" :divider="false">ข้อมูลสินค้า</HeaderPage>

            <div flex="100" flex-gt-lg="50">
              <FormItem
                label="รหัสสินค้าเพิ่มเติม"
                prop="AdditionalCode"
                :label-width="140"
                flex="100"
              >
                <Input size="large" v-model="formItem.AdditionalCode"></Input>
              </FormItem>
              <FormItem label="Part Number" prop="PartNumber" :label-width="140" flex="100">
                <Input size="large" v-model="formItem.PartNumber"></Input>
              </FormItem>
              <FormItem label="รหัสผู้ผลิต" prop="ManufactCode" :label-width="140" flex="100">
                <Input size="large" v-model="formItem.ManufactCode"></Input>
              </FormItem>
              <!-- <FormItem label="ผู้จำหน่าย" prop="field13" :label-width="170" flex="100">
                <Select
                  clearable
                  size="large"
                  v-model="formItem.field13"
                  placeholder="เลือกผู้จำหน่าย"
                >
                  <Option value="test01">test01</Option>
                </Select>
              </FormItem>-->
              <!-- <FormItem label="บริการครั้งถัดไป" prop="nextService" :label-width="170" flex="100">
                <Select
                  clearable
                  size="large"
                  v-model="formItem.nextService"
                  placeholder="เลือกบริการครั้งถัดไป"
                  @on-open-change="nextserviceFromAPI()"
                >
                  <Option
                    v-for="(e, index) in getDataNextService"
                    :key="index"
                    :value="e.Id"
                  >{{e.Name}}</Option>
                </Select>
              </FormItem>-->
              <!-- <FormItem
                label="บริการครั้งถัดไป (ย่อย)"
                prop="field15"
                :label-width="170"
                flex="100"
              >
                <Select
                  :disabled="formItem.subNextService == null"
                  clearable
                  size="large"
                  v-model="formItem.subNextService"
                  placeholder="เลือกบริการครั้งถัดไป (ย่อย)"
                  @on-open-change="subnextserviceFromAPI(formItem.nextService)"
                >
                  <Option
                    v-for="(e, index) in getDataSubNextService"
                    :key="index"
                    :value="e.Id"
                  >{{e.Name}}</Option>
                </Select>
              </FormItem>-->
            </div>

            <div flex="100" flex-gt-lg="45" flex-offset-gt-lg>
              <FormItem label="ประเภทสินค้า" prop="FastProduct" :label-width="140" flex="100">
                <Checkbox size="large" v-model="formItem.FastProduct">อะไหล่ Fast</Checkbox>
                <Tooltip max-width="300" content="กรณีเป็นค่าแรงหรือบริการไม่ต้องตัดสต๊อก">
                  <Checkbox size="large" v-model="formItem.CutStock">ต้องตัดสต๊อก</Checkbox>
                </Tooltip>
              </FormItem>
              <FormItem label="สถานะสินค้า" prop="Status" :label-width="140" flex="100">
                <Select
                  clearable
                  size="large"
                  v-model="formItem.Status"
                  placeholder="เลือกชนิดภาษีมูลค่าเพิ่ม"
                >
                  <Option value="1">ใช้งาน</Option>
                  <Option value="2">ยดเลิก</Option>
                </Select>
              </FormItem>
              <FormItem label="หมายเหตุ" prop="Note" :label-width="140" flex="100">
                <Input
                  size="large"
                  v-model="formItem.Note"
                  type="textarea"
                  :autosize="{ minRows: 3, maxRows: 5 }"
                ></Input>
              </FormItem>
            </div>
          </section>

          <section
            class="secction-form with-border"
            flex="100"
            flex-lg="45"
            flex-gt-lg="35"
            flex-offset-lg="5"
            flex-offset-gt-lg="5"
          >
            <HeaderPage :userAvatar="false" :buttonAdd="false" :divider="false">ตั้งค่าหน่วยซื้อขาย</HeaderPage>

            <FormItem label="หน่วยนับ" prop="UnitId" :label-width="160" flex="100">
              <Select
                clearable
                size="large"
                v-model="formItem.UnitID"
                placeholder="เลือกหน่วยนับ"
                @on-open-change="productUnitFromAPI()"
              >
                <Option
                  v-for="(e, index) in getDataProductUnit"
                  :key="index"
                  :value="e.Id"
                >{{e.Name}}</Option>
              </Select>
            </FormItem>

            <div flex="100" layout="row" layout-wrap>
              <FormItem label="หน่วยซื้อ" prop="BuyUnitId" :label-width="160" flex="100" flex-gt-lg="60">
                <Select
                  clearable
                  size="large"
                  v-model="formItem.BuyUnitId"
                  placeholder="เลือกหน่วยนับ"
                  @on-open-change="productUnitFromAPI()"
                >
                  <Option
                    v-for="(e, index) in getDataProductUnit"
                    :key="index"
                    :value="e.Id"
                  >{{e.Name}}</Option>
                </Select>
              </FormItem>

              <FormItem
                label="หน่วยนับ/ซื้อ"
                prop="BuyUnitValue"
                 :label-width="160"
                 flex="100" flex-gt-lg="40"
              >
                <Input size="large" v-model="formItem.BuyUnitValue"></Input>
              </FormItem>
            </div>

            <div flex="100" layout="row" layout-wrap>
              <FormItem label="หน่วยขาย" prop="SaleUnitId" :label-width="160" flex="100" flex-gt-lg="60">
                <Select
                  clearable
                  size="large"
                  v-model="formItem.SaleUnitId"
                  placeholder="เลือกหน่วยนับ"
                  @on-open-change="productUnitFromAPI()"
                >
                  <Option
                    v-for="(e, index) in getDataProductUnit"
                    :key="index"
                    :value="e.Id"
                  >{{e.Name}}</Option>
                </Select>
              </FormItem>

              <FormItem
                label="หน่วยนับ/ขาย"
                prop="SaleUnitValue"
                :label-width="160"
                flex="100" flex-gt-lg="40"
              >
                <Input size="large" v-model="formItem.SaleUnitValue"></Input>
              </FormItem>
            </div>

            <section layout="row">
              <FormItem label="ราคาขาย" prop="ProductSalePrice" :label-width="160" flex="auto">
                <Input size="large" v-model="formItem.ProductSalePrice"></Input>
              </FormItem>
              <!-- <div flex="30" style="margin-left: 10px">
                <Button type="success" shape="circle" size="large" @click>จัดการราคา</Button>
              </div>-->
            </section>

            <FormItem label="ราคาทุน (ไม่รวม VAT)" prop="CostPrice" :label-width="160" flex="100">
              <Input size="large" v-model="formItem.CostPrice"></Input>
            </FormItem>
            <FormItem label="Standard Margin" prop="StandardMargin" :label-width="160" flex="100">
              <Input size="large" v-model="formItem.StandardMargin"></Input>
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
        // field1: [{ required: true, message: 'กรุณากรอกข้อมูล', trigger: 'change' }],
        // field2: [{ required: true, message: 'กรุณากรอกข้อมูล', trigger: 'change' }],
        // field3: [{ message: 'กรุณากรอกข้อมูล', trigger: 'change' }],
        // field4: [{ message: 'กรุณากรอกข้อมูล', trigger: 'change' }],
        // field5: [{ message: 'กรุณากรอกข้อมูล', trigger: 'change' }],
        // field6: [{ required: true, message: 'กรุณากรอกข้อมูล', trigger: 'blur' }],
        // field7: [{ required: true, message: 'กรุณากรอกข้อมูล', trigger: 'blur' }],
        // field8: [{ message: 'กรุณากรอกข้อมูล', trigger: 'blur' }],
        // field9: [{ message: 'กรุณากรอกข้อมูล', trigger: 'blur' }],
        // field10: [{ message: 'กรุณากรอกข้อมูล', trigger: 'blur' }],
        // field11: [{ message: 'กรุณากรอกข้อมูล', trigger: 'blur' }],
        // field12: [{ message: 'กรุณากรอกข้อมูล', trigger: 'blur' }],
        // field13: [{ message: 'กรุณากรอกข้อมูล', trigger: 'change' }],
        // field14: [{ required: true, message: 'กรุณากรอกข้อมูล', trigger: 'change' }],
        // field15: [{ required: true, message: 'กรุณากรอกข้อมูล', trigger: 'change' }],
        // field16: [{ required: true, message: 'กรุณากรอกข้อมูล', trigger: 'change' }],
        // field17: [{ required: true, message: 'กรุณากรอกข้อมูล', trigger: 'change' }],
        // field18: [{ message: 'กรุณากรอกข้อมูล', trigger: 'blur' }],
        // field19: [{ required: true, message: 'กรุณากรอกข้อมูล', trigger: 'change' }],
        // field20: [{ message: 'กรุณากรอกข้อมูล', trigger: 'blur' }],
        // field21: [{ required: true, message: 'กรุณากรอกข้อมูล', trigger: 'blur' }],
        // field22: [{ required: true, message: 'กรุณากรอกข้อมูล', trigger: 'blur' }],
        // field23: [{ required: true, message: 'กรุณากรอกข้อมูล', trigger: 'change' }],
        // field24: [{ message: 'กรุณากรอกข้อมูล', trigger: 'change' }],
        // field25: [{ type: 'date', message: 'กรุณากรอกข้อมูล', trigger: 'change' }],
        // field26: [{ message: 'กรุณากรอกข้อมูล', trigger: 'blur' }]
      },
      search: {
        productGroup: null,
        productType: null,
        productBrand: null,
        productModel: null,
        productSize: null,
        productStatus: null
      },
      formItem: {
        ProGroupId: null,
        ProTypeId: null,
        ProBrandId: null,
        ProModelId: null,
        ProSizeId: null,
        Status: null,
        Code: null,
        NameTh: null,
        NameEn: null,
        AdditionalCode: null,
        ManufactCode: null,
        PartNumber: null,
        CutStock: false,
        FastProduct: false,
        Note: null,
        UnitID: null,
        BuyUnitId: null,
        BuyUnitValue: null,
        SaleUnitId: null,
        SaleUnitValue: null,
        CostPrice: null,
        ProductSalePrice: null,
        StandardMargin: null,
        nextService: null,
        subNextService: null
      },
      getDataProductGroup: null,
      getDataProductType: null,
      getDataProductBrand: null,
      getDataProductModel: null,
      getDataProductSize: null,
      getDataNextService: null,
      getDataSubNextService: null,
      getDataProductUnit: null,
      tableColumns1: [
        {
          title: 'รหัสสินค้า',
          key: 'Code',
          width: 150,
          align: 'center',
          sortable: true
        },
        {
          title: 'ชื่อสินค้า',
          key: 'NameTh',
          minWidth: 170,
          align: 'center',
          sortable: true
        },
        {
          title: 'ประเภทสินค้า',
          key: 'ProTypeName',
          minWidth: 180,
          align: 'center',
          sortable: true
        },
        {
          title: 'ยี่ห้อสินค้า',
          key: 'ProBrandName',
          minWidth: 170,
          align: 'center',
          sortable: true
        },
        {
          title: 'รุ่นสินค้า',
          key: 'ProModelName',
          minWidth: 150,
          align: 'center',
          sortable: true
        },
        {
          title: 'ขนาดสินค้า',
          key: 'ProSizeName',
          width: 150,
          align: 'center',
          sortable: true
        },
        {
          title: 'ราคาทุน',
          key: 'CostPrice',
          width: 160,
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
      ]
    }
  },
  computed: {},
  mounted() {
    this.checkPermission()

    setTimeout(() => {
      this.productgroupFromAPI()
      this.producttypeFromAPI()
      this.productbrandFromAPI()
      this.productsizeFromAPI()
    }, 500)

    setTimeout(() => {
      // this.nextserviceFromAPI()
      this.productUnitFromAPI()
    }, 1500)
  },
  methods: {
    debug() {
      // let testData = {
      // }
      // console.log(testData)
    },
    async productUnitFromAPI() {
      if (this.getDataProductUnit == null) {
        console.log('productUnitFromAPI()')

        let apiWithQuery = `${'api/v1/MasterData/product/unit'}`

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

        console.log('productUnitFromAPI()', res)
        let { StatusCode, Resource } = await res

        if (StatusCode == 200) {
          this.getDataProductUnit = await res.Resource
        }

        if (res == undefined) {
          await this.reToken()
          await this.productUnitFromAPI()
        }
      }
    },
    // async subnextserviceFromAPI(id) {
    //   if (id) {
    //     console.log('subnextserviceFromAPI()')

    //     let apiWithQuery = `api/v1/MasterData/nextservice/${id}/subnextservice`

    //     let res = await this.$axios
    //       .$get(apiWithQuery, {
    //         headers: {
    //           'Access-Control-Allow-Origin': '*',
    //           Authorization: `Bearer ${this.accessToken}`
    //         }
    //       })
    //       .catch(function (error) {
    //         if (error.response) {
    //           console.log(error.response.status)
    //         }
    //       })

    //     console.log('subnextserviceFromAPI()', res)
    //     let { StatusCode, Resource } = await res

    //     if (StatusCode == 200) {
    //       this.getDataSubNextService = await res.Resource
    //     }

    //     if (res == undefined) {
    //       await this.reToken()
    //       await this.subnextserviceFromAPI()
    //     }
    //   }
    // },
    // async nextserviceFromAPI() {
    //   if (this.getDataNextService == null) {
    //     console.log('nextserviceFromAPI()')

    //     let apiWithQuery = `${'api/v1/MasterData/nextservice'}`

    //     let res = await this.$axios
    //       .$get(apiWithQuery, {
    //         headers: {
    //           'Access-Control-Allow-Origin': '*',
    //           Authorization: `Bearer ${this.accessToken}`
    //         }
    //       })
    //       .catch(function (error) {
    //         if (error.response) {
    //           console.log(error.response.status)
    //         }
    //       })

    //     console.log('nextserviceFromAPI()', res)
    //     let { StatusCode, Resource } = await res

    //     if (StatusCode == 200) {
    //       this.getDataNextService = await res.Resource
    //     }

    //     if (res == undefined) {
    //       await this.reToken()
    //       await this.nextserviceFromAPI()
    //     }
    //   }
    // },
    async productsizeFromAPI() {
      if (this.getDataProductSize == null) {
        console.log('productsizeFromAPI()')

        let apiWithQuery = `${'api/v1/MasterData/product/prosize'}`

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

        console.log('productsizeFromAPI()', res)
        let { StatusCode, Resource } = await res

        if (StatusCode == 200) {
          this.getDataProductSize = await res.Resource
        }

        if (res == undefined) {
          await this.reToken()
          await this.productsizeFromAPI()
        }
      }
    },
    async productmodelFromAPI(id) {
      if (id) {
        console.log('productmodelFromAPI()')

        let apiWithQuery = `api/v1/MasterData/product/probrand/${id}/promodel`

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

        console.log('productmodelFromAPI()', res)
        let { StatusCode, Resource } = await res

        if (StatusCode == 200) {
          this.getDataProductModel = await res.Resource
        }

        if (res == undefined) {
          await this.reToken()
          await this.productmodelFromAPI()
        }
      }
    },
    async productbrandFromAPI() {
      if (this.getDataProductType == null) {
        console.log('productbrandFromAPI()')

        let apiWithQuery = `${'api/v1/MasterData/product/probrand'}`

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

        console.log('productbrandFromAPI()', res)
        let { StatusCode, Resource } = await res

        if (StatusCode == 200) {
          this.getDataProductBrand = await res.Resource
        }

        if (res == undefined) {
          await this.reToken()
          await this.productbrandFromAPI()
        }
      }
    },
    async producttypeFromAPI() {
      if (this.getDataProductType == null) {
        console.log('producttypeFromAPI()')

        let apiWithQuery = `${'api/v1/MasterData/product/protype'}`

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

        console.log('producttypeFromAPI()', res)
        let { StatusCode, Resource } = await res

        if (StatusCode == 200) {
          this.getDataProductType = await res.Resource
        }

        if (res == undefined) {
          await this.reToken()
          await this.producttypeFromAPI()
        }
      }
    },
    async productgroupFromAPI() {
      if (this.getDataProductGroup == null) {
        console.log('productgroupFromAPI()')

        let apiWithQuery = `${'api/v1/MasterData/product/progroup'}`

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

        console.log('productgroupFromAPI()', res)
        let { StatusCode, Resource } = await res

        if (StatusCode == 200) {
          this.getDataProductGroup = await res.Resource
        }

        if (res == undefined) {
          await this.reToken()
          await this.productgroupFromAPI()
        }
      }
    },
    searchOnDatatable(obj) {
      this.modeSearch = true
      this.$set(obj, "ProGroupID", this.search.productGroup)
      this.$set(obj, "ProTypeID", this.search.productType)
      this.$set(obj, "ProBrandID", this.search.productBrand)
      this.$set(obj, "ProModelID", this.search.productModel)
      this.$set(obj, "ProSizeID", this.search.productSize)
      this.$set(obj, "Status", this.search.productStatus)

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

      this.productgroupFromAPI()
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

      if (this.modeEdit) {
        this.productmodelFromAPI(this.formItem.ProBrandId)
      }
    },
    async editData(id) {
      this.itemID = id
      let apiWithQuery = `${'api/v1/Product/product/' + id}`

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

        this.formItem.ProGroupId = Resource.ProGroupId
        this.formItem.ProTypeId = Resource.ProTypeId
        this.formItem.ProBrandId = Resource.ProBrandId
        this.formItem.ProModelId = Resource.ProModelId
        this.formItem.ProSizeId = Resource.ProSizeId
        this.formItem.Status = Resource.Status
        this.formItem.Code = Resource.Code
        this.formItem.NameTh = Resource.NameTh
        this.formItem.NameEn = Resource.NameEn
        this.formItem.AdditionalCode = Resource.AdditionalCode
        this.formItem.ManufactCode = Resource.ManufactCode
        this.formItem.PartNumber = Resource.PartNumber
        this.formItem.CutStock = Resource.CutStock
        this.formItem.FastProduct = Resource.FastProduct
        this.formItem.Note = Resource.Note
        this.formItem.UnitID = Resource.UnitID
        this.formItem.BuyUnitId = Resource.BuyUnitId
        this.formItem.BuyUnitValue = Resource.BuyUnitValue
        this.formItem.SaleUnitId = Resource.SaleUnitId
        this.formItem.SaleUnitValue = Resource.SaleUnitValue
        this.formItem.CostPrice = Resource.CostPrice
        this.formItem.ProductSalePrice = Resource.ProductSalePrice
        this.formItem.StandardMargin = Resource.StandardMargin

        this.openModalEdit()
      }

      if (res == undefined) {
        await this.reToken()
        await this.editData(id)
      }
    },
    async saveData() {
      this.$refs.dataTable.loading = true
      let apiUrl = `api/v1/Product`
      let apiEditMode = `${'api/v1/Product'}`

      let oo = {
          Id: +this.itemID,
          Code: ''+this.formItem.Code,
          ProGroupId: +this.formItem.ProGroupId,
          ProTypeId: +this.formItem.ProTypeId,
          ProBrandId: +this.formItem.ProBrandId,
          ProModelId: +this.formItem.ProModelId,
          ProSizeId: +this.formItem.ProSizeId,
          Status: +this.formItem.Status,
          NameTh: this.formItem.NameTh,
          NameEn: this.formItem.NameEn,
          AdditionalCode: this.formItem.AdditionalCode,
          ManufactCode: this.formItem.ManufactCode,
          PartNumber: this.formItem.PartNumber,
          CutStock: this.formItem.CutStock,
          FastProduct: this.formItem.FastProduct,
          Note: this.formItem.Note,
          UnitID: +this.formItem.UnitID,
          BuyUnitId: +this.formItem.BuyUnitId,
          BuyUnitValue: +this.formItem.BuyUnitValue,
          SaleUnitId: +this.formItem.SaleUnitId,
          SaleUnitValue: +this.formItem.SaleUnitValue,
          CostPrice: +this.formItem.CostPrice,
          ProductSalePrice: +this.formItem.ProductSalePrice,
          StandardMargin: +this.formItem.StandardMargin
        }

        console.log('oo', oo)

      if (this.modeEdit == false) {
        let res = await this.$axios
          .$post(
            `${apiUrl}`,
            {
              ProGroupId: +this.formItem.ProGroupId,
              ProTypeId: +this.formItem.ProTypeId,
              ProBrandId: +this.formItem.ProBrandId,
              ProModelId: +this.formItem.ProModelId,
              ProSizeId: +this.formItem.ProSizeId,
              Status: +this.formItem.Status,
              NameTh: this.formItem.NameTh,
              NameEn: this.formItem.NameEn,
              AdditionalCode: this.formItem.AdditionalCode,
              ManufactCode: this.formItem.ManufactCode,
              PartNumber: this.formItem.PartNumber,
              CutStock: this.formItem.CutStock,
              FastProduct: this.formItem.FastProduct,
              Note: this.formItem.Note,
              UnitID: +this.formItem.UnitID,
              BuyUnitId: +this.formItem.BuyUnitId,
              BuyUnitValue: +this.formItem.BuyUnitValue,
              SaleUnitId: +this.formItem.SaleUnitId,
              SaleUnitValue: +this.formItem.SaleUnitValue,
              CostPrice: +this.formItem.CostPrice,
              ProductSalePrice: +this.formItem.ProductSalePrice,
              StandardMargin: +this.formItem.StandardMargin
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
              console.log(error.response)
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
        let res = await this.$axios
          .$put(
            `${apiEditMode}`,
            {
              Id: +this.itemID,
              Code: ''+this.formItem.Code,
              ProGroupId: +this.formItem.ProGroupId,
              ProTypeId: +this.formItem.ProTypeId,
              ProBrandId: +this.formItem.ProBrandId,
              ProModelId: +this.formItem.ProModelId,
              ProSizeId: +this.formItem.ProSizeId,
              Status: +this.formItem.Status,
              NameTh: this.formItem.NameTh,
              NameEn: this.formItem.NameEn,
              AdditionalCode: this.formItem.AdditionalCode,
              ManufactCode: this.formItem.ManufactCode,
              PartNumber: this.formItem.PartNumber,
              CutStock: this.formItem.CutStock,
              FastProduct: this.formItem.FastProduct,
              Note: this.formItem.Note,
              UnitID: +this.formItem.UnitID,
              BuyUnitId: +this.formItem.BuyUnitId,
              BuyUnitValue: +this.formItem.BuyUnitValue,
              SaleUnitId: +this.formItem.SaleUnitId,
              SaleUnitValue: +this.formItem.SaleUnitValue,
              CostPrice: +this.formItem.CostPrice,
              ProductSalePrice: +this.formItem.ProductSalePrice,
              StandardMargin: +this.formItem.StandardMargin
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