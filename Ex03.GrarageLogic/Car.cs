using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    abstract class Car : Vehicle
    {
        enum eColor
        {
            Red,
            Silver,
            White,
            Black
        }
        enum eNumberOfDoors
        {
            Two=2,
            Three=3,
            four=4,
            Five=5
        }

        private eColor m_CarColor;
        private eNumberOfDoors m_NumberOfDoors;

    }
}
