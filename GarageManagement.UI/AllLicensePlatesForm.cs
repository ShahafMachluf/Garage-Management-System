using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GarageManagement.Logic;

namespace GarageManagement.UI
{
    public partial class AllLicensePlatesForm : Form
    {
        private readonly GarageManager r_GarageManagerReference;

        public AllLicensePlatesForm(GarageManager i_GarageManager)
        {
            r_GarageManagerReference = i_GarageManager;
            InitializeComponent();
            List<Vehicle> allVehicles = i_GarageManager.GetAllVehicles();
            if (allVehicles.Count == 0)
            {
                Message.Text = "There are no vehicles in the garage";
            }
            else
            {
                int lastLabelBottom = Message.Bottom;
                foreach (Vehicle vehicle in allVehicles)
                {
                    Label LicensePlateNumber = new Label();
                    LicensePlateNumber.Click += Label_Click;
                    LicensePlateNumber.MouseEnter += LicensePlateNumber_MouseEnter;
                    LicensePlateNumber.MouseLeave += LicensePlateNumber_MouseLeave;
                    LicensePlateNumber.AutoSize = true;
                    LicensePlateNumber.Text = vehicle.LicensePlateNumber;
                    LicensePlateNumber.Left = Message.Left;
                    LicensePlateNumber.Top = lastLabelBottom + 5;
                    Controls.Add(LicensePlateNumber);
                    lastLabelBottom = LicensePlateNumber.Bottom;
                }

                ButtonExit.Top = lastLabelBottom + 20;
                this.Height = ButtonExit.Bottom + 50;
            }

            Update();
        }

        private void LicensePlateNumber_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        private void LicensePlateNumber_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void Label_Click(object sender, EventArgs e)
        {
            Label licensePlate = sender as Label;
            VehicleFullDetailesForm VehicleFullDetailes = new VehicleFullDetailesForm(r_GarageManagerReference);
            VehicleFullDetailes.LicensePlateNumber = licensePlate.Text;
            VehicleFullDetailes.SimulateShowClick(sender, e);
            VehicleFullDetailes.ShowDialog();
        }
    }
}
