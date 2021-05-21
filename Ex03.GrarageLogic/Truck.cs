using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle
    {
        protected const int k_NumberOWheels = 16;
        protected const float k_MaxAirPressure = 26f;
        protected const float k_MaxTankCapacity = 120f;
        private const InternalCombustionEngine.eFuelType k_FuelType = InternalCombustionEngine.eFuelType.Soler;
        
        private bool m_IsDrivingHazardousMaterials;
        private float m_MaximumCarryingWeight;

        public Truck(string i_LicenseNumber)
           : base(i_LicenseNumber, k_NumberOWheels, k_MaxAirPressure)
        {
            m_Engine = new InternalCombustionEngine(k_MaxTankCapacity, k_FuelType);
        }
        
        public override void SetAllVehicleProperties(Dictionary<string, string> i_VehicleProperties)
        {
            base.SetAllVehicleProperties(i_VehicleProperties);
            float.TryParse(i_VehicleProperties["Maximum Carrying Weight"], out m_MaximumCarryingWeight);
            
            m_IsDrivingHazardousMaterials = i_VehicleProperties["Is Driving Hazardous Materials"] == "Yes";
        }
        
        public override Dictionary<string, string> BuildProperties()
        {
            Dictionary<string, string> vehicleProperties = base.BuildProperties();
           
            vehicleProperties.Add("Is Driving Hazardous Materials", "Yes, No");
            vehicleProperties.Add("Maximum Carrying Weight", null);

            return vehicleProperties;
        }

        public override Dictionary<string, string> GetProperties()
        {
            Dictionary<string, string> vehicleProperties = base.GetProperties();
           
            vehicleProperties.Add("Is Driving Hazardous Materials", m_IsDrivingHazardousMaterials.ToString());
            vehicleProperties.Add("Maximum Carrying Weight", m_MaximumCarryingWeight.ToString());

            return vehicleProperties;
        }

        public override bool ValidateVehicleProperties(Dictionary<string, string> i_VehicleProperties)
        {
            bool isValid = base.ValidateVehicleProperties(i_VehicleProperties);

            if (!float.TryParse(i_VehicleProperties["Maximum Carrying Weight"], out float maximumCarryingWeight))
            {
                throw new FormatException("Maximum Carrying Weight is not a number");
            }

            if(i_VehicleProperties["Is Driving Hazardous Materials"] != "Yes" && i_VehicleProperties["Is Driving Hazardous Materials"] != "No")
            {
                throw new FormatException("Is Driving Hazardous Materials is not 'Yes' or 'No'");
            }

            return isValid;
        }
    }

}
