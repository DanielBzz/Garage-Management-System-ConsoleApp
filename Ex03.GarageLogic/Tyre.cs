namespace Ex03.GarageLogic
{
    public class Tyre
    {
        private readonly float r_MaxAirPressure;
        private float m_CurrentAirPressure;
        private string m_Manufacturer;

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
                return m_Manufacturer;
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
                // throw some exception that over the limit ...
            }
        }
    }
}
