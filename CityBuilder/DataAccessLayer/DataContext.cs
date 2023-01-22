using CityBuilder.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityBuilder.DataAccessLayer
{
    public class DataContext: DbContext
    {
        public DataContext() : base("DbConnection") { }
        public DbSet<Player> Player { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Structure> Structure { get; set; }
        public DbSet<IsBuild> IsBuild { get; set; }
        public DbSet<Area> Area { get; set; }
        
    }
}
