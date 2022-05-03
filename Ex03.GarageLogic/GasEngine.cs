using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                // throw exception
            }

            if (overTheMaxCapacity(i_AmountToAdd))
            {
                // throw exception
            }

            m_CurrentEnergyCapacity += i_AmountToAdd;
        }

        public override string ToString()
        {
            string engineInfo = string.Format(@"Engine powered by : Fuel
Fuel type : {0}
{1}", r_FuelType, base.ToString());

            return engineInfo;
        }
    }
}
