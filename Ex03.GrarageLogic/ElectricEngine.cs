using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{

    
    public class ElectricEngine : Engine
    { 
        public ElectricEngine(float i_BatteryCapacity) : base()
        {
            m_EnergyCapacity = i_BatteryCapacity;
        }
        
        public override void SetAllEngineProperties(Dictionary<string, string> i_EngineProperties)
        {
            float.TryParse(i_EngineProperties["Battery Time Left"], out m_EnergyLeft);
        }
      
        public override Dictionary<string, string> BuildProperties()
        {
            Dictionary<string, string> properties = new Dictionary<string, string>();
            
            properties.Add("Battery Time Left", null);
            
            return properties;
        }

        public override Dictionary<string, string> GetProperties()
        {
            Dictionary<string, string> properties = new Dictionary<string, string>();

            properties.Add("Battery Time Left", m_EnergyLeft.ToString());
            properties.Add("Battery Capacity", m_EnergyCapacity.ToString());

            return properties;
        }

        public override bool ValidateEngineProperties(Dictionary<string, string> i_VehicleProperties)
        {
            const bool isValid = true;

            if (!float.TryParse(i_VehicleProperties["Battery Time Left"], out float batteryTimeLeft))
            {
                throw new FormatException("Battery Time Left is not a number");
            }

            return isValid;
        }
       
        public void Charge(float i_AmountToCharge, Vehicle i_VehicleToFuel)
        {
            i_AmountToCharge /= 60;
            if (i_AmountToCharge < 0)
            {
                throw new ArgumentException("Cant add negative amount of Charge");
            }

            if (i_AmountToCharge + m_EnergyLeft <= m_EnergyCapacity)
            {
                m_EnergyLeft += i_AmountToCharge;
                i_VehicleToFuel.EnergyPercentLeft = CalculatePercentOfEnergyLeft();
            }
            else
            {
                throw new ValueOutOfRangeException(0, m_EnergyCapacity - m_EnergyLeft, "Cant add fuel more than the size of tank");
            }
        }
    }
}
