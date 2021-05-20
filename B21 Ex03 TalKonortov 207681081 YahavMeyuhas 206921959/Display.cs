using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ex03.ConsoleUI
{
    class Display
    {
        private List<string> m_Options;
        public Display(List<string> i_Options)
        {
            m_Options = i_Options;
        
        }
        public bool validateInput(int i_Input)
        {
            return i_Input > 0 && i_Input <= m_Options.Count();
        }
        public void ShowMenu(string i_Title)
        {
            Console.Clear();       
            int i = 1;
            string menuToPrint = i_Title;
            foreach(string option in m_Options)
            {
                menuToPrint+=(string.Format("{0}. {1}{2}", i, option,Environment.NewLine));
                i++;
            }
            Console.WriteLine(menuToPrint);
        }
        public int getUserInput()
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
                return m_Options.Count;
            }
        }

    }
}
