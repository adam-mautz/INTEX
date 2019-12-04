using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace INTEX.Models
{
    [Table("Customers")]
    public class Customer
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int CustID { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [DisplayName("First name")]
        [StringLength(30)]
        public string Cust_First_Name { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [DisplayName("Last name")]
        [StringLength(30)]
        public string Cust_Last_Name { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [DisplayName("Street Address")]
        [StringLength(30)]
        public string Cust_Street_Address1 { get; set; }

        [DisplayName("Street Address (cont.)")]
        [StringLength(30)]
        public string Cust_Street_Address2 { get; set; }

        [Required(ErrorMessage = "City is required")]
        [DisplayName("City")]
        [StringLength(50)]
        public string Cust_City { get; set; }

        [Required(ErrorMessage = "State is required")]
        [DisplayName("State")]
        [StringLength(20)]
        public string Cust_State { get; set; }

        [Required(ErrorMessage = "Zip is required")]
        [DisplayName("Zip Code")]
        [StringLength(5)]
        public string Cust_Zip { get; set; }

        [DisplayName("Zip Code Plus")]
        [StringLength(4)]
        public string Cust_Zip_Plus { get; set; }

        [Required(ErrorMessage = "Area code is required")]
        [DisplayName("Area Code")]
        [StringLength(3)]
        public string Cust_Area_Code { get; set; }

        [Required(ErrorMessage = "Phone Number required")]
        [DisplayName("Phone Number")]
        [StringLength(7)]
        public string Cust_Phone { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DisplayName("Email Address")]
        [StringLength(30)]
        public string Cust_Email { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [DisplayName("Username")]
        [StringLength(30)]
        public string Cust_Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DisplayName("Password")]
        [StringLength(30)]
        public string Cust_Password { get; set; }


    }
}