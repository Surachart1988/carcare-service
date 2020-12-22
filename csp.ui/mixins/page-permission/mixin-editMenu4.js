export default {
  data() {
    return {};
  },
  mounted() {},
  methods: {
    editTableDataMenu4(positionId) {
      let dataMenu4 = [
        "ใบรับเข้าสินค้า",
        "ใบส่งคืนสินค้า",
        "ใบปรับลดปรับเพิ่ม",
        "ใบรับเคลมสินค้า",
        "ใบเช็คสต๊อกสินค้า"
      ];

      if (this.modeEdit == true) {
        for (let i = 0; i < dataMenu4.length; i++) {
          let id = i + 19;
          this.dummyMasterPermisson.push({
            PositionId: positionId,
            MenuId: id,
            CreatePermisson:
              this.tableDataMenu4[i].createAllow === true
                ? this.tableDataMenu4[i].createAllow
                : this.tableDataMenu4[i].createAllow === false
                ? this.tableDataMenu4[i].createAllow
                : null,
            EditPermisson:
              this.tableDataMenu4[i].editAllow === true
                ? this.tableDataMenu4[i].editAllow
                : this.tableDataMenu4[i].editAllow === false
                ? this.tableDataMenu4[i].editAllow
                : null,
            ViewPermisson:
              this.tableDataMenu4[i].viewAllow === true
                ? this.tableDataMenu4[i].viewAllow
                : this.tableDataMenu4[i].viewAllow === false
                ? this.tableDataMenu4[i].viewAllow
                : null,
            DeletePermisson:
              this.tableDataMenu4[i].deleteAllow === true
                ? this.tableDataMenu4[i].deleteAllow
                : this.tableDataMenu4[i].deleteAllow === false
                ? this.tableDataMenu4[i].deleteAllow
                : null,
            PrintPermisson:
              this.tableDataMenu4[i].printAllow === true
                ? this.tableDataMenu4[i].printAllow
                : this.tableDataMenu4[i].printAllow === false
                ? this.tableDataMenu4[i].printAllow
                : null
          });
        }
      }
      if (this.modeEdit == false) {
        for (let i = 0; i < dataMenu4.length; i++) {
          let id = i + 19;
          this.dummyMasterPermisson.push({
            MenuId: id,
            CreatePermisson:
              this.tableDataMenu4[i].createAllow === true
                ? this.tableDataMenu4[i].createAllow
                : this.tableDataMenu4[i].createAllow === false
                ? this.tableDataMenu4[i].createAllow
                : null,
            EditPermisson:
              this.tableDataMenu4[i].editAllow === true
                ? this.tableDataMenu4[i].editAllow
                : this.tableDataMenu4[i].editAllow === false
                ? this.tableDataMenu4[i].editAllow
                : null,
            ViewPermisson:
              this.tableDataMenu4[i].viewAllow === true
                ? this.tableDataMenu4[i].viewAllow
                : this.tableDataMenu4[i].viewAllow === false
                ? this.tableDataMenu4[i].viewAllow
                : null,
            DeletePermisson:
              this.tableDataMenu4[i].deleteAllow === true
                ? this.tableDataMenu4[i].deleteAllow
                : this.tableDataMenu4[i].deleteAllow === false
                ? this.tableDataMenu4[i].deleteAllow
                : null,
            PrintPermisson:
              this.tableDataMenu4[i].printAllow === true
                ? this.tableDataMenu4[i].printAllow
                : this.tableDataMenu4[i].printAllow === false
                ? this.tableDataMenu4[i].printAllow
                : null
          });
        }
      }

      
    }
  }
};
