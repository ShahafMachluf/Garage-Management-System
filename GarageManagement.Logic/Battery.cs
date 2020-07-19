using System.Collections.Generic;
using MongoDB.Bson.Serialization;

namespace GarageManagement.Logic
{
    public class Battery : PowerSource
    {
        public Battery(float i_MaximumBatteryTime) : base(i_MaximumBatteryTime)
        {
        }

        public static void GetBatteryParameters(List<string> io_Parameters)
        {
            io_Parameters.Add("time left in battery (in hours)");
        }

        internal override void RegisterClass()
        {
            base.RegisterClass();
            if (!BsonClassMap.IsClassMapRegistered(typeof(Battery)))
            {
                BsonClassMap.RegisterClassMap<Battery>();
            }
        }
    }
}
