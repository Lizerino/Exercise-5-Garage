using Autofac;
using Exercise5.Garage;
using Exercise5.Menus;
using Exercise5.UserInterfaces;
using Exercise5.Vehicles;

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

            return builder.Build();
            // Question: Kan man automatisera det här?
        }
    }
}