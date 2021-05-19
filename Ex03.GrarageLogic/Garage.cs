using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    
    public class Garage
    {

        private Dictionary<string, VehicleRecord> m_LicenseNumberToVehicleRecord;

        public Garage()
        {
            m_LicenseNumberToVehicleRecord = new Dictionary<string, VehicleRecord>();
        }
        public void AddVehicle(Vehicle i_Vehicle, string i_Owner, string i_PhoneNumber)
        {
            VehicleRecord newRecord = new VehicleRecord(i_Vehicle, i_Owner, i_PhoneNumber);
            m_LicenseNumberToVehicleRecord.Add(i_Vehicle.LicenseNumber, newRecord);
        }

        public Dictionary<string,string> getVehicleRecordDataAsDictionary(string i_LicenseNumber)
        {
            VehicleRecord record = m_LicenseNumberToVehicleRecord[i_LicenseNumber];
            Dictionary<string, string> propertiesToReturn = record.GetProperties();
            return propertiesToReturn;
            
        }

        public Vehicle CreateVehicle(VehicleCreator.eVehicleType i_VehicleType, string i_LicenseNumber)
        {
            return VehicleCreator.createVehicle(i_VehicleType, i_LicenseNumber);
        }

        public bool CheckIfTheVehicleExistsInTheGarage(string i_LicenseNumber)
        {
            return m_LicenseNumberToVehicleRecord.ContainsKey(i_LicenseNumber);
        }
        public VehicleRecord GetVehicleRecordFromTheGarage(string i_LicenseNumber)
        {
            return m_LicenseNumberToVehicleRecord[i_LicenseNumber];
        }

        public List<VehicleCreator.eVehicleType> GetAllSupportedVehicleTypesInTheGarage()
        {
            List<VehicleCreator.eVehicleType> allSupportedVehicleTypesInTheGarage = new List<VehicleCreator.eVehicleType>();
            foreach(VehicleCreator.eVehicleType eVehicleType in Enum.GetValues(typeof(VehicleCreator.eVehicleType)))
                {
                allSupportedVehicleTypesInTheGarage.Add(eVehicleType);
            }
            return allSupportedVehicleTypesInTheGarage;
        }
    }
}
