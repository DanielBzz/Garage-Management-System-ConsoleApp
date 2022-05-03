using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        private readonly float r_MaxBatteryLife;
        private float m_CurrentBattery;

        public ElectricEngine(float i_MaxBattery)
        {
            r_MaxBatteryLife = i_MaxBattery;
            m_CurrentBattery = 0;
        }

        public void Charge(float i_AmountToAdd)
        {
            if (overTheMaxCapacity(i_AmountToAdd))
            {
                // throw exception
            }

            m_CurrentBattery += i_AmountToAdd;
            EnergyPrecentage = (m_CurrentBattery / r_MaxBatteryLife) * 100;
        }

        private bool overTheMaxCapacity(float i_AmountToAdd)
        {
            return r_MaxBatteryLife >= m_CurrentBattery + i_AmountToAdd;
        }
    }
}
