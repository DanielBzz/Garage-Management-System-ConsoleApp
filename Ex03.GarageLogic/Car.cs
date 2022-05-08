namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private eCarNumOfDoors m_NumOfDoors;
        private eCarColor m_Color;

        public Car(int i_NumOfWheels, float i_MaxPressure, Engine i_Engine)
            : base(i_NumOfWheels, i_MaxPressure, i_Engine) { }

        public eCarNumOfDoors NumOfDoors
        {
            set
            {
                m_NumOfDoors = value;
            }
        }

        public eCarColor Color
        {
            set
            {
                m_Color = value;
            }
        }

        public override string ToString()
        {
            string mototbikeInfo = string.Format(@"Vehicle : Car
{0}
Number of doors: {1}
Color: {2}", base.ToString(), m_NumOfDoors, m_Color);

            return mototbikeInfo;
        }

        public override string ToShow()
        {
            return string.Format(@"Car {0}
{1}", base.Engine.GetType().Name, base.ToShow());
        }
    }
}
