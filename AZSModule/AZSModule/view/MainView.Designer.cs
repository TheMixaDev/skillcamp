namespace AZSModule.view
{
    partial class MainView
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
            this.statusLabel = new System.Windows.Forms.Label();
            this.inputBox = new System.Windows.Forms.TextBox();
            this.passButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(119, 9);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(154, 13);
            this.statusLabel.TabIndex = 0;
            this.statusLabel.Text = "Введите идентификатор АЗС";
            // 
            // inputBox
            // 
            this.inputBox.Location = new System.Drawing.Point(104, 25);
            this.inputBox.Name = "inputBox";
            this.inputBox.Size = new System.Drawing.Size(185, 20);
            this.inputBox.TabIndex = 1;
            // 
            // passButton
            // 
            this.passButton.Location = new System.Drawing.Point(146, 51);
            this.passButton.Name = "passButton";
            this.passButton.Size = new System.Drawing.Size(96, 23);
            this.passButton.TabIndex = 2;
            this.passButton.Text = "Продолжить";
            this.passButton.UseVisualStyleBackColor = true;
            this.passButton.Click += new System.EventHandler(this.passButton_Click);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 80);
            this.Controls.Add(this.passButton);
            this.Controls.Add(this.inputBox);
            this.Controls.Add(this.statusLabel);
            this.Name = "MainView";
            this.Text = "Ввод данных";
            this.Load += new System.EventHandler(this.MainView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.TextBox inputBox;
        private System.Windows.Forms.Button passButton;
    }
}