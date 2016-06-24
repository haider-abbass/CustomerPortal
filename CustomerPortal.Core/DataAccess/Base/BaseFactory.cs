using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using log4net;

namespace CustomerPortal.Core.DataAccess.Base
{
    public class BaseFactory
    {
        //Initialize Logger
        protected static readonly ILog Log =
            LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        protected void LogError(Exception exception)
        {
            Log.Error(string.Format("Error in Method: {0}, Error Message : {1}, Stack Trace : {2}", exception.TargetSite,exception.Message,exception.StackTrace));
        }

        protected void LogError(Exception exception, dynamic inputModel)
        {
            var inModel = new StringBuilder();

            //foreach (var entry in inputModel)
            //{
            //    inModel.Append(entry.ToString()+" , ");
            //}
            Log.Error(string.Format("Error in Method: {0}, Error Message : {1}, Stack Trace : {2}, Input Parameters : {3}", exception.TargetSite, exception.Message, exception.StackTrace,inModel.ToString()));
        }
    }
}
