export default {
  data() {
    return {};
  },
  mounted() {},
  methods: {
    editTableDataMenu15(positionId) {
      let dataMenu15 = [
        "กำหนดการทำงานระบบ",
        "กำหนดข้อมูลบริษัท",
        "ข้อมูลเริ่มต้นระบบ",
        "สอบถามการใช้งานระบบ",
        "ค้นหาการใช้งานเอกสาร"
      ]

      if (this.modeEdit == true) {
        for (let i = 0; i < dataMenu15.length; i++) {
          let id = i + 85;
          this.dummyMasterPermisson.push({
            PositionId: positionId,
            MenuId: id,
            CreatePermisson:
              this.tableDataMenu15[i].createAllow === true
                ? this.tableDataMenu15[i].createAllow
                : this.tableDataMenu15[i].createAllow === false
                ? this.tableDataMenu15[i].createAllow
                : null,
            EditPermisson:
              this.tableDataMenu15[i].editAllow === true
                ? this.tableDataMenu15[i].editAllow
                : this.tableDataMenu15[i].editAllow === false
                ? this.tableDataMenu15[i].editAllow
                : null,
            ViewPermisson:
              this.tableDataMenu15[i].viewAllow === true
                ? this.tableDataMenu15[i].viewAllow
                : this.tableDataMenu15[i].viewAllow === false
                ? this.tableDataMenu15[i].viewAllow
                : null,
            DeletePermisson:
              this.tableDataMenu15[i].deleteAllow === true
                ? this.tableDataMenu15[i].deleteAllow
                : this.tableDataMenu15[i].deleteAllow === false
                ? this.tableDataMenu15[i].deleteAllow
                : null,
            PrintPermisson:
              this.tableDataMenu15[i].printAllow === true
                ? this.tableDataMenu15[i].printAllow
                : this.tableDataMenu15[i].printAllow === false
                ? this.tableDataMenu15[i].printAllow
                : null
          });
        }
      }
      if (this.modeEdit == false) {
        for (let i = 0; i < dataMenu15.length; i++) {
          let id = i + 85;
          this.dummyMasterPermisson.push({
            MenuId: id,
            CreatePermisson:
              this.tableDataMenu15[i].createAllow === true
                ? this.tableDataMenu15[i].createAllow
                : this.tableDataMenu15[i].createAllow === false
                ? this.tableDataMenu15[i].createAllow
                : null,
            EditPermisson:
              this.tableDataMenu15[i].editAllow === true
                ? this.tableDataMenu15[i].editAllow
                : this.tableDataMenu15[i].editAllow === false
                ? this.tableDataMenu15[i].editAllow
                : null,
            ViewPermisson:
              this.tableDataMenu15[i].viewAllow === true
                ? this.tableDataMenu15[i].viewAllow
                : this.tableDataMenu15[i].viewAllow === false
                ? this.tableDataMenu15[i].viewAllow
                : null,
            DeletePermisson:
              this.tableDataMenu15[i].deleteAllow === true
                ? this.tableDataMenu15[i].deleteAllow
                : this.tableDataMenu15[i].deleteAllow === false
                ? this.tableDataMenu15[i].deleteAllow
                : null,
            PrintPermisson:
              this.tableDataMenu15[i].printAllow === true
                ? this.tableDataMenu15[i].printAllow
                : this.tableDataMenu15[i].printAllow === false
                ? this.tableDataMenu15[i].printAllow
                : null
          });
        }
      }

      
    }
  }
};
