using CityBuilder.DataAccessLayer;
using CityBuilder.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityBuilder.Services
{
    public class CityServices : IGenericServices<City>
    {
        DataContext db = new DataContext();
        public bool Add(City entity)
        {
            bool status = false;
            try
            {
                db.City.Add(entity);
                db.SaveChanges();

                status = true;
            }
            catch
            {
                status = false;
            }
            return status;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public City Detail(int id)
        {
            throw new NotImplementedException();
        }

        public bool Edit(City entity)
        {
            throw new NotImplementedException();
        }

        public List<City> List(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
