using AZSModule.controller;
using AZSModule.model;
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

namespace AZSModule.view
{
    public partial class MainView : Form
    {
        MainView instance;
        public MainView()
        {
            InitializeComponent();
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            instance = this;
            GeneralController.Stylizer(this);
        }

        private void passButton_Click(object sender, EventArgs e)
        {
            try
            {
                statusLabel.Text = "Получение данных...";
                inputBox.Enabled = false;
                int stationId = int.Parse(inputBox.Text);
                new Thread(() =>
                {
                    StationData data = StationController.GetStation(stationId);
                    if(data == null)
                    {
                        instance.Invoke(new Action(() =>
                        {
                            MessageBox.Show("Указанная станция не найдена!");
                            statusLabel.Text = "Введите идентификатор АЗС";
                            inputBox.Enabled = true;
                        }));
                        return;
                    }
                    instance.Invoke(new Action(() =>
                    {
                        statusLabel.Text = "Введите идентификатор АЗС";
                        inputBox.Enabled = true;
                    }));
                    (new AZSView(data)).ShowDialog();
                }).Start();
            } catch
            {
                MessageBox.Show("Указанная станция не найдена!");
                statusLabel.Text = "Введите идентификатор АЗС";
                inputBox.Enabled = true;
            }
        }
    }
}
