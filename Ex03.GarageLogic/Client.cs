using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Client
    {
        private readonly string r_ClientName;
        private readonly string r_PhoneNumber;
        private readonly Vehicle r_ClientVehicle;
        private eServiceStatus m_Status;

        public Client(string i_Name, string i_PhoneNumber, Vehicle i_Vehicle)
        {
            r_ClientName = i_Name;
            r_PhoneNumber = i_PhoneNumber;
            r_ClientVehicle = i_Vehicle;
            m_Status = eServiceStatus.InRepair;
        }

        public string ClientName
        {
            get
            {
                return r_ClientName;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return r_PhoneNumber;
            }
        }

        public Vehicle ClientVehicle
        {
            get
            {
                return r_ClientVehicle;
            }
        }

        public eServiceStatus Status
        {
            get
            {
                return m_Status;
            }

            set
            {
                m_Status = value;
            }
        }

        public override string ToString()
        {
            string info = string.Format(@"Owner name : {0}
Phone number:{1}
State in the garage:{2}
{3}", r_ClientName, r_PhoneNumber, m_Status.GetType(), r_ClientVehicle.ToString());

            return info;
        }
    }
}
