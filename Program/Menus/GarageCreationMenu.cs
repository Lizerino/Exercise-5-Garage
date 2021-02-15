using Exercise5.Garage;
using Exercise5.UserInterfaces;
using Exercise5.Vehicles;

namespace Exercise5.Menus
{
    public class GarageCreationMenu : IGarageCreationMenu
    {
        private IConsoleUI cui;
        private IGarageHandler garageHandler;
        private IVehicleHandler vehicleHandler;
        private IVehicleCreationMenu vehicleCreationMenu;

        public GarageCreationMenu(IConsoleUI cui, IGarageHandler garageHandler, IVehicleHandler vehicleHandler, IVehicleCreationMenu vehicleCreationMenu)
        {
            this.cui = cui;
            this.garageHandler = garageHandler;
            this.vehicleHandler = vehicleHandler;
            this.vehicleCreationMenu = vehicleCreationMenu;
        }

        public IGarage<IVehicle> Show()
        {
            IGarage<IVehicle> garage = garageHandler.CreateGarage();
            while (true)
            {
                cui.Clear();
                cui.ForegroundColor(14);
                cui.Write("1: ");
                cui.ResetColor();
                cui.Write("Add Vehicle To Garage\n");
                cui.ForegroundColor(14);
                cui.Write("2: ");
                cui.ResetColor();
                cui.Write("Remove Vehicle From Garage\n");
                cui.ForegroundColor(14);
                cui.Write("0: ");
                cui.ResetColor();
                cui.Write("Finish Setting Up Garage\n");
                cui.ForegroundColor(14);
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