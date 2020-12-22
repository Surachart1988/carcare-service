export default {
  data() {
    return {};
  },
  mounted() {},
  methods: {
    editTableDataMenu2(positionId) {
      let dataMenu2 = [
        "ใบสั่งซ่อม",
        "ใบเสร็จรับเงิน/ใบกำกับภาษี(อย่างย่อ)",
        "ใบส่งสินค้าชั่วคราว",
        "ใบกำกับภาษีเต็มรูป",
        "ใบลดหนี้/รับคืนสินค้า",
        "ใบเสนอราคา",
        "ใบรับมัดจำ",
        "ใบตรวจสภาพรถยนต์"
      ];

      if (this.modeEdit == true) {
        for (let i = 0; i < dataMenu2.length; i++) {
          let id = i + 8;
          this.dummyMasterPermisson.push({
            PositionId: positionId,
            MenuId: id,
            CreatePermisson:
              this.tableDataMenu2[i].createAllow === true
                ? this.tableDataMenu2[i].createAllow
                : this.tableDataMenu2[i].createAllow === false
                ? this.tableDataMenu2[i].createAllow
                : null,
            EditPermisson:
              this.tableDataMenu2[i].editAllow === true
                ? this.tableDataMenu2[i].editAllow
                : this.tableDataMenu2[i].editAllow === false
                ? this.tableDataMenu2[i].editAllow
                : null,
            ViewPermisson:
              this.tableDataMenu2[i].viewAllow === true
                ? this.tableDataMenu2[i].viewAllow
                : this.tableDataMenu2[i].viewAllow === false
                ? this.tableDataMenu2[i].viewAllow
                : null,
            DeletePermisson:
              this.tableDataMenu2[i].deleteAllow === true
                ? this.tableDataMenu2[i].deleteAllow
                : this.tableDataMenu2[i].deleteAllow === false
                ? this.tableDataMenu2[i].deleteAllow
                : null,
            PrintPermisson:
              this.tableDataMenu2[i].printAllow === true
                ? this.tableDataMenu2[i].printAllow
                : this.tableDataMenu2[i].printAllow === false
                ? this.tableDataMenu2[i].printAllow
                : null
          });
        }
      }
      if (this.modeEdit == false) {
        for (let i = 0; i < dataMenu2.length; i++) {
          let id = i + 8;
          this.dummyMasterPermisson.push({
            MenuId: id,
            CreatePermisson:
              this.tableDataMenu2[i].createAllow === true
                ? this.tableDataMenu2[i].createAllow
                : this.tableDataMenu2[i].createAllow === false
                ? this.tableDataMenu2[i].createAllow
                : null,
            EditPermisson:
              this.tableDataMenu2[i].editAllow === true
                ? this.tableDataMenu2[i].editAllow
                : this.tableDataMenu2[i].editAllow === false
                ? this.tableDataMenu2[i].editAllow
                : null,
            ViewPermisson:
              this.tableDataMenu2[i].viewAllow === true
                ? this.tableDataMenu2[i].viewAllow
                : this.tableDataMenu2[i].viewAllow === false
                ? this.tableDataMenu2[i].viewAllow
                : null,
            DeletePermisson:
              this.tableDataMenu2[i].deleteAllow === true
                ? this.tableDataMenu2[i].deleteAllow
                : this.tableDataMenu2[i].deleteAllow === false
                ? this.tableDataMenu2[i].deleteAllow
                : null,
            PrintPermisson:
              this.tableDataMenu2[i].printAllow === true
                ? this.tableDataMenu2[i].printAllow
                : this.tableDataMenu2[i].printAllow === false
                ? this.tableDataMenu2[i].printAllow
                : null
          });
        }
      }

      
    }
  }
};
