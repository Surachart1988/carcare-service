<template>
  <div class="component-wrapper">
    <Form
          ref="formValidate"
          :model="demo"
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
              <Input disabled size="large" v-model="demo" placeholder="username"></Input>
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
            </FormItem>
                        
<Input disabled size="large" v-model="demo" placeholder="username"></Input>
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
                <i-switch size="large" v-model="demo">
                  <span slot="open">อนุญาต</span>
                  <span slot="close">ไม่อนุญาต</span>
                </i-switch>
              </div>
            </FormItem>
           
                       
          </section>
          <section layout="row" layout-wrap layout-align="center center" flex="100">
          <FormItem
              prop="positionId"
              label="111"
              flex-xs="100"
              flex-sm="100"
              flex-md="100"
              flex-gt-md="40"
              
            >
            <Input size="large" v-model="demo" placeholder="username"></Input>
            </FormItem>
             <FormItem
              prop="positionId"
              label="222"
              flex-xs="100"
              flex-sm="100"
              flex-md="100"
              flex-gt-md="40"
             
            >
            <Input size="large" v-model="demo" placeholder="username"></Input>
            </FormItem>
            </section>
          </form>
  </div>
</template>

<script>


export default {
  components: {
  
  },
  data() {
    return {
      demo: ''
    }
  },
  computed: {
  
  },
  mounted() {
    
  },
  methods: {

  }
}
</script>

<style lang="scss" scoped></style>
