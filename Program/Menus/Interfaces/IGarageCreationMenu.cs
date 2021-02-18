using Exercise5.Garage.Interfaces;
using Exercise5.Vehicles.Interfaces;

namespace Exercise5.Menus.Interfaces
{
    public interface IGarageCreationMenu
    {
        IGarage<IVehicle> Show();
    }
}