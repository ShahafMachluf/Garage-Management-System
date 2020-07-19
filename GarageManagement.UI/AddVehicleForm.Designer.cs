namespace GarageManagement.UI
{
    partial class AddVehicleForm
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
            this.VehicleTypeLabel = new System.Windows.Forms.Label();
            this.LicensePlateNumberText = new System.Windows.Forms.TextBox();
            this.BottonOK = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.VehicleTypeComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // LicensePlateNumberLabel
            // 
            this.LicensePlateNumberLabel.AutoSize = true;
            this.LicensePlateNumberLabel.Location = new System.Drawing.Point(12, 23);
            this.LicensePlateNumberLabel.Name = "LicensePlateNumberLabel";
            this.LicensePlateNumberLabel.Size = new System.Drawing.Size(144, 17);
            this.LicensePlateNumberLabel.TabIndex = 0;
            this.LicensePlateNumberLabel.Text = "License plate number";
            // 
            // VehicleTypeLabel
            // 
            this.VehicleTypeLabel.AutoSize = true;
            this.VehicleTypeLabel.Location = new System.Drawing.Point(12, 60);
            this.VehicleTypeLabel.Name = "VehicleTypeLabel";
            this.VehicleTypeLabel.Size = new System.Drawing.Size(85, 17);
            this.VehicleTypeLabel.TabIndex = 1;
            this.VehicleTypeLabel.Text = "Vehicle type";
            // 
            // LicensePlateNumberText
            // 
            this.LicensePlateNumberText.Location = new System.Drawing.Point(244, 18);
            this.LicensePlateNumberText.Name = "LicensePlateNumberText";
            this.LicensePlateNumberText.Size = new System.Drawing.Size(150, 22);
            this.LicensePlateNumberText.TabIndex = 2;
            // 
            // BottonOK
            // 
            this.BottonOK.Location = new System.Drawing.Point(98, 136);
            this.BottonOK.Name = "BottonOK";
            this.BottonOK.Size = new System.Drawing.Size(75, 23);
            this.BottonOK.TabIndex = 4;
            this.BottonOK.Text = "OK";
            this.BottonOK.UseVisualStyleBackColor = true;
            this.BottonOK.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point(271, 136);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 5;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            // 
            // VehicleTypeComboBox
            // 
            this.VehicleTypeComboBox.FormattingEnabled = true;
            this.VehicleTypeComboBox.Location = new System.Drawing.Point(244, 60);
            this.VehicleTypeComboBox.Name = "VehicleTypeComboBox";
            this.VehicleTypeComboBox.Size = new System.Drawing.Size(150, 24);
            this.VehicleTypeComboBox.TabIndex = 3;
            // 
            // AddVehicleForm
            // 
            this.AcceptButton = this.BottonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ButtonCancel;
            this.ClientSize = new System.Drawing.Size(487, 185);
            this.Controls.Add(this.VehicleTypeComboBox);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.BottonOK);
            this.Controls.Add(this.LicensePlateNumberText);
            this.Controls.Add(this.VehicleTypeLabel);
            this.Controls.Add(this.LicensePlateNumberLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AddVehicleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add new vehicle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LicensePlateNumberLabel;
        private System.Windows.Forms.Label VehicleTypeLabel;
        private System.Windows.Forms.TextBox LicensePlateNumberText;
        private System.Windows.Forms.Button BottonOK;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.ComboBox VehicleTypeComboBox;
    }
}