namespace VehicleRental.Vehicles
{
    public class Van : Vehicle
    {
        private bool FoldFlatSeats { get; set; }
        private double CargoCapacity { get; set; }
        
        public Van(string regNum, string make, string model, double dailyRentalPrice, bool foldFlatSeats, double cargoCapacity)
            : base(regNum, make, model, dailyRentalPrice)
        {
            FoldFlatSeats = foldFlatSeats;
            CargoCapacity = cargoCapacity;
        }
        
        public override List<object> GetAttributes()
        {
            var vehicleAttributes = new List<object>();
            vehicleAttributes.Add($"Registration number: {RegNum}");
            vehicleAttributes.Add($"Make: {Make}");
            vehicleAttributes.Add($"Model: {Model}");
            vehicleAttributes.Add($"Daily Rental Price: {DailyRentalPrice}");
            vehicleAttributes.Add($"Fold-flat Seats: {FoldFlatSeats}");
            vehicleAttributes.Add($"Cargo Capacity: {CargoCapacity}");

            return vehicleAttributes;
        }
        
        public override string ToString()
        {
            return string.Join("\n", GetAttributes());
        }
    }
}