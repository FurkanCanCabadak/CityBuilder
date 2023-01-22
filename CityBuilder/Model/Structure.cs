using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityBuilder.Model
{
    public class Structure
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan UpgradeTime { get; set; }
        public double Income { get; set; }
        public int Level { get; set; }
        public int MaxLevel { get; set; }
        public double Cost { get; set; }
        public string StructureImage { get; set; }
        public bool IsDelete { get; set; }
        public bool IsStatus { get; set; }
        public List<Area> Area { get; set; }
    }
}
