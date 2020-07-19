using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GarageManagement.Logic;

namespace GarageManagement.UI
{
    public partial class ChargeBatteryForm : Form
    {
        private readonly GarageManager r_GarageManagerReference;

        public ChargeBatteryForm(GarageManager i_GarageManager)
        {
            r_GarageManagerReference = i_GarageManager;
            InitializeComponent();
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            float minutesToAdd;
            if (LicensePlateNumberTextBox.Text == string.Empty)
            {
                MessageBox.Show("Enter license plate number", "ERROR", MessageBoxButtons.OK);
            }
            else if (!float.TryParse(NumberOfMinutesToAddTextBox.Text, out minutesToAdd))
            {
                MessageBox.Show("Amount of fuel should be be a rational number", "ERROR", MessageBoxButtons.OK);
            }
            else
            {
                try
                {
                    r_GarageManagerReference.ChargeBattery(LicensePlateNumberTextBox.Text, minutesToAdd);
                    MessageBox.Show("Battery charged successfully", "Success", MessageBoxButtons.OK);
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message, "ERROR", MessageBoxButtons.OK);
                }
            }
        }
    }
}