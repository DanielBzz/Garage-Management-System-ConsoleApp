namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        protected readonly float r_MaxEnergyCapacity;
        protected float m_CurrentEnergy;
        
        public Engine(float i_MaxCapacity)
        {
            r_MaxEnergyCapacity = i_MaxCapacity;
        }

        public float CurrentEnergy
        {
            get
            {
                return m_CurrentEnergy;
            }

            set
            {
                if (!IsValidNewCapacity(value - CurrentEnergy))
                {
                    m_CurrentEnergy = value;
                }
            }
        }

        public float EnergyPrecentage
        {
            get
            {
                return (m_CurrentEnergy / r_MaxEnergyCapacity) * 100;
            }
        }

        public override string ToString()
        {
            return string.Format(@"Energy left : {0} %", EnergyPrecentage);
        }

        public abstract string ToShow();

        protected bool IsValidNewCapacity(float i_AmountToAdd)
        {
            float newCapacity = m_CurrentEnergy + i_AmountToAdd;
            bool overTheMax = r_MaxEnergyCapacity < newCapacity || newCapacity < 0;

            if (overTheMax)
            {
                throw new ValueOutOfRangeException(r_MaxEnergyCapacity, 0, newCapacity);
            }

            return overTheMax;
        }
    }
}
