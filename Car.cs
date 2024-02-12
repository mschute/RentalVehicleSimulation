namespace VehicleRental.Vehicles
{
    public class Car : Vehicle
    {
        
        private bool Convertible { get; set; }
        private int SeatNumber { get; set; }
        
        public Car(string regNum, string make, string model, double dailyRentalPrice, bool convertible, int seatNumber)
            : base(regNum, make, model, dailyRentalPrice)
        {
            Convertible = convertible;
            SeatNumber = seatNumber;
        }
        
        public override List<object> GetAttributes()
        {
            var vehicleAttributes = new List<object>();
            vehicleAttributes.Add($"Registration number: {RegNum}");
            vehicleAttributes.Add($"Make: {Make}");
            vehicleAttributes.Add($"Model: {Model}");
            vehicleAttributes.Add($"Daily Rental Price: {DailyRentalPrice}");
            vehicleAttributes.Add($"Convertible: {Convertible}");
            vehicleAttributes.Add($"Number of seats: {SeatNumber}");

            return vehicleAttributes;
        }
        
        public override string ToString()
        {
            return string.Join("\n", GetAttributes());
        }
    }
}