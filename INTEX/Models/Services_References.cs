using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("Services_References")]
    public class Services_References
    {
        [Key]
        [StringLength(2, ErrorMessage = "This string must be 2 characters long")]
        public string Test_Type { get; set; }

        public int ReferenceID { get; set; }
    }
}