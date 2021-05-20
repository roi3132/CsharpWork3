namespace Ex03.GarageLogic
{
    using System;

    public class ElectricEngine : Engine
    {
        private float m_RemainingBatteryTime;
        private float m_MaxBatteryTime;

        public ElectricEngine(float i_MaxBatteryTime)
        {
            MaxBatteryTime = i_MaxBatteryTime;
            RemainingBatteryTime = 0;
        }

        public float RemainingBatteryTime { get => m_RemainingBatteryTime; set => m_RemainingBatteryTime = value; }

        public float MaxBatteryTime { get => m_MaxBatteryTime; set => m_MaxBatteryTime = value; }

        public void BatteryCharging(float i_TimeToCharge)
        {
            if (RemainingBatteryTime + i_TimeToCharge < MaxBatteryTime)
            {
                RemainingBatteryTime += i_TimeToCharge;
            }
            else
            {
                throw new ValueOutOfRangeException(0, MaxBatteryTime - RemainingBatteryTime);
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(
                @"
Remaining battery time:{0} 
Max battery time:{1}",
RemainingBatteryTime,
MaxBatteryTime);
        }
    }
}
