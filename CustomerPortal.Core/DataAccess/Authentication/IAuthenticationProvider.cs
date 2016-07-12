using CustomerPortal.Core.Models.Authentication;
using CustomerPortal.Core.Models.Session;

namespace CustomerPortal.Core.DataAccess.Authentication
{
    public interface IAuthenticationProvider
    {
        User AuthenticateUser(SignInModel signInModel);
    }
}
