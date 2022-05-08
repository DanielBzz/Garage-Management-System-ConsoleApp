using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string m_PlateNumber;
        private string m_Model; 
        private Engine m_Engine;
        private List<Tyre> m_Tyres;

        public Vehicle(int i_NumOfWheels, float i_MaxAirPressure, Engine i_Engine)
        {
            m_Engine = i_Engine;
            m_Tyres = new List<Tyre>(i_NumOfWheels);
            for (int i = 0; i < i_NumOfWheels; i++)
            {
                m_Tyres.Add(new Tyre(i_MaxAirPressure));
            }
        }

        public string PlateNumber
        {
            get
            {
                return m_PlateNumber;
            }

            set
            {
                if (m_PlateNumber == null)
                {
                    if (isValidName(value))
                    {
                        m_PlateNumber = value;
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
        }

        public float CurrentEnergy
        {
            set
            {
                m_Engine.CurrentEnergy = value;
            }
        }

        public List<Tyre> Tyres
        {
            get
            {
                return m_Tyres;
            }
        }

        public string TyreManufacturer
        {
            set
            {
                foreach (Tyre tyre in m_Tyres)
                {
                    tyre.Manufacturer = value;
                }
            }
        }

        public float TyreCurrentAirPressure
        {
            set
            {
                foreach (Tyre tyre in m_Tyres)
                {
                    tyre.CurrentAirPressure = value;
                }
            }
        }

        public override string ToString()
        {
            string vehicleInfo = string.Format(@"Vehicle model: {0}
Vehicle Plate Number: {1}
{2}
{3}", m_Model, m_PlateNumber, m_Tyres[0].ToString(), m_Engine.ToString());

            return vehicleInfo;
        }

        public virtual string ToShow()
        {
            return string.Format(@"{0}
{1}", m_Tyres[0].ToShow(), m_Engine.ToShow());
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
