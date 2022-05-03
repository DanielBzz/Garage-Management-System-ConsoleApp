using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03GarageLogic
{
    public class ElectricEngine : Vehicle
    {
        readonly float r_MaxBatteryLife;     //In hours
        float m_CurrentBattery;     //In hours

        public ElectricEngine(string i_Model, string i_ID, int i_NumOfTyres, float i_MaxBattery)
            : base(i_Model, i_ID, i_NumOfTyres)
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
