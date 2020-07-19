using System;
using System.Linq;
using System.Windows.Forms;
using GarageManagement.Logic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GarageManagement.UI
{
    public partial class ChangeStatusForm : Form
    {
        private readonly GarageManager r_GarageManagerReference;

        public ChangeStatusForm(GarageManager i_GarageManager)
        {
            r_GarageManagerReference = i_GarageManager;
            InitializeComponent();
            foreach (string repairStatus in Enum.GetNames(typeof(Vehicle.eRepairStatus)))
            {
                VehicleStatuses.Items.Add(repairStatus);
            }
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            if (VehicleStatuses.SelectedItem == null)
            {
                MessageBox.Show("Select repair status", "ERROR", MessageBoxButtons.OK);
            }
            else if (LicensePlateNumberTextBox.Text == string.Empty)
            {
                MessageBox.Show("Insert license plate number", "ERROR", MessageBoxButtons.OK);
            }
            else
            {
                try
                {
                    Vehicle.eRepairStatus newStatus;
                    Enum.TryParse<Vehicle.eRepairStatus>(VehicleStatuses.SelectedItem.ToString(), out newStatus);
                    r_GarageManagerReference.ChangeVehicleStatus(LicensePlateNumberTextBox.Text, newStatus);
                    MessageBox.Show("Status changed successfully", "Success", MessageBoxButtons.OK);
                }
                catch (ArgumentException exp)
                {
                    MessageBox.Show(exp.Message, "ERROR", MessageBoxButtons.OK);
                }
            }
        }
    }
}
