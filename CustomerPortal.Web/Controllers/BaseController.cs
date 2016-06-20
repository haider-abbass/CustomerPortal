using Umbraco.Web.Mvc;
using log4net;
using System.Reflection;

namespace CustomerPortal.Web.Controllers
{
    /// <summary>
    /// Base class for all the controllers.
    /// </summary>
    public class BaseController : SurfaceController
    {
        //Initialize Logger
        public static readonly ILog Log =
            LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
    }
}