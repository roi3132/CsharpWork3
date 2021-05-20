namespace Ex03.GarageLogic
{
    using System;

    public class Vehicles
    {
        protected string m_ModelName;
        protected string m_LicenseNumber;
        private float m_PercentageOfEnergyLeft;
        private Engine m_Engine;
        protected Wheels[] m_ListOfWheels;

        public Vehicles(string i_ModelName, string i_LicenseNumber, Engine.eEngineType i_EngineType)
        {
            m_ModelName = i_ModelName;
            m_LicenseNumber = i_LicenseNumber;
        }

        public Wheels[] Wheels
        {
            get { return m_ListOfWheels; }
        }

        public string LicenseNumber
        {
            get { return m_LicenseNumber; }
        }

        public Engine Engine { get => m_Engine; set => m_Engine = value; }

        public float PercentageOfEnergyLeft { get => m_PercentageOfEnergyLeft; set => m_PercentageOfEnergyLeft = value; }

        public override string ToString()
        {
            return string.Format(
                @"
Model:{0} 
License number:{1} 
Energy left:{2}%",
m_ModelName,
m_LicenseNumber,
PercentageOfEnergyLeft) + m_ListOfWheels[0].ToString() + m_Engine.ToString();
        }

        public enum eVehicleType
        {
            Car = 1,
            Motorcycle,
            Truck
        }
    }
}
