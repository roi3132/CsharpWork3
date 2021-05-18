using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicles
    {
        private const float k_MaxAirPressure = 30;
        private const int k_NumberOfWheels = 16;
        private bool m_IsDrivingHazardousSubstances;
        private float m_MaxCarryingWeight;

        public Truck(string i_ModelName, string i_LicenseNumber,
        eDoorsType i_NumOfDoors, string i_ManufacturerName)
        : base(i_ModelName, i_LicenseNumber)
        {
            m_Color = i_Color;
            m_NumOfDoors = i_NumOfDoors;
            m_ListOfWheels = new Wheels[k_NumberOfWheels];
            for (int i = 0; i < k_NumberOfWheels; i++)
            {
                m_ListOfWheels[i] = new Wheels(i_ManufacturerName, k_MaxAirPressure);
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("Is driving hazardous substances:{0} MaximumCarryingWeight{1}",
                m_IsDrivingHazardousSubstances,m_MaxCarryingWeight);
        }
    }
}
