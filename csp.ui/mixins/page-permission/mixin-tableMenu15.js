export default {
  data() {
    return {
      
    }
  },
  mounted() {
    
  },
  methods: {
    mockTableDataMenu15() {
      let data = []
      let rowLabel = [
        'กำหนดการทำงานระบบ',
        'กำหนดข้อมูลบริษัท',
        'ข้อมูลเริ่มต้นระบบ',
        'สอบถามการใช้งานระบบ',
        'ค้นหาการใช้งานเอกสาร'
      ]
      for (let i = 0; i < rowLabel.length; i++) {
        data.push({
          page: rowLabel[i],
          createAllow: false,
          editAllow: false,
          viewAllow: false,
          deleteAllow: null,
          printAllow: null
        })
      }
      
      if (this.modeEdit) {
        data = [];
        for (let i = 0; i < rowLabel.length; i++) {
          data.push({
            page: rowLabel[i],
            createAllow: this.MasterPermisson[i + 68].CreatePermisson,
            editAllow: this.MasterPermisson[i + 68].EditPermisson,
            viewAllow: this.MasterPermisson[i + 68].ViewPermisson,
            deleteAllow: this.MasterPermisson[i + 68].DeletePermisson,
            printAllow: this.MasterPermisson[i + 68].PrintPermisson
          });
        }
      }

      data[2].createAllow = null
      data[2].viewAllow = null
      data[3].createAllow = null
      data[3].editAllow = null
      data[4].createAllow = null
      data[4].editAllow = null
      return data
    },
    mockTableColumnsMenu15() {
      const tableMenu15ColumnList = {
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
            const fav = this.tableDataMenu15[params.index].createAllow
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
                    this.toggleCRUDP(params.index, params.page, 'tableDataMenu15', 'create')
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
            const fav = this.tableDataMenu15[params.index].editAllow
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
                    this.toggleCRUDP(params.index, params.page, 'tableDataMenu15', 'edit')
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
            const fav = this.tableDataMenu15[params.index].viewAllow
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
                    this.toggleCRUDP(params.index, params.page, 'tableDataMenu15', 'view')
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
            const fav = this.tableDataMenu15[params.index].deleteAllow
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
                    this.toggleCRUDP(params.index, params.page, 'tableDataMenu15', 'delete')
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
            const fav = this.tableDataMenu15[params.index].printAllow
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
                    this.toggleCRUDP(params.index, params.page, 'tableDataMenu15', 'print')
                  }
                }
              })
              // h('span', ' ' + params.row.page)
            ])
          }
        }
      }

      let data = [tableMenu15ColumnList.name, tableMenu15ColumnList.create, tableMenu15ColumnList.edit, tableMenu15ColumnList.view, tableMenu15ColumnList.delete, tableMenu15ColumnList.print]

      return data
    }
  }
}