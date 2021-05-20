namespace Ex03.GarageLogic
{
    using System;

    public class Motorcycle : Vehicles
    {
        private const GasolineEngine.eFuelTypes k_FuelType = GasolineEngine.eFuelTypes.Octan98;
        private const float k_MaxAmountOfFuel = 6;
        private const float K_MaxBatteryTime = 1.8f;
        private const int k_MaxAirPressure = 30;
        private const int k_NumberOfWheels = 2;
        private eLicenseType m_LicenseType;
        private int m_EngineCapacity;

        public Motorcycle(
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

        public enum eLicenseType
        {
            A1,
            B1,
            AA,
            BB
        }

        public eLicenseType LicenseType { get => m_LicenseType; set => m_LicenseType = value; }

        public int EngineCapacity { get => m_EngineCapacity; set => m_EngineCapacity = value; }

        public override string ToString()
        {
            return base.ToString() + string.Format(
                @"
License type:{0} 
Engine capacity:{1}",
                LicenseType,
                EngineCapacity);
        }
    }
}
