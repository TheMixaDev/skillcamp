namespace AZSModule.view
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
            this.addressBox = new System.Windows.Forms.TextBox();
            this.fuelGrid = new System.Windows.Forms.DataGridView();
            this.Fuel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Left = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saveButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fuelGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Адрес:";
            // 
            // addressBox
            // 
            this.addressBox.Location = new System.Drawing.Point(59, 6);
            this.addressBox.Name = "addressBox";
            this.addressBox.Size = new System.Drawing.Size(315, 20);
            this.addressBox.TabIndex = 1;
            // 
            // fuelGrid
            // 
            this.fuelGrid.AllowUserToAddRows = false;
            this.fuelGrid.AllowUserToDeleteRows = false;
            this.fuelGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fuelGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Fuel,
            this.Price,
            this.Left});
            this.fuelGrid.Location = new System.Drawing.Point(15, 32);
            this.fuelGrid.Name = "fuelGrid";
            this.fuelGrid.Size = new System.Drawing.Size(359, 150);
            this.fuelGrid.TabIndex = 2;
            // 
            // Fuel
            // 
            this.Fuel.HeaderText = "Топливо";
            this.Fuel.Name = "Fuel";
            this.Fuel.ReadOnly = true;
            // 
            // Price
            // 
            this.Price.HeaderText = "Цена";
            this.Price.Name = "Price";
            // 
            // Left
            // 
            this.Left.HeaderText = "Остаток";
            this.Left.Name = "Left";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(15, 188);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(150, 23);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Сохранить изменения";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(283, 188);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(91, 23);
            this.closeButton.TabIndex = 4;
            this.closeButton.Text = "Закрыть";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // AZSView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 220);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.fuelGrid);
            this.Controls.Add(this.addressBox);
            this.Controls.Add(this.label1);
            this.Name = "AZSView";
            this.Text = "AZSView";
            this.Load += new System.EventHandler(this.AZSView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fuelGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox addressBox;
        private System.Windows.Forms.DataGridView fuelGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fuel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Left;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button closeButton;
    }
}