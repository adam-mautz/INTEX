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
        public NorthwestContext() : base("ClientInstrumentContext")
        {
        }

        public DbSet<Customer> customer { get; set; }
    }
}