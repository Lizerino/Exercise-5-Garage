using Exercise5.UserInterfaces;
using Exercise5.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Exercise5.Garage
{
    public class GarageHandler : IGarageHandler
    {
        private IConsoleUI cui;

        public GarageHandler(IConsoleUI cui)
        {
            this.cui = cui;
        }

        /// <summary>
        /// Create a new garage with user defined name and size
        /// </summary>
        /// <returns></returns>
        public IGarage<IVehicle> CreateGarage()
        {
            cui.ResetColor();
            var name = SetName();
            var size = SetMaxCapacity();
            IGarage<IVehicle> garage = new Garage<IVehicle>(name, size);
            return garage;
        }

        /// <summary>
        /// User input for naming a new garage
        /// </summary>
        /// <returns></returns>
        private string SetName()
        {
            cui.WriteLine("Enter name of garage");
            string name = null;
            while (String.IsNullOrWhiteSpace(name))
            {
                name = cui.ReadLine();
            }
            return name;
        }

        /// <summary>
        /// Ask user for an int to use as initial max capacity for garage
        /// </summary>
        /// <returns></returns>
        private int SetMaxCapacity()
        {
            int maxCapacityChoice;
            cui.WriteLine("Enter size of garage.");
            while (!int.TryParse(cui.ReadLine(), out maxCapacityChoice) || maxCapacityChoice < 0)
            {
                cui.Write("That is not a valid number.");
            }
            return maxCapacityChoice;
        }

        /// <summary>
        /// Add vehicle to garage
        /// </summary>
        /// <param name="garage"></param>
        /// <param name="vehicleToAdd"></param>
        public void AddVehicle(IGarage<IVehicle> garage, IVehicle vehicleToAdd)
        {
            garage.AddVehicle(vehicleToAdd);
        }

        /// <summary>
        /// Remove vehicle from garage
        /// </summary>
        /// <param name="garage"></param>
        public void RemoveVehicle(IGarage<IVehicle> garage)
        {
            bool vehicleFound = false;
            cui.WriteLine("Please enter the registration number of the vehicle you would like to remove.");
            var userInput = cui.ReadLine();
            foreach (var vehicle in garage)
            {
                if (vehicle.RegistrationNumber == userInput.ToLower())
                {
                    garage.RemoveVehicle(vehicle);
                    cui.WriteLine($"The vehicle with registration number {vehicle.RegistrationNumber} was removed");
                    vehicleFound = true;
                }
            }
            if (vehicleFound == false)
            {
                cui.WriteLine($"A vehicle with the registration number {userInput} could not be found");
            }
            cui.ReadKey();
        }

        /// <summary>
        /// List all vehicles in garage
        /// </summary>
        /// <param name="garage"></param>
        public void ListAllVehicles(IGarage<IVehicle> garage)
        {
            foreach (var vehicle in garage)
            {
                cui.WriteLine(vehicle.GetType().Name);
                var vehicleProperties = vehicle.GetType().GetProperties();
                foreach (var vehicleProperty in vehicleProperties)
                {
                    cui.WriteLine(vehicleProperty.Name + ": " + vehicleProperty.GetValue(vehicle).ToString());
                }
                cui.WriteLine("");
            }
            cui.ReadKey();
        }

        /// <summary>
        /// Modified from https://stackoverflow.com/questions/1139181/a-method-to-count-occurrences-in-a-list
        /// </summary>
        /// <param name="garage"></param>
        public void ListVehicleTypes(IGarage<IVehicle> garage)
        {
            var vehicleTypeList = new List<Type>();
            foreach (var vehicle in garage)
            {
                vehicleTypeList.Add(vehicle.GetType());
            }

            var g = vehicleTypeList.GroupBy(i => i);

            foreach (var grp in g)
            {
                Console.WriteLine($"{grp.Count()} {grp.Key.Name}");
            }
            cui.ReadKey();
        }

        /// <summary>
        /// Search for vehicle via registration number
        /// </summary>
        /// <param name="garage"></param>
        public void SearchForVehicleViaRegistrationNumber(IGarage<IVehicle> garage)
        {
            bool vehicleFound = false;
            cui.WriteLine("Please enter the registration number of the vehicle you would like search for.");
            var userInput = cui.ReadLine().ToLower();
            foreach (var vehicle in garage)
            {
                if (vehicle.RegistrationNumber == userInput)
                {
                    cui.WriteLine(vehicle.GetType().Name);
                    var vehicleProperties = vehicle.GetType().GetProperties();
                    foreach (var vehicleProperty in vehicleProperties)
                    {
                        cui.WriteLine(vehicleProperty.Name + ": " + vehicleProperty.GetValue(vehicle).ToString());
                    }
                    cui.WriteLine("");
                    vehicleFound = true;
                }
            }
            if (vehicleFound == false)
            {
                cui.WriteLine("A vehicle with that registration number could not be found");
            }
            cui.ReadKey();
        }

        /// <summary>
        /// Search for vehicle via attribute
        /// </summary>
        /// <param name="garage"></param>
        public void SearchForVehicleViaAttribute(IGarage<IVehicle> garage)
        {
            cui.WriteLine("Please enter your search criteria using this format:");
            cui.ForegroundColor(8);
            cui.WriteLine("RegistrationNumber=abc123, Color=white etc.");
            cui.ResetColor();
            cui.WriteLine("Make sure you separate each criteria with a comma and the separate the value from the attribute with a =");
            cui.WriteLine("Please be aware that the attribute name IS case sensitive");
            cui.WriteLine("Valid attributes are the following:");

            // Gets valid properties
            IEnumerable<string> validProperties = getValidProperties(garage);

            // Display all valid properties
            foreach (var property in validProperties) { cui.Write($"{property} "); }
            cui.WriteLine("");

            // Checks that user input is valid and that the searched for properties exists
            List<UserInputFinal> userInputFinalList = ValidateAndFormatUserInput(validProperties);

            // Save all vehicles matching user input
            List<IVehicle> vehicleList = GetMatchingVehicles(garage, userInputFinalList);

            // Display all matching vehicles and properties from list
            DisplayMatchingVehicles(vehicleList);

            cui.ReadKey();
        }

        /// <summary>
        /// Displays all vehicles matching the user supplied criterias
        /// </summary>
        /// <param name="vehicleList"></param>
        private void DisplayMatchingVehicles(List<IVehicle> vehicleList)
        {
            if (vehicleList.Count > 0)
            {
                cui.WriteLine("Vehicles matching all valid criteria:");
                foreach (var vehicle in vehicleList)
                {
                    cui.WriteLine(vehicle.GetType().Name);
                    var vehicleProperties = vehicle.GetType().GetProperties();
                    foreach (var vehicleProperty in vehicleProperties)
                    {
                        cui.WriteLine(vehicleProperty.Name + ": " + vehicleProperty.GetValue(vehicle).ToString());
                    }
                    cui.WriteLine("");
                }
            }
            else
            {
                cui.WriteLine("No vehicles matching the search criteria were found");
            }
        }

        /// <summary>
        /// Get vehicles matching the user supplied criteria
        /// </summary>
        /// <param name="garage"></param>
        /// <param name="userInputFinalList"></param>
        /// <returns></returns>
        private static List<IVehicle> GetMatchingVehicles(IGarage<IVehicle> garage, List<UserInputFinal> userInputFinalList)
        {
            var vehicleList = new List<IVehicle>();
            foreach (var vehicle in garage)
            {
                bool vehicleMatch = true;
                foreach (var criteria in userInputFinalList)
                {
                    string propertyValue = vehicle.GetType().GetProperty(criteria.property)?.GetValue(vehicle).ToString().ToLower();

                    if (criteria.value != propertyValue)
                    {
                        vehicleMatch = false;
                        break;
                    }
                }
                if (vehicleMatch == true && userInputFinalList.Count > 0)
                {
                    vehicleList.Add(vehicle);
                }
            }

            return vehicleList;
        }

        /// <summary>
        /// Validates user input in regards to formatting and valid properties
        /// </summary>
        /// <param name="validProperties"></param>
        /// <returns></returns>
        private List<UserInputFinal> ValidateAndFormatUserInput(IEnumerable<string> validProperties)
        {
            var userInput = cui.ReadLine();
            var userInputFinalList = new List<UserInputFinal>();
            var userInputSplitByCriteria = userInput.Split(",");
            foreach (var criteria in userInputSplitByCriteria)
            {
                var criteriaTrimmed = criteria.Trim();
                var propertyValueSplit = criteriaTrimmed.Split("=");
                UserInputFinal userInputFinal = new UserInputFinal();
                if (propertyValueSplit.Length > 1) // Avoids crash with users entering a string that is too short
                {
                    if (String.IsNullOrWhiteSpace(propertyValueSplit[0]) || String.IsNullOrWhiteSpace(propertyValueSplit[1]))
                    {
                    }
                    else if (!validProperties.Contains(propertyValueSplit[0]))
                    {
                        cui.WriteLine($"{propertyValueSplit[0]} is not a valid property");
                    }
                    else
                    {
                        userInputFinal.property = propertyValueSplit[0];
                        userInputFinal.value = propertyValueSplit[1].ToLower();
                        userInputFinalList.Add(userInputFinal);
                    }
                }
                else
                {
                    cui.WriteLine($"\"{criteria}\" is not a valid search criteria. Search criteria must consist of at least 1 character followed by a = and then another character");
                }
            }

            return userInputFinalList;
        }

        /// <summary>
        /// Gets all valid properties from currently existing vehicles in garag
        /// </summary>
        /// <param name="garage"></param>
        /// <returns></returns>
        private static IEnumerable<string> getValidProperties(IGarage<IVehicle> garage)
        {
            // Get a list of distinct valid properties
            var validPropertiesList = new List<string>();
            foreach (var vehicle in garage)
            {
                var propertiesInfoList = new List<PropertyInfo[]>();
                propertiesInfoList.Add(vehicle.GetType().GetProperties());
                foreach (var properties in propertiesInfoList)
                {
                    foreach (var property in properties)
                    {
                        validPropertiesList.Add(property.Name.ToString());
                    }
                }
            }
            var validProperties = validPropertiesList.Distinct();
            return validProperties;
        }
    }
}