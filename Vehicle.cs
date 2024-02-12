namespace VehicleRental.Vehicles
{
    public abstract class Vehicle : IComparable<Vehicle>
    {
        public string RegNum { get; private set; }
        public string Make { get; private set; }
        public string Model { get; private set; }
        public double DailyRentalPrice { get; private set; }

        public Vehicle(string regNum, string make, string model, double dailyRentalPrice) : base()
        {
            Make = make;
            RegNum = regNum;
            Model = model;
            DailyRentalPrice = dailyRentalPrice;
        }
        
        public int CompareTo(Vehicle other)
        {
            if (other == null)
            {
                return -1;
            }

            return Make.CompareTo(other.Make);
        }
        
        public virtual List<object> GetAttributes()
        {
            var vehicleAttributes = new List<object>();
            vehicleAttributes.Add($"Registration number: {RegNum}");
            vehicleAttributes.Add($"Make: {Make}");
            vehicleAttributes.Add($"Model: {Model}");
            vehicleAttributes.Add($"Daily Rental Price: {DailyRentalPrice}");

            return vehicleAttributes;
        }
        
        public override string ToString()
        {
            return string.Join("\n", GetAttributes());
        }
    }
}