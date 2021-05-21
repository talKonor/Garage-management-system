using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal abstract class Car : Vehicle
    {
        public enum eColor
        {
            Red,
            Silver,
            White,
            Black
        }

        private const int k_NumberOWheels = 4;
        private const float k_MaxAirPressure = 32f;
        private eColor m_CarColor;
        private int m_NumberOfDoors;

        public eColor CarColor
        {
            get
            {
                return m_CarColor;
            }
            set
            {
                m_CarColor = value;
            }
        }

        public int NumberOfDoors
        {
            get
            {
                return m_NumberOfDoors;
                
            }
            set
            {
                m_NumberOfDoors = value;
            }
        }

        public Car(string i_LicenseNumber)
                : base(i_LicenseNumber, k_NumberOWheels, k_MaxAirPressure)
        {
        }


        public override void SetAllVehicleProperties(Dictionary<string, string> i_VehicleProperties)
        {
            base.SetAllVehicleProperties(i_VehicleProperties);
            int.TryParse(i_VehicleProperties["Number Of Doors"], out m_NumberOfDoors);
            if(!(Enum.TryParse(i_VehicleProperties["Color"],true, out m_CarColor))){
                throw new FormatException("Color not found in list");
            }
        }
        public override Dictionary<string, string> BuildProperties()
        {
            Dictionary<string, string> properties = base.BuildProperties();
            properties.Add("Color",Utils.getEnumValuesAsString(typeof(eColor)));
            properties.Add("Number Of Doors", null);

            return properties;
        }


        public override Dictionary<string, string> GetProperties()
        {
            Dictionary<string, string> properties = base.GetProperties();
            properties.Add("Color", m_CarColor.ToString());
            properties.Add("Number Of Doors", m_NumberOfDoors.ToString());

            return properties;
        }
        public override bool ValidateVehicleProperties(Dictionary<string, string> i_VehicleProperties) 
        {
            bool isValid = base.ValidateVehicleProperties(i_VehicleProperties);
            if (!(Enum.TryParse(i_VehicleProperties["Color"], true, out eColor carColor)))
            {
                throw new FormatException("Color not found in list");
            }
            if (!int.TryParse(i_VehicleProperties["Number Of Doors"], out int numberOfDoors))
            {
                throw new FormatException("Number Of Doors is not a number");
            }
            else if(numberOfDoors<2 || numberOfDoors > 5)
            {
                throw new ValueOutOfRangeException(2, 5, "Number of doors is out of range");
            }



            return isValid;
        }

    }
}
