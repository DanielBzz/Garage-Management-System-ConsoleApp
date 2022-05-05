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
            int userNewStatusInput;
            string licensePlateNumber;

            Console.WriteLine(Messenger.EnterPlateNumberMsg());
            UILogic.GetLicensePlateString(out licensePlateNumber);
            Console.WriteLine(Messenger.ChangeVehicleStatusMsg());
            UILogic.GetMenuInput(out userNewStatusInput, 1, 3);
            try
            {
                r_GarageManager.SetNewStatusForVehicle(licensePlateNumber, (eServiceStatus)userNewStatusInput);
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
}

        public void InflateTyreToMax()
        {
            string licensePlateNumber;

            Console.WriteLine(Messenger.EnterPlateNumberMsg());
            UILogic.GetLicensePlateString(out licensePlateNumber);
            try
            {
                r_GarageManager.InflateTyresToMax(licensePlateNumber);
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Refuel()
        {
            string licensePlateNumber;
            int userFuelTypeInput, amountToAdd;

            Console.WriteLine(Messenger.EnterPlateNumberMsg());
            UILogic.GetLicensePlateString(out licensePlateNumber);
            Console.WriteLine(Messenger.SelectFuelTypeMsg());
            UILogic.GetMenuInput(out userFuelTypeInput, 1, 4);
            Console.WriteLine(Messenger.SelectEnergyAmountToAddMsg());
            UILogic.GetAmountInput(out amountToAdd);
            try
            {
                r_GarageManager.RefuelVehicle(licensePlateNumber, (eFuelType)userFuelTypeInput, amountToAdd);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ValueOutOfRangeException ex)
            { 
                Console.WriteLine(ex.Message);
            }
        }

        public void Recharge()
        {
            string licensePlateNumber;
            int amountToAdd;

            Console.WriteLine(Messenger.EnterPlateNumberMsg());
            UILogic.GetLicensePlateString(out licensePlateNumber);
            Console.WriteLine(Messenger.SelectEnergyAmountToAddMsg());
            UILogic.GetAmountInput(out amountToAdd);
            try
            {
                r_GarageManager.ChargeVehicle(licensePlateNumber, amountToAdd);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ValueOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ShowVehicleFullData()
        {
            string licensePlateNumber;

            Console.WriteLine(Messenger.EnterPlateNumberMsg());
            UILogic.GetLicensePlateString(out licensePlateNumber);
            try
            {
                r_GarageManager.GetVehicleDetails(licensePlateNumber);
            }
            catch(ArgumentException ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
