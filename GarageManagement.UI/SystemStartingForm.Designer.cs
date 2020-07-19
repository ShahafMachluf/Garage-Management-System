namespace GarageManagement.UI
{
    partial class SystemStartingForm
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
            this.ButtonOK = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.selectEnvironmentLabel = new System.Windows.Forms.Label();
            this.EnvironmentSelectionComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // ButtonOK
            // 
            this.ButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ButtonOK.Location = new System.Drawing.Point(45, 109);
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.Size = new System.Drawing.Size(75, 23);
            this.ButtonOK.TabIndex = 0;
            this.ButtonOK.Text = "OK";
            this.ButtonOK.UseVisualStyleBackColor = true;
            this.ButtonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point(214, 109);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 1;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            // 
            // selectEnvironmentLabel
            // 
            this.selectEnvironmentLabel.AutoSize = true;
            this.selectEnvironmentLabel.Location = new System.Drawing.Point(13, 23);
            this.selectEnvironmentLabel.Name = "selectEnvironmentLabel";
            this.selectEnvironmentLabel.Size = new System.Drawing.Size(161, 17);
            this.selectEnvironmentLabel.TabIndex = 2;
            this.selectEnvironmentLabel.Text = "Select your environment";
            // 
            // EnvironmentSelectionComboBox
            // 
            this.EnvironmentSelectionComboBox.FormattingEnabled = true;
            this.EnvironmentSelectionComboBox.Items.AddRange(new object[] {
            "Local",
            "MongoDB"});
            this.EnvironmentSelectionComboBox.Location = new System.Drawing.Point(202, 23);
            this.EnvironmentSelectionComboBox.Name = "EnvironmentSelectionComboBox";
            this.EnvironmentSelectionComboBox.Size = new System.Drawing.Size(121, 24);
            this.EnvironmentSelectionComboBox.TabIndex = 3;
            // 
            // SystemStartingForm
            // 
            this.AcceptButton = this.ButtonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ButtonCancel;
            this.ClientSize = new System.Drawing.Size(368, 152);
            this.Controls.Add(this.EnvironmentSelectionComboBox);
            this.Controls.Add(this.selectEnvironmentLabel);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SystemStartingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Environment select";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonOK;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Label selectEnvironmentLabel;
        private System.Windows.Forms.ComboBox EnvironmentSelectionComboBox;
    }
}