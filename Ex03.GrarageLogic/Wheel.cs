using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
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
                throw new ValueOutOfRangeException(0, m_MaxAirPressure - m_CurrentAirPressure, "Air to add is over the limit");
            }
        }


        public virtual Dictionary<string, string> BuildProperties()
        {
            Dictionary<string, string> wheelProperties = new Dictionary<string, string>();
            wheelProperties.Add("Wheel - Manufacturer", null);
            wheelProperties.Add("Wheel - Current PSI", null);

            return wheelProperties;
        }

        public virtual void SetAllWheelProperties(Dictionary<string, string> i_VehicleProperties)
        {          
            float.TryParse(i_VehicleProperties["Wheel - Current Air Pressure"], out float currentAirPressuer);
            WheelManufacturer = i_VehicleProperties["Wheel - Manufacture"];
            CurrentAirPressure = currentAirPressuer;
        }

        public bool ValidateWheelProperties(Dictionary<string, string> i_VehicleProperties)
        {
            bool isValid = true;

            if(i_VehicleProperties["Wheel - Current Air Pressure"].Length < 1)
            {
                throw new FormatException("Model Name is empty");
            }

            if (!float.TryParse(i_VehicleProperties["Wheel - Current Air Pressure"], out float currentAirPressure))
            {
                throw new FormatException("Wheel - Current Air Pressure is not a number");
            }

            return isValid;
        }
    }
}
