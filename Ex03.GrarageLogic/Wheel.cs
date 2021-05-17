using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Wheel
    {
        private string m_WheelManufaturer;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;


        public Wheel(string i_WheelManufaturer, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            m_WheelManufaturer = i_WheelManufaturer;
            m_CurrentAirPressure = i_CurrentAirPressure;
            m_MaxAirPressure = i_MaxAirPressure;
        }
        public void Inflate(float i_Mso) { }
    }
}
