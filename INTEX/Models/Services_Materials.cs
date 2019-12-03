using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("Services_Materials")]
    public class Services_Materials
    {
        [Key]
        [StringLength(2, ErrorMessage = "This must be 2 characters long")]
        public string Test_Type { get; set; }

        [StringLength(4, ErrorMessage = "This must be 4 characters long")]
        public int MaterialID { get; set; }
    }
}