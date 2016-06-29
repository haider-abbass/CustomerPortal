using System.Security.Principal;
using System.Web.Mvc;
using System.Web.Security;
using CustomerPortal.Core.DataAccess.Authentication;
using CustomerPortal.Core.Models.Authentication;
using CustomerPortal.Core.Models.Validation;
using CustomerPortal.Core.Util;
using CustomerPortal.Web.Util;

namespace CustomerPortal.Web.Controllers
{
    /// <summary>
    /// Manages Authentication Requests
    /// </summary>
    public class AuthenticationController : BaseController
    {
        private readonly IAuthenticationProvider _iAuth;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="iAuthentication">The i athentication.</param>
        public AuthenticationController(IAuthenticationProvider iAuthentication)
        {
            _iAuth = iAuthentication;
        }
        
        [HttpPost]                
        public ActionResult LoginUser(SignInModel signInModel)
        {
            //Check if the session already exists
            if (HttpContext.User.Identity.IsAuthenticated) return CurrentUmbracoPage();
            
            //Validate input model
            if (!ValidationFactory.ValidateLoginInput(signInModel).IsValid)return null;
            
            //Authenticate user from database
            var user = _iAuth.AuthenticateUser(signInModel);

            if (user != null)
            {
                //Set Authentication Cookie
                FormsAuthentication.SetAuthCookie(user.UserGuid, signInModel.RememberMe);
                var cookie = System.Web.HttpContext.Current.Response.Cookies[FormsAuthentication.FormsCookieName];
                if (cookie != null)
                {
                    var ticket = FormsAuthentication.Decrypt(cookie.Value);
                    if (ticket != null && !ticket.Expired)
                    {
                        var roles = (ticket.UserData ?? "").Split(',');
                        System.Web.HttpContext.Current.User = new GenericPrincipal(new FormsIdentity(ticket), roles);
                    }
                }
                //Set current user data to the Session
                SessionUtil.User = user;
            }

            //Log Entry
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult LogoutUser()
        {
            var redirectPage = 1068;            
            if (HttpContext.Session != null)
            {
                SessionUtil.KillSession();
            }
            FormsAuthentication.SignOut();
            Roles.DeleteCookie();
            return RedirectToUmbracoPage(redirectPage);
        }
    }
}