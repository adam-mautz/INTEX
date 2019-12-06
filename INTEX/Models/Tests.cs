using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("Tests")]
    public class Tests
    {
        [Key]
        [Display(Name = "Sequence Code")]
        public int Compound_Sequence_Code { get; set; }

        [Display(Name = "LT Number")]
        public int LT_Number { get; set; }

        [Display(Name = "Test Type")]
        public string Test_Type { get; set; }

        [Display(Name = "Comments")]
        public string Comment { get; set; }

        [Display(Name = "Status")]
        public string StatusID { get; set; }

        [Display(Name = "Test Data File")]
        public string Raw_Results { get; set; } //this will be holding a text file. Will the data type need to be changed?

        [Display(Name = "Approved")]
        public Boolean? Approved { get; set; }

        [Display(Name = "Data Scheduled")]
        public DateTime? Test_Date_Scheduled { get; set; }

        [Display(Name = "Order ID")]
        public int OrderID { get; set; }


    }

    public class testModels
    {
        public List<Tests> lstTests { get; set; }
    }

}