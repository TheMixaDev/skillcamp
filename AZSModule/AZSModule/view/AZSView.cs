using AZSModule.controller;
using AZSModule.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AZSModule.view
{
    public partial class AZSView : Form
    {
        StationData station;
        public AZSView(StationData load)
        {
            station = load;
            InitializeComponent();
        }

        private void AZSView_Load(object sender, EventArgs e)
        {
            GeneralController.Stylizer(this);
            Text = "Управление АЗС №"+station.Id;
            addressBox.Text = station.Address;
            List<string> fuels = new List<string>(new string[] { "92", "95", "98", "DiselFuel" });
            foreach(string fuel in fuels)
            {
                int i = fuelGrid.Rows.Add();
                fuelGrid.Rows[i].Cells[0].Value = fuel;
                fuelGrid.Rows[i].Cells[1].Value = 0;
                fuelGrid.Rows[i].Cells[2].Value = 0;
            }
            foreach(StationData.Fueldata fueldata in station.FuelData)
            {
                string fuelName = Regex.Replace(fueldata.Type, @"\s+", "");
                if(fuels.Contains(fuelName))
                {
                    int i = fuels.IndexOf(fuelName);
                    fuelGrid.Rows[i].Cells[1].Value = fueldata.Price;
                    fuelGrid.Rows[i].Cells[2].Value = fueldata.Left;
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            List<StationData.Fueldata> fueldatas = new List<StationData.Fueldata>();
            List<string> fuels = new List<string>(new string[] { "92", "95", "98", "Disel Fuel" });
            bool error = false;
            for (int i = 0; i < 4; i++)
            {
                try
                {
                    StationData.Fueldata fueldata = new StationData.Fueldata
                    {
                        Type = fuels[i],
                        Price = float.Parse(fuelGrid.Rows[i].Cells[1].Value.ToString()),
                        Left = int.Parse(fuelGrid.Rows[i].Cells[2].Value.ToString()),
                    };
                    fueldatas.Add(fueldata);
                }
                catch
                {
                    MessageBox.Show("Данные о топливе "+fuels[i]+" имеют неверный формат! Перепроверьте их и попробуйте еще раз.");
                    error = true;
                }
            }
            if (error) return;
            station.Address = FixAddress(addressBox.Text);
            station.FuelData = fueldatas.ToArray();
            saveButton.Enabled = false;
            AZSView instance = this;
            new Thread(() =>
            {
                StationController.SetStation(station);
                instance.Invoke(new Action(() =>
                {
                    saveButton.Enabled = true;
                    MessageBox.Show("Данные сохранены!");
                }));
            }).Start();

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        public string FixAddress(string address)
        {
            List<char> chars = new List<char>(address.ToCharArray());
            while (chars[chars.Count-1] == ' ')
            {
                chars.RemoveAt(chars.Count - 1);
            }
            return new string(chars.ToArray());
        }
    }
}
