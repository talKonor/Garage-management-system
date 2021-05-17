using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class ElectricMotorcycle : Motorcycle
    {
        private ElectircalEngine m_Engine;

        public ElectircalEngine Engine
        {
            get
            {
                return m_Engine;
            }
        }
    }
}
