﻿using System;

namespace Ex03.GarageLogic
{
    public class GasEngine : Engine
    {
        private readonly eFuelType r_FuelType;

        public GasEngine(eFuelType i_FuelType, float i_MaxCapacity)
            : base(i_MaxCapacity)
        {
            r_FuelType = i_FuelType;
        }

        public void Refuel(float i_AmountToAdd, eFuelType i_FuelType)
        {
            if (!r_FuelType.Equals(i_FuelType))
            {
                throw new ArgumentException(string.Format("Not match fuel type, please select {0} ", Enum.GetName(typeof(eFuelType), r_FuelType)));
            }

            if (!IsValidNewCapacity(i_AmountToAdd))
            {
                m_CurrentEnergy += i_AmountToAdd;
            }
        }

        public override string ToString()
        {
            string engineInfo = string.Format(@"Motor powered by : Gas
Fuel type : {0}
{1}", r_FuelType, base.ToString());

            return engineInfo;
        }

        public override string ToShow()
        {
            string engineInfo = string.Format(@"Motor powered by : Gas
Fuel type : {0}", r_FuelType);

            return engineInfo;
        }
    }
}
