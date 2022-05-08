namespace Ex03.GarageLogic
{
    class Truck : Vehicle
    {
        private bool m_IsRefrigeratedContents;
        private float m_CargoVolume;

        public Truck(int i_NumOfWheels, float i_MaxPressure, Engine i_Engine)
            : base(i_NumOfWheels, i_MaxPressure, i_Engine) { }

        public float CargoVolume
        {
            set
            {
                m_CargoVolume = value;
            }
        }

        public bool CargoRefrigerated
        {
            set
            {
                m_IsRefrigeratedContents = value;
            }
        }

        public override string ToString()
        {
            string truckInfo = string.Format(@"Vehicle : Truck
{0}
Cargo volume: {1}
Refrigerated Cargo ? : {2}", base.ToString(), m_CargoVolume, m_IsRefrigeratedContents ? "Yes" : "No");

            return truckInfo;
        }

        public override string ToShow()
        {
            return string.Format(@"Truck {0}
{1}", base.Engine.GetType().Name, base.ToShow());
        }
    }
}
