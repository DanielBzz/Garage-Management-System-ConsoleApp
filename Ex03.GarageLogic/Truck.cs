using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    class Truck : Vehicle
    {
        private const int k_NumOfWheels = 16;
        private bool m_IsRefrigeratedContents;
        private float m_CargoVolume;

        public Truck(int i_NumOfWheels, float i_MaxPressure, Engine i_Engine)
            : base(i_NumOfWheels, i_MaxPressure, i_Engine) { }

        public override string ToString()
        {
            string truckInfo = string.Format(@"Vehicle is truck.
Refrigerated contents: {0}.
Cargo volume: {1}.
{2}", m_IsRefrigeratedContents ? "Have" : "Not Have", m_CargoVolume, base.ToString());

            return truckInfo;
        }
    }
}
