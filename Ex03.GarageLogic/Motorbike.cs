namespace Ex03.GarageLogic
{
    public class Motorbike : Vehicle
    {
        private float m_EngineCC;
        private eBikeLicenseType m_LicenseType;

        public Motorbike(int i_NumOfWheels, float i_MaxPressure, Engine i_Engine)
            : base(i_NumOfWheels, i_MaxPressure, i_Engine) { }

        public float EngineCC
        {
            set
            {
                m_EngineCC = value;
            }
        }

        public eBikeLicenseType LicenseType
        {
            set
            {
                m_LicenseType = value;
            }
        }

        public override string ToString()
        {
            string mototbikeInfo = string.Format(@"Vehicle : Motorbike
{0}
EngineCC: {1}
License type: {2}", base.ToString(), m_EngineCC, m_LicenseType);

            return mototbikeInfo;
        }

        public override string ToShow()
        {
            return string.Format(@"Motorbike {0}
{1}", base.Engine.GetType().Name, base.ToShow());
        }
    }
}
