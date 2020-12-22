export default {
  data() {
    return {};
  },
  mounted() {},
  methods: {
    editTableDataMenu1(positionId) {
      let dataMenu1 = ['ค้นหาลูกค้า', 'ค้นหารถยนต์', 'ค้นหาผู้จำหน่าย', 'ค้นหาสินค้า']

      if (this.modeEdit == true) {
        for (let i = 0; i < dataMenu1.length; i++) {
          let id = i + 3
          this.dummyMasterPermisson.push({
            PositionId: positionId,
            MenuId: id,
            CreatePermisson: this.tableDataMenu1[i].createAllow === true ? this.tableDataMenu1[i].createAllow : this.tableDataMenu1[i].createAllow === false ? this.tableDataMenu1[i].createAllow : null,
            EditPermisson: this.tableDataMenu1[i].editAllow === true ? this.tableDataMenu1[i].editAllow : this.tableDataMenu1[i].editAllow === false ? this.tableDataMenu1[i].editAllow : null,
            ViewPermisson: this.tableDataMenu1[i].viewAllow === true ? this.tableDataMenu1[i].viewAllow : this.tableDataMenu1[i].viewAllow === false ? this.tableDataMenu1[i].viewAllow : null,
            DeletePermisson: this.tableDataMenu1[i].deleteAllow === true ? this.tableDataMenu1[i].deleteAllow : this.tableDataMenu1[i].deleteAllow === false ? this.tableDataMenu1[i].deleteAllow : null,
            PrintPermisson: this.tableDataMenu1[i].printAllow === true ? this.tableDataMenu1[i].printAllow : this.tableDataMenu1[i].printAllow === false ? this.tableDataMenu1[i].printAllow : null,
          })
        }
      }
      if (this.modeEdit == false) {
        for (let i = 0; i < dataMenu1.length; i++) {
          let id = i + 3
          this.dummyMasterPermisson.push({
            MenuId: id,
            CreatePermisson: this.tableDataMenu1[i].createAllow === true ? this.tableDataMenu1[i].createAllow : this.tableDataMenu1[i].createAllow === false ? this.tableDataMenu1[i].createAllow : null,
            EditPermisson: this.tableDataMenu1[i].editAllow === true ? this.tableDataMenu1[i].editAllow : this.tableDataMenu1[i].editAllow === false ? this.tableDataMenu1[i].editAllow : null,
            ViewPermisson: this.tableDataMenu1[i].viewAllow === true ? this.tableDataMenu1[i].viewAllow : this.tableDataMenu1[i].viewAllow === false ? this.tableDataMenu1[i].viewAllow : null,
            DeletePermisson: this.tableDataMenu1[i].deleteAllow === true ? this.tableDataMenu1[i].deleteAllow : this.tableDataMenu1[i].deleteAllow === false ? this.tableDataMenu1[i].deleteAllow : null,
            PrintPermisson: this.tableDataMenu1[i].printAllow === true ? this.tableDataMenu1[i].printAllow : this.tableDataMenu1[i].printAllow === false ? this.tableDataMenu1[i].printAllow : null,
          })
        }
      }

      
    }
  }
};
