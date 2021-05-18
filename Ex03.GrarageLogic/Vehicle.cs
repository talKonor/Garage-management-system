using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    abstract class Vehicle
    {
        protected string m_ModelName;
        protected string m_LicenseNumber;
        protected float m_EnergyPrecentLeft;
        protected List<Wheel> m_Wheels;

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

        public Vehicle(string i_LicenseNumber, int i_NumberOfWheels, float i_MaxAirPressure)
        {
            m_LicenseNumber = i_LicenseNumber;
            m_Wheels = new List<Wheel>(i_NumberOfWheels);
           
            for (int i = 0; i < i_NumberOfWheels; i++)
            {
                m_Wheels[i] = new Wheel(i_MaxAirPressure);
            }
        }

        public virtual Dictionary<string, string> BuildProperties()
        {
            Dictionary<string, string> vehicleProperties = new Dictionary<string, string>();
            vehicleProperties.Add("ModelName", null);
            vehicleProperties.Add("Energy Precent Left", null);
            vehicleProperties.Add("Wheel - Manufacturer", null);
            vehicleProperties.Add("Wheel - Current PSI", null);

            return vehicleProperties;
        }
        public virtual void SetAllVehicleProperties(Dictionary<string, string> i_VehicleProperties)
        {
            float currentAirPressuer, energyPrecentLeft;
            float.TryParse(i_VehicleProperties["Wheel - Current PSI"], out currentAirPressuer);
            float.TryParse(i_VehicleProperties["Energy Precent Left"], out energyPrecentLeft);

            m_EnergyPrecentLeft = energyPrecentLeft;
            m_ModelName = i_VehicleProperties["ModelName"];
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.SetAllWheelProperties(i_VehicleProperties);
            }
        }
        public virtual bool ValidateVehicleProperties(Dictionary<string, string> i_VehicleProperties)
        {
            float checkEnergyPrecentLeft;
            bool isValid = true;

            if (i_VehicleProperties["ModelName"].Length < 1)
            {
                throw new FormatException("Model Name is empty");
            }
            if (!(float.TryParse(i_VehicleProperties["Energy Precent Left"], out checkEnergyPrecentLeft)))
            {
                throw new FormatException("Energy Precent Left is not a number");

            }
            else if (checkEnergyPrecentLeft < 0 || checkEnergyPrecentLeft > 100)
            {
                throw new ValueOutOfRangeException(0, 100, "Energy Precentage is out of range");
            }


            return isValid;
        }
    }
}
