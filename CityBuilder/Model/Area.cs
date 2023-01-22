using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace CityBuilder.Model
{
    public class Area
    {

        public int Id{ get; set; }
        public double GetMoney{ get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public int StructureId { get; set; }
        public Structure Structure { get; set; }
        public int StructureLvl { get; set; }
        public int IsBuildId { get; set; }
        public IsBuild IsBuild { get; set; }
        public int LocationX { get; set; }
        public int LocationY { get; set; }
        public bool IsCollect { get; set; }
        public bool IsDelete { get; set; }
        public bool IsStatus { get; set; }
    }
}
