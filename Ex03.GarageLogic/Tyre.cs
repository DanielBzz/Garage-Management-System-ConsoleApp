namespace Ex03.GarageLogic
{
    public class Tyre
    {
        private readonly float r_MaxAirPressure;
        private float m_CurrentAirPressure;
        private string r_Manufacturer;

        public float MaxAirPressure
        {
            get
            {
                return r_MaxAirPressure;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }
        }

        public string Manufacturer
        {
            get
            {
                return r_Manufacturer;
            }

            set
            {
                r_Manufacturer = value;
            }
        }

        public void Inflate(float i_NewPressure)
        {
            bool overTheLimit = (m_CurrentAirPressure + i_NewPressure) >= r_MaxAirPressure;

            if (!overTheLimit)
            {
                m_CurrentAirPressure += i_NewPressure;
            }
            else
            {
                throw new ValueOutOfRangeException(MaxAirPressure);
            }
        }

        public override string ToString()
        {
            string tyreInfo = string.Format(@"Tyre manufacturer: {0}.
Tyre max air pressure: {1}.
Tyre current air pressure: {2}.", r_Manufacturer, r_MaxAirPressure, m_CurrentAirPressure);

            return tyreInfo;
        }
    }
}
