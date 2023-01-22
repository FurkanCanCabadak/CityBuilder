using CityBuilder.DataAccessLayer;
using CityBuilder.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace CityBuilder.Services
{
    public class AreaServices : IGenericServices<Area>
    {
        DataContext db = new DataContext();
        public bool Add(Area entity)
        {
            bool status = false;
            try
            {
                db.Area.Add(entity);
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

        public Area Detail(int id)
        {
            Area area = db.Area.FirstOrDefault(x => x.Id == id);
            return area;
        }

        public bool Edit(Area entity)
        {
            bool status = false;
            try
            {
                Area area = db.Area.FirstOrDefault(x => x.Id == entity.Id);
                area.StructureLvl = entity.StructureLvl;
                area.GetMoney=entity.GetMoney;
                area.IsCollect=entity.IsCollect;
                area.StructureId=entity.StructureId;
                area.IsBuildId=entity.IsBuildId;
                area.IsStatus=entity.IsStatus;
                db.SaveChanges();
                status = true;
            }
            catch (Exception)
            {

            }
            return status;
        }

        public List<Area> List(int Id)
        {
            List<Area> list = new List<Area>();
            foreach (var area in db.Area.ToList())
            {
                if (area.CityId == Id)
                {
                    list.Add(area);
                }
            }
            return list;
        }
    }
}
