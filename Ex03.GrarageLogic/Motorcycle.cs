using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Motorcycle : Vehicle
    {
        public enum eLicenceType
        {
            A,
            B1,
            AA,
            BB
        }
        protected const int k_NumberOWheels = 2;
        protected const float k_MaxAirPressure = 30f;

        protected eLicenceType m_LicenceType;
        private int m_EngineCapacity;

        public Motorcycle(string i_LicenseNumber)
                : base(i_LicenseNumber, k_NumberOWheels, k_MaxAirPressure)
        {

        }

        private eLicenceType getLicenceTypeFromString(string i_LicenceTypeAsString)
        {
            eLicenceType licenceTypeToReturn;
            switch (i_LicenceTypeAsString)
            {
                case "A":
                    licenceTypeToReturn = eLicenceType.A;
                    break;
                case "B1":
                    licenceTypeToReturn = eLicenceType.B1;
                    break;
                case "AA":
                    licenceTypeToReturn = eLicenceType.AA;
                    break;
                case "BB":
                    licenceTypeToReturn = eLicenceType.BB;
                    break;
                default:
                    throw new FormatException("licence Type not found in list");
                    break;
            }

            return licenceTypeToReturn;
        }


        public override void SetAllVehicleProperties(Dictionary<string, string> i_VehicleProperties)
        {
            base.SetAllVehicleProperties(i_VehicleProperties);
            int.TryParse(i_VehicleProperties["Engine Capacity"], out m_EngineCapacity);
            m_LicenceType = getLicenceTypeFromString(i_VehicleProperties["Licence Type"]);
        }
        public virtual Dictionary<string, string> BuildProperties()
        {
            Dictionary<string, string> properties = base.BuildProperties();
            properties.Add("Licence Type", null);
            properties.Add("Engine Capacity", null);

            return properties;
        }

        public virtual bool ValidateVehicleProperties(Dictionary<string, string> i_VehicleProperties)
        {
            bool isValid = base.ValidateVehicleProperties(i_VehicleProperties);

            getLicenceTypeFromString(i_VehicleProperties["Licence Type"]);
            if (!int.TryParse(i_VehicleProperties["Engine Capacity"], out int engineCapacity))
            {
                throw new FormatException("Engine Capacity is not a number");
            }
           
            return isValid;
        }
    }
}
