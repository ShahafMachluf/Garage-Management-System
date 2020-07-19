namespace GarageManagement.UI
{
    partial class ChargeBatteryForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.NumberOfMinutesToAddTextBox = new System.Windows.Forms.TextBox();
            this.ButtonOK = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LicensePlateNumberLabel
            // 
            this.LicensePlateNumberLabel.AutoSize = true;
            this.LicensePlateNumberLabel.Location = new System.Drawing.Point(12, 33);
            this.LicensePlateNumberLabel.Name = "LicensePlateNumberLabel";
            this.LicensePlateNumberLabel.Size = new System.Drawing.Size(144, 17);
            this.LicensePlateNumberLabel.TabIndex = 2;
            this.LicensePlateNumberLabel.Text = "License plate number";
            // 
            // LicensePlateNumberTextBox
            // 
            this.LicensePlateNumberTextBox.Location = new System.Drawing.Point(205, 28);
            this.LicensePlateNumberTextBox.Name = "LicensePlateNumberTextBox";
            this.LicensePlateNumberTextBox.Size = new System.Drawing.Size(100, 22);
            this.LicensePlateNumberTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Number of minutes to add";
            // 
            // NumberOfMinutesToAddTextBox
            // 
            this.NumberOfMinutesToAddTextBox.Location = new System.Drawing.Point(205, 79);
            this.NumberOfMinutesToAddTextBox.Name = "NumberOfMinutesToAddTextBox";
            this.NumberOfMinutesToAddTextBox.Size = new System.Drawing.Size(100, 22);
            this.NumberOfMinutesToAddTextBox.TabIndex = 2;
            // 
            // ButtonOK
            // 
            this.ButtonOK.Location = new System.Drawing.Point(36, 182);
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.Size = new System.Drawing.Size(75, 23);
            this.ButtonOK.TabIndex = 3;
            this.ButtonOK.Text = "OK";
            this.ButtonOK.UseVisualStyleBackColor = true;
            this.ButtonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point(230, 182);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 4;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            // 
            // ChargeBatteryForm
            // 
            this.AcceptButton = this.ButtonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ButtonCancel;
            this.ClientSize = new System.Drawing.Size(385, 242);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonOK);
            this.Controls.Add(this.NumberOfMinutesToAddTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LicensePlateNumberTextBox);
            this.Controls.Add(this.LicensePlateNumberLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChargeBatteryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Charge battery";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LicensePlateNumberLabel;
        private System.Windows.Forms.TextBox LicensePlateNumberTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NumberOfMinutesToAddTextBox;
        private System.Windows.Forms.Button ButtonOK;
        private System.Windows.Forms.Button ButtonCancel;
    }
}