using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Car : Vehicles
    {
        private const int k_NumberOfWheels = 4;
        private eColorsType m_Color;
        private eDoorsType m_NumOfDoors;

        public Car(string i_ModelName, string i_LicenseNumber, float i_PercentageOfEnergyLeft
            ,eColorsType i_Color, eDoorsType i_NumOfDoors) 
            : base(i_ModelName, i_LicenseNumber, i_PercentageOfEnergyLeft)
        {
            m_Color = i_Color;
            m_NumOfDoors = i_NumOfDoors;
            m_ListOfWheels = new Wheels[k_NumberOfWheels];
            for (int i = 0; i < k_NumberOfWheels; i++) 
            {

            }
        }

        public enum eColorsType
        {
            Red,
            White,
            Black,
            Silver
        }

        public enum eDoorsType
        {
            Two,
            Three,
            Four,
            Five
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("Color:{0} Num of doors:{1}",m_Color,m_NumOfDoors);
        }
    }
}
