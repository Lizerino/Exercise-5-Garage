using Exercise5.Garage.Interfaces;
using Exercise5.Menus.Interfaces;
using Exercise5.UserInterfaces.Interfaces;
using Exercise5.Vehicles.Interfaces;

namespace Exercise5.Menus
{
    public class VehicleCreationMenu : IVehicleCreationMenu
    {
        private IConsoleUI cui;

        private IVehicleHandler vehicleHandler;

        private IVehicle vehicle;

        private IMenuUtil menuUtil;

        public VehicleCreationMenu(IConsoleUI cui, IVehicleHandler vehicleHandler, IMenuUtil menuUtil)
        {
            this.cui = cui;
            this.vehicleHandler = vehicleHandler;
            this.menuUtil = menuUtil;
        }

        public IVehicle Show(IGarage<IVehicle> garage)
        {
            cui.Clear();
            cui.ResetColor();
            cui.WriteLine("What kind of vehicle would you like to create?");
            cui.WriteLine("");
            menuUtil.MenuOption("1", "Airplane");
            menuUtil.MenuOption("2", "Helicopter");
            menuUtil.MenuOption("3", "Bicycle");
            menuUtil.MenuOption("4", "Bus");
            menuUtil.MenuOption("5", "Car");
            menuUtil.MenuOption("6", "Motorcycle");
            menuUtil.MenuOption("7", "Truck");
            menuUtil.MenuOption("8", "Motorboat");
            menuUtil.MenuOption("9", "Rowboat");
            menuUtil.MenuOption("A", "Submarine");
            menuUtil.MenuOption("0", "Back To Main Menu");

            while (true)
            {
                switch (cui.ReadKey())
                {
                    case '1':
                        cui.Clear();
                        vehicle = vehicleHandler.CreateAirplane(garage);
                        return vehicle;

                    case '2':
                        cui.Clear();
                        vehicle = vehicleHandler.CreateHelicopter(garage);
                        return vehicle;

                    case '3':
                        cui.Clear();
                        vehicle = vehicleHandler.CreateBicycle(garage);
                        return vehicle;

                    case '4':
                        cui.Clear();
                        vehicle = vehicleHandler.CreateBus(garage);
                        return vehicle;

                    case '5':
                        cui.Clear();
                        vehicle = vehicleHandler.CreateCar(garage);
                        return vehicle;

                    case '6':
                        cui.Clear();
                        vehicle = vehicleHandler.CreateMotorcycle(garage);
                        return vehicle;

                    case '7':
                        cui.Clear();
                        vehicle = vehicleHandler.CreateTruck(garage);
                        return vehicle;

                    case '8':
                        cui.Clear();
                        vehicle = vehicleHandler.CreateMotorBoat(garage);
                        return vehicle;

                    case '9':
                        cui.Clear();
                        vehicle = vehicleHandler.CreateRowBoat(garage);
                        return vehicle;

                    case 'a':
                    case 'A':
                        cui.Clear();
                        vehicle = vehicleHandler.CreateSubmarine(garage);
                        return vehicle;

                    case 'b':
                    case 'B':
                        cui.Clear();
                        vehicle = vehicleHandler.CreateBus(garage);
                        return vehicle;

                    case '0':
                        return vehicle;

                    default:
                        cui.WriteLine("Unknown Command");
                        break;
                }
            }
        }
    }
}