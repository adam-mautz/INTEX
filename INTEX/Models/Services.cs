using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("Services")]
    public class Services
    {
        [Key]
        public string Test_Type { get; set; }

        public string Test_Name { get; set; }

        public string Procedure_Description { get; set; }

        public Decimal Test_Cost { get; set; }

        public Decimal Base_Price { get; set; }
    }
}