using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricVehicles :Vehicles
    {
        const int k_NumberOfWheels = 4;
        private float m_RemainingBatteryTime;
        private float m_MaxBatteryTime;

        public ElectricVehicles(float i_RemainingBatteryTime, float i_MaxBatteryTime
             , string i_ModelName, string i_LicenseNumber, float i_PercentageOfEnergyLeft)
            : base(i_ModelName, i_LicenseNumber, i_PercentageOfEnergyLeft)
        {
            m_MaxBatteryTime = i_MaxBatteryTime;
            m_RemainingBatteryTime = i_RemainingBatteryTime;
        }

        public void BatteryCharging(float i_TimeToCharge)
        {
            if (m_RemainingBatteryTime + i_TimeToCharge < m_MaxBatteryTime)
            {
                m_RemainingBatteryTime += i_TimeToCharge;
            }
            else
            {
                throw new ValueOutOfRangeException(0, m_MaxBatteryTime);
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("Remaining battery time:{0} Max battery time:{1}");
        }
    }
}
