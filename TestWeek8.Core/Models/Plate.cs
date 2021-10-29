using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWeek8.Core.Models
{
    public class Plate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Tipology PlateType { get; set; }
        public decimal Price { get; set; }
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
        public enum Tipology
        {
            FirstCourse,
            MainCourse,
            SideDish,
            Sweet
        }
    }
}
