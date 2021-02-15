using System;

namespace Exercise5.Vehicles
{
    [Serializable]
    public class Vehicle : IVehicle
    {
        public double CargoCapacity { get; set; }
        public string Color { get; set; }
        public int SeatingCapacity { get; set; }
        public string RegistrationNumber { get; set; }
        public double TopSpeed { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public double Length { get; set; }
        public string LicenseRequirement { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="cargoCapacity"></param>
        /// <param name="color"></param>
        /// <param name="seatingCapacity"></param>
        /// <param name="registryNumber"></param>
        /// <param name="topSpeed"></param>
        /// <param name="weight"></param>
        /// <param name="height"></param>
        /// <param name="length"></param>
        /// <param name="licenseRequirement"></param>
        public Vehicle(double cargoCapacity, string color, int seatingCapacity, string registryNumber, double topSpeed, double weight, double height, double length, string licenseRequirement)
        {
            CargoCapacity = cargoCapacity;
            Color = color;
            SeatingCapacity = seatingCapacity;
            RegistrationNumber = registryNumber;
            TopSpeed = topSpeed;
            Weight = weight;
            Height = height;
            Length = length;
            LicenseRequirement = licenseRequirement;
        }
    }
}