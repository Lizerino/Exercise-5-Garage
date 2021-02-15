using System;

namespace Exercise5.Vehicles.Sea
{
    [Serializable]
    internal abstract class BaseSea : Vehicle
    {
        public double Displacement { get; set; }

        protected BaseSea(double cargoCapacity, string color, int seatingCapacity, string registryNumber, double topSpeed, double weight, double height, double length, string licenseRequirement, double displacement) : base(cargoCapacity, color, seatingCapacity, registryNumber, topSpeed, weight, height, length, licenseRequirement)
        {
            Displacement = displacement;
        }
    }
}