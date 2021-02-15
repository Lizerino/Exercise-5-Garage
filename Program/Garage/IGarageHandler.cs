using Exercise5.Vehicles;

namespace Exercise5.Garage
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
    }
}