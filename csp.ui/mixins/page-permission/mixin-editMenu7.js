export default {
  data() {
    return {};
  },
  mounted() {},
  methods: {
    editTableDataMenu7(positionId) {
      let dataMenu7 = [
        "ทะเบียนลูกค้า",
        "ทะเบียนผู้จำหน่าย",
        "ทะเบียนสินค้า",
        "ทะเบียนสินค้าเก่า",
        "ทะเบียนวัสดุสิ้นเปลือง/อุปกรณ์สำนักงาน",
        "ทะเบียนสินค้าชุด",
        "บันทึกราคาขาย",
        "รายการตรวจสภาพรถ",
        "กำหนดราคาต่อกลุ่มลูกค้า",
        "ทะเบียนพนักงาน",
        "กำหนดข้อมูลหลัก",
        "กำหนดข้อมูลแคมเปญ",
        "กำหนดข้อมูลโปรโมชั่น",
        "กำหนดข้อมูลข่าวสาร"
      ]

      if (this.modeEdit == true) {
        for (let i = 0; i < dataMenu7.length; i++) {
          let id = i + 30;
          this.dummyMasterPermisson.push({
            PositionId: positionId,
            MenuId: id,
            CreatePermisson:
              this.tableDataMenu7[i].createAllow === true
                ? this.tableDataMenu7[i].createAllow
                : this.tableDataMenu7[i].createAllow === false
                ? this.tableDataMenu7[i].createAllow
                : null,
            EditPermisson:
              this.tableDataMenu7[i].editAllow === true
                ? this.tableDataMenu7[i].editAllow
                : this.tableDataMenu7[i].editAllow === false
                ? this.tableDataMenu7[i].editAllow
                : null,
            ViewPermisson:
              this.tableDataMenu7[i].viewAllow === true
                ? this.tableDataMenu7[i].viewAllow
                : this.tableDataMenu7[i].viewAllow === false
                ? this.tableDataMenu7[i].viewAllow
                : null,
            DeletePermisson:
              this.tableDataMenu7[i].deleteAllow === true
                ? this.tableDataMenu7[i].deleteAllow
                : this.tableDataMenu7[i].deleteAllow === false
                ? this.tableDataMenu7[i].deleteAllow
                : null,
            PrintPermisson:
              this.tableDataMenu7[i].printAllow === true
                ? this.tableDataMenu7[i].printAllow
                : this.tableDataMenu7[i].printAllow === false
                ? this.tableDataMenu7[i].printAllow
                : null
          });
        }
      }
      if (this.modeEdit == false) {
        for (let i = 0; i < dataMenu7.length; i++) {
          let id = i + 30;
          this.dummyMasterPermisson.push({
            MenuId: id,
            CreatePermisson:
              this.tableDataMenu7[i].createAllow === true
                ? this.tableDataMenu7[i].createAllow
                : this.tableDataMenu7[i].createAllow === false
                ? this.tableDataMenu7[i].createAllow
                : null,
            EditPermisson:
              this.tableDataMenu7[i].editAllow === true
                ? this.tableDataMenu7[i].editAllow
                : this.tableDataMenu7[i].editAllow === false
                ? this.tableDataMenu7[i].editAllow
                : null,
            ViewPermisson:
              this.tableDataMenu7[i].viewAllow === true
                ? this.tableDataMenu7[i].viewAllow
                : this.tableDataMenu7[i].viewAllow === false
                ? this.tableDataMenu7[i].viewAllow
                : null,
            DeletePermisson:
              this.tableDataMenu7[i].deleteAllow === true
                ? this.tableDataMenu7[i].deleteAllow
                : this.tableDataMenu7[i].deleteAllow === false
                ? this.tableDataMenu7[i].deleteAllow
                : null,
            PrintPermisson:
              this.tableDataMenu7[i].printAllow === true
                ? this.tableDataMenu7[i].printAllow
                : this.tableDataMenu7[i].printAllow === false
                ? this.tableDataMenu7[i].printAllow
                : null
          });
        }
      }

      
    }
  }
};
