using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
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
                Console.Clear();
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

                Console.Write("Press Enter to continue");
                Console.ReadLine();
                //System.Threading.Thread.Sleep(3500);
                Console.Clear();
            } while (userInput != 8);
            
            Console.WriteLine(Messenger.GoodByeMsg());
            System.Threading.Thread.Sleep(2500);
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

        public static void GetValidInteger(out int o_UserInput)
        {
            StringBuilder input = new StringBuilder(Console.ReadLine());

            while (int.TryParse(input.ToString(), out o_UserInput) == false)
            {
                Console.WriteLine(Messenger.WrongInputMsg());
                input.Clear();
                input.AppendLine(Console.ReadLine());
            }
        }

        public static void GetValidFloat(out float o_UserInput)
        {
            StringBuilder input = new StringBuilder(Console.ReadLine());

            while (float.TryParse(input.ToString(), out o_UserInput) == false)
            {
                Console.WriteLine(Messenger.WrongInputMsg());
                input.Clear();
                input.AppendLine(Console.ReadLine());
            }
        }

        public static void GetNoneNullString(out string o_UserInput)
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

        public static object DynamicTryParse(MethodInfo i_Method)
        {
            Type type;
            Type[] tryParseSignature;
            MethodInfo dynamicTryParse;
            object[] dynamicTryParseParams = new object[2];

            dynamicTryParseParams[1] = null;
            type = i_Method.GetParameters()[0].ParameterType;
            tryParseSignature = new[] { typeof(string), type.MakeByRefType() };
            if (type.Name != "String")
            {
                try
                {
                    dynamicTryParse = type.GetMethod("TryParse", tryParseSignature);
                    if (dynamicTryParse == null)
                    {
                        throw new ArgumentNullException(string.Format("Error : Could not find TryParse method for {0}", type));
                    }

                    dynamicTryParseParams[0] = Console.ReadLine();
                    dynamicTryParse.Invoke(type, dynamicTryParseParams);
                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine(ane);
                }
            }
            else
            {
                dynamicTryParseParams[1] = Console.ReadLine();
            }

            return dynamicTryParseParams[1];
        }
        
        //public static int GetEnumInput(Type i_EnumType)
        //{
        //    int parsedEnum = int.MaxValue;
        //    int maxEnumValue = Enum.GetValues(i_EnumType).Length - 1;
        //    bool exceptionFlag = false;

        //    while(!exceptionFlag)
        //    {
        //        try
        //        {
        //            StringBuilder resString = new StringBuilder();
        //            int i = 1;

        //            if (m_VehiclesList.Count == 0)
        //            {
        //                buildVehicleList();
        //            }

        //            foreach (Vehicle vehicle in m_VehiclesList)
        //            {
        //                resString.AppendFormat("({0}) {1}", i, vehicle.ToShow()).AppendLine().AppendLine();
        //                i++;
        //            }
        //            if (!int.TryParse(Console.ReadLine(), out parsedEnum))
        //            {
        //                throw new FormatException("")
        //            }
        //        }
        //    }
        //}
    }
}
