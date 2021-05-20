using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        public enum eEngineType
        {
            ElectircalEngine,
            InternalCombustionEngine
        }

        private string m_ModelName;
        private string m_LicenseNumber;
        protected float m_EnergyPrecentLeft;
        protected Engine m_Engine;
        private List<Wheel> m_Wheels;

        public string ModelName
        {
            get
            {
                return m_ModelName;
            }
            set
            {
                m_ModelName = value;
            }
        }
        public string LicenseNumber
        {
            get
            {
                return m_LicenseNumber;
            }
            set
            {
                m_LicenseNumber = value;
            }
        }
        public float EnergyPrecentLeft
        {
            get
            {
                return m_EnergyPrecentLeft;
            }
            set
            {
                m_EnergyPrecentLeft = value;
            }
        }
         public Engine Engine
        {
            get
            {
                return m_Engine;
            }
        }
        public Vehicle(string i_LicenseNumber, int i_NumberOfWheels, float i_MaxAirPressure)
        {
            m_LicenseNumber = i_LicenseNumber;
            m_Wheels = new List<Wheel>();
           
            for (int i = 0; i < i_NumberOfWheels; i++)
            {
                m_Wheels.Add( new Wheel(i_MaxAirPressure));
            }
        }

        public virtual Dictionary<string, string> BuildProperties()
        {
            Dictionary<string, string> vehicleProperties = new Dictionary<string, string>();
            vehicleProperties.Add("ModelName", null);
            vehicleProperties = vehicleProperties.Concat(m_Wheels[0].BuildProperties()).ToDictionary(e => e.Key, e => e.Value);
            vehicleProperties = vehicleProperties.Concat(m_Engine.BuildProperties()).ToDictionary(e => e.Key, e => e.Value);
            return vehicleProperties;

        }

        public virtual Dictionary<string, string> GetProperties()
        {
            Dictionary<string, string> vehicleProperties = new Dictionary<string, string>();
            vehicleProperties.Add("ModelName", m_ModelName);
            vehicleProperties.Add("Energy Precent Left", m_EnergyPrecentLeft.ToString());
            vehicleProperties = vehicleProperties.Concat(m_Wheels[0].GetProperties()).ToDictionary(e => e.Key, e => e.Value);
            vehicleProperties = vehicleProperties.Concat(m_Engine.GetProperties()).ToDictionary(e => e.Key, e => e.Value);
            return vehicleProperties;
        }

        public virtual void SetAllVehicleProperties(Dictionary<string, string> i_VehicleProperties)
        {
            float  energyPrecentLeft;
            
            m_ModelName = i_VehicleProperties["ModelName"];
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.SetAllWheelProperties(i_VehicleProperties);
            }

            m_Engine.SetAllEngineProperties(i_VehicleProperties);
            m_EnergyPrecentLeft = m_Engine.CalculatePrecentsOfEnergtLeft();
        }
        public virtual bool ValidateVehicleProperties(Dictionary<string, string> i_VehicleProperties)
        {
            bool isValid = true;

            if (i_VehicleProperties["ModelName"].Length < 1)
            {
                throw new FormatException("Model Name is empty");
            }


            return isValid;
        }

        public void Inflate()
        {
            foreach(Wheel wheel in m_Wheels)
            {
                wheel.Inflate();
            }
        }
       
        public virtual void check()
        {
            Console.WriteLine(m_ModelName);
            Console.WriteLine(m_LicenseNumber);
            Console.WriteLine(m_EnergyPrecentLeft);

        }

        public abstract Engine getEngine();
    }
}
