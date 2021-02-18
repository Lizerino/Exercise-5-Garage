using Exercise5.Vehicles;
using Exercise5.Vehicles.Interfaces;

namespace Exercise5.Garage.Interfaces
{
    public interface IGarageHandler
    {
        IGarage<IVehicle> CreateGarage();

        void AddVehicle(IGarage<IVehicle> garage, IVehicle vehicleToAdd);

        void RemoveVehicle(IGarage<IVehicle> garage);

        void ListAllVehicles(IGarage<IVehicle> garage);

        void ListVehicleTypes(IGarage<IVehicle> garage);

        void SearchForVehicleViaRegistrationNumber(IGarage<IVehicle> garage);

        void SearchForVehicleViaAttribute(IGarage<IVehicle> garage);

        IGarage<IVehicle> CreateDefaultGarage();
    }
}