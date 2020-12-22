export default {
  data() {
    return {};
  },
  mounted() {},
  methods: {
    editTableDataMenu5(positionId) {
      let dataMenu5 = ['ใบบันทึกค่าใช้จ่าย', 'ใบเบิกวัสดุสิ้นเปลือง']

      if (this.modeEdit == true) {
        for (let i = 0; i < dataMenu5.length; i++) {
          let id = i + 25
          this.dummyMasterPermisson.push({
            PositionId: positionId,
            MenuId: id,
            CreatePermisson: this.tableDataMenu5[i].createAllow === true ? this.tableDataMenu5[i].createAllow : this.tableDataMenu5[i].createAllow === false ? this.tableDataMenu5[i].createAllow : null,
            EditPermisson: this.tableDataMenu5[i].editAllow === true ? this.tableDataMenu5[i].editAllow : this.tableDataMenu5[i].editAllow === false ? this.tableDataMenu5[i].editAllow : null,
            ViewPermisson: this.tableDataMenu5[i].viewAllow === true ? this.tableDataMenu5[i].viewAllow : this.tableDataMenu5[i].viewAllow === false ? this.tableDataMenu5[i].viewAllow : null,
            DeletePermisson: this.tableDataMenu5[i].deleteAllow === true ? this.tableDataMenu5[i].deleteAllow : this.tableDataMenu5[i].deleteAllow === false ? this.tableDataMenu5[i].deleteAllow : null,
            PrintPermisson: this.tableDataMenu5[i].printAllow === true ? this.tableDataMenu5[i].printAllow : this.tableDataMenu5[i].printAllow === false ? this.tableDataMenu5[i].printAllow : null,
          })
        }
      }
      if (this.modeEdit == false) {
        for (let i = 0; i < dataMenu5.length; i++) {
          let id = i + 25
          this.dummyMasterPermisson.push({
            MenuId: id,
            CreatePermisson: this.tableDataMenu5[i].createAllow === true ? this.tableDataMenu5[i].createAllow : this.tableDataMenu5[i].createAllow === false ? this.tableDataMenu5[i].createAllow : null,
            EditPermisson: this.tableDataMenu5[i].editAllow === true ? this.tableDataMenu5[i].editAllow : this.tableDataMenu5[i].editAllow === false ? this.tableDataMenu5[i].editAllow : null,
            ViewPermisson: this.tableDataMenu5[i].viewAllow === true ? this.tableDataMenu5[i].viewAllow : this.tableDataMenu5[i].viewAllow === false ? this.tableDataMenu5[i].viewAllow : null,
            DeletePermisson: this.tableDataMenu5[i].deleteAllow === true ? this.tableDataMenu5[i].deleteAllow : this.tableDataMenu5[i].deleteAllow === false ? this.tableDataMenu5[i].deleteAllow : null,
            PrintPermisson: this.tableDataMenu5[i].printAllow === true ? this.tableDataMenu5[i].printAllow : this.tableDataMenu5[i].printAllow === false ? this.tableDataMenu5[i].printAllow : null,
          })
        }
      }

      
    }
  }
};
