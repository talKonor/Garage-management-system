using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {

        private string m_ModelName;
        private string m_LicenseNumber;
        protected float m_EnergyPercentLeft;
        protected Engine m_Engine;
        private List<Wheel> m_Wheels;

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

        public float EnergyPercentLeft
        {
            get
            {
                return m_EnergyPercentLeft;
            }
            set
            {
                m_EnergyPercentLeft = value;
            }
        }

        public Engine Engine
        {
            get
            {
                return m_Engine;
            }
        }

        protected Vehicle(string i_LicenseNumber, int i_NumberOfWheels, float i_MaxAirPressure)
        {
            m_LicenseNumber = i_LicenseNumber;
            m_Wheels = new List<Wheel>();

            for (int i = 0; i < i_NumberOfWheels; i++)
            {
                m_Wheels.Add(new Wheel(i_MaxAirPressure));
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
            vehicleProperties.Add("Energy Precent Left", m_EnergyPercentLeft.ToString());
            vehicleProperties = vehicleProperties.Concat(m_Wheels[0].GetProperties()).ToDictionary(e => e.Key, e => e.Value);
            vehicleProperties = vehicleProperties.Concat(m_Engine.GetProperties()).ToDictionary(e => e.Key, e => e.Value);

            return vehicleProperties;
        }

        public virtual void SetAllVehicleProperties(Dictionary<string, string> i_VehicleProperties)
        {
            m_ModelName = i_VehicleProperties["ModelName"];
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.SetAllWheelProperties(i_VehicleProperties);
            }

            m_Engine.SetAllEngineProperties(i_VehicleProperties);
            m_EnergyPercentLeft = m_Engine.CalculatePercentOfEnergyLeft();
        }

        public virtual bool ValidateVehicleProperties(Dictionary<string, string> i_VehicleProperties)
        {
            bool isValid = true;

            if (i_VehicleProperties["ModelName"].Length < 1)
            {
                throw new FormatException("Model Name is empty");
            }

            m_Wheels[0].ValidateWheelProperties(i_VehicleProperties);
            m_Engine.ValidateEngineProperties(i_VehicleProperties);

            return isValid;
        }

        public void Inflate()
        {
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.Inflate();
            }
        }
    }
}
