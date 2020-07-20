using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Driver;

namespace GarageManagement.Logic
{
    public class GarageManager
    {
        private readonly bool r_ConnectedToMongoDB;
        private readonly Dictionary<int, Vehicle> r_VehiclesDictionary;
        private readonly IMongoCollection<BsonDocument> r_DBCollection;

        public GarageManager(bool i_ConnectedToMongoDB, IMongoCollection<BsonDocument> i_DBCollection)
        {
            r_ConnectedToMongoDB = i_ConnectedToMongoDB;
            r_DBCollection = i_DBCollection;
            if (!r_ConnectedToMongoDB)
            {
                r_VehiclesDictionary = new Dictionary<int, Vehicle>();
            }
        }

        public bool IsConnectedToDB
        {
            get
            {
                return r_ConnectedToMongoDB;
            }
        }

        public IMongoCollection<BsonDocument> DBCollection
        {
            get
            {
                return r_DBCollection;
            }
        }

        public Vehicle CreateVehicle(string i_LicensePlateNumber, VehicleCreator.eVehiclesTypes i_VehicelType)
        {
            Vehicle newVehicle;

            if(IsVehicleExist(i_LicensePlateNumber))
            {
                throw new ArgumentException("ERROR. The vehicle with license plate number" + i_LicensePlateNumber + "is already exist");
            }

            newVehicle = VehicleCreator.CreateVehicle(i_LicensePlateNumber, i_VehicelType);

            return newVehicle;
        }

        public void AddVehicleToGarage(ref Vehicle i_NewVehicle)
        {
            if (IsVehicleExist(i_NewVehicle.LicensePlateNumber))
            {
                throw new ArgumentException("ERROR. The vehicle with license plate number " + i_NewVehicle.LicensePlateNumber + " already in the garage");
            }

            if(!r_ConnectedToMongoDB)
            {
                r_VehiclesDictionary.Add(i_NewVehicle.GetHashCode(), i_NewVehicle);
            }
            else
            {
                r_DBCollection.InsertOne(i_NewVehicle.ToBsonDocument());
            }
        }

        public void RemoveVehicleFromGarage(ref Vehicle i_VehicleToRemove)
        {
            Vehicle vehicleSearchedInDirectory;
            if (!r_VehiclesDictionary.TryGetValue(i_VehicleToRemove.GetHashCode(), out vehicleSearchedInDirectory))
            {
                throw new ArgumentException("ERROR. The vehicle with license plate number " + vehicleSearchedInDirectory.LicensePlateNumber + " not exist in the garage");
            }

            r_VehiclesDictionary.Remove(i_VehicleToRemove.GetHashCode());
        }

        public Dictionary<int, Vehicle> VehiclesDictionary
        {
            get
            {
                return r_VehiclesDictionary;
            }
        }

        public bool IsVehicleExist(string i_LicensePlateNumber)
        {
            Vehicle vehicleToLookFor;
            bool isVehicleExist;

            if(r_ConnectedToMongoDB)
            {
                FilterDefinition<BsonDocument> DBFilter = Builders<BsonDocument>.Filter.Eq("_id", i_LicensePlateNumber);
                BsonDocument vehicleBsonDocument = r_DBCollection.Find<BsonDocument>(DBFilter).FirstOrDefault();
                isVehicleExist = vehicleBsonDocument != null;
            }
            else
            {
                isVehicleExist = r_VehiclesDictionary.TryGetValue(i_LicensePlateNumber.GetHashCode(), out vehicleToLookFor);
            }

            return isVehicleExist;
        }

        public void ChangeVehicleStatus(string i_LicensePlateNumber, Vehicle.eRepairStatus i_ReapairStatus)
        {
            Vehicle vehicleToChangeStatus = GetVehicleByLicenseNumber(i_LicensePlateNumber);

            if (!Enum.IsDefined(typeof(Vehicle.eRepairStatus), i_ReapairStatus))
            {
                throw new ArgumentException("ERROR. New vheicle status not exist");
            }

            vehicleToChangeStatus.Status = i_ReapairStatus;
            if(r_ConnectedToMongoDB)
            {
                UpdateDefinition<BsonDocument> update = Builders<BsonDocument>.Update.Set("Status", i_ReapairStatus.ToString());
                UpdateVehicleInMongoDB(i_LicensePlateNumber, update);
            }
        }

        public List<Vehicle> GetAllVehicles()
        {
            List<Vehicle> vehicleToReturn = new List<Vehicle>();
            if (!r_ConnectedToMongoDB)
            {
                foreach (KeyValuePair<int, Vehicle> keyAndValue in r_VehiclesDictionary)
                {
                    vehicleToReturn.Add(keyAndValue.Value);
                }
            }
            else
            {
                var emptyFilter = Builders<BsonDocument>.Filter.Empty;
                List<BsonDocument> documents = r_DBCollection.Find<BsonDocument>(emptyFilter).ToList();
                vehicleToReturn = VehicleCreator.ConvertBsonListToVehicleList(documents);
            }

            return vehicleToReturn;
        }

        public List<Vehicle> GetVehiclesInSpesificStatus(Vehicle.eRepairStatus i_Status)
        {
            List<Vehicle> vehicleToReturn = new List<Vehicle>();
            if (!r_ConnectedToMongoDB)
            {
                if (!Enum.IsDefined(typeof(Vehicle.eRepairStatus), i_Status))
                {
                    throw new ArgumentException("ERROR. " + i_Status + " status is not exist");
                }

                foreach (KeyValuePair<int, Vehicle> keyAndValue in r_VehiclesDictionary)
                {
                    if (keyAndValue.Value.Status == i_Status)
                    {
                        vehicleToReturn.Add(keyAndValue.Value);
                    }
                }
            }
            else
            {
                var statusFilter = Builders<BsonDocument>.Filter.Eq("Status", i_Status);
                List<BsonDocument> documents = r_DBCollection.Find<BsonDocument>(statusFilter).ToList();
                vehicleToReturn = VehicleCreator.ConvertBsonListToVehicleList(documents);
            }

            return vehicleToReturn;
        }

        public void FillWheelsAirToMaximum(string i_LicensePlateNumber)
        {
            Vehicle vehicleToFillAir = GetVehicleByLicenseNumber(i_LicensePlateNumber);

            vehicleToFillAir.FillAllWheels();
            if(r_ConnectedToMongoDB)
            {
                UpdateDefinition<BsonDocument> update = Builders<BsonDocument>.Update.Set("Wheels", vehicleToFillAir.Wheels);
                UpdateVehicleInMongoDB(i_LicensePlateNumber, update);
            }
        }

        public void FillWheels(string i_LicensePlateNumber, List<string> i_NewAirPresure)
        {
            Vehicle vehicleToFillAir = GetVehicleByLicenseNumber(i_LicensePlateNumber);

            for (int i = 0; i < i_NewAirPresure.Count && i < vehicleToFillAir.Wheels.Length; i++)
            {
                vehicleToFillAir.Wheels[i].CurrentAirPressure = i_NewAirPresure[i];
            }

            if (r_ConnectedToMongoDB)
            {
                UpdateDefinition<BsonDocument> update = Builders<BsonDocument>.Update.Set("Wheels", vehicleToFillAir.Wheels);
                UpdateVehicleInMongoDB(i_LicensePlateNumber, update);
            }
        }

        public void AddFuel(string i_LicensePlateNumber, float i_AmountOfFuel, Fuel.eFuelType i_FuelType)
        {
            Vehicle vehicleToFill = GetVehicleByLicenseNumber(i_LicensePlateNumber);
            Fuel vehicleFuelTank;

            vehicleFuelTank = vehicleToFill.GetPowerSource() as Fuel;
            if (vehicleFuelTank == null)
            {
                throw new ArgumentException("ERROR. The vehicle is not working on fuel");
            }

            if (!Enum.IsDefined(typeof(Fuel.eFuelType), i_FuelType))
            {
                throw new ArgumentException("ERROR. select fuel type from the list.");
            }

            if (vehicleFuelTank.FuelType != i_FuelType)
            {
                throw new ArgumentException(i_FuelType + " is not the right fuel type for this vehicle, " + vehicleFuelTank.FuelType + " is the right fuel type");
            }

            vehicleToFill.AddToPowerSource(i_AmountOfFuel);
            vehicleToFill.UpdatePercentageOfEnergy();
            if(r_ConnectedToMongoDB)
            {
                UpdateDefinition<BsonDocument> update = Builders<BsonDocument>.Update.Set("PercentageOfEnergy", vehicleToFill.PercentageOfEnergy).Set("PowerSource.AmountOfEnergyLeft", vehicleToFill.GetPowerSource().AmountOfEnergyLeft);
                UpdateVehicleInMongoDB(i_LicensePlateNumber, update);
            }
        }

        public void ChargeBattery(string i_LicensePlateNumber, float i_HoursToAdd)
        {
            Vehicle vehicleToFill = GetVehicleByLicenseNumber(i_LicensePlateNumber);
            Battery vehicleBattery;

            vehicleBattery = vehicleToFill.GetPowerSource() as Battery;
            if (vehicleBattery == null)
            {
                throw new ArgumentException("ERROR. This vehicle is not working on battery");
            }

            vehicleToFill.AddToPowerSource(i_HoursToAdd);
            vehicleToFill.UpdatePercentageOfEnergy();
            if(r_ConnectedToMongoDB)
            {
                UpdateDefinition<BsonDocument> update = Builders<BsonDocument>.Update.Set("PercentageOfEnergy", vehicleToFill.PercentageOfEnergy).Set("PowerSource.AmountOfEnergyLeft", vehicleToFill.GetPowerSource().AmountOfEnergyLeft);
                UpdateVehicleInMongoDB(i_LicensePlateNumber, update);
            }
        }

        public Vehicle GetVehicleByLicenseNumber(string i_LicensePlateNumber)
        {
            Vehicle vehicle;

            if (r_ConnectedToMongoDB)
            {
                FilterDefinition<BsonDocument> DBFilter = Builders<BsonDocument>.Filter.Eq("_id", i_LicensePlateNumber);
                BsonDocument vehicleBsonDocument = r_DBCollection.Find<BsonDocument>(DBFilter).FirstOrDefault();
                if (vehicleBsonDocument == null)
                {
                    throw new ArgumentException("ERROR. The Vehicle with license plate number " + i_LicensePlateNumber + " not exist");
                }

                vehicle = VehicleCreator.ConvertBsonDocumentToVehicle(vehicleBsonDocument);
            }
            else
            {
                if (!r_VehiclesDictionary.TryGetValue(i_LicensePlateNumber.GetHashCode(), out vehicle))
                {
                    throw new ArgumentException("ERROR. The Vehicle with license plate number " + i_LicensePlateNumber + " not exist");
                }
            }

            return vehicle;
        }
        
        public void UpdateVehicleInMongoDB(string i_LicensePlateNumber, UpdateDefinition<BsonDocument> i_Update)
        {
            FilterDefinition<BsonDocument> DBFilter = Builders<BsonDocument>.Filter.Eq("_id", i_LicensePlateNumber);
            BsonDocument vehicleBsonDocument = r_DBCollection.Find<BsonDocument>(DBFilter).FirstOrDefault();
            if (vehicleBsonDocument == null)
            {
                throw new ArgumentException("ERROR. The Vehicle with license plate number " + i_LicensePlateNumber + " not exist");
            }

            r_DBCollection.UpdateOne(DBFilter, i_Update);
        }
    }
}