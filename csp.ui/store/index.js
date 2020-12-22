const cookieparser = process.server ? require('cookieparser') : undefined

export const state = () => {
  return {
    auth: null,
    jwtDecode: null,
    menuID: null
  }
}
export const mutations = {
  setAuth (state, data) {
    state.auth = data;
  },
  setJwtDecode (state, data) {
    state.jwtDecode = data;
  },
  setMenuID (state, data) {
    state.menuID = data;
  }
}
// export const actions = {
//   nuxtServerInit ({ commit }, { req }) {
//     let auth = null
    
//     if (req.headers.cookie) {
//       const parsed = cookieparser.parse(req.headers.cookie)
//       try {
//         auth = JSON.parse(parsed.auth)
//       } catch (err) {
//       }
//     }
//     commit('setAuth', auth)
//   }
// }
export const actions = {
  setAuth: (state , data) => {
    state.commit("auth", data);
  },
  setJwtDecode (state, data) {
    state.commit("jwtDecode", data);
  },
  setMenuID (state, data) {
    state.commit("menuID", data);
  }
};