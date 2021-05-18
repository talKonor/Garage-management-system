using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic

{

    public class ValueOutOfRangeException  : Exception
    {
    private float m_MaxValue;
    private float m_MinValue;
        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue,string i_message) : base(i_message)
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;
        }
    }
}
