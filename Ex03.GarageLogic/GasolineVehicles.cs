using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class GasolineVehicles
    {
        private eFuelTypes m_FuelType;
        private float m_CurrentAmountOfFuel;
        private float m_MaxAmountOfFuel;

        public void Refueling(float i_LitersToRefuel, eFuelTypes i_FuelType)
        {
            if (i_LitersToRefuel + m_CurrentAmountOfFuel < m_CurrentAmountOfFuel ||
                i_FuelType == m_FuelType)
            {
                m_CurrentAmountOfFuel += i_LitersToRefuel;
            }
            else
            {
                throw new ValueOutOfRangeException(m_MaxAmountOfFuel,GetMinAmountFuel());
            }      
        }

        public float GetMinAmountFuel() 
        {
            return m_MaxAmountOfFuel - m_CurrentAmountOfFuel;
        }

        public enum eFuelTypes
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }


    }
}
