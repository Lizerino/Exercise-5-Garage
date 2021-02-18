using Exercise5.Vehicles;
using Exercise5.Vehicles.Interfaces;
using System.Collections.Generic;

namespace Exercise5.Garage.Interfaces
{
    public interface IGarage<T> where T : IVehicle
    {
        string Name { get; set; }

        void AddVehicle(T vehicleToAdd);

        void RemoveVehicle(T vehicleToRemove);

        IEnumerator<T> GetEnumerator();
    }
}