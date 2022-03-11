namespace KolonkaModule.view
{
    partial class AlternativePaymentView
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
            this.cardButton = new System.Windows.Forms.Button();
            this.litrButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Недостаточно средств на накопительной карте";
            // 
            // cardButton
            // 
            this.cardButton.Location = new System.Drawing.Point(15, 25);
            this.cardButton.Name = "cardButton";
            this.cardButton.Size = new System.Drawing.Size(246, 30);
            this.cardButton.TabIndex = 1;
            this.cardButton.Text = "Оплатить банковской картой";
            this.cardButton.UseVisualStyleBackColor = true;
            this.cardButton.Click += new System.EventHandler(this.cardButton_Click);
            // 
            // litrButton
            // 
            this.litrButton.Location = new System.Drawing.Point(15, 61);
            this.litrButton.Name = "litrButton";
            this.litrButton.Size = new System.Drawing.Size(246, 39);
            this.litrButton.TabIndex = 2;
            this.litrButton.Text = "Заправить N литров за накопленные баллы";
            this.litrButton.UseVisualStyleBackColor = true;
            this.litrButton.Click += new System.EventHandler(this.litrButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(15, 106);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(246, 39);
            this.addButton.TabIndex = 3;
            this.addButton.Text = "Добавить недостающую сумму Х рублей с помощью кредитной карты";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // AlternativePaymentView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 157);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.litrButton);
            this.Controls.Add(this.cardButton);
            this.Controls.Add(this.label1);
            this.Name = "AlternativePaymentView";
            this.Text = "Выбор оплаты";
            this.Load += new System.EventHandler(this.AlternativePaymentView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cardButton;
        private System.Windows.Forms.Button litrButton;
        private System.Windows.Forms.Button addButton;
    }
}