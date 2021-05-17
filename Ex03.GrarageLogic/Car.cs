using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    abstract class Car : Vehicle
    {
       public enum eColor
        {
            Red,
            Silver,
            White,
            Black
        }
       public enum eNumberOfDoors
        {
            Two=2,
            Three=3,
            four=4,
            Five=5
        }

        private eColor m_CarColor;
        private eNumberOfDoors m_NumberOfDoors;

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

        public eNumberOfDoors NumberOfDoors
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
                :  base(i_LicenseNumber)
        {
        }

    }
}
