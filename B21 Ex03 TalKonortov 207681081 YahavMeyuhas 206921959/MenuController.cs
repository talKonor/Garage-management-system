using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;


namespace Ex03.ConsoleUI
{
    class MenuController
    {
        public MenuDisplay m_HomeMenue;
        Garage m_Garage;

        public MenuController()
        {
            m_HomeMenue = new MenuDisplay(new List<string>
            {"Enter new vehicle to garage","Display all license numbers", "Change vehicle state","Inflate wheels"
            ,"Fuel vehicle","Charge vehicle","Display vehicle data","Exit" });
            m_Garage = new Garage();

        }

        public void HomePage()
        {
            int userInput;
            do
            {
                m_HomeMenue.ShowMenu();
                userInput = m_HomeMenue.getUserInput();
            } while (!Navigator(userInput));
        }


        private bool Navigator(int i_UserInput)
        {
            bool isExitOptionHasBeenChosen = false;
            switch (i_UserInput)
            {
                case 1:
                    AddToTheGarage();
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    displayInfoAboutVehicle();
                    break;
               default:
                    isExitOptionHasBeenChosen = true;
                    break;
            }
            return isExitOptionHasBeenChosen;
        }

        public void displayInfoAboutVehicle()
        {
            string licenseNumber = getLicenseNumber();

            Dictionary<string,string> vehicleProperties= m_Garage.getVehicleRecordDataAsDictionary(licenseNumber);
            foreach(string key in vehicleProperties.Keys.ToList())
            {
                Console.WriteLine(string.Format("{0} : {1}",key, vehicleProperties[key]));
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
            if (m_Garage.CheckIfTheVehicleExistsInTheGarage(licenseNumber))
            {
                //goto function A
            }
            else
            {
                AddNewVehicleRecord(licenseNumber);
            }
        }

        public void AddNewVehicleRecord(string i_LicenseNumber)
        {
            Console.WriteLine("Please enter Owner Name: ");
            string ownerName = Console.ReadLine();
            Console.WriteLine("Please enter phone number: ");
            string ownerPhoneNumber = Console.ReadLine();
            ///TODO validate phone number
            try
            {
            Vehicle newVehicle = CreateNewVehicle(i_LicenseNumber);

            m_Garage.AddVehicle(newVehicle, ownerName, ownerPhoneNumber);

            }
            catch(Exception error)
            {
                Console.WriteLine(error.Message);
            }


        }
        public Vehicle CreateNewVehicle(string i_LicenseNumber)
        {
            List<VehicleCreator.eVehicleType> allSupportedVehicleTypesInTheGarage = m_Garage.GetAllSupportedVehicleTypesInTheGarage();
           MenuDisplay viechleTypeMenu = new MenuDisplay(GetAllSupportedVehicleTypesInTheGarageAsStrings(allSupportedVehicleTypesInTheGarage));
            viechleTypeMenu.ShowMenu();
           int userInput = viechleTypeMenu.getUserInput();
            Vehicle newVehicle = VehicleCreator.createVehicle(allSupportedVehicleTypesInTheGarage[userInput-1], i_LicenseNumber);
            getAndFillProperties(newVehicle);
            return newVehicle;
        }
        private List<string> GetAllSupportedVehicleTypesInTheGarageAsStrings(List<VehicleCreator.eVehicleType> i_AllSupportedVehicleTypesInTheGarage)
        {
            List<string> allSupportedVehicleTypesInTheGarageAsStrings = new List<string>();
            foreach(VehicleCreator.eVehicleType vehicleType in i_AllSupportedVehicleTypesInTheGarage)
            {
                allSupportedVehicleTypesInTheGarageAsStrings.Add(vehicleType.ToString());
            }
            return allSupportedVehicleTypesInTheGarageAsStrings;
        }

        public void getAndFillProperties(Vehicle i_newVehicle)
        {
            Dictionary<string, string> vehicleProperties = i_newVehicle.BuildProperties();

            foreach(string key in vehicleProperties.Keys.ToList())
            {
                Console.Clear();

                Console.WriteLine(string.Format("Please enter: {0}",key));
                vehicleProperties[key] = Console.ReadLine();
            }

            if (i_newVehicle.ValidateVehicleProperties(vehicleProperties))
            {
                i_newVehicle.SetAllVehicleProperties(vehicleProperties);
            }


        }

    }
}
