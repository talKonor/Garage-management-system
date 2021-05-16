using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class VehicleCreator
    {
        public enum eVehicleType
        {
            ElectricCar,
            ElectricMotorcycle,
            InternalCombustionEngineCar,
            InternalCombustionEngineMotorcycle,
            Truck,
        }
         public Vehicle createVehicle(eVehicleType i_VehicleType)
        {
            Vehicle vehicle;
            switch (i_VehicleType)
            {
                case eVehicleType.ElectricCar:
                    vehicle = new ElectricCar();
                    break;
                case eVehicleType.ElectricMotorcycle:
                    vehicle = new ElectricMotorcycle();
                    break;
                case eVehicleType.InternalCombustionEngineCar:
                    vehicle = new InternalCombustionEngineCar();
                    break;
                case eVehicleType.InternalCombustionEngineMotorcycle:
                    vehicle = new InternalCombustionEngineMotorcycle();
                    break;
                case eVehicleType.Truck:
                    vehicle = new Truck();
                    break;
                default:
                    vehicle = null;
                    break;
            }
            return vehicle;
        }
    }
} 
