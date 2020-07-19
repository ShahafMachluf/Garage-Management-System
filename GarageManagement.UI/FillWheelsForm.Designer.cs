namespace GarageManagement.UI
{
    partial class FillWheelsForm
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
            this.ButtonOK = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.FillAllWheelsLabel = new System.Windows.Forms.Label();
            this.FillAllWheelsCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // LicensePlateNumberLabel
            // 
            this.LicensePlateNumberLabel.AutoSize = true;
            this.LicensePlateNumberLabel.Location = new System.Drawing.Point(29, 33);
            this.LicensePlateNumberLabel.Name = "LicensePlateNumberLabel";
            this.LicensePlateNumberLabel.Size = new System.Drawing.Size(144, 17);
            this.LicensePlateNumberLabel.TabIndex = 0;
            this.LicensePlateNumberLabel.Text = "License plate number";
            // 
            // LicensePlateNumberTextBox
            // 
            this.LicensePlateNumberTextBox.Location = new System.Drawing.Point(231, 30);
            this.LicensePlateNumberTextBox.Name = "LicensePlateNumberTextBox";
            this.LicensePlateNumberTextBox.Size = new System.Drawing.Size(100, 22);
            this.LicensePlateNumberTextBox.TabIndex = 1;
            // 
            // ButtonOK
            // 
            this.ButtonOK.Location = new System.Drawing.Point(51, 146);
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
            this.ButtonCancel.Location = new System.Drawing.Point(231, 146);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 5;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            // 
            // FillAllWheelsLabel
            // 
            this.FillAllWheelsLabel.AutoSize = true;
            this.FillAllWheelsLabel.Location = new System.Drawing.Point(32, 69);
            this.FillAllWheelsLabel.Name = "FillAllWheelsLabel";
            this.FillAllWheelsLabel.Size = new System.Drawing.Size(168, 17);
            this.FillAllWheelsLabel.TabIndex = 2;
            this.FillAllWheelsLabel.Text = "Fill all wheels to maximum";
            // 
            // FillAllWheelsCheckBox
            // 
            this.FillAllWheelsCheckBox.AutoSize = true;
            this.FillAllWheelsCheckBox.Checked = true;
            this.FillAllWheelsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.FillAllWheelsCheckBox.Location = new System.Drawing.Point(231, 69);
            this.FillAllWheelsCheckBox.Name = "FillAllWheelsCheckBox";
            this.FillAllWheelsCheckBox.Size = new System.Drawing.Size(18, 17);
            this.FillAllWheelsCheckBox.TabIndex = 3;
            this.FillAllWheelsCheckBox.UseVisualStyleBackColor = true;
            this.FillAllWheelsCheckBox.CheckedChanged += new System.EventHandler(this.FillAllWheelsCheckBox_CheckedChanged);
            // 
            // FillWheelsForm
            // 
            this.AcceptButton = this.ButtonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ButtonCancel;
            this.ClientSize = new System.Drawing.Size(373, 192);
            this.Controls.Add(this.FillAllWheelsCheckBox);
            this.Controls.Add(this.FillAllWheelsLabel);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonOK);
            this.Controls.Add(this.LicensePlateNumberTextBox);
            this.Controls.Add(this.LicensePlateNumberLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FillWheelsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Fill wheels";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LicensePlateNumberLabel;
        private System.Windows.Forms.TextBox LicensePlateNumberTextBox;
        private System.Windows.Forms.Button ButtonOK;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Label FillAllWheelsLabel;
        private System.Windows.Forms.CheckBox FillAllWheelsCheckBox;
    }
}