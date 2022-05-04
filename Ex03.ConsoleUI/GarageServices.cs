using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    class GarageServices
    {
        private readonly GarageManager r_GarageManager = new GarageManager();

        public void EnterNewVehicle()
        {
            // print menu of all the vehicle option in the garage ,, we should hold a list of all the vehicles in the factory;

            while (!invalid)
                try
                {
                    r_GarageManager.AddNewClient()
                }
        }

        public void ShowVehicleList()
        {
            int userInput;
            
            Console.WriteLine(Messenger.FilterByStatusMsg());
            UILogic.GetMenuInput(out userInput, 1, 4);
            eServiceStatus filterBy = (eServiceStatus)userInput;

            List<string> vehiclesList = r_GarageManager.ShowAllVehiclesInGarage(filterBy);
            int count = 0;

            foreach (string licensePlate in vehiclesList)
            {
                
                ++count;
                Console.WriteLine(string.Format("{0}.{1}{2}", count, licensePlate, Environment.NewLine));
            }

            if (count == 0) 
            {
                Console.WriteLine("There is no vehicles {0}", filterBy != eServiceStatus.NoStatus ? 
                                 Enum.GetName(typeof(eServiceStatus), filterBy) : "");
            }
        }

        public void ChangeVehicleStatus()
        {

        }

        public void InflateTyreToMax()
        {

        }

        public void Refuel()
        {

        }

        public void Recharge()
        {

        }

        public void ShowVehicleFullData()
        {

        }
    }
}
