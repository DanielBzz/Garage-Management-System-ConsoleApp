using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private readonly string r_Model;    // maybe do all members protected and give up on properties
        private readonly string r_ID;
        private readonly Engine r_Engine;
        private readonly List<Tyre> m_Tyres = new List<Tyre>();

        public Vehicle(string i_Model, string i_ID, int i_NumOfTyres, Engine i_Engine)
        {
            r_Model = i_Model;
            r_ID = i_ID;
            r_Engine = i_Engine;
            for (int i = 0; i < i_NumOfTyres; i++)
            {
                m_Tyres.Add(new Tyre());
            }
        }

        public string ID
        {
            get
            {
                return r_ID;
            }
        }

        public string Model
        {
            get
            {
                return r_Model;
            }
        }

        public Engine Engine
        {
            get
            {
                return r_Engine;
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public void InflateTyresToMax()
        {
            foreach (Tyre tyre in m_Tyres)
            {
                tyre.Inflate(tyre.MaxAirPressure - tyre.CurrentAirPressure);
            }
        }

        // public abstract void AddEnergy(float i_AmountToAdd, eFuelType i_FuelType);
    }
}
