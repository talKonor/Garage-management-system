using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    abstract class Motorcycle : Vehicle
    {
        enum eLicenceType
        {
            A,
            B1,
            AA,
            BB
        }
        private eLicenceType m_LicenceType;
        private int m_EngineCapacity;
    }
}
