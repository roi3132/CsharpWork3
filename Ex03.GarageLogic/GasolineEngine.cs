namespace Ex03.GarageLogic
{
    using System;

    public class GasolineEngine : Engine
    {
        private eFuelTypes m_FuelType;
        private float m_CurrentAmountOfFuel;
        private float m_MaxAmountOfFuel;

        public enum eFuelTypes
        {
            Soler = 1,
            Octan95,
            Octan96,
            Octan98
        }

        public GasolineEngine(eFuelTypes i_FuelType, float i_MaxAmountOfFuel)
        {
            CurrentAmountOfFuel = 0;
            m_FuelType = i_FuelType;
            MaxAmountOfFuel = i_MaxAmountOfFuel;
        }

        public eFuelTypes FuelType
        {
            get { return m_FuelType; }
        }

        public float CurrentAmountOfFuel { get => m_CurrentAmountOfFuel; set => m_CurrentAmountOfFuel = value; }

        public float MaxAmountOfFuel { get => m_MaxAmountOfFuel; set => m_MaxAmountOfFuel = value; }

        public void Refueling(float i_LitersToRefuel, eFuelTypes i_FuelType)
        {
            if (i_LitersToRefuel + CurrentAmountOfFuel < MaxAmountOfFuel)
            {
                if (i_FuelType == m_FuelType)
                {
                    CurrentAmountOfFuel += i_LitersToRefuel;           
                }
                else 
                {
                    throw new ArgumentException("The fuel type does not match");
                }
            }
            else
            {
                throw new ValueOutOfRangeException(0, MaxAmountOfFuel - CurrentAmountOfFuel);
            }      
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(
                @"
Fuel type:{0} 
Current amount of fuel:{1} 
Max amount of fuel:{2}", 
                m_FuelType,
                CurrentAmountOfFuel,
                MaxAmountOfFuel);
        }
    }
}
