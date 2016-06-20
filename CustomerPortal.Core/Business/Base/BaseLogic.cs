using System.Reflection;
using log4net;

namespace CustomerPortal.Core.Business.Base
{
    internal class BaseLogic
    {
        //Initialize Logger
        protected static readonly ILog Log =
            LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
    }
}
