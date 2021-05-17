using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Wheel
    {
        private string m_WheelManufacturer;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;

        public string WheelManufacturer
        {
            get
            {
                return m_WheelManufacturer;
            }
            set
            {
                m_WheelManufacturer = value;
            }
        }
        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }
            set
            {
                m_CurrentAirPressure = value;
            }
        }
        public float MaxAirPressure
        {
            get
            {
                return m_MaxAirPressure;
            }
            set
            {
                m_MaxAirPressure = value;
            }
        }
        public Wheel(float i_MaxAirPressure)
        {
            m_MaxAirPressure = i_MaxAirPressure;
        }
        public Wheel Clone()
        {
            Wheel clonedWheel = new Wheel(m_MaxAirPressure);
            clonedWheel.m_WheelManufacturer = m_WheelManufacturer;
            return clonedWheel; 
        }
        public void Inflate(float i_AirToAdd) {
            if (m_CurrentAirPressure + i_AirToAdd <= m_MaxAirPressure)
            {
                m_CurrentAirPressure += i_AirToAdd;
            }
            else
            {
                //throw //outofrangeexception
            }
        }
    }
}
