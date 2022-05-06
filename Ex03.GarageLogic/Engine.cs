using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        protected readonly float r_MaxEnergyCapacity; // make enum maybe of fullTank = 100 , EmptyTank = 0.
        protected float m_CurrentEnergyCapacity;

        public Engine(float i_MaxCapacity)
        {
            r_MaxEnergyCapacity = i_MaxCapacity;
        }

        public float CurrentEnergyCapacity
        {
            get
            {
                return m_CurrentEnergyCapacity;
            }

            set
            {
                if (!IsValidNewCapacity(value - CurrentEnergyCapacity))
                {
                    m_CurrentEnergyCapacity = value;
                }
            }
        }

        public float EnergyPrecentage
        {
            get
            {
                return (m_CurrentEnergyCapacity / r_MaxEnergyCapacity) * 100;
            }
        }

        public override string ToString()
        {
            return string.Format(@"{0} % energy left", EnergyPrecentage);
        }

        public abstract string ToShow();

        protected bool IsValidNewCapacity(float i_AmountToAdd)
        {
            float newCapacity = m_CurrentEnergyCapacity + i_AmountToAdd;
            bool overTheMax = r_MaxEnergyCapacity < newCapacity || newCapacity < 0;

            if (overTheMax)
            {
                throw new ValueOutOfRangeException(r_MaxEnergyCapacity, 0, newCapacity);
            }

            return overTheMax;
        }
    }
}
