using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private readonly eCarNumOfDoors r_NumOfDoors;
        private eCarColor m_Color;

        public Car(int i_NumOfWheels, float i_MaxPressure, Engine i_Engine)
            : base(i_NumOfWheels, i_MaxPressure, i_Engine) { }

        public override string ToString()
        {
            string carInfo = string.Format(@"Vehicle is car.
Num of doors: {0}.
color: {1}.
{2}", r_NumOfDoors, m_Color, base.ToString());

            return carInfo;
        }
    }
}
