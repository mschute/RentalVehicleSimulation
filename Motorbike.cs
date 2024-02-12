namespace VehicleRental.Vehicles
{
    public class Motorbike : Vehicle
    {
        private bool SideCar { get; set; }
        private int MaxSpeed { get; set; }
        
        public Motorbike(string regNum, string make, string model, double dailyRentalPrice, bool sideCar, int maxSpeed)
            : base(regNum, make, model, dailyRentalPrice)
        {
            SideCar = sideCar;
            MaxSpeed = maxSpeed;
        }
        
        public override List<object> GetAttributes()
        {
            var vehicleAttributes = new List<object>();
            vehicleAttributes.Add($"Registration Number: {RegNum}");
            vehicleAttributes.Add($"Make: {Make}");
            vehicleAttributes.Add($"Model: {Model}");
            vehicleAttributes.Add($"Daily Rental Price: {DailyRentalPrice}");
            vehicleAttributes.Add($"Side Car: {SideCar}");
            vehicleAttributes.Add($"Maximum Speed (mph): {MaxSpeed}");

            return vehicleAttributes;
        }
        
        public override string ToString()
        {
            return string.Join("\n", GetAttributes());
        }
    }
}