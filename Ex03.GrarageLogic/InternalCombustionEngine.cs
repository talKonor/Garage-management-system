using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class InternalCombustionEngine : Engine
    {
        public enum eFuelType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }

        private eFuelType m_FuelType;

        public InternalCombustionEngine(float i_MaxTankCapacity, eFuelType i_FuelType) : base()
        {
            m_EnergyCapacity = i_MaxTankCapacity;
            m_FuelType = i_FuelType;
        }

        public void Fuel(eFuelType i_FuelType, float i_AmountOfFuelToAdd, Vehicle i_VehicleToFuel)
        {
            if (i_FuelType.Equals(m_FuelType))
            {
                if (i_AmountOfFuelToAdd < 0)
                {
                    throw new ArgumentException("Cant add negative amount of fuel");
                }
                if (i_AmountOfFuelToAdd + m_EnergyLeft <= m_EnergyCapacity)
                {
                    m_EnergyLeft += i_AmountOfFuelToAdd;
                    i_VehicleToFuel.EnergyPercentLeft = CalculatePercentOfEnergyLeft();
                }
                else
                {
                    throw new ValueOutOfRangeException(0, m_EnergyCapacity - m_EnergyLeft, "Cant add fuel more than the size of tank");
                }
            }
            else
            {
                throw new ArgumentException("Wrong fuel type");
            }
        }

        public string GetFuelTypesAsString()
        {
            return Utils.getEnumValuesAsString(typeof(eFuelType));
        }

        public static eFuelType GetFuelTypeFromString(string i_FuelTypeAsString)
        {
            Enum.TryParse(i_FuelTypeAsString, true, out eFuelType fuelTypeToReturn);

            return fuelTypeToReturn;
        }

        public override void SetAllEngineProperties(Dictionary<string, string> i_EngineProperties)
        {
            float.TryParse(i_EngineProperties["Current Amount Of Fuel"], out m_EnergyLeft);
        }

        public override Dictionary<string, string> BuildProperties()
        {
            Dictionary<string, string> properties = new Dictionary<string, string>();

            properties.Add("Current Amount Of Fuel", null);

            return properties;
        }

        public override Dictionary<string, string> GetProperties()
        {
            Dictionary<string, string> properties = new Dictionary<string, string>();

            properties.Add("Current Amount Of Fuel", m_EnergyLeft.ToString());
            properties.Add("Max Tank Capacity", m_EnergyCapacity.ToString());
            properties.Add("Fuel Type", m_FuelType.ToString());

            return properties;
        }

        public override bool ValidateEngineProperties(Dictionary<string, string> i_EngineProperties)
        {
            const bool isValid = true;

            if (!float.TryParse(i_EngineProperties["Current Amount Of Fuel"], out float currentAmountOfFuel))
            {
                throw new FormatException("Current Amount Of Fuel is not a number");
            }
            else if (currentAmountOfFuel < 0 || currentAmountOfFuel > m_EnergyCapacity)
            {
                throw new ValueOutOfRangeException(0, m_EnergyCapacity, "Current amount of fuel is out of range");
            }

            return isValid;
        }
    }
}
