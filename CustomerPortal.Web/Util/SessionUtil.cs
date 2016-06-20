using System.Web;
using CustomerPortal.Core.Models.Session;

namespace CustomerPortal.Web.Util
{
    /// <summary>
    /// This class holds the session object
    /// </summary>
    public class SessionUtil
    {
        public static User User
        {
            get
            {
                var loggedInUser = HttpContext.Current.Session["User"];
                if (loggedInUser == null)
                {
                    return null;
                }

                return (User)loggedInUser;
            }
            set
            {
                HttpContext.Current.Session["User"] = value;
            }
        }

        /// <summary>
        /// Kills the session for a specific user.
        /// </summary>
        public static void KillSession()
        {
            HttpContext.Current.Session.RemoveAll();
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();
        }
    }    
}
