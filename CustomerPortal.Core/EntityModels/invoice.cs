//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CustomerPortal.Core.EntityModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class invoice
    {
        public int invoice_id { get; set; }
        public Nullable<int> file_number { get; set; }
        public string job { get; set; }
        public string virksomhed { get; set; }
        public Nullable<decimal> hours { get; set; }
        public Nullable<decimal> salary { get; set; }
        public Nullable<decimal> amount { get; set; }
        public string diverse { get; set; }
        public string our_sales_person { get; set; }
        public string job_category { get; set; }
        public string hrm { get; set; }
        public string hrm2 { get; set; }
        public Nullable<int> hrm_count { get; set; }
        public Nullable<System.DateTime> invoice_month { get; set; }
        public Nullable<System.DateTime> student_worked_month { get; set; }
        public string remarks { get; set; }
        public Nullable<System.DateTime> created { get; set; }
    }
}
