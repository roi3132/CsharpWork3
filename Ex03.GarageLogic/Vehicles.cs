using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Vehicles
    {
        private string m_ModelName;
        private string m_LicenseNumber;
        private float m_Energy;
        private List<Wheels> m_ListOfWheels;
        public List<Wheels> Wheels 
        {
            get { return m_ListOfWheels; }
        }


        public string LicenseNumber 
        {
            get { return m_LicenseNumber; }
        }

    }
}
