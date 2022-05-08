using System;
using System.Reflection;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    class GarageServices
    {
        private readonly GarageManager r_GarageManager = new GarageManager();
        private readonly VehicleFactory r_VehicleFactory = new VehicleFactory();

        public void EnterNewVehicle()
        {
            int userSelection;
            Vehicle vehicle;

            Console.WriteLine(Messenger.SelectVehicleMsg());
            Console.Write(r_VehicleFactory.ShowVehiclesList());
            UILogic.GetUserSelection(out userSelection, 1, r_VehicleFactory.VehiclesList.Count);
            try
            {
                vehicle = createNewVehicle(userSelection);
                addNewClient(vehicle);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private Vehicle createNewVehicle(int i_UserSelection)
        {
            Vehicle vehicle;

            vehicle = r_VehicleFactory.CreateVehicleByUserChoice(i_UserSelection);
            setVehicleData(vehicle);

            return vehicle;
        }

        private void setVehicleData(Vehicle i_Vehicle)
        {
            List<MethodInfo> uniqueMethods = r_GarageManager.BuildSetterMethodsList(i_Vehicle);
            object[] parametersForMethod = new object[1];

            foreach (MethodInfo method in uniqueMethods)
            {
                Type parameterType = method.GetParameters()[0].ParameterType;
                if (parameterType.IsEnum)
                {
                    int userSelection;

                    Console.WriteLine(string.Format("Choose {0} :", Messenger.CamelCasedEnumToString(parameterType)));
                    Console.Write(Messenger.EnumListMsg(parameterType));
                    UILogic.GetUserSelection(out userSelection, 1, Enum.GetNames(parameterType).Length);
                    parametersForMethod[0] = userSelection - 1;
                }
                else
                {
                    Console.WriteLine(string.Format("Enter {0} :", Messenger.CamelCasedStringToMsg(method.Name.Remove(0, 4))));
                    parametersForMethod[0] = UILogic.DynamicTryParse(method);
                }

                method.Invoke(i_Vehicle, parametersForMethod);
            }
        }

        private void addNewClient(Vehicle i_Vehicle)
        {
            string name, phoneNumber;

            Console.WriteLine(string.Format(@"Enter {0} {1}", i_Vehicle.GetType().Name, "owner's name"));
            UILogic.GetNoneNullString(out name);
            Console.WriteLine(string.Format(@"Enter {0} {1}", i_Vehicle.GetType().Name, "owner's phone number"));
            UILogic.GetNoneNullString(out phoneNumber);
            r_GarageManager.AddNewClient(name, phoneNumber, i_Vehicle);
        }

        public void ShowVehicleList()
        {
            int userInput;
            
            Console.WriteLine(Messenger.FilterByStatusMsg());
            UILogic.GetUserSelection(out userInput, 1, 4);
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
                Console.WriteLine("There are no vehicles {0}", filterBy != eServiceStatus.NoStatus ? 
                                 Enum.GetName(typeof(eServiceStatus), filterBy) : "");
            }
        }

        public void ChangeVehicleStatus()
        {
            int userNewStatusInput;
            string licensePlateNumber;

            Console.WriteLine(Messenger.EnterPlateNumberMsg());
            UILogic.GetNoneNullString(out licensePlateNumber);
            Console.WriteLine(Messenger.ChangeVehicleStatusMsg());
            UILogic.GetUserSelection(out userNewStatusInput, 1, 3);
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
            UILogic.GetNoneNullString(out licensePlateNumber);
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
            UILogic.GetNoneNullString(out licensePlateNumber);
            Console.WriteLine(Messenger.SelectFuelTypeMsg());
            UILogic.GetUserSelection(out userFuelTypeInput, 1, 4);
            Console.WriteLine(Messenger.SelectEnergyAmountToAddMsg());
            UILogic.GetValidInteger(out amountToAdd);
            try
            {
                r_GarageManager.RefuelVehicle(licensePlateNumber, (eFuelType)userFuelTypeInput, amountToAdd);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (ValueOutOfRangeException vore)
            { 
                Console.WriteLine(vore.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Recharge()
        {
            string licensePlateNumber;
            int amountToAdd;

            Console.WriteLine(Messenger.EnterPlateNumberMsg());
            UILogic.GetNoneNullString(out licensePlateNumber);
            Console.WriteLine(Messenger.SelectEnergyAmountToAddMsg());
            UILogic.GetValidInteger(out amountToAdd);
            try
            {
                r_GarageManager.ChargeVehicle(licensePlateNumber, amountToAdd);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (ValueOutOfRangeException vora)
            {
                Console.WriteLine(vora.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ShowVehicleFullData()
        {
            string licensePlateNumber;

            Console.WriteLine(Messenger.EnterPlateNumberMsg());
            UILogic.GetNoneNullString(out licensePlateNumber);
            try
            {
                Console.WriteLine(r_GarageManager.GetVehicleDetails(licensePlateNumber));
            }
            catch(ArgumentException ae) 
            {
                Console.WriteLine(ae.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
