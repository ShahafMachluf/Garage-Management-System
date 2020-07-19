using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GarageManagement.Logic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GarageManagement.UI
{
    public partial class VehicleFullDetailesForm : Form
    {
        private readonly GarageManager r_GarageManager;

        public VehicleFullDetailesForm(GarageManager i_GarageManager)
        {
            r_GarageManager = i_GarageManager;
            InitializeComponent();
        }

        public string LicensePlateNumber
        {
            set
            {
                LicensePlateNumberTextBox.Text = value;
            }
        }

        private void removeDynamicControls()
        {
            List<Control> toDelete = new List<Control>();
            foreach (Control control in Controls)
            {
                if (control.TabIndex > 3)
                {
                    toDelete.Add(control);
                }
            }

            foreach (Control control in toDelete)
            {
                Controls.Remove(control);
            }

            ButtonCancel.Top = 100;
            this.Height = 180;
        }

        public void SimulateShowClick(object sender, EventArgs e)
        {
            ButtonShowDetailes_Click(sender, e);
        }

        private void ButtonShowDetailes_Click(object sender, EventArgs e)
        {
            removeDynamicControls();
            if (LicensePlateNumberTextBox.Text == string.Empty)
            {
                MessageBox.Show("Enter license plate number", "ERROR", MessageBoxButtons.OK);
            }
            else
            {
                Vehicle vehicleToPrint;
                List<string> vehicleDetailes;
                if (!r_GarageManager.IsConnectedToDB)
                {
                    r_GarageManager.VehiclesDictionary.TryGetValue(LicensePlateNumberTextBox.Text.GetHashCode(), out vehicleToPrint);
                }
                else
                {
                    var filter = Builders<BsonDocument>.Filter.Eq("_id", LicensePlateNumberTextBox.Text);
                    BsonDocument bsonVehicle = r_GarageManager.DBCollection.Find(filter).FirstOrDefault();
                    vehicleToPrint = VehicleCreator.ConvertBsonDocumentToVehicle(bsonVehicle);
                }

                if (vehicleToPrint == null)
                {
                    MessageBox.Show("Vehicle with license palate number " + LicensePlateNumberTextBox.Text + " not exist", "ERROR", MessageBoxButtons.OK);
                }
                else
                {
                    int lastParameterBottom = LicensePlateNumberLabel.Bottom;
                    vehicleDetailes = vehicleToPrint.GetVehicleFullDetailes();
                    foreach (string vehicleParameter in vehicleDetailes)
                    {
                        Label parameter = new Label();
                        parameter.AutoSize = true;
                        parameter.Text = vehicleParameter;
                        parameter.Left = LicensePlateNumberLabel.Left;
                        parameter.Top = lastParameterBottom + 10;
                        Controls.Add(parameter);
                        lastParameterBottom = parameter.Bottom;
                    }

                    ButtonCancel.Top = lastParameterBottom + 10;
                    this.Height = ButtonCancel.Bottom + 50;
                }
            }
        }
    }
}
