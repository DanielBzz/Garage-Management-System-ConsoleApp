using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class Program
    {
        public static void Main()
        {
            try
            {
                inflate();
            }
            catch (ValueOutOfRangeException vore)
            {
                Console.WriteLine("Overloading");
            }
            catch(Exception ex)
            {
                //handle general case
            }
        }
    }
}
