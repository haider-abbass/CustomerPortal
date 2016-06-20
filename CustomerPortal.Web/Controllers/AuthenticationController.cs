using System.Web.Mvc;

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
    }
}