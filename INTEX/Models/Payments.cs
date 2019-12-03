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
        [Key]
        public int CustID { get; set; }

        public int OrderID { get; set; }

        public DateTime Payment_Due_Date { get; set; } //this is type= "date" in SQL server, but VS doesn't have date, only DateTime

        public DateTime EarlyDueDate { get; set; }

        public Decimal Subtotal { get; set; }//the max length in the database is 2 to the right of the decimal and 6 characters in length total.

        public Decimal MyProperty { get; set; }

        public Decimal Total_Quote_Price { get; set; }

    }
}