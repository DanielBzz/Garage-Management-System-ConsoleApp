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
            m_CurrentEnergyCapacity = 0;
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
            return string.Format(@"{0}% energy left", EnergyPrecentage);
        }

        protected bool overTheMaxCapacity(float i_AmountToAdd)
        {
            return r_MaxEnergyCapacity >= m_CurrentEnergyCapacity + i_AmountToAdd;
        }
    }
}
