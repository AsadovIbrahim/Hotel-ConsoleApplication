using System;
using System.Collections.Generic;
using Hotel_Application.Exceptions;

namespace Hotel_Application.Models
{
    public class Hotel
    {
        private static int _Id;
        public int Id { get; set; }
        public List<Room> Rooms { get; set; } = new();
        public string? Name { get; set; }

        public void AddRoom(Room room)
        {
            Rooms.Add(room);
        }

        public void MakeReservation(int? roomId, int guestCount)
        {
            if (roomId == null)
            {
                throw new NullReferenceException("Room ID cannot be null.");
            }

            Room room = Rooms.Find(r => r.Id == roomId)!;
            if (room == null)
            {
                throw new ArgumentException("Room with the provided ID does not exist.");
            }

            if (!room.IsAvailable)
            {
                throw new NotAvailableException("Room is not available for reservation.");
            }

            if (guestCount > room.PersonCapacity)
            {
                throw new ArgumentException("Guest count exceeds room capacity.");
            }

            room.IsAvailable = false;
            Console.WriteLine($"Reservation made for Room {room.Id}.");
        }

        public string ShowInfo()
        {
            return $"Id:{Id}\nHotel Name:{Name}";
        }

        public override string ToString()
        {
            return ShowInfo();
        }

        public Hotel()
        {
            Id = ++_Id;
        }
    }
}
