using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class ElectricMotorcycle : Motorcycle
    {
        private ElectircalEngine m_Engine;


        public ElectricMotorcycle(string i_LicenseNumber) :
            base(i_LicenseNumber)
        {
            m_Engine = new ElectircalEngine();
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

        public virtual Dictionary<string, string> BuildProperties()
        {
            Dictionary<string, string> properties = base.BuildProperties();
            properties.Concat(m_Engine.BuildProperties());

            return properties;
        }
    }
}
