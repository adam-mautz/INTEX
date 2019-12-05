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
        public int Compound_Sequence_Code { get; set; }

        public int LT_Number { get; set; }

        public string Test_Type { get; set; }

        public string Comment { get; set; }

        public string StatusID { get; set; }

        public string Raw_Results { get; set; } //this will be holding a text file. Will the data type need to be changed?

        public Boolean? Approved { get; set; }

        public DateTime? Test_Date_Scheduled { get; set; }

        public int OrderID { get; set; }


    }

    public class testModels
    {
        public List<Tests> lstTests { get; set; }
    }

}