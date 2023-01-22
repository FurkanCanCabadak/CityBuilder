using CityBuilder.DataAccessLayer;
using CityBuilder.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityBuilder.Services
{
    public class PlayerServices : IGenericServices<Player>
    {
        DataContext db = new DataContext();
        public bool Add(Player entity)
        {
            bool status = false;
            try
            {
                db.Player.Add(entity);
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
            bool status = false;
            var product = db.Player.Find(id);
            if (product != null)
            {
                product.IsDelete = true;
                db.SaveChanges();
                status = true;
            }
            return status;
        }

        public Player Detail(int id)
        {
            Player player=db.Player.FirstOrDefault(x => x.Id == id);
            return player;
        }

        public bool Edit(Player entity)
        {
            bool status = false;
            try
            {
                Player entityPlayer = db.Player.FirstOrDefault(x => x.Id == entity.Id);
                entityPlayer.Age = entity.Age;
                entityPlayer.Money = entity.Money;
                entityPlayer.Email = entity.Email;
                entityPlayer.Password = entity.Password;
                entityPlayer.IsStatus = entity.IsStatus;
                entityPlayer.Username = entity.Username;
                db.SaveChanges();
                status = true;
            }
            catch (Exception)
            {

            }
            return status;
        }

        public List<Player> List(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
