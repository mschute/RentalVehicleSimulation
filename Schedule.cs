using VehicleRental.Interfaces;

namespace VehicleRental
{
    // TODO Am I implementing IOverlappable correctly? Is using equatable cheating?
    public class Schedule : IOverlappable<Schedule>, IEquatable<Schedule>
    {
        public DateOnly PickUpDate { get; private set; }
        public DateOnly DropOffDate { get; private set; }

        public Schedule(DateOnly pickUpDate, DateOnly dropOffDate)
        {
            PickUpDate = pickUpDate;
            DropOffDate = dropOffDate;
        }

        public bool Overlaps(Schedule other)
        {
            if(this.PickUpDate.CompareTo(other.DropOffDate) <= 0 && this.DropOffDate.CompareTo(other.PickUpDate) >= 0)
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"{nameof(PickUpDate)}: {PickUpDate}, {nameof(DropOffDate)}: {DropOffDate}";
        }

        public bool Equals(Schedule other)
        {
            if(other == null)
            {
                return false;
            }

            return (this.PickUpDate == other.PickUpDate && this.DropOffDate == other.DropOffDate);
        }

        public double CalcTotalDays()
        {
            var pickUp = this.PickUpDate;
            var dropOff = this.DropOffDate;

            return pickUp.DayNumber - dropOff.DayNumber;
        }
    }
}