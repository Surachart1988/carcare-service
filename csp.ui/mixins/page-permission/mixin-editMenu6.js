export default {
  data() {
    return {};
  },
  mounted() {},
  methods: {
    editTableDataMenu6(positionId) {
      let dataMenu6 = ['ใบหักภาษี ณ ที่จ่าย']

      if (this.modeEdit == true) {
        for (let i = 0; i < dataMenu6.length; i++) {
          let id = i + 28
          this.dummyMasterPermisson.push({
            PositionId: positionId,
            MenuId: id,
            CreatePermisson: this.tableDataMenu6[i].createAllow === true ? this.tableDataMenu6[i].createAllow : this.tableDataMenu6[i].createAllow === false ? this.tableDataMenu6[i].createAllow : null,
            EditPermisson: this.tableDataMenu6[i].editAllow === true ? this.tableDataMenu6[i].editAllow : this.tableDataMenu6[i].editAllow === false ? this.tableDataMenu6[i].editAllow : null,
            ViewPermisson: this.tableDataMenu6[i].viewAllow === true ? this.tableDataMenu6[i].viewAllow : this.tableDataMenu6[i].viewAllow === false ? this.tableDataMenu6[i].viewAllow : null,
            DeletePermisson: this.tableDataMenu6[i].deleteAllow === true ? this.tableDataMenu6[i].deleteAllow : this.tableDataMenu6[i].deleteAllow === false ? this.tableDataMenu6[i].deleteAllow : null,
            PrintPermisson: this.tableDataMenu6[i].printAllow === true ? this.tableDataMenu6[i].printAllow : this.tableDataMenu6[i].printAllow === false ? this.tableDataMenu6[i].printAllow : null,
          })
        }
      }
      if (this.modeEdit == false) {
        for (let i = 0; i < dataMenu6.length; i++) {
          let id = i + 28
          this.dummyMasterPermisson.push({
            MenuId: id,
            CreatePermisson: this.tableDataMenu6[i].createAllow === true ? this.tableDataMenu6[i].createAllow : this.tableDataMenu6[i].createAllow === false ? this.tableDataMenu6[i].createAllow : null,
            EditPermisson: this.tableDataMenu6[i].editAllow === true ? this.tableDataMenu6[i].editAllow : this.tableDataMenu6[i].editAllow === false ? this.tableDataMenu6[i].editAllow : null,
            ViewPermisson: this.tableDataMenu6[i].viewAllow === true ? this.tableDataMenu6[i].viewAllow : this.tableDataMenu6[i].viewAllow === false ? this.tableDataMenu6[i].viewAllow : null,
            DeletePermisson: this.tableDataMenu6[i].deleteAllow === true ? this.tableDataMenu6[i].deleteAllow : this.tableDataMenu6[i].deleteAllow === false ? this.tableDataMenu6[i].deleteAllow : null,
            PrintPermisson: this.tableDataMenu6[i].printAllow === true ? this.tableDataMenu6[i].printAllow : this.tableDataMenu6[i].printAllow === false ? this.tableDataMenu6[i].printAllow : null,
          })
        }
      }
      
      
    }
  }
};
