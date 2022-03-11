using KolonkaModule.controller;
using KolonkaModule.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KolonkaModule.view
{
    public partial class AZSView : Form
    {
        StationData data;
        float pricePerLitr = -1;
        public static float newLitrs = -1;
        public static bool successPayment = false;
        public static bool closeView = false;
        public AZSView(StationData load)
        {
            data = load;
            InitializeComponent();
        }

        private void AZSView_Load(object sender, EventArgs e)
        {
            proceedLabel.Visible = false;
            GeneralController.Stylizer(this);
            Text = "Заправка №"+data.Id;
            List<StationData.Fueldata> fueldatas = new List<StationData.Fueldata>(data.FuelData);
            foreach(StationData.Fueldata fueldata in data.FuelData)
            {
                if (fueldata.Left <= 0 || fueldata.Price <= 0.0) fueldatas.Remove(fueldata);
            }
            clientBox.DataSource = ClientController.GetClients();
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
            } else
            {
                vBox.Enabled = false;
                priceBox.Enabled = false;
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
            closeView = false;
            try
            {
                proceedLabel.Visible = true;
                float price = float.Parse(priceBox.Text);
                float amount = float.Parse(vBox.Text);
                ClientData client = ((ClientData)clientBox.SelectedItem);
                StationData.Fueldata fueldata = ((StationData.Fueldata)fuelBox.SelectedItem);
                List<string> cards = ClientController.GetCards(client.Id);
                if (cards.Count < 1)
                {
                    MessageBox.Show("К вашему аккаунту не привязаны банковские карты!");
                    proceedLabel.Visible = false;
                    return;
                }
                if (buyBox.SelectedIndex == 0)
                {
                    proceedButton.Enabled = false;
                    AZSView instance = this;
                    new Thread(() => {
                        bool paymentSuccess = BankController.Pay(cards[0], client, price, data.Id, fueldata.Type, amount);
                        if(paymentSuccess)
                        {
                            instance.Invoke(new Action(() =>
                            {
                                proceedLabel.Visible = false;
                                MessageBox.Show("Одобрено. Код транзакции: "+DateTime.Now.ToString("ddMMyyyy-hhmmss"));
                                (new PistolView(cards[0], price, pricePerLitr, fueldata.Type, amount, data.Id)).ShowDialog();
                                if (closeView) Close();
                            }));
                        } else
                        {
                            MessageBox.Show("Отклонено. Код транзакции: 00000000-000000");
                        }
                    }).Start();
                }
                else
                {
                    if (client.Balance < price)
                    {
                        newLitrs = -1;
                        successPayment = false;
                        (new AlternativePaymentView(client,pricePerLitr, price-client.Balance, fueldata.Type, data.Id, amount)).ShowDialog();
                        if (successPayment)
                        {
                            if(newLitrs > -0.5)
                            {
                                amount = newLitrs;
                            }
                            proceedLabel.Visible = false;
                            MessageBox.Show("Оплата успешно проведена!");
                            (new PistolView(cards[0], price, pricePerLitr, fueldata.Type, amount, data.Id)).ShowDialog();
                            if (closeView) Close();
                        }
                        else MessageBox.Show("Оплата отменена.");
                        proceedLabel.Visible = false;
                    } else
                    {
                        AZSView instance = this;
                        new Thread(() =>
                        {
                            bool result = ClientController.TakeBonuses(client.Id, (int)Math.Floor(price));
                            if (result)
                            {
                                instance.Invoke(new Action(() =>
                                {
                                    proceedLabel.Visible = false;
                                    MessageBox.Show("Оплата успешно проведена!");
                                    (new PistolView(cards[0], price, pricePerLitr, fueldata.Type, amount, data.Id)).ShowDialog();
                                    if (closeView) Close();
                                }));
                            } else
                            {
                                instance.Invoke(new Action(() =>
                                {
                                    proceedLabel.Visible = false;
                                    MessageBox.Show("Не удалось списать бонусы!");
                                }));
                            }
                        }).Start();
                    }
                }
            } catch {
                MessageBox.Show("Цена не является верным числом!");
                proceedLabel.Visible = false;
            }
        }
    }
}
