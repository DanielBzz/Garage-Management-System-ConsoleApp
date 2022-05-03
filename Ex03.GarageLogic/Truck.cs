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

        public Truck(string i_Model, string i_ID, Engine i_Engine, bool i_IsRefrigeratedContents, float i_CargoVolume)
                    : base(i_Model, i_ID, k_NumOfWheels, i_Engine)
        {
            m_IsRefrigeratedContents = i_IsRefrigeratedContents;
            m_CargoVolume = i_CargoVolume;
        }

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
