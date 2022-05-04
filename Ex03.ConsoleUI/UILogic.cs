using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class UILogic
    {
        private GarageManager m_GarageManager = new GarageManager();

        public void Run()
        {
            int userInput;

            do
            {
                Console.WriteLine(Messenger.WelcomeMsg());
                GetRunInput(out userInput);

                switch (userInput)
                {
                    case 1:
                        EnterNewVehicle();
                        break;
                    case 2:
                        ShowVehicleList();
                        break;
                    case 3:
                        ChangeVehicleStatus();
                        break;
                    case 4:
                        InflateTyreToMax();
                        break;
                    case 5:
                        Refuel();
                        break;
                    case 6:
                        Recharge();
                        break;
                    case 7:
                        ShowVehicleFullData();
                        break;
                    default:
                        //
                        break;
                }

                Console.Clear();
            } while (userInput != 8);

            Console.WriteLine(Messenger.GoodByeMsg());
        }

        public void EnterNewVehicle()
        {

            while (!invalid)
            try
            {
                m_GarageManager.AddNewClient()
            }
        }

        public void ShowVehicleList()
        {

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

        private void GetRunInput(out int i_UserInput)
        {
            StringBuilder input = new StringBuilder(Console.ReadLine());
            
            while (int.TryParse(input.ToString(), out i_UserInput) && i_UserInput > 0 && i_UserInput < 9)
            {
                Console.Clear();
                Console.WriteLine(Messenger.WrongInputMsg());
                Console.WriteLine(Messenger.WelcomeMsg());
                input.Clear();
                input.AppendLine(Console.ReadLine());
            }
        }
    }
}
