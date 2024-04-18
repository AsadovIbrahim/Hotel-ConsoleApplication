using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Application.Models
{
    public class Room
    {
        private static int _Id;
        public int Id;
        public string? Name { get; set; }
        public double Price { get; set; }
        public int PersonCapacity { get; }
        public bool IsAvailable { get; set; }

        public Room(string? name, double price, int personCapacity)
        {
            Id = ++_Id;
            Name = name;
            Price = price;
            PersonCapacity = personCapacity;
            IsAvailable = true;
        }

        public string ShowInfo()
        {
            return ($"Id:{Id}\nName:{Name}\nPrice:{Price}\nPersonCapacity:{PersonCapacity}\n" +
                $"Availablity:{(IsAvailable ? "Available" : "Not Available")}");
        }

        public override string ToString()
        {
            return ShowInfo();
        }
    }
}
