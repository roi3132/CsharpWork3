using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.GasolineVehicles;

namespace Ex03.GarageLogic
{
    class Garage
    {
        private string m_OwnerName;
        private string m_OwnerPhone;
        private eVehicleCondition m_Condition;
        private Dictionary<string, Vehicles> m_VechilesData;
        private Dictionary<string, eVehicleCondition> m_VechilesStatus;


        public bool PutCar(Vehicles i_Vehicles)
        {
            bool carIsInGarage = false;
            if (m_VechilesData.ContainsKey(i_Vehicles.LicenseNumber))
            {
                m_VechilesStatus[i_Vehicles.LicenseNumber] = eVehicleCondition.InRepair;
                carIsInGarage = true;
            }
            else
            {
                m_VechilesStatus.Add(i_Vehicles.LicenseNumber, eVehicleCondition.InRepair);
                m_VechilesData.Add(i_Vehicles.LicenseNumber, i_Vehicles);
            }
            return !carIsInGarage;
        }

        public StringBuilder GetVehiclesList(eVehicleCondition i_FilterByCondition)
        {
            StringBuilder vehiclesList = new StringBuilder(string.Empty);
            foreach (KeyValuePair<string, eVehicleCondition> vehicle in m_VechilesStatus)
            {
                if (vehicle.Value == i_FilterByCondition)
                {
                    vehiclesList.Append(vehicle.Key + Environment.NewLine);
                }
            }
            return vehiclesList;
        }

        public StringBuilder GetVehiclesList()
        {
            StringBuilder vehiclesList = new StringBuilder(string.Empty);
            foreach (KeyValuePair<string, eVehicleCondition> vehicle in m_VechilesStatus)
            {
                vehiclesList.Append(vehicle.Key + Environment.NewLine);
            }
            return vehiclesList;
        }

        public bool Update(string i_NumberLicense, eVehicleCondition i_Condition)
        {
            bool vehiclelExsist = true;
            if (m_VechilesStatus.ContainsKey(i_NumberLicense))
            {
                m_VechilesStatus[i_NumberLicense] = i_Condition;
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
                List<Wheels> wheels = m_VechilesData[i_NumberLicense].Wheels;
                foreach (Wheels wheel in wheels)
                {
                    float pressureToFill = wheel.GetMinAirPressure();
                    wheel.InflatingWheel(pressureToFill);
                }
            }
            else
            {
                vehiclelExsist = false;
            }
            return vehiclelExsist;
        }

        public bool RefuelVehicle(string i_NumberLicense, eFuelTypes i_FuelTypes, float i_GasolineToFill)
        {
            bool vehiclelExsist = true;
            if (m_VechilesData.ContainsKey(i_NumberLicense))
            {
                if(m_VechilesData[i_NumberLicense])
                List<Wheels> wheels = m_VechilesData[i_NumberLicense].Wheels;
                foreach (Wheels wheel in wheels)
                {
                    float pressureToFill = wheel.GetMinAirPressure();
                    wheel.InflatingWheel(pressureToFill);
                }
            }
            else
            {
                vehiclelExsist = false;
            }
            return vehiclelExsist;
        }

        public bool ChargeVehicle(string, int)
        {

        }

        public string GetVehicleData(string)
        {

        }

        public enum eVehicleCondition
        {
            InRepair,
            Fixed,
            Paid
        }
    }
}
