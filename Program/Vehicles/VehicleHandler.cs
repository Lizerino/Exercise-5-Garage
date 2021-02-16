using Exercise5.Garage;
using Exercise5.UserInterfaces;
using Exercise5.Vehicles.Air;
using Exercise5.Vehicles.Land;
using Exercise5.Vehicles.Sea;
using System;

namespace Exercise5.Vehicles
{
    public class VehicleHandler : IVehicleHandler
    {
        private IConsoleUI cui;

        // Vehicle base properties
        private double cargoCapacity;

        private string color;
        private int seatingCapacity;
        private string registrationNumber;
        private double topSpeed;
        private double weight;
        private double height;
        private double length;
        private string licenseRequirement;

        // Air Base Properties
        private int maxAltitude;

        // Land Base Properties
        private int numberOfWheels;

        // Sea Base properties
        private double displacement;

        public VehicleHandler(IConsoleUI cui)
        {
            this.cui = cui;
        }

        private bool AskUserForAYesOrNo()
        {
            bool result;
            while (true)
            {
                char answer = cui.ReadKey();
                if (answer == 'y' ^ answer == 'n')
                {
                    if (answer == 'n')
                    {
                        result = false;
                    }
                    else
                    {
                        result = true;
                    }
                    break;
                }
                else
                {
                    cui.WriteLine("Invalid answer. Please press y or n.");
                }
            }

            return result;
        }
        // TODO: Avoid slinging garage all over the place
        private void getBaseVehicleProperties(IGarage<IVehicle> garage)
        {
            //Registry Number
            cui.WriteLine("Please enter the vehicles registry number.");
            while (true)
            {
                var userInput = cui.ReadLine().ToLower();
                if (String.IsNullOrWhiteSpace(userInput))
                {
                    cui.WriteLine("Invalid registry number. Please enter a registry number.");
                }
                else
                {
                    var uniqueRegistryNumber = true;
                    foreach (var vehicle in garage)
                    {
                        if (vehicle.RegistrationNumber == userInput)
                        {
                            uniqueRegistryNumber = false;
                            cui.WriteLine("Registry number needs to be unique.");
                        }
                    }
                    if (uniqueRegistryNumber == true)
                    {
                        registrationNumber = userInput;
                        break;
                    }
                }
            }

            // Vehicle color
            cui.WriteLine("Please enter the vehicles color.");
            while (true)
            {
                color = cui.ReadLine();
                if (String.IsNullOrWhiteSpace(color))
                {
                    cui.WriteLine("Invalid color. Please enter a color.");
                }
                else
                {
                    break;
                }
            }

            // Seating capacity
            cui.WriteLine("Please enter the vehicles seating capacity.");
            while (!int.TryParse(cui.ReadLine(), out seatingCapacity) || seatingCapacity < 0 || seatingCapacity>int.MaxValue)
            {
                cui.WriteLine("Invalid seating capacity. Please enter a seating capacity of 0 or more.");
            }

            // Top speed in km/h
            cui.WriteLine("Please enter the vehicles top speed in km/h.");
            while (!double.TryParse(cui.ReadLine(), out topSpeed) || topSpeed < 0)
            {
                cui.WriteLine("Invalid top speed. Please enter a positive number in km/h.");
            }

            // Cargo capacity in cubic meters
            cui.WriteLine("Please enter the vehicles cargo capacity in cubic meters.");
            while (!double.TryParse(cui.ReadLine(), out cargoCapacity) || cargoCapacity < 0)
            {
                cui.WriteLine("Invalid cargo capacity. Please enter a positive number in cubic meters.");
            }

            // Height in meters
            cui.WriteLine("Please enter the vehicles height in meters.");
            while (!double.TryParse(cui.ReadLine(), out height) || height < 0)
            {
                cui.WriteLine("Invalid height. Please enter a positive number in meters.");
            }

            // Length in meters
            cui.WriteLine("Please enter the vehicles length in meters.");
            while (!double.TryParse(cui.ReadLine(), out length) || length < 0)
            {
                cui.WriteLine("Invalid length. Please enter a positive number in meters.");
            }

            // Weight in kg
            cui.WriteLine("Please enter the vehicles weight in kilograms.");
            while (!double.TryParse(cui.ReadLine(), out weight) || weight < 0)
            {
                cui.WriteLine("Invalid weight. Please enter a positive number in kilograms.");
            }

            // License requirement i.e. Drivers License, Pilot License etc
            cui.WriteLine("Please enter the vehicles license requirement.");
            while (true)
            {
                licenseRequirement = cui.ReadLine();
                if (String.IsNullOrWhiteSpace(color))
                {
                    cui.WriteLine("Invalid license requirement. Please enter a license requirement.");
                }
                else
                {
                    break;
                }
            }
        }

        private void getBaseAirProperties()
        {
            // Max altitude in meters
            cui.WriteLine("Please enter the vehicles max altitude in meters.");
            while (!int.TryParse(cui.ReadLine(), out maxAltitude) || maxAltitude < 0)
            {
                cui.WriteLine("Invalid max altitude. Please enter a positive whole number in meters.");
            }
        }

        private void getBaseLandProperties()
        {
            // Number of Wheels
            cui.WriteLine("Please enter the vehicles number of wheels.");
            while (!int.TryParse(cui.ReadLine(), out numberOfWheels) || numberOfWheels < 0)
            {
                cui.WriteLine("Invalid number of wheels. Please enter a seating capacity of 0 or more.");
            }
        }

        private void getBaseSeaProperties()
        {
            // vehicles displacement
            cui.WriteLine("Please enter the vehicles displacement in tons.");
            while (!double.TryParse(cui.ReadLine(), out displacement) || displacement < 0)
            {
                cui.WriteLine("Invalid displacement. Please enter a positive number in tons.");
            }
        }

        public IVehicle CreateSubmarine(IGarage<IVehicle> garage)
        {
            getBaseVehicleProperties(garage);
            getBaseSeaProperties();

            int maxDepth;
            cui.WriteLine("Please enter the vehicles max depth in meters.");
            while (!int.TryParse(cui.ReadLine(), out maxDepth) || maxDepth < 1)
            {
                cui.WriteLine("Invalid max depth. Please enter a positive max depth in whole meters.");
            }

            Submarine vehicle = new Submarine(cargoCapacity, color, seatingCapacity, registrationNumber, topSpeed, weight, height, length, licenseRequirement, displacement, maxDepth);
            return vehicle;
        }

        public IVehicle CreateMotorcycle(IGarage<IVehicle> garage)
        {
            getBaseVehicleProperties(garage);
            getBaseLandProperties();

            double decibelLevel;
            cui.WriteLine("Please enter the vehicles decibel level");
            while (!double.TryParse(cui.ReadLine(), out decibelLevel) || decibelLevel < 0)
            {
                cui.WriteLine("Invalid decibel level. Please enter a positive decibel level.");
            }

            Motorcycle vehicle = new Motorcycle(cargoCapacity, color, seatingCapacity, registrationNumber, topSpeed, weight, height, length, licenseRequirement, numberOfWheels, decibelLevel);
            return vehicle;
        }

        public IVehicle CreateAirplane(IGarage<IVehicle> garage)
        {
            getBaseVehicleProperties(garage);
            getBaseAirProperties();

            string fuelType;
            cui.WriteLine("Please enter the vehicles fuel type");
            while (true)
            {
                fuelType = cui.ReadLine();
                if (String.IsNullOrWhiteSpace(fuelType))
                {
                    cui.WriteLine("Invalid fuel type. Please enter a fuel type.");
                }
                else
                {
                    break;
                }
            }

            Airplane vehicle = new Airplane(cargoCapacity, color, seatingCapacity, registrationNumber, topSpeed, weight, height, length, licenseRequirement, maxAltitude, fuelType);
            return vehicle;
        }

        public IVehicle CreateHelicopter(IGarage<IVehicle> garage)
        {
            getBaseVehicleProperties(garage);
            getBaseAirProperties();

            int numberOfRotors;
            cui.WriteLine("Please enter the vehicles number of rotors.");
            while (!int.TryParse(cui.ReadLine(), out numberOfRotors) || numberOfRotors < 1)
            {
                cui.WriteLine("Invalid number of rotors. Please enter a positive number.");
            }

            Helicopter vehicle = new Helicopter(cargoCapacity, color, seatingCapacity, registrationNumber, topSpeed, weight, height, length, licenseRequirement, maxAltitude, numberOfRotors);
            return vehicle;
        }

        public IVehicle CreateMotorBoat(IGarage<IVehicle> garage)
        {
            getBaseVehicleProperties(garage);
            getBaseSeaProperties();

            int numberOfEngines;
            cui.WriteLine("Please enter the vehicles number of engines");
            while (!int.TryParse(cui.ReadLine(), out numberOfEngines) || numberOfEngines < 1)
            {
                cui.WriteLine("Invalid number of engines. Please enter a positive number.");
            }

            MotorBoat vehicle = new MotorBoat(cargoCapacity, color, seatingCapacity, registrationNumber, topSpeed, weight, height, length, licenseRequirement, displacement, numberOfEngines);
            return vehicle;
        }

        public IVehicle CreateCar(IGarage<IVehicle> garage)
        {            
            getBaseVehicleProperties(garage);
            getBaseLandProperties();

            double engineVolume;
            cui.WriteLine("Please enter the vehicles engine volume in liters.");
            while (!double.TryParse(cui.ReadLine(), out engineVolume) || engineVolume < 0)
            {
                cui.WriteLine("Invalid engine volume. Please enter a positive engine volume in liters.");
            }

            Car vehicle = new Car(cargoCapacity, color, seatingCapacity, registrationNumber, topSpeed, weight, height, length, licenseRequirement, numberOfWheels, engineVolume);
            return vehicle;
        }

        public IVehicle CreateBus(IGarage<IVehicle> garage)
        {
            getBaseVehicleProperties(garage);
            getBaseLandProperties();

            cui.WriteLine("Is this vehicle handicap accessible. Please answer (Y)es or (N)o.");
            bool handicapAccessible = AskUserForAYesOrNo();

            Bus vehicle = new Bus(cargoCapacity, color, seatingCapacity, registrationNumber, topSpeed, weight, height, length, licenseRequirement, numberOfWheels, handicapAccessible);
            return vehicle;
        }

        public IVehicle CreateRowBoat(IGarage<IVehicle> garage)
        {
            getBaseVehicleProperties(garage);
            getBaseSeaProperties();

            int numberOfRowers;
            cui.WriteLine("Please enter the vehicles number of rowers.");
            while (!int.TryParse(cui.ReadLine(), out numberOfRowers) || numberOfRowers < 0)
            {
                cui.WriteLine("Invalid number of rowers. Please enter a positive number.");
            }

            RowBoat vehicle = new RowBoat(cargoCapacity, color, seatingCapacity, registrationNumber, topSpeed, weight, height, length, licenseRequirement, displacement, numberOfRowers);
            return vehicle;
        }

        public IVehicle CreateTruck(IGarage<IVehicle> garage)
        {
            getBaseVehicleProperties(garage);
            getBaseLandProperties();

            cui.WriteLine("Is this vehicle a semi truck. Please answer (Y)es or (N)o.");
            bool isASemi = AskUserForAYesOrNo();

            Truck vehicle = new Truck(cargoCapacity, color, seatingCapacity, registrationNumber, topSpeed, weight, height, length, licenseRequirement, numberOfWheels, isASemi);
            return vehicle;
        }

        public IVehicle CreateBicycle(IGarage<IVehicle> garage)
        {
            getBaseVehicleProperties(garage);
            getBaseLandProperties();

            cui.WriteLine("Does this vehicle have a child seat. Please answer (Y)es or (N)o.");
            bool hasChildSeat = AskUserForAYesOrNo();
            Bicycle vehicle = new Bicycle(cargoCapacity, color, seatingCapacity, registrationNumber, topSpeed, weight, height, length, licenseRequirement, numberOfWheels, hasChildSeat);
            return vehicle;
        }
    }
}