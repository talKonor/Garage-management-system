using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class InternalCombustionEngine
    {
        public enum eFuelType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }

        private eFuelType m_FuelType;
        private float m_CurrentAmountOfFuel;
        private float m_MaxTankCapacity; 

        public InternalCombustionEngine(eFuelType i_FuelType, float i_CurrentAmountOfFuel, float i_MaxTankCapacity)
        {
            m_FuelType = i_FuelType;
            m_CurrentAmountOfFuel = i_CurrentAmountOfFuel;
            m_MaxTankCapacity = i_MaxTankCapacity;
        }
        

        void fuel(float i_AmountOfFuelToAdd, eFuelType i_FuelType)
        {
            if(i_AmountOfFuelToAdd + m_CurrentAmountOfFuel <= m_MaxTankCapacity)
            {
                m_CurrentAmountOfFuel += i_AmountOfFuelToAdd;
            }
            else
            {
                throw/// TODO
            }
        }


    }
}
