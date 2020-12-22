import Cookies from 'js-cookie'

export default function (context) {

  const {
		// app,
		store,
		// route,
		// params,
		// query,
		// env,
		isDev,
		// isHMR,
		redirect,
		// error
  } = context
  
  let valueCookie = Cookies.get('cspAuth')

  // If the user is not authenticated

    if (valueCookie == 'logged-in') {
      return redirect('/')
    }

}