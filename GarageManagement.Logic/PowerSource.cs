using System;
using MongoDB.Bson.Serialization;

namespace GarageManagement.Logic
{
    public abstract class PowerSource
    {
        protected float r_MaximumAmountOfEnergy;
        protected float m_AmountOfEnergyLeft;

        protected PowerSource(float i_MaximumAmountOfEnergy)
        {
            r_MaximumAmountOfEnergy = i_MaximumAmountOfEnergy;
        }

        public float AmountOfEnergyLeft
        {
            get
            {
                return m_AmountOfEnergyLeft;
            }
        }

        public void AddToPowerSource(float i_AmountToAdd)
        {
            if(m_AmountOfEnergyLeft == r_MaximumAmountOfEnergy)
            {
                throw new ArgumentException("Power source is full");
            }

            if (i_AmountToAdd + m_AmountOfEnergyLeft > r_MaximumAmountOfEnergy || i_AmountToAdd < 0)
            {
                throw new ValueOutOfRangeException(0, r_MaximumAmountOfEnergy - m_AmountOfEnergyLeft, "ERROR. Values should be between 0 - " + (r_MaximumAmountOfEnergy - m_AmountOfEnergyLeft));
            }

            m_AmountOfEnergyLeft += i_AmountToAdd;
        }

        public void SetPowersourceCurrentValue(string i_CurrentValue)
        {
            float currentValue;
            if (!float.TryParse(i_CurrentValue, out currentValue) || i_CurrentValue.Length == 0)
            {
                throw new FormatException("ERROR. Power source value should be a rational number");
            }

            if (currentValue > r_MaximumAmountOfEnergy || currentValue < 0)
            {
                throw new ValueOutOfRangeException(0, r_MaximumAmountOfEnergy, "ERROR. Power source value sholud be between 0 - " + r_MaximumAmountOfEnergy);
            }

            m_AmountOfEnergyLeft = currentValue;
        }

        internal virtual void RegisterClass()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(PowerSource)))
            {
                BsonClassMap.RegisterClassMap<PowerSource>(cm =>
                {
                    cm.MapField(c => c.m_AmountOfEnergyLeft).SetElementName("AmountOfEnergyLeft");
                    cm.MapField(c => c.r_MaximumAmountOfEnergy).SetElementName("MaximumAmountOfEnergy");
                });
            }
        }
    }
}
