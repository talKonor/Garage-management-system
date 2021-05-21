using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public static class VehicleCreator
    {
        public enum eVehicleType
        {
            ElectricCar=1,
            ElectricMotorcycle=2,
            InternalCombustionEngineCar=3,
            InternalCombustionEngineMotorcycle=4,
            Truck=5,
        }

        public static Vehicle CreateVehicle(eVehicleType i_VehicleType,string i_LicenseNumber)
        { 
            Vehicle vehicle;
            switch (i_VehicleType)
            {
                case eVehicleType.ElectricCar:
                    vehicle = new ElectricCar(i_LicenseNumber);
                    break;
                case eVehicleType.ElectricMotorcycle:
                    vehicle = new ElectricMotorcycle(i_LicenseNumber);
                    break;
                case eVehicleType.InternalCombustionEngineCar:
                    vehicle = new InternalCombustionEngineCar(i_LicenseNumber);
                    break;
                case eVehicleType.InternalCombustionEngineMotorcycle:
                    vehicle = new InternalCombustionEngineMotorcycle(i_LicenseNumber);
                    break;
                case eVehicleType.Truck:
                    vehicle = new Truck(i_LicenseNumber);
                    break;
                default:
                    vehicle = null;
                    break;
            }

            return vehicle;
        }
    }
} 
