export default {
  data() {
    return {};
  },
  mounted() {},
  methods: {
    mockTableDataMenu2() {
      let data = [];
      let rowLabel = [
        "ใบสั่งซ่อม",
        "ใบเสร็จรับเงิน/ใบกำกับภาษี(อย่างย่อ)",
        "ใบส่งสินค้าชั่วคราว",
        "ใบกำกับภาษีเต็มรูป",
        "ใบลดหนี้/รับคืนสินค้า",
        "ใบเสนอราคา",
        "ใบรับมัดจำ",
        "ใบตรวจสภาพรถยนต์"
      ];

      for (let i = 0; i < rowLabel.length; i++) {
        data.push({
          page: rowLabel[i],
          createAllow: false,
          editAllow: false,
          viewAllow: false,
          deleteAllow: false,
          printAllow: false
        });
      }

      if (this.modeEdit) {
        data = [];
        for (let i = 0; i < rowLabel.length; i++) {
          data.push({
            page: rowLabel[i],
            createAllow: this.MasterPermisson[i + 4].CreatePermisson,
            editAllow: this.MasterPermisson[i + 4].EditPermisson,
            viewAllow: this.MasterPermisson[i + 4].ViewPermisson,
            deleteAllow: this.MasterPermisson[i + 4].DeletePermisson,
            printAllow: this.MasterPermisson[i + 4].PrintPermisson
          });
        }
      }

      data[3].editAllow = null;
      data[4].editAllow = null;
      data[5].editAllow = null;

      return data;
    },
    mockTableColumnsMenu2() {
      const tableMenu2ColumnList = {
        name: {
          title: this.permissionCol.title,
          key: "page",
          render: (h, params) => {
            return h("div", [h("span", " " + params.row.page)]);
          }
        },
        create: {
          title: this.permissionCol.create,
          //key: 'page',
          align: "center",
          width: 120,
          render: (h, params) => {
            const fav = this.tableDataMenu2[params.index].createAllow;
            const style =
              fav === false
                ? {
                    cursor: "pointer",
                    color: "#f5f5f5",
                    backgroundColor: "#f5f5f5",
                    borderRadius: "30px",
                    fontSize: "28px",
                    border: "3px solid #E1E1E1"
                  }
                : fav === true
                ? {
                    cursor: "pointer",
                    color: "#00d317",
                    fontSize: "36px",
                    borderRadius: "30px",
                    border: "2px solid #00d317"
                  }
                : {
                    display: "none"
                  };

            return h("div", [
              h("Icon", {
                style: style,
                props: {
                  type:
                    fav === false ? "md-close-circle" : "md-checkmark-circle"
                },
                nativeOn: {
                  click: () => {
                    this.toggleCRUDP(
                      params.index,
                      params.page,
                      "tableDataMenu2",
                      "create"
                    );
                  }
                }
              })
              // h('span', ' ' + params.row.page)
            ]);
          }
        },
        edit: {
          title: this.permissionCol.edit,
          //key: 'page',
          align: "center",
          width: 120,
          render: (h, params) => {
            const fav = this.tableDataMenu2[params.index].editAllow;
            const style =
              fav === false
                ? {
                    cursor: "pointer",
                    color: "#f5f5f5",
                    backgroundColor: "#f5f5f5",
                    borderRadius: "30px",
                    fontSize: "28px",
                    border: "3px solid #E1E1E1"
                  }
                : fav === true
                ? {
                    cursor: "pointer",
                    color: "#00d317",
                    fontSize: "36px",
                    borderRadius: "30px",
                    border: "2px solid #00d317"
                  }
                : {
                    display: "none"
                  };

            return h("div", [
              h("Icon", {
                style: style,
                props: {
                  type:
                    fav === false ? "md-close-circle" : "md-checkmark-circle"
                },
                nativeOn: {
                  click: () => {
                    this.toggleCRUDP(
                      params.index,
                      params.page,
                      "tableDataMenu2",
                      "edit"
                    );
                  }
                }
              })
              // h('span', ' ' + params.row.page)
            ]);
          }
        },
        view: {
          title: this.permissionCol.view,
          //key: 'page',
          align: "center",
          width: 120,
          render: (h, params) => {
            const fav = this.tableDataMenu2[params.index].viewAllow;
            const style =
              fav === false
                ? {
                    cursor: "pointer",
                    color: "#f5f5f5",
                    backgroundColor: "#f5f5f5",
                    borderRadius: "30px",
                    fontSize: "28px",
                    border: "3px solid #E1E1E1"
                  }
                : fav === true
                ? {
                    cursor: "pointer",
                    color: "#00d317",
                    fontSize: "36px",
                    borderRadius: "30px",
                    border: "2px solid #00d317"
                  }
                : {
                    display: "none"
                  };

            return h("div", [
              h("Icon", {
                style: style,
                props: {
                  type:
                    fav === false ? "md-close-circle" : "md-checkmark-circle"
                },
                nativeOn: {
                  click: () => {
                    this.toggleCRUDP(
                      params.index,
                      params.page,
                      "tableDataMenu2",
                      "view"
                    );
                  }
                }
              })
              // h('span', ' ' + params.row.page)
            ]);
          }
        },
        delete: {
          title: this.permissionCol.delete,
          //key: 'page',
          align: "center",
          width: 120,
          render: (h, params) => {
            const fav = this.tableDataMenu2[params.index].deleteAllow;
            const style =
              fav === false
                ? {
                    cursor: "pointer",
                    color: "#f5f5f5",
                    backgroundColor: "#f5f5f5",
                    borderRadius: "30px",
                    fontSize: "28px",
                    border: "3px solid #E1E1E1"
                  }
                : fav === true
                ? {
                    cursor: "pointer",
                    color: "#00d317",
                    fontSize: "36px",
                    borderRadius: "30px",
                    border: "2px solid #00d317"
                  }
                : {
                    display: "none"
                  };

            return h("div", [
              h("Icon", {
                style: style,
                props: {
                  type:
                    fav === false ? "md-close-circle" : "md-checkmark-circle"
                },
                nativeOn: {
                  click: () => {
                    this.toggleCRUDP(
                      params.index,
                      params.page,
                      "tableDataMenu2",
                      "delete"
                    );
                  }
                }
              })
              // h('span', ' ' + params.row.page)
            ]);
          }
        },
        print: {
          title: this.permissionCol.print,
          //key: 'page',
          align: "center",
          width: 120,
          render: (h, params) => {
            const fav = this.tableDataMenu2[params.index].printAllow;
            const style =
              fav === false
                ? {
                    cursor: "pointer",
                    color: "#f5f5f5",
                    backgroundColor: "#f5f5f5",
                    borderRadius: "30px",
                    fontSize: "28px",
                    border: "3px solid #E1E1E1"
                  }
                : fav === true
                ? {
                    cursor: "pointer",
                    color: "#00d317",
                    fontSize: "36px",
                    borderRadius: "30px",
                    border: "2px solid #00d317"
                  }
                : {
                    display: "none"
                  };

            return h("div", [
              h("Icon", {
                style: style,
                props: {
                  type:
                    fav === false ? "md-close-circle" : "md-checkmark-circle"
                },
                nativeOn: {
                  click: () => {
                    this.toggleCRUDP(
                      params.index,
                      params.page,
                      "tableDataMenu2",
                      "print"
                    );
                  }
                }
              })
              // h('span', ' ' + params.row.page)
            ]);
          }
        }
      };

      let data = [
        tableMenu2ColumnList.name,
        tableMenu2ColumnList.create,
        tableMenu2ColumnList.edit,
        tableMenu2ColumnList.view,
        tableMenu2ColumnList.delete,
        tableMenu2ColumnList.print
      ];

      return data;
    }
  }
};
