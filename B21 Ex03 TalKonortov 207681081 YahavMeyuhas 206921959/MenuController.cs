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
        public Display m_HomeMenue;
        Garage m_Garage;

        public MenuController()
        {
            m_HomeMenue = new Display(new List<string>
            {"Enter new vehicle to garage","Display all license numbers", "Change vehicle state","Inflate wheels"
            ,"Fuel vehicle","Charge vehicle","Display vehicle data","Exit" });
            m_Garage = new Garage();
        }

        public void HomePage()
        {
            int userInput;
            do
            {
                m_HomeMenue.ShowMenu("Please choose one of the following options: \n");
                userInput = m_HomeMenue.getUserInput();
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
                        showAllLicenseNumbersInTheGragae();
                        break;
                    case 3:
                        changeVehicelStateInTheGarage();
                        break;
                    case 4:
                        InflateWheelsToMax();
                        break;
                    case 5:
                        FuelVehicel();
                        break;
                    case 6:
                        ChargeVehicel();
                        break;
                    case 7:
                        displayInfoAboutVehicle();
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
            }

            enterToContinue();

            return isExitOptionHasBeenChosen;
        }

        public void enterToContinue()
        {
            Console.WriteLine("Please press ENTER to continue");
            Console.ReadLine();
        }
        public void FuelVehicel()
        {
            string licenseNumber = getLicenseNumber();
            if (checkIfTheVehicleExistsInTheGarage(licenseNumber))
            {
                Vehicle vehicleToFuel = m_Garage.GetVehicleRecordFromTheGarage(licenseNumber).Vehicle;
                Engine vehicleEngineToFuel = vehicleToFuel.getEngine();
                if (vehicleEngineToFuel is InternalCombustionEngine)
                {
                    Console.WriteLine("Please type fuel type to fill: ");
                    Console.WriteLine(((InternalCombustionEngine)vehicleEngineToFuel).getFuelTypesAsString());
                    string fuelTypeToFill = Console.ReadLine();
                    Console.WriteLine("Please type amount ot fuel to fill: ");
                    float.TryParse(Console.ReadLine(), out float fuelAmountToFill);
                    ((InternalCombustionEngine)vehicleEngineToFuel).Fuel(InternalCombustionEngine.getFuelTypeFromString(fuelTypeToFill), fuelAmountToFill,vehicleToFuel);
                    
                }
                else
                {
                    throw new ArgumentException("This veichel does not have an Internal Combustion Engine");
                }
            }
            else
            {
                throw new ArgumentException("Vehicle was not found in the garage");
            }

        }
        public void ChargeVehicel()
        {
            string licenseNumber = getLicenseNumber();
            if (checkIfTheVehicleExistsInTheGarage(licenseNumber))
            {
                Vehicle vehicleToCharge = m_Garage.GetVehicleRecordFromTheGarage(licenseNumber).Vehicle;
                Engine vehicleEngineToCharge = vehicleToCharge.getEngine();
                if (vehicleEngineToCharge is ElectircalEngine)
                {
                    Console.WriteLine("Please enter minutes to charge: ");
                    float.TryParse(Console.ReadLine(), out float fuelAmountToFill);
                    ((ElectircalEngine)vehicleEngineToCharge).Charge(fuelAmountToFill,vehicleToCharge);
                }
                else
                {
                    throw new ArgumentException("This veichel does not have an Internal Combustion Engine");
                }
            }
            else
            {
                throw new ArgumentException("Vehicle was not found in the garage");
            }

        }
        public void displayInfoAboutVehicle()
        {
            string licenseNumber = getLicenseNumber();

            Dictionary<string, string> vehicleProperties = m_Garage.getVehicleRecordDataAsDictionary(licenseNumber);
            foreach (string key in vehicleProperties.Keys.ToList())
            {
                Console.WriteLine(string.Format("{0} : {1}", key, vehicleProperties[key]));
            }

        }
        private void changeVehicelStateInTheGarage()
        {
            string license = getLicenseNumber();
            List<string> vehicleStates = Garage.getAllVehicleState();
            Display vehicleStateToChoose = new Display(vehicleStates);
            vehicleStateToChoose.ShowMenu("Please choose one of the following options: \n");
            int choosenState = vehicleStateToChoose.getUserInput();
            m_Garage.changeVehicelStateInTheGarage(license, vehicleStates[choosenState - 1]);
        }
        private void showAllLicenseNumbersInTheGragae()
        {
            List<string> allVehicleState = Garage.getAllVehicleState();
            allVehicleState.Add("All");
            Display vehicleStateToChoose = new Display(allVehicleState);
            vehicleStateToChoose.ShowMenu("Please choose one of the following options: \n");
            string choosenState = Console.ReadLine();
            List<string> allLicenseNumbersInTheGragae = m_Garage.getAllLicenseNumbersInTheGragaeByChoosenState(choosenState);
            Display licenseNumbersInTheGragae = new Display(allLicenseNumbersInTheGragae);
            string title = "All license numbers in the garage filtered by state : '" + choosenState + "'\n";
            licenseNumbersInTheGragae.ShowMenu(title);
        }
        private bool checkIfTheVehicleExistsInTheGarage(string i_LicenseNumber)
        {
            return m_Garage.CheckIfTheVehicleExistsInTheGarage(i_LicenseNumber);
        }
        public void InflateWheelsToMax()
        {
            string licenseNumber = getLicenseNumber();
            if (checkIfTheVehicleExistsInTheGarage(licenseNumber))
            {
                m_Garage.GetVehicleRecordFromTheGarage(licenseNumber).Vehicle.Inflate();
            }
            else
            {
                throw new ArgumentException("Vehicle was not found in the garage");
            }
        }
        public string getLicenseNumber()
        {
            string licenseNumber;
            Console.WriteLine("Please enter the vehicle license number: ");
            licenseNumber = Console.ReadLine();
            return licenseNumber;
        }
        public void AddToTheGarage()
        {
            string licenseNumber = getLicenseNumber();
            if (checkIfTheVehicleExistsInTheGarage(licenseNumber))
            {
                m_Garage.changeVehicelStateInTheGarage(licenseNumber, "InRepair");
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
            Display viechleTypeMenu = new Display(GetAllSupportedVehicleTypesInTheGarageAsStrings(allSupportedVehicleTypesInTheGarage));
            Vehicle newVehicle;
            int userInput;
            viechleTypeMenu.ShowMenu("Please choose one of the following options: \n");
            userInput = viechleTypeMenu.getUserInput();
            newVehicle = VehicleCreator.createVehicle(allSupportedVehicleTypesInTheGarage[userInput - 1], i_LicenseNumber);
            getAndFillProperties(newVehicle);
            return newVehicle;
        }
        private List<string> GetAllSupportedVehicleTypesInTheGarageAsStrings(List<VehicleCreator.eVehicleType> i_AllSupportedVehicleTypesInTheGarage)
        {
            List<string> allSupportedVehicleTypesInTheGarageAsStrings = new List<string>();
            foreach (VehicleCreator.eVehicleType vehicleType in i_AllSupportedVehicleTypesInTheGarage)
            {
                allSupportedVehicleTypesInTheGarageAsStrings.Add(vehicleType.ToString());
            }
            return allSupportedVehicleTypesInTheGarageAsStrings;
        }
        public void getAndFillProperties(Vehicle i_newVehicle)
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
