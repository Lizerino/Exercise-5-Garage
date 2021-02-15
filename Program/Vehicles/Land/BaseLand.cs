using System;

namespace Exercise5.Vehicles.Land
{
    [Serializable]
    internal abstract class BaseLand : Vehicle
    {
        public int NumberOfWheels { get; set; }

        protected BaseLand(double cargoCapacity, string color, int seatingCapacity, string registryNumber, double topSpeed, double weight, double height, double length, string licenseRequirement, int numberOfWheels) : base(cargoCapacity, color, seatingCapacity, registryNumber, topSpeed, weight, height, length, licenseRequirement)
        {
            NumberOfWheels = numberOfWheels;
        }
    }
}