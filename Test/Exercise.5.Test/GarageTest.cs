using Xunit;

namespace Exercise5.Test
{
    public class GarageTests
    {
        [Fact]
        public void AddVehicle_ShouldWork()
        {
            // Create a garage and add a vehicle
            var garage = new Garage.Garage<IVehicle>("Test", 1);
            var vehicle = new Vehicles.Air.Airplane(1, "1", 1, "1", 1, 1, 1, 1, "1", 1, "1");
            garage.AddVehicle(vehicle);
            var numberOfItems = 0;
            foreach (var item in garage)
            {
                numberOfItems++;
            }
            Assert.True(numberOfItems == 1);
        }

        [Fact]
        public void RemoveVehicle_ShouldWork()
        {
            // Create garage and add a vehicle then remove the same vehicle. Only valid if the
            // AddVehicle test also works
            var garage = new Garage.Garage<IVehicle>("Test", 1);
            var vehicle = new Vehicles.Air.Airplane(1, "1", 1, "1", 1, 1, 1, 1, "1", 1, "1");
            garage.AddVehicle(vehicle);
            garage.RemoveVehicle(vehicle);
            var numberOfItems = 0;
            foreach (var item in garage)
            {
                numberOfItems++;
            }
            Assert.True(numberOfItems == 0);
        }

        [Fact]
        public void DoubleArray_ShouldWork()
        {
            // Create garage with 1 spot
            var garage = new Garage.Garage<IVehicle>("Test", 1);

            // Add 2 vehicles
            var vehicle = new Vehicles.Air.Airplane(1, "1", 1, "1", 1, 1, 1, 1, "1", 1, "1");
            var vehicle2 = new Vehicles.Air.Airplane(2, "2", 2, "2", 2, 2, 2, 2, "2", 2, "2");
            garage.AddVehicle(vehicle);
            garage.AddVehicle(vehicle2);
            var numberOfItems = 0;
            foreach (var item in garage)
            {
                numberOfItems++;
            }
            Assert.True(numberOfItems == 2);
        }
    }
}