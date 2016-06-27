using CustomerPortal.Core.Models.Authentication;
using CustomerPortal.Core.Models.Validation;
using CustomerPortal.Core.Resources;

namespace CustomerPortal.Core.Util
{
    /// <summary>
    /// Validations Rule Engine
    /// </summary>
    public static class ValidationFactory
    {
        /// <summary>
        /// Validates the login input model.
        /// </summary>
        /// <param name="signInModel">The sign in model.</param>
        /// <returns></returns>
        public static Validity ValidateLoginInput(SignInModel signInModel)
        {
            //Check Null
            if (string.IsNullOrEmpty(signInModel.UserName) || string.IsNullOrEmpty(signInModel.Password))
            {
                return new Validity{Message = Messages.InvalidUserNameOrPassword,IsValid = false};    
            }
            //Password Length
            if (signInModel.Password.Length<6)
            {
                return new Validity { Message = Messages.InvalidPasswordLength, IsValid = false };    
            }
            return new Validity { IsValid = true }; 
        }
    }
}
