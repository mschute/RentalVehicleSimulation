using VehicleRental.Vehicles;

namespace VehicleRental.Interfaces;

public interface IRentalManager
{
    public bool AddVehicle(Vehicle vehicle);
    public bool DeleteVehicle(string number);
    public void ListVehicles();
    public void ListOrderedVehicles();
    public void GenerateReport(string fileName);
}