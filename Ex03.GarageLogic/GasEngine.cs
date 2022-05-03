using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03GarageLogic
{
    public class GasEngine : Vehicle
    {
        private readonly eFuelType r_FuelType;
        private readonly float r_MaxFuelCapacity;
        private float m_CurrentFuelCapacity;

        public GasEngine(string i_Model, string i_ID, int i_NumOfTyres, eFuelType i_FuelType, float i_MaxCapacity)
            : base(i_Model, i_ID, i_NumOfTyres)
        {
            r_FuelType = i_FuelType;
            r_MaxFuelCapacity = i_MaxCapacity;
            m_CurrentFuelCapacity = 0;
        }

        public void Refuel(float i_AmountToAdd, eFuelType i_FuelType)
        {
            if (!EqualsFuelType(i_FuelType))
            {
                // throw exception
            }

            if (overTheMaxCapacity(i_AmountToAdd))
            {
                // throw exception
            }

            m_CurrentFuelCapacity += i_AmountToAdd;
            EnergyPrecentage = (m_CurrentFuelCapacity / r_MaxFuelCapacity) * 100;
        }

        private bool overTheMaxCapacity(float i_AmountToAdd)
        {
            return r_MaxFuelCapacity >= m_CurrentFuelCapacity + i_AmountToAdd;
        }

        private bool EqualsFuelType(eFuelType i_FuelType)
        {
            return r_FuelType == i_FuelType;
        }

    }
}
