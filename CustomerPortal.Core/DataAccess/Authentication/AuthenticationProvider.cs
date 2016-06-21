using CustomerPortal.Core.DataAccess.Base;
using CustomerPortal.Core.Models.Authentication;
using CustomerPortal.Core.Models.Session;

namespace CustomerPortal.Core.DataAccess.Authentication
{

    internal class AuthenticationProvider: BaseFactory
    {
        /// <summary>
        /// Authenticates the user.
        /// </summary>
        /// <param name="signUpModel">The sign up model.</param>
        /// <returns></returns>
        internal User AuthenticateUser(SignUpModel signUpModel)
        {

            return new User();
                        
        }
    }
}
