using Exercise5.Garage;
using Exercise5.Vehicles;

namespace Exercise5.Menus
{
    public interface IVehicleCreationMenu
    {
        IVehicle Show(IGarage<IVehicle> garage);
    }
}