using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static TestWeek8.Core.Models.Plate;

namespace TestWeek8.Models
{
    public class PlateViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Tipology TypePlate { get; set; }
        public decimal Price { get; set; }
        public int MenuId { get; set; }
    }
}
