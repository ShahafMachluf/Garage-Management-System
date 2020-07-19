using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace GarageManagement.Logic
{
    public class VehicleCreator
    {
        public enum eVehiclesTypes
        {
            FuelMotorcycle = 1,
            ElectricMotorcycle,
            FuelCar,
            ElectricCar,
            Truck,
        }

        public static Vehicle CreateVehicle(string i_LicensePlateNumber, eVehiclesTypes i_VehicleType)
        {
            Vehicle newVehicle = null;
            if(i_LicensePlateNumber.Length != 7 && i_LicensePlateNumber.Length != 8)
            {
                throw new ArgumentException("ERROR. License plate number should contain 7 or 8 digits.");
            }

            if (!Enum.IsDefined(typeof(eVehiclesTypes), i_VehicleType))
            {
                throw new ArgumentException("ERROR. " + i_VehicleType + "is not exist");
            }

            switch(i_VehicleType)
            {
                case eVehiclesTypes.ElectricCar:
                case eVehiclesTypes.FuelCar:
                    {
                        newVehicle = new Car(i_LicensePlateNumber, i_VehicleType);
                        break;
                    }

                case eVehiclesTypes.ElectricMotorcycle:
                case eVehiclesTypes.FuelMotorcycle:
                    {
                        newVehicle = new Motorcycle(i_LicensePlateNumber, i_VehicleType);
                        break;
                    }

                case eVehiclesTypes.Truck:
                    {
                        newVehicle = new Truck(i_LicensePlateNumber);
                        break;
                    }
            }

            return newVehicle;
        }

        public static List<Vehicle> ConvertBsonListToVehicleList(List<BsonDocument> i_BsonVehicles)
        {
            StringBuilder vehicleTypeInDocumnet = new StringBuilder();
            string[] vehicleTypes = Enum.GetNames(typeof(VehicleCreator.eVehiclesTypes));
            List<Vehicle> vehicles = new List<Vehicle>();
            Vehicle convertedVehicle = null;
            foreach (BsonDocument bsonVehicle in i_BsonVehicles)
            {
                convertedVehicle = ConvertBsonDocumentToVehicle(bsonVehicle);
                if(convertedVehicle != null)
                {
                    vehicles.Add(convertedVehicle);
                }

                convertedVehicle = null;
            }

            return vehicles;
        }

        public static Vehicle ConvertBsonDocumentToVehicle(BsonDocument i_VehicleDocument)
        {
            Vehicle vehicle = null;
            if (i_VehicleDocument != null)
            {
                string documnet = i_VehicleDocument.ToString();
                if (documnet.Contains(@"""_t"" : ""Motorcycle"""))
                {
                    vehicle = BsonSerializer.Deserialize<Motorcycle>(i_VehicleDocument);
                }
                else if (documnet.Contains(@"""_t"" : ""Car"""))
                {
                    vehicle = BsonSerializer.Deserialize<Car>(i_VehicleDocument);
                }
                else if (documnet.Contains(@"""_t"" : ""Truck"""))
                {
                    vehicle = BsonSerializer.Deserialize<Truck>(i_VehicleDocument);
                }
            }

            return vehicle;
        }

        public static void RegisterVehicles()
        {
            BsonSerializer.RegisterSerializer(typeof(DateTime), DateTimeSerializer.LocalInstance);
            Vehicle newVehicle;
            newVehicle = new Motorcycle("00000000", eVehiclesTypes.ElectricMotorcycle);
            newVehicle.RegisterClass();
            newVehicle = new Motorcycle("00000000", eVehiclesTypes.FuelMotorcycle);
            newVehicle.RegisterClass();
            newVehicle = new Car("00000000", eVehiclesTypes.ElectricCar);
            newVehicle.RegisterClass();
            newVehicle = new Car("00000000", eVehiclesTypes.FuelCar);
            newVehicle.RegisterClass();
            newVehicle = new Truck("00000000");
            newVehicle.RegisterClass();
        }

        public static string[] GetListOfVehicleTypes()
        {
            string[] types = Enum.GetNames(typeof(eVehiclesTypes));

            for (int i = 0; i < types.Length; i++)
            {
                for (int j = 1; j < types[i].Length; j++)
                {
                    if (char.IsUpper(types[i][j]))
                    {
                        types[i] = types[i].Insert(j, " ");
                        j++;
                    }
                }
            }

            return types;
        }
    }
}
