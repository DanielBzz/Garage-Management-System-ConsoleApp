﻿using System;

namespace Ex03.GarageLogic
{
    public class Tyre
    {
        private float? m_MaxAirPressure;
        private float m_CurrentAirPressure;
        private string m_Manufacturer;

        public Tyre (float i_MaxAirPressure)
        {
            m_MaxAirPressure = i_MaxAirPressure;
        }

        public float MaxAirPressure
        {
            get
            {
                return m_MaxAirPressure.Value;
            }

            set
            {
                if (!m_MaxAirPressure.HasValue)
                {
                    if (value < 0)
                    {
                          throw new FormatException("Not a valid air pressure");
                    }

                    m_MaxAirPressure = value;
                }
                else
                {
                    throw new ArgumentException("Tyre at its max air pressure");
                }
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }

            set
            {
                Inflate(value - m_CurrentAirPressure);
            }
        }

        public string Manufacturer
        {
            get
            {
                return m_Manufacturer;
            }

            set
            {
                if (m_Manufacturer == null)
                {
                    if (isValidName(value))
                    {
                        m_Manufacturer = value;
                    }
                }
                else
                {
                    throw new ArgumentException("Tyre already has a Manufacturer");
                }
            }
        }

        public void Inflate(float i_AddPressureValue)
        {
            float newAirPressure = m_CurrentAirPressure + i_AddPressureValue;

            if (isValidAirPressure(newAirPressure))
            {
                m_CurrentAirPressure += i_AddPressureValue;
            }
        }

        public override string ToString()
        {
            string tyreInfo = string.Format(@"Tyre manufacturer: {0}
Tyre max air pressure: {1}
Tyre current air pressure: {2}", m_Manufacturer, m_MaxAirPressure, m_CurrentAirPressure);

            return tyreInfo;
        }

        public string ToShow()
        {
            return string.Format(@"Tyre max air pressure : {0}", m_MaxAirPressure);
        }

        private bool isValidName(string i_Value)
        {
            bool validName = i_Value != null;

            if (!validName)
            {
                throw new FormatException("Not a valid value");
            }

            return validName;
        }

        private bool isValidAirPressure(float i_Value)
        {
            bool validAirPressure = i_Value >= 0 && i_Value <= m_MaxAirPressure;

            if (!validAirPressure)
            {
                throw new ValueOutOfRangeException(m_MaxAirPressure.Value, 0, i_Value);
            }

            return validAirPressure;
        }
    }
}
