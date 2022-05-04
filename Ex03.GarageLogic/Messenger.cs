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
    }
}