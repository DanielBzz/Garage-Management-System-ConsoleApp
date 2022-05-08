using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Messenger
    {
        public static string WelcomeMsg()
        {
            return string.Format(@"Welcome To The Garage !
Choose a method from the list below :
1.  Enter new vehicle
2.  Show vehicles
3.  Change vehicle status
4.  Inflate tyre to max
5.  Refuel (for vehicles powered by gas)
6.  Recharge (for electric vehicles)
7.  Show vehicle full data
8.  Exit");
        }

        public static string EnterPlateNumberMsg()
        {
            return "Enter Licence Plate Number :";
        }

        public static string VehicleListMsg()
        {
            return string.Format(@"1.   Show vehicles in repair
2.  Show fixed vehicles
3.  Show checked out vehicles
3.  Show all vehicles");
        }

        public static string ChangeVehicleStatusMsg()
        {
            return string.Format(@"Choose vehicle status :
1.  In repair
2.  Fixed
3.  Paid");
        }

        public static string GoodByeMsg()
        {
            return "Good Bye :)";
        }

        public static string WrongInputMsg()
        {
            return "Wrong input, please try again.";
        }

        public static string FilterByStatusMsg()
        {
            return string.Format(@"Select one of the following filter:
1.  In repair
2.  Fixed
3.  Paid
4.  Without filter");
        }

        public static string SelectFuelTypeMsg()
        {
            return string.Format(@"Select fuel type you want to refuel with:
1.  Soler
2.  Octan95
3.  Octan96
4.  Octan98");
        }

        public static string SelectEnergyAmountToAddMsg()
        {
            return "Please select amount of energy you want to add:";
        }

        public static string SelectVehicleMsg()
        {
            return "Please select a vehicle from the following list :";
        }

        public static string CamelCasedStringToMsg(string i_MethodName)
        {
            for (int i = 0; i < i_MethodName.Length - 1; i++)
            {
                if (char.IsUpper(i_MethodName[i + 1]) && char.IsLower(i_MethodName[i]))
                {
                    i_MethodName = i_MethodName.Insert(i + 1, " ");
                }
            }

            return i_MethodName;
        }

        public static string CamelCasedEnumToString(Type i_EnumType)
        {
            string enumMsg = i_EnumType.Name.Remove(0, 1);

            enumMsg = CamelCasedStringToMsg(enumMsg);

            return enumMsg;
        }

        public static string EnumListMsg(Type i_EnumType)
        {
            StringBuilder enumList = new StringBuilder();
            int i = 1;

            foreach(string name in Enum.GetNames(i_EnumType))
            {
                enumList.AppendFormat("({0}) {1}", i, name).AppendLine();
                i++;
            }

            return enumList.ToString();
        }
    }
}