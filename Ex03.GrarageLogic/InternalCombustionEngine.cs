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


        public float CurrentAmountOfFuel
        {
            get
            {
                return m_EnergeyLeft;
            }
        }
        public float MaxTankCapacity
        {
            get
            {
                return m_EnergeyCapacity;
            }
        }

        public InternalCombustionEngine(float i_MaxTankCapacity, eFuelType i_FuelType) : base()
        {
            m_EnergeyCapacity = i_MaxTankCapacity;
            m_FuelType = i_FuelType;
        }
        public void Fuel(eFuelType i_FuelType, float i_AmountOfFuelToAdd,Vehicle i_VehicleToFuel)
        {
            if (i_FuelType.Equals(m_FuelType))
            {
                if (i_AmountOfFuelToAdd < 0)
                {
                    throw new ArgumentException("Cant add negative amount of fuel");
                }
                if (i_AmountOfFuelToAdd + m_EnergeyLeft <= m_EnergeyCapacity)
                {
                    m_EnergeyLeft += i_AmountOfFuelToAdd;
                    i_VehicleToFuel.EnergyPrecentLeft = CalculatePrecentsOfEnergtLeft();
                }
                else
                {
                    throw new ValueOutOfRangeException(0, m_EnergeyCapacity - m_EnergeyLeft, "Cant add fuel more than the size of tank");
                }
            }
            else
            {
                throw new ArgumentException("Wrong fuel type");
            }
        }

        public string getFuelTypesAsString()
        {
            return Utils.getEnumValuesAsString(typeof(eFuelType));
        }
        public static eFuelType getFuelTypeFromString(string i_FuelTypeAsString)
        {
            eFuelType fuelTypeToReturn;
            switch (i_FuelTypeAsString)
            {
                case "Soler":
                    fuelTypeToReturn = eFuelType.Soler;
                    break;
                case "Octan95":
                    fuelTypeToReturn = eFuelType.Octan95;
                    break;
                case "Octan96":
                    fuelTypeToReturn = eFuelType.Octan96;
                    break;
                case "Octan98":
                    fuelTypeToReturn = eFuelType.Octan98;
                    break;
                default:
                    throw new FormatException("Fuel type not found in list");
                    break;
            }

            return fuelTypeToReturn;
        }
        public override void SetAllEngineProperties(Dictionary<string, string> i_EngineProperties)
        {
            float.TryParse(i_EngineProperties["Current Amount Of Fuel"], out m_EnergeyLeft);
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
            properties.Add("Current Amount Of Fuel", m_EnergeyLeft.ToString());
            properties.Add("Max Tank Capacity", m_EnergeyCapacity.ToString());
            properties.Add("Fuel Type", m_FuelType.ToString());
            return properties;
        }

        public override bool ValidateEngineProperties(Dictionary<string, string> i_VehicleProperties)
        {
            bool isValid = true;

            if (!float.TryParse(i_VehicleProperties["Current Amount Of Fuel"], out float currentAmountOfFuel))
            {
                throw new FormatException("Current Amount Of Fuel is not a number");
            }
            else if (currentAmountOfFuel < 0 || currentAmountOfFuel > m_EnergeyCapacity)
            {
                throw new ValueOutOfRangeException(0, m_EnergeyCapacity, "Current amount of fuel is out of range");
            }


            return isValid;
        }

    }
}
