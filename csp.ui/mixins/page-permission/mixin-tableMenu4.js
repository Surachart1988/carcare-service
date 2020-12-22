export default {
  data() {
    return {
      
    }
  },
  mounted() {
    
  },
  methods: {
    mockTableDataMenu4() {
      let data = []
      let rowLabel = [
        'ใบรับเข้าสินค้า',
        'ใบส่งคืนสินค้า',
        'ใบปรับลดปรับเพิ่ม',
        'ใบรับเคลมสินค้า',
        'ใบเช็คสต๊อกสินค้า'
      ]
      for (let i = 0; i < rowLabel.length; i++) {
        data.push({
          page: rowLabel[i],
          createAllow: false,
          editAllow: false,
          viewAllow: false,
          deleteAllow: false,
          printAllow: false
        })
      }

      if (this.modeEdit) {
        data = [];
        for (let i = 0; i < rowLabel.length; i++) {
          data.push({
            page: rowLabel[i],
            createAllow: this.MasterPermisson[i + 13].CreatePermisson,
            editAllow: this.MasterPermisson[i + 13].EditPermisson,
            viewAllow: this.MasterPermisson[i + 13].ViewPermisson,
            deleteAllow: this.MasterPermisson[i + 13].DeletePermisson,
            printAllow: this.MasterPermisson[i + 13].PrintPermisson
          });
        }
      }

      return data
    },
    mockTableColumnsMenu4() {
      const tableMenu4ColumnList = {
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
            const fav = this.tableDataMenu4[params.index].createAllow
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
                    this.toggleCRUDP(params.index, params.page, 'tableDataMenu4', 'create')
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
            const fav = this.tableDataMenu4[params.index].editAllow
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
                    this.toggleCRUDP(params.index, params.page, 'tableDataMenu4', 'edit')
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
            const fav = this.tableDataMenu4[params.index].viewAllow
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
                    this.toggleCRUDP(params.index, params.page, 'tableDataMenu4', 'view')
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
            const fav = this.tableDataMenu4[params.index].deleteAllow
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
                    this.toggleCRUDP(params.index, params.page, 'tableDataMenu4', 'delete')
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
            const fav = this.tableDataMenu4[params.index].printAllow
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
                    this.toggleCRUDP(params.index, params.page, 'tableDataMenu4', 'print')
                  }
                }
              })
              // h('span', ' ' + params.row.page)
            ])
          }
        }
      }

      let data = [tableMenu4ColumnList.name, tableMenu4ColumnList.create, tableMenu4ColumnList.edit, tableMenu4ColumnList.view, tableMenu4ColumnList.delete, tableMenu4ColumnList.print]

      return data
    }
  }
}