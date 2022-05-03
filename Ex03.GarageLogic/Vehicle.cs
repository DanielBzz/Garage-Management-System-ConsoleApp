using System;
using System.Collections.Generic;

namespace Ex03GarageLogic
{
    public abstract class Vehicle
    {
        private readonly string m_Model;    // maybe do all members protected and give up on properties
        private readonly string m_ID;
        private float m_CurrentEnergyPrecentage;        // make enum maybe of fullTank = 100 , EmptyTank = 0.
        private List<Tyre> m_Tyres = null;
        private Engine m_Engine;

        public override string ToString()
        {
            return base.ToString();
        }

        public Vehicle(string i_Model, string i_ID, int i_NumOfTyres)
        {
            m_Model = i_Model;
            m_ID = i_ID;
            m_CurrentEnergyPrecentage = 0;

            for (int i = 0; i < i_NumOfTyres; i++)
            {
                m_Tyres.Add(new Tyre());
            }
        }

        public string ID
        {
            get
            {
                return m_ID;
            }
        }

        public string Model
        {
            get
            {
                return m_Model;
            }
        }

        public float EnergyPrecentage
        {
            get
            {
                return m_CurrentEnergyPrecentage;
            }

            set
            {
                m_CurrentEnergyPrecentage = value;
            }
        }

        private class Tyre
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

       // public abstract void AddEnergy(float i_AmountToAdd, eFuelType i_FuelType);

        public void InflateTyresToMax()// maybe to do this actino in garage he should know tyres .
        {
            foreach (Tyre tyre in m_Tyres)
            {
                tyre.Inflate(tyre.MaxAirPressure - tyre.CurrentAirPressure);
            }
        }

        //public abstract string ToString();      // not sure if it needed , any case we should have override ToString() in every vehicle
    }
}
