using System;
using System.Windows.Forms;
using GarageManagement.Logic;

namespace GarageManagement.UI
{
    public partial class AddFuelForm : Form
    {
        private readonly GarageManager r_GarageManagerReference;

        public AddFuelForm(GarageManager i_GarageManager)
        {
            r_GarageManagerReference = i_GarageManager;
            InitializeComponent();
            foreach (string fuelType in Enum.GetNames(typeof(Fuel.eFuelType)))
            {
                ComboBoxFuelType.Items.Add(fuelType);
            }
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            float amountOfFuel;
            if (LicensePlateNumberTextBox.Text == string.Empty)
            {
                MessageBox.Show("Enter license plate number", "ERROR", MessageBoxButtons.OK);
            }
            else if (!float.TryParse(AmountOfFuelTextBox.Text, out amountOfFuel))
            {
                MessageBox.Show("Amount of fuel should be be a rational number", "ERROR", MessageBoxButtons.OK);
            }
            else if (ComboBoxFuelType.SelectedItem == null)
            {
                MessageBox.Show("Select fuel type", "ERROR", MessageBoxButtons.OK);
            }
            else
            {
                try
                {
                    Fuel.eFuelType fuelType;
                    Enum.TryParse<Fuel.eFuelType>(ComboBoxFuelType.SelectedItem.ToString(), out fuelType);
                    r_GarageManagerReference.AddFuel(LicensePlateNumberTextBox.Text, amountOfFuel, fuelType);
                    MessageBox.Show("Fuel added successfully", "Success", MessageBoxButtons.OK);
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message, "ERROR", MessageBoxButtons.OK);
                }
            }
        }
    }
}
