using System;

namespace Exercise5.Vehicles.Air
{
    [Serializable]
    internal abstract class BaseAir : Vehicle
    {
        public int MaxAltitude { get; set; }

        protected BaseAir(double cargoCapacity, string color, int seatingCapacity, string registryNumber, double topSpeed, double weight, double height, double length, string licenseRequirement, int maxAltitude) : base(cargoCapacity, color, seatingCapacity, registryNumber, topSpeed, weight, height, length, licenseRequirement)
        {
            MaxAltitude = maxAltitude;
        }
    }
}