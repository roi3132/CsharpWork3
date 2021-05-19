using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private readonly Dictionary<string, List<object>> m_VechilesData;

        public Garage()
        {
            m_VechilesData = new Dictionary<string, List<object>>();
        }

        public bool InsertNewVehicle(Vehicles i_Vehicles, string i_OwnerName, string i_Phone)
        {
            bool carIsInGarage = false;
            if (m_VechilesData.ContainsKey(i_Vehicles.LicenseNumber))
            {
                m_VechilesData[i_Vehicles.LicenseNumber][1] = eVehicleCondition.InRepair;
                carIsInGarage = true;
            }
            else
            {
                List<object> data = new List<object>() { i_Vehicles, eVehicleCondition.InRepair, i_OwnerName, i_Phone };
                m_VechilesData.Add(i_Vehicles.LicenseNumber, data);
            }
            return !carIsInGarage;
        }

        public StringBuilder GetVehiclesList(eVehicleCondition i_FilterByCondition)
        {
            StringBuilder vehiclesList = new StringBuilder(string.Empty);
            foreach (KeyValuePair<string, List<object>> vehicle in m_VechilesData)
            {
                if ((eVehicleCondition)vehicle.Value[1] == i_FilterByCondition)
                {
                    vehiclesList.Append(vehicle.Key + Environment.NewLine);
                }
            }
            if (vehiclesList.ToString() == string.Empty)
            {
                vehiclesList.Append("No vehicle in the garage");
            }
            return vehiclesList;
        }

        public StringBuilder GetVehiclesList()
        {
            StringBuilder NumberLicenseList = new StringBuilder(string.Empty);
            foreach (KeyValuePair<string, List<object>> vehicle in m_VechilesData)
            {
                NumberLicenseList.Append(vehicle.Key + Environment.NewLine);
            }
            return NumberLicenseList;
        }

        public bool UpdateCondition(string i_NumberLicense, eVehicleCondition i_Condition)
        {
            bool vehiclelExsist = true;
            if (m_VechilesData.ContainsKey(i_NumberLicense))
            {
                m_VechilesData[i_NumberLicense][1] = i_Condition;
            }
            else
            {
                vehiclelExsist = false;
            }
            return vehiclelExsist;
        }

        public bool InflateWheel(string i_NumberLicense)
        {
            bool vehiclelExsist = true;
            if (m_VechilesData.ContainsKey(i_NumberLicense))
            {
                Vehicles v = m_VechilesData[i_NumberLicense][0] as Vehicles;
                foreach (Wheels wheel in v.Wheels)
                {
                    float pressureToFill = wheel.GetAirPressureToAddTheMax();
                    wheel.InflatingWheel(pressureToFill);
                }
            }
            else
            {
                throw new KeyNotFoundException("no car with this license plate");
            }
            return vehiclelExsist;
        }

        public bool RefuelVehicle(string i_NumberLicense, GasolineEngine.eFuelTypes i_FuelTypes, float i_GasolineToFill)
        {
            bool vehiclelExsist = true;
           
            if (m_VechilesData.ContainsKey(i_NumberLicense))
            {
                try
                {
                    Vehicles tempVehicle = m_VechilesData[i_NumberLicense][0] as Vehicles;
                    GasolineEngine currentGasolineVehicles = tempVehicle.Engine as GasolineEngine;
                    currentGasolineVehicles.Refueling(i_GasolineToFill, i_FuelTypes);
                    //precent calc of ampunt of fuel
                    tempVehicle.PercentageOfEnergyLeft = ((currentGasolineVehicles.CurrentAmountOfFuel * 100) / currentGasolineVehicles.MaxAmountOfFuel);
                }
                catch(NullReferenceException)
                {
                    throw new NullReferenceException("the car is Elcetric power and you try to put fuel in it, please recharge insted");
                }
                catch(Exception e)
                {
                    throw e;
                }
            }
            else
            {
                throw new KeyNotFoundException("no vehichle with this license number in garage");
            }
            return vehiclelExsist;
        }

        public bool ChargeVehicle(string i_NumberLicense, int i_MinutesToCharge)
        {
            bool vehiclelExsist = true;

            if (m_VechilesData.ContainsKey(i_NumberLicense))
            {
                Vehicles tempVehicle = m_VechilesData[i_NumberLicense][0] as Vehicles;
                ElectricEngine currentElectricVehicles = tempVehicle.Engine as ElectricEngine;
                currentElectricVehicles.BatteryCharging(i_MinutesToCharge);
            }
            else
            {
                throw new KeyNotFoundException("no vehichle with this license number in garage");
            }
            return vehiclelExsist;
        }

        public StringBuilder GetVehicleData(string i_NumberLicense)
        {
            StringBuilder vehicleData = new StringBuilder();
            // if key not found throw KeyNotFoundException
            try
            {
                List<object> data = m_VechilesData[i_NumberLicense];
                vehicleData.Append(data[2]);
                vehicleData.Append(data[3]);
                foreach (object o in data)
                {
                    vehicleData.Append(o.ToString());
                }
                vehicleData.Append(data[1]);
            }
            catch(KeyNotFoundException knfe)
            {
                throw new ArgumentException("licence plate not found", i_NumberLicense, knfe);
            }
            return vehicleData;
        }

        public enum eVehicleCondition
        {
            InRepair,
            Fixed,
            Paid
        }

        public bool IsVehicleExsist(string i_NumberLicense)
        {
            bool vehicleFound = false;

            try
            {
                List<object> data = m_VechilesData[i_NumberLicense];
                vehicleFound = true;
            }
            catch (KeyNotFoundException knfe)
            {
                vehicleFound = false;
            }
            return vehicleFound;
        }
    }
}
