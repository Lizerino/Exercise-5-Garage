using Exercise5.Garage;
using Exercise5.Vehicles;

namespace Exercise5.Menus
{
    public interface IGarageCreationMenu
    {
        IGarage<IVehicle> Show();
    }
}