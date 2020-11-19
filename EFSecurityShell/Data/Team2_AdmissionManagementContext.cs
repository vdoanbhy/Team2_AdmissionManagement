using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Team2_AdmissionManagement.Data
{
    public class Team2_AdmissionManagementContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Team2_AdmissionManagementContext() : base("name=Team2_AdmissionManagementContext")
        {
        }

        public System.Data.Entity.DbSet<Team2_AdmissionManagement.Models.Applicant> Applicants { get; set; }

        public System.Data.Entity.DbSet<Team2_AdmissionManagement.Models.Interest> Interests { get; set; }

        public System.Data.Entity.DbSet<Team2_AdmissionManagement.Models.Review> Reviews { get; set; }
    }
}
