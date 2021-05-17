using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class InternalCombustionEngine
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
        

        void fuel(float i_AmountOfFuelToAdd, eFuelType i_FuelType)
        {
            if(i_AmountOfFuelToAdd + m_CurrentAmountOfFuel <= m_MaxTankCapacity)
            {
                m_CurrentAmountOfFuel += i_AmountOfFuelToAdd;
            }
            else
            {
                //throw/// TODO
            }
        }

        private eFuelType getFuelTypeFromString(string i_FuelTypeAsString)
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
                    throw Exception;
                    break;
            }

            return fuelTypeToReturn;
        }
        public void SetAllEngineProperties(Dictionary<string, string> i_EngineProperties)
        {
            m_FuelType = getFuelTypeFromString(i_EngineProperties["Fuel Type"]);
            float.TryParse(i_EngineProperties["Current Amount Of Fuel"], out m_CurrentAmountOfFuel);
            float.TryParse(i_EngineProperties["Max Tank Capacity"], out m_MaxTankCapacity);
        }
        public Dictionary<string, string> BuildProperties()
        {
            Dictionary<string, string> properties = new Dictionary<string, string>();
            properties.Add("Fuel Type", null);
            properties.Add("Current Amount Of Fuel", null);
            properties.Add("Max Tank Capacity", null);
            return properties;
        }
    }
}
