using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehicleRecord
    {
        enum eVehicleState
        {
            InRepair,
            Fixed,
            Paid,
        }
        private Vehicle m_Vehicle;
        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private eVehicleState m_VehicleState;

        public VehicleRecord(Vehicle i_Vehicle, string i_OwnerName, string i_OwnerPhoneNumber)
        {
            m_Vehicle = i_Vehicle;
            m_OwnerName = i_OwnerName;
            m_OwnerPhoneNumber = i_OwnerPhoneNumber;
        }

    }
}
