using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ISD.Models;

namespace ISD.Areas.Admin.Models
{
    public class dbContext:DbContext
    {
        public dbContext() : base("name=constr") { }
        //tables mapping      
        public DbSet<AdminLogin> adminDetails { get; set; }        
        public DbSet<PagesData> pageDataList { get; set; }

        public DbSet<Drawing> drawings { get; set; }
        public DbSet<SampleModels> models { get; set; }

        public DbSet<DrawingsType> drawingTypes { get; set; }

        //user section models
        public DbSet<CustomerQuery> customerQuery { get; set; }


    }


}