namespace KolonkaModule.view
{
    partial class AZSView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.fuelBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.modeBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buyBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.vBox = new System.Windows.Forms.TextBox();
            this.priceBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.proceedButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.clientBox = new System.Windows.Forms.ComboBox();
            this.proceedLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Топливо:";
            // 
            // fuelBox
            // 
            this.fuelBox.FormattingEnabled = true;
            this.fuelBox.Location = new System.Drawing.Point(106, 35);
            this.fuelBox.Name = "fuelBox";
            this.fuelBox.Size = new System.Drawing.Size(257, 21);
            this.fuelBox.TabIndex = 1;
            this.fuelBox.SelectedIndexChanged += new System.EventHandler(this.fuelBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Режим заправки:";
            // 
            // modeBox
            // 
            this.modeBox.FormattingEnabled = true;
            this.modeBox.Items.AddRange(new object[] {
            "Фиксированный объем",
            "Фиксированная цена",
            "До полного бака с ограничением по объему"});
            this.modeBox.Location = new System.Drawing.Point(106, 63);
            this.modeBox.Name = "modeBox";
            this.modeBox.Size = new System.Drawing.Size(257, 21);
            this.modeBox.TabIndex = 3;
            this.modeBox.SelectedIndexChanged += new System.EventHandler(this.modeBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Способ оплаты:";
            // 
            // buyBox
            // 
            this.buyBox.FormattingEnabled = true;
            this.buyBox.Items.AddRange(new object[] {
            "Банковской картой",
            "Накопительной картой"});
            this.buyBox.Location = new System.Drawing.Point(106, 88);
            this.buyBox.Name = "buyBox";
            this.buyBox.Size = new System.Drawing.Size(257, 21);
            this.buyBox.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(87, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Объем:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(97, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Цена:";
            // 
            // vBox
            // 
            this.vBox.Location = new System.Drawing.Point(138, 123);
            this.vBox.Name = "vBox";
            this.vBox.Size = new System.Drawing.Size(42, 20);
            this.vBox.TabIndex = 8;
            this.vBox.Text = "10";
            this.vBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // priceBox
            // 
            this.priceBox.Location = new System.Drawing.Point(139, 148);
            this.priceBox.Name = "priceBox";
            this.priceBox.Size = new System.Drawing.Size(70, 20);
            this.priceBox.TabIndex = 9;
            this.priceBox.Text = "10";
            this.priceBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(186, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "литров";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(215, 151);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "рублей";
            // 
            // proceedButton
            // 
            this.proceedButton.Location = new System.Drawing.Point(138, 174);
            this.proceedButton.Name = "proceedButton";
            this.proceedButton.Size = new System.Drawing.Size(103, 23);
            this.proceedButton.TabIndex = 12;
            this.proceedButton.Text = "Оплатить";
            this.proceedButton.UseVisualStyleBackColor = true;
            this.proceedButton.Click += new System.EventHandler(this.proceedButton_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(54, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Клиент:";
            // 
            // clientBox
            // 
            this.clientBox.FormattingEnabled = true;
            this.clientBox.Location = new System.Drawing.Point(106, 6);
            this.clientBox.Name = "clientBox";
            this.clientBox.Size = new System.Drawing.Size(257, 21);
            this.clientBox.TabIndex = 14;
            // 
            // proceedLabel
            // 
            this.proceedLabel.AutoSize = true;
            this.proceedLabel.Location = new System.Drawing.Point(135, 200);
            this.proceedLabel.Name = "proceedLabel";
            this.proceedLabel.Size = new System.Drawing.Size(114, 13);
            this.proceedLabel.TabIndex = 15;
            this.proceedLabel.Text = "Происходит оплата...";
            // 
            // AZSView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 214);
            this.Controls.Add(this.proceedLabel);
            this.Controls.Add(this.clientBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.proceedButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.priceBox);
            this.Controls.Add(this.vBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buyBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.modeBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.fuelBox);
            this.Controls.Add(this.label1);
            this.Name = "AZSView";
            this.Text = "AZSView";
            this.Load += new System.EventHandler(this.AZSView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox fuelBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox modeBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox buyBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox vBox;
        private System.Windows.Forms.TextBox priceBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button proceedButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox clientBox;
        private System.Windows.Forms.Label proceedLabel;
    }
}