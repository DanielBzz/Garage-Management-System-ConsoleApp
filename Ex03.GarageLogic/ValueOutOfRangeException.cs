using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;
        public string m_ErorMsg;
        //
        public ValueOutOfRangeException(float x)
        {
            if (m_MaxValue < x)
                m_ErorMsg = "over the max";
            if (m_MinValue > x)
                m_ErorMsg = "under the law";
        }
    }
}
