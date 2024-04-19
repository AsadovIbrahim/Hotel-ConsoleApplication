using Hotel_Application.Models;
using static Hotel_Application.Functions.StaticMethods;

namespace Hotel_Application
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\t\t****MENU*****");
                Console.WriteLine("1.Enter System");
                Console.WriteLine("0.Exit");

                Console.Write("Choose:");
                int input = Convert.ToInt32(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        LoginMenu();
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Wrong Input");
                        break;
                }
            }
        }
    }
}

