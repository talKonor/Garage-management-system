using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Utils
    {
        public static string getEnumValuesAsString(Type enumTypeToStringOfValues)
        {
            string stringToReturn = "";
            foreach (Enum e in Enum.GetValues((enumTypeToStringOfValues)))
            {
                stringToReturn += string.Format(" {0},", e.ToString());
            }
            stringToReturn = stringToReturn.TrimEnd(',');
            return stringToReturn;
        }
    }
}
