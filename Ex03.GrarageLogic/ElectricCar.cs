using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class ElectricCar : Car 
    {
        private const float k_BatteryCapacity = 3.2f;
       
        public ElectricCar(string i_LicenseNumber)
                : base(i_LicenseNumber)
        {
            m_Engine = new ElectircalEngine(k_BatteryCapacity);
        }

        public override void SetAllVehicleProperties(Dictionary<string, string> i_VehicleProperties)
        {
            base.SetAllVehicleProperties(i_VehicleProperties);

        }
        public override Dictionary<string, string> BuildProperties()
        {
            Dictionary<string, string> vehicleProperties = base.BuildProperties();
            return vehicleProperties;
        }

        public override Dictionary<string, string> GetProperties()
        {
            Dictionary<string, string> vehicleProperties = base.GetProperties();
            return vehicleProperties;
        }

        public override bool ValidateVehicleProperties(Dictionary<string, string> i_VehicleProperties)
        {
            return base.ValidateVehicleProperties(i_VehicleProperties) && m_Engine.ValidateEngineProperties(i_VehicleProperties);
        }

        public override Engine getEngine()
        {
            return m_Engine;
        }
    }
}
