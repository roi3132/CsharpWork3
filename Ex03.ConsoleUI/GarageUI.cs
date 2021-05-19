using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class UserInterface
    {
        private readonly Service m_Service;
        private bool m_Run;
        private readonly Garage m_Garage;

        public UserInterface()
        {
            m_Service = new Service();
            m_Run = true;
            m_Garage = new Garage();
        }

        public enum eUserChoice
        {
            InsertNewVehicle = 1,
            DisplayLicenseNumbers,
            SetVehicleStatus,
            InflateWheels,
            FillGasolin,
            ChargeBattery,
            DisplayFullVehicleData,
            Exit,
        }

        public void Start()
        {
            do
            {
                m_Service.GetDisplayMenu();
                int userChoose = m_Service.GetChoiceFromUser(8);
                switch (userChoose)
                {
                    case (int)eUserChoice.InsertNewVehicle:
                        {
                            Console.Clear();
                            int vehicleType = m_Service.GetVehicleType();
                            string ownerName = m_Service.GetOwnerName();
                            string ownerPhone = m_Service.GetOwnerPhone();
                            string modelName = m_Service.GetModelName();
                            string licenseNumber = m_Service.GetLicenseNumber();
                            string manufacturerName = m_Service.GetManufacturerName();
                            switch (vehicleType)
                            {
                                case (int)Vehicles.eVehicleType.Car:
                                    {
                                        int engineType = m_Service.GetEngineType();
                                        int color = m_Service.GetColorType();
                                        int numOfDoors = m_Service.GetNumOfDoors();
                                        Car car = new Car(modelName, licenseNumber, manufacturerName, (Engine.eEngineType)engineType);
                                        car.Color = (Car.eColorsType)color;
                                        car.NumOfDoors = (Car.eDoorsType)numOfDoors;
                                        m_Garage.InsertNewVehicle(car, ownerName, ownerPhone);
                                        break;
                                    }
                                case (int)Vehicles.eVehicleType.Motorcycle:
                                    {

                                        int engineType = m_Service.GetEngineType();
                                        int licenseType = m_Service.GetLicenseType();
                                        int engineCapacity = m_Service.GetEngineCapacity();
                                        Motorcycle motorcycle = new Motorcycle(modelName, licenseNumber, manufacturerName, (Engine.eEngineType)engineType);
                                        motorcycle.LicenseType = (Motorcycle.eLicenseType)licenseType;
                                        motorcycle.EngineCapacity = engineCapacity;
                                        break;
                                    }
                                case (int)Vehicles.eVehicleType.Truck:
                                    {
                                        bool isDrivingHazardousSubstances = m_Service.GetIsDrivingHazardousSubstances();
                                        float maxCarryingWeight = m_Service.GetMaxCarryingWeight();
                                        Truck truck = new Truck(modelName, licenseNumber, manufacturerName, Engine.eEngineType.Gasolin);
                                        truck.IsDrivingHazardousSubstances = isDrivingHazardousSubstances;
                                        truck.MaxCarryingWeight = maxCarryingWeight;
                                        break;
                                    }
                            }
                            Console.Clear();
                            break;
                        }
                    case (int)eUserChoice.DisplayLicenseNumbers:
                        {
                            Console.Clear();
                            int hasFiltering = m_Service.GetHasFiltering();
                            if (hasFiltering == 1)
                            {
                                int filter = m_Service.GetCondition();
                                Console.WriteLine(m_Garage.GetVehiclesList((Garage.eVehicleCondition)filter));
                            }
                            else
                            {
                                Console.WriteLine(m_Garage.GetVehiclesList());
                            }
                            break;
                        }
                    case (int)eUserChoice.SetVehicleStatus:
                        {
                            Console.Clear();
                            string licenseNumber = m_Service.GetLicenseNumber();
                            int condition = m_Service.GetCondition();
                            m_Garage.UpdateCondition(licenseNumber, (Garage.eVehicleCondition)condition); // exeption
                            Console.Clear();
                            break;
                        }
                    case (int)eUserChoice.InflateWheels:
                        {
                            Console.Clear();
                            string licenseNumber = m_Service.GetLicenseNumber();
                            m_Garage.InflateWheel(licenseNumber); //exeption
                            Console.Clear();
                            break;
                        }
                    case (int)eUserChoice.FillGasolin:
                        {
                            Console.Clear();
                            string licenseNumber = m_Service.GetLicenseNumber();
                            float gasoilneAmount = m_Service.GetGasoilneAmount();
                            int gasolineType = m_Service.GetGasolineType();
                            m_Garage.RefuelVehicle(licenseNumber, (GasolineEngine.eFuelTypes)gasolineType,
                               gasoilneAmount); //exeption
                            Console.Clear();
                            break;
                        }
                    case (int)eUserChoice.ChargeBattery:
                        {
                            Console.Clear();
                            string licenseNumber = m_Service.GetLicenseNumber();
                            int minutesToCharge = m_Service.GetMinutesToCharge();
                            m_Garage.ChargeVehicle(licenseNumber, minutesToCharge); //exeption
                            Console.Clear();
                            break;
                        }
                    case (int)eUserChoice.DisplayFullVehicleData:
                        {
                            Console.Clear();
                            bool keepTryGetValidInput = true;
                            string licenseNumber = string.Empty;
                            while (keepTryGetValidInput)
                            {
                                licenseNumber = m_Service.GetLicenseNumber();
                                try
                                {
                                    StringBuilder result = m_Garage.GetVehicleData(licenseNumber);
                                    keepTryGetValidInput = false;
                                    Console.WriteLine(result.ToString());
                                }
                                catch (ArgumentException ae)
                                {
                                    keepTryGetValidInput = true;
                                    Console.WriteLine("licence number not found, please try again with other number");
                                }
                            }                 
                            break;
                        }
                    case (int)eUserChoice.Exit:
                        {
                            m_Run = false;
                            break;
                        }
                }
            } while (m_Run);
        }
    }
}

