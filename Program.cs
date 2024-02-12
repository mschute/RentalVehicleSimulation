namespace VehicleRental
{
    //TODO Need to recreate this whole file and remove the VehicleRental.Console
    class Program
    {
        static void Main(string[] args)
        {
            var controller = new WestminsterRentalVehicle();
            var menu = new TextMenu(controller);
            
            menu.MainMenu();
        }
    }
}