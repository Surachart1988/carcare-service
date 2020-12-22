<template>
  <div class="component-wrapper">
    <HeaderPage>
      ข้อมูลหลัก
      <!-- <template v-slot:subheader>
      xxx
      </template>-->
    </HeaderPage>

    <MasterDataMenu style="margin-top:-10px"></MasterDataMenu>

    <div class="wrapper-alert" layout="column" layout-align="center center">
      <div layout="row" layout-wrap layout-align="center center">
        <div flex="100">
          <div
            flex="100"
            class="alert-header"
          >เป็นการกำหนดข้อมูลหลักที่ใช้ในโปรแกรม ซึ่งข้อมูลแต่ละตัวผู้ใช้สามารถ เพิ่ม แก้ไข และ ลบ ได้</div>
          <div
            flex="100"
            class="alert-header"
          >โดยต้องทำการแก้ไขก่อนการเริ่มใช้งานโปรแกรม เพราะถ้าแก้ไขหลังจากที่เริ่มใช้โปรแกรมแล้ว ข้อมูลอาจจะผิดเพี้ยนได้</div>
          <div
            flex="100"
            class="alert-bigheader"
          >การทำงานให้คลิกไปที่ชื่อเมนูข้อมูลด้านบนที่ต้องการจัดการข้อมูล</div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import HeaderPage from '@/components/HeaderPage'
import MasterDataMenu from '@/components/MasterDataMenu'

export default {
  components: {
    HeaderPage,
    MasterDataMenu
  },
  data() {
    return {}
  }
}
</script>

<style lang="scss">
</style>