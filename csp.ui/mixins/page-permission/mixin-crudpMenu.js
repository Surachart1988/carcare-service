export default {
  data() {
    return {};
  },
  mounted() {},
  methods: {
    toggleCRUDP(index, page, table, column) {
      if (table == "tableDataMenu1") {
        if (column == "create") {
          this.tableDataMenu1[index].createAllow =
            this.tableDataMenu1[index].createAllow === false ? true : false;
        }
        if (column == "edit") {
          this.tableDataMenu1[index].editAllow =
            this.tableDataMenu1[index].editAllow === false ? true : false;
        }
        if (column == "view") {
          this.tableDataMenu1[index].viewAllow =
            this.tableDataMenu1[index].viewAllow === false ? true : false;
        }
        if (column == "delete") {
          this.tableDataMenu1[index].deleteAllow =
            this.tableDataMenu1[index].deleteAllow === false ? true : false;
        }
        if (column == "print") {
          this.tableDataMenu1[index].printAllow =
            this.tableDataMenu1[index].printAllow === false ? true : false;
        }
      }

      if (table == "tableDataMenu2") {
        if (column == "create") {
          this.tableDataMenu2[index].createAllow =
            this.tableDataMenu2[index].createAllow === false ? true : false;
        }
        if (column == "edit") {
          this.tableDataMenu2[index].editAllow =
            this.tableDataMenu2[index].editAllow === false ? true : false;
        }
        if (column == "view") {
          this.tableDataMenu2[index].viewAllow =
            this.tableDataMenu2[index].viewAllow === false ? true : false;
        }
        if (column == "delete") {
          this.tableDataMenu2[index].deleteAllow =
            this.tableDataMenu2[index].deleteAllow === false ? true : false;
        }
        if (column == "print") {
          this.tableDataMenu2[index].printAllow =
            this.tableDataMenu2[index].printAllow === false ? true : false;
        }
      }

      if (table == "tableDataMenu3") {
        if (column == "create") {
          this.tableDataMenu3[index].createAllow =
            this.tableDataMenu3[index].createAllow === false ? true : false;
        }
        if (column == "edit") {
          this.tableDataMenu3[index].editAllow =
            this.tableDataMenu3[index].editAllow === false ? true : false;
        }
        if (column == "view") {
          this.tableDataMenu3[index].viewAllow =
            this.tableDataMenu3[index].viewAllow === false ? true : false;
        }
        if (column == "delete") {
          this.tableDataMenu3[index].deleteAllow =
            this.tableDataMenu3[index].deleteAllow === false ? true : false;
        }
        if (column == "print") {
          this.tableDataMenu3[index].printAllow =
            this.tableDataMenu3[index].printAllow === false ? true : false;
        }
      }

      if (table == "tableDataMenu4") {
        if (column == "create") {
          this.tableDataMenu4[index].createAllow =
            this.tableDataMenu4[index].createAllow === false ? true : false;
        }
        if (column == "edit") {
          this.tableDataMenu4[index].editAllow =
            this.tableDataMenu4[index].editAllow === false ? true : false;
        }
        if (column == "view") {
          this.tableDataMenu4[index].viewAllow =
            this.tableDataMenu4[index].viewAllow === false ? true : false;
        }
        if (column == "delete") {
          this.tableDataMenu4[index].deleteAllow =
            this.tableDataMenu4[index].deleteAllow === false ? true : false;
        }
        if (column == "print") {
          this.tableDataMenu4[index].printAllow =
            this.tableDataMenu4[index].printAllow === false ? true : false;
        }
      }

      if (table == "tableDataMenu5") {
        if (column == "create") {
          this.tableDataMenu5[index].createAllow =
            this.tableDataMenu5[index].createAllow === false ? true : false;
        }
        if (column == "edit") {
          this.tableDataMenu5[index].editAllow =
            this.tableDataMenu5[index].editAllow === false ? true : false;
        }
        if (column == "view") {
          this.tableDataMenu5[index].viewAllow =
            this.tableDataMenu5[index].viewAllow === false ? true : false;
        }
        if (column == "delete") {
          this.tableDataMenu5[index].deleteAllow =
            this.tableDataMenu5[index].deleteAllow === false ? true : false;
        }
        if (column == "print") {
          this.tableDataMenu5[index].printAllow =
            this.tableDataMenu5[index].printAllow === false ? true : false;
        }
      }

      if (table == "tableDataMenu6") {
        if (column == "create") {
          this.tableDataMenu6[index].createAllow =
            this.tableDataMenu6[index].createAllow === false ? true : false;
        }
        if (column == "edit") {
          this.tableDataMenu6[index].editAllow =
            this.tableDataMenu6[index].editAllow === false ? true : false;
        }
        if (column == "view") {
          this.tableDataMenu6[index].viewAllow =
            this.tableDataMenu6[index].viewAllow === false ? true : false;
        }
        if (column == "delete") {
          this.tableDataMenu6[index].deleteAllow =
            this.tableDataMenu6[index].deleteAllow === false ? true : false;
        }
        if (column == "print") {
          this.tableDataMenu6[index].printAllow =
            this.tableDataMenu6[index].printAllow === false ? true : false;
        }
      }

      if (table == "tableDataMenu7") {
        if (column == "create") {
          this.tableDataMenu7[index].createAllow =
            this.tableDataMenu7[index].createAllow === false ? true : false;
        }
        if (column == "edit") {
          this.tableDataMenu7[index].editAllow =
            this.tableDataMenu7[index].editAllow === false ? true : false;
        }
        if (column == "view") {
          this.tableDataMenu7[index].viewAllow =
            this.tableDataMenu7[index].viewAllow === false ? true : false;
        }
        if (column == "delete") {
          this.tableDataMenu7[index].deleteAllow =
            this.tableDataMenu7[index].deleteAllow === false ? true : false;
        }
        if (column == "print") {
          this.tableDataMenu7[index].printAllow =
            this.tableDataMenu7[index].printAllow === false ? true : false;
        }
      }

      if (table == "tableDataMenu8") {
        if (column == "create") {
          this.tableDataMenu8[index].createAllow =
            this.tableDataMenu8[index].createAllow === false ? true : false;
        }
        if (column == "edit") {
          this.tableDataMenu8[index].editAllow =
            this.tableDataMenu8[index].editAllow === false ? true : false;
        }
        if (column == "view") {
          this.tableDataMenu8[index].viewAllow =
            this.tableDataMenu8[index].viewAllow === false ? true : false;
        }
        if (column == "delete") {
          this.tableDataMenu8[index].deleteAllow =
            this.tableDataMenu8[index].deleteAllow === false ? true : false;
        }
        if (column == "print") {
          this.tableDataMenu8[index].printAllow =
            this.tableDataMenu8[index].printAllow === false ? true : false;
        }
      }

      if (table == "tableDataMenu9") {
        if (column == "create") {
          this.tableDataMenu9[index].createAllow =
            this.tableDataMenu9[index].createAllow === false ? true : false;
        }
        if (column == "edit") {
          this.tableDataMenu9[index].editAllow =
            this.tableDataMenu9[index].editAllow === false ? true : false;
        }
        if (column == "view") {
          this.tableDataMenu9[index].viewAllow =
            this.tableDataMenu9[index].viewAllow === false ? true : false;
        }
        if (column == "delete") {
          this.tableDataMenu9[index].deleteAllow =
            this.tableDataMenu9[index].deleteAllow === false ? true : false;
        }
        if (column == "print") {
          this.tableDataMenu9[index].printAllow =
            this.tableDataMenu9[index].printAllow === false ? true : false;
        }
      }

      if (table == "tableDataMenu10") {
        if (column == "create") {
          this.tableDataMenu10[index].createAllow =
            this.tableDataMenu10[index].createAllow === false ? true : false;
        }
        if (column == "edit") {
          this.tableDataMenu10[index].editAllow =
            this.tableDataMenu10[index].editAllow === false ? true : false;
        }
        if (column == "view") {
          this.tableDataMenu10[index].viewAllow =
            this.tableDataMenu10[index].viewAllow === false ? true : false;
        }
        if (column == "delete") {
          this.tableDataMenu10[index].deleteAllow =
            this.tableDataMenu10[index].deleteAllow === false ? true : false;
        }
        if (column == "print") {
          this.tableDataMenu10[index].printAllow =
            this.tableDataMenu10[index].printAllow === false ? true : false;
        }
      }

      if (table == "tableDataMenu11") {
        if (column == "create") {
          this.tableDataMenu11[index].createAllow =
            this.tableDataMenu11[index].createAllow === false ? true : false;
        }
        if (column == "edit") {
          this.tableDataMenu11[index].editAllow =
            this.tableDataMenu11[index].editAllow === false ? true : false;
        }
        if (column == "view") {
          this.tableDataMenu11[index].viewAllow =
            this.tableDataMenu11[index].viewAllow === false ? true : false;
        }
        if (column == "delete") {
          this.tableDataMenu11[index].deleteAllow =
            this.tableDataMenu11[index].deleteAllow === false ? true : false;
        }
        if (column == "print") {
          this.tableDataMenu11[index].printAllow =
            this.tableDataMenu11[index].printAllow === false ? true : false;
        }
      }

      if (table == "tableDataMenu12") {
        if (column == "create") {
          this.tableDataMenu12[index].createAllow =
            this.tableDataMenu12[index].createAllow === false ? true : false;
        }
        if (column == "edit") {
          this.tableDataMenu12[index].editAllow =
            this.tableDataMenu12[index].editAllow === false ? true : false;
        }
        if (column == "view") {
          this.tableDataMenu12[index].viewAllow =
            this.tableDataMenu12[index].viewAllow === false ? true : false;
        }
        if (column == "delete") {
          this.tableDataMenu12[index].deleteAllow =
            this.tableDataMenu12[index].deleteAllow === false ? true : false;
        }
        if (column == "print") {
          this.tableDataMenu12[index].printAllow =
            this.tableDataMenu12[index].printAllow === false ? true : false;
        }
      }

      if (table == "tableDataMenu13") {
        if (column == "create") {
          this.tableDataMenu13[index].createAllow =
            this.tableDataMenu13[index].createAllow === false ? true : false;
        }
        if (column == "edit") {
          this.tableDataMenu13[index].editAllow =
            this.tableDataMenu13[index].editAllow === false ? true : false;
        }
        if (column == "view") {
          this.tableDataMenu13[index].viewAllow =
            this.tableDataMenu13[index].viewAllow === false ? true : false;
        }
        if (column == "delete") {
          this.tableDataMenu13[index].deleteAllow =
            this.tableDataMenu13[index].deleteAllow === false ? true : false;
        }
        if (column == "print") {
          this.tableDataMenu13[index].printAllow =
            this.tableDataMenu13[index].printAllow === false ? true : false;
        }
      }

      if (table == "tableDataMenu14") {
        if (column == "create") {
          this.tableDataMenu14[index].createAllow =
            this.tableDataMenu14[index].createAllow === false ? true : false;
        }
        if (column == "edit") {
          this.tableDataMenu14[index].editAllow =
            this.tableDataMenu14[index].editAllow === false ? true : false;
        }
        if (column == "view") {
          this.tableDataMenu14[index].viewAllow =
            this.tableDataMenu14[index].viewAllow === false ? true : false;
        }
        if (column == "delete") {
          this.tableDataMenu14[index].deleteAllow =
            this.tableDataMenu14[index].deleteAllow === false ? true : false;
        }
        if (column == "print") {
          this.tableDataMenu14[index].printAllow =
            this.tableDataMenu14[index].printAllow === false ? true : false;
        }
      }

      if (table == "tableDataMenu15") {
        if (column == "create") {
          this.tableDataMenu15[index].createAllow =
            this.tableDataMenu15[index].createAllow === false ? true : false;
        }
        if (column == "edit") {
          this.tableDataMenu15[index].editAllow =
            this.tableDataMenu15[index].editAllow === false ? true : false;
        }
        if (column == "view") {
          this.tableDataMenu15[index].viewAllow =
            this.tableDataMenu15[index].viewAllow === false ? true : false;
        }
        if (column == "delete") {
          this.tableDataMenu15[index].deleteAllow =
            this.tableDataMenu15[index].deleteAllow === false ? true : false;
        }
        if (column == "print") {
          this.tableDataMenu15[index].printAllow =
            this.tableDataMenu15[index].printAllow === false ? true : false;
        }
      }
    }
  }
};
