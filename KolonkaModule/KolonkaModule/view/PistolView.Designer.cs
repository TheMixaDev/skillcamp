namespace KolonkaModule.view
{
    partial class PistolView
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
            this.fillButton = new System.Windows.Forms.Button();
            this.returnButton = new System.Windows.Forms.Button();
            this.fuelProgressBar = new System.Windows.Forms.ProgressBar();
            this.autoBox = new System.Windows.Forms.CheckBox();
            this.fuelTypeLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.progressLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // fillButton
            // 
            this.fillButton.Location = new System.Drawing.Point(12, 12);
            this.fillButton.Name = "fillButton";
            this.fillButton.Size = new System.Drawing.Size(130, 23);
            this.fillButton.TabIndex = 0;
            this.fillButton.Text = "Подача топлива";
            this.fillButton.UseVisualStyleBackColor = true;
            this.fillButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.fillButton_MouseDown);
            this.fillButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.fillButton_MouseUp);
            // 
            // returnButton
            // 
            this.returnButton.Location = new System.Drawing.Point(319, 12);
            this.returnButton.Name = "returnButton";
            this.returnButton.Size = new System.Drawing.Size(88, 23);
            this.returnButton.TabIndex = 1;
            this.returnButton.Text = "Вернуть";
            this.returnButton.UseVisualStyleBackColor = true;
            this.returnButton.Click += new System.EventHandler(this.returnButton_Click);
            // 
            // fuelProgressBar
            // 
            this.fuelProgressBar.Location = new System.Drawing.Point(148, 12);
            this.fuelProgressBar.Name = "fuelProgressBar";
            this.fuelProgressBar.Size = new System.Drawing.Size(165, 23);
            this.fuelProgressBar.TabIndex = 2;
            // 
            // autoBox
            // 
            this.autoBox.AutoSize = true;
            this.autoBox.Location = new System.Drawing.Point(12, 41);
            this.autoBox.Name = "autoBox";
            this.autoBox.Size = new System.Drawing.Size(50, 17);
            this.autoBox.TabIndex = 3;
            this.autoBox.Text = "Авто";
            this.autoBox.UseVisualStyleBackColor = true;
            this.autoBox.CheckedChanged += new System.EventHandler(this.autoBox_CheckedChanged);
            // 
            // fuelTypeLabel
            // 
            this.fuelTypeLabel.AutoSize = true;
            this.fuelTypeLabel.Location = new System.Drawing.Point(12, 61);
            this.fuelTypeLabel.Name = "fuelTypeLabel";
            this.fuelTypeLabel.Size = new System.Drawing.Size(35, 13);
            this.fuelTypeLabel.TabIndex = 4;
            this.fuelTypeLabel.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Соединен с колонкой";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Подача топлива разрешена";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Переполнения нет";
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Location = new System.Drawing.Point(209, 38);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(30, 13);
            this.progressLabel.TabIndex = 8;
            this.progressLabel.Text = "0 / 0";
            // 
            // PistolView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 139);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fuelTypeLabel);
            this.Controls.Add(this.autoBox);
            this.Controls.Add(this.fuelProgressBar);
            this.Controls.Add(this.returnButton);
            this.Controls.Add(this.fillButton);
            this.Name = "PistolView";
            this.Text = "Заправочный пистолет";
            this.Load += new System.EventHandler(this.PistolView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button fillButton;
        private System.Windows.Forms.Button returnButton;
        private System.Windows.Forms.ProgressBar fuelProgressBar;
        private System.Windows.Forms.CheckBox autoBox;
        private System.Windows.Forms.Label fuelTypeLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label progressLabel;
    }
}