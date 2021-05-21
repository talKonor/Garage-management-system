using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class ElectricMotorcycle : Motorcycle
    {
        private const float k_BatteryCapacity = 1.8f;

        public ElectricMotorcycle(string i_LicenseNumber) : base(i_LicenseNumber)
        {
            m_Engine = new ElectricEngine(k_BatteryCapacity);
        }
    }
}
