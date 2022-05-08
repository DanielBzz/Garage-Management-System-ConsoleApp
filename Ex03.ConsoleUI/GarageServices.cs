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
            Console.Write(string.Format("Choose a number from {0} to {1} : ", 1, r_VehicleFactory.VehicleListLength));
            UILogic.GetUserSelection(out userSelection, 1, r_VehicleFactory.VehicleListLength);
            Console.Clear();
            vehicle = createNewVehicle(userSelection);
            addNewClient(vehicle);
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
            r_GarageManager.SetNewStatusForVehicle(licensePlateNumber, (eServiceStatus)userNewStatusInput);
        }

        public void InflateTyreToMax()
        {
            string licensePlateNumber;

            Console.WriteLine(Messenger.EnterPlateNumberMsg());
            UILogic.GetNoneNullString(out licensePlateNumber);
            r_GarageManager.InflateTyresToMax(licensePlateNumber);
        }

        public void Refuel()
        {
            float amountToAdd;
            int userFuelTypeInput; 
            string licensePlateNumber;

            Console.WriteLine(Messenger.EnterPlateNumberMsg());
            UILogic.GetNoneNullString(out licensePlateNumber);
            Console.WriteLine(Messenger.SelectFuelTypeMsg());
            UILogic.GetUserSelection(out userFuelTypeInput, 1, 4);
            Console.WriteLine(Messenger.SelectEnergyAmountToAddMsg());
            UILogic.GetValidFloat(out amountToAdd);
            r_GarageManager.RefuelVehicle(licensePlateNumber, (eFuelType)userFuelTypeInput, amountToAdd);
        }

        public void Recharge()
        {
            string licensePlateNumber;
            float amountToAdd;

            Console.WriteLine(Messenger.EnterPlateNumberMsg());
            UILogic.GetNoneNullString(out licensePlateNumber);
            Console.WriteLine(Messenger.SelectEnergyAmountToAddMsg());
            UILogic.GetValidFloat(out amountToAdd);
            r_GarageManager.ChargeVehicle(licensePlateNumber, amountToAdd);  
        }

        public void ShowVehicleFullData()
        {
            string licensePlateNumber;

            Console.WriteLine(Messenger.EnterPlateNumberMsg());
            UILogic.GetNoneNullString(out licensePlateNumber);
            Console.WriteLine(r_GarageManager.GetVehicleDetails(licensePlateNumber));
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
            int userSelection;
            List<MethodInfo> uniqueMethods = r_GarageManager.BuildSetterMethodsList(i_Vehicle);
            object[] parametersForMethod = new object[1];

            foreach (MethodInfo method in uniqueMethods)
            {
                Type parameterType = method.GetParameters()[0].ParameterType;
                if (parameterType.IsEnum)
                {
                    Console.WriteLine(string.Format("Choose {0} :", Messenger.CamelCasedEnumToString(parameterType)));
                    Console.Write(Messenger.EnumListMsg(parameterType));
                    UILogic.GetUserSelection(out userSelection, 1, Enum.GetNames(parameterType).Length);
                    parametersForMethod[0] = userSelection - 1;
                }
                else if (parameterType.Equals(typeof(bool)))
                {
                    Console.WriteLine(string.Format("Choose whether {0} :", Messenger.CamelCasedStringToMsg(method.Name.Remove(0, 4))));
                    Console.WriteLine(string.Format("(1) Yes {0}(2) No", Environment.NewLine));
                    UILogic.GetUserSelection(out userSelection, 1, 2);
                    parametersForMethod[0] = userSelection == 1 ? true : false;
                }
                else
                {
                    Console.WriteLine(string.Format("Enter {0} :", Messenger.CamelCasedStringToMsg(method.Name.Remove(0, 4))));
                    parametersForMethod[0] = UILogic.GetValidData(method);
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
    }
}
