using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Vehicles
    {
        protected string m_ModelName;
        protected string m_LicenseNumber;
        protected float m_PercentageOfEnergyLeft;
        protected Engine m_Engine;
        protected Wheels[] m_ListOfWheels; // change to List<>

        public Vehicles(string i_ModelName, string i_LicenseNumber, Engine.eEngineType i_EngineType)
        {
            m_ModelName = i_ModelName;
            m_LicenseNumber = i_LicenseNumber;
        }

        public Wheels[] Wheels
        {
            get { return m_ListOfWheels; }
        }

        public string LicenseNumber
        {
            get { return m_LicenseNumber; }
        }

        public override string ToString()
        {
            return string.Format(@"
Model:{0} 
License number:{1} 
Energy left:{2}%", m_ModelName, m_LicenseNumber,m_PercentageOfEnergyLeft, m_ListOfWheels[0].ToString());
        }

        public enum eVehicleType
        {
            Car = 1,
            Motorcycle,
            Truck
        }
    }
}
