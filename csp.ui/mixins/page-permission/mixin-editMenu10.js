export default {
  data() {
    return {};
  },
  mounted() {},
  methods: {
    editTableDataMenu10(positionId) {
      let dataMenu10 = ["บันทึกรับ-จ่ายเงินสด", "ปิดสิ้นวัน"]

      if (this.modeEdit == true) {
        for (let i = 0; i < dataMenu10.length; i++) {
          let id = i + 51;
          this.dummyMasterPermisson.push({
            PositionId: positionId,
            MenuId: id,
            CreatePermisson:
              this.tableDataMenu10[i].createAllow === true
                ? this.tableDataMenu10[i].createAllow
                : this.tableDataMenu10[i].createAllow === false
                ? this.tableDataMenu10[i].createAllow
                : null,
            EditPermisson:
              this.tableDataMenu10[i].editAllow === true
                ? this.tableDataMenu10[i].editAllow
                : this.tableDataMenu10[i].editAllow === false
                ? this.tableDataMenu10[i].editAllow
                : null,
            ViewPermisson:
              this.tableDataMenu10[i].viewAllow === true
                ? this.tableDataMenu10[i].viewAllow
                : this.tableDataMenu10[i].viewAllow === false
                ? this.tableDataMenu10[i].viewAllow
                : null,
            DeletePermisson:
              this.tableDataMenu10[i].deleteAllow === true
                ? this.tableDataMenu10[i].deleteAllow
                : this.tableDataMenu10[i].deleteAllow === false
                ? this.tableDataMenu10[i].deleteAllow
                : null,
            PrintPermisson:
              this.tableDataMenu10[i].printAllow === true
                ? this.tableDataMenu10[i].printAllow
                : this.tableDataMenu10[i].printAllow === false
                ? this.tableDataMenu10[i].printAllow
                : null
          });
        }
      }
      if (this.modeEdit == false) {
        for (let i = 0; i < dataMenu10.length; i++) {
          let id = i + 51;
          this.dummyMasterPermisson.push({
            MenuId: id,
            CreatePermisson:
              this.tableDataMenu10[i].createAllow === true
                ? this.tableDataMenu10[i].createAllow
                : this.tableDataMenu10[i].createAllow === false
                ? this.tableDataMenu10[i].createAllow
                : null,
            EditPermisson:
              this.tableDataMenu10[i].editAllow === true
                ? this.tableDataMenu10[i].editAllow
                : this.tableDataMenu10[i].editAllow === false
                ? this.tableDataMenu10[i].editAllow
                : null,
            ViewPermisson:
              this.tableDataMenu10[i].viewAllow === true
                ? this.tableDataMenu10[i].viewAllow
                : this.tableDataMenu10[i].viewAllow === false
                ? this.tableDataMenu10[i].viewAllow
                : null,
            DeletePermisson:
              this.tableDataMenu10[i].deleteAllow === true
                ? this.tableDataMenu10[i].deleteAllow
                : this.tableDataMenu10[i].deleteAllow === false
                ? this.tableDataMenu10[i].deleteAllow
                : null,
            PrintPermisson:
              this.tableDataMenu10[i].printAllow === true
                ? this.tableDataMenu10[i].printAllow
                : this.tableDataMenu10[i].printAllow === false
                ? this.tableDataMenu10[i].printAllow
                : null
          });
        }
      }

      
    }
  }
};
