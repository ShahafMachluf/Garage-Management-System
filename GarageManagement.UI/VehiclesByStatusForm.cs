using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GarageManagement.Logic;

namespace GarageManagement.UI
{
    public partial class VehiclesByStatusForm : Form
    {
        private readonly GarageManager r_GarageManagerReference;

        public VehiclesByStatusForm(GarageManager i_GarageManager)
        {
            r_GarageManagerReference = i_GarageManager;
            InitializeComponent();
            foreach (string status in Enum.GetNames(typeof(Vehicle.eRepairStatus)))
            {
                StatusComboBox.Items.Add(status);
            }

            Update();
        }

        private void clearDynamicLabels()
        {
            List<Control> toDelete = new List<Control>();
            foreach (Control control in Controls)
            {
                if (control.TabIndex > 2)
                {
                    toDelete.Add(control);
                }
            }

            foreach (Control control in toDelete)
            {
                Controls.Remove(control);
            }

            Update();
        }

        private void StatusComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearDynamicLabels();
            Vehicle.eRepairStatus status;
            int lastLabelBottom = StatusLabel.Bottom;
            Enum.TryParse<Vehicle.eRepairStatus>(StatusComboBox.Text.ToString(), out status);
            List<Vehicle> vehicles = r_GarageManagerReference.GetVehiclesInSpesificStatus(status);
            if (vehicles.Count == 0)
            {
                Label msg = new Label();
                msg.Text = "There are no vehicles in this status";
                msg.AutoSize = true;
                msg.Left = StatusLabel.Left;
                msg.Top = StatusLabel.Bottom + 5;
                Controls.Add(msg);
                ButtonExit.Top = lastLabelBottom + 50;
                this.Height = ButtonExit.Bottom + 50;
            }
            else
            {
                foreach (Vehicle vehicle in vehicles)
                {
                    Label LicensePlateNumberlabel = new Label();
                    LicensePlateNumberlabel.Click += Label_Click;
                    LicensePlateNumberlabel.MouseEnter += LicensePlateNumberlabel_MouseEnter;
                    LicensePlateNumberlabel.MouseLeave += LicensePlateNumberlabel_MouseLeave;
                    LicensePlateNumberlabel.Text = vehicle.LicensePlateNumber;
                    LicensePlateNumberlabel.AutoSize = true;
                    LicensePlateNumberlabel.Left = StatusLabel.Left;
                    LicensePlateNumberlabel.Top = lastLabelBottom + 5;
                    Controls.Add(LicensePlateNumberlabel);
                    lastLabelBottom = LicensePlateNumberlabel.Bottom;
                }

                ButtonExit.Top = lastLabelBottom + 20;
                this.Height = ButtonExit.Bottom + 50;
            }

            Update();
        }

        private void LicensePlateNumberlabel_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        private void LicensePlateNumberlabel_MouseEnter(object sender, EventArgs e)
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