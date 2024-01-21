using System.Windows.Forms;

namespace MaterialShipmentApp
{
    partial class MaterialShipmentForm
    {

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            { 
                this.dealTimeDateTimePicker = new System.Windows.Forms.DateTimePicker();
                this.materialComboBox = new System.Windows.Forms.ComboBox();
                this.numOfMaterialsTextBox = new System.Windows.Forms.TextBox();
                this.customerNameTextBox = new System.Windows.Forms.TextBox();
                this.totalCostLabel = new System.Windows.Forms.Label();
                this.sellButton = new System.Windows.Forms.Button();
                this.dealTimeLabel = new System.Windows.Forms.Label();
                this.materialLabel = new System.Windows.Forms.Label();
                this.numOfMaterialsLabel = new System.Windows.Forms.Label();
                this.customerNameLabel = new System.Windows.Forms.Label();
                this.SuspendLayout();
                // 
                // dealTimeDateTimePicker
                // 
                this.dealTimeDateTimePicker.Location = new System.Drawing.Point(12, 30);
                this.dealTimeDateTimePicker.Name = "dealTimeDateTimePicker";
                this.dealTimeDateTimePicker.Size = new System.Drawing.Size(360, 20);
                this.dealTimeDateTimePicker.TabIndex = 0;

                // 
                // materialComboBox
                // 
                this.materialComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                this.materialComboBox.FormattingEnabled = true;
                this.materialComboBox.Location = new System.Drawing.Point(12, 70);
                this.materialComboBox.Name = "materialComboBox";
                this.materialComboBox.Size = new System.Drawing.Size(360, 21);
                this.materialComboBox.TabIndex = 1;

                // 
                // numOfMaterialsTextBox
                // 
                this.numOfMaterialsTextBox.Location = new System.Drawing.Point(12, 110);
                this.numOfMaterialsTextBox.Name = "numOfMaterialsTextBox";
                this.numOfMaterialsTextBox.Size = new System.Drawing.Size(360, 20);
                this.numOfMaterialsTextBox.TabIndex = 2;

                // 
                // customerNameTextBox
                // 
                this.customerNameTextBox.Location = new System.Drawing.Point(12, 150);
                this.customerNameTextBox.Name = "customerNameTextBox";
                this.customerNameTextBox.Size = new System.Drawing.Size(360, 20);
                this.customerNameTextBox.TabIndex = 3;

                // 
                // totalCostLabel
                // 
                this.totalCostLabel.AutoSize = true;
                this.totalCostLabel.Location = new System.Drawing.Point(12, 190);
                this.totalCostLabel.Name = "totalCostLabel";
                this.totalCostLabel.Size = new System.Drawing.Size(0, 13);
                this.totalCostLabel.TabIndex = 4;

                // 
                // sellButton
                // 
                this.sellButton.Location = new System.Drawing.Point(12, 230);
                this.sellButton.Name = "sellButton";
                this.sellButton.Size = new System.Drawing.Size(360, 40);
                this.sellButton.TabIndex = 5;
                this.sellButton.Text = "Продать";
                this.sellButton.UseVisualStyleBackColor = true;
                this.sellButton.Click += new System.EventHandler(this.sellButton_Click);

                // 
                // dealTimeLabel
                // 
                this.dealTimeLabel.AutoSize = true;
                this.dealTimeLabel.Location = new System.Drawing.Point(12, 10);
                this.dealTimeLabel.Name = "dealTimeLabel";
                this.dealTimeLabel.Size = new System.Drawing.Size(92, 13);
                this.dealTimeLabel.TabIndex = 6;
                this.dealTimeLabel.Text = "Дата сделки:";

                // 
                // materialLabel
                // 
                this.materialLabel.AutoSize = true;
                this.materialLabel.Location = new System.Drawing.Point(12, 50);
                this.materialLabel.Name = "materialLabel";
                this.materialLabel.Size = new System.Drawing.Size(68, 13);
                this.materialLabel.TabIndex = 7;
                this.materialLabel.Text = "Материал:";

                // 
                // numOfMaterialsLabel
                // 
                this.numOfMaterialsLabel.AutoSize = true;
                this.numOfMaterialsLabel.Location = new System.Drawing.Point(12, 90);
                this.numOfMaterialsLabel.Name = "numOfMaterialsLabel";
                this.numOfMaterialsLabel.Size = new System.Drawing.Size(118, 13);
                this.numOfMaterialsLabel.TabIndex = 8;
                this.numOfMaterialsLabel.Text = "Количество материала:";
                // 
                // customerNameLabel
                // 
                this.customerNameLabel.AutoSize = true;
                this.customerNameLabel.Location = new System.Drawing.Point(12, 130);
                this.customerNameLabel.Name = "customerNameLabel";
                this.customerNameLabel.Size = new System.Drawing.Size(88, 13);
                this.customerNameLabel.TabIndex = 9;
                this.customerNameLabel.Text = "Имя покупателя:";
                // 
                // MaterialShipmentForm
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(400, 270);
                this.Controls.Add(this.customerNameLabel);
                this.Controls.Add(this.numOfMaterialsLabel);
                this.Controls.Add(this.materialLabel);
                this.Controls.Add(this.dealTimeLabel);
                this.Controls.Add(this.sellButton);
                this.Controls.Add(this.totalCostLabel);
                this.Controls.Add(this.customerNameTextBox);
                this.Controls.Add(this.numOfMaterialsTextBox);
                this.Controls.Add(this.materialComboBox);
                this.Controls.Add(this.dealTimeDateTimePicker);
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                this.MaximizeBox = false;
                this.Name = "MaterialShipmentForm";
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                this.Text = "Отгрузка материалов";
                this.ResumeLayout(false);
                this.PerformLayout();
            }
        }

        private System.Windows.Forms.DateTimePicker dealTimeDateTimePicker;
        private System.Windows.Forms.ComboBox materialComboBox;
        private System.Windows.Forms.TextBox numOfMaterialsTextBox;
        private System.Windows.Forms.TextBox customerNameTextBox;
        private System.Windows.Forms.Label totalCostLabel;
        private System.Windows.Forms.Button sellButton;
        private System.Windows.Forms.Label dealTimeLabel;
        private System.Windows.Forms.Label materialLabel;
        private System.Windows.Forms.Label numOfMaterialsLabel;
        private System.Windows.Forms.Label customerNameLabel;
    }
}