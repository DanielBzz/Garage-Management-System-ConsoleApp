using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class UILogic
    {
        public void Run()
        {
            int userInput;

            do
            {
                Console.WriteLine(Messenger.WelcomeMsg());
                GetMenuInput(out userInput, 1, 8);

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

        public static void GetMenuInput(out int i_UserInput, int i_MinValue, int i_MaxValue)
        {
            StringBuilder input = new StringBuilder(Console.ReadLine());
            
            while (int.TryParse(input.ToString(), out i_UserInput) && i_UserInput >= i_MinValue && i_UserInput <= i_MaxValue)
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
