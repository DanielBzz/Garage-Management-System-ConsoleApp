using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private Dictionary<string, Client> m_CurrentClients = new Dictionary<string, Client>();

        public void AddNewClient(string i_Name, string i_PhoneNumber, Vehicle i_Vehicle)// or AddNewVehicle . first method in file
        {
            Client newClient;

            if (!isVehicleInGarage(i_Vehicle.ID, out newClient))
            {
                newClient = new Client(i_Name, i_PhoneNumber, i_Vehicle);
                m_CurrentClients.Add(i_Vehicle.ID, newClient);
            }
            else
            {
                newClient.Status = eServiceStatus.InRepair;
                // throw some message that the vehicle is already in the garage
            }
        }

        public string[] ShowAllVehiclesInGarage() // second method in file , return all vehicle's id //finish
        {
            string[] res = new string[m_CurrentClients.Count];

            m_CurrentClients.Keys.CopyTo(res, 0);

            return res;
        }

        public void SetNewStatusForVehicle(string i_VehicleId, eServiceStatus i_NewStatus) // third method in file
        {
            Client vehicleOwner;

            if (isVehicleInGarage(i_VehicleId, out vehicleOwner))
            {
                vehicleOwner.Status = i_NewStatus;
            }
            else
            {
                // throw exception not in garage
            }
        }

        public void InflateTyresToMax(string i_VehicleId, eServiceStatus i_NewStatus) // forth method in file
        {
            Client vehicleOwner;

            if (isVehicleInGarage(i_VehicleId, out vehicleOwner))
            {
                vehicleOwner.ClientVehicle.InflateTyresToMax();
            }
            else
            {
                // throw exception not in garage
            }
        }

        public void RefuelVehicle(string i_VehicleId, eFuelType i_FuelType, float i_AmountToAdd)   // fifth method in file 
        {
            Client vehicleOwner;

            if (!isVehicleInGarage(i_VehicleId, out vehicleOwner))
            {
                // throw exception
            }

            GasEngine engineToRefuel = vehicleOwner.ClientVehicle.Engine as GasEngine;

            if (engineToRefuel == null)
            {
                // throw exception not on gas
            }

            engineToRefuel.Refuel(i_AmountToAdd, i_FuelType);
        }

        public void ChargeVehicle(string i_VehicleId, float i_AmountToAdd)  // sixth method in file
        {
            Client vehicleOwner;

            if (!isVehicleInGarage(i_VehicleId, out vehicleOwner))
            {
                // throw exception
            }

            ElectricEngine engineToCharge = vehicleOwner.ClientVehicle.Engine as ElectricEngine;

            if (engineToCharge == null)
            {
                // throw exception not electric
            }

            engineToCharge.Charge(i_AmountToAdd);
        }

        public string GetVehicleDetails(string i_VehicleId) // seventh method in file
        {
            Client client;

            if (!isVehicleInGarage(i_VehicleId, out client))
            {
                // throw exception
            }

            return client.ToString();
        }

        private bool isVehicleInGarage(string i_VehicleId, out Client o_VehicleOwner)
        {
            return m_CurrentClients.TryGetValue(i_VehicleId, out o_VehicleOwner);
        }
    }
}