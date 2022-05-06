using System;

namespace Ex03.ConsoleUI
{
    public class Program
    {
        public static void Main()
        {
            UILogic garageApp = new UILogic();
            try
            {
                garageApp.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
