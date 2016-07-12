using System.Web;
using CustomerPortal.Core.DataAccess.Authentication;
using CustomerPortal.Core.Models.Session;
using Ninject;

namespace CustomerPortal.Web.Util
{
    /// <summary>
    /// This class holds the session object
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Applies the class/interface bindings.
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        public static void ApplyBindings(IKernel kernel)
        {
            //Add all the class to interface bindings here
            kernel.Bind<IAuthenticationProvider>().To<AuthenticationProvider>();            
        }
    }    
}
