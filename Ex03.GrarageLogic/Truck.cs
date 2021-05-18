using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        protected const int k_NumberOWheels = 16;
        protected const float k_MaxAirPressure = 26f;
        protected const float k_MaxTankCapacity = 120f;

        private bool m_IsDrivingHazardousMaterials;
        private float m_MaximumCarryingWeight;
        private InternalCombustionEngine m_Engine;

        public Truck(string i_LicenseNumber)
           : base(i_LicenseNumber, k_NumberOWheels, k_MaxAirPressure)
        {
            m_Engine = new InternalCombustionEngine(k_MaxTankCapacity,InternalCombustionEngine.eFuelType.Soler);

        }
        public override void SetAllVehicleProperties(Dictionary<string, string> i_VehicleProperties)
        {
            base.SetAllVehicleProperties(i_VehicleProperties);
            float.TryParse(i_VehicleProperties["Maximum Carrying Weight"], out m_MaximumCarryingWeight);
            m_IsDrivingHazardousMaterials = i_VehicleProperties["Is Driving Hazardous Materials"] == "Yes";
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

        public virtual bool ValidateVehicleProperties(Dictionary<string, string> i_VehicleProperties)
        {
            bool isValid = base.ValidateVehicleProperties(i_VehicleProperties);

            if (!float.TryParse(i_VehicleProperties["Maximum Carrying Weight"], out float maximumCarryingWeight))
            {
                throw new FormatException("Maximum Carrying Weight is not a number");
            }

            if(i_VehicleProperties["Is Driving Hazardous Materials"]!="Yes" && i_VehicleProperties["Is Driving Hazardous Materials"] != "No")
            {
                throw new FormatException("Is Driving Hazardous Materials is not 'Yes' or 'No'");
            }


            return isValid;
        }
    }

}
