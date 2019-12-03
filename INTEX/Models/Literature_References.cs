using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    public class Literature_References
    {
        [Key]
        public int ReferenceID { get; set; }

        public string Reference_Description { get; set; }
    }
}