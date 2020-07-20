using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
using GarageManagement.Logic;

namespace GarageManagement.UI
{
    public partial class SystemStartingForm : Form
    {
        private IMongoCollection<BsonDocument> m_Collection;

        public SystemStartingForm()
        {
            InitializeComponent();
            EnvironmentSelectionComboBox.SelectedValueChanged += EnvironmentSelection_SelectedValueChanged;
        }

        public IMongoCollection<BsonDocument> Collection
        {
            get
            {
                return m_Collection;
            }
        }

        public string EnvironmentSelection
        {
            get
            {
                return EnvironmentSelectionComboBox.SelectedItem.ToString();
            }
        }

        private void EnvironmentSelection_SelectedValueChanged(object sender, System.EventArgs e)
        {
            if (EnvironmentSelectionComboBox.SelectedItem.ToString() == "MongoDB")
            {
                int tabIndex = 6;
                Label serverAddressLabel = new Label();
                Label serverUsernameLabel = new Label();
                Label serverPasswordLabel = new Label();

                TextBox serverAddressTextBox = new TextBox();
                TextBox serverUsernameTextBox = new TextBox();
                TextBox serverPasswordTextBox = new TextBox();

                serverAddressLabel.Text = "Server address";
                serverUsernameLabel.Text = "Username";
                serverPasswordLabel.Text = "Password";

                serverAddressLabel.Left = selectEnvironmentLabel.Left;
                serverAddressLabel.Top = selectEnvironmentLabel.Bottom + 10;
                serverAddressLabel.TabIndex = tabIndex++;

                serverUsernameLabel.Left = selectEnvironmentLabel.Left;
                serverUsernameLabel.Top = serverAddressLabel.Bottom + 10;
                serverUsernameLabel.TabIndex = tabIndex++;

                serverPasswordLabel.Left = selectEnvironmentLabel.Left;
                serverPasswordLabel.Top = serverUsernameLabel.Left + 100;
                serverPasswordLabel.TabIndex = tabIndex++;

                serverAddressTextBox.Top = serverAddressLabel.Top;
                serverAddressTextBox.Left = serverAddressLabel.Left + 100;
                serverAddressTextBox.TabIndex = tabIndex++;

                serverUsernameTextBox.Top = serverUsernameLabel.Top;
                serverUsernameTextBox.Left = serverUsernameLabel.Left + 100;
                serverUsernameTextBox.TabIndex = tabIndex++;

                serverPasswordTextBox.Top = serverPasswordLabel.Top;
                serverPasswordTextBox.Left = serverPasswordLabel.Left + 100;
                serverPasswordTextBox.TabIndex = tabIndex++;
                serverPasswordTextBox.PasswordChar = '*';

                ButtonOK.Top = serverPasswordLabel.Bottom + 20;
                ButtonCancel.Top = ButtonOK.Top;
                Height = ButtonOK.Bottom + 50;

                Controls.Add(serverAddressLabel);
                Controls.Add(serverUsernameLabel);
                Controls.Add(serverPasswordLabel);
                Controls.Add(serverAddressTextBox);
                Controls.Add(serverUsernameTextBox);
                Controls.Add(serverPasswordTextBox);
                Update();
            }
            else
            {
                List<Control> toRemove = new List<Control>();
                foreach (Control control in Controls)
                {
                    if (control.TabIndex > 3)
                    {
                        toRemove.Add(control);
                    }
                }

                foreach (Control controlToRemove in toRemove)
                {
                    Controls.Remove(controlToRemove);
                }

                ButtonOK.Top = selectEnvironmentLabel.Bottom + 30;
                ButtonCancel.Top = EnvironmentSelectionComboBox.Bottom + 30;
                Height = ButtonCancel.Bottom + 70;
                Update();
            }
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            if (EnvironmentSelectionComboBox.SelectedItem.ToString() == "Local")
            {
                Close();
            }
            else if (EnvironmentSelectionComboBox.SelectedItem.ToString() == "MongoDB")
            {
                if (!connetToMongoDB(Controls[7].Text, Controls[8].Text, Controls[9].Text))
                {
                    DialogResult = DialogResult.Abort;
                }
                else
                {
                    MessageBox.Show("Connected to MongoDB", "Success", MessageBoxButtons.OK);
                }
            }
        }

        private bool connetToMongoDB(string i_ServerAddress, string i_Username, string i_Password)
        {
            // garage.edik2.mongodb.net
            bool isConnected = true;
            StringBuilder connectionString = new StringBuilder();
            connectionString.Append(@"mongodb+srv://");
            connectionString.Append(i_Username);
            connectionString.Append(':');
            connectionString.Append(i_Password);
            connectionString.Append('@');
            connectionString.Append(i_ServerAddress);

            try
            {
                var client = new MongoClient(connectionString.ToString());
                client.ListDatabaseNames();
                var DB = client.GetDatabase("Garage");
                m_Collection = DB.GetCollection<BsonDocument>("Vehicles");
            }
            catch (Exception)
            {
                isConnected = false;
                MessageBox.Show("There was an error connection to MongoDB\r\nPlease check the server address, username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            VehicleCreator.RegisterVehicles();

            return isConnected;
        }
    }
}