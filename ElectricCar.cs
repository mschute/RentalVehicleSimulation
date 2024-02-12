namespace VehicleRental.Vehicles
{
    public class ElectricCar : Vehicle
    {
        private bool WirelessCharging { get; set; }
        private int BatteryCapacity { get; set; }
        
        public ElectricCar(string regNum, string make, string model, double dailyRentalPrice, bool wirelessCharging, int batteryCapacity)
            : base(regNum, make, model, dailyRentalPrice)
        {
            WirelessCharging = wirelessCharging;
            BatteryCapacity = batteryCapacity;
        }
        
        public override List<object> GetAttributes()
        {
            var vehicleAttributes = new List<object>();
            vehicleAttributes.Add($"Registration number: {RegNum}");
            vehicleAttributes.Add($"Make: {Make}");
            vehicleAttributes.Add($"Model: {Model}");
            vehicleAttributes.Add($"Daily Rental Price: {DailyRentalPrice}");
            vehicleAttributes.Add($"Wireless Charging: {WirelessCharging}");
            vehicleAttributes.Add($"Battery Capacity in kWh: {BatteryCapacity}");

            return vehicleAttributes;
        }
        
        public override string ToString()
        {
            return string.Join("\n", GetAttributes());
        }
    }
}