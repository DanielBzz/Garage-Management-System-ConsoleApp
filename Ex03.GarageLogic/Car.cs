using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private const int k_NumOfWheels = 4;
        private readonly eCarNumOfDoors r_NumOfDoors;
        private eCarColor m_Color;

        public Car(string i_Model, string i_ID, Engine i_Engine, eCarColor i_CarColor, eCarNumOfDoors i_NumOfDoors)
            : base(i_Model, i_ID, k_NumOfWheels, i_Engine)
        {
            m_Color = i_CarColor;
            r_NumOfDoors = i_NumOfDoors;
        }

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
