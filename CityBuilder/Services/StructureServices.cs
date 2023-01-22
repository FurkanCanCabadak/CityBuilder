using CityBuilder.DataAccessLayer;
using CityBuilder.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityBuilder.Services
{
    public class StructureServices : IGenericServices<Structure>
    {
        DataContext db = new DataContext();
        public bool Add(Structure entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Structure Detail(int id)
        {
            Structure structure = db.Structure.FirstOrDefault(x => x.Id == id);
            return structure;
        }

        public bool Edit(Structure entity)
        {
            throw new NotImplementedException();
        }

        public List<Structure> List(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
