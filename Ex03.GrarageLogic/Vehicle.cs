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

        public Vehicle(string i_LicenseNumber)
        {
            m_LicenseNumber = i_LicenseNumber;
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
            float currentAirPressuer,energyPrecentLeft;
            float.TryParse(i_VehicleProperties["Wheel - Current PSI"], out currentAirPressuer);
            float.TryParse(i_VehicleProperties["Energy Precent Left"], out ene rgyPrecentLeft);

           m_EnergyPrecentLeft = energyPrecentLeft;
           m_ModelName = i_VehicleProperties["ModelName"];
            foreach(Wheel wheel in m_Wheels)
            {
                wheel.WheelManufacturer = i_VehicleProperties["Wheel - Manufacture"];
                wheel.CurrentAirPressure = currentAirPressuer;
            }
        }
    }
}
