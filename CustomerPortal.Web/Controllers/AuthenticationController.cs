using System.Web.Mvc;
using CustomerPortal.Core.DataAccess.Authentication;
using CustomerPortal.Core.Models.Authentication;

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
        
        [HttpGet]
        public ActionResult Login()
        {
            var model = new SignInModel
            {
                UserName = "ps@moment.dk",
                Password = "123456"
            };
            var sessionObject = _iAuth.AuthenticateUser(model);
            return null;
        }
    }
}