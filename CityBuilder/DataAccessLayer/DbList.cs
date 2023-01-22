using CityBuilder.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityBuilder.DataAccessLayer
{
    public class DbList
    {
        DataContext db = new DataContext();
        private List<IsBuild> _isBuild = new List<IsBuild>();
        private List<Structure> _structure = new List<Structure>();
        public List<IsBuild> GetIsBuild()
        {
            foreach (var isBuild in db.IsBuild.ToList())
            {
                _isBuild.Add(isBuild);
            }
            List<IsBuild> _build = this._isBuild.ToList();
            return _build;
        }
        public List<Structure> GetStructure()
        {
            foreach (var structure in db.Structure.ToList())
            {
                _structure.Add(structure);
            }
            List<Structure> _structures = this._structure.ToList();
            return _structures;
        }
    }
}
