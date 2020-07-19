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
using MongoDB.Driver;
using GarageManagement.Logic;

namespace GarageManagement.UI
{
    public partial class MainForm : Form
    {
        private readonly GarageManager r_GarageManager;
        private readonly IMongoCollection<BsonDocument> r_Collection;

        public MainForm(bool i_SaveToDataBase, IMongoCollection<BsonDocument> i_DBCollection)
        {
            r_GarageManager = new GarageManager(i_SaveToDataBase, i_DBCollection);
            r_Collection = i_DBCollection;
            InitializeComponent();
            if (i_SaveToDataBase)
            {
                selectedEnvironmentLabel.Text = selectedEnvironmentLabel.Text + "MongoDB";
            }
            else
            {
                selectedEnvironmentLabel.Text = selectedEnvironmentLabel.Text + "Local";
            }
        }

        private void AddNewVehicle_Click(object sender, EventArgs e)
        {
            AddVehicleForm newVehicleForm = new AddVehicleForm(r_GarageManager, r_Collection);
            newVehicleForm.ShowDialog();
        }

        private void ChangeVehicleStatus_Click(object sender, EventArgs e)
        {
            ChangeStatusForm statusForm = new ChangeStatusForm(r_GarageManager);
            statusForm.ShowDialog();
        }

        private void AddFuel_Click(object sender, EventArgs e)
        {
            AddFuelForm addFuel = new AddFuelForm(r_GarageManager);
            addFuel.ShowDialog();
        }

        private void ChargeBattery_Click(object sender, EventArgs e)
        {
            ChargeBatteryForm chargeBattery = new ChargeBatteryForm(r_GarageManager);
            chargeBattery.ShowDialog();
        }

        private void ShowAllLicensePlates_Click(object sender, EventArgs e)
        {
            AllLicensePlatesForm allLicensePlates = new AllLicensePlatesForm(r_GarageManager);
            allLicensePlates.ShowDialog();
        }

        private void ShowVehiclesInSpesificStatus_Click(object sender, EventArgs e)
        {
            VehiclesByStatusForm VehiclesByStatus = new VehiclesByStatusForm(r_GarageManager);
            VehiclesByStatus.ShowDialog();
        }

        private void ShowVehicleFullDetailes_Click(object sender, EventArgs e)
        {
            VehicleFullDetailesForm VehicleFullDetailes = new VehicleFullDetailesForm(r_GarageManager);
            VehicleFullDetailes.ShowDialog();
        }

        private void FillVehicleWheels_Click(object sender, EventArgs e)
        {
            FillWheelsForm fillWheels = new FillWheelsForm(r_GarageManager);
            fillWheels.ShowDialog();
        }

        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Garage managment system. \r\nCreated by Shahaf Machluf.", "About", MessageBoxButtons.OK);
        }
    }
}
