﻿using Exercise5.FilesHandling;
using Exercise5.Garage;
using Exercise5.Garage.Interfaces;
using Exercise5.Menus.Interfaces;
using Exercise5.UserInterfaces.Interfaces;
using Exercise5.Vehicles.Interfaces;
using System;
using System.IO;

namespace Exercise5.Menus
{
    public partial class MainMenu : IMainMenu
    {
        private IConsoleUI cui;

        private IGarageHandler garageHandler;

        private IGarageCreationMenu garageCreationMenu;

        private IVehicleCreationMenu vehicleCreationMenu;

        private IMenuUtil menuUtil;

        private string badCommand;

        public MainMenu(IConsoleUI cui, IGarageHandler garageHandler, IGarageCreationMenu garageCreationMenu, IVehicleCreationMenu vehicleCreationMenu, IMenuUtil menuUtil)
        {
            this.cui = cui;
            this.garageHandler = garageHandler;
            this.garageCreationMenu = garageCreationMenu;
            this.vehicleCreationMenu = vehicleCreationMenu;
            this.menuUtil = menuUtil;
        }

        public void Show()
        {
            // Reset color of text if not default at start
            cui.ResetColor();

            IGarage<IVehicle> garage;
            try
            {
                // Load Garage from file
                garage = LoadGarageFromFile();
            }
            catch (Exception)
            {
                // Create default garage if loading garage fails
                garage = garageHandler.CreateGarage();
            }

            while (true)
            {
                cui.Clear();
                menuUtil.MenuOption("1", "Create A New Garage");

                menuUtil.MenuOption("2", "Add Vehicle To Garage");

                menuUtil.MenuOption("3", "Remove Vehicle From Garage");

                menuUtil.MenuOption("4", "Search For Vehicle In Garage Via Registration Number");

                menuUtil.MenuOption("5", "Search For Vehicle In Garage Via Attribute");

                menuUtil.MenuOption("6", "List All Vehicles In Garage");

                menuUtil.MenuOption("7", "List the amount and type of vehicles in garage");

                menuUtil.MenuOption("8", "Create a default garage and seed it");

                menuUtil.MenuOption("Q", "Save Garage and Quit Program");

                cui.WriteLine(badCommand);
                badCommand = "";
                switch (cui.ReadKey())
                {
                    case '1':

                        // Create a new garage
                        SaveGarageToFile(garage);
                        garage = garageCreationMenu.Show();
                        break;

                    case '2':

                        // Add vehicle to current garage
                        IVehicle vehicleToAdd = vehicleCreationMenu.Show(garage);
                        garageHandler.AddVehicle(garage, vehicleToAdd);
                        break;

                    case '3':

                        // Remove Vehicle from current garage
                        garageHandler.RemoveVehicle(garage);
                        break;

                    case '4':

                        // Search for vehicle in current garage via registration number
                        garageHandler.SearchForVehicleViaRegistrationNumber(garage);
                        break;

                    case '5':

                        // Search for vehicle in current garage via attribute
                        garageHandler.SearchForVehicleViaAttribute(garage);
                        break;

                    case '6':

                        //List all vehicles in current garage
                        garageHandler.ListAllVehicles(garage);
                        break;

                    case '7':

                        // List the types and number of vehicles
                        garageHandler.ListVehicleTypes(garage);
                        break;

                    case '8':

                        // Create a default garage and seed it with vehicles
                        garage = garageHandler.CreateDefaultGarage();
                        break;

                    case 'q':
                        SaveGarageToFile(garage);
                        cui.Clear();
                        cui.WriteLine("Thank you for choosing Garage 1.0 as your garage managing software of choice");
                        cui.WriteLine("Please take a look at our other software solutions");
                        cui.WriteLine("Wardrobe 1.0, Wastebasket 2.0 and Bucket 4.2 to help us make your life even easier!");
                        Environment.Exit(0);
                        break;

                    default:
                        badCommand = "Unknown Command";
                        break;
                }
                cui.Clear();
            }
        }

        private void SaveGarageToFile(IGarage<IVehicle> garage)
        {
            // TODO: Make it possible to save multiple different garages
            BinarySerialization.WriteToBinaryFile(Directory.GetCurrentDirectory() + "Garage.grg", garage);
        }

        private IGarage<IVehicle> LoadGarageFromFile()
        {
            return BinarySerialization.ReadFromBinaryFile<Garage<IVehicle>>(Directory.GetCurrentDirectory() + "Garage.grg");
        }
    }
}