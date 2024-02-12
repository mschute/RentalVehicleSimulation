using VehicleRental.Vehicles;

namespace VehicleRental
{
    public class Reservation : IComparable<Reservation>
    {
        public Driver Driver { get; private set; }
        public Schedule Schedule { get; private set; }
        public Vehicle Vehicle { get; private set; }
        public double TotalPrice
        {
            get
            {
                return Vehicle.DailyRentalPrice * Schedule.CalcTotalDays();
            }
        }

        public Reservation(Driver driver, Schedule schedule, Vehicle vehicle)
        {
            Driver = driver;
            Schedule = schedule;
            Vehicle = vehicle;
        }

        public int CompareTo(Reservation other)
        {
            if (other.Schedule == null && this.Schedule == null)
            {
                return this.Vehicle.RegNum.CompareTo(other.Vehicle.RegNum);
            }

            if (other.Schedule == null)
            {
                return 1;
            }

            if (this.Schedule == null)
            {
                return -1;
            }

            return (this.Schedule.PickUpDate.CompareTo(other.Schedule.PickUpDate));
        }
    }
}