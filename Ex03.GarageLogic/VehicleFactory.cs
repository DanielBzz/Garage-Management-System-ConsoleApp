using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Ex03.GarageLogic
{
    // To add new vehicle just need to add vehicle's method -> For example watch 'BuildGasCar' method
    public class VehicleFactory
    {
        private List<Vehicle> m_VehiclesList = new List<Vehicle>();
        private int m_VehicleListLength;

        public int VehicleListLength
        {
            get
            {
                m_VehicleListLength = m_VehiclesList.Count;
                return m_VehicleListLength;
            }
        }

        public Vehicle CreateVehicleByUserChoice(int i_UserChoice)
        {
            int i = 0;
            Vehicle vehicle = null;
            MethodInfo[] allMethods = this.GetType().GetMethods();

            foreach (MethodInfo methodInfo in allMethods)
            {
                if (methodInfo.ReturnType.Name.Equals("Vehicle"))
                {
                    ParameterInfo[] allParams = methodInfo.GetParameters();
                    if (allParams.Length == 0)
                    {
                        i++;
                        if (i == i_UserChoice)
                        {
                            vehicle = methodInfo.Invoke(this, allParams) as Vehicle;
                        }
                    }
                }
            }

            return vehicle;
        }

        public Vehicle BuildGasCar()
        {
            int numOfWheels = 4;
            float maxPressure = 29;
            float fuelTankVolume = 38F;
            eFuelType fuelType = eFuelType.Octan95;
            GasEngine engine = new GasEngine(fuelType, fuelTankVolume);

            return new Car(numOfWheels, maxPressure, engine);
        }

        public Vehicle BuildElectricCar()
        {
            int numOfWheels = 4;
            float maxPressure = 29;
            float batteryLife = 3.3F;
            ElectricEngine engine = new ElectricEngine(batteryLife);

            return new Car(numOfWheels, maxPressure, engine);
        }

        public Vehicle BuildGasMotorbike()
        {
            int numOfWheels = 2;
            float maxPressure = 31;
            float fuelTankVolume = 6.2F;
            eFuelType fuelType = eFuelType.Octan98;
            GasEngine engine = new GasEngine(fuelType, fuelTankVolume);

            return new Motorbike(numOfWheels, maxPressure, engine);
        }

        public Vehicle BuildElectricMotorbike()
        {
            int numOfWheels = 2;
            float maxPressure = 31;
            float batteryLife = 2.5F;
            ElectricEngine engine = new ElectricEngine(batteryLife);

            return new Motorbike(numOfWheels, maxPressure, engine);
        }

        public Vehicle BuildGasTruck()
        {
            int numOfWheels = 16;
            float maxPressure = 24;
            float fuelTankVolume = 120F;
            eFuelType fuelType = eFuelType.Soler;
            GasEngine engine = new GasEngine(fuelType, fuelTankVolume);

            return new Truck(numOfWheels, maxPressure, engine);
        }

        public string ShowVehiclesList()
        {
            StringBuilder resString = new StringBuilder();
            int i = 1;

            if (m_VehiclesList.Count == 0)
            {
                buildVehicleList();
            }

            foreach (Vehicle vehicle in m_VehiclesList)
            {
                resString.AppendFormat("({0}) {1}", i, vehicle.ToShow()).AppendLine().AppendLine();
                i++;
            }

            return resString.ToString();
        }

        private void buildVehicleList()
        {
            MethodInfo[] allMethods = this.GetType().GetMethods();

            foreach (MethodInfo methodInfo in allMethods)
            {
                if (methodInfo.ReturnType.Name.Equals("Vehicle"))
                {
                    ParameterInfo[] allParams = methodInfo.GetParameters();
                    if (allParams.Length == 0)
                    {
                        m_VehiclesList.Add(methodInfo.Invoke(this, allParams) as Vehicle);
                    }
                }
            }
        }
    }
}
