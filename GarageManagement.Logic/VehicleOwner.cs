using System;
using MongoDB.Bson.Serialization;

namespace GarageManagement.Logic
{
    public class VehicleOwner
    {
        private string m_Name;
        private string m_PhoneNumber;

        public string Name
        {
            get
            {
                return m_Name;
            }

            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("ERROR. owner name can`t be empty");
                }

                m_Name = value;
            }
        }

        public string PhoneNumber
        {
            set
            {
                long phoneNumber;
                if (!long.TryParse(value, out phoneNumber) || (value.Length != 9 && value.Length != 10))
                {
                    throw new ArgumentException("ERROR. phone number should contain 9 or 10 digits");
                }

                m_PhoneNumber = value;
            }
        }

        internal void RegisterClass()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(VehicleOwner)))
            {
                BsonClassMap.RegisterClassMap<VehicleOwner>(cm =>
                {
                    cm.MapField(c => c.m_Name).SetElementName("Name");
                    cm.MapField(c => c.m_PhoneNumber).SetElementName("PhoneNumber");
                });
            }
        }
    }
}
