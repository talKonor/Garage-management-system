using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Car : Vehicle
    {
        public enum eColor
        {
            Red,
            Silver,
            White,
            Black
        }

        protected const int k_NumberOWheels = 4;
        protected const float k_MaxAirPressure = 32f;


        protected eColor m_CarColor;
        protected int m_NumberOfDoors;

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
            m_Wheels = new List<Wheel>(k_NumberOWheels);
            for (int i = 0; i < k_NumberOWheels; i++)
            {
                m_Wheels[i] = new Wheel(k_MaxAirPressure);
            }
        }

        private eColor getColorFromString(string i_ColorAsString)
        {
            eColor colorToReturn;
            switch (i_ColorAsString)
            {
                case "Red":
                    colorToReturn = eColor.Red;
                    break;
                case "Silver":
                    colorToReturn = eColor.Silver;
                    break;
                case "White":
                    colorToReturn = eColor.White;
                    break;
                case "Black":
                    colorToReturn = eColor.Black;
                    break;
                default:
                    throw new FormatException("Color not found in list");
                    break;
            }

            return colorToReturn;
        }

        public override void SetAllVehicleProperties(Dictionary<string, string> i_VehicleProperties)
        {
            base.SetAllVehicleProperties(i_VehicleProperties);
            int.TryParse(i_VehicleProperties["Number Of Doors"], out m_NumberOfDoors);
            m_CarColor = getColorFromString(i_VehicleProperties["Color"]);


        }
        public override Dictionary<string, string> BuildProperties()
        {
            Dictionary<string, string> properties = base.BuildProperties();
            properties.Add("Color", null);
            properties.Add("Number Of Doors", null);

            return properties;
        }
        public virtual bool ValidateVehicleProperties(Dictionary<string, string> i_VehicleProperties) 
        {
            bool isValid = base.ValidateVehicleProperties(i_VehicleProperties);
            getColorFromString(i_VehicleProperties["Color"]);

            if(!int.TryParse(i_VehicleProperties["Number Of Doors"], out int numberOfDoors))
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
