using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Car: Vehicles
    {
        private eColorsType m_Color;
        private eDoorsType m_NumOfDoors;

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
    }
}
