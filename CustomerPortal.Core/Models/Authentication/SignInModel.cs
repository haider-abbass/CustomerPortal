namespace CustomerPortal.Core.Models.Authentication
{
    public class SignInModel
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }

    public class AutoLoginModel
    {
        public string Guid { get; set; }
    }
}
