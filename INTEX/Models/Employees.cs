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

        public string Emp_First_Name { get; set; }

        public string Emp_Last_Name { get; set; }

        public string Emp_Street_Address1 { get; set; }

        public string Emp_Street_Address2 { get; set; }

        public string Emp_City { get; set; }

        public string Emp_State { get; set; }

        public string Emp_Zip { get; set; }

        public string Emp_Zip_Plus { get; set; }

        public string Emp_Area_Code { get; set; }

        public string Emp_Phone { get; set; }

        public string Emp_Email { get; set; }

        [Required]
        public string Emp_Username { get; set; }

        [Required]
        public string Emp_Password { get; set; }
    }
}