using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03GarageLogic
{
    class Motorbike
    {
        private const int k_NumOfWheels = 2;
        private int m_EngineCC;
        private eBikeLicenseType m_LicenceType;
        private Vehicle m_Vehicle;

        public Motorbike(string i_Model, string i_ID, eEnergySource i_EnergySource, 
             eBikeLicenseType i_LicenceType, int i_EngineCC, eFuelType i_FuelType = eFuelType.Blank)
        {
            if (i_EnergySource == eEnergySource.Fuel)
            {
                m_Vehicle = new GasEngine(i_Model, i_ID, k_NumOfWheels, i_FuelType);
            }
            else // (i_EnergySource == eEnergySource.Electric)
            {
                m_Vehicle = new ElectricEngine(i_Model, i_ID, k_NumOfWheels);
                //
            }

            m_LicenceType = i_LicenceType;
            m_EngineCC = i_EngineCC;
        }

        //public void AddEnergy(string i_ID, float i_AmountToAdd, eFuelType i_FuelType = eFuelType.Blank) 
        //{
        //    m_Vehicle.AddEnergy(i_ID, i_AmountToAdd, i_FuelType);
        //}
    }
}
