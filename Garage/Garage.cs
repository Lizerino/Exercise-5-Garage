﻿using Exercise5.Vehicles;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Exercise5.Garage
{
    [Serializable]
    public class Garage<T> : IEnumerable<T>, IGarage<T> where T : IVehicle
    {
        public string Name { get; set; }
        private T[] garageVehicleList;

        /// <summary>
        /// Garage Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="size"></param>
        public Garage(string name, int size)
        {
            Name = name;
            garageVehicleList = new T[size];
        }

        /// <summary>
        /// Add vehicle to first empty spot. If full double the array size and add vehicle to first empty spot.
        /// </summary>
        /// <param name="vehicleToAdd"></param>
        public void AddVehicle(T vehicleToAdd)
        {
            int i = CheckForFreeSpot();
            if (i < 0)
            {
                DoubleArraySize(vehicleToAdd);
            }
            else
            {
                garageVehicleList.SetValue(vehicleToAdd, i);
            }
        }

        /// <summary>
        /// Remove vehicle from garage
        /// </summary>
        /// <param name="vehicleToRemove"></param>
        public void RemoveVehicle(T vehicleToRemove)
        {
            for (int i = 0; i < garageVehicleList.Length; i++)
            {
                T vehicle = garageVehicleList[i];
                if (vehicleToRemove.Equals(vehicle))
                {
                    garageVehicleList[i] = default(T);
                }
            }
        }

        /// <summary>
        /// Double array size and add vehicle to first empty spot
        /// </summary>
        /// <param name="vehicle"></param>
        private void DoubleArraySize(T vehicle)
        {
            var tempArray = new T[garageVehicleList.Length];
            garageVehicleList.CopyTo(tempArray, 0);
            int oldLength = garageVehicleList.Length;
            int newLength = oldLength * 2;
            garageVehicleList = new T[newLength];
            tempArray.CopyTo(garageVehicleList, 0);
            garageVehicleList.SetValue(vehicle, oldLength);
        }

        /// <summary>
        /// Check for null and returns first null spot or -1 if not spots are found
        /// </summary>
        /// <returns></returns>
        private int CheckForFreeSpot()
        {
            for (int i = 0; i < garageVehicleList.Length; i++)
            {
                T spot = garageVehicleList[i];
                if (spot == null)
                {
                    return i;
                }
            }
            return -1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T vehicle in garageVehicleList)
            {
                if (vehicle != null)
                {
                    yield return vehicle;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}