using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

 
namespace Ex03.ConsoleUI
{
    class HomeMenu
    {
       public MenuDisplay m_HomeMenue;
        Garage m_Garage;

        public HomeMenu()
        {
            m_HomeMenue=new MenuDisplay( new List<string>
            {"Enter new vehicle to garage","Display all license numbers", "Change vehicle state","Inflate wheels"
            ,"Fuel vehicle","Charge vehicle","Display vehicle data" });
            m_Garage = new Garage();
             
        }

    }
}
