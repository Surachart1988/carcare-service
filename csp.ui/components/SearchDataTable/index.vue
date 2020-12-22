<template>
  <div layout="row" layout-align="center center" class="search-box" style="width: 60%">
    <Form
      ref="formValidate"
      :model="formItem"
      :rules="ruleValidate"
      layout="row"
      layout-align="center center"
    >
      <FormItem flex="100" prop="searchBox" style="margin-right:1rem">
        <Input
          suffix="ios-search"
          @on-clear="clear()"
          size="large"
          v-model="formItem.searchBox"
          placeholder="ค้นหา..."
          clearable
          :style="{ width: searchboxWidth }"
        />
      </FormItem>

      <FormItem flex="100" prop="select">
        <Select v-model="formItem.select" size="large" :style="{ width: selectWidth }">
          <Option
            v-for="(e, index) in modifyColumns"
            :key="index"
            :value="e.key"
            v-if="e.title != 'Action' "
          >{{e.title}}</Option>
        </Select>
      </FormItem>

      <FormItem flex="100">
      <Button
        type="primary"
        @click="handleSubmit('formValidate')"
        shape="circle"
        size="large"
        style="margin-left:15px;"
      >ค้นหา</Button>
      </FormItem>
    </Form>
  </div>
</template>

<script>
export default {
  props: {
    selectWidth: {
      default: 'auto'
    },
    searchboxWidth: {
      default: 'auto'
    },
    columns: {
      default: '',
      type: Array
    },
    deletePrefix: {
      default: false,
      type: Boolean
    },
    deleteSubfix: {
      default: false,
      type: Boolean
    }
  },
  components: {},
  data() {
    return {
      formItem: {
        searchBox: '',
        select: ''
      },
      ruleValidate: {
        searchBox: { required: true, message: 'กรุณากรอกข้อมูล', trigger: 'blur' },
        select: { required: true, message: 'กรุณากรอกข้อมูล', trigger: 'blur' }
      }
    }
  },
  computed: {
    modifyColumns() {
      let dataSelect = this.columns.clone()

      if (this.deletePrefix) {
        dataSelect.splice(0, 1)
      }
      if (this.deleteSubfix) {
        dataSelect.splice(dataSelect.length - 1, 1)
      }
      return dataSelect
    }
  },
  methods: {
    clear() {
      this.$parent.modeSearch = false
      this.$parent.clearOnDatatable()
    },
    async search() {
      let data = {}
      this.$set(data, this.formItem.select, this.formItem.searchBox)
      
      this.$parent.searchOnDatatable(data)
      this.formItem.searchBox = this.formItem.searchBox
    },
    handleSubmit(name) {
      this.$refs[name].validate(valid => {
        if (valid) {
          this.search()
        } else {
          this.$Message.error('ยังไม่ได้กรอกข้อมูลค้นหา!')
        }
      })
    }
  }
}
</script>

<style lang="scss" scoped>
</style>