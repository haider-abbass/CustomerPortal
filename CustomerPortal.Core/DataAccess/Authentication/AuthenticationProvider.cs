using System;
using System.Linq;
using CustomerPortal.Core.DataAccess.Base;
using CustomerPortal.Core.EntityModels;
using CustomerPortal.Core.Models.Authentication;
using CustomerPortal.Core.Models.Session;
using CustomerPortal.Core.Models.Util;

namespace CustomerPortal.Core.DataAccess.Authentication
{

    public class AuthenticationProvider: BaseFactory,IAuthenticationProvider
    {
        /// <summary>
        /// Authenticates the user.
        /// </summary>
        /// <param name="signInModel">The sign up model.</param>
        /// <returns></returns>
        public User AuthenticateUser(SignInModel signInModel)
        {
            using (var dbContext = new db12054Entities())
            {
                try
                {
                    var dbUser = (from p in dbContext.contact_person
                        join c in dbContext.companies on p.company_id equals c.company_id
                        join cm in dbContext.companies on c.parent_id equals cm.company_id into com
                        from comp in com.DefaultIfEmpty()
                        where p.email == signInModel.UserName && p.password == signInModel.Password
                        orderby p.contact_person_id descending
                        select new
                        {
                            FirstName = p.name ?? "",
                            LastName = p.surname,
                            Guid = p.guid,
                            CompanyId = c.company_id,
                            CompanyName = c.name,
                            HoursManagement = p.portal_hours,
                            Invoicing = p.portal_invoice,
                            ResourcePlanning = p.portal_planning
                        }
                        ).FirstOrDefault();

                    if (dbUser == null) return null;

                    var user = new User
                    {
                        FirstName = dbUser.FirstName,
                        LastName = dbUser.LastName,
                        UserGuid = dbUser.Guid,
                        CompanyId = dbUser.CompanyId,
                        WorksFor = dbUser.CompanyName
                    };
                    //Adding Authorization Roles
                    user.UserAuthorizations.Add(new UserAuthorization
                    {
                        IsAuthorized = dbUser.HoursManagement,
                        Role = Enums.UserRoles.WorkHoursManager
                    });
                    user.UserAuthorizations.Add(new UserAuthorization
                    {
                        IsAuthorized = dbUser.Invoicing,
                        Role = Enums.UserRoles.InvoicingManager
                    });
                    user.UserAuthorizations.Add(new UserAuthorization
                    {
                        IsAuthorized = dbUser.ResourcePlanning,
                        Role = Enums.UserRoles.PlanningManager
                    });
                    return user;
                }
                catch (Exception exception)
                {
                    LogError(exception,signInModel);
                }
            }
            return null;
        }
    }
}
