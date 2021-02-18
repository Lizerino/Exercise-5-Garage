using System;

namespace Exercise5.Vehicles.Land
{
    [Serializable]
    internal class Truck : BaseLand
    {
        public bool IsASemi { get; set; }

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
        /// <param name="isASemi"></param>
        public Truck(double cargoCapacity, string color, int seatingCapacity, string registryNumber, double topSpeed, double weight, double height, double length, string licenseRequirement, int numberOfWheels, bool isASemi) : base(cargoCapacity, color, seatingCapacity, registryNumber, topSpeed, weight, height, length, licenseRequirement, numberOfWheels)
        {
            IsASemi = isASemi;
        }
    }
}