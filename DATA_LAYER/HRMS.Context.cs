﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DATA_LAYER
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HRMSEntities : DbContext
    {
        public HRMSEntities()
            : base("name=HRMSEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TBL_COUNTRY> TBL_COUNTRY { get; set; }
        public virtual DbSet<TBL_DIVISION> TBL_DIVISION { get; set; }
        public virtual DbSet<TBL_EMP_ASSETDETAILS> TBL_EMP_ASSETDETAILS { get; set; }
        public virtual DbSet<TBL_EMP_BASICINFO> TBL_EMP_BASICINFO { get; set; }
        public virtual DbSet<TBL_EMP_BASICINFO_HISTORY> TBL_EMP_BASICINFO_HISTORY { get; set; }
        public virtual DbSet<TBL_EMP_COM_DETAILS_HISTORY> TBL_EMP_COM_DETAILS_HISTORY { get; set; }
        public virtual DbSet<TBL_EMP_COMMUNICATION_DETAILS> TBL_EMP_COMMUNICATION_DETAILS { get; set; }
        public virtual DbSet<TBL_EMP_DOCUMENT_DETAILS> TBL_EMP_DOCUMENT_DETAILS { get; set; }
        public virtual DbSet<TBL_EMP_EMPLOYMENT_RECORD> TBL_EMP_EMPLOYMENT_RECORD { get; set; }
        public virtual DbSet<TBL_EMP_EXTRACULMACTIVITY> TBL_EMP_EXTRACULMACTIVITY { get; set; }
        public virtual DbSet<TBL_EMP_LEAVE_DETAILS> TBL_EMP_LEAVE_DETAILS { get; set; }
        public virtual DbSet<TBL_EMP_PIPDETAILS> TBL_EMP_PIPDETAILS { get; set; }
        public virtual DbSet<TBL_EMP_QUALIFICATION_DETAILS> TBL_EMP_QUALIFICATION_DETAILS { get; set; }
        public virtual DbSet<TBL_EMP_RELATIONSHIP_DETAILS> TBL_EMP_RELATIONSHIP_DETAILS { get; set; }
        public virtual DbSet<TBL_EMP_SALARYACCOUNTDETAILS> TBL_EMP_SALARYACCOUNTDETAILS { get; set; }
        public virtual DbSet<TBL_EMP_TRAINING_DETAILS> TBL_EMP_TRAINING_DETAILS { get; set; }
        public virtual DbSet<TBL_EMP_TRANSFER_DETAILS> TBL_EMP_TRANSFER_DETAILS { get; set; }
        public virtual DbSet<TBL_HRMS_ASSET_MASTER> TBL_HRMS_ASSET_MASTER { get; set; }
        public virtual DbSet<TBL_HRMS_ASSETTYPE_MASTER> TBL_HRMS_ASSETTYPE_MASTER { get; set; }
        public virtual DbSet<TBL_HRMS_BLOODGROUP_MASTER> TBL_HRMS_BLOODGROUP_MASTER { get; set; }
        public virtual DbSet<TBL_HRMS_BOARD_UNIVERSITY_M> TBL_HRMS_BOARD_UNIVERSITY_M { get; set; }
        public virtual DbSet<TBL_HRMS_DEGREETYPE_MASTER> TBL_HRMS_DEGREETYPE_MASTER { get; set; }
        public virtual DbSet<TBL_HRMS_DEPARTMENTMASTER> TBL_HRMS_DEPARTMENTMASTER { get; set; }
        public virtual DbSet<TBL_HRMS_DESIGNATIONMASTER> TBL_HRMS_DESIGNATIONMASTER { get; set; }
        public virtual DbSet<TBL_HRMS_EXITSUBCATAGORY> TBL_HRMS_EXITSUBCATAGORY { get; set; }
        public virtual DbSet<TBL_HRMS_EXITTYPE_MASTER> TBL_HRMS_EXITTYPE_MASTER { get; set; }
        public virtual DbSet<TBL_HRMS_GRADE_MASTER> TBL_HRMS_GRADE_MASTER { get; set; }
        public virtual DbSet<TBL_HRMS_LOCATIONMASTER> TBL_HRMS_LOCATIONMASTER { get; set; }
        public virtual DbSet<TBL_HRMS_RECORDTYPE_MASTER> TBL_HRMS_RECORDTYPE_MASTER { get; set; }
        public virtual DbSet<TBL_HRMS_REPORTINGMASTER> TBL_HRMS_REPORTINGMASTER { get; set; }
        public virtual DbSet<TBL_HRMS_SHIFT_MASTER> TBL_HRMS_SHIFT_MASTER { get; set; }
        public virtual DbSet<TBL_SECTION> TBL_SECTION { get; set; }
        public virtual DbSet<TBL_STATE> TBL_STATE { get; set; }
        public virtual DbSet<TBL_SUB_DIVISION> TBL_SUB_DIVISION { get; set; }
        public virtual DbSet<USER> USERS { get; set; }
        public virtual DbSet<TBL_EMP_TRANSFER_DETAILS_BCK> TBL_EMP_TRANSFER_DETAILS_BCK { get; set; }
        public virtual DbSet<TBL_EMP_AWARDS> TBL_EMP_AWARDS { get; set; }
        public virtual DbSet<TBL_EMP_CULTURAL_ACTIVITYDTLS> TBL_EMP_CULTURAL_ACTIVITYDTLS { get; set; }
        public virtual DbSet<TBL_EMP_HOBBIES> TBL_EMP_HOBBIES { get; set; }
        public virtual DbSet<TBL_EMP_PUBLICATIONS> TBL_EMP_PUBLICATIONS { get; set; }
        public virtual DbSet<TBL_EMP_SOCIALACTIVITIES> TBL_EMP_SOCIALACTIVITIES { get; set; }
        public virtual DbSet<TBL_EMP_SPORTSDETAILS> TBL_EMP_SPORTSDETAILS { get; set; }
    }
}