namespace CustomerPortal.Core.Util
{
    public class Enums
    {
        public enum UserRole
        {
            WorkHoursManager = 1,
            InvoicingManager = 2,
            PlanningManager = 3
        }

        public enum AuthorizationLevel
        {
            Readonly = 1,
            Create = 2,
            Update = 3,
            Delete = 4,                
            Executive = 5 //All Operations
        }

        //public enum Department
        //{
        //    Moment = 0,
        //    Students = 1,
        //    Staff = 2,
        //    Pro = 3
        //}
    }
}