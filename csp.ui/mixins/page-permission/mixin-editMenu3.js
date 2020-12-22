export default {
  data() {
    return {};
  },
  mounted() {},
  methods: {
    editTableDataMenu3(positionId) {
      let dataMenu3 = ["ใบสั่งซื้อสินค้า"];

      if (this.modeEdit == true) {
        for (let i = 0; i < dataMenu3.length; i++) {
          let id = i + 17;
          this.dummyMasterPermisson.push({
            PositionId: positionId,
            MenuId: id,
            CreatePermisson:
              this.tableDataMenu3[i].createAllow === true
                ? this.tableDataMenu3[i].createAllow
                : this.tableDataMenu3[i].createAllow === false
                ? this.tableDataMenu3[i].createAllow
                : null,
            EditPermisson:
              this.tableDataMenu3[i].editAllow === true
                ? this.tableDataMenu3[i].editAllow
                : this.tableDataMenu3[i].editAllow === false
                ? this.tableDataMenu3[i].editAllow
                : null,
            ViewPermisson:
              this.tableDataMenu3[i].viewAllow === true
                ? this.tableDataMenu3[i].viewAllow
                : this.tableDataMenu3[i].viewAllow === false
                ? this.tableDataMenu3[i].viewAllow
                : null,
            DeletePermisson:
              this.tableDataMenu3[i].deleteAllow === true
                ? this.tableDataMenu3[i].deleteAllow
                : this.tableDataMenu3[i].deleteAllow === false
                ? this.tableDataMenu3[i].deleteAllow
                : null,
            PrintPermisson:
              this.tableDataMenu3[i].printAllow === true
                ? this.tableDataMenu3[i].printAllow
                : this.tableDataMenu3[i].printAllow === false
                ? this.tableDataMenu3[i].printAllow
                : null
          });
        }
      }
      if (this.modeEdit == false) {
        for (let i = 0; i < dataMenu3.length; i++) {
          let id = i + 17;
          this.dummyMasterPermisson.push({
            MenuId: id,
            CreatePermisson:
              this.tableDataMenu3[i].createAllow === true
                ? this.tableDataMenu3[i].createAllow
                : this.tableDataMenu3[i].createAllow === false
                ? this.tableDataMenu3[i].createAllow
                : null,
            EditPermisson:
              this.tableDataMenu3[i].editAllow === true
                ? this.tableDataMenu3[i].editAllow
                : this.tableDataMenu3[i].editAllow === false
                ? this.tableDataMenu3[i].editAllow
                : null,
            ViewPermisson:
              this.tableDataMenu3[i].viewAllow === true
                ? this.tableDataMenu3[i].viewAllow
                : this.tableDataMenu3[i].viewAllow === false
                ? this.tableDataMenu3[i].viewAllow
                : null,
            DeletePermisson:
              this.tableDataMenu3[i].deleteAllow === true
                ? this.tableDataMenu3[i].deleteAllow
                : this.tableDataMenu3[i].deleteAllow === false
                ? this.tableDataMenu3[i].deleteAllow
                : null,
            PrintPermisson:
              this.tableDataMenu3[i].printAllow === true
                ? this.tableDataMenu3[i].printAllow
                : this.tableDataMenu3[i].printAllow === false
                ? this.tableDataMenu3[i].printAllow
                : null
          });
        }
      }

      
    }
  }
};
