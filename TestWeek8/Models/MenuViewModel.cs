using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestWeek8.Models
{
    public class MenuViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Insert Name")]
        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}
