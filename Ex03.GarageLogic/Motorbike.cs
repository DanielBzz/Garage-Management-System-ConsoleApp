using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Motorbike : Vehicle
    {
        private const int k_NumOfWheels = 2;
        private int m_EngineCC;
        private eBikeLicenseType m_LicenseType;

        //public Motorbike(string i_Model, string i_ID, Engine i_Engine, int i_EngineCC, eBikeLicenseType i_LicenseType)
        //    : base(i_Model, i_ID, k_NumOfWheels, i_Engine)
        //{
        //    m_LicenseType = i_LicenseType;
        //    m_EngineCC = i_EngineCC;
        //}

        public override string ToString()
        {
            string mototbikeInfo = string.Format(@"Vehicle is motorbike.
EngineCC: {0}.
License type: {1}.
{2}", m_EngineCC, m_LicenseType, base.ToString());

            return mototbikeInfo;
        }
    }
}
