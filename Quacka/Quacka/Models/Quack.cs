using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quacka.Models
{
    public class Quack
    {
        public int Id { get; set; }
        [MaxLength(140)]
        [Required]
        public string Body { get; set; }
        [Display(Name = "Created")]
        public DateTime CreatedAt { get; set; }
    }
}