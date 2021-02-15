using System;

namespace Exercise5.Vehicles.Sea
{
    [Serializable]
    internal class RowBoat : BaseSea
    {
        public int NumberOfRowers { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="cargoCapacity"></param>
        /// <param name="color"></param>
        /// <param name="seatingCapacity"></param>
        /// <param name="registryNumber"></param>
        /// <param name="topSpeed"></param>
        /// <param name="weight"></param>
        /// <param name="licenseRequirement"></param>
        /// <param name="displacement"></param>
        /// <param name="numberOfRowers"></param>
        public RowBoat(double cargoCapacity, string color, int seatingCapacity, string registryNumber, double topSpeed, double weight, double height, double length, string licenseRequirement, double displacement, int numberOfRowers) : base(cargoCapacity, color, seatingCapacity, registryNumber, topSpeed, weight, height, length, licenseRequirement, displacement)
        {
            NumberOfRowers = numberOfRowers;
        }
    }
}