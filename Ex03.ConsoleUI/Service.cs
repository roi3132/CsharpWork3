using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    class Service
    {

        public void GetDisplayMenu()
        {
            Console.WriteLine(
    @"Choose your option:(1-7)
1) Enter new vehicle to the Garge.
2) Display vehicels that at the garage by license number.
3) Change the vehicle condition.
4) Inflate vehicle wheels to the max max.
5) Refuel vehicle.
6) Charge an electric vehicle.
7) Display all the vehicle information.
8) Exit.");
        }


        public int GetVehicleType() 
        {
            Console.WriteLine(@"
Please select vehicle type (1-3):
1) Car 
2) Motorcycle 
3) Truck");

            int vehicleType = GetChoiceFromUser(3);
            return vehicleType;
        }

        public string GetOwnerName() 
        {
            Console.WriteLine("Please enter Owner name:");
            string ownerName = Console.ReadLine();
            return ownerName;
        }

        public string GetOwnerPhone()
        {
            Console.WriteLine("Please enter Owner phone:");
            string ownerPhone = Console.ReadLine();
            return ownerPhone;
        }

        public string GetModelName()
        {
            Console.WriteLine("Please enter model name:");
            string modelName = Console.ReadLine();
            return modelName;
        }

        public string GetLicenseNumber()
        {
            Console.WriteLine("Please enter number license:");
            string licenseNumber = Console.ReadLine();
            return licenseNumber;
        }

        public string GetManufacturerName()
        {
            Console.WriteLine("Please enter wheel manufacturer name:");
            string manufacturerName = Console.ReadLine();
            return manufacturerName;
        }

        public int GetEngineCapacity()
        {
            Console.WriteLine("Please enter engine capacity:");
            int engineCapacity = GetNumberFromUser();
            return engineCapacity;
        }

        public float GetMaxCarryingWeight()
        {
            Console.WriteLine("Please enter maximum Carrying Weight:");
            float maxCarryingWeight = float.Parse(Console.ReadLine());
            return maxCarryingWeight;
        }

        public float GetGasoilneAmount()
        {
            Console.WriteLine("Please enter the amount of gasoline:");
            float gasoilneAmount = float.Parse(Console.ReadLine());
            return gasoilneAmount;
        }

        public int GetMinutesToCharge()
        {
            Console.WriteLine("Please enter the amount of Minutes to charge:");
            int minutesToCharge = int.Parse(Console.ReadLine());
            return minutesToCharge;
        }

        public int GetHasFiltering()
        {
            Console.WriteLine(@"
You want to filter the results by the condition of the vehicle in garage?
1) Yes
2) No");
            int hasFiltering = GetChoiceFromUser(2);
            return hasFiltering;
        }

        public int GetCondition()
        {
            Console.WriteLine(@"
Condition:
1) in repair
2) Fixed 
3) Paid");
            int filter = GetChoiceFromUser(3);
            return filter;
        }

        public int GetEngineType()
        {
            Console.WriteLine(@"
Please select engine type:
1) Gasolin
2) Electric");
            int engineType = GetChoiceFromUser(2);
            return engineType;
        }

        public int GetColorType()
        {
            Console.WriteLine(@"
Please select type of color:
1) Red
2) Silver
3) White
4) Black");
            int color = GetChoiceFromUser(4);
            return color;
        }

        public int GetNumOfDoors()
        {
            Console.WriteLine(@"
Please select number of doors:
1) Two
2) Three
3) Four
4) Five");

            int numOfDoors = GetChoiceFromUser(4);
            return numOfDoors;
        }

        public int GetLicenseType()
        {
            Console.WriteLine(@"
Please select License type:
1) A1
2) B1
3) AA
4) BB");
            int licenseType = GetChoiceFromUser(4);
            return licenseType;
        }

        public bool GetIsDrivingHazardousSubstances()
        {
            Console.WriteLine(@"
Please select if Is Driving Hazardous Substances:
1) Yes
2) No");
            bool isDrivingHazardousSubstances = false;
            if (GetChoiceFromUser(2) == 1)
            {
                isDrivingHazardousSubstances = true;
            }
            return isDrivingHazardousSubstances;
        }

        public int GetGasolineType()
        {
            Console.WriteLine(@"
Please select gasoline type:
1) Soler 
2) Octan95
3) Octan96
4) Octan98");
            int gasolineType = GetChoiceFromUser(4);
            return gasolineType;
        }

        public int GetChoiceFromUser( int i_UpperRange)
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
                    if (userInput <= i_UpperRange && userInput >= 1)
                    {
                        invalidChoice = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. plese enter number acoording to the menu options.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("invalide input. please enter only numbers and try again.");
                }
            }
            return userInput;
        }

        public int GetNumberFromUser()
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
                    invalidChoice = false;
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("You did not type anything. Please try again");
                }
                catch (FormatException )
                {
                    Console.WriteLine("Invalide input. please enter only numbers and try again");
                }
            }
            return userInput;
        }
    }
}
