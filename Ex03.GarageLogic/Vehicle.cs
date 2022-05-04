using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string m_Model;    // maybe do all members protected and give up on properties
        private string m_ID;
        private Engine m_Engine;
        private List<Tyre> m_Tyres;

        public Vehicle(int i_NumOfTyres)
        {
            m_Tyres = new List<Tyre>(i_NumOfTyres);
        }

        public string ID
        {
            get
            {
                return m_ID;
            }

            set
            {
                if (m_ID == null)
                {
                    if (isValidName(value))
                    {
                        m_ID = value;
                    }
                }
                else
                {
                    throw new ArgumentException("Vehicle already has ID");
                }
            }
        }

        public string Model
        {
            get
            {
                return m_Model;
            }

            set
            {
                if (m_Model == null)
                {
                    if (isValidName(value))
                    {
                       m_Model = value;
                    }
                }
                else
                {
                    throw new ArgumentException("Vehicle already has a model");
                }
            }
        }

        public Engine Engine
        {
            get
            {
                return m_Engine;
            }

            set
            {
                if (m_Engine == null)
                {
                    m_Engine = value;
                }
                else
                {
                    throw new ArgumentException("Vehicle already has a Engine");
                }
            }
        }

        public List<Tyre> Tyres
        {
            get
            {
                return m_Tyres;
            }
        }

        public override string ToString()
        {
            string vehicleInfo = string.Format(@"Vehicle model: {0}
Vehicle Plate Number: {1}
{2}
{3}", m_Model, m_ID, m_Tyres[0].ToString(), m_Engine.ToString());

            return vehicleInfo;
        }

        public void InflateTyresToMax()
        {
            foreach (Tyre tyre in m_Tyres)
            {
                tyre.Inflate(tyre.MaxAirPressure - tyre.CurrentAirPressure);
            }
        }

        private bool isValidName(string i_Value)
        {
            bool validName = i_Value != null;

            if (!validName)
            {
                throw new FormatException("Not a valid value");
            }

            return validName;
        }
    }
}
