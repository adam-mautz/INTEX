using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    public class Materials
    {
        [Key]
        public int MaterialID { get; set; }

        public string Material_Description { get; set; }
    }
}