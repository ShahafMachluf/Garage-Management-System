namespace GarageManagement.UI
{
    partial class AddFuelForm
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
            this.LicensePlateNumberLabel = new System.Windows.Forms.Label();
            this.LicensePlateNumberTextBox = new System.Windows.Forms.TextBox();
            this.AmountOfFuelTextBox = new System.Windows.Forms.TextBox();
            this.AmountOfFuelLabel = new System.Windows.Forms.Label();
            this.ButtonOK = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.LabelFuelType = new System.Windows.Forms.Label();
            this.ComboBoxFuelType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // LicensePlateNumberLabel
            // 
            this.LicensePlateNumberLabel.AutoSize = true;
            this.LicensePlateNumberLabel.Location = new System.Drawing.Point(21, 29);
            this.LicensePlateNumberLabel.Name = "LicensePlateNumberLabel";
            this.LicensePlateNumberLabel.Size = new System.Drawing.Size(144, 17);
            this.LicensePlateNumberLabel.TabIndex = 1;
            this.LicensePlateNumberLabel.Text = "License plate number";
            // 
            // LicensePlateNumberTextBox
            // 
            this.LicensePlateNumberTextBox.Location = new System.Drawing.Point(222, 29);
            this.LicensePlateNumberTextBox.Name = "LicensePlateNumberTextBox";
            this.LicensePlateNumberTextBox.Size = new System.Drawing.Size(100, 22);
            this.LicensePlateNumberTextBox.TabIndex = 2;
            // 
            // AmountOfFuelTextBox
            // 
            this.AmountOfFuelTextBox.Location = new System.Drawing.Point(222, 81);
            this.AmountOfFuelTextBox.Name = "AmountOfFuelTextBox";
            this.AmountOfFuelTextBox.Size = new System.Drawing.Size(100, 22);
            this.AmountOfFuelTextBox.TabIndex = 3;
            // 
            // AmountOfFuelLabel
            // 
            this.AmountOfFuelLabel.AutoSize = true;
            this.AmountOfFuelLabel.Location = new System.Drawing.Point(24, 81);
            this.AmountOfFuelLabel.Name = "AmountOfFuelLabel";
            this.AmountOfFuelLabel.Size = new System.Drawing.Size(99, 17);
            this.AmountOfFuelLabel.TabIndex = 4;
            this.AmountOfFuelLabel.Text = "Amount of fuel";
            // 
            // ButtonOK
            // 
            this.ButtonOK.Location = new System.Drawing.Point(48, 200);
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.Size = new System.Drawing.Size(75, 23);
            this.ButtonOK.TabIndex = 5;
            this.ButtonOK.Text = "OK";
            this.ButtonOK.UseVisualStyleBackColor = true;
            this.ButtonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point(247, 200);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 6;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            // 
            // LabelFuelType
            // 
            this.LabelFuelType.AutoSize = true;
            this.LabelFuelType.Location = new System.Drawing.Point(24, 125);
            this.LabelFuelType.Name = "LabelFuelType";
            this.LabelFuelType.Size = new System.Drawing.Size(66, 17);
            this.LabelFuelType.TabIndex = 7;
            this.LabelFuelType.Text = "Fuel type";
            // 
            // ComboBoxFuelType
            // 
            this.ComboBoxFuelType.FormattingEnabled = true;
            this.ComboBoxFuelType.Location = new System.Drawing.Point(222, 125);
            this.ComboBoxFuelType.Name = "ComboBoxFuelType";
            this.ComboBoxFuelType.Size = new System.Drawing.Size(100, 24);
            this.ComboBoxFuelType.TabIndex = 8;
            // 
            // AddFuelForm
            // 
            this.AcceptButton = this.ButtonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ButtonCancel;
            this.ClientSize = new System.Drawing.Size(370, 252);
            this.Controls.Add(this.ComboBoxFuelType);
            this.Controls.Add(this.LabelFuelType);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonOK);
            this.Controls.Add(this.AmountOfFuelLabel);
            this.Controls.Add(this.AmountOfFuelTextBox);
            this.Controls.Add(this.LicensePlateNumberTextBox);
            this.Controls.Add(this.LicensePlateNumberLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddFuelForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add fuel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LicensePlateNumberLabel;
        private System.Windows.Forms.TextBox LicensePlateNumberTextBox;
        private System.Windows.Forms.TextBox AmountOfFuelTextBox;
        private System.Windows.Forms.Label AmountOfFuelLabel;
        private System.Windows.Forms.Button ButtonOK;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Label LabelFuelType;
        private System.Windows.Forms.ComboBox ComboBoxFuelType;
    }
}