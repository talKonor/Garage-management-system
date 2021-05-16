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
    }
}
