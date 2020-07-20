using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using GarageManagement.Logic;

namespace GarageManagement.UI
{
    public partial class AddVehicleForm : Form
    {
        private readonly GarageManager r_GarageManagerReference;
        private bool m_VehicleDetailesFilled;

        public AddVehicleForm(GarageManager i_GarageManagerReference)
        {
            m_VehicleDetailesFilled = false;
            r_GarageManagerReference = i_GarageManagerReference;
            InitializeComponent();
            foreach (string vehicleType in VehicleCreator.GetListOfVehicleTypes())
            {
                VehicleTypeComboBox.Items.Add(vehicleType);
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (VehicleTypeComboBox.SelectedItem == null)
            {
                MessageBox.Show("Select vehicle type", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    VehicleCreator.eVehiclesTypes vehicleType;
                    string selectedType = VehicleTypeComboBox.SelectedItem.ToString();
                    selectedType = string.Concat(selectedType.Where(character => !char.IsWhiteSpace(character)));
                    Enum.TryParse<VehicleCreator.eVehiclesTypes>(selectedType, out vehicleType);
                    Vehicle newVehicle = r_GarageManagerReference.CreateVehicle(LicensePlateNumberText.Text, vehicleType);
                    AdditionalInformationForm informationForm = new AdditionalInformationForm(newVehicle);
                    informationForm.VehicleDetailesFilled += InformationForm_vehicleDetailesFilled;
                    informationForm.ShowDialog();
                    if (m_VehicleDetailesFilled)
                    {
                        r_GarageManagerReference.AddVehicleToGarage(ref newVehicle);
                        MessageBox.Show("Vehicle added to garage!", "Success", MessageBoxButtons.OK);
                        m_VehicleDetailesFilled = false;
                    }
                    else
                    {
                        MessageBox.Show("Vehicle not added to garage!", "Abort", MessageBoxButtons.OK);
                    }

                    this.Close();
                }
                catch (ArgumentException exp)
                {
                    MessageBox.Show(exp.Message, "ERROR", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

        private void InformationForm_vehicleDetailesFilled()
        {
            m_VehicleDetailesFilled = true;
        }
    }
}
