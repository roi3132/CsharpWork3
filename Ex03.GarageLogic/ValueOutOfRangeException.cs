namespace Ex03.GarageLogic
{
    using System;

    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;

        public ValueOutOfRangeException(
            float i_MaxValue,
            float i_MinValue) : base(
                string.Format(
              @"An error occurred while trying to put a value not in the range.
                            Please insert input between {0} to {1}",
              i_MinValue,
              i_MaxValue)) /// not good
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;
        }

        public ValueOutOfRangeException(
            Exception i_InnerException,
            float i_MaxValue,
            float i_MinValue) : base(
                string.Format(
                @"An error occurred while trying to put a value not in the range.
                            Please insert input between {0} to {1}",
                i_MinValue,
                i_MaxValue),
            i_InnerException)
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;
        }

        public float MaxValue
        {
            get { return m_MaxValue; }
        }

        public float MinValue
        {
            get { return m_MinValue; }
        }
    }
}
