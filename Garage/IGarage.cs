using Exercise5.Vehicles;
using System.Collections.Generic;

namespace Exercise5.Garage
{
    public interface IGarage<T> where T : IVehicle
    {
        string Name { get; set; }

        void AddVehicle(T vehicleToAdd);

        void RemoveVehicle(T vehicleToRemove);

        IEnumerator<T> GetEnumerator();
    }
}