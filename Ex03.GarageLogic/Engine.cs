using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        private float m_CurrentEnergyPrecentage = 0;        // make enum maybe of fullTank = 100 , EmptyTank = 0.

        public float EnergyPrecentage
        {
            get
            {
                return m_CurrentEnergyPrecentage;
            }

            set
            {
                m_CurrentEnergyPrecentage = value;
            }
        }
    }
}
