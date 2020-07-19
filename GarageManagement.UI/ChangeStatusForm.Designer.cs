namespace GarageManagement.UI
{
    partial class ChangeStatusForm
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
            this.NewStatus = new System.Windows.Forms.Label();
            this.VehicleStatuses = new System.Windows.Forms.ComboBox();
            this.ButtonOK = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LicensePlateNumberLabel
            // 
            this.LicensePlateNumberLabel.AutoSize = true;
            this.LicensePlateNumberLabel.Location = new System.Drawing.Point(12, 28);
            this.LicensePlateNumberLabel.Name = "LicensePlateNumberLabel";
            this.LicensePlateNumberLabel.Size = new System.Drawing.Size(144, 17);
            this.LicensePlateNumberLabel.TabIndex = 0;
            this.LicensePlateNumberLabel.Text = "License plate number";
            // 
            // LicensePlateNumberTextBox
            // 
            this.LicensePlateNumberTextBox.Location = new System.Drawing.Point(186, 23);
            this.LicensePlateNumberTextBox.Name = "LicensePlateNumberTextBox";
            this.LicensePlateNumberTextBox.Size = new System.Drawing.Size(121, 22);
            this.LicensePlateNumberTextBox.TabIndex = 1;
            // 
            // NewStatus
            // 
            this.NewStatus.AutoSize = true;
            this.NewStatus.Location = new System.Drawing.Point(12, 69);
            this.NewStatus.Name = "NewStatus";
            this.NewStatus.Size = new System.Drawing.Size(77, 17);
            this.NewStatus.TabIndex = 2;
            this.NewStatus.Text = "New status";
            // 
            // VehicleStatuses
            // 
            this.VehicleStatuses.FormattingEnabled = true;
            this.VehicleStatuses.Location = new System.Drawing.Point(186, 62);
            this.VehicleStatuses.Name = "VehicleStatuses";
            this.VehicleStatuses.Size = new System.Drawing.Size(121, 24);
            this.VehicleStatuses.TabIndex = 3;
            // 
            // ButtonOK
            // 
            this.ButtonOK.Location = new System.Drawing.Point(42, 162);
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.Size = new System.Drawing.Size(75, 23);
            this.ButtonOK.TabIndex = 4;
            this.ButtonOK.Text = "OK";
            this.ButtonOK.UseVisualStyleBackColor = true;
            this.ButtonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point(328, 162);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 5;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            // 
            // ChangeStatusForm
            // 
            this.AcceptButton = this.ButtonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ButtonCancel;
            this.ClientSize = new System.Drawing.Size(415, 197);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonOK);
            this.Controls.Add(this.VehicleStatuses);
            this.Controls.Add(this.NewStatus);
            this.Controls.Add(this.LicensePlateNumberTextBox);
            this.Controls.Add(this.LicensePlateNumberLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangeStatusForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Change status";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LicensePlateNumberLabel;
        private System.Windows.Forms.TextBox LicensePlateNumberTextBox;
        private System.Windows.Forms.Label NewStatus;
        private System.Windows.Forms.ComboBox VehicleStatuses;
        private System.Windows.Forms.Button ButtonOK;
        private System.Windows.Forms.Button ButtonCancel;
    }
}