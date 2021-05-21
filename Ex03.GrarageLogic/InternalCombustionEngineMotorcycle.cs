using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class InternalCombustionEngineMotorcycle : Motorcycle
    {
        private const float k_MaxTankCapacity = 6f;
        private const InternalCombustionEngine.eFuelType k_FuelType = InternalCombustionEngine.eFuelType.Octan98;
        public InternalCombustionEngineMotorcycle(string i_LicenseNumber)
           : base(i_LicenseNumber)
        {
            m_Engine = new InternalCombustionEngine(k_MaxTankCapacity, k_FuelType);
        }
    }
}
