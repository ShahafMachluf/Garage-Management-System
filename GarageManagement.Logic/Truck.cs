using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization;

namespace GarageManagement.Logic
{
    public class Truck : Vehicle
    {
        private const int k_NumberOfTruckWheels = 16;
        private const float k_MaximumAmountOfFuel = 120;
        private const float k_MaximumWheelAirPressure = 28;
        private const Fuel.eFuelType k_FuelType = Fuel.eFuelType.Soler;
        private float m_CargoVolume;
        private bool m_IsTransportingHazardousMaterials;

        public enum eTruckRequiredParameters
        {
            CargoVolume = 7,
            IsTransportingHazardousMaterials
        }

        public Truck(string i_LicensePlateNumber) : base(i_LicensePlateNumber)
        {
            m_PowerSource = new Fuel(k_MaximumAmountOfFuel, k_FuelType);
        }

        public string IsTransportingHazardousMaterials
        {
            get
            {
                return m_IsTransportingHazardousMaterials.ToString();
            }

            set
            {
                if(value.Length == 0)
                {
                    throw new ArgumentException("ERROR. is transporting hazardous materials can't be empty");
                }

                if(value != "Y" && value != "N" && value != "y" && value != "n" && value != "True" && value != "False")
                {
                    throw new ArgumentException("ERROR. is transporting hazardous materials selection should contain Y/N");
                }

                m_IsTransportingHazardousMaterials = value == "Y" || value == "y" || value == "True";
            }
        }

        public string CargoVolume
        {
            get
            {
                return m_CargoVolume.ToString();
            }

            set
            {
                float parsedValue;
                if (!float.TryParse(value, out parsedValue))
                {
                    throw new FormatException("ERROR. Cargo volume should be rational number");
                }

                if(parsedValue < 0)
                {
                    throw new ArgumentException("ERROR. Cargo volume can't be negative");
                }
                    
                m_CargoVolume = parsedValue;
            }
        }

        public override void AddToPowerSource(float i_AmountToAdd)
        {
            m_PowerSource.AddToPowerSource(i_AmountToAdd);
        }

        public override void UpdatePercentageOfEnergy()
        {
            m_PercentageOfEnergy = m_PowerSource.AmountOfEnergyLeft / k_MaximumAmountOfFuel * 100;
        }

        public override List<string> GetVehicleFullDetailes()
        {
            List<string> vehicleDetailes = GetVehicleBaseDetailes();

            vehicleDetailes.Add("Cargo volume: " + m_CargoVolume.ToString());
            vehicleDetailes.Add("Is transporting hazardous materials: " + m_IsTransportingHazardousMaterials.ToString());
            vehicleDetailes.Add("Power source type: fuel");
            vehicleDetailes.Add("Fuel type: " + k_FuelType);

            return vehicleDetailes;
        }

        public override List<string> GetVehicleRequiredParameters()
        {
            List<string> truckParameters = GetBaseVehicleRequiredParameters();
            Fuel.GetFuelParameters(truckParameters);
            truckParameters.Add("cargo volume");
            truckParameters.Add("is transporting hazardous materials?");

            return truckParameters;
        }

        public override void SetVehicleRequiredParameters(string i_ParameterToSet, int i_ParameterIndex)
        {
            eVehicleRequiredParameters vehicleParameterIndex;
            eTruckRequiredParameters truckParameterIndex;

            Enum.TryParse<eTruckRequiredParameters>(i_ParameterIndex.ToString(), out truckParameterIndex);
            if (Enum.TryParse<eVehicleRequiredParameters>(i_ParameterIndex.ToString(), out vehicleParameterIndex))
            {
                SetBaseVehicleRequiredParametersWrapper(i_ParameterToSet, i_ParameterIndex, k_NumberOfTruckWheels, k_MaximumWheelAirPressure);
            }

            switch (truckParameterIndex)
            {
                case eTruckRequiredParameters.CargoVolume:
                    {
                        CargoVolume = i_ParameterToSet;
                        break;
                    }

                case eTruckRequiredParameters.IsTransportingHazardousMaterials:
                    {
                        IsTransportingHazardousMaterials = i_ParameterToSet;
                        break;
                    }
            }
        }

        public override void RegisterClass()
        {
            base.RegisterClass();
            if (!BsonClassMap.IsClassMapRegistered(typeof(Truck)))
            {
                BsonClassMap.RegisterClassMap<Truck>(cm =>
                {
                    cm.MapField(c => c.m_CargoVolume).SetElementName("CargoVolume");
                    cm.MapField(c => c.m_IsTransportingHazardousMaterials).SetElementName("IsTransportingHazardousMaterials");
                });
            }
        }
    }
}
