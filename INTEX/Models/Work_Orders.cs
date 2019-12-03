using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("Work_Orders")]
    public class Work_Orders
    {
        [Key]
        public int OrderID { get; set; }

        public int CustID { get; set; }

        public int LT_Number { get; set; }

        public Boolean Rushed { get; set; }

        public Decimal Discount_Percentage { get; set; }

        public string StatusID { get; set; }

        public string Comments { get; set; }//ssms has this as a varbinary data type, so string here might not be large enough

        public string Reports { get; set; } //ssms has this as a varbinary data type, so string here might not be large enough
    }
}