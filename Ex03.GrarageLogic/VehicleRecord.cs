using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehicleRecord
    {
        public enum eVehicleState
        {
            InRepair = 1,
            Fixed = 2,
            Paid = 3,
        }

        private readonly Vehicle r_Vehicle;
        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private eVehicleState m_VehicleState;

        public VehicleRecord(Vehicle i_Vehicle, string i_OwnerName, string i_OwnerPhoneNumber)
        {
            r_Vehicle = i_Vehicle;
            m_OwnerName = i_OwnerName;
            m_OwnerPhoneNumber = i_OwnerPhoneNumber;
            m_VehicleState = eVehicleState.InRepair;
        }

        public Vehicle Vehicle
        {
            get
            {
                return r_Vehicle;
            }
        }

        public eVehicleState VehicleState
        {
            get
            {
                return m_VehicleState;
            }
            set
            {
                m_VehicleState = value;
            }
        }

        public Dictionary<string, string> GetProperties()
        {
            Dictionary<string, string> vehicleRecordProperties = new Dictionary<string, string>();

            vehicleRecordProperties.Add("Owner Name", m_OwnerName);
            vehicleRecordProperties.Add("Owner Phone Number", m_OwnerPhoneNumber);
            vehicleRecordProperties.Add("Vehicle State", m_VehicleState.ToString());
            vehicleRecordProperties = vehicleRecordProperties.Concat(r_Vehicle.GetProperties()).ToDictionary(e => e.Key, e => e.Value);

            return vehicleRecordProperties;
        }
    }
}
