using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicles
    {
        private const GasolineEngine.eFuelTypes k_FuelType = GasolineEngine.eFuelTypes.Soler;
        private const float k_MaxAmountOfFuel = 120;
        private const float k_MaxAirPressure = 26;
        private const int k_NumberOfWheels = 16;
        private bool m_IsDrivingHazardousSubstances;
        private float m_MaxCarryingWeight;

        public bool IsDrivingHazardousSubstances { get; set; }
        public float MaxCarryingWeight { get; set; }

        public Truck(string i_ModelName, string i_LicenseNumber, string i_ManufacturerName
            , Engine.eEngineType i_EngineType)
                : base(i_ModelName, i_LicenseNumber, i_EngineType)
        {
            m_ModelName = i_ModelName;
            m_LicenseNumber = i_LicenseNumber;
            m_Engine = new GasolineEngine(k_FuelType, k_MaxAmountOfFuel);
            m_ListOfWheels = new Wheels[k_NumberOfWheels];
            for (int i = 0; i < k_NumberOfWheels; i++)
            {
                m_ListOfWheels[i] = new Wheels(i_ManufacturerName, k_MaxAirPressure);
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("Is driving hazardous substances:{0} MaximumCarryingWeight{1}",
                m_IsDrivingHazardousSubstances, m_MaxCarryingWeight);
        }
    }
}
