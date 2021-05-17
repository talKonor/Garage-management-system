using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Truck : Vehicle
    {
        private bool m_IsDrivingHazardousMaterials;
        private float m_MaximumCarryingWeight;
        private InternalCombustionEngine m_Engine;
        public Truck(bool i_IsDrivingHazardousMaterials, float i_MaximumCarryingWeight, InternalCombustionEngine i_Engine, string i_Manufacturer, string i_LicenseNumber, float i_EnergyPrecentLeft, string i_WheelManufacturer, float i_CurrentAirPressure, float i_MaxAirPressure) : base(string i_Manufacturer, string i_LicenseNumber, float i_EnergyPrecentLeft, string i_WheelManufacturer, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            m_IsDrivingHazardousMaterials = i_IsDrivingHazardousMaterials;
            m_MaximumCarryingWeight = i_MaximumCarryingWeight;
            m_Engine = i_Engine;
        }

    }

}
