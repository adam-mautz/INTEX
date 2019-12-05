using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("Employees")]

    public class Employees
    {
        [Key]
        public int EmpID { get; set; }

        [Display(Name = "Employee First Name")]
        public string Emp_First_Name { get; set; }

        [Display(Name = " Employee Last Name")]
        public string Emp_Last_Name { get; set; }

        [Display(Name = "Address 1")]
        public string Emp_Street_Address1 { get; set; }

        [Display(Name = "Address 2")]
        public string Emp_Street_Address2 { get; set; }

        [Display(Name = "City")]
        public string Emp_City { get; set; }

        [Display(Name = "State")]
        public string Emp_State { get; set; }

        [Display(Name = "Zip Code")]
        public string Emp_Zip { get; set; }

        [Display(Name = "Zip Code 2")]
        public string Emp_Zip_Plus { get; set; }

        [Display(Name = "Area Code")]
        public string Emp_Area_Code { get; set; }

        [Display(Name = "Phone Number")]
        public string Emp_Phone { get; set; }

        [Display(Name = "Email")]
        public string Emp_Email { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string Emp_Username { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Emp_Password { get; set; }
    }
}