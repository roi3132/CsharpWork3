using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheels
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;

        public Wheels(string i_ManufacturerName, float i_MaxAirPressure) 
        {
            m_CurrentAirPressure = 0;
            m_ManufacturerName = i_ManufacturerName;
            m_MaxAirPressure = i_MaxAirPressure;
        }

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

        public override string ToString()
        {
            return string.Format("Manufacturer name:{0} Current air pressure:{1} Max air pressure:{2}"
                ,m_ManufacturerName,m_CurrentAirPressure,m_MaxAirPressure); 
        }


    }
}
