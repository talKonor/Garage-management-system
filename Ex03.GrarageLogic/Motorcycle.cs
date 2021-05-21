using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal abstract class Motorcycle : Vehicle
    {
        public enum eLicenseType
        {
            A,
            B1,
            AA,
            BB
        }
        protected const int k_NumberOWheels = 2;
        protected const float k_MaxAirPressure = 30f;
        protected eLicenseType m_LicenseType;
        private int m_EngineVolume;

        public Motorcycle(string i_LicenseNumber) : base(i_LicenseNumber, k_NumberOWheels, k_MaxAirPressure)
        {
        }

        public override void SetAllVehicleProperties(Dictionary<string, string> i_VehicleProperties)
        {
            base.SetAllVehicleProperties(i_VehicleProperties);
            int.TryParse(i_VehicleProperties["Engine Volume"], out m_EngineVolume);

            if (!(Enum.TryParse(i_VehicleProperties["License Type"], true, out m_LicenseType)))
            {
                throw new FormatException("License Type not found in list");
            }
        }

        public override Dictionary<string, string> BuildProperties()
        {
            Dictionary<string, string> properties = base.BuildProperties();

            properties.Add("License Type", Utils.getEnumValuesAsString(typeof(eLicenseType)));
            properties.Add("Engine Volume", null);

            return properties;
        }

        public override Dictionary<string, string> GetProperties()
        {
            Dictionary<string, string> properties = base.GetProperties();

            properties.Add("License Type", m_LicenseType.ToString());
            properties.Add("Engine Volume", m_EngineVolume.ToString());

            return properties;
        }

        public override bool ValidateVehicleProperties(Dictionary<string, string> i_VehicleProperties)
        {
            bool isValid = base.ValidateVehicleProperties(i_VehicleProperties);

            if (!(Enum.TryParse(i_VehicleProperties["License Type"], true, out eLicenseType LicenseType)))
            {
                throw new FormatException("License Type not found in list");
            }

            if (!int.TryParse(i_VehicleProperties["Engine Volume"], out int engineCapacity))
            {
                throw new FormatException("Engine Volume is not a number");
            }

            return isValid;
        }
    }
}
