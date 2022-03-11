using KolonkaModule.controller;
using KolonkaModule.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KolonkaModule.view
{
    public partial class AZSView : Form
    {
        StationData data;
        float pricePerLitr = -1;
        public AZSView(StationData load)
        {
            data = load;
            InitializeComponent();
        }

        private void AZSView_Load(object sender, EventArgs e)
        {
            GeneralController.Stylizer(this);
            Text = "Заправка №"+data.Id;
            List<StationData.Fueldata> fueldatas = new List<StationData.Fueldata>(data.FuelData);
            foreach(StationData.Fueldata fueldata in data.FuelData)
            {
                if (fueldata.Left <= 0 || fueldata.Price <= 0.0) fueldatas.Remove(fueldata);
            }
            fuelBox.DataSource = fueldatas;
            modeBox.SelectedIndex = 0;
            buyBox.SelectedIndex = 0;
            recalculate();
        }

        private void fuelBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            pricePerLitr = ((StationData.Fueldata)fuelBox.SelectedItem).Price;
            recalculate();
        }

        private void modeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(modeBox.SelectedIndex == 0)
            {
                vBox.Enabled = true;
                priceBox.Enabled = false;
            } else if(modeBox.SelectedIndex == 1)
            {
                vBox.Enabled = false;
                priceBox.Enabled = true;
            }
        }

        public void recalculate()
        {
            try
            {
                if (modeBox.SelectedIndex == 0 || modeBox.SelectedIndex == 2)
                {
                    priceBox.Text = (pricePerLitr * float.Parse(vBox.Text)).ToString();
                }
                else if (modeBox.SelectedIndex == 1)
                {
                    vBox.Text = (float.Parse(priceBox.Text) / pricePerLitr).ToString();
                }
            }
            catch { }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            recalculate();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            recalculate();
        }

        private void proceedButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Оплата успешно проведена!");
            Close();
        }
    }
}
