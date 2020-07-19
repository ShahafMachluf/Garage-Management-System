using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace GarageManagement.Logic
{
    public class Motorcycle : Vehicle
    {
        private const Fuel.eFuelType k_MotorcycleFuelType = Fuel.eFuelType.Octan95;
        private const float k_MaximumBatteryTime = 1.2f;
        private const float k_MaximumAmountOfFuel = 7;
        private const int k_NumberOfLicenseType = 4;
        private const int k_NumberOfMotorcycleWheels = 2;
        private const float k_MaximumWheelAirPressure = 30;
        private eMotorcycleLicense m_LicenseType;
        private int m_EngineCapacity;

        public enum eMotorcycleLicense
        {
            A = 1,
            A1,
            AA,
            B
        }

        public enum eMotorcycleRequiredParameters
        {
            LicenseType = 7,
            EngineCapacity
        }

        public Motorcycle(string i_LicensePlateNumber, VehicleCreator.eVehiclesTypes i_VehicleType) : base(i_LicensePlateNumber)
        {
            if(i_VehicleType == VehicleCreator.eVehiclesTypes.ElectricMotorcycle)
            {
                m_PowerSource = new Battery(k_MaximumBatteryTime);
            }
            else if(i_VehicleType == VehicleCreator.eVehiclesTypes.FuelMotorcycle)
            {
                m_PowerSource = new Fuel(k_MaximumAmountOfFuel, k_MotorcycleFuelType);
            }
        }

        public string EngineCapacity
        {
            get
            {
                return m_EngineCapacity.ToString();
            }

            set
            {
                int parsedValue;

                if (!int.TryParse(value, out parsedValue))
                {
                    throw new FormatException("ERROR. Engine capacity should be an integer number");
                }

                if(parsedValue <= 0)
                {
                    throw new ArgumentException("ERROR. Engine capacity should be grater then zero");
                }

                m_EngineCapacity = parsedValue;
            }
        }

        public string LicenseType
        {
            get
            {
                return m_LicenseType.ToString();
            }

            set
            {
                int parsedValue;
                if(!int.TryParse(value, out parsedValue))
                {
                    throw new FormatException("ERROR. License type should be a number from the list");
                }

                if (!Enum.IsDefined(typeof(eMotorcycleLicense), parsedValue))
                {
                    throw new ValueOutOfRangeException(1, k_NumberOfLicenseType, "ERROR. License type should be choosen from 1 - " + k_NumberOfLicenseType);
                }

                Enum.TryParse(value, out m_LicenseType);
            }
        }

        public override void AddToPowerSource(float i_AmountToAdd)
        {
            m_PowerSource.AddToPowerSource(i_AmountToAdd);
        }

        public override List<string> GetVehicleFullDetailes()
        {
            List<string> vehicleDetailes = GetVehicleBaseDetailes();
            vehicleDetailes.Add("License type: " + m_LicenseType.ToString());
            vehicleDetailes.Add("Engine Capacity: " + m_EngineCapacity.ToString());
            if (m_PowerSource is Fuel)
            {
                vehicleDetailes.Add("Power source type: fuel");
            }
            else if (m_PowerSource is Battery)
            {
                vehicleDetailes.Add("Power source type: battery");
            }

            return vehicleDetailes;
        }

        public override List<string> GetVehicleRequiredParameters()
        {
            List<string> baseParameters = GetBaseVehicleRequiredParameters();
            string chooseLicenseTypeMessege;

            if (m_PowerSource is Fuel)
            {
                Fuel.GetFuelParameters(baseParameters);
            }
            else if (m_PowerSource is Battery)
            {
                Battery.GetBatteryParameters(baseParameters);
            }

            chooseLicenseTypeMessege = string.Format(@"select motorcycle license:
1. A
2. A1
3. AA
4. B");
            baseParameters.Add(chooseLicenseTypeMessege);
            baseParameters.Add("engine capacity");

            return baseParameters;
        }

        public override void SetVehicleRequiredParameters(string i_ParameterToSet, int i_ParameterIndex)
        {
            eVehicleRequiredParameters vehicleParameterIndex;
            eMotorcycleRequiredParameters motorcycleParameterIndex;

            Enum.TryParse<eMotorcycleRequiredParameters>(i_ParameterIndex.ToString(), out motorcycleParameterIndex);
            if (Enum.TryParse<eVehicleRequiredParameters>(i_ParameterIndex.ToString(), out vehicleParameterIndex))
            {
                SetBaseVehicleRequiredParametersWrapper(i_ParameterToSet, i_ParameterIndex, k_NumberOfMotorcycleWheels, k_MaximumWheelAirPressure);
            }

            switch (motorcycleParameterIndex)
            {
                case eMotorcycleRequiredParameters.LicenseType:
                    {
                        LicenseType = i_ParameterToSet;
                        break;
                    }

                case eMotorcycleRequiredParameters.EngineCapacity:
                    {
                        EngineCapacity = i_ParameterToSet;
                        break;
                    }
            }
        }

        public override void UpdatePercentageOfEnergy()
        {
            float fullCapacityValue;

            if (m_PowerSource is Fuel)
            {
                fullCapacityValue = k_MaximumAmountOfFuel;
            }
            else
            {
                fullCapacityValue = k_MaximumBatteryTime;
            }

            m_PercentageOfEnergy = m_PowerSource.AmountOfEnergyLeft / fullCapacityValue * 100;
        }

        public override void RegisterClass()
        {
            base.RegisterClass();
            if (!BsonClassMap.IsClassMapRegistered(typeof(Motorcycle)))
            {
                BsonClassMap.RegisterClassMap<Motorcycle>(cm =>
                {
                    cm.MapField(c => c.m_EngineCapacity).SetElementName("EngineCapacity");
                    cm.MapField(c => c.m_LicenseType).SetElementName("LicenseType").SetSerializer(new EnumSerializer<eMotorcycleLicense>(BsonType.String));
                });
            }
        }
    }
}
