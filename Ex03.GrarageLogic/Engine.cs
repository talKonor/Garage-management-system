using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        protected float m_EnergeyLeft;
        protected float m_EnergeyCapacity; 

        public float EnergeyCapacity
        {
            get
            {
                return m_EnergeyCapacity;
            }
        }
        public float EnergeyLeft
        {
            get
            {
                return m_EnergeyLeft;
            }
        }

        public abstract void SetAllEngineProperties(Dictionary<string, string> i_EngineProperties);
        public abstract Dictionary<string, string> BuildProperties();

        public abstract Dictionary<string, string> GetProperties();

        public abstract bool ValidateEngineProperties(Dictionary<string, string> i_VehicleProperties);

        public float CalculatePrecentsOfEnergtLeft()
        {
            return (m_EnergeyLeft / m_EnergeyCapacity) * 100;
        }
    }
}

