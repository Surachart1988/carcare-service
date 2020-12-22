export default {
  data() {
    return {};
  },
  mounted() {},
  methods: {
    editTableDataMenu14(positionId) {
      let dataMenu14 = [
        "รายงานการขาย",
        "รายงานการซื้อ",
        "รายงานคลังสินค้า",
        "รายงานข้อมูลหลัก",
        "รายงานเจ้าหนี้",
        "รายงานลูกหนี้",
        "รายงานภาษี",
        "รายงานการรับ-จ่ายเงิน",
        "รายงานลูกค้าสัมพันธ์",
        "รายงานบันทึกการใช้งานระบบ"
      ]

      if (this.modeEdit == true) {
        for (let i = 0; i < dataMenu14.length; i++) {
          let id = i + 74;
          this.dummyMasterPermisson.push({
            PositionId: positionId,
            MenuId: id,
            CreatePermisson:
              this.tableDataMenu14[i].createAllow === true
                ? this.tableDataMenu14[i].createAllow
                : this.tableDataMenu14[i].createAllow === false
                ? this.tableDataMenu14[i].createAllow
                : null,
            EditPermisson:
              this.tableDataMenu14[i].editAllow === true
                ? this.tableDataMenu14[i].editAllow
                : this.tableDataMenu14[i].editAllow === false
                ? this.tableDataMenu14[i].editAllow
                : null,
            ViewPermisson:
              this.tableDataMenu14[i].viewAllow === true
                ? this.tableDataMenu14[i].viewAllow
                : this.tableDataMenu14[i].viewAllow === false
                ? this.tableDataMenu14[i].viewAllow
                : null,
            DeletePermisson:
              this.tableDataMenu14[i].deleteAllow === true
                ? this.tableDataMenu14[i].deleteAllow
                : this.tableDataMenu14[i].deleteAllow === false
                ? this.tableDataMenu14[i].deleteAllow
                : null,
            PrintPermisson:
              this.tableDataMenu14[i].printAllow === true
                ? this.tableDataMenu14[i].printAllow
                : this.tableDataMenu14[i].printAllow === false
                ? this.tableDataMenu14[i].printAllow
                : null
          });
        }
      }
      if (this.modeEdit == false) {
        for (let i = 0; i < dataMenu14.length; i++) {
          let id = i + 74;
          this.dummyMasterPermisson.push({
            MenuId: id,
            CreatePermisson:
              this.tableDataMenu14[i].createAllow === true
                ? this.tableDataMenu14[i].createAllow
                : this.tableDataMenu14[i].createAllow === false
                ? this.tableDataMenu14[i].createAllow
                : null,
            EditPermisson:
              this.tableDataMenu14[i].editAllow === true
                ? this.tableDataMenu14[i].editAllow
                : this.tableDataMenu14[i].editAllow === false
                ? this.tableDataMenu14[i].editAllow
                : null,
            ViewPermisson:
              this.tableDataMenu14[i].viewAllow === true
                ? this.tableDataMenu14[i].viewAllow
                : this.tableDataMenu14[i].viewAllow === false
                ? this.tableDataMenu14[i].viewAllow
                : null,
            DeletePermisson:
              this.tableDataMenu14[i].deleteAllow === true
                ? this.tableDataMenu14[i].deleteAllow
                : this.tableDataMenu14[i].deleteAllow === false
                ? this.tableDataMenu14[i].deleteAllow
                : null,
            PrintPermisson:
              this.tableDataMenu14[i].printAllow === true
                ? this.tableDataMenu14[i].printAllow
                : this.tableDataMenu14[i].printAllow === false
                ? this.tableDataMenu14[i].printAllow
                : null
          });
        }
      }

      
    }
  }
};
