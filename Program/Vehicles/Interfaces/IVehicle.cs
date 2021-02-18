namespace Exercise5.Vehicles.Interfaces
{
    public interface IVehicle
    {
        double CargoCapacity { get; set; }

        string Color { get; set; }

        int SeatingCapacity { get; set; }

        string RegistrationNumber { get; set; }

        double TopSpeed { get; set; }

        double Weight { get; set; }

        double Height { get; set; }

        double Length { get; set; }

        string LicenseRequirement { get; set; }
    }
}