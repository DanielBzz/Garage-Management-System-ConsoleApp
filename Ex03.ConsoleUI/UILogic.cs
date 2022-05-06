using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class UILogic
    {
        private readonly GarageServices r_GarageServices = new GarageServices();
        public void Run()
        {
            int userInput;

            do
            {
                Console.WriteLine(Messenger.WelcomeMsg());
                GetUserSelection(out userInput, 1, 8);
                // if every method has try&catch we should initiate try on the switch below and catch afterwards
                switch (userInput)
                {
                    case 1:
                        r_GarageServices.EnterNewVehicle();
                        break;
                    case 2:
                        r_GarageServices.ShowVehicleList();
                        break;
                    case 3:
                        r_GarageServices.ChangeVehicleStatus();
                        break;
                    case 4:
                        r_GarageServices.InflateTyreToMax();
                        break;
                    case 5:
                        r_GarageServices.Refuel();
                        break;
                    case 6:
                        r_GarageServices.Recharge();
                        break;
                    case 7:
                        r_GarageServices.ShowVehicleFullData();
                        break;
                    default:
                        break;
                }

                Console.WriteLine("Please wait");
                System.Threading.Thread.Sleep(3500);
                Console.Clear();
            } while (userInput != 8);

            Console.WriteLine(Messenger.GoodByeMsg());
        }

        public static void GetUserSelection(out int o_UserInput, int i_MinValue, int i_MaxValue)
        {
            StringBuilder input = new StringBuilder(Console.ReadLine());
            
            while (int.TryParse(input.ToString(), out o_UserInput) == false || o_UserInput < i_MinValue || o_UserInput > i_MaxValue)
            {
                Console.WriteLine(Messenger.WrongInputMsg());
                input.Clear();
                input.Append(Console.ReadLine());
            }
        }

        public static void GetEnergyAmount(out int o_UserInput)
        {
            StringBuilder input = new StringBuilder(Console.ReadLine());

            while (int.TryParse(input.ToString(), out o_UserInput))
            {
                Console.WriteLine(Messenger.WrongInputMsg());
                input.Clear();
                input.AppendLine(Console.ReadLine());
            }
        }

        public static void GetLicensePlateString(out string o_UserInput)
        {
            StringBuilder input = new StringBuilder(Console.ReadLine());

            while (input == null)
            {
                Console.WriteLine(Messenger.WrongInputMsg());
                input.Clear();
                input.AppendLine(Console.ReadLine());
            }

            o_UserInput = input.ToString();
        }
    }
}
