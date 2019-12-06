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
        [Display(Name = "Order ID")]
        public int OrderID { get; set; }

        [Display(Name = "Customer ID")]
        public int CustID { get; set; }

        [Display(Name = "LT Number")]
        public int LT_Number { get; set; }

        [Display(Name = "Rush Order")]
        public Boolean? Rushed { get; set; }

        [Display(Name = "Discount %")]
        public Decimal? Discount_Percentage { get; set; }

        [Display(Name = "Status")]
        [StringLength(1, ErrorMessage = "Enter U for Uncheduled, I for Incomplete, or C for Complete")]
        public string StatusID { get; set; }

        [Display(Name = "Comments")]
        public string Comments { get; set; }

        [Display(Name = "Summary Report")]
        public string Reports { get; set; } 
    }
}