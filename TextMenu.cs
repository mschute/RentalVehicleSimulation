using VehicleRental.Vehicles;

namespace VehicleRental
{
    public class TextMenu
    {
        WestminsterRentalVehicle _controller;

        public TextMenu(WestminsterRentalVehicle controller)
        {
            _controller = controller;
        }

        private static string MainMenuChoice()
        {
            Console.WriteLine("\nWelcome to Westminster Vehicle Rental\n");
            Console.WriteLine("Press 1 for the Customer Menu");
            Console.WriteLine("Press 2 for the Admin Menu");
            Console.WriteLine("Press 3 to exit");

            var userResponse = Console.ReadLine();

            while(userResponse != "3" && userResponse != "2" && userResponse != "1")
            {
                Console.WriteLine("Invalid input. Please try again");
                userResponse = Console.ReadLine();
            }

            return userResponse;
        }

        public void MainMenu()
        {
            var userMenuChoice = MainMenuChoice();

            while(userMenuChoice != "3")
            {
                switch (userMenuChoice)
                {
                    case "1":
                        userMenuChoice = CustomerMenu();
                        break;
                    case "2":
                        userMenuChoice = AdminMenu();
                        break;
                }
            }

            Console.Clear();
            Console.WriteLine("Thank you for visiting Westminster Vechile Rental! Goodbye!");
        }

        private static string CustomerMenuChoice()
        {
            Console.WriteLine("\nWelcome to the Customer Menu\n");
            Console.WriteLine("Choose an option: \n");
            Console.WriteLine("1. List the available vehicles ");
            Console.WriteLine("2. Add a reservation ");
            Console.WriteLine("3. Change a reservation ");
            Console.WriteLine("4. Delete a reservation ");
            Console.WriteLine("5. Switch to Admin Menu ");
            Console.WriteLine("6. Exit Westminster Vehicle Rental");

            var userResponse = Console.ReadLine();

            while (userResponse != "1" && userResponse != "2" && userResponse != "3" && userResponse != "4" && userResponse != "5" && userResponse != "6")
            {
                Console.WriteLine("Invalid response. Please try again.");
                userResponse = Console.ReadLine();
            }

            return userResponse;
        }

        private static bool CustomerContinue()
        {
            Console.WriteLine("\nWould you like to do something else? (y or n)");
            var userContinue = Console.ReadLine();

            while(userContinue != "y" && userContinue != "n")
            {
                Console.WriteLine("Invalid response. Please try again.");
                userContinue = Console.ReadLine();
            }

            return userContinue == "y";
        }

        private string CustomerMenu()
        {
            var customerChoice = "";

            while (customerChoice != "5" && customerChoice != "6")
            {
                customerChoice = CustomerMenuChoice();

                switch (customerChoice)
                {
                    // TODO Verify this works bug free
                    case "1":
                    {
                        var type = VehicleFactory.GetWantedVehicleType();
                        Console.WriteLine("For your desired reservation:");
                        var wantedSchedule = _controller.GetScheduleDates();

                        _controller.ListAvailableVehicles(wantedSchedule, type);

                        var cont = CustomerContinue();
                        return cont == false ? "3" : "1";
                    }
                    // TODO Verify this works bug free
                    case "2":
                    {
                        //test remove static context
                        var number = RegistrationNumber.GetRegistrationNumber();
                        Console.WriteLine("For the reservation you would like to make:");
                        var wantedSchedule = _controller.GetScheduleDates();

                        _controller.AddReservation(number, wantedSchedule);

                        var cont = CustomerContinue();
                        return cont == false ? "3" : "1";
                    }
                    // TODO Verify this works bug free
                    case "3":
                    {
                        var number = RegistrationNumber.GetRegistrationNumber();
                        Console.WriteLine("For your old reservation: ");
                        var oldSchedule = _controller.GetScheduleDates();
                        Console.WriteLine("For your new reservation:");
                        var newSchedule = _controller.GetScheduleDates();

                        _controller.ChangeReservation(number, oldSchedule, newSchedule);

                        var cont = CustomerContinue();
                        return cont == false ? "3" : "1";
                    }
                    // TODO Verify this works bug free
                    case "4":
                    {
                        var number = RegistrationNumber.GetRegistrationNumber();
                        Console.WriteLine("For the reservation you would like to delete:");
                        var schedule = _controller.GetScheduleDates();

                        _controller.DeleteReservation(number, schedule);
                        var cont = CustomerContinue();
                        return cont == false ? "3" : "1";
                    }
                }
            }
            return customerChoice == "5" ? "2" : "3";
        }

        private static string AdminMenuChoice()
        {
            Console.WriteLine("\nWelcome to the Admin Menu\n");
            Console.WriteLine("Choose an option: \n");
            Console.WriteLine("1. Add a vehicle");
            Console.WriteLine("2. Delete a vehicle");
            Console.WriteLine("3. List vehicles");
            Console.WriteLine("4. List vehicles in order of make");
            Console.WriteLine("5. Generate report");
            Console.WriteLine("6. Switch to Customer Menu ");
            Console.WriteLine("7. Exit Westminster Vehicle Rental");

            var userResponse = Console.ReadLine();

            while (userResponse != "1" && userResponse != "2" && userResponse != "3" && userResponse != "4" && userResponse != "5" && userResponse != "6")
            {
                Console.WriteLine("Invalid response. Please try again.");
                userResponse = Console.ReadLine();
            }

            return userResponse;
        }

        private static bool AdminContinue()
        {
            Console.WriteLine("\nWould you like to do something else? (y or n)");
            var userContinue = Console.ReadLine();

            while (userContinue != "y" && userContinue != "n")
            {
                Console.WriteLine("Invalid response. Please try again.");
                userContinue = Console.ReadLine();
            }

            return userContinue == "y";
        }

        private string AdminMenu()
        {
            var adminChoice = "";

            while (adminChoice != "5" && adminChoice != "6")
            {
                adminChoice = AdminMenuChoice();

                switch (adminChoice)
                {
                    case "1":
                    {
                        var vehicle = VehicleFactory.Create();
                        _controller.AddVehicle(vehicle);

                        var cont = AdminContinue();
                        return cont == false ? "3" : "2";
                    }
                    case "2":
                    {
                        Console.WriteLine("\nWhat is the registration number of the vehicle you would like to delete? ");
                        var vehicle = Console.ReadLine();
                        _controller.DeleteVehicle(vehicle);

                        var cont = AdminContinue();
                        return cont == false ? "3" : "2";
                    }
                    case "3":
                    {
                        _controller.ListVehicles();

                        var cont = AdminContinue();
                        return cont == false ? "3" : "2";
                    }
                    case "4":
                    {
                        _controller.ListOrderedVehicles();

                        var cont = AdminContinue();
                        return cont == false ? "3" : "2";
                    }
                    case "5":
                    {
                        Console.WriteLine("What file name would you like to save the report to? (E.g. filename.txt)");
                        var userResponse = Console.ReadLine();
                        _controller.GenerateReport(userResponse);

                        var cont = AdminContinue();
                        return cont == false ? "3" : "5";
                    }
                }
            }
            return adminChoice == "6" ? "1" : "3";
        }
    }
}