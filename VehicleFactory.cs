namespace VehicleRental.Vehicles;

// Removing all static references and testing it.
public static class VehicleFactory
{ 
    public static Vehicle Create()
    {
        var type = GetWantedVehicleType();
        var regNum = RegistrationNumber.GetRegistrationNumber();
        var make = SetVehicleMake();
        var model = SetVehicleModel();
        var price = SetDailyRentalPrice();
        
        switch (type.Name)
        {
            case nameof(Van):
                var foldFlatSeats = SetFoldFlatSeats();
                var cargoCapacity = SetCargoCapacity();
                return new Van(regNum, make, model, price, foldFlatSeats, cargoCapacity);
    
            case nameof(Car):
                var convertible = SetConvertible();
                var seatNumber = SetSeatNumber();
                return new Car(regNum, make, model, price, convertible, seatNumber);
    
            case nameof(ElectricCar):
                var wirelessCharging = SetWirelessCharging();
                var batteryCapacity = SetBatteryCapacity();
                return new ElectricCar(regNum, make, model, price, wirelessCharging, batteryCapacity);
    
            case nameof(Motorbike):
                var sideCar = SetSideCar();
                var maxSpeed = SetMaxSpeed();
                return new Motorbike(regNum, make, model, price, sideCar, maxSpeed);
    
            default:
                return null;
        }
    }
    
    public static System.Type GetWantedVehicleType()
    {
        var types = new List<System.Type>
        {
            typeof(Car),
            typeof(Van),
            typeof(ElectricCar),
            typeof(Motorbike)
        };
    
        Console.WriteLine("\nPlease choose the type of vehicle: ");
        for (int i = 0; i < types.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {types[i].Name}");
        }
    
        var userResponse = Console.ReadLine();
    
        while (userResponse != "4" && userResponse != "3" && userResponse != "2" && userResponse != "1")
        {
            Console.WriteLine("\nInvalid response. Please enter a number to choose your selection.");
            Console.WriteLine("\nPlease choose the type of vehicle: ");
            for (int i = 0; i < types.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {types[i].Name}");
            }
            userResponse = Console.ReadLine();
        }
        var type = int.Parse(userResponse) - 1;
        return types[type];
    }
    
    private static string SetVehicleMake()
    {
        Console.WriteLine("\nWhat is the make of the vehicle? ");
        var userResponse = Console.ReadLine();
        var containsInt = false;
        containsInt = userResponse.Any(char.IsDigit);
    
        while (userResponse == "" || containsInt)
        {
            Console.WriteLine("\nInvalid response. Must be a word. Please try again.");
            Console.WriteLine("\nWhat is the make of the vehicle? ");
            userResponse = Console.ReadLine();
            containsInt = userResponse.Any(char.IsDigit);
        }
        return userResponse;
    }
    
    private static string SetVehicleModel()
    {
        Console.WriteLine("\nWhat is the model of the vehicle? ");
        var userResponse = Console.ReadLine();
        var containsInt = false;
        containsInt = userResponse.Any(char.IsDigit);
    
        while (userResponse == "" || containsInt)
        {
            Console.WriteLine("\nInvalid response. Must be a word. Please try again.");
            Console.WriteLine("\nWhat is the model of the vehicle? ");
            userResponse = Console.ReadLine();
            containsInt = userResponse.Any(char.IsDigit);
        }
        return userResponse;
    }
    
    private static double SetDailyRentalPrice()
    {
        Console.WriteLine("\nWhat is the daily rental price of the vehicle?");
        var userResponse = Console.ReadLine();
    
        while (userResponse == "" || !(int.TryParse(userResponse, out _) || double.TryParse(userResponse, out _)))
        {
            Console.WriteLine("\nInvalid response. Must be a number. Please try again.");
            Console.WriteLine("\nWhat is the daily rental price of the vehicle?");
            userResponse = Console.ReadLine();
        }
        return Convert.ToDouble(userResponse);
    }
    
    private static bool SetFoldFlatSeats()
    {
        Console.WriteLine("\nDoes the van have fold-flat seats? (y or n)");
        var foldFlatSeats  = Console.ReadLine();

        while (foldFlatSeats != "y" && foldFlatSeats != "n")
        {
            Console.WriteLine("\nInvalid response. Please try again.");
            Console.WriteLine("\nDoes the van have fold-flat seats? (y or n)");
            foldFlatSeats = Console.ReadLine();
        }
        return foldFlatSeats == "y";
    }
        
    private static double SetCargoCapacity()
    {
        Console.WriteLine("\nWhat is the cargo capacity of the van in kg? (1200, 1600, 2000)");
        var cargoCapacity = Console.ReadLine();

        while (cargoCapacity != "1200" && cargoCapacity != "1600" && cargoCapacity != "2000")
        {
            Console.WriteLine("\nInvalid response. Please try again.");
            Console.WriteLine("\nWhat is the cargo capacity of the van in kg? (1200, 1600, 2000)");
            cargoCapacity = Console.ReadLine();
        }
        return Convert.ToDouble(cargoCapacity);
    }
    
    private static bool SetConvertible()
    {
        Console.WriteLine("\nIs the car a convertible? (y or n)");
        var isConvertible = Console.ReadLine();

        while (isConvertible != "y" && isConvertible != "n")
        {
            Console.WriteLine("\nInvalid response. Please try again.");
            Console.WriteLine("\nIs the car a convertible? (y or n)");
            isConvertible = Console.ReadLine();
        }
        return isConvertible == "y";
    }
    
    private static int SetSeatNumber()
    {
        Console.WriteLine("\nWhat are the number of seats in the car? (2, 4, 6)");
        var seatNumber = Console.ReadLine();

        while (seatNumber != "2" && seatNumber != "4" && seatNumber != "6")
        {
            Console.WriteLine("\nInvalid response. Please try again.");
            Console.WriteLine("\nWhat are the number of seats in the car? (2, 4, 6)");
            seatNumber = Console.ReadLine();
        }
        return Convert.ToInt32(seatNumber);
    }
    
    private static bool SetWirelessCharging()
    {
        Console.WriteLine("\nDoes the electric car have wireless charging? (y or n)");
        var wirelessCharging = Console.ReadLine();

        while (wirelessCharging != "y" && wirelessCharging != "n")
        {
            Console.WriteLine("\nInvalid response. Please try again.");
            Console.WriteLine("\nDoes the electric car have wireless charging? (y or n)");
            wirelessCharging = Console.ReadLine();
        }
        return wirelessCharging == "y";
    }
    
    private static int SetBatteryCapacity()
    {
        Console.WriteLine("\nWhat is the battery capacity of the electric car in kWh? (50, 75, 100)");
        var batteryCapacity = Console.ReadLine();

        while (batteryCapacity != "50" && batteryCapacity != "75" && batteryCapacity != "100")
        {
            Console.WriteLine("\nInvalid response. Please try again.");
            Console.WriteLine("\nWhat is the battery capacity of the electric car in kWh? (50, 75, 100)");
            batteryCapacity = Console.ReadLine();
        }
        return Convert.ToInt32(batteryCapacity);
    }
    
    private static bool SetSideCar()
    {
        Console.WriteLine("\nDoes the motorbike have a sidecar? (y or n)");
        var sidecar = Console.ReadLine();

        while (sidecar != "y" && sidecar != "n")
        {
            Console.WriteLine("\nInvalid response. Please try again.");
            Console.WriteLine("\nDoes the motorbike have a sidecar? (y or n)");
            sidecar = Console.ReadLine();
        }
        return sidecar == "y";
    }
        
    private static int SetMaxSpeed()
    {
        Console.WriteLine("\nWhat is the maximum speed of the motorbike in mph? (50, 100, 150)");
        var maxSpeed = Console.ReadLine();

        while (maxSpeed != "50" && maxSpeed != "100" && maxSpeed != "150")
        {
            Console.WriteLine("\nInvalid response. Please try again.");
            Console.WriteLine("\nWhat is the maximum speed of the motorbike in mph? (50, 100, 150)");
            maxSpeed = Console.ReadLine();
        }
        return Convert.ToInt32(maxSpeed);
    }
}