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
        protected Wheels[] m_ListOfWheels;

        public Vehicles(string i_ModelName, string i_LicenseNumber, float i_PercentageOfEnergyLeft)
        {
            m_ModelName = i_ModelName;
            m_LicenseNumber = i_LicenseNumber;
            m_PercentageOfEnergyLeft = i_PercentageOfEnergyLeft;
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
            return string.Format("Model:{0} License number:{1} Energy left:{2}% {3}", m_ModelName, m_LicenseNumber,
                m_PercentageOfEnergyLeft, m_ListOfWheels[0].ToString());
        }
    }
}
