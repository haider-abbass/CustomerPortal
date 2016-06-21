using System.Reflection;
using log4net;

namespace CustomerPortal.Core.DataAccess.Base
{
    internal class BaseFactory
    {
        //Initialize Logger
        protected static readonly ILog Log =
            LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
    }
}
