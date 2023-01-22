using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityBuilder.Model
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; }
        public bool IsDelete { get; set; }
        public bool IsStatus { get; set; }

        public List<Area> Area { get; set; }
    }
}
