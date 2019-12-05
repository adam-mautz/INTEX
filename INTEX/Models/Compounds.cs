using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("Compounds")]
    public class Compounds
    {
        [Key]
        public int LT_Number { get; set; }

        public string Compound_Name { get; set; }

        public decimal Compound_Quantity { get; set; }

        public string Appearance { get; set; }

        public decimal Estimated_Weight { get; set; }

        public DateTime Date_Arrived { get; set; }

        public DateTime Date_Received { get; set; }

        public DateTime Date_Due { get; set; }

        public decimal Actual_Weight { get; set; }

        public decimal Max_Tolerated_Dose { get; set; }
    }
}