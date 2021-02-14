using System;

namespace Exercise5.Vehicles.Air
{
    [Serializable]
    internal class Helicopter : BaseAir
    {
        public int NumberOfRotors { get; set; }

        public Helicopter(double cargoCapacity, string color, int seatingCapacity, string registryNumber, double topSpeed, double weight, double height, double length, string licenseRequirement, int maxAltitude, int numberOfRotors) : base(cargoCapacity, color, seatingCapacity, registryNumber, topSpeed, weight, height, length, licenseRequirement, maxAltitude)
        {
            NumberOfRotors = numberOfRotors;
        }
    }
}