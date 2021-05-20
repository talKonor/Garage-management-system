using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class ElectricMotorcycle : Motorcycle
    {
        private const float k_BatteryCapacity = 1.8f;
        private ElectircalEngine m_Engine;

        public ElectricMotorcycle(string i_LicenseNumber) :
            base(i_LicenseNumber)
        {
            m_Engine = new ElectircalEngine(k_BatteryCapacity);
        }
        public ElectircalEngine Engine
        {
            get
            {
                return m_Engine;
            }
        }
        public override void SetAllVehicleProperties(Dictionary<string, string> i_VehicleProperties)
        {
            base.SetAllVehicleProperties(i_VehicleProperties);
            m_Engine.SetAllEngineProperties(i_VehicleProperties);
        }

        public override Dictionary<string, string> BuildProperties()
        {
            Dictionary<string, string> vehicleProperties = base.BuildProperties();
            vehicleProperties = vehicleProperties.Concat(m_Engine.BuildProperties()).ToDictionary(e => e.Key, e => e.Value);

            return vehicleProperties;
        }
        public override Dictionary<string, string> GetProperties()
        {
            Dictionary<string, string> vehicleProperties = base.GetProperties();
            vehicleProperties = vehicleProperties.Concat(m_Engine.GetProperties()).ToDictionary(e => e.Key, e => e.Value);

            return vehicleProperties;
        }
        public override bool ValidateVehicleProperties(Dictionary<string, string> i_VehicleProperties)
        {
            return  base.ValidateVehicleProperties(i_VehicleProperties) && m_Engine.ValidateEngineProperties(i_VehicleProperties);

        }
        public override eEngineType GetEngineType()
        {
            return m_Engine.GetEngineType();
        }
        public override Engine getEngine()
        {
            return m_Engine;
        }
    }
}
