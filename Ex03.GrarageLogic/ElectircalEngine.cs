using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectircalEngine : Engine
    {

        public ElectircalEngine(float i_BatteryCapacity) : base()
        {
            m_EnergeyCapacity = i_BatteryCapacity;
        }
        public override void SetAllEngineProperties(Dictionary<string, string> i_EngineProperties)
        {
            float.TryParse(i_EngineProperties["Battery Time Left"], out m_EnergeyLeft);
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
            properties.Add("Battery Time Left", m_EnergeyLeft.ToString());
            properties.Add("Battery Capacity", m_EnergeyCapacity.ToString());

            return properties;
        }

        public override bool ValidateEngineProperties(Dictionary<string, string> i_VehicleProperties)
        {
            bool isValid = true;

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
            if (i_AmountToCharge + m_EnergeyLeft <= m_EnergeyCapacity)
            {
                m_EnergeyLeft += i_AmountToCharge;
                i_VehicleToFuel.EnergyPrecentLeft = CalculatePrecentsOfEnergtLeft();
            }
            else
            {
                throw new ValueOutOfRangeException(0, m_EnergeyCapacity - m_EnergeyLeft, "Cant add fuel more than the size of tank");
            }

        }

    }
}
