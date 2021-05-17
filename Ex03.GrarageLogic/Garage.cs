using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GrarageLogic
{
    class Garage
    {
        private Dictionary<string, VehicleRecord> m_LicenseNumberToVehicleRecord;
        public void AddVehicle(Vehicle i_Vehicle, string i_Owner, string i_PhoneNumber)
        {
            VehicleRecord newRecord = new VehicleRecord(i_Vehicle, i_Owner, i_PhoneNumber);
            m_LicenseNumberToVehicleRecord.Add(i_Vehicle.LicenseNumber, newRecord);
        }

        public Vehicle createVehicle(VehicleCreator.eVehicleType i_VehicleType, string i_LicenseNumberi)
        {
            return VehicleCreator.createVehicle(i_VehicleType, i_LicenseNumberi);
        }
    }
}
