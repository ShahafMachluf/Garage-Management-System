namespace GarageManagement.UI
{
    partial class VehicleFullDetailesForm
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
            this.ButtonShow = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LicensePlateNumberLabel
            // 
            this.LicensePlateNumberLabel.AutoSize = true;
            this.LicensePlateNumberLabel.Location = new System.Drawing.Point(12, 26);
            this.LicensePlateNumberLabel.Name = "LicensePlateNumberLabel";
            this.LicensePlateNumberLabel.Size = new System.Drawing.Size(144, 17);
            this.LicensePlateNumberLabel.TabIndex = 0;
            this.LicensePlateNumberLabel.Text = "License plate number";
            // 
            // LicensePlateNumberTextBox
            // 
            this.LicensePlateNumberTextBox.Location = new System.Drawing.Point(183, 26);
            this.LicensePlateNumberTextBox.Name = "LicensePlateNumberTextBox";
            this.LicensePlateNumberTextBox.Size = new System.Drawing.Size(116, 22);
            this.LicensePlateNumberTextBox.TabIndex = 1;
            // 
            // ButtonShow
            // 
            this.ButtonShow.Location = new System.Drawing.Point(334, 25);
            this.ButtonShow.Name = "ButtonShow";
            this.ButtonShow.Size = new System.Drawing.Size(114, 23);
            this.ButtonShow.TabIndex = 2;
            this.ButtonShow.Text = "Show detailes";
            this.ButtonShow.UseVisualStyleBackColor = true;
            this.ButtonShow.Click += new System.EventHandler(this.ButtonShowDetailes_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point(183, 120);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 3;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            // 
            // VehicleFullDetailesForm
            // 
            this.AcceptButton = this.ButtonShow;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ButtonCancel;
            this.ClientSize = new System.Drawing.Size(479, 153);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonShow);
            this.Controls.Add(this.LicensePlateNumberTextBox);
            this.Controls.Add(this.LicensePlateNumberLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VehicleFullDetailesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Vehicle full detailes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LicensePlateNumberLabel;
        private System.Windows.Forms.TextBox LicensePlateNumberTextBox;
        private System.Windows.Forms.Button ButtonShow;
        private System.Windows.Forms.Button ButtonCancel;
    }
}