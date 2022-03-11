using KolonkaModule.controller;
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
    public partial class PistolView : Form
    {
        string fuel;
        float currentFuel;
        float fuelLimit;
        PistolView instance;
        System.Timers.Timer timer;
        bool proceed = false;

        string clientCard;
        float totalSum;
        float pricePerLitr;
        int stationId;
        public PistolView(string card, float total, float litrPrice, string fuelType, float limit, int station)
        {
            instance = this;
            fuel = fuelType;
            fuelLimit = limit;

            clientCard = card;
            totalSum = total;
            pricePerLitr = litrPrice;
            stationId = station;

            InitializeComponent();
        }

        private void PistolView_Load(object sender, EventArgs e)
        {
            fuelTypeLabel.Text = "Топливо: "+fuel;
            fuelProgressBar.Maximum = (int)(Round(fuelLimit) * 100);
            progressLabel.Text = "0 / " + Round(fuelLimit);

            timer = new System.Timers.Timer(10);
            timer.Enabled = false;
            timer.AutoReset = true;
            timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (!proceed) return;
            try
            {
                if(currentFuel >= fuelLimit)
                {
                    timer.Enabled = false;
                    instance.Invoke(new Action(() =>
                    {
                        if ((int)(Round(currentFuel) * 100) > fuelProgressBar.Maximum)
                        {
                            currentFuel = fuelLimit;
                        }
                        fuelProgressBar.Value = (int)(Round(currentFuel) * 100);
                        progressLabel.Text = Round(currentFuel) + " / " + Round(fuelLimit);
                        fillButton.Enabled = false;
                    }));
                    return;
                }
                currentFuel += 0.02f;
                instance.Invoke(new Action(() =>
                {
                    if((int)(Round(currentFuel) * 100) > fuelProgressBar.Maximum)
                    {
                        currentFuel = fuelLimit;
                    }
                    fuelProgressBar.Value = (int)(Round(currentFuel) * 100);
                    progressLabel.Text = Round(currentFuel) + " / " + Round(fuelLimit);
                }));
            }
            catch { }
        }

        private void autoBox_CheckedChanged(object sender, EventArgs e)
        {
            proceed = autoBox.Checked;
            timer.Enabled = autoBox.Checked;
            if(currentFuel < fuelLimit)
                fillButton.Enabled = !autoBox.Checked;
        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            returnButton.Enabled = false;
            fillButton.Enabled = false;
            autoBox.Enabled = false;
            autoBox.Checked = false;
            proceed = false;
            if (fuelLimit > currentFuel)
            {
                MessageBox.Show("Сумма за недолитый объем бензина была возвращена вам на ваш счет!");
                new Thread(() =>
                {
                    BankController.Refund(clientCard, totalSum - (fuelLimit - currentFuel) * pricePerLitr);
                }).Start();
            }
            new Thread(() =>
            {
                StationController.AddStory(stationId, fuel, (int)Math.Round(currentFuel), totalSum - (fuelLimit - currentFuel) * pricePerLitr);
                instance.Invoke(new Action(() =>
                {
                    AZSView.closeView = true;
                    MessageBox.Show("Пистол возврщен!");
                    Close();
                }));
            }).Start();
        }

        private void fillButton_MouseDown(object sender, MouseEventArgs e)
        {
            proceed = true;
            timer.Enabled = true;
        }

        private void fillButton_MouseUp(object sender, MouseEventArgs e)
        {
            proceed = false;
            timer.Enabled = false;
        }

        public float Round(float f)
        {
            return (float)Math.Round(f * 100f) / 100f;
        }
    }
}
