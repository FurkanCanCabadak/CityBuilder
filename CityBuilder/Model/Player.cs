using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CityBuilder.Model
{
    public class Player
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public double Money { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public bool IsDelete { get; set; }
        public bool IsStatus { get; set; }

        public List<City> City { get; set; }
    }
}
