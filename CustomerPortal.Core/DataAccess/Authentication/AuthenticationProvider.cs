using System;
using System.Collections.Generic;
using System.Linq;
using CustomerPortal.Core.DataAccess.Base;
using CustomerPortal.Core.EntityModels;
using CustomerPortal.Core.Models.Authentication;
using CustomerPortal.Core.Models.Session;
using CustomerPortal.Core.Util;

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

                    //2) Get the Job Numbers
                                        
                    var jobsData = (from jobs in dbContext.jobs
                        from cpersons in
                            dbContext.contact_person.Where(x => jobs.contact_person_id == x.contact_person_id
                                                                ||
                                                                jobs.treasury_contact_person_id == x.contact_person_id ||
                                                                jobs.cc_contact_person_id == x.contact_person_id
                                )
                        from jtcp in
                            dbContext.JobToContactPersons.Where(
                                y => jobs.file_number == y.jnr && cpersons.contact_person_id == y.contact_person_id)
                                .DefaultIfEmpty()
                        where cpersons.email == signInModel.UserName
                        select new
                        {
                            JobNumber = jobs.file_number,
                            IsPro = jobs.department == 3,
                            JobStatus = jobs.job_status
                        });

                    var minDate = DateTime.Now.AddYears(-1);
                    //3) Rules Set
                    var list1 = jobsData.Where(x => x.JobStatus < 4).Select(x=> new {x.JobNumber, x.IsPro });
                    var list2 = (from jData in jobsData
                                     join vRHours in dbContext.vReportedHours on jData.JobNumber equals vRHours.jnr
                                 where vRHours.worked_date > minDate
                                     select new {jData.JobNumber, jData.IsPro});
                    var list3 = (from jData in jobsData
                                 join inv in dbContext.invoices on jData.JobNumber equals inv.file_number
                                 where inv.student_worked_month > minDate
                                 select new { jData.JobNumber, jData.IsPro });
                    var list4 = (from jData in jobsData
                                 join vts in dbContext.vTasks on jData.JobNumber equals vts.jnr
                                 where vts.start_time > minDate
                                 select new { jData.JobNumber, jData.IsPro });

                    var jobsList = list1.Union(list2).Union(list3).Union(list4).ToList();

                    foreach (var job in jobsList)
                    {
                        user.JobNumbers.Add(new UserJobs{JobId = job.JobNumber,IsPro = job.IsPro});
                    }
                                        
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
