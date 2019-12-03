using INTEX.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace INTEX.DAL 
{
    public class NorthwestContext : DbContext
    {
        public NorthwestContext() : base("NorthwestContext")
        {

        }

        public DbSet<Payments> payments { get; set; }
        public DbSet<Services> services { get; set; }
        public DbSet<Services_Materials> services_materials { get; set; }
        public DbSet<Services_References> services_references { get; set; }
        public DbSet<Statuses> statuses { get; set; }
        public DbSet<Tests> tests { get; set; }
        public DbSet<Work_Orders> work_orders { get; set; }
    }
}