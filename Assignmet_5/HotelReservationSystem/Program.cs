namespace HotelReservationSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== Hotel Reservation System =====");

            try
            {
                Guest guest1 = new Guest(Guid.NewGuid(), "Wael", "01000000000");
                Console.WriteLine($"[Guest Registered] Name: {guest1.FullName}");

                Room room101 = new Room(101, RoomType.Single, 150.0m);
                Room room102 = new Room(102, RoomType.Suite, 500.0m);

                DateTime checkIn = DateTime.Now.AddDays(1);
                DateTime checkOut = DateTime.Now.AddDays(3);
                Reservation res1 = new Reservation(Guid.NewGuid(), checkIn, checkOut, room101);
                guest1.AddReservation(res1);

                Console.WriteLine($"\n[Reservation Created] Status: {res1.Status}");
                Console.WriteLine($"Total Cost ({(checkOut - checkIn).Days} nights): {res1.TotalCost:C}");

                res1.Confirm();
                Console.WriteLine($"Status after Confirm: {res1.Status}");

                res1.CheckIn();
                Console.WriteLine($"Status after CheckIn: {res1.Status}");

                res1.CheckOut();
                Console.WriteLine($"Status after CheckOut: {res1.Status}");

                Console.WriteLine("\n------------------------------------------------");
                Console.WriteLine("=== Testing Validation Exceptions ===");

                room102.StartMaintenance();
                Console.WriteLine($"\nRoom 102 Maintenance Status: {room102.IsUnderMaintenance}");

                Console.WriteLine("Attempting to book Room 102 while under maintenance...");
                Reservation res2 = new Reservation(Guid.NewGuid(), checkIn, checkOut, room102);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}