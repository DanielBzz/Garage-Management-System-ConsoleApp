using System.Collections.Generic;
using System.Reflection;

namespace Ex03.GarageLogic
{

    class VehicleFactory
    {
        private List<Vehicle> m_VehiclesList;

        private void buildVehicleList()
        {
            MethodInfo[] allMethods = this.GetType().GetMethods();
            foreach (MethodInfo methodInfo in allMethods)
            {
                if (methodInfo.ReturnType is Vehicle)
                {
                    m_VehiclesList.Add(methodInfo.Invoke(this, null) as Vehicle);
                }
            }
        }

        public Motorbike BuildGasMotorbike()
        {
            int numOfWheels = 2;
            float maxPressure = 31;
            float engineCC = 6.2F;
            eFuelType fuelType = eFuelType.Octan98;

            return new Motorbike(numOfWheels, maxPressure, engineCC, fuelType);
        }

        public Motorbike BuildElectricMotorbike()
        {
            int numOfWheels = 2;
            float maxPressure = 31;
            float batteryLife = 2.5F;

            return new Motorbike(numOfWheels, maxPressure, batteryLife);
        }
    }
}
