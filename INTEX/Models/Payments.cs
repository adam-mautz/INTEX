using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("Payments")]
    public class Payments
    {
        [Key, Column(Order = 0)]
        public int CustID { get; set; }

        [Key, Column(Order = 1)]
        public int OrderID { get; set; }

        [Display(Name = "Payment Due")]
        public DateTime Payment_Due_Date { get; set; } //this is type= "date" in SQL server, but VS doesn't have date, only DateTime

        [Display(Name = "Early Payment Due")]
        public DateTime EarlyDueDate { get; set; }

        [Display(Name = "Order Subtotal")]
        public Decimal Subtotal { get; set; }//the max length in the database is 2 to the right of the decimal and 6 characters in length total.

        [Display(Name = "Discount")]
        public Decimal Discount { get; set; }

        [Display(Name = "Total Due")]
        public Decimal Total_Quote_Price { get; set; }

    }
}