export default {
  data() {
    return {
      
    }
  },
  mounted() {
    
  },
  methods: {
    mockTableDataMenu9() {
      let data = []
      let rowLabel = [
        'ลูกค้าสัมพันธ์',
        'แบบประเมินความพึงพอใจลูกค้า',
        'ติดตามผลการให้บริการ'
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
            createAllow: this.MasterPermisson[i + 36].CreatePermisson,
            editAllow: this.MasterPermisson[i + 36].EditPermisson,
            viewAllow: this.MasterPermisson[i + 36].ViewPermisson,
            deleteAllow: this.MasterPermisson[i + 36].DeletePermisson,
            printAllow: this.MasterPermisson[i + 36].PrintPermisson
          });
        }
      }

      data[0].createAllow = null
      data[0].editAllow = null
      data[0].deleteAllow = null
      data[1].printAllow = null
      data[2].printAllow = null
      return data
    },
    mockTableColumnsMenu9() {
      const tableMenu9ColumnList = {
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
            const fav = this.tableDataMenu9[params.index].createAllow
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
                    this.toggleCRUDP(params.index, params.page, 'tableDataMenu9', 'create')
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
            const fav = this.tableDataMenu9[params.index].editAllow
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
                    this.toggleCRUDP(params.index, params.page, 'tableDataMenu9', 'edit')
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
            const fav = this.tableDataMenu9[params.index].viewAllow
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
                    this.toggleCRUDP(params.index, params.page, 'tableDataMenu9', 'view')
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
            const fav = this.tableDataMenu9[params.index].deleteAllow
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
                    this.toggleCRUDP(params.index, params.page, 'tableDataMenu9', 'delete')
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
            const fav = this.tableDataMenu9[params.index].printAllow
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
                    this.toggleCRUDP(params.index, params.page, 'tableDataMenu9', 'print')
                  }
                }
              })
              // h('span', ' ' + params.row.page)
            ])
          }
        }
      }

      let data = [tableMenu9ColumnList.name, tableMenu9ColumnList.create, tableMenu9ColumnList.edit, tableMenu9ColumnList.view, tableMenu9ColumnList.delete, tableMenu9ColumnList.print]

      return data
    }
  }
}