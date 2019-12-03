using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public int CustID { get; set; }

        public string Cust_First_Name { get; set; }

        public string Cust_Last_Name { get; set; }

        public string Cust_Street_Address1 { get; set; }

        public string Cust_Street_Address2 { get; set; }

        public string Cust_City { get; set; }

        public string Cust_State { get; set; }

        public string Cust_Zip { get; set; }

        public string Cust_Zip_Plus { get; set; }

        public string Cust_Area_Code { get; set; }

        public string Cust_Phone { get; set; }

        public string Cust_Email { get; set; }

        public string Cust_Username { get; set; }

        public string Cust_Password { get; set; }


    }
}