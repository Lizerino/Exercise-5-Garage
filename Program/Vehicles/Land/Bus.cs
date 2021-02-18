using System;

namespace Exercise5.Vehicles.Land
{
    [Serializable]
    internal class Bus : BaseLand
    {
        public bool HandicapAccessible { get; set; }

        /// <summary>
        /// </summary>
        /// <param name="cargoCapacity"></param>
        /// <param name="color"></param>
        /// <param name="passengerCapacity"></param>
        /// <param name="registryNumber"></param>
        /// <param name="topSpeed"></param>
        /// <param name="weight"></param>
        /// <param name="licenseRequirement"></param>
        /// <param name="numberOfWheels"></param>
        /// <param name="handicapAccessible"></param>
        public Bus(double cargoCapacity, string color, int passengerCapacity, string registryNumber, double topSpeed, double weight, double height, double length, string licenseRequirement, int numberOfWheels, bool handicapAccessible) : base(cargoCapacity, color, passengerCapacity, registryNumber, topSpeed, weight, height, length, licenseRequirement, numberOfWheels)
        {
            HandicapAccessible = handicapAccessible;
        }
    }
}