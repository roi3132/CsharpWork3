using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleFactory
    {
        public static Vehicles CreateVehicle(Vehicles.eVehicleType i_TypeOfVehicle,
            Engine.eEngineType i_EngineType, string i_LicenseNumber, string i_ModelName,
            string i_WheelManufacturer)
        {
            Vehicles vehicle = null;

            switch (i_TypeOfVehicle)
            {
                case Vehicles.eVehicleType.Car:
                    vehicle = new Car(i_LicenseNumber, i_ModelName, i_WheelManufacturer, i_EngineType);
                    break;

                case Vehicles.eVehicleType.Motorcycle:
                    vehicle = new Motorcycle(i_LicenseNumber, i_ModelName, i_WheelManufacturer, i_EngineType);
                    break;

                case Vehicles.eVehicleType.Truck:
                    vehicle = new Truck(i_LicenseNumber, i_ModelName, i_WheelManufacturer, i_EngineType);
                    break;
            }

            return vehicle;
        }
    }
}
