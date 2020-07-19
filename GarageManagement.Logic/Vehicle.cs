using System;
using System.Collections.Generic;
using System.ComponentModel;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson;

namespace GarageManagement.Logic
{
    public abstract class Vehicle
    {
        private const int k_NumberOfRequiredParametersToSet = 3;
        protected string r_LicensePlateNumber;
        protected string m_ModelName;
        protected float m_PercentageOfEnergy;
        protected Wheel[] m_Wheels;
        protected VehicleOwner m_OwnerDetailes;
        protected eRepairStatus m_Status;
        protected PowerSource m_PowerSource;
        protected DateTime m_TimeOfEnteringToGarage;

        public class Wheel
        {
            private float r_MaximumAirPressure;
            private string m_ManufacturerName;
            private float m_CurrentAirPressure;

            public Wheel(float i_MaximumAirPressure)
            {
                r_MaximumAirPressure = i_MaximumAirPressure;
            }

            public string ManufacturerName
            {
                get
                {
                    return m_ManufacturerName;
                }

                set
                {
                    if (value.Length == 0)
                    {
                        throw new ArgumentException("ERROR. wheel manufactor name can't be empty");
                    }

                    m_ManufacturerName = value;
                }
            }

            public string CurrentAirPressure
            {
                get
                {
                    return m_CurrentAirPressure.ToString();
                }

                set
                {
                    float currentAirPresure;
                    if (!float.TryParse(value, out currentAirPresure))
                    {
                        throw new FormatException("ERROR. current air presure should be rational positive number");
                    }

                    if (currentAirPresure > r_MaximumAirPressure || currentAirPresure < 0)
                    {
                        throw new ValueOutOfRangeException(0, r_MaximumAirPressure, "ERROR. current wheel air presure should be between 0 to " + r_MaximumAirPressure);
                    }

                    m_CurrentAirPressure = currentAirPresure;
                }
            }

            public float MaximumAirPressure
            {
                get
                {
                    return r_MaximumAirPressure;
                }
            }

            public void AddAir(float i_AmountOfAir)
            {
                if ((m_CurrentAirPressure + i_AmountOfAir > r_MaximumAirPressure) || i_AmountOfAir < 0)
                {
                    throw new ValueOutOfRangeException(0, r_MaximumAirPressure - m_CurrentAirPressure, "ERROR. Value to add should be between 0 - " + (r_MaximumAirPressure - m_CurrentAirPressure));
                }

                m_CurrentAirPressure += i_AmountOfAir;
            }

            public Wheel ShallowCopy()
            {
                return (Wheel)this.MemberwiseClone();
            }

            internal void RegisterClass()
            {
                if (!BsonClassMap.IsClassMapRegistered(typeof(Wheel)))
                {
                    BsonClassMap.RegisterClassMap<Vehicle.Wheel>(cm =>
                    {
                        cm.MapField(c => c.m_ManufacturerName).SetElementName("ManufacturerName");
                        cm.MapField(c => c.m_CurrentAirPressure).SetElementName("CurrentAirPressure");
                        cm.MapField(c => c.r_MaximumAirPressure).SetElementName("MaximumAirPressure");
                    });
                }
            }
        }

        public enum eRepairStatus
        {
            [Description("In Repair")]
            InRepair = 1,
            [Description("RepairEd")]
            Repaired,
            Paied
        }

        public enum eVehicleRequiredParameters
        {
            CarModel = 1,
            OwnerName,
            OwnerPhoneNumber,
            WheelManufactor,
            WheelAirPresure,
            AmoutOfEnergyInPowerSource
        }

        protected Vehicle(string i_LicensePlateNumber)
        {
            r_LicensePlateNumber = i_LicensePlateNumber;
            m_Status = eRepairStatus.InRepair;
            m_TimeOfEnteringToGarage = DateTime.Now;
        }

        public override int GetHashCode()
        {
            return r_LicensePlateNumber.GetHashCode();
        }

        public float PercentageOfEnergy
        {
            get
            {
                return m_PercentageOfEnergy;
            }
        }

        public string ModelName
        {
            set
            {
                if(value.Length == 0)
                {
                    throw new ArgumentException("ERROR. model name can`t be empty", m_ModelName);
                }

                m_ModelName = value;
            }
        }

        public void FillAllWheels()
        {
            float amountOfAir;
            foreach(Wheel wheel in m_Wheels)
            {
                amountOfAir = wheel.MaximumAirPressure - float.Parse(wheel.CurrentAirPressure);
                wheel.AddAir(amountOfAir);
            }
        }

        public string LicensePlateNumber
        {
            get
            {
                return r_LicensePlateNumber;
            }
        }

        public eRepairStatus Status
        {
            get
            {
                return m_Status;
            }

            set
            {
                m_Status = value;
            }
        }

        public PowerSource GetPowerSource()
        {
            return m_PowerSource;
        }

        public List<string> GetVehicleBaseDetailes()
        {
            List<string> vehicleDetailes = new List<string>();
            string wheelManufactor;
            float wheelAirPresure;

            vehicleDetailes.Add("License plate number: " + r_LicensePlateNumber);
            vehicleDetailes.Add("Model name: " + m_ModelName);
            vehicleDetailes.Add("Owner name: " + m_OwnerDetailes.Name);
            vehicleDetailes.Add("Vehicle status: " + m_Status.ToString());
            vehicleDetailes.Add("Number of wheels: " + m_Wheels.Length.ToString());
            wheelManufactor = m_Wheels[0].ManufacturerName;
            wheelAirPresure = float.Parse(m_Wheels[0].CurrentAirPressure);
            vehicleDetailes.Add("Wheels manufactor: " + wheelManufactor);
            vehicleDetailes.Add("Wheels air presure: " + wheelAirPresure.ToString());
            vehicleDetailes.Add("Percentage of energey: " + m_PercentageOfEnergy.ToString());
            vehicleDetailes.Add("Time of entering to garage: " + m_TimeOfEnteringToGarage.ToString("dd-MM-yyyy HH:mm"));

            return vehicleDetailes;
        }

        public List<string> GetBaseVehicleRequiredParameters()
        {
            List<string> parameters = new List<string>();

            parameters.Add("vehicle model");
            parameters.Add("owner name");
            parameters.Add("owner phone number");
            parameters.Add("wheel manufactor");
            parameters.Add("wheel air presure");

            return parameters;
        }

        public void SetBaseVehicleRequiredParameters(string i_ParameterToSet, int i_ParameterIndex)
        {
            eVehicleRequiredParameters parameterIndex;

            Enum.TryParse<eVehicleRequiredParameters>(i_ParameterIndex.ToString(), out parameterIndex);
            switch (parameterIndex)
            {
                case eVehicleRequiredParameters.CarModel:
                    {
                        ModelName = i_ParameterToSet;
                        break;
                    }

                case eVehicleRequiredParameters.OwnerName:
                    {
                        m_OwnerDetailes = new VehicleOwner();
                        m_OwnerDetailes.Name = i_ParameterToSet;
                        break;
                    }

                case eVehicleRequiredParameters.OwnerPhoneNumber:
                    {
                        m_OwnerDetailes.PhoneNumber = i_ParameterToSet;
                        break;
                    }

                case eVehicleRequiredParameters.AmoutOfEnergyInPowerSource:
                    {
                        m_PowerSource.SetPowersourceCurrentValue(i_ParameterToSet);
                        UpdatePercentageOfEnergy();
                        break;
                    }
            }
        }

        protected void SetBaseVehicleRequiredParametersWrapper(string i_ParameterToSet, int i_WhichParameter,
    int i_NumberOfVehicleWheels, float i_WheelMaximumAirPresure)
        {
            eVehicleRequiredParameters vehicleParameterIndex;

            Enum.TryParse<eVehicleRequiredParameters>(i_WhichParameter.ToString(), out vehicleParameterIndex);

            switch (vehicleParameterIndex)
            {
                case eVehicleRequiredParameters.CarModel:
                case eVehicleRequiredParameters.OwnerName:
                case eVehicleRequiredParameters.OwnerPhoneNumber:
                case eVehicleRequiredParameters.AmoutOfEnergyInPowerSource:
                    {
                        SetBaseVehicleRequiredParameters(i_ParameterToSet, i_WhichParameter);
                        break;
                    }

                case eVehicleRequiredParameters.WheelManufactor:
                    {
                        m_Wheels = new Vehicle.Wheel[i_NumberOfVehicleWheels];
                        m_Wheels[0] = new Vehicle.Wheel(i_WheelMaximumAirPresure);
                        m_Wheels[0].ManufacturerName = i_ParameterToSet;
                        break;
                    }

                case eVehicleRequiredParameters.WheelAirPresure:
                    {
                        m_Wheels[0].CurrentAirPressure = i_ParameterToSet;
                        for (int i = 1; i < i_NumberOfVehicleWheels; i++)
                        {
                            m_Wheels[i] = m_Wheels[0].ShallowCopy();
                        }

                        break;
                    }
            }
        }

        public bool IsVehicleWorkingOnFuel()
        {
            return m_PowerSource is Fuel;
        }

        public bool IsVehicleWorkingOnBattery()
        {
            return m_PowerSource is Battery;
        }

        public Wheel[] Wheels
        {
            get
            {
                return m_Wheels;
            }
        }

        public abstract void AddToPowerSource(float i_AmountToAdd);

        public abstract List<string> GetVehicleFullDetailes();

        public abstract void UpdatePercentageOfEnergy();

        public abstract List<string> GetVehicleRequiredParameters();

        public abstract void SetVehicleRequiredParameters(string i_ParameterToSet, int i_ParameterIndex);

        public virtual void RegisterClass()
        {
            m_Wheels = new Wheel[1];
            m_Wheels[0] = new Wheel(0);
            m_Wheels[0].RegisterClass();
            m_PowerSource.RegisterClass();
            m_OwnerDetailes = new VehicleOwner();
            m_OwnerDetailes.RegisterClass();
            if (!BsonClassMap.IsClassMapRegistered(typeof(Vehicle)))
            {
                BsonClassMap.RegisterClassMap<Vehicle>(cm =>
                {
                    cm.SetIdMember(cm.MapField(c => c.r_LicensePlateNumber).SetElementName("LicensePlateNumber"));
                    cm.MapField(c => c.m_ModelName).SetElementName("ModelName");
                    cm.MapField(c => c.m_OwnerDetailes).SetElementName("OwnerDetailes");
                    cm.MapField(c => c.m_PercentageOfEnergy).SetElementName("PercentageOfEnergy");
                    cm.MapField(c => c.m_PowerSource).SetElementName("PowerSource");
                    cm.MapField(c => c.m_Status).SetElementName("Status").SetSerializer(new EnumSerializer<eRepairStatus>(BsonType.String));
                    cm.MapField(c => c.m_Wheels).SetElementName("Wheels");
                    cm.MapField(c => c.m_TimeOfEnteringToGarage).SetElementName("TimeOfEnteringToGarage");
                });
            }
        }
    }
}