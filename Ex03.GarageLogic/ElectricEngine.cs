using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        public ElectricEngine(float i_MaxBattery)
            : base(i_MaxBattery)
        {
        }

        public void Charge(float i_AmountToAdd)
        {
            if (overTheMaxCapacity(i_AmountToAdd))
            {
                throw new ValueOutOfRangeException(r_MaxEnergyCapacity, 0, m_CurrentEnergyCapacity + i_AmountToAdd);
            }

            m_CurrentEnergyCapacity += i_AmountToAdd;
        }

        public override string ToString()
        {
            string engineInfo = string.Format(@"Engine powered by : Electric
{0}", base.ToString());

            return engineInfo;
        }
    }
}
