using System;

namespace Exercise5.Vehicles.Land
{
    [Serializable]
    internal class Car : BaseLand
    {
        public double EngineVolume { get; set; }

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
        /// <param name="engineVolume"></param>
        public Car(double cargoCapacity, string color, int passengerCapacity, string registryNumber, double topSpeed, double weight, double height, double length, string licenseRequirement, int numberOfWheels, double engineVolume) : base(cargoCapacity, color, passengerCapacity, registryNumber, topSpeed, weight, height, length, licenseRequirement, numberOfWheels)
        {
            EngineVolume = engineVolume;
        }
    }
}