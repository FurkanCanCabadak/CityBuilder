using CityBuilder.DataAccessLayer;
using CityBuilder.Model;
using CityBuilder.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CityBuilder.View
{
    public partial class SignUpScreen : Form
    {   
        //Gerekli nesnelerin oluşturulması.
        DataContext db = new DataContext();
        DbList DbList = new DbList();
        PlayerServices PlayerServices = new PlayerServices();
        CityServices CityServices = new CityServices();
        AreaServices AreaServices = new AreaServices();
        bool addArea = false;
        bool addPlayer = false;
        bool addCity = false;
        public SignUpScreen()
        {
            InitializeComponent();
        }
        //Oyun açıldığında yüklenmesi gereken kısımlar.
        private void SignUpScreen_Load(object sender, EventArgs e)
        {
            
        }
        public void Reset()
        {
            mailTxt.Clear();
            usernameTxt.Clear();
            passwordTxt.Clear();
            ageNmrc.Value = 0;
        }
        //Kayıt ol butonu ile kullanıcı kaydı yapılması.
        private void signUpBtn_Click(object sender, EventArgs e)
        {
            List<Structure> structures = DbList.GetStructure();
            List<IsBuild> isBuilds = DbList.GetIsBuild();
            var player = db.Player.FirstOrDefault(x => x.Username == usernameTxt.Text);
            if (player== null)
            {
                Player newPlayer = new Player()
                {
                    Money = 1000,
                    IsDelete = false,
                    IsStatus = true,
                    Username = usernameTxt.Text,
                    Password = passwordTxt.Text,
                    Age = Convert.ToInt32(ageNmrc.Value),
                    Email = mailTxt.Text
                };
                addPlayer = PlayerServices.Add(newPlayer);
                City newCity = new City() 
                { 
                    PlayerId = newPlayer.Id,
                    IsDelete = false,
                    IsStatus = true,
                    Name = newPlayer.Username
                };
                addCity=CityServices.Add(newCity);
                int x = 0;
                int y = 0;
                for (int i = 0; i < 100; i++)
                {
                    Area newArea = new Area()
                    {
                        IsDelete = false,
                        IsStatus = true,
                        GetMoney = 0,
                        CityId = newCity.Id,
                        StructureId = structures[0].Id,
                        IsCollect = false,
                        IsBuildId = isBuilds[0].Id,
                        LocationX = x,
                        LocationY=y
                    };
                    addArea = AreaServices.Add(newArea);
                    if (addArea == false)
                    {
                        break;
                        MessageBox.Show("hata oluştu");
                    }
                    x += 120;
                    if (x == 1200)
                    {
                        x = 0;
                        y += 80;
                    }
                }
                if (addArea==true && addPlayer == true&& addCity==true)
                {
                    db.SaveChanges();
                    GameScreen gameScreen = new GameScreen(newPlayer.Id);
                    this.Hide();
                    gameScreen.ShowDialog();
                    this.Show();
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Unexpected error pls try again.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    Reset();
                }
            }
            else
            {
                MessageBox.Show("This player already exist. Please choose another username.","Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Reset();
            }
        }

    }
}
