using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class InternalCombustionEngineCar : Car
    {
        private const float k_MaxTankCapacity = 45f;
        private InternalCombustionEngine m_Engine;
        
        public InternalCombustionEngineCar(string i_LicenseNumber)
     : base(i_LicenseNumber)
        {
            m_Engine = new InternalCombustionEngine(k_MaxTankCapacity, InternalCombustionEngine.eFuelType.Octan95);
        }

        public override void SetAllVehicleProperties(Dictionary<string, string> i_VehicleProperties)
        {
            base.SetAllVehicleProperties(i_VehicleProperties);
            m_Engine.SetAllEngineProperties(i_VehicleProperties);
        }

        public virtual Dictionary<string, string> BuildProperties()
        {
            Dictionary<string, string> properties = base.BuildProperties();
            properties.Concat(m_Engine.BuildProperties());

            return properties;
        }

        public virtual bool ValidateVehicleProperties(Dictionary<string, string> i_VehicleProperties)
        {
            return base.ValidateVehicleProperties(i_VehicleProperties) && m_Engine.ValidateEngineProperties(i_VehicleProperties);
        }
    }
}
