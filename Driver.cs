using System;

namespace VehicleRental
{
	public class Driver
	{
		public string Name { get; private set; }
        public string Surname { get; private set; }
		public DateOnly Dob { get; private set; }
		public string LicenseNo { get; private set; }

        public Driver(string name, string surname, DateOnly dob, string licenseNo)
        {
            Name = name;
            Surname = surname;
            Dob = dob;
            LicenseNo = licenseNo;
        }

        private static string GetDriversFirstName()
        {
            Console.WriteLine("\nWhat is the driver's first name?");
            var userResponse = Console.ReadLine();
            var containsInt = false;
            containsInt = userResponse.Any(char.IsDigit);

            while (userResponse == "" || containsInt)
            {
                Console.WriteLine("\nInvalid response. Please try again.");
                Console.WriteLine("\nWhat is the driver's first name:");
                userResponse = Console.ReadLine();
                containsInt = userResponse.Any(char.IsDigit);
            }
            return userResponse;
        }

        private static string GetDriversSurname()
        {
            Console.WriteLine("\nWhat is the driver's surname?");
            var userResponse = Console.ReadLine();
            var containsInt = false;
            containsInt = userResponse.Any(char.IsDigit);
            
            while (userResponse == "" || containsInt)
            {
                Console.WriteLine("\nInvalid response. Please try again.");
                Console.WriteLine("\nWhat is the driver's last name:");
                userResponse = Console.ReadLine();
                containsInt = userResponse.Any(char.IsDigit);
            }
            return userResponse;
        }
        
        private static DateOnly GetDriversDob()
        {
            Console.WriteLine("\nWhat is the driver's date of birth? (yyyy, mm, dd)");
            var userResponse = Console.ReadLine();
            
            while (!DateOnly.TryParse(userResponse, out _))
            {
                Console.WriteLine("\nInvalid entry. Please try again.");
                Console.WriteLine("\nWhat is the driver's date of birth? (yyyy, mm, dd)");
                userResponse = Console.ReadLine();
            }
            return DateOnly.Parse(userResponse);
        }

        private static string GetDriversLicense()
        {
            Console.WriteLine("\nWhat is the driver's license number?");
            string userResponse = Console.ReadLine();

            while (userResponse == "")
            {
                Console.WriteLine("\nInvalid response. Please try again.");
                Console.WriteLine("\nWhat is the driver's license number?");
                userResponse = Console.ReadLine();
            }
            return userResponse;
        }

        public static Driver MakeDriver()
        {
            string name = GetDriversFirstName();
            string surname = GetDriversSurname();
            DateOnly dob = GetDriversDob();
            string licenseNo = GetDriversLicense();

            Driver driver = new Driver(name, surname, dob, licenseNo);
            return driver;
        }

        public override string ToString()
        {
            return $"\n{nameof(Name)}: {Name}" +
                   $"\n{nameof(Surname)}: {Surname}" +
                   $"\n{nameof(Dob)}: {Dob}" +
                   $"\n{nameof(LicenseNo)}: {LicenseNo}";
        }
    }
}