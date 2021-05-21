using System;
using System.Collections.Generic;
using System.Linq;


namespace Ex03.ConsoleUI
{
    class Display
    {
        private readonly List<string> r_Options;
        
        public Display(List<string> i_Options)
        {
            r_Options = i_Options;
        
        }
        
        public void ShowMenu(string i_Title)
        {
            int i = 1;
            string menuToPrint = i_Title;
            
            Console.Clear();       
            menuToPrint += Environment.NewLine;
            foreach(string option in r_Options)
            {
                menuToPrint+=(string.Format("{0}. {1}{2}", i, option,Environment.NewLine));
                i++;
            }

            Console.WriteLine(menuToPrint);
        }
        
        public int GetUserInput()
        {
            string userInputAsString;
            int userInputToReturn;
            bool isValid = false;

            do
            {
                userInputAsString = Console.ReadLine();
                if (!(int.TryParse(userInputAsString, out userInputToReturn)))
                {
                    Console.WriteLine("Wrong Input! Please enter a Integer number");
                    isValid = false;
                }
                else
                {
                    isValid = checkInput(userInputToReturn, 1, MenuSize);
                }

            } while (!isValid);

            return userInputToReturn;
        }

        private bool checkInput(int i_UserInput, int i_MinPickPossible, int i_MaxPickPossible)
        {
            bool inputIsValid = true;

            if (i_UserInput < i_MinPickPossible || i_UserInput > i_MaxPickPossible)
            {
                Console.WriteLine("Invalid input! the chosen spot is not in the range of the Menu,please choose valid option");
                inputIsValid = false;
            }

            return inputIsValid;
        }
        
        public int MenuSize {
            get
            {
                return r_Options.Count;
            }
        }

    }
}
