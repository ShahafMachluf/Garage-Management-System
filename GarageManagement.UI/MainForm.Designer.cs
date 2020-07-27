namespace GarageManagement.UI
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.AddNewVehicle = new System.Windows.Forms.Button();
            this.ChangeVehicleStatus = new System.Windows.Forms.Button();
            this.AddFuel = new System.Windows.Forms.Button();
            this.ChargeBattery = new System.Windows.Forms.Button();
            this.FillVehicleWheels = new System.Windows.Forms.Button();
            this.ShowAllLicensePlates = new System.Windows.Forms.Button();
            this.ShowVehiclesInSpesificStatus = new System.Windows.Forms.Button();
            this.ShowVehicleFullDetailes = new System.Windows.Forms.Button();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.AboutMenuItem = new System.Windows.Forms.MenuItem();
            this.selectedEnvironmentLabel = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AddNewVehicle
            // 
            this.AddNewVehicle.Image = ((System.Drawing.Image)(resources.GetObject("AddNewVehicle.Image")));
            this.AddNewVehicle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AddNewVehicle.Location = new System.Drawing.Point(0, 12);
            this.AddNewVehicle.Name = "AddNewVehicle";
            this.AddNewVehicle.Size = new System.Drawing.Size(231, 44);
            this.AddNewVehicle.TabIndex = 0;
            this.AddNewVehicle.Text = "Add new vehicle";
            this.AddNewVehicle.UseVisualStyleBackColor = true;
            this.AddNewVehicle.Click += new System.EventHandler(this.AddNewVehicle_Click);
            // 
            // ChangeVehicleStatus
            // 
            this.ChangeVehicleStatus.Image = ((System.Drawing.Image)(resources.GetObject("ChangeVehicleStatus.Image")));
            this.ChangeVehicleStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ChangeVehicleStatus.Location = new System.Drawing.Point(0, 80);
            this.ChangeVehicleStatus.Name = "ChangeVehicleStatus";
            this.ChangeVehicleStatus.Size = new System.Drawing.Size(231, 44);
            this.ChangeVehicleStatus.TabIndex = 1;
            this.ChangeVehicleStatus.Text = "   Change vehicle status";
            this.ChangeVehicleStatus.UseVisualStyleBackColor = true;
            this.ChangeVehicleStatus.Click += new System.EventHandler(this.ChangeVehicleStatus_Click);
            // 
            // AddFuel
            // 
            this.AddFuel.Image = ((System.Drawing.Image)(resources.GetObject("AddFuel.Image")));
            this.AddFuel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AddFuel.Location = new System.Drawing.Point(521, 12);
            this.AddFuel.Name = "AddFuel";
            this.AddFuel.Size = new System.Drawing.Size(231, 44);
            this.AddFuel.TabIndex = 6;
            this.AddFuel.Text = "Add fuel to vehicle";
            this.AddFuel.UseVisualStyleBackColor = true;
            this.AddFuel.Click += new System.EventHandler(this.AddFuel_Click);
            // 
            // ChargeBattery
            // 
            this.ChargeBattery.Image = ((System.Drawing.Image)(resources.GetObject("ChargeBattery.Image")));
            this.ChargeBattery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ChargeBattery.Location = new System.Drawing.Point(521, 80);
            this.ChargeBattery.Name = "ChargeBattery";
            this.ChargeBattery.Size = new System.Drawing.Size(231, 44);
            this.ChargeBattery.TabIndex = 7;
            this.ChargeBattery.Text = "     Charge vehicle battery";
            this.ChargeBattery.UseVisualStyleBackColor = true;
            this.ChargeBattery.Click += new System.EventHandler(this.ChargeBattery_Click);
            // 
            // FillVehicleWheels
            // 
            this.FillVehicleWheels.Image = ((System.Drawing.Image)(resources.GetObject("FillVehicleWheels.Image")));
            this.FillVehicleWheels.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FillVehicleWheels.Location = new System.Drawing.Point(0, 140);
            this.FillVehicleWheels.Name = "FillVehicleWheels";
            this.FillVehicleWheels.Size = new System.Drawing.Size(231, 44);
            this.FillVehicleWheels.TabIndex = 2;
            this.FillVehicleWheels.Text = "Fill vehicle wheels";
            this.FillVehicleWheels.UseVisualStyleBackColor = true;
            this.FillVehicleWheels.Click += new System.EventHandler(this.FillVehicleWheels_Click);
            // 
            // ShowAllLicensePlates
            // 
            this.ShowAllLicensePlates.Image = ((System.Drawing.Image)(resources.GetObject("ShowAllLicensePlates.Image")));
            this.ShowAllLicensePlates.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ShowAllLicensePlates.Location = new System.Drawing.Point(255, 12);
            this.ShowAllLicensePlates.Name = "ShowAllLicensePlates";
            this.ShowAllLicensePlates.Size = new System.Drawing.Size(231, 44);
            this.ShowAllLicensePlates.TabIndex = 3;
            this.ShowAllLicensePlates.Text = "Show all vehicles";
            this.ShowAllLicensePlates.UseVisualStyleBackColor = true;
            this.ShowAllLicensePlates.Click += new System.EventHandler(this.ShowAllLicensePlates_Click);
            // 
            // ShowVehiclesInSpesificStatus
            // 
            this.ShowVehiclesInSpesificStatus.AutoSize = true;
            this.ShowVehiclesInSpesificStatus.Image = ((System.Drawing.Image)(resources.GetObject("ShowVehiclesInSpesificStatus.Image")));
            this.ShowVehiclesInSpesificStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ShowVehiclesInSpesificStatus.Location = new System.Drawing.Point(255, 80);
            this.ShowVehiclesInSpesificStatus.Name = "ShowVehiclesInSpesificStatus";
            this.ShowVehiclesInSpesificStatus.Size = new System.Drawing.Size(231, 44);
            this.ShowVehiclesInSpesificStatus.TabIndex = 4;
            this.ShowVehiclesInSpesificStatus.Text = "       Show vehicles by status";
            this.ShowVehiclesInSpesificStatus.UseVisualStyleBackColor = true;
            this.ShowVehiclesInSpesificStatus.Click += new System.EventHandler(this.ShowVehiclesInSpesificStatus_Click);
            // 
            // ShowVehicleFullDetailes
            // 
            this.ShowVehicleFullDetailes.AutoSize = true;
            this.ShowVehicleFullDetailes.Image = ((System.Drawing.Image)(resources.GetObject("ShowVehicleFullDetailes.Image")));
            this.ShowVehicleFullDetailes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ShowVehicleFullDetailes.Location = new System.Drawing.Point(255, 140);
            this.ShowVehicleFullDetailes.Name = "ShowVehicleFullDetailes";
            this.ShowVehicleFullDetailes.Size = new System.Drawing.Size(231, 44);
            this.ShowVehicleFullDetailes.TabIndex = 5;
            this.ShowVehicleFullDetailes.Text = "          Show vehicle full detailes";
            this.ShowVehicleFullDetailes.UseVisualStyleBackColor = true;
            this.ShowVehicleFullDetailes.Click += new System.EventHandler(this.ShowVehicleFullDetailes_Click);
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.AboutMenuItem});
            // 
            // AboutMenuItem
            // 
            this.AboutMenuItem.Index = 0;
            this.AboutMenuItem.Text = "About";
            this.AboutMenuItem.Click += new System.EventHandler(this.AboutMenuItem_Click);
            // 
            // selectedEnvironmentLabel
            // 
            this.selectedEnvironmentLabel.AutoSize = true;
            this.selectedEnvironmentLabel.Location = new System.Drawing.Point(22, 229);
            this.selectedEnvironmentLabel.Name = "selectedEnvironmentLabel";
            this.selectedEnvironmentLabel.Size = new System.Drawing.Size(95, 17);
            this.selectedEnvironmentLabel.TabIndex = 8;
            this.selectedEnvironmentLabel.Text = "Environment: ";
            // 
            // ExitButton
            // 
            this.ExitButton.Image = ((System.Drawing.Image)(resources.GetObject("ExitButton.Image")));
            this.ExitButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ExitButton.Location = new System.Drawing.Point(521, 140);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(231, 44);
            this.ExitButton.TabIndex = 8;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(789, 260);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.selectedEnvironmentLabel);
            this.Controls.Add(this.ShowVehicleFullDetailes);
            this.Controls.Add(this.ShowVehiclesInSpesificStatus);
            this.Controls.Add(this.ShowAllLicensePlates);
            this.Controls.Add(this.FillVehicleWheels);
            this.Controls.Add(this.ChargeBattery);
            this.Controls.Add(this.AddFuel);
            this.Controls.Add(this.ChangeVehicleStatus);
            this.Controls.Add(this.AddNewVehicle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Garage manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddNewVehicle;
        private System.Windows.Forms.Button ChangeVehicleStatus;
        private System.Windows.Forms.Button AddFuel;
        private System.Windows.Forms.Button ChargeBattery;
        private System.Windows.Forms.Button FillVehicleWheels;
        private System.Windows.Forms.Button ShowAllLicensePlates;
        private System.Windows.Forms.Button ShowVehiclesInSpesificStatus;
        private System.Windows.Forms.Button ShowVehicleFullDetailes;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem AboutMenuItem;
        private System.Windows.Forms.Label selectedEnvironmentLabel;
        private System.Windows.Forms.Button ExitButton;
    }
}