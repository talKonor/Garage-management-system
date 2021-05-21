using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Ex03.GarageLogic;


namespace Ex03.ConsoleUI
{
    class MenuController
    {
       
        Garage m_Garage;

        public MenuController()
        {
           
            m_Garage = new Garage();
        }

        public void HomePage()
        {
         Display homeMenu = new Display(new List<string> {"Enter new vehicle to garage","Display all license numbers"
                                                              , "Change vehicle state","Inflate wheels"
                                                              ,"Fuel vehicle","Charge vehicle","Display vehicle data","Exit" });
        int userInput;
            do
            {
                homeMenu.ShowMenu("Please choose one of the following options:");
                userInput = homeMenu.GetUserInput();
            } while (!Navigator(userInput));
        }
        
        private bool Navigator(int i_UserInput)
        {
            bool isExitOptionHasBeenChosen = false;
            try
            {
                switch (i_UserInput)
                {
                    case 1:
                        AddToTheGarage();
                        break;
                    case 2:
                        showAllLicenseNumbersInTheGarage();
                        EnterToContinue();
                        break;
                    case 3:
                        changeVehicleStateInTheGarage();
                        break;
                    case 4:
                        InflateWheelsToMax();
                        break;
                    case 5:
                        FuelVehicle();
                        break;
                    case 6:
                        ChargeVehicle();
                        break;
                    case 7:
                        DisplayInfoAboutVehicle();
                        EnterToContinue();
                        break;
                    case 8:
                        isExitOptionHasBeenChosen = true;
                        break;
                    default:
                        break;
                }
            }

            catch (Exception error)
            {
                Console.WriteLine(error.Message);
                EnterToContinue();
            }

            return isExitOptionHasBeenChosen;
        }

        public void EnterToContinue()
        {
            Console.WriteLine("Please press ENTER to continue");
            Console.ReadLine();
        }

        public void FuelVehicle()
        {
            string licenseNumber = GetLicenseNumber();
            if (checkIfTheVehicleExistsInTheGarage(licenseNumber))
            {
                Vehicle vehicleToFuel = m_Garage.GetVehicleRecordFromTheGarage(licenseNumber).Vehicle;
                Engine vehicleEngine = vehicleToFuel.Engine;
                if (vehicleEngine is InternalCombustionEngine vehicleEngineToFuel)
                {
                    Console.WriteLine("Please type fuel type to fill: ");
                    Console.WriteLine(((InternalCombustionEngine)vehicleEngineToFuel).GetFuelTypesAsString());
                    string fuelTypeToFill = Console.ReadLine();
                    Console.WriteLine("Please type amount ot fuel to fill: ");
                    float.TryParse(Console.ReadLine(), out float fuelAmountToFill);
                    ((InternalCombustionEngine)vehicleEngineToFuel).Fuel(InternalCombustionEngine.GetFuelTypeFromString(fuelTypeToFill), fuelAmountToFill, vehicleToFuel);
                }
                else
                {
                    throw new ArgumentException("This vehicle does not have an Internal Combustion Engine");
                }
            }
            else
            {
                throw new ArgumentException("Vehicle was not found in the garage");
            }
        }

        public void ChargeVehicle()
        {
            string licenseNumber = GetLicenseNumber();
            if (checkIfTheVehicleExistsInTheGarage(licenseNumber))
            {
                Vehicle vehicleToCharge = m_Garage.GetVehicleRecordFromTheGarage(licenseNumber).Vehicle;
                Engine vehicleEngine = vehicleToCharge.Engine;
                if (vehicleEngine is ElectricEngine vehicleEngineToCharge)
                {
                    Console.WriteLine("Please enter minutes to charge: ");
                    float.TryParse(Console.ReadLine(), out float fuelAmountToFill);
                    ((ElectricEngine)vehicleEngineToCharge).Charge(fuelAmountToFill, vehicleToCharge);
                }
                else
                {
                    throw new ArgumentException("This vehicle does not have an Internal Combustion Engine");
                }
            }
            else
            {
                throw new ArgumentException("Vehicle was not found in the garage");
            }
        }

        public void DisplayInfoAboutVehicle()
        {
            string licenseNumber = GetLicenseNumber();
            Dictionary<string, string> vehicleProperties = m_Garage.GetVehicleRecordDataAsDictionary(licenseNumber);

            foreach (string key in vehicleProperties.Keys.ToList())
            {
                Console.WriteLine(string.Format("{0} : {1}", key, vehicleProperties[key]));
            }
        }
        
        private void changeVehicleStateInTheGarage()
        {
            string license = GetLicenseNumber();
            List<string> vehicleStates = Garage.GetAllVehicleState();
            Display vehicleStateToChoose = new Display(vehicleStates);

            vehicleStateToChoose.ShowMenu("Please choose one of the following options:");
            int chosenState = vehicleStateToChoose.GetUserInput();
            m_Garage.ChangeVehicleStateInTheGarage(license, vehicleStates[chosenState - 1]);
        }

        private void showAllLicenseNumbersInTheGarage()
        {
            List<string> allVehicleState = Garage.GetAllVehicleState();
            allVehicleState.Add("All");
            Display vehicleStateToChoose = new Display(allVehicleState);
            vehicleStateToChoose.ShowMenu("Please choose one of the following options:");
            string chosenState = Console.ReadLine();
            List<string> allLicenseNumbersInTheGarage = m_Garage.GetAllLicenseNumbersInTheGarageByChosenState(chosenState);
            Display licenseNumbersInTheGarage = new Display(allLicenseNumbersInTheGarage);

            string title = string.Format("All license numbers in the garage filtered by state : {0}", chosenState);
            licenseNumbersInTheGarage.ShowMenu(title);
        }

        private bool checkIfTheVehicleExistsInTheGarage(string i_LicenseNumber)
        {
            return m_Garage.CheckIfTheVehicleExistsInTheGarage(i_LicenseNumber);
        }

        public void InflateWheelsToMax()
        {
            string licenseNumber = GetLicenseNumber();
            if (checkIfTheVehicleExistsInTheGarage(licenseNumber))
            {
                m_Garage.GetVehicleRecordFromTheGarage(licenseNumber).Vehicle.Inflate();
            }
            else
            {
                throw new ArgumentException("Vehicle was not found in the garage");
            }
        }

        public string GetLicenseNumber()
        {
            Console.WriteLine("Please enter the vehicle license number: ");
            string licenseNumber = Console.ReadLine();

            return licenseNumber;
        }

        public void AddToTheGarage()
        {
            string licenseNumber = GetLicenseNumber();

            if (checkIfTheVehicleExistsInTheGarage(licenseNumber))
            {
                m_Garage.ChangeVehicleStateInTheGarage(licenseNumber, "InRepair");
                Console.WriteLine("Vehicle already registered in the garage. Vehicle state changed to:'In Repair'");
            }
            else
            {
                AddNewVehicleRecord(licenseNumber);
            }
        }
        
        private bool checkIfValidPhoneNumber(string i_PhoneNumber)
        {
            bool isValidPhoneNumber = true;

            foreach (char digit in i_PhoneNumber)
            {
                if (!char.IsDigit(digit))
                {
                    isValidPhoneNumber = false;
                }
            }

            return isValidPhoneNumber;
        }
        
        public void AddNewVehicleRecord(string i_LicenseNumber)
        {
            Console.WriteLine("Please enter Owner Name: ");
            string ownerName = Console.ReadLine();
            Console.WriteLine("Please enter phone number: ");
            string ownerPhoneNumber = Console.ReadLine();

            if (!checkIfValidPhoneNumber(ownerPhoneNumber))
            {
                throw new FormatException("Invalid phone number! need to contain only numbers");
            }

            try
            {
                Vehicle newVehicle = CreateNewVehicle(i_LicenseNumber);

                m_Garage.AddVehicle(newVehicle, ownerName, ownerPhoneNumber);

            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }
        
        public Vehicle CreateNewVehicle(string i_LicenseNumber)
        {
            List<VehicleCreator.eVehicleType> allSupportedVehicleTypesInTheGarage = m_Garage.GetAllSupportedVehicleTypesInTheGarage();
            Display vehicleTypeMenu = new Display(getAllSupportedVehicleTypesInTheGarageAsStrings(allSupportedVehicleTypesInTheGarage));
            vehicleTypeMenu.ShowMenu("Please choose one of the following options:");
            int userInput = vehicleTypeMenu.GetUserInput();
            Vehicle newVehicle = m_Garage.CreateVehicle(allSupportedVehicleTypesInTheGarage[userInput - 1], i_LicenseNumber);

            GetAndFillProperties(newVehicle);

            return newVehicle;
        }

        private List<string> getAllSupportedVehicleTypesInTheGarageAsStrings(List<VehicleCreator.eVehicleType> i_AllSupportedVehicleTypesInTheGarage)
        {
            List<string> allSupportedVehicleTypesInTheGarageAsStrings = new List<string>();

            foreach (VehicleCreator.eVehicleType vehicleType in i_AllSupportedVehicleTypesInTheGarage)
            {
                allSupportedVehicleTypesInTheGarageAsStrings.Add(vehicleType.ToString());
            }

            return allSupportedVehicleTypesInTheGarageAsStrings;
        }

        public void GetAndFillProperties(Vehicle i_newVehicle)
        {
            Dictionary<string, string> vehicleProperties = i_newVehicle.BuildProperties();

            foreach (string key in vehicleProperties.Keys.ToList())
            {
                Console.Clear();
                Console.WriteLine(string.Format("Please type: {0}", key));
                if (vehicleProperties[key] != null)
                {
                    Console.WriteLine(string.Format("Options are: {0}", vehicleProperties[key]));
                }
                vehicleProperties[key] = Console.ReadLine();
            }

            if (i_newVehicle.ValidateVehicleProperties(vehicleProperties))
            {
                i_newVehicle.SetAllVehicleProperties(vehicleProperties);
            }
        }
    }
}
