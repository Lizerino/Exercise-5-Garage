using System;
using System.ComponentModel;

namespace Exercise5.Vehicles.Air
{
    [Serializable]
    internal class Airplane : BaseAir
    {
        [DisplayName("Fuel Type")]
        public string FuelType { get; set; }

        public Airplane(double cargoCapacity, string color, int seatingCapacity, string registryNumber, double topSpeed, double weight, double height, double length, string licenseRequirement, int maxAltitude, string fuelType) : base(cargoCapacity, color, seatingCapacity, registryNumber, topSpeed, weight, height, length, licenseRequirement, maxAltitude)
        {
            FuelType = fuelType;
        }
    }
}