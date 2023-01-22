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
    public partial class GameScreen : Form
    {
        DbList DbList = new DbList();
        DataContext db = new DataContext();
        PlayerServices playerServices = new PlayerServices();
        AreaServices AreaServices = new AreaServices();
        StructureServices StructureServices = new StructureServices();
        GameServices GameServices = new GameServices();
        List<Area> areas = new List<Area>();
        List<PictureBox> pBox = new List<PictureBox>();
        Structure structure = new Structure();
        Player onPlayer;
        City city = new City();
        Area area = new Area();
        double playerMoney = 0;

        List<Structure> structures;
        double getMoney = 0;
        int panelY = 10;
        public GameScreen(int  id)
        {
            onPlayer = db.Player.FirstOrDefault(x => x.Id == id);
            InitializeComponent();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            dateTime.Start();
            game.Start(); structures = DbList.GetStructure();
            city = db.City.FirstOrDefault(x => x.PlayerId == onPlayer.Id);
            areas = AreaServices.List(city.Id);
            playerMoney = db.Player.FirstOrDefault(x => x.Id == onPlayer.Id).Money;
            foreach (var item in areas.ToList())
            {
                getMoney += item.GetMoney;
            }
            Reset();
        }
        public void Reset()
        {
            onPlayer = playerServices.Detail(onPlayer.Id);
            playerMoney = onPlayer.Money;
            BuildMap();
            label1.Text = playerMoney.ToString();
            label2.Text = area.StructureLvl.ToString(); 
            foreach (var item in areas.ToList())
            {
                getMoney += item.GetMoney;
            }
            getMoneyLbl.Text = getMoney.ToString();
            getMoney=0;
            label1.Update();
            label1.Refresh();
            label2.Update();
            label2.Refresh();
            Application.DoEvents();
        }
        public void BuildMap()
        {
            cityPanel.Controls.Clear();
            foreach (var area in areas.ToList())
            {
                PictureBox picture = GameServices.CreatePB(area);
                picture.Click += Picture_Click;
                pBox.Add(picture);
                cityPanel.Controls.Add(picture);
            }
        }

        private void Picture_Click(object sender, EventArgs e)
        {
            menuPnl.Controls.Clear();
            PictureBox clickedPic = sender as PictureBox;
            foreach (var item in areas.ToList())
            {
                if (item.LocationX == clickedPic.Location.X&& item.LocationY == clickedPic.Location.Y)
                {
                    area = item;
                    if (item.StructureId==1)
                    {
                        foreach(var structure in structures.ToList())
                        {
                            if (structure.Id!=1)
                            {
                                Panel build = GameServices.BuildMenu(area, structure.StructureImage,panelY);
                                menuPnl.Controls.Add(build);
                                panelY += 300;
                            }
                        }
                        panelY=0;
                        break;
                    }
                    else
                    {
                        Panel upgrade = GameServices.UpgradeBuildMenu(area);
                        menuPnl.Controls.Add(upgrade);
                        break;
                    }
                }
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            onPlayer = null;
            this.DialogResult = DialogResult.OK;
            dateTime.Stop();
            game.Stop();
        }

        private void game_Tick(object sender, EventArgs e)
        {
            foreach (var item in areas.ToList())
            {
                if (item.StructureId!=1)
                {
                    structure = StructureServices.Detail(item.StructureId);
                    item.GetMoney += structure.Income * item.StructureLvl;
                    AreaServices.Edit(item);
                }
            }
            Reset();
        }

        private void dateTime_Tick(object sender, EventArgs e)
        {
            label2.Text=DateTime.Now.ToString("HH:mm:ss");
        }

        private void collectBtn_Click(object sender, EventArgs e)
        {
            onPlayer = playerServices.Detail(onPlayer.Id);
            foreach (var item in areas.ToList())
            {
                getMoney += item.GetMoney;


                item.GetMoney = 0;
                AreaServices.Edit(item);
            }
            Console.WriteLine(onPlayer.Money.ToString()+" get= "+ getMoney);
            onPlayer.Money +=getMoney;
            playerServices.Edit(onPlayer);
            getMoney = 0;
            Reset();
        }
    }
}
