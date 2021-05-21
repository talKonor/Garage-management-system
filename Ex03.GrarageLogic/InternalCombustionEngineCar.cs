using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class InternalCombustionEngineCar : Car
    {
        private const float k_MaxTankCapacity = 45f;
        private const InternalCombustionEngine.eFuelType k_FuelType = InternalCombustionEngine.eFuelType.Octan95;

        public InternalCombustionEngineCar(string i_LicenseNumber) : base(i_LicenseNumber)
        {
            m_Engine = new InternalCombustionEngine(k_MaxTankCapacity, k_FuelType);
        }
    }
}
