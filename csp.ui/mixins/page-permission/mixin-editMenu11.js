export default {
  data() {
    return {};
  },
  mounted() {},
  methods: {
    editTableDataMenu11(positionId) {
      let dataMenu11 = [
        "ใบชำระเจ้าหนี้",
        "ใบเจ้าหนี้คืนชำระ",
        "ใบลดหนี้เจ้าหนี้",
        "ใบลดหนี้เจ้าหนี้(ตามใบรับเข้า)",
        "ใบเพิ่มหนี้เจ้าหนี้",
        "ใบเพิ่มหนี้เจ้าหนี้(ตามใบรับเข้า)"
      ]

      if (this.modeEdit == true) {
        for (let i = 0; i < dataMenu11.length; i++) {
          let id = i + 54;
          this.dummyMasterPermisson.push({
            PositionId: positionId,
            MenuId: id,
            CreatePermisson:
              this.tableDataMenu11[i].createAllow === true
                ? this.tableDataMenu11[i].createAllow
                : this.tableDataMenu11[i].createAllow === false
                ? this.tableDataMenu11[i].createAllow
                : null,
            EditPermisson:
              this.tableDataMenu11[i].editAllow === true
                ? this.tableDataMenu11[i].editAllow
                : this.tableDataMenu11[i].editAllow === false
                ? this.tableDataMenu11[i].editAllow
                : null,
            ViewPermisson:
              this.tableDataMenu11[i].viewAllow === true
                ? this.tableDataMenu11[i].viewAllow
                : this.tableDataMenu11[i].viewAllow === false
                ? this.tableDataMenu11[i].viewAllow
                : null,
            DeletePermisson:
              this.tableDataMenu11[i].deleteAllow === true
                ? this.tableDataMenu11[i].deleteAllow
                : this.tableDataMenu11[i].deleteAllow === false
                ? this.tableDataMenu11[i].deleteAllow
                : null,
            PrintPermisson:
              this.tableDataMenu11[i].printAllow === true
                ? this.tableDataMenu11[i].printAllow
                : this.tableDataMenu11[i].printAllow === false
                ? this.tableDataMenu11[i].printAllow
                : null
          });
        }
      }
      if (this.modeEdit == false) {
        for (let i = 0; i < dataMenu11.length; i++) {
          let id = i + 54;
          this.dummyMasterPermisson.push({
            MenuId: id,
            CreatePermisson:
              this.tableDataMenu11[i].createAllow === true
                ? this.tableDataMenu11[i].createAllow
                : this.tableDataMenu11[i].createAllow === false
                ? this.tableDataMenu11[i].createAllow
                : null,
            EditPermisson:
              this.tableDataMenu11[i].editAllow === true
                ? this.tableDataMenu11[i].editAllow
                : this.tableDataMenu11[i].editAllow === false
                ? this.tableDataMenu11[i].editAllow
                : null,
            ViewPermisson:
              this.tableDataMenu11[i].viewAllow === true
                ? this.tableDataMenu11[i].viewAllow
                : this.tableDataMenu11[i].viewAllow === false
                ? this.tableDataMenu11[i].viewAllow
                : null,
            DeletePermisson:
              this.tableDataMenu11[i].deleteAllow === true
                ? this.tableDataMenu11[i].deleteAllow
                : this.tableDataMenu11[i].deleteAllow === false
                ? this.tableDataMenu11[i].deleteAllow
                : null,
            PrintPermisson:
              this.tableDataMenu11[i].printAllow === true
                ? this.tableDataMenu11[i].printAllow
                : this.tableDataMenu11[i].printAllow === false
                ? this.tableDataMenu11[i].printAllow
                : null
          });
        }
      }

      
    }
  }
};
