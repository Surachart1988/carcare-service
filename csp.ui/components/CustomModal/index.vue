<template>
<div>
  <Modal v-if="useModalConfirm" v-model="modalConfirm" width="360" class-name="vertical-center-modal custom-modal" @on-cancel="closeModal()">
        <div style="text-align:center; padding-top:50px">
          <Icon type="md-information-circle" class="icon-confirm"/>
            <p>ต้องการลบ</p>
            <p>ข้อมูลนี้หรือไม่</p>
        </div>
        <div slot="footer">
        <div layout="row" layout-align="center center">
          <Button
            type="primary"
            ghost
            shape="circle"
            size="large"
            @click="submitModal()"
          >{{okButton}}</Button>
          <Button type="default" ghost shape="circle" size="large" @click="closeModal()">ยกเลิก</Button>
        </div>
      </div>
    </Modal>


    <Modal v-if="useModalPermission" v-model="modalPermission" width="360" class-name="vertical-center-modal custom-modal" :closable="false" :mask-closable="false" :lock-scroll ="false">
        <div style="text-align:center; padding-top:50px">
          <Icon type="md-information-circle" class="icon-confirm"/>
            <p>คุณไม่ได้รับสิทธิ์</p>
            <p>ในการเข้าถึงข้อมูลหน้านี้</p>
        </div>
        <div slot="footer">
        <div layout="row" layout-align="center center">
          <Button
            type="primary"
            ghost
            shape="circle"
            size="large"
            @click="modalPermission = false"
          >{{okButton}}</Button>
        </div>
      </div>
    </Modal>
</div>
</template>

<script>

export default {
  props: {
    modalConfirm: {
      type: Boolean,
      default: false
    },
    useModalConfirm: {
      type: Boolean,
      default: false
    },

    useModalPermission: {
      type: Boolean,
      default: false
    },
    okButton: {
      type: String,
      default: 'บันทึก'
    }
  },
  data() {
    return {
      modalPermission: true
    }
  },
  mounted() {
  },
  methods: {
    submitModal() {
      this.$parent.submitModalConfirm()
    },
    closeModal() {
      this.$parent.closeModalConfirm()
    }
  }
}
</script>