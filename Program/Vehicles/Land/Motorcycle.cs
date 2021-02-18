using System;

namespace Exercise5.Vehicles.Land

{
    [Serializable]
    internal class Motorcycle : BaseLand
    {
        public double DecibelLevel { get; set; }

        /// <summary>
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
        /// <param name="numberOfWheels"></param>
        /// <param name="decibelLevel"></param>
        public Motorcycle(double cargoCapacity, string color, int seatingCapacity, string registryNumber, double topSpeed, double weight, double height, double length, string licenseRequirement, int numberOfWheels, double decibelLevel) : base(cargoCapacity, color, seatingCapacity, registryNumber, topSpeed, weight, height, length, licenseRequirement, numberOfWheels)
        {
            DecibelLevel = decibelLevel;
        }
    }
}