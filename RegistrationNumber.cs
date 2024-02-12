namespace VehicleRental;

public static class RegistrationNumber
{
    public static string GetRegistrationNumber()
    {
        Console.WriteLine("\nWhat is the registration number of the vehicle? ");
        var userResponse = Console.ReadLine();
        
        var containsSpecial = false;
        containsSpecial = userResponse.Any(char.IsSymbol);

        var containsLowerCase = false;
        containsLowerCase = userResponse.Any(char.IsLower);

        while (userResponse == "" || containsSpecial || containsLowerCase) // Execute while true, if one of the or conditions is true then this is true
        {
            Console.WriteLine("\nInvalid response. Cannot have symbols or lowercase letters. Please try again.");
            Console.WriteLine("\nWhat is the registration number of the vehicle? ");
            userResponse = Console.ReadLine();
            containsSpecial = userResponse.Any(char.IsSymbol);
            containsLowerCase = userResponse.Any(char.IsLower);
        }
        return userResponse;
    }
}