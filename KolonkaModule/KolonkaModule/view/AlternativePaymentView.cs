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
    public partial class AlternativePaymentView : Form
    {
        ClientData client;
        float litrPrice;
        float requiredPrice;
        string fuel;
        int station;
        float litrs;
        public AlternativePaymentView(ClientData load, float litr, float required, string fuelType, int stationId, float litrAmount)
        {
            client = load;
            litrPrice = litr;
            requiredPrice = required;
            fuel = fuelType;
            station = stationId;
            litrs = litrAmount;
            InitializeComponent();
        }

        private void AlternativePaymentView_Load(object sender, EventArgs e)
        {
            GeneralController.Stylizer(this);
            litrButton.Text = $"Заправить {Round(client.Balance/litrPrice)} литров за накопленные баллы";
            addButton.Text = $"Добавить недостающую сумму {Round(requiredPrice)} рублей с помощью кредитной карты";
        }

        private void cardButton_Click(object sender, EventArgs e)
        {
            List<string> cards = ClientController.GetCards(client.Id);
            if (cards.Count < 1)
            {
                MessageBox.Show("К вашему аккаунту не привязаны банковские карты!");
                return;
            }
            AlternativePaymentView instance = this;
            new Thread(() => {
                bool paymentSuccess = BankController.Pay(cards[0], client, requiredPrice, station, fuel, litrs);
                if (paymentSuccess)
                {
                    instance.Invoke(new Action(() =>
                    {
                        MessageBox.Show("Одобрено. Код транзакции: " + DateTime.Now.ToString("ddMMyyyy-hhmmss"));
                        AZSView.successPayment = true;
                        Close();
                    }));
                }
                else
                {
                    MessageBox.Show("Отклонено. Код транзакции: 00000000-000000");
                }
            }).Start();
        }

        private void litrButton_Click(object sender, EventArgs e)
        {
            AZSView.newLitrs = Round(client.Balance / litrPrice);
            AlternativePaymentView instance = this;
            new Thread(() =>
            {
                bool result = ClientController.TakeBonuses(client.Id, client.Balance);
                if (result)
                {
                    instance.Invoke(new Action(() =>
                    {
                        AZSView.successPayment = true;
                        Close();
                    }));
                }
                else
                {
                    instance.Invoke(new Action(() =>
                    {
                        MessageBox.Show("Не удалось списать бонусы!");
                    }));
                }
            }).Start();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            cardButton_Click(null, null);
        }

        public float Round(float f)
        {
            return (float)Math.Round(f * 100f) / 100f;
        }
    }
}
