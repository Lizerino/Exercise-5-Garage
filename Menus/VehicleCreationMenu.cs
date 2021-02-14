using Exercise5.Garage;
using Exercise5.UserInterfaces;
using Exercise5.Vehicles;

namespace Exercise5.Menus
{
    public class VehicleCreationMenu : IVehicleCreationMenu
    {
        private IConsoleUI cui;
        private IVehicleHandler vehicleHandler;
        private IVehicle vehicle;

        public VehicleCreationMenu(IConsoleUI cui, IVehicleHandler vehicleHandler)
        {
            this.cui = cui;
            this.vehicleHandler = vehicleHandler;
        }

        public IVehicle Show(IGarage<IVehicle> garage)
        {
            cui.Clear();
            cui.ResetColor();
            cui.WriteLine("What kind of vehicle would you like to create?");
            cui.WriteLine("");
            cui.ForegroundColor(14);
            cui.Write("1: ");
            cui.ResetColor();
            cui.WriteLine("Airplane");
            cui.ForegroundColor(14);
            cui.Write("2: ");
            cui.ResetColor();
            cui.WriteLine("Helicopter");
            cui.ForegroundColor(14);
            cui.Write("3: ");
            cui.ResetColor();
            cui.WriteLine("Bicycle");
            cui.ForegroundColor(14);
            cui.Write("4: ");
            cui.ResetColor();
            cui.WriteLine("Bus");
            cui.ForegroundColor(14);
            cui.Write("5: ");
            cui.ResetColor();
            cui.WriteLine("Car");
            cui.ForegroundColor(14);
            cui.Write("6: ");
            cui.ResetColor();
            cui.WriteLine("Motorcycle");
            cui.ForegroundColor(14);
            cui.Write("7: ");
            cui.ResetColor();
            cui.WriteLine("Truck");
            cui.ForegroundColor(14);
            cui.Write("8: ");
            cui.ResetColor();
            cui.WriteLine("Motorboat");
            cui.ForegroundColor(14);
            cui.Write("9: ");
            cui.ResetColor();
            cui.WriteLine("Rowboat");
            cui.ForegroundColor(14);
            cui.Write("A: ");
            cui.ResetColor();
            cui.WriteLine("Submarine");

            cui.ForegroundColor(14);
            cui.Write("0: ");
            cui.ResetColor();
            cui.Write("Back To Main Menu");

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