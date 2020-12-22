export default {
  data() {
    return {};
  },
  mounted() {},
  methods: {
    editTableDataMenu13(positionId) {
      let dataMenu13 = [
        "บันทึกการรับเช็ค",
        "บันทึกการจ่ายเช็ค",
        "ค้นหาข้อมูลบัญชีธนาคาร",
        "ข้อมูลบัญชีธนาคาร"
      ]

      if (this.modeEdit == true) {
        for (let i = 0; i < dataMenu13.length; i++) {
          let id = i + 69;
          this.dummyMasterPermisson.push({
            PositionId: positionId,
            MenuId: id,
            CreatePermisson:
              this.tableDataMenu13[i].createAllow === true
                ? this.tableDataMenu13[i].createAllow
                : this.tableDataMenu13[i].createAllow === false
                ? this.tableDataMenu13[i].createAllow
                : null,
            EditPermisson:
              this.tableDataMenu13[i].editAllow === true
                ? this.tableDataMenu13[i].editAllow
                : this.tableDataMenu13[i].editAllow === false
                ? this.tableDataMenu13[i].editAllow
                : null,
            ViewPermisson:
              this.tableDataMenu13[i].viewAllow === true
                ? this.tableDataMenu13[i].viewAllow
                : this.tableDataMenu13[i].viewAllow === false
                ? this.tableDataMenu13[i].viewAllow
                : null,
            DeletePermisson:
              this.tableDataMenu13[i].deleteAllow === true
                ? this.tableDataMenu13[i].deleteAllow
                : this.tableDataMenu13[i].deleteAllow === false
                ? this.tableDataMenu13[i].deleteAllow
                : null,
            PrintPermisson:
              this.tableDataMenu13[i].printAllow === true
                ? this.tableDataMenu13[i].printAllow
                : this.tableDataMenu13[i].printAllow === false
                ? this.tableDataMenu13[i].printAllow
                : null
          });
        }
      }
      if (this.modeEdit == false) {
        for (let i = 0; i < dataMenu13.length; i++) {
          let id = i + 69;
          this.dummyMasterPermisson.push({
            MenuId: id,
            CreatePermisson:
              this.tableDataMenu13[i].createAllow === true
                ? this.tableDataMenu13[i].createAllow
                : this.tableDataMenu13[i].createAllow === false
                ? this.tableDataMenu13[i].createAllow
                : null,
            EditPermisson:
              this.tableDataMenu13[i].editAllow === true
                ? this.tableDataMenu13[i].editAllow
                : this.tableDataMenu13[i].editAllow === false
                ? this.tableDataMenu13[i].editAllow
                : null,
            ViewPermisson:
              this.tableDataMenu13[i].viewAllow === true
                ? this.tableDataMenu13[i].viewAllow
                : this.tableDataMenu13[i].viewAllow === false
                ? this.tableDataMenu13[i].viewAllow
                : null,
            DeletePermisson:
              this.tableDataMenu13[i].deleteAllow === true
                ? this.tableDataMenu13[i].deleteAllow
                : this.tableDataMenu13[i].deleteAllow === false
                ? this.tableDataMenu13[i].deleteAllow
                : null,
            PrintPermisson:
              this.tableDataMenu13[i].printAllow === true
                ? this.tableDataMenu13[i].printAllow
                : this.tableDataMenu13[i].printAllow === false
                ? this.tableDataMenu13[i].printAllow
                : null
          });
        }
      }

      
    }
  }
};
