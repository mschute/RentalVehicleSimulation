namespace VehicleRental.Interfaces;

public interface IRentalCustomer
{
    void ListAvailableVehicles(Schedule wantedSchedule, Type type);
    bool AddReservation(string number, Schedule wantedSchedule);
    bool ChangeReservation(string number, Schedule oldSchedule, Schedule newSchedule);
    bool DeleteReservation(string number, Schedule schedule);
}