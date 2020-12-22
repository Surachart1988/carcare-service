export default {
  data() {
    return {
      
    }
  },
  mounted() {
    
  },
  methods: {
    mockTableDataMenu7() {
      let data = []
      let rowLabel = [
        'ทะเบียนลูกค้า',
        'ทะเบียนผู้จำหน่าย',
        'ทะเบียนสินค้า',
        'ทะเบียนสินค้าเก่า',
        'ทะเบียนวัสดุสิ้นเปลือง/อุปกรณ์สำนักงาน',
        'ทะเบียนสินค้าชุด',
        'บันทึกราคาขาย',
        'รายการตรวจสภาพรถ',
        'กำหนดราคาต่อกลุ่มลูกค้า',
        'ทะเบียนพนักงาน',
        'กำหนดข้อมูลหลัก',
        'กำหนดข้อมูลแคมเปญ',
        'กำหนดข้อมูลโปรโมชั่น',
        'กำหนดข้อมูลข่าวสาร'
      ]
      for (let i = 0; i < rowLabel.length; i++) {
        data.push({
          page: rowLabel[i],
          createAllow: false,
          editAllow: false,
          viewAllow: false,
          deleteAllow: false,
          printAllow: null
        })
      }

      data[13].printAllow = false

      if (this.modeEdit) {
        data = [];
        for (let i = 0; i < rowLabel.length; i++) {
          data.push({
            page: rowLabel[i],
            createAllow: this.MasterPermisson[i + 21].CreatePermisson,
            editAllow: this.MasterPermisson[i + 21].EditPermisson,
            viewAllow: this.MasterPermisson[i + 21].ViewPermisson,
            deleteAllow: this.MasterPermisson[i + 21].DeletePermisson,
            printAllow: this.MasterPermisson[i + 21].PrintPermisson
          });

          data[i].printAllow = null
        }

        data[13].printAllow = this.MasterPermisson[13 + 21].PrintPermisson
      }

      return data
    },
    mockTableColumnsMenu7() {
      const tableMenu7ColumnList = {
        name: {
          title: this.permissionCol.title,
          key: 'page',
          render: (h, params) => {
            return h('div', [h('span', ' ' + params.row.page)])
          }
        },
        create: {
          title: this.permissionCol.create,
          //key: 'page',
          align: 'center',
          width: 120,
          render: (h, params) => {
            const fav = this.tableDataMenu7[params.index].createAllow
            const style =
              fav === false
                ? {
                    cursor: 'pointer',
                    color: '#f5f5f5',
                    backgroundColor: '#f5f5f5',
                    borderRadius: '30px',
                    fontSize: '28px',
                    border: '3px solid #E1E1E1'
                  }
                : fav === true
                ? {
                    cursor: 'pointer',
                    color: '#00d317',
                    fontSize: '36px',
                    borderRadius: '30px',
                    border: '2px solid #00d317'
                  }
                : {
                    display: 'none'
                  }

            return h('div', [
              h('Icon', {
                style: style,
                props: {
                  type: fav === false ? 'md-close-circle' : 'md-checkmark-circle'
                },
                nativeOn: {
                  click: () => {
                    this.toggleCRUDP(params.index, params.page, 'tableDataMenu7', 'create')
                  }
                }
              })
              // h('span', ' ' + params.row.page)
            ])
          }
        },
        edit: {
          title: this.permissionCol.edit,
          //key: 'page',
          align: 'center',
          width: 120,
          render: (h, params) => {
            const fav = this.tableDataMenu7[params.index].editAllow
            const style =
              fav === false
                ? {
                    cursor: 'pointer',
                    color: '#f5f5f5',
                    backgroundColor: '#f5f5f5',
                    borderRadius: '30px',
                    fontSize: '28px',
                    border: '3px solid #E1E1E1'
                  }
                : fav === true
                ? {
                    cursor: 'pointer',
                    color: '#00d317',
                    fontSize: '36px',
                    borderRadius: '30px',
                    border: '2px solid #00d317'
                  }
                : {
                    display: 'none'
                  }

            return h('div', [
              h('Icon', {
                style: style,
                props: {
                  type: fav === false ? 'md-close-circle' : 'md-checkmark-circle'
                },
                nativeOn: {
                  click: () => {
                    this.toggleCRUDP(params.index, params.page, 'tableDataMenu7', 'edit')
                  }
                }
              })
              // h('span', ' ' + params.row.page)
            ])
          }
        },
        view: {
          title: this.permissionCol.view,
          //key: 'page',
          align: 'center',
          width: 120,
          render: (h, params) => {
            const fav = this.tableDataMenu7[params.index].viewAllow
            const style =
              fav === false
                ? {
                    cursor: 'pointer',
                    color: '#f5f5f5',
                    backgroundColor: '#f5f5f5',
                    borderRadius: '30px',
                    fontSize: '28px',
                    border: '3px solid #E1E1E1'
                  }
                : fav === true
                ? {
                    cursor: 'pointer',
                    color: '#00d317',
                    fontSize: '36px',
                    borderRadius: '30px',
                    border: '2px solid #00d317'
                  }
                : {
                    display: 'none'
                  }

            return h('div', [
              h('Icon', {
                style: style,
                props: {
                  type: fav === false ? 'md-close-circle' : 'md-checkmark-circle'
                },
                nativeOn: {
                  click: () => {
                    this.toggleCRUDP(params.index, params.page, 'tableDataMenu7', 'view')
                  }
                }
              })
              // h('span', ' ' + params.row.page)
            ])
          }
        },
        delete: {
          title: this.permissionCol.delete,
          //key: 'page',
          align: 'center',
          width: 120,
          render: (h, params) => {
            const fav = this.tableDataMenu7[params.index].deleteAllow
            const style =
              fav === false
                ? {
                    cursor: 'pointer',
                    color: '#f5f5f5',
                    backgroundColor: '#f5f5f5',
                    borderRadius: '30px',
                    fontSize: '28px',
                    border: '3px solid #E1E1E1'
                  }
                : fav === true
                ? {
                    cursor: 'pointer',
                    color: '#00d317',
                    fontSize: '36px',
                    borderRadius: '30px',
                    border: '2px solid #00d317'
                  }
                : {
                    display: 'none'
                  }

            return h('div', [
              h('Icon', {
                style: style,
                props: {
                  type: fav === false ? 'md-close-circle' : 'md-checkmark-circle'
                },
                nativeOn: {
                  click: () => {
                    this.toggleCRUDP(params.index, params.page, 'tableDataMenu7', 'delete')
                  }
                }
              })
              // h('span', ' ' + params.row.page)
            ])
          }
        },
        print: {
          title: this.permissionCol.print,
          //key: 'page',
          align: 'center',
          width: 120,
          render: (h, params) => {
            const fav = this.tableDataMenu7[params.index].printAllow
            const style =
              fav === false
                ? {
                    cursor: 'pointer',
                    color: '#f5f5f5',
                    backgroundColor: '#f5f5f5',
                    borderRadius: '30px',
                    fontSize: '28px',
                    border: '3px solid #E1E1E1'
                  }
                : fav === true
                ? {
                    cursor: 'pointer',
                    color: '#00d317',
                    fontSize: '36px',
                    borderRadius: '30px',
                    border: '2px solid #00d317'
                  }
                : {
                    display: 'none'
                  }

            return h('div', [
              h('Icon', {
                style: style,
                props: {
                  type: fav === false ? 'md-close-circle' : 'md-checkmark-circle'
                },
                nativeOn: {
                  click: () => {
                    this.toggleCRUDP(params.index, params.page, 'tableDataMenu7', 'print')
                  }
                }
              })
              // h('span', ' ' + params.row.page)
            ])
          }
        }
      }

      let data = [tableMenu7ColumnList.name, tableMenu7ColumnList.create, tableMenu7ColumnList.edit, tableMenu7ColumnList.view, tableMenu7ColumnList.delete, tableMenu7ColumnList.print]

      return data
    }
  }
}