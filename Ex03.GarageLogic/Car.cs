namespace Ex03.GarageLogic
{
    using System;

    public class Car : Vehicles
    {
        private const GasolineEngine.eFuelTypes k_FuelType = GasolineEngine.eFuelTypes.Octan95;
        private const float k_MaxAmountOfFuel = 45;
        private const float K_MaxBatteryTime = 3.2f;
        private const int k_MaxAirPressure = 32;
        private const int k_NumberOfWheels = 4;    
        private eColorsType m_Color;
        private eDoorsType m_NumOfDoors;

        public eColorsType Color { get => m_Color; set => m_Color = value; }

        public eDoorsType NumOfDoors { get => m_NumOfDoors; set => m_NumOfDoors = value; }

        public Car(
            string i_ModelName,
            string i_LicenseNumber,
            string i_ManufacturerName,
            Engine.eEngineType i_EngineType)
                : base(
                      i_ModelName,
                      i_LicenseNumber,
                      i_EngineType)
        {
            m_ModelName = i_ModelName;
            m_LicenseNumber = i_LicenseNumber;
            if (i_EngineType == Engine.eEngineType.Gasolin)
            {
                Engine = new GasolineEngine(k_FuelType, k_MaxAmountOfFuel);
            }
            else if (i_EngineType == Engine.eEngineType.Electric) 
            {
                Engine = new ElectricEngine(K_MaxBatteryTime);
            }

            m_ListOfWheels = new Wheels[k_NumberOfWheels];
            for (int i = 0; i < k_NumberOfWheels; i++) 
            {
                m_ListOfWheels[i] = new Wheels(i_ManufacturerName, k_MaxAirPressure);
            }
        }

        public enum eColorsType
        {
            Red = 1,
            White,
            Black,
            Silver
        }

        public enum eDoorsType
        {
            Two = 1,
            Three,
            Four,
            Five
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(
                @"
Color: {0}
Num of doors: {1}",
Color,
NumOfDoors);
        }
    }
}
