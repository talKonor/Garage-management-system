using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class ElectircalEngine
    {
        private float m_BatteryTimeLeft;
        private float m_BatteryCapacity;

        public void charge(float i_ChargeTimeToAdd) {
            if (m_BatteryTimeLeft + i_ChargeTimeToAdd <= m_BatteryCapacity)
            {
                m_BatteryCapacity += i_ChargeTimeToAdd;
            }
            else
            {
               // throw //// TODO 
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
    }
}
