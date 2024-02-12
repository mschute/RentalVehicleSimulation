using System.IO.Pipes;
using VehicleRental.Interfaces;
using VehicleRental.Vehicles;

namespace VehicleRental
{
    public class WestminsterRentalVehicle : IRentalManager, IRentalCustomer
    {
        Dictionary<string, Vehicle> _vehicles = new Dictionary<string, Vehicle>();
        Dictionary<string, List<Reservation>> _reservations = new Dictionary<string, List<Reservation>>();

        public bool AddReservation(string number, Schedule wantedSchedule)
        {
            if (!_vehicles.ContainsKey(number))
            {
                Console.WriteLine("\nSorry, a reservation could not be made as this vehicle is not in our system.");
                return false;
            }

            Reservation reservation;

            if (!_reservations.ContainsKey(number))
            {
                List<Reservation> reservationList = new List<Reservation>();

                reservation = new Reservation(Driver.MakeDriver(), wantedSchedule, _vehicles[number]);
                reservationList.Add(reservation);
                _reservations.Add(number, reservationList);
                Console.WriteLine($"\nYour reservation for {_vehicles[number].GetType().Name} {number} was successful!");
                return true;
            }

            List<Reservation> testList = _reservations[number];

            for (int i = 0; i < testList.Count; i++)
            {
                if (testList[i].Schedule.Overlaps(wantedSchedule))
                {
                    Console.WriteLine("\nSorry, the requested reservation schedule overlaps with a previous booking.");
                    return false;
                }
            }
            reservation = new Reservation(Driver.MakeDriver(), wantedSchedule, _vehicles[number]);
            _reservations[number].Add(reservation);
            Console.WriteLine($"\nYour reservation for {_vehicles[number].GetType().Name} {number} was successful!");
            return true;
        }

        public bool AddVehicle(Vehicle vehicle)
        {
            if (_vehicles.Count > 49)
            {
                Console.WriteLine("Could not add vehicle, all parking lots are filled.");
                return false;
            }

            if (!_vehicles.ContainsKey(vehicle.RegNum))
            {
                _vehicles.Add(vehicle.RegNum, vehicle);
                Console.WriteLine("\nSuccess! The vehicle was added to the garage.");
                Console.WriteLine($"\nThe number of spaces available in the garage are: {50 - _vehicles.Count}");
                return true;
            }
            else
            {
                Console.WriteLine($"The vehicle is already in the system");
                return false;
            }
        }

        public bool ChangeReservation(string number, Schedule oldSchedule, Schedule newSchedule)
        {
            if (!_reservations.ContainsKey(number))
            {
                Console.WriteLine($"The registration {number} was not found in our system. Please try again.");
                return false;
            }

            List<Reservation> reservationList = _reservations[number];

            for (int i = 0; i < _reservations[number].Count; i++)
            {
                if (reservationList[i].Schedule.Overlaps(newSchedule))
                {
                    Console.WriteLine("Sorry, the reservation change cannot be made. " +
                        "The requested schedule overlaps with an existing reservation.");

                    return false;
                }

                if (reservationList[i].Schedule.Equals(oldSchedule))
                {
                    var oldReservation = reservationList[i];
                    var newReservation = new Reservation(oldReservation.Driver, newSchedule, oldReservation.Vehicle);
                    reservationList[i] = newReservation;

                    Console.WriteLine($"Your reservation for {_vehicles[number].GetType().Name} with " +
                        $"the registration {number} has been changed from: \r\n {oldSchedule} to {newSchedule}");
                    return true;
                }
            }
            return false;
        }

        public bool DeleteReservation(string number, Schedule schedule)
        {
            if (!_reservations.ContainsKey(number))
            {
                Console.WriteLine($"The registration {number} was not found in our system. Please try again.");
                return false;
            }

            var reservationList = _reservations[number];

            for (int i = 0; i < reservationList.Count; i++)
            {
                if (reservationList[i].Schedule.Equals(schedule))
                {
                    reservationList.RemoveAt(i);

                    Console.WriteLine($"Your reservation for {_vehicles[number].GetType().Name} with " +
                                        $"the registration {number} was deleted.");
                    return true;
                }
            }
            Console.WriteLine("No matching reservation was found.");
            return false;
        }

        public bool DeleteVehicle(string number)
        {
            if (!_vehicles.ContainsKey(number))
            {
                Console.WriteLine("\nSorry. This vehicle was not found in the system. Please try again.\n");
                return false;
            }
            else
            {
                var vehicleInfo = _vehicles[number].ToString();
                _vehicles.Remove(number);
                _reservations.Remove(number);
                Console.WriteLine($"\nSuccess! The vehicle that was deleted: \n{vehicleInfo}");
                Console.WriteLine($"\nThe number of available spaces in the garage are: {50 - _vehicles.Count}");
                return true;
            }
        }

        public void GenerateReport(string filename)
        {
            while(!filename.EndsWith(".txt"))
            {
                Console.WriteLine("Invalid entry. Filename should end with '.txt'. Please try again.");
                Console.WriteLine("What file name would you like to save the report to? (E.g. filename.txt)");
                filename = Console.ReadLine();
            }
            var report = "Report\n";

            foreach (var vehicle in _vehicles)
            {
                report += $"\n{vehicle.Value}";

                if (_reservations.TryGetValue(vehicle.Key, out var reservationList))
                {
                    reservationList.Sort();

                    foreach (var reservation in reservationList)
                    {
                        report += $"\nSchedule:\n{reservation.Schedule}\nPrice: {reservation.TotalPrice}\nDriver:\n{reservation.Driver}\n";
                    }
                }

            }
            Console.WriteLine(report);
            // TODO NEED TO CLEAN UP OUTPUT
            TextWriter writer = new StreamWriter(filename, false);
            writer.WriteLine(report);
            writer.Dispose();
        }
        
        public void ListAvailableVehicles(Schedule wantedSchedule, Type type)
        {
            int matchesCount = 0;
            foreach (var vehicle in _vehicles)
            {
                if (type == vehicle.Value.GetType())
                {
                    string vehicleKey = vehicle.Key;
                    if (!_reservations.ContainsKey(vehicleKey))
                    {
                        Console.WriteLine(vehicle.Value);
                        matchesCount++;
                        continue;
                    }

                    List<Reservation> scheduleList = _reservations[vehicleKey].ToList();

                    int noOverlapCount = 0;

                    for (int i = 0; i < scheduleList.Count; i++)
                    {
                        if (!scheduleList[i].Schedule.Overlaps(wantedSchedule))
                        {
                            noOverlapCount++;
                        }

                        if(noOverlapCount == scheduleList.Count)
                        {
                            Console.WriteLine(vehicle.Value);
                            matchesCount++;
                        }
                    }
                    noOverlapCount = 0;
                }
            }
            if (matchesCount == 0)
            {
                Console.WriteLine($"\nSorry, there are no available {type.Name}s for those dates.");
            }
        }

        public void ListOrderedVehicles()
        {
            List<Vehicle> sortList = _vehicles.Values.ToList();
            sortList.Sort();
            foreach (var vehicle in sortList)
            {
                Console.WriteLine($"\n {vehicle.ToString()}");
            }
        }

        public void ListVehicles()
        {
            foreach (var entry in _vehicles)
            {
                Console.WriteLine($"\nRegistration Number: {entry.Key}");
                Console.WriteLine($"Vehicle type: { entry.Value.GetType().Name}");
                Console.WriteLine("Reservation schedule: ");
                foreach (var scheduleList in _reservations)
                {
                    if (scheduleList.Key == entry.Key)
                    {
                        var listedSchedule = _reservations[scheduleList.Key].ToList();
                        foreach (var value in listedSchedule)
                        {
                            Console.WriteLine(value.Schedule.ToString());
                        }
                    }
                }
            }
        }

        public Schedule GetScheduleDates()
        {
            Console.WriteLine("\nWhat is the pick-up date? (yyyy, mm, dd)");
            var userResponseStart = Console.ReadLine();
            
            while (!DateOnly.TryParse(userResponseStart, out _))
            {
                Console.WriteLine("Invalid entry. Please try again.");
                Console.WriteLine("\nWhat is the pick-up date? (yyyy, mm, dd)");
                userResponseStart = Console.ReadLine();
            }
            var startDate = DateOnly.Parse(userResponseStart);
            
            Console.WriteLine("\nWhat is the drop-off date? (yyyy, mm, dd)");
            var userResponseEnd = Console.ReadLine();

            while (!DateOnly.TryParse(userResponseEnd, out _) || DateOnly.Parse(userResponseEnd) < DateOnly.Parse(userResponseStart))
            {
                if (!DateOnly.TryParse(userResponseEnd, out _))
                {
                    Console.WriteLine("\nInvalid entry. Please try again.");
                    Console.WriteLine("\nWhat is the pick-up date? (yyyy, mm, dd)");
                    userResponseEnd = Console.ReadLine();
                }
                
                if (DateOnly.Parse(userResponseEnd) < DateOnly.Parse(userResponseStart))
                {
                    Console.WriteLine("\nThe drop-off date cannot be earlier than the pick-up date. Please try again.");
                    Console.WriteLine("\nWhat is the drop-off date? (yyyy, mm, dd)");
                    userResponseEnd = Console.ReadLine();
                }
            }
            var endDate = DateOnly.Parse(userResponseEnd);
            return new Schedule(startDate, endDate);
        }
        
    }
}