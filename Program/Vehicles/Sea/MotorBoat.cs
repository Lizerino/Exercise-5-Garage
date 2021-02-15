using System;

namespace Exercise5.Vehicles.Sea
{
    [Serializable]
    internal class MotorBoat : BaseSea
    {
        public int NumberOfEngines { get; set; }

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
        /// <param name="displacement"></param>
        /// <param name="numberOfEngines"></param>
        public MotorBoat(double cargoCapacity, string color, int seatingCapacity, string registryNumber, double topSpeed, double weight, double height, double length, string licenseRequirement, double displacement, int numberOfEngines) : base(cargoCapacity, color, seatingCapacity, registryNumber, topSpeed, weight, height, length, licenseRequirement, displacement)
        {
            NumberOfEngines = numberOfEngines;
        }
    }
}