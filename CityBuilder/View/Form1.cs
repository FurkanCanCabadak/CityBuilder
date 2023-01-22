using CityBuilder.DataAccessLayer;
using CityBuilder.Model;
using CityBuilder.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CityBuilder
{
    public partial class CityBuilder : Form
    {
        //Gerekli nesnelerin oluşturulması.
        DataContext db = new DataContext();
        public CityBuilder()
        {
            InitializeComponent();
        }
        public void Reset()
        {
            usernameTxt.Clear();
            passwordTxt.Clear();
        }
        //Oyun açıldığında yüklenmesi gereken kısımlar.
        private void CityBuilder_Load(object sender, EventArgs e)
        {
        }
        //Giriş yapma butonu
        private void signInBtn_Click(object sender, EventArgs e)
        {
            var player = db.Player.FirstOrDefault(Player => Player.Username == usernameTxt.Text&&Player.Password == passwordTxt.Text);
            if (player!=null)
            {
                this.Hide();
                GameScreen gameScreen = new GameScreen(player.Id);//Giriş yapan kullanıcının değerleri oyuna aktarılıyor.
                gameScreen.ShowDialog();
                Reset();
                this.Show();
            }
            else
            {
                MessageBox.Show("Entry Failed");
                Reset();
            }
        }
        //Kaydolma butonu
        private void signUpBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignUpScreen signUp = new SignUpScreen();
            signUp.ShowDialog();
            Reset();
            this.Show();
        }
    }
}
