using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectircalEngine
    {
        private float m_BatteryTimeLeft;
        private float m_BatteryCapacity;


        public ElectircalEngine(float i_BatteryCapacity)
        {
            m_BatteryCapacity = i_BatteryCapacity;
        }
        public void charge(float i_ChargeTimeToAdd) {
            if (i_ChargeTimeToAdd < 0)
            {
                throw new FormatException("Cant add negative amount of charge time");
            }
            if (m_BatteryTimeLeft + i_ChargeTimeToAdd <= m_BatteryCapacity)
            {
                m_BatteryCapacity += i_ChargeTimeToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException(0, m_BatteryCapacity-m_BatteryTimeLeft, "total charge time is over the limit");
            }
        }
        public  void SetAllEngineProperties(Dictionary<string, string> i_EngineProperties)
        {
            float.TryParse(i_EngineProperties["Battery Time Left"], out m_BatteryTimeLeft);
            float.TryParse(i_EngineProperties["Battery Capacity"], out m_BatteryCapacity);
        }
        public Dictionary<string, string> BuildProperties()
        {
            Dictionary<string, string> properties = new Dictionary<string, string>();
            properties.Add("Battery Time Left", null);
            properties.Add("Battery Capacity", null);
            return properties;
        }


        public bool ValidateEngineProperties(Dictionary<string, string> i_VehicleProperties)
        {
            bool isValid = true;

            if (!float.TryParse(i_VehicleProperties["Battery Time Left"], out float batteryTimeLeft))
            {
                throw new FormatException("Battery Time Left is not a number");
            }
            if (!float.TryParse(i_VehicleProperties["Battery Capacity"], out float batteryCapacity))
            {
                throw new FormatException("Battery Capacity is not a number");
            }


            return isValid;
        }
    }
}
