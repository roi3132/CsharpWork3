using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class UserInterface
    {
        private bool m_Run;
        private readonly Garage m_Garage;

        public UserInterface()
        {
            m_Run = false;
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
                DisplayMenu();
                int userChoose = GetChoiceFromUser(1, 7);
                switch (userChoose)
                {
                    case (int)eUserChoice.InsertNewVehicle:
                        {
                            Console.WriteLine("Please enter Owner name:");
                            string ownerName = Console.ReadLine();
                            Console.WriteLine("Please enter Owner phone:");
                            string ownerphone = Console.ReadLine();
                            Console.WriteLine("Please enter model name:");
                            string modelName = Console.ReadLine();
                            Console.WriteLine("Please enter number license:");
                            string licenseNumber = Console.ReadLine();
                            Console.WriteLine("Please enter wheel manufacturer name:");
                            string manufacturerName = Console.ReadLine();
                            Console.WriteLine(@"
Please select vehicle type (1-3):
1) Car 
2) Motorcycle 
3) Truck");

                            int vehicleType = GetChoiceFromUser(1, 3);
                            switch (vehicleType)
                            {
                                case (int)Vehicles.eVehicleType.Car:
                                    {
                                        Console.WriteLine(@"
Please select engine type:
1) Gasolin
2) Electric");
                                        int engineType = GetChoiceFromUser(1, 2);
                                        Console.WriteLine(@"
Please select type of color:
1) Red
2) Silver
3) White
4) Black");
                                        int color = GetChoiceFromUser(1, 4);
                                        Console.WriteLine(@"
Please select number of doors:
1) Two
2) Tree
3) Four
4) Five");

                                        int numOfDoors = GetChoiceFromUser(1, 4);
                                        Car car = new Car(modelName, licenseNumber, manufacturerName, (Engine.eEngineType)engineType);
                                        car.Color = (Car.eColorsType)color;
                                        car.NumOfDoors = (Car.eDoorsType)numOfDoors;
                                        m_Garage.InsertNewVehicle(car, ownerName, ownerphone);
                                        break;
                                    }
                                case (int)Vehicles.eVehicleType.Motorcycle:
                                    {
                                        Console.WriteLine(@"
Please select engine type:
1) Gasolin
2) Electric");
                                        int engineType = GetChoiceFromUser(1, 2);
                                        Console.WriteLine(@"
Please select License type:
1) A1
2) B1
3) AA
4) BB");
                                        int licenseType = GetChoiceFromUser(1, 4);
                                        Console.WriteLine("Please enter engine capacity:");
                                        int engineCapacity = int.Parse(Console.ReadLine());
                                        Motorcycle motorcycle = new Motorcycle(modelName, licenseNumber, manufacturerName, (Engine.eEngineType)engineType);
                                        motorcycle.LicenseType = (Motorcycle.eLicenseType)licenseType;
                                        motorcycle.EngineCapacity = engineCapacity;
                                        break;
                                    }
                                case (int)Vehicles.eVehicleType.Truck:
                                    {
                                        Console.WriteLine(@"
Please select if Is Driving Hazardous Substances:
1) Yes
2) No");
                                        bool isDrivingHazardousSubstances = false;
                                        if (GetChoiceFromUser(1, 2) == 1)
                                        {
                                            isDrivingHazardousSubstances = true;
                                        }
                                        Console.WriteLine("Please enter maximum Carrying Weight:");
                                        float maxCarryingWeight = float.Parse(Console.ReadLine());
                                        Truck truck = new Truck(modelName, licenseNumber, manufacturerName, Engine.eEngineType.Gasolin);
                                        truck.IsDrivingHazardousSubstances = isDrivingHazardousSubstances;
                                        truck.MaxCarryingWeight = maxCarryingWeight;
                                        break;
                                    }
                            }
                            break;
                        }
                    case (int)eUserChoice.DisplayLicenseNumbers:
                        {
                            Console.WriteLine(@"
You want to filter the results by the condition of the vehicle in garage?
1) Yes
2) No");
                            int hasFiltering = GetChoiceFromUser(1, 2);
                            if (hasFiltering == 1)
                            {
                                Console.WriteLine(@"
Condition:
1) in repair
2) Fixed 
3) Paid");
                                int filter = GetChoiceFromUser(1, 3);
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
                            Console.WriteLine("Please enter number license:");
                            string licenseNumber = Console.ReadLine();
                            Console.WriteLine(@"
Change the condition of the vehicle to:
1) in repair
2) Fixed 
3) Paid");
                            int condition = GetChoiceFromUser(1, 3);
                            m_Garage.UpdateCondition(licenseNumber, (Garage.eVehicleCondition)condition); // exeption
                            break;
                        }
                    case (int)eUserChoice.InflateWheels:
                        {
                            Console.WriteLine("Please enter number license:");
                            string licenseNumber = Console.ReadLine();
                            m_Garage.InflateWheel(licenseNumber); //exeption
                            break;
                        }
                    case (int)eUserChoice.FillGasolin:
                        {
                            Console.WriteLine("Please enter number license:");
                            string licenseNumber = Console.ReadLine();
                            Console.WriteLine("Please enter the amount of gasoline:");
                            float gasoilneAmount = float.Parse(Console.ReadLine());
                            Console.WriteLine(@"
Please select gasoline type:
1) Soler 
2) Octan95
3) Octan96
4) Octan98");
                            int gasolineType = GetChoiceFromUser(1, 4);
                            m_Garage.RefuelVehicle(licenseNumber, (GasolineEngine.eFuelTypes)gasolineType,
                                gasoilneAmount); //exeption
                            break;
                        }
                    case (int)eUserChoice.ChargeBattery:
                        {
                            Console.WriteLine("Please enter number license:");
                            string licenseNumber = Console.ReadLine();
                            Console.WriteLine("Please enter the amount of Minutes to charge:");
                            int minutesToCharge = int.Parse(Console.ReadLine());
                            m_Garage.ChargeVehicle(licenseNumber, minutesToCharge); //exeption
                            break;
                        }
                    case (int)eUserChoice.DisplayFullVehicleData:
                        {
                            Console.WriteLine("Please enter number license:");
                            string licenseNumber = Console.ReadLine();
                            Console.WriteLine(m_Garage.GetVehicleData(licenseNumber));
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


        public void DisplayMenu()
        {
            Console.WriteLine(
    @"Choose your option:(1-7)
1) Put new vehicle.
2) Display numbers license.
3) Setting the vehicle condition.
4) Inflate the wheels to max.
5) Refuel vehicle.
6) Charge an electric vehicle.
7) Display all vehicle datas.");
        }
        public int GetChoiceFromUser(int i_LowerRange, int i_UpperRange)
        {
            bool invalidChoice = true;
            string userInputStr = string.Empty;
            int userInput = -1;
            while (invalidChoice)
            {
                userInputStr = Console.ReadLine();
                try
                {
                    userInput = int.Parse(userInputStr);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid input. Please try agin.");
                    userInputStr = Console.ReadLine();
                    userInput = int.Parse(userInputStr);
                }
                if ((userInput <= i_UpperRange || userInput >= i_LowerRange))
                {
                    invalidChoice = false;

                }
                else
                {
                    Console.WriteLine("Invalid input. Please try agin.");
                }
            }
            return userInput;
        }

    }
}
