using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Motorcycle: Vehicles
    {
        private eLicenseType m_License;
        private int m_EngineCapacity;

        public enum eLicenseType
        {
            A1,
            B1,
            AA,
            BB
        }
    }
}
