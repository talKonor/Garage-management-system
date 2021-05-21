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

        public Dictionary<string, string> GetVehicleRecordDataAsDictionary(string i_LicenseNumber)
        {
            VehicleRecord record = m_LicenseNumberToVehicleRecord[i_LicenseNumber];
            Dictionary<string, string> propertiesToReturn = record.GetProperties();

            return propertiesToReturn;

        }

        public Vehicle CreateVehicle(VehicleCreator.eVehicleType i_VehicleType, string i_LicenseNumber)
        {
            return VehicleCreator.CreateVehicle(i_VehicleType, i_LicenseNumber);
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
            
            foreach (VehicleCreator.eVehicleType eVehicleType in Enum.GetValues(typeof(VehicleCreator.eVehicleType)))
            {
                allSupportedVehicleTypesInTheGarage.Add(eVehicleType);
            }
            
            return allSupportedVehicleTypesInTheGarage;
        }

        public static List<string> GetAllVehicleState()
        {
            List<string> allVehicleState = new List<string>();
          
            foreach (VehicleRecord.eVehicleState vehicleState in Enum.GetValues(typeof(VehicleRecord.eVehicleState)))
            {
                allVehicleState.Add(vehicleState.ToString());
            }
           
            return allVehicleState;
        }

        public List<string> GetAllLicenseNumbersInTheGarageByChosenState(string i_ChosenState)
        {
            List<string> allLicenseNumbers = new List<string>();
            
            foreach (string key in m_LicenseNumberToVehicleRecord.Keys)
            {
                if (i_ChosenState == "All")
                {
                    allLicenseNumbers.Add(key);
                }
                else
                {
                    Enum.TryParse(i_ChosenState, out VehicleRecord.eVehicleState vehicleState);
                    if (m_LicenseNumberToVehicleRecord[key].VehicleState.Equals(vehicleState))
                    {
                        allLicenseNumbers.Add(key);
                    }
                }
            }

            return allLicenseNumbers;
        }

        public void ChangeVehicleStateInTheGarage(string i_LicenseNumber, string i_ChosenState)
        {
            if (CheckIfTheVehicleExistsInTheGarage(i_LicenseNumber))
            {
                if ((Enum.TryParse(i_ChosenState, true, out VehicleRecord.eVehicleState newVehicleState)))
                {
                    m_LicenseNumberToVehicleRecord[i_LicenseNumber].VehicleState = newVehicleState;
                }
                else
                {
                    throw new ArgumentException("Vehicle state is not valid");
                }
            }
            else
            {
                throw new ArgumentException("Vehicle was not found in the garage");
            }
        }
    }
}
