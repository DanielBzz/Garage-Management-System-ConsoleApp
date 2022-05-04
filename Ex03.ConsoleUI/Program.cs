using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.ConsoleUI
{
    public class Program
    {
        public static void Main()
        {
            try
            {
                Ex03.ConsoleUI.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
