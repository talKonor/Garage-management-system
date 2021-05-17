using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    abstract class Vehicle
    {
        private string m_Manufacturer;
        private string m_LicenseNumber;
        private float m_EnergyPrecentLeft;
        private List<Wheel> m_Wheels;

        public string Manufacturer
        {
            get
            {
                return m_Manufacturer;
            }
            set
            {
                m_Manufacturer = value;
            }
        }
        public string LicenseNumber
        {
            get
            {
                return m_LicenseNumber;
            }
            set
            {
                m_LicenseNumber = value;
            }
        }
        public float EnergyPrecentLeft
        {
            get
            {
                return m_EnergyPrecentLeft;
            }
            set
            {
                m_EnergyPrecentLeft = value;
            }
        }

        public Vehicle(string i_LicenseNumber)
        {
            m_LicenseNumber = i_LicenseNumber;
        }
    }
}
