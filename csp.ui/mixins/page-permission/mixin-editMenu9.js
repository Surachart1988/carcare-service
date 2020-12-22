export default {
  data() {
    return {};
  },
  mounted() {},
  methods: {
    editTableDataMenu9(positionId) {
      let dataMenu9 = [
        "ลูกค้าสัมพันธ์",
        "แบบประเมินความพึงพอใจลูกค้า",
        "ติดตามผลการให้บริการ"
      ]

      if (this.modeEdit == true) {
        for (let i = 0; i < dataMenu9.length; i++) {
          let id = i + 47;
          this.dummyMasterPermisson.push({
            PositionId: positionId,
            MenuId: id,
            CreatePermisson:
              this.tableDataMenu9[i].createAllow === true
                ? this.tableDataMenu9[i].createAllow
                : this.tableDataMenu9[i].createAllow === false
                ? this.tableDataMenu9[i].createAllow
                : null,
            EditPermisson:
              this.tableDataMenu9[i].editAllow === true
                ? this.tableDataMenu9[i].editAllow
                : this.tableDataMenu9[i].editAllow === false
                ? this.tableDataMenu9[i].editAllow
                : null,
            ViewPermisson:
              this.tableDataMenu9[i].viewAllow === true
                ? this.tableDataMenu9[i].viewAllow
                : this.tableDataMenu9[i].viewAllow === false
                ? this.tableDataMenu9[i].viewAllow
                : null,
            DeletePermisson:
              this.tableDataMenu9[i].deleteAllow === true
                ? this.tableDataMenu9[i].deleteAllow
                : this.tableDataMenu9[i].deleteAllow === false
                ? this.tableDataMenu9[i].deleteAllow
                : null,
            PrintPermisson:
              this.tableDataMenu9[i].printAllow === true
                ? this.tableDataMenu9[i].printAllow
                : this.tableDataMenu9[i].printAllow === false
                ? this.tableDataMenu9[i].printAllow
                : null
          });
        }
      }
      if (this.modeEdit == false) {
        for (let i = 0; i < dataMenu9.length; i++) {
          let id = i + 47;
          this.dummyMasterPermisson.push({
            MenuId: id,
            CreatePermisson:
              this.tableDataMenu9[i].createAllow === true
                ? this.tableDataMenu9[i].createAllow
                : this.tableDataMenu9[i].createAllow === false
                ? this.tableDataMenu9[i].createAllow
                : null,
            EditPermisson:
              this.tableDataMenu9[i].editAllow === true
                ? this.tableDataMenu9[i].editAllow
                : this.tableDataMenu9[i].editAllow === false
                ? this.tableDataMenu9[i].editAllow
                : null,
            ViewPermisson:
              this.tableDataMenu9[i].viewAllow === true
                ? this.tableDataMenu9[i].viewAllow
                : this.tableDataMenu9[i].viewAllow === false
                ? this.tableDataMenu9[i].viewAllow
                : null,
            DeletePermisson:
              this.tableDataMenu9[i].deleteAllow === true
                ? this.tableDataMenu9[i].deleteAllow
                : this.tableDataMenu9[i].deleteAllow === false
                ? this.tableDataMenu9[i].deleteAllow
                : null,
            PrintPermisson:
              this.tableDataMenu9[i].printAllow === true
                ? this.tableDataMenu9[i].printAllow
                : this.tableDataMenu9[i].printAllow === false
                ? this.tableDataMenu9[i].printAllow
                : null
          });
        }
      }

      
    }
  }
};
