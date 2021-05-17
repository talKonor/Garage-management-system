using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class ElectricCar : Car 
    {
        private ElectircalEngine m_Engine;
       
        public ElectricCar()
        {
            m_Engine = new ElectircalEngine();
        }

        public ElectircalEngine Engine
        {
            get
            {
                return m_Engine;
            }
        }
    }
}
