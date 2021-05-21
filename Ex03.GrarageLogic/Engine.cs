using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        protected float m_EnergyLeft;
        protected float m_EnergyCapacity;

        public float EnergyCapacity
        {
            get
            {
                return m_EnergyCapacity;
            }
        }
        public float EnergyLeft
        {
            get
            {
                return m_EnergyLeft;
            }
        }

        public abstract void SetAllEngineProperties(Dictionary<string, string> i_EngineProperties);

        public abstract Dictionary<string, string> BuildProperties();

        public abstract Dictionary<string, string> GetProperties();

        public abstract bool ValidateEngineProperties(Dictionary<string, string> i_VehicleProperties);

        public float CalculatePercentOfEnergyLeft()
        {
            return (m_EnergyLeft / m_EnergyCapacity) * 100;
        }
    }
}

