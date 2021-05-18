using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class UserInterface
    {
        private bool m_Stop;
        private readonly Garage m_Garage;

        public UserInterface()
        {
            m_Stop = false;
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
        public enum eVehicleType
        {
            Car = 1,
            motorcycle,
            truck
        }

        public void Start()
        {
            do
            {
                DisplayMenu();
                string userChooseStr = Console.ReadLine();
                try
                {
                    int userChoose; ;               
                    Enum.TryParse(userChooseStr, out userChoose);
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
                                string numberLicense = Console.ReadLine();
                                Console.WriteLine("Please enter wheel manufacturer name:");
                                string manufacturerName = Console.ReadLine();
                                Console.WriteLine(@"Please select vehicle type:
1) Car 
2) Motorcycle 
3) Truck");
                                string vehicleTypeStr = Console.ReadLine();
                                int vehicleType;
                                Enum.TryParse(vehicleTypeStr, out vehicleType);
                                switch (vehicleType) 
                                {
                                    case (int)eVehicleType.Car:
                                    {
                                            Car car = new Car();
                                            break;
                                    }
                                }

                                m_Garage.InsertNewVehicle("123165");
                                break;
                            }
                    }

                }
                catch (Exception e) 
                {
                    
                }
              
            } while (m_Stop);   
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
        
    }
}
