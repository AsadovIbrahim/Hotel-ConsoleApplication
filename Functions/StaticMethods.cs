using Hotel_Application.Exceptions;
using Hotel_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Application.Functions
{
    public static class StaticMethods
    {
        public static List<Hotel> Hotels { get; set; } = new List<Hotel>();

        public static void LoginMenu()
        {
            while (true)
            {
                Console.WriteLine("1.Create Hotel");
                Console.WriteLine("2.Show All Hotels");
                Console.WriteLine("3.Select Hotel");
                Console.WriteLine("4.Exit");

                int select = Convert.ToInt32(Console.ReadLine());
                switch (select)
                {
                    case 1:
                        CreateHotel();
                        break;
                    case 2:
                        ShowAllHotels();
                        break;
                    case 3:
                        SelectHotel();
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Wrong Input");
                        break;
                }
            }
        }

        public static void CreateHotel()
        {
            Console.Write("Enter Hotel Name:");
            string name = Console.ReadLine()!;
            if (Hotels.Exists(h => h.Name == name))
            {
                Console.WriteLine("This Hotel Is Exists!");
                return;
            }

            Hotel hotel = new Hotel { Name = name };
            Hotels.Add(hotel);
            Console.WriteLine($"Hotel {name} is created successfully...");
        }

        public static void ShowAllHotels()
        {
            if (Hotels.Count == 0)
            {
                Console.WriteLine("Empty!");
                return;
            }

            Console.WriteLine("All Hotels:");
            foreach (var item in Hotels)
            {
                Console.WriteLine(item.ShowInfo());
            }
        }

        public static void SelectHotel()
        {
            Console.Write("Enter Hotel Name:");
            string name = Console.ReadLine()!;
            var selectedHotel = Hotels.FirstOrDefault(n => n.Name == name);
            if (selectedHotel == null)
            {
                Console.WriteLine("Don't Found This Hotel Name");
                return;
            }

            HotelMenu(selectedHotel);
        }

        public static void HotelMenu(Hotel hotel)
        {
            Console.WriteLine($"******{hotel.Name}******");
            Console.WriteLine("1.Create Room");
            Console.WriteLine("2.Show All Rooms");
            Console.WriteLine("3.Make Reservation");
            Console.WriteLine("4.Back");
            Console.WriteLine("5.Exit");

            Console.Write("Enter:");
            int input = Convert.ToInt32(Console.ReadLine());

            switch (input)
            {
                case 1:
                    CreateRoom(hotel);
                    break;
                case 2:
                    ShowAllRooms(hotel);
                    break;
                case 3:
                    MakeReservation(hotel);
                    break;
                case 4:
                    return;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Wrong Input");
                    break;
            }
        }

        public static void CreateRoom(Hotel hotel)
        {
            Console.Write("Enter Room Name:");
            string name = Console.ReadLine()!;
            Console.Write("Enter Room Price:");
            double price = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter Room Capacity:");
            int capacity = Convert.ToInt32(Console.ReadLine());
            Room room = new Room(name, price, capacity);
            hotel.AddRoom(room);
            Console.WriteLine($"Room Created Successfully...");
        }

        public static void ShowAllRooms(Hotel hotel)
        {
            if (hotel.Rooms.Count == 0)
            {
                Console.WriteLine("Empty!");
                return;
            }

            Console.WriteLine($"All Rooms in {hotel.Name}:");
            foreach (var room in hotel.Rooms)
            {
                Console.WriteLine(room.ShowInfo());
            }
        }

        public static void MakeReservation(Hotel hotel)
        {
            Console.Write("Enter Room Id:");
            int roomId = Convert.ToInt32(Console.ReadLine()!);
            Console.Write("Enter Guest Count:");
            int guestCount = Convert.ToInt32(Console.ReadLine()!);

            try
            {
                hotel.MakeReservation(roomId, guestCount);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (NotAvailableException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void PressAnyKey()
        {
            Console.WriteLine("Press Any Key...");
            Console.ReadKey();
        }
    }
}
