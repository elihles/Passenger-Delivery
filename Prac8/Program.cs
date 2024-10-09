using Prac_8;
using System;
using System.Collections;

namespace Prac8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PassengerList passengerList = new PassengerList("PassengerData.txt");

            int choice = DisplayOptions();
            do
            {
                switch (choice)
                {
                    case 1:
                        AddPassenger(passengerList);
                        break;
                    case 2:
                        DeletePassenger(passengerList);
                        break;
                    case 3:
                        passengerList.Display();
                        break;
                    case 4:
                        DisplayPassengerNumber(passengerList);
                        break;
                    case 5:
                        DisplayPassengersByRoute(passengerList);
                        break;
                    case 6:
                        passengerList.SortedPassengerUp();
                        Console.WriteLine("Passengers sorted in ascending order by number.");
                        passengerList.Display();

                        break;
                    case 7:
                        passengerList.SortPassengerDown();
                        Console.WriteLine("Passengers sorted in descending order by number.");
                        passengerList.Display();
                        break;
                    case 8:
                        passengerList.SortNameUp();
                        Console.WriteLine("Passengers sorted in ascending order by surname.");
                        passengerList.Display();
                        break;
                    case 9:
                        passengerList.SortNameDown(); // Ensure you have a method for sorting by surname descending
                        Console.WriteLine("Passengers sorted in descending order by surname.");
                        passengerList.Display();
                        break;
                    case 10:
                        passengerList.WriteData();
                        Console.WriteLine("Passenger data saved to file.");
                        break;
                    case 11:
                        Console.WriteLine("Exiting the program.");
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }

                Console.WriteLine(); // Blank line for readability
                choice = DisplayOptions(); // Re-display the options after each operation

            } while (choice != 11);
        }

        private static int DisplayOptions()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Add a new Passenger");
            Console.WriteLine("2. Delete a Passenger");
            Console.WriteLine("3. Display all Passengers");
            Console.WriteLine("4. Display Passenger by Number");
            Console.WriteLine("5. Display Passengers by Route");
            Console.WriteLine("6. Sort Passengers Ascending by Number");
            Console.WriteLine("7. Sort Passengers Descending by Number");
            Console.WriteLine("8. Sort Passengers Ascending by Surname");
            Console.WriteLine("9. Sort Passengers Descending by Surname");
            Console.WriteLine("10. Save Passengers to File");
            Console.WriteLine("11. Exit");

            Console.Write("Select an option: ");
            return int.Parse(Console.ReadLine());
        }

        private static void AddPassenger(PassengerList passengerList)
        {
            Console.Write("Enter passenger number: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Enter surname: ");
            string surname = Console.ReadLine();
            Console.Write("Enter initials: ");
            string initials = Console.ReadLine();
            Console.Write("Enter route: ");
            string route = Console.ReadLine();
            Console.Write("Enter date: ");
            string date = Console.ReadLine();
            Console.Write("Enter ticket amount: ");
            double ticketAmount = double.Parse(Console.ReadLine());
            Console.Write("Enter status: ");
            string status = Console.ReadLine();

            Passenger newPassenger = new Passenger(number, surname, initials, route, date, ticketAmount, status);
            passengerList.Add(newPassenger);
            Console.WriteLine("Passenger added successfully.");
        }

        private static void DeletePassenger(PassengerList passengerList)
        {
            Console.Write("Enter passenger number to delete: ");
            int number = int.Parse(Console.ReadLine());
            int pos = passengerList.FindPassenger(number.ToString());
            if (pos > 0)
            {
                passengerList.Delete(pos);
                Console.WriteLine("Passenger deleted successfully.");
            }
            else
            {
                Console.WriteLine("Passenger not found.");
            }
        }

        private static void DisplayPassengerNumber(PassengerList passengerList)
        {
            Console.Write("Enter passenger number: ");
            int number = int.Parse(Console.ReadLine());
            int pos = passengerList.FindPassenger(number.ToString());
            if (pos > 0)
            {
                Passenger passenger = passengerList.Get(pos);
                passenger.DisplayPassengerDetails();
            }
            else
            {
                Console.WriteLine("Passenger not found.");
            }
        }
       private static void DisplayPassengersByRoute(PassengerList passengerList)
{
    Console.Write("Enter your destination Route: ");
    string route = Console.ReadLine();

    // Call the DisplayPassengersByRoute method in PassengerList
    passengerList.DisplayPassengersByRoute(route);
}



    }
}
