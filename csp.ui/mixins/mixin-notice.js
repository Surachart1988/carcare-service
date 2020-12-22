export default {
  data() {
    return {};
  },
  methods: {
    noticeInfo(text) {
      this.$Notice.info({
        title: text
      });
    },
    noticeSuccess(text) {
      this.$Notice.success({
        title: text
      });
    },
    noticeWarning(text) {
      this.$Notice.warning({
        title: text
      });
    },
    noticeError(text) {
      this.$Notice.error({
        title: text
      });
    }
  }
};
