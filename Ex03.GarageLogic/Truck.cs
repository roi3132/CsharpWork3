using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicles
    {
        private const int k_NumberOfWheels = 16;
        private bool m_IsDrivingHazardousSubstances;
        private float m_MaximumCarryingWeight;

        public Truck(bool i_IsDrivingHazardousSubstances, float i_MaximumCarryingWeight
            , string i_ModelName, string i_LicenseNumber, float i_PercentageOfEnergyLeft)
            : base(i_ModelName, i_LicenseNumber, i_PercentageOfEnergyLeft)
        {
            m_IsDrivingHazardousSubstances = i_IsDrivingHazardousSubstances;
            m_MaximumCarryingWeight = i_MaximumCarryingWeight;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("Is driving hazardous substances:{0} MaximumCarryingWeight{1}",
                m_IsDrivingHazardousSubstances,m_MaximumCarryingWeight);
        }
    }
}
