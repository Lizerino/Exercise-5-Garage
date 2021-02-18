using Autofac;
using Exercise5.Garage;
using Exercise5.Garage.Interfaces;
using Exercise5.Interfaces;
using Exercise5.Menus;
using Exercise5.Menus.Interfaces;
using Exercise5.UserInterfaces;
using Exercise5.UserInterfaces.Interfaces;
using Exercise5.Vehicles;
using Exercise5.Vehicles.Interfaces;

namespace Exercise5
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Garage<IVehicle>>().As<IGarage<IVehicle>>();
            builder.RegisterType<GarageHandler>().As<IGarageHandler>();
            builder.RegisterType<GarageCreationMenu>().As<IGarageCreationMenu>();
            builder.RegisterType<MainMenu>().As<IMainMenu>();
            builder.RegisterType<VehicleCreationMenu>().As<IVehicleCreationMenu>();
            builder.RegisterType<ConsoleUI>().As<IConsoleUI>();
            builder.RegisterType<Vehicle>().As<IVehicle>();
            builder.RegisterType<VehicleHandler>().As<IVehicleHandler>();
            builder.RegisterType<Startup>().As<IStartup>();
            builder.RegisterType<MenuUtil>().As<IMenuUtil>();

            return builder.Build();
            // Question: Kan man automatisera det här?
        }
    }
}