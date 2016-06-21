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
        // GET: Authentication
        public ActionResult Index()
        {
            return View();           
        }

        [HttpGet]
        public ActionResult Login()
        {
            var model = new SignInModel
            {
                UserName = "ps@moment.dk",
                Password = "123456"
            };
            var sessionObject = new AuthenticationProvider().AuthenticateUser(model);
            return null;
        }
    }
}