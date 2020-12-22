export default {
  data() {
    return {};
  },
  mounted() {},
  methods: {
    editTableDataMenu8(positionId) {
      let dataMenu8 = ["ตารางนัดหมาย"]

      if (this.modeEdit == true) {
        for (let i = 0; i < dataMenu8.length; i++) {
          let id = i + 45;
          this.dummyMasterPermisson.push({
            PositionId: positionId,
            MenuId: id,
            CreatePermisson:
              this.tableDataMenu8[i].createAllow === true
                ? this.tableDataMenu8[i].createAllow
                : this.tableDataMenu8[i].createAllow === false
                ? this.tableDataMenu8[i].createAllow
                : null,
            EditPermisson:
              this.tableDataMenu8[i].editAllow === true
                ? this.tableDataMenu8[i].editAllow
                : this.tableDataMenu8[i].editAllow === false
                ? this.tableDataMenu8[i].editAllow
                : null,
            ViewPermisson:
              this.tableDataMenu8[i].viewAllow === true
                ? this.tableDataMenu8[i].viewAllow
                : this.tableDataMenu8[i].viewAllow === false
                ? this.tableDataMenu8[i].viewAllow
                : null,
            DeletePermisson:
              this.tableDataMenu8[i].deleteAllow === true
                ? this.tableDataMenu8[i].deleteAllow
                : this.tableDataMenu8[i].deleteAllow === false
                ? this.tableDataMenu8[i].deleteAllow
                : null,
            PrintPermisson:
              this.tableDataMenu8[i].printAllow === true
                ? this.tableDataMenu8[i].printAllow
                : this.tableDataMenu8[i].printAllow === false
                ? this.tableDataMenu8[i].printAllow
                : null
          });
        }
      }
      if (this.modeEdit == false) {
        for (let i = 0; i < dataMenu8.length; i++) {
          let id = i + 45;
          this.dummyMasterPermisson.push({
            MenuId: id,
            CreatePermisson:
              this.tableDataMenu8[i].createAllow === true
                ? this.tableDataMenu8[i].createAllow
                : this.tableDataMenu8[i].createAllow === false
                ? this.tableDataMenu8[i].createAllow
                : null,
            EditPermisson:
              this.tableDataMenu8[i].editAllow === true
                ? this.tableDataMenu8[i].editAllow
                : this.tableDataMenu8[i].editAllow === false
                ? this.tableDataMenu8[i].editAllow
                : null,
            ViewPermisson:
              this.tableDataMenu8[i].viewAllow === true
                ? this.tableDataMenu8[i].viewAllow
                : this.tableDataMenu8[i].viewAllow === false
                ? this.tableDataMenu8[i].viewAllow
                : null,
            DeletePermisson:
              this.tableDataMenu8[i].deleteAllow === true
                ? this.tableDataMenu8[i].deleteAllow
                : this.tableDataMenu8[i].deleteAllow === false
                ? this.tableDataMenu8[i].deleteAllow
                : null,
            PrintPermisson:
              this.tableDataMenu8[i].printAllow === true
                ? this.tableDataMenu8[i].printAllow
                : this.tableDataMenu8[i].printAllow === false
                ? this.tableDataMenu8[i].printAllow
                : null
          });
        }
      }

      
    }
  }
};
