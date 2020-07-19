using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GarageManagement.Logic;

namespace GarageManagement.UI
{
    public partial class FillWheelsForm : Form
    {
        private readonly GarageManager r_GarageManagerReference;
        private List<TextBox> m_WheelsAirPresure;

        public FillWheelsForm(GarageManager i_GarageManager)
        {
            r_GarageManagerReference = i_GarageManager;
            InitializeComponent();
        }

        private void FillAllWheelsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!FillAllWheelsCheckBox.Checked)
                {
                    Vehicle vehicleToFillAir = r_GarageManagerReference.GetVehicleByLicenseNumber(LicensePlateNumberTextBox.Text);
                    int wheelNumber = 1;
                    int tabNumber = 6;
                    int lastLabelBottom = FillAllWheelsLabel.Bottom;

                    m_WheelsAirPresure = new List<TextBox>();
                    foreach (Vehicle.Wheel wheel in vehicleToFillAir.Wheels)
                    {
                        Label wheelLabel = new Label();
                        TextBox wheelAirPresureTextBox = new TextBox();
                        wheelLabel.Text = "wheel " + wheelNumber;
                        wheelNumber++;
                        wheelLabel.Top = lastLabelBottom + 10;
                        wheelLabel.Left = FillAllWheelsLabel.Left;
                        wheelAirPresureTextBox.Size = new Size(75, 22);
                        wheelAirPresureTextBox.Top = wheelLabel.Top;
                        wheelAirPresureTextBox.Left = wheelLabel.Left + 100;
                        wheelAirPresureTextBox.TabIndex = tabNumber++;
                        lastLabelBottom = wheelLabel.Bottom;
                        wheelAirPresureTextBox.Text = wheel.CurrentAirPressure;
                        m_WheelsAirPresure.Add(wheelAirPresureTextBox);
                        Controls.Add(wheelLabel);
                        Controls.Add(wheelAirPresureTextBox);
                    }

                    ButtonOK.Top = lastLabelBottom + 10;
                    ButtonCancel.Top = ButtonOK.Top;
                    this.Height = ButtonCancel.Bottom + 50;
                }
                else
                {
                    List<Control> toDelete = new List<Control>();
                    foreach (Control control in Controls)
                    {
                        if (control.TabIndex > 5)
                        {
                            toDelete.Add(control);
                        }
                    }

                    foreach (Control control in toDelete)
                    {
                        Controls.Remove(control);
                    }

                    ButtonOK.Top = FillAllWheelsLabel.Bottom + 10;
                    ButtonCancel.Top = ButtonOK.Top;
                    this.Height = ButtonCancel.Bottom + 50;
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "ERROR", MessageBoxButtons.OK);
            }

            Update();
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            if (LicensePlateNumberTextBox.Text == string.Empty)
            {
                MessageBox.Show("Enter license plate number", "ERROR", MessageBoxButtons.OK);
            }
            else
            {
                try
                {
                    if (FillAllWheelsCheckBox.Checked)
                    {
                        r_GarageManagerReference.FillWheelsAirToMaximum(LicensePlateNumberTextBox.Text);
                    }
                    else
                    {
                        List<string> newWheelsAirPresure = new List<string>();
                        foreach (TextBox airPresure in m_WheelsAirPresure)
                        {
                            newWheelsAirPresure.Add(airPresure.Text);
                        }

                        r_GarageManagerReference.FillWheels(LicensePlateNumberTextBox.Text, newWheelsAirPresure);
                    }

                    MessageBox.Show("Wheels filled successfully", "Success", MessageBoxButtons.OK);
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message, "ERROR", MessageBoxButtons.OK);
                }
            }
        }
    }
}
