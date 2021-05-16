using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Truck: Vehicle
    {
        private bool m_IsDrivingHazardousMaterials;
        private float m_MaximumCarryingWeight;
        private InternalCombustionEngine m_Engine;
    }
}
