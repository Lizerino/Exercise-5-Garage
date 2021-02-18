using Exercise5.Garage.Interfaces;
using Exercise5.Menus.Interfaces;
using Exercise5.UserInterfaces.Interfaces;
using Exercise5.Vehicles.Interfaces;

namespace Exercise5.Menus
{
    public class GarageCreationMenu : IGarageCreationMenu
    {
        private IConsoleUI cui;

        private IGarageHandler garageHandler;

        private IVehicleCreationMenu vehicleCreationMenu;

        private IMenuUtil menuUtil;

        public GarageCreationMenu(IConsoleUI cui, IGarageHandler garageHandler, IVehicleCreationMenu vehicleCreationMenu, IMenuUtil menuUtil)
        {
            this.cui = cui;
            this.garageHandler = garageHandler;           
            this.vehicleCreationMenu = vehicleCreationMenu;
            this.menuUtil = menuUtil;
        }

        public IGarage<IVehicle> Show()
        {
            IGarage<IVehicle> garage = garageHandler.CreateGarage();

            while (true)
            {
                cui.Clear();
                menuUtil.MenuOption("1", "Add Vehicle To Garage");
                menuUtil.MenuOption("2", "Remove Vehicle From Garage");
                menuUtil.MenuOption("0", "Finish Setting Up Garage");
                switch (cui.ReadKey())
                {
                    case '1':

                        // Add Vehicle to new garage
                        garageHandler.AddVehicle(garage, vehicleCreationMenu.Show(garage));
                        break;

                    case '2':

                        // Remove a vehicle from new garage
                        garageHandler.ListAllVehicles(garage);
                        garageHandler.RemoveVehicle(garage);
                        break;

                    case '0':

                        // Finish setting up garage
                        return garage;

                    default:
                        cui.WriteLine("Unknown Command");
                        break;
                }
            }
        }
    }
}