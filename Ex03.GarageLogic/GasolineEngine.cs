using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GasolineEngine : Engine
    {
        private eFuelTypes m_FuelType;
        private float m_CurrentAmountOfFuel;
        private float m_MaxAmountOfFuel;

        public GasolineEngine(eFuelTypes i_FuelType, float i_MaxAmountOfFuel)    
        {
            m_CurrentAmountOfFuel = 0;
            m_FuelType = i_FuelType;
            m_MaxAmountOfFuel = i_MaxAmountOfFuel;
        }

        public eFuelTypes FuelType
        {
            get { return m_FuelType; }
        }

        public float CurrentAmountOfFuel
        {
            set { m_CurrentAmountOfFuel = value; }
        }

        public void Refueling(float i_LitersToRefuel, eFuelTypes i_FuelType)
        {
            if (i_LitersToRefuel + m_CurrentAmountOfFuel < m_MaxAmountOfFuel)
            {
                if (i_FuelType == m_FuelType)
                {
                    m_CurrentAmountOfFuel += i_LitersToRefuel;
                    
                }
                else 
                {
                    throw new ArgumentException("The fuel type does not match");
                }
            }
            else
            {
                throw new ValueOutOfRangeException(0, GetMaxAmountToFill());
            }      
        }

        public float GetMaxAmountToFill() 
        {
            return m_MaxAmountOfFuel - m_CurrentAmountOfFuel;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(@"
Fuel type:{0} 
Current amount of fuel:{1} 
Max amount of fuel:{2}", m_FuelType,m_CurrentAmountOfFuel,m_MaxAmountOfFuel);
        }

        public enum eFuelTypes
        {
            Soler = 1,
            Octan95,
            Octan96,
            Octan98
        }
    }
}
