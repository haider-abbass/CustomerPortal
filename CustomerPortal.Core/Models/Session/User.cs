using System.Collections.Generic;
using CustomerPortal.Core.Models.Util;

namespace CustomerPortal.Core.Models.Session
{
    /// <summary>
    /// The Session Template Class
    /// </summary>
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserGuid { get; set; }
        public int CompanyId { get; set; }
        public string WorksFor { get; set; }
        public List<UserAuthorization> UserAuthorizations { get; set; } 
        public List<UserJobs> JobNumbers { get; set; }
        public Enums.Department UserDepartment { get; set; }

        public User()
        {
            UserAuthorizations = new List<UserAuthorization>();
        }
    }

    public class UserJobs
    {
        public int JobId { get; set; }
        public bool IsPro { get; set; }
    }

    public class UserAuthorization
    {
        public bool IsAuthorized { get; set; }
        public Enums.UserRoles Role { get; set; }
    }

}
