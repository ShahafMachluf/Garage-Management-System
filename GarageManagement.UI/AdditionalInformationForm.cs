using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GarageManagement.Logic;

namespace GarageManagement.UI
{
    public partial class AdditionalInformationForm : Form
    {
        private readonly Vehicle r_CurrentVehicleReference;

        public event Action VehicleDetailesFilled;

        public AdditionalInformationForm(Vehicle i_NewVehicle)
        {
            r_CurrentVehicleReference = i_NewVehicle;
            InitializeComponent();
            initiateAdditionalInformationComponents(r_CurrentVehicleReference);
        }

        private void initiateAdditionalInformationComponents(Vehicle i_NewVehicle)
        {
            Label parameterLabel;
            TextBox parameterTextBox;
            int lastParameterBottom = MessageLabel.Bottom;
            int tabIndex = 0;
            List<string> parameters = i_NewVehicle.GetVehicleRequiredParameters();
            foreach (string parameter in parameters)
            {
                if (parameter.Contains("select"))
                {
                    addParameterWithRadioButtons(parameter, ref lastParameterBottom, ref tabIndex);
                }
                else if (parameter.Contains("is"))
                {
                    addParameterWithCheckBox(parameter, ref lastParameterBottom, ref tabIndex);
                }
                else
                {
                    parameterLabel = new Label();
                    parameterTextBox = new TextBox();
                    parameterLabel.Text = parameter;
                    parameterLabel.TabIndex = tabIndex++;
                    parameterLabel.AutoSize = true;
                    parameterLabel.Top = lastParameterBottom + 10;
                    parameterLabel.Left = MessageLabel.Left;
                    parameterTextBox.Top = parameterLabel.Top;
                    parameterTextBox.Left = 160;
                    parameterTextBox.Size = new Size(80, 10);
                    lastParameterBottom = parameterLabel.Bottom;
                    Controls.Add(parameterLabel);
                    Controls.Add(parameterTextBox);
                }
            }

            ButtonCancel.Top = lastParameterBottom + 20;
            ButtonOK.Top = ButtonCancel.Top;
            this.Height = ButtonOK.Bottom + 50;
            Update();
        }

        private void addParameterWithCheckBox(string i_Parameter, ref int io_LastParameterBottom, ref int io_TabIndex)
        {
            Label parameterLabel = new Label();
            CheckBox parameterCheckBox = new CheckBox();
            parameterLabel.Text = i_Parameter;
            parameterLabel.TabIndex = io_TabIndex++;
            parameterLabel.AutoSize = true;
            parameterLabel.Top = io_LastParameterBottom + 10;
            parameterLabel.Left = MessageLabel.Left;
            parameterCheckBox.Top = parameterLabel.Top - 4;
            parameterCheckBox.Left = 200;
            io_LastParameterBottom = parameterLabel.Bottom;
            Controls.Add(parameterLabel);
            Controls.Add(parameterCheckBox);
        }

        private void addParameterWithRadioButtons(string i_Parameter, ref int io_LastParameterBottom, ref int io_TabIndex)
        {
            string labelString, optionsString;
            StringBuilder currentOption = new StringBuilder();
            Label parameterLabel = new Label();
            GroupBox radioButtonsGroupBox = new GroupBox();
            int i = 0;
            int labelStringEnd = i_Parameter.IndexOf(':');
            radioButtonsGroupBox.Height = parameterLabel.Height;
            labelString = i_Parameter.Substring(0, labelStringEnd - 1);
            parameterLabel.Text = labelString;
            parameterLabel.TabIndex = io_TabIndex++;
            parameterLabel.AutoSize = true;
            parameterLabel.Top = io_LastParameterBottom + 10;
            parameterLabel.Left = MessageLabel.Left;
            io_LastParameterBottom = parameterLabel.Bottom;
            optionsString = i_Parameter.Substring(labelStringEnd);
            int lastRadioButtonRight = radioButtonsGroupBox.Left;
            while (i < optionsString.Length)
            {
                if (char.IsDigit(optionsString[i]))
                {
                    RadioButton optionRadioButton = new RadioButton();
                    optionRadioButton.Name = optionsString[i].ToString();
                    i += 3;
                    while (i < optionsString.Length && optionsString[i] != '\r')
                    {
                        currentOption.Append(optionsString[i]);
                        i++;
                    }

                    i++;
                    optionRadioButton.Text = currentOption.ToString();
                    optionRadioButton.AutoSize = true;
                    currentOption.Clear();
                    radioButtonsGroupBox.Controls.Add(optionRadioButton);
                    optionRadioButton.Left = lastRadioButtonRight;
                    lastRadioButtonRight = optionRadioButton.Right;
                }

                i++;
            }

            radioButtonsGroupBox.Top = parameterLabel.Top;
            radioButtonsGroupBox.Left = 160;
            radioButtonsGroupBox.Width = radioButtonsGroupBox.Controls[radioButtonsGroupBox.Controls.Count - 1].Right;
            Controls.Add(parameterLabel);
            Controls.Add(radioButtonsGroupBox);
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            int parameterIndex = 1;
            bool selectedRadioButton = false;
            List<string> vehicleInformation = new List<string>();

            foreach (Control formControl in Controls)
            {
                if (formControl is TextBox)
                {
                    vehicleInformation.Add(((TextBox)formControl).Text);
                }
                else if (formControl is CheckBox)
                {
                    vehicleInformation.Add(((CheckBox)formControl).Checked.ToString());
                }
                else if (formControl is GroupBox)
                {
                    foreach (Control groupBoxControl in ((GroupBox)formControl).Controls)
                    {
                        RadioButton formRadioButton = groupBoxControl as RadioButton;
                        if (formRadioButton != null && formRadioButton.Checked)
                        {
                            vehicleInformation.Add(formRadioButton.Name);
                            selectedRadioButton = true;
                        }
                    }

                    if(!selectedRadioButton)
                    {
                        vehicleInformation.Add("-1");
                    }
                }
            }

            try
            {
                foreach (string vehicleParameter in vehicleInformation)
                {
                    r_CurrentVehicleReference.SetVehicleRequiredParameters(vehicleParameter, parameterIndex);
                    parameterIndex++;
                }

                if (VehicleDetailesFilled != null)
                {
                    VehicleDetailesFilled.Invoke();
                }

                Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
    }
}
