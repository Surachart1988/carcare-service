<template>
  <div class="component-wrapper" id="hozmenu" ref="hozmenu">
    <Menu mode="horizontal" :active-name="activeByUrl">
      <Submenu name="1">
        <template slot="title">สินค้า</template>
        <MenuItem name="1-1" to="/master-data/setting-master-data/product-group">
          <Icon type="md-link" />
          <div class="link-menu">กลุ่มสินค้า</div>
        </MenuItem>
        <MenuItem name="1-2" to="/master-data/setting-master-data/product-type">
          <Icon type="md-link" />
          <div class="link-menu">ประเภทสินค้า</div>
        </MenuItem>
        <MenuItem name="1-3" to="/master-data/setting-master-data/product-brand">
          <Icon type="md-link" />
          <div class="link-menu">ยี่ห้อสินค้า</div>
        </MenuItem>
        <MenuItem name="1-4" to="/master-data/setting-master-data/product-model">
          <Icon type="md-link" />
          <div class="link-menu">รุ่นสินค้า</div>
        </MenuItem>
        <MenuItem name="1-5" to="/master-data/setting-master-data/product-size">
          <Icon type="md-link" />
          <div class="link-menu">ขนาดสินค้า</div>
        </MenuItem>
        <MenuItem name="1-6" to="/master-data/setting-master-data/product-unit">
          <Icon type="md-link" />
          <div class="link-menu">หน่วยสินค้า</div>
        </MenuItem>
        <!-- <MenuItem name="1-7" to="/master-data/setting-master-data/location">
          <Icon type="md-link" />
          <div class="link-menu">ที่เก็บสินค้า</div>
        </MenuItem>
        <MenuItem name="1-8" to="/master-data/setting-master-data/dot">
          <Icon type="md-link" />
          <div class="link-menu">ที่เก็บ DOT</div>
        </MenuItem>
        <MenuItem name="1-9" to="/master-data/setting-master-data/next-service">
          <Icon type="md-link" />
          <div class="link-menu">บริการครั้งต่อไป</div>
        </MenuItem>
        <MenuItem name="1-10" to="/master-data/setting-master-data/sub-next-service">
          <Icon type="md-link" />
          <div class="link-menu">บริการครั้งต่อไปย่อย</div>
        </MenuItem> -->
      </Submenu>
      <Submenu name="2">
        <template slot="title">รถยนต์</template>
        <MenuItem name="2-1" to="/master-data/setting-master-data/car-type">
          <Icon type="md-link" />
          <div class="link-menu">ประเภทรถยนต์</div>
        </MenuItem>
        <MenuItem name="2-2" to="/master-data/setting-master-data/car-brand">
          <Icon type="md-link" />
          <div class="link-menu">ยี่ห้อรถยนต์</div>
        </MenuItem>
        <MenuItem name="2-3" to="/master-data/setting-master-data/car-model">
          <Icon type="md-link" />
          <div class="link-menu">รุ่นรถยนต์</div>
        </MenuItem>
        <MenuItem name="2-4" to="/master-data/setting-master-data/car-sub-model">
          <Icon type="md-link" />
          <div class="link-menu">รุ่นย่อยรถยนต์</div>
        </MenuItem>
        <!-- <MenuItem name="2-5" to="/master-data/setting-master-data/car-checklist">
          <Icon type="md-link" />
          <div class="link-menu">รายการตรวจสอบสภาพรถยนต์</div>
        </MenuItem> -->
        <MenuItem name="2-6" to="/master-data/setting-master-data/car-gear">
          <Icon type="md-link" />
          <div class="link-menu">เกียร์</div>
        </MenuItem>
      </Submenu>
      <Submenu name="3">
        <template slot="title">ลูกค้า</template>
        <MenuItem name="3-1" to="/master-data/setting-master-data/contact-type">
          <Icon type="md-link" />
          <div class="link-menu">กลุ่มลูกค้า</div>
        </MenuItem>
        <MenuItem name="3-2" to="/master-data/setting-master-data/business-type">
          <Icon type="md-link" />
          <div class="link-menu">ประเภทธุรกิจ</div>
        </MenuItem>
      </Submenu>
      <!-- <Submenu name="4">
        <template slot="title">เอกสาร</template>
        <MenuItem name="4-1" to="/master-data/setting-master-data/reason-dec-inc">
          <Icon type="md-link" />
          <div class="link-menu">สาเหตุการปรับลดปรับเพิ่ม</div>
        </MenuItem>
        <MenuItem name="4-2" to="/master-data/setting-master-data/assessment">
          <Icon type="md-link" />
          <div class="link-menu">หัวข้อการประเมิน</div>
        </MenuItem>
        <MenuItem name="4-3" to="/master-data/setting-master-data/tag-status">
          <Icon type="md-link" />
          <div class="link-menu">รายการติดตามหลังบริการ</div>
        </MenuItem>
        <MenuItem name="4-4" to="/master-data/setting-master-data/document-type">
          <Icon type="md-link" />
          <div class="link-menu">ทะเบียนเอกสาร</div>
        </MenuItem>
      </Submenu> -->
      <!-- <Submenu name="5">
        <template slot="title">การเงิน</template>
        <MenuItem name="5-1" to="/master-data/setting-master-data/bank-name">
          <Icon type="md-link" />
          <div class="link-menu">ชื่อธนาคาร</div>
        </MenuItem>
        <MenuItem name="5-2" to="/master-data/setting-master-data/credit-card">
          <Icon type="md-link" />
          <div class="link-menu">ชื่อบัตรเครดิต</div>
        </MenuItem>
        <MenuItem name="5-3" to="/master-data/setting-master-data/cheque-type">
          <Icon type="md-link" />
          <div class="link-menu">รูปแบบเช็ค</div>
        </MenuItem>
        <MenuItem name="5-4" to="/master-data/setting-master-data/credit-card-swipe">
          <Icon type="md-link" />
          <div class="link-menu">รูปแบบการรูดบัตร</div>
        </MenuItem>
      </Submenu> -->
      <Submenu name="6">
        <template slot="title">ภาษี</template>
        <MenuItem name="6-1" to="/master-data/setting-master-data/tax-rate">
          <Icon type="md-link" />
          <div class="link-menu">อัตราภาษีซื้อ/ขาย</div>
        </MenuItem>
      </Submenu>
      <Submenu name="7">
        <template slot="title">หักภาษี ณ ที่จ่าย</template>
        <MenuItem name="7-1" to="/master-data/setting-master-data/condition-withholding-tax">
          <Icon type="md-link" />
          <div class="link-menu">เงื่อนไขการหักภาษี</div>
        </MenuItem>
        <MenuItem name="7-2" to="/master-data/setting-master-data/sort-withholding-tax">
          <Icon type="md-link" />
          <div class="link-menu">ประเภทการหักภาษี</div>
        </MenuItem>
      </Submenu>
      <Submenu name="8">
        <template slot="title">พนักงาน</template>
        <MenuItem name="8-1" to="/master-data/setting-master-data/position">
          <Icon type="md-link" />
          <div class="link-menu">ตำแหน่งหน้าที่</div>
        </MenuItem>
      </Submenu>
    </Menu>
  </div>
</template>

<script>
export default {
  components: {},
  data() {
    return {
      heightOfMenu: ''
    }
  },
  computed: {
    activeByUrl() {
      if (this.$route.fullPath == '/master-data/setting-master-data/product-group') {
        return '1-1'
      }
      if (this.$route.fullPath == '/master-data/setting-master-data/product-type') {
        return '1-2'
      }
      if (this.$route.fullPath == '/master-data/setting-master-data/product-brand') {
        return '1-3'
      }
      if (this.$route.fullPath == '/master-data/setting-master-data/product-model') {
        return '1-4'
      }
      if (this.$route.fullPath == '/master-data/setting-master-data/product-size') {
        return '1-5'
      }
      if (this.$route.fullPath == '/master-data/setting-master-data/product-unit') {
        return '1-6'
      }
      if (this.$route.fullPath == '/master-data/setting-master-data/location') {
        return '1-7'
      }
      if (this.$route.fullPath == '/master-data/setting-master-data/dot') {
        return '1-8'
      }
      if (this.$route.fullPath == '/master-data/setting-master-data/next-service') {
        return '1-9'
      }
      if (this.$route.fullPath == '/master-data/setting-master-data/sub-next-service') {
        return '1-10'
      }
      if (this.$route.fullPath == '/master-data/setting-master-data/car-type') {
        return '2-1'
      }
      if (this.$route.fullPath == '/master-data/setting-master-data/car-brand') {
        return '2-2'
      }
      if (this.$route.fullPath == '/master-data/setting-master-data/car-model') {
        return '2-3'
      }
      if (this.$route.fullPath == '/master-data/setting-master-data/car-sub-model') {
        return '2-4'
      }
      if (this.$route.fullPath == '/master-data/setting-master-data/car-checklist') {
        return '2-5'
      }
      if (this.$route.fullPath == '/master-data/setting-master-data/car-gear') {
        return '2-6'
      }
      if (this.$route.fullPath == '/master-data/setting-master-data/contact-type') {
        return '3-1'
      }
      if (this.$route.fullPath == '/master-data/setting-master-data/business-type') {
        return '3-2'
      }
      if (this.$route.fullPath == '/master-data/setting-master-data/reason-dec-inc') {
        return '4-1'
      }
      if (this.$route.fullPath == '/master-data/setting-master-data/assessment') {
        return '4-2'
      }
      if (this.$route.fullPath == '/master-data/setting-master-data/tag-status') {
        return '4-3'
      }
      if (this.$route.fullPath == '/master-data/setting-master-data/document-type') {
        return '4-4'
      }
      if (this.$route.fullPath == '/master-data/setting-master-data/bank-name') {
        return '5-1'
      }
      if (this.$route.fullPath == '/master-data/setting-master-data/credit-card') {
        return '5-2'
      }
      if (this.$route.fullPath == '/master-data/setting-master-data/cheque-type') {
        return '5-3'
      }
      if (this.$route.fullPath == '/master-data/setting-master-data/credit-card-swipe') {
        return '5-4'
      }
      if (this.$route.fullPath == '/master-data/setting-master-data/tax-rate') {
        return '6-1'
      }
      if (this.$route.fullPath == '/master-data/setting-master-data/condition-withholding-tax') {
        return '7-1'
      }
      if (this.$route.fullPath == '/master-data/setting-master-data/sort-withholding-tax') {
        return '7-2'
      }
      if (this.$route.fullPath == '/master-data/setting-master-data/position') {
        return '8-1'
      }
    }
  },
  created() {},
  mounted() {
    console.log(this.$route)

    this.$nextTick(() => {
      var heightString = document.getElementById('hozmenu').clientHeight

      this.heightOfMenu = heightString + 'px'
    })
  },
  methods: {
    // gg() {
    //   this.$router.push({ name: 'index' })
    // }
  }
}
</script>

<style lang="scss">
@function rem($size) {
  @return $size / 16px * 1rem;
}

ul.ivu-menu-horizontal > li {
  ul.ivu-menu-drop-list > a {
    display: flex;
    align-items: center;
    width: 100%;
  }
  ul.ivu-menu-drop-list > li {
    .ivu-icon {
      color: darken($color_font-2, 15%);
      font-weight: bold;
    }
    .link-menu {
      color: $color_font-2;
      display: inline-flex;
      margin-left: 5px;
    }

    &:hover {
      .link-menu {
        color: $color_font-main;
      }
    }
  }

  &:nth-child(1) {
    ul.ivu-menu-drop-list {
      min-width: 170px;
      width: 100%;

      > li {
        width: 170px;
      }
    }
  }
  &:nth-child(2) {
    ul.ivu-menu-drop-list {
      min-width: 250px;
      width: 100%;

      > li {
        width: 250px;
      }
    }
  }
  &:nth-child(3) {
    ul.ivu-menu-drop-list {
      min-width: 125px;
      width: 100%;

      > li {
        width: 125px;
      }
    }
  }
  &:nth-child(4) {
    ul.ivu-menu-drop-list {
      min-width: 200px;
      width: 100%;

      > li {
        width: 200px;
      }
    }
  }
  &:nth-child(5) {
    ul.ivu-menu-drop-list {
      min-width: 155px;
      width: 100%;

      > li {
        width: 155px;
      }
    }
  }
  &:nth-child(6) {
    ul.ivu-menu-drop-list {
      min-width: 155px;
      width: 100%;

      > li {
        width: 155px;
      }
    }
  }
  &:nth-child(7) {
    ul.ivu-menu-drop-list {
      min-width: 160px;
      width: 100%;

      > li {
        width: 160px;
      }
    }
  }
  &:nth-child(8) {
    ul.ivu-menu-drop-list {
      min-width: 135px;
      width: 100%;

      > li {
        width: 135px;
      }
    }
  }
}
</style>
