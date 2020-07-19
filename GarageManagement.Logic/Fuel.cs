using System.Collections.Generic;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Serializers;

namespace GarageManagement.Logic
{
    public class Fuel : PowerSource
    {
        private eFuelType m_FuelType;

        public enum eFuelType
        {
            Octan95 = 1,
            Octan96,
            Octan98,
            Soler
        }

        public eFuelType FuelType
        {
            get
            {
                return m_FuelType;
            }
        }

        public Fuel(float i_MaximumAmountOfFuel, eFuelType i_FuelType) : base(i_MaximumAmountOfFuel)
        {
            m_FuelType = i_FuelType;
        }

        public static void GetFuelParameters(List<string> io_Parameters)
        {
            io_Parameters.Add("amout of fuel (in liters)");
        }

        internal override void RegisterClass()
        {
            base.RegisterClass();
            if (!BsonClassMap.IsClassMapRegistered(typeof(Fuel)))
            {
                BsonClassMap.RegisterClassMap<Fuel>(cm =>
                {
                    cm.MapField(c => c.m_FuelType).SetElementName("FuelType").SetSerializer(new EnumSerializer<eFuelType>(BsonType.String));
                });
            }
        }
    }
}
