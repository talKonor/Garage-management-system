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

        public ElectircalEngine(float i_BatteryCapacity)
        {
            m_BatteryCapacity = i_BatteryCapacity;
        }

        public void charge(float i_ChargeTimeToAdd) {
            if (m_BatteryTimeLeft + i_ChargeTimeToAdd <= m_BatteryCapacity)
            {
                m_BatteryCapacity += i_ChargeTimeToAdd;
            }
            else
            {
                throw //// TODO 
            }
        }
    }
}
