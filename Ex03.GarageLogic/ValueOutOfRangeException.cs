using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;
        
        public float MaxValue
        {
            get
            {
                return m_MaxValue;
            }
        }

        public float MinValue
        {
            get
            {
                return m_MinValue;
            }
        }

        public ValueOutOfRangeException(float i_Max, float i_Min, float i_value)
            : base(string.Format("Exceeds {0} the {1}", i_Max < i_value ? "over" : "under", i_Max < i_value ? "maximum" : "minimum"))
        {
            m_MaxValue = i_Max;
            m_MinValue = i_Min;
        }

        public ValueOutOfRangeException(float i_Max, float i_Min, string i_Message)
           : base(i_Message)
        {
            m_MaxValue = i_Max;
            m_MinValue = i_Min;
        }
    }
}
