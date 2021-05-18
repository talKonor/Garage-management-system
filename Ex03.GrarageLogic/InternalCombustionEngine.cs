using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class InternalCombustionEngine
    {
        public enum eFuelType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }

        private eFuelType m_FuelType;
        private float m_CurrentAmountOfFuel;
        private float m_MaxTankCapacity;
        

        public InternalCombustionEngine(float i_MaxTankCapacity, eFuelType i_FuelType)
        {
            m_MaxTankCapacity = i_MaxTankCapacity;
            m_FuelType = i_FuelType;
        }
        void fuel(float i_AmountOfFuelToAdd, eFuelType i_FuelType)
        {
            if (i_AmountOfFuelToAdd < 0)
            {
                throw new FormatException("Cant add negative amount of fuel");
            }
            if(i_AmountOfFuelToAdd + m_CurrentAmountOfFuel <= m_MaxTankCapacity)
            {
                m_CurrentAmountOfFuel += i_AmountOfFuelToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException(0, m_MaxTankCapacity-m_CurrentAmountOfFuel, "Cant add fuel more than the size of tank");
            }
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
        public void SetAllEngineProperties(Dictionary<string, string> i_EngineProperties)
        {
            float.TryParse(i_EngineProperties["Current Amount Of Fuel"], out m_CurrentAmountOfFuel);
        }
        public Dictionary<string, string> BuildProperties()
        {
            Dictionary<string, string> properties = new Dictionary<string, string>();
            properties.Add("Current Amount Of Fuel", null);
            return properties;
        }

        public bool ValidateEngineProperties(Dictionary<string, string> i_VehicleProperties)
        {
            bool isValid = true;

            if (!float.TryParse(i_VehicleProperties["Current Amount Of Fuel"], out float currentAmountOfFuel))
            {
                throw new FormatException("Current Amount Of Fuel is not a number");
            }
            else if(currentAmountOfFuel<0 || currentAmountOfFuel > m_MaxTankCapacity)
            {
                throw new ValueOutOfRangeException(0, m_MaxTankCapacity, "Current amount of fuel is out of range");
            }


            return isValid;
        }
    }
}
