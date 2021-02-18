using Exercise5.Garage;
using Exercise5.Garage.Interfaces;

namespace Exercise5.Vehicles.Interfaces
{
    public interface IVehicleHandler
    {
        IVehicle CreateAirplane(IGarage<IVehicle> garage);

        IVehicle CreateBicycle(IGarage<IVehicle> garage);

        IVehicle CreateBus(IGarage<IVehicle> garage);

        IVehicle CreateCar(IGarage<IVehicle> garage);

        IVehicle CreateHelicopter(IGarage<IVehicle> garage);

        IVehicle CreateMotorBoat(IGarage<IVehicle> garage);

        IVehicle CreateMotorcycle(IGarage<IVehicle> garage);

        IVehicle CreateRowBoat(IGarage<IVehicle> garage);

        IVehicle CreateSubmarine(IGarage<IVehicle> garage);

        IVehicle CreateTruck(IGarage<IVehicle> garage);
    }
}