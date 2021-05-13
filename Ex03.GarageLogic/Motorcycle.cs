using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicles
    {
        private const int k_NumberOfWheels = 2;
        private eLicenseType m_LicenseType;
        private int m_EngineCapacity;

        public Motorcycle(eLicenseType i_LicenseType, int i_EngineCapacity
            , string i_ModelName, string i_LicenseNumber, float i_PercentageOfEnergyLeft)
            : base(i_ModelName, i_LicenseNumber, i_PercentageOfEnergyLeft, k_NumberOfWheels)
        {
            m_LicenseType = i_LicenseType;
            m_EngineCapacity = i_EngineCapacity;
        }

        public enum eLicenseType
        {
            A1,
            B1,
            AA,
            BB
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("License type:{0} Engine capacity{1}",
                m_LicenseType,m_EngineCapacity);
        }
    }
}
