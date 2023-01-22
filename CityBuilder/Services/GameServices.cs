using CityBuilder.DataAccessLayer;
using CityBuilder.Model;
using CityBuilder.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CityBuilder.Services
{
    public class GameServices
    {
        DataContext db = new DataContext(); 
        PlayerServices playerServices = new PlayerServices();
        AreaServices areaServices = new AreaServices();
        StructureServices structureServices = new StructureServices();
        CityServices cityServices = new CityServices();
        double totalCost = 0;
        Area areaClicked = new Area();
        int playerId = 0;
        public PictureBox CreatePB(Area area)
        {
            Structure structure = db.Structure.FirstOrDefault(x => x.Id == area.StructureId);
            PictureBox picture = new PictureBox();
            picture.Width = 120;
            picture.Height = 80;
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            picture.ImageLocation = @"C:\Users\furka\Desktop\işkur\Game\CityBuilder\CityBuilder\Resources\images\structures\" + structure.StructureImage;
            picture.Location = new Point(area.LocationX, area.LocationY);
            return picture;
        }
        public Panel UpgradeBuildMenu(Area area)
        {
            areaClicked = area;
            playerId = db.City.FirstOrDefault(x => x.Id == area.CityId).PlayerId;
            Panel panel = new Panel();
            panel.Width = 150;
            panel.Height = 300;
            panel.BackColor = Color.Transparent;
            Structure structure = db.Structure.FirstOrDefault(x => x.Id == area.StructureId);
            totalCost = structure.Cost * (area.StructureLvl + 1);
            PictureBox menuPicture = new PictureBox();
            menuPicture.Width = 80;
            menuPicture.Height = 60;
            menuPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            menuPicture.Location = new Point(35, 10);
            menuPicture.ImageLocation = @"C:\Users\furka\Desktop\işkur\Game\CityBuilder\CityBuilder\Resources\images\structures\" + structure.StructureImage;
            panel.Controls.Add(menuPicture);
            Label cost = new Label();
            cost.Text = totalCost.ToString() + " Cr";
            cost.Location = new Point(35, 75);
            cost.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            cost.BackColor = System.Drawing.Color.Transparent;
            panel.Controls.Add(cost);
            Label lvl = new Label();
            lvl.Text = (area.StructureLvl + 1).ToString() + " Lvl";
            lvl.Location = new Point(35, 95);
            lvl.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            lvl.BackColor = System.Drawing.Color.Transparent;
            panel.Controls.Add(lvl);
            Button button = new Button();
            button.Text = "Upgrade";
            button.Width = 120;
            button.Height = 40;
            button.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            button.Location = new Point(15, 120);
            button.Click += UpgradeButtonClick;
            panel.Controls.Add(button);
            if (area.StructureLvl == structure.MaxLevel)
            {
                button.Visible = false;
                lvl.Text = "Max Lvl";
                cost.Visible = false;
            }
            return panel;

        }

        public Panel BuildMenu(Area area,string image,int y)
        {
            Structure structure = db.Structure.FirstOrDefault(x => x.StructureImage == image);
            areaClicked = area;
            playerId = db.City.FirstOrDefault(x => x.Id == area.CityId).PlayerId;
            Panel panel = new Panel();
            panel.Location = new Point(-20, y);
            panel.Width = 150;
            panel.Height = 300;
            panel.BackColor = Color.Transparent;
            panel.Name = structure.Name;
            PictureBox menuPicture = new PictureBox();
            menuPicture.Width = 80;
            menuPicture.Height = 60;
            menuPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            menuPicture.Location = new Point(35, 10);
            menuPicture.ImageLocation = @"C:\Users\furka\Desktop\işkur\Game\CityBuilder\CityBuilder\Resources\images\structures\" + image;
            panel.Controls.Add(menuPicture);
            Label cost = new Label();
            cost.Text = structure.Cost.ToString() + " Cr";
            cost.Location = new Point(35, 85);
            cost.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            cost.BackColor = System.Drawing.Color.Transparent;
            panel.Controls.Add(cost);
            Label ıncome = new Label();
            ıncome.Text = (structure.Income).ToString() + " Cr";
            ıncome.Location = new Point(35, 115);
            ıncome.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            ıncome.BackColor = System.Drawing.Color.Transparent;
            panel.Controls.Add(ıncome);
            Button button = new Button();
            button.Text = "Build";
            button.Name=structure.Name;
            button.Width = 120;
            button.Height = 40;
            button.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            button.Location = new Point(15, 140);
            button.Click += BuildButtonClick;
            panel.Controls.Add(button);

            return panel;
        }

        private void BuildButtonClick(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Player player = db.Player.FirstOrDefault(x => x.Id == playerId);
            double cost = db.Structure.FirstOrDefault(x => x.Name == button.Name).Cost;
            if (player.Money>=cost)
            {
                areaClicked.StructureId = db.Structure.FirstOrDefault(x => x.Name == button.Name).Id;
                areaServices.Edit(areaClicked);
                player.Money -= cost;
                cost = 0;
                playerServices.Edit(player);
                CreatePB(areaClicked);
                MessageBox.Show("success");
            }
            else
            {
                MessageBox.Show("fail");
            }

        }

        private void UpgradeButtonClick(object sender, EventArgs e)
        {
            Player player = db.Player.FirstOrDefault(x=>x.Id == playerId);
            if (player.Money >= totalCost)
            {
                player.Money -= totalCost;
                playerServices.Edit(player);
                areaClicked.StructureLvl++;
                areaServices.Edit(areaClicked);
                totalCost = 0;
                MessageBox.Show("success");
            }
            else
            {
                MessageBox.Show("fail");
            }
        }
    }
}
