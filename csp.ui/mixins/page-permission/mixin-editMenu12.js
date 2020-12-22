export default {
  data() {
    return {};
  },
  mounted() {},
  methods: {
    editTableDataMenu12(positionId) {
      let dataMenu12 = [
        "ใบชำระลูกหนี้",
        "ใบคืนชำระลูกหนี้",
        "ใบลดหนี้ลูกหนี้",
        "ใบลดหนี้ลูกหนี้(ตามใบเสร็จ)",
        "ใบเพิ่มหนี้ลูกหนี้",
        "ใบเพิ่มหนี้ลูกหนี้(ตามใบเสร็จ)",
        "ใบแจ้งหนี้"
      ]

      if (this.modeEdit == true) {
        for (let i = 0; i < dataMenu12.length; i++) {
          let id = i + 61;
          this.dummyMasterPermisson.push({
            PositionId: positionId,
            MenuId: id,
            CreatePermisson:
              this.tableDataMenu12[i].createAllow === true
                ? this.tableDataMenu12[i].createAllow
                : this.tableDataMenu12[i].createAllow === false
                ? this.tableDataMenu12[i].createAllow
                : null,
            EditPermisson:
              this.tableDataMenu12[i].editAllow === true
                ? this.tableDataMenu12[i].editAllow
                : this.tableDataMenu12[i].editAllow === false
                ? this.tableDataMenu12[i].editAllow
                : null,
            ViewPermisson:
              this.tableDataMenu12[i].viewAllow === true
                ? this.tableDataMenu12[i].viewAllow
                : this.tableDataMenu12[i].viewAllow === false
                ? this.tableDataMenu12[i].viewAllow
                : null,
            DeletePermisson:
              this.tableDataMenu12[i].deleteAllow === true
                ? this.tableDataMenu12[i].deleteAllow
                : this.tableDataMenu12[i].deleteAllow === false
                ? this.tableDataMenu12[i].deleteAllow
                : null,
            PrintPermisson:
              this.tableDataMenu12[i].printAllow === true
                ? this.tableDataMenu12[i].printAllow
                : this.tableDataMenu12[i].printAllow === false
                ? this.tableDataMenu12[i].printAllow
                : null
          });
        }
      }
      if (this.modeEdit == false) {
        for (let i = 0; i < dataMenu12.length; i++) {
          let id = i + 61;
          this.dummyMasterPermisson.push({
            MenuId: id,
            CreatePermisson:
              this.tableDataMenu12[i].createAllow === true
                ? this.tableDataMenu12[i].createAllow
                : this.tableDataMenu12[i].createAllow === false
                ? this.tableDataMenu12[i].createAllow
                : null,
            EditPermisson:
              this.tableDataMenu12[i].editAllow === true
                ? this.tableDataMenu12[i].editAllow
                : this.tableDataMenu12[i].editAllow === false
                ? this.tableDataMenu12[i].editAllow
                : null,
            ViewPermisson:
              this.tableDataMenu12[i].viewAllow === true
                ? this.tableDataMenu12[i].viewAllow
                : this.tableDataMenu12[i].viewAllow === false
                ? this.tableDataMenu12[i].viewAllow
                : null,
            DeletePermisson:
              this.tableDataMenu12[i].deleteAllow === true
                ? this.tableDataMenu12[i].deleteAllow
                : this.tableDataMenu12[i].deleteAllow === false
                ? this.tableDataMenu12[i].deleteAllow
                : null,
            PrintPermisson:
              this.tableDataMenu12[i].printAllow === true
                ? this.tableDataMenu12[i].printAllow
                : this.tableDataMenu12[i].printAllow === false
                ? this.tableDataMenu12[i].printAllow
                : null
          });
        }
      }

      
    }
  }
};
