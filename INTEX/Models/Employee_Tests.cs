using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("Employee_Tests")]
    public class Employee_Tests
    {
        [Key, Column(Order = 0)]
        public int Compound_Sequence_Code { get; set; }

        [Key, Column(Order = 1)]
        public int MyProperty { get; set; }

        public int EmpID { get; set; }
    }
}