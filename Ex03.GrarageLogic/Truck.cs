using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Truck : Vehicle
    {
        protected const int k_NumberOWheels = 16;
        protected const float k_MaxAirPressure = 26f;

        private bool m_IsDrivingHazardousMaterials;
        private float m_MaximumCarryingWeight;
        private InternalCombustionEngine m_Engine;

        public Truck(string i_LicenseNumber)
           : base(i_LicenseNumber)
        {
            m_Engine = new InternalCombustionEngine();
            m_Wheels = new List<Wheel>(k_NumberOWheels);
            for (int i = 0; i < k_NumberOWheels; i++)
            {
                m_Wheels[i] = new Wheel(k_MaxAirPressure);
            }
        }
        public override void SetAllVehicleProperties(Dictionary<string, string> i_VehicleProperties)
        {
            base.SetAllVehicleProperties(i_VehicleProperties);
            float.TryParse(i_VehicleProperties["Maximum Carrying Weight"], out m_MaximumCarryingWeight);
            m_IsDrivingHazardousMaterials = i_VehicleProperties["Is Driving Hazardous Materials"] == "True";
            m_Engine.SetAllEngineProperties(i_VehicleProperties);
        }
        public virtual Dictionary<string, string> BuildProperties()
        {
            Dictionary<string, string> properties = base.BuildProperties();
            properties.Concat(m_Engine.BuildProperties());
            properties.Add("Is Driving Hazardous Materials", null);
            properties.Add("Maximum Carrying Weight", null);

            return properties;
        }
    }

}
