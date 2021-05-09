using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Wheels
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;

        public void InflatingWheel(float i_AirPressure)
        {
            if (i_AirPressure + m_CurrentAirPressure < m_MaxAirPressure)
            {
                m_CurrentAirPressure += i_AirPressure;
            }
            else
            {
                throw new ValueOutOfRangeException(m_MaxAirPressure, GetMinAirPressure());
            }
        }
        public float GetMinAirPressure() 
        {
            return m_MaxAirPressure - m_CurrentAirPressure;
        }
    }
}
