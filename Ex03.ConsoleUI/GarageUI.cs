namespace Ex03.ConsoleUI
{
    using System;
    using System.Collections.Generic;
    using Ex03.GarageLogic;

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
            ChangeVehicleStatus,
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
                Console.Clear();
                switch (userChoose)
                {
                    case (int)eUserChoice.InsertNewVehicle:
                        {
                            int vehicleType = m_Service.GetVehicleType();
                            string ownerName = m_Service.GetOwnerName();
                            string ownerPhone = m_Service.GetOwnerPhone();
                            string modelName = m_Service.GetModelName();
                            string licenseNumber = m_Service.GetLicenseNumber();
                            string wheelManufacturerName = m_Service.GetWheelManufacturerName();

                            Console.Clear();
                            switch (vehicleType)
                            {
                                case (int)Vehicles.eVehicleType.Car:
                                    {
                                        int engineType = m_Service.GetEngineType();
                                        int color = m_Service.GetColorType();
                                        int numOfDoors = m_Service.GetNumOfDoors();

                                        Car car =(Car)VehicleFactory.CreateVehicle((Vehicles.eVehicleType)vehicleType, (Engine.eEngineType)engineType,
                                                                                   licenseNumber, modelName, wheelManufacturerName);
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

                                        Motorcycle motorcycle = (Motorcycle)VehicleFactory.CreateVehicle((Vehicles.eVehicleType)vehicleType, (Engine.eEngineType)engineType,
                                                                                                          licenseNumber, modelName, wheelManufacturerName);
                                        motorcycle.LicenseType = (Motorcycle.eLicenseType)licenseType;
                                        motorcycle.EngineCapacity = engineCapacity;
                                        m_Garage.InsertNewVehicle(motorcycle, ownerName, ownerPhone);
                                        break;
                                    }

                                case (int)Vehicles.eVehicleType.Truck:
                                    {
                                        bool isDrivingHazardousSubstances = m_Service.GetIsDrivingHazardousSubstances();
                                        float maxCarryingWeight = m_Service.GetMaxCarryingWeight();

                                        Truck truck = (Truck)VehicleFactory.CreateVehicle((Vehicles.eVehicleType)vehicleType, (Engine.eEngineType.Gasolin),
                                                                                                          licenseNumber, modelName, wheelManufacturerName);
                                        truck.IsDrivingHazardousSubstances = isDrivingHazardousSubstances;
                                        truck.MaxCarryingWeight = maxCarryingWeight;
                                        m_Garage.InsertNewVehicle(truck, ownerName, ownerPhone);
                                        break;
                                    }
                            }

                            Console.Clear();
                            break;
                        }

                    case (int)eUserChoice.DisplayLicenseNumbers:
                        {
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

                    case (int)eUserChoice.ChangeVehicleStatus:
                        {
                            string licenseNumber = string.Empty;
                            int condition = -1;
                            Console.Clear();
                            Console.WriteLine("changing vehicle status:");
                            try
                            {
                                licenseNumber = m_Service.GetLicenseNumber();
                                m_Garage.UpdateCondition(licenseNumber, (Garage.eVehicleCondition)condition);
                                condition = m_Service.GetCondition();
                                Console.WriteLine("status for vehicle number : {0} have been updated to: {1}", licenseNumber, ((Garage.eVehicleCondition)condition).ToString());
                            }
                            catch (KeyNotFoundException knfe)
                            {
                                Console.WriteLine(knfe.Message.ToString());
                                Console.WriteLine("going back to main menu");
                            }

                            break;
                        }

                    case (int)eUserChoice.InflateWheels:
                        {
                            string licenseNumber = string.Empty;
                            Console.Clear();
                            Console.WriteLine("infliting wheels to the max:");
                            try
                            {
                                licenseNumber = m_Service.GetLicenseNumber();
                                m_Garage.InflateWheel(licenseNumber);
                                Console.WriteLine("air for vehicle {0} inflate to the Max", licenseNumber);
                            }
                            catch (KeyNotFoundException knfe)
                            {
                                Console.WriteLine(knfe.Message.ToString());
                                Console.WriteLine("going back to main menu");
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message.ToString());
                                Console.WriteLine("some thing went wrong, going back to main menu");
                            }

                            break;
                        }

                    case (int)eUserChoice.FillGasolin:
                        {
                            bool keepTryingToRefuel = true;
                            string licenseNumber = string.Empty;
                            float gasoilneAmount = float.MinValue;
                            GasolineEngine.eFuelTypes gasolineType = 0;
                            Console.Clear();
                            while (keepTryingToRefuel)
                            {
                                try
                                {
                                    licenseNumber = m_Service.GetLicenseNumber();
                                    gasoilneAmount = m_Service.GetGasoilneAmount();
                                    gasolineType = m_Service.GetGasolineType();
                                    m_Garage.RefuelVehicle(licenseNumber, gasolineType, gasoilneAmount);
                                    keepTryingToRefuel = false;
                                }
                                catch (ArgumentException ae)
                                {
                                    Console.WriteLine(ae.Message.ToString());
                                    Console.WriteLine("please try again.");
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message.ToString());
                                    keepTryingToRefuel = false;
                                    break;
                                }
                            }

                            break;
                        }

                    case (int)eUserChoice.ChargeBattery:
                        {
                            bool keepTryingToCharge = true;
                            string licenseNumber = string.Empty;
                            int minutesToCharge = 0;
                            Console.Clear();
                            while (keepTryingToCharge)
                            {
                                try
                                {
                                    licenseNumber = m_Service.GetLicenseNumber();
                                    minutesToCharge = m_Service.GetMinutesToCharge();
                                    m_Garage.ChargeVehicle(licenseNumber, minutesToCharge);
                                    keepTryingToCharge = false;
                                }
                                catch (ArgumentException ae)
                                {
                                    Console.WriteLine(ae.Message.ToString());
                                    Console.WriteLine("please try again.");
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message.ToString());
                                    Console.WriteLine("going back to main menu");
                                    keepTryingToCharge = false;
                                    break;
                                }
                            }

                            break;
                        }

                    case (int)eUserChoice.DisplayFullVehicleData:
                        {
                            string licenseNumber = string.Empty;
                            string result = string.Empty;
                            Console.Clear();
                            try
                            {
                                licenseNumber = m_Service.GetLicenseNumber();
                                result = m_Garage.GetVehicleData(licenseNumber);
                                Console.WriteLine(result);
                            }
                            catch (KeyNotFoundException knfe)
                            {
                                Console.WriteLine(knfe.Message.ToString());
                                Console.WriteLine("going back to main menu");
                            }

                            break;
                        }

                    case (int)eUserChoice.Exit:
                        {
                            m_Run = false;
                            break;
                        }
                }
            }
            while (m_Run);
        }
    }
}
