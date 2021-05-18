using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ex03.ConsoleUI
{
    class MenuDisplay
    {
        private List<string> m_Options;
        public MenuDisplay(List<string> i_Options)
        {
            m_Options = i_Options;
        
        }
        public bool validateInput(int i_Input)
        {
            return i_Input > 0 && i_Input <= m_Options.Count();
        }
        public void ShowMenu()
        {
            int i = 1;
            string menuToPrint = "";
            foreach(string option in m_Options)
            {
                menuToPrint+=(string.Format("{0}. {1}{2}", i, option,Environment.NewLine));
                i++;
            }
            Console.WriteLine(menuToPrint);
        }
    }
}
