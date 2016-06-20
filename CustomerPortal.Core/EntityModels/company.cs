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
    
    public partial class company
    {
        public company()
        {
            this.contact_person = new HashSet<contact_person>();
        }
    
        public int company_id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string fax { get; set; }
        public string comment { get; set; }
        public string email { get; set; }
        public string website { get; set; }
        public Nullable<byte> company_status { get; set; }
        public Nullable<System.DateTime> created_date { get; set; }
        public string name_second { get; set; }
        public Nullable<int> kob_no { get; set; }
        public string employees_no { get; set; }
        public string employees_no_code { get; set; }
        public Nullable<int> cvr_no { get; set; }
        public Nullable<int> p_no { get; set; }
        public Nullable<int> jur_se_no { get; set; }
        public Nullable<int> reg_no { get; set; }
        public Nullable<short> founding_year { get; set; }
        public Nullable<byte> company_type_id { get; set; }
        public string mother_company { get; set; }
        public string mother_country { get; set; }
        public string mother_company2 { get; set; }
        public string mother_country2 { get; set; }
        public string customercategory { get; set; }
        public bool salesforce1_locked { get; set; }
        public bool marked_as_primary { get; set; }
        public string reference { get; set; }
        public string career_partner_guid { get; set; }
        public string product_partner_guid { get; set; }
        public Nullable<int> parent_id { get; set; }
        public Nullable<int> cmpnTemplateSubstitutionConfirmation { get; set; }
        public Nullable<int> cmpnTemplateCoverLetterSingle { get; set; }
        public Nullable<int> cmpnTemplateCoverLetterBoth { get; set; }
        public string group_initial { get; set; }
        public Nullable<bool> offentligt { get; set; }
        public string ext_hrp_user { get; set; }
        public string ean { get; set; }
        public Nullable<int> agreement_id { get; set; }
        public Nullable<int> concern_id { get; set; }
        public Nullable<bool> isupdated { get; set; }
        public Nullable<System.DateTime> import_date { get; set; }
    
        public virtual ICollection<contact_person> contact_person { get; set; }
    }
}