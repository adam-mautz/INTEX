using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("Statuses")]
    public class Statuses
    {
        [Key]
        [StringLength(1, MinimumLength = 1, ErrorMessage = "This must be 1 character long")]
        public string StatusID { get; set; }

        [StringLength(30, ErrorMessage = "This string must be at most 30 characters long")]
        public string Status_Name { get; set; }
    }
}