using System;

namespace Prac_8
{
    internal class Passenger
    {
        private int passengerNumber;
        private string surname;
        private string initials;
        private string route;
        private string date;
        private double ticketAmount;
        private string status;

        public Passenger(int passengerNumber, string surname, string initials, string route, string date, double ticketAmount, string status)
        {
            this.passengerNumber = passengerNumber;
            this.surname = surname;
            this.initials = initials;
            this.route = route;
            this.date = date;
            this.ticketAmount = ticketAmount;
            this.status = status;
        }

        public int GetPassengerNumber()
        {
            return passengerNumber;
        }
        public void SetPassengerNumber(int value)
        {
            passengerNumber = value;
        }

        public string GetSurname()
        {
            return surname;
        }
        public void SetSurname(string value)
        {
            surname = value;
        }

        public string GetInitials()
        {
            return initials;
        }
        public void SetInitials(string value)
        {
            initials = value;
        }

        public string GetRoute()
        {
            return route;
        }
        public void SetRoute(string value)
        {
            route = value;
        }

        public string GetDate()
        {
            return date;
        }
        public void SetDate(string value)
        {
            date = value;
        }

        public double GetTicketAmount()
        {
            return ticketAmount;
        }
        public void SetTicketAmount(double value)
        {
            ticketAmount = value;
        }

        public string GetStatus()
        {
            return status;
        }
        public void SetStatus(string value)
        {
            status = value;
        }
        public  void DisplayPassengerDetails()
        {
            Console.WriteLine("Passenger number :{0}", passengerNumber);
            Console.WriteLine("Surname:{0}", surname);
            Console.WriteLine("Initials :{0}", initials);
            Console.WriteLine("Route    :{0}", route);
            Console.WriteLine("Date     :{0}", date);
            Console.WriteLine("Ticket Amount :{0:C}", ticketAmount);
            Console.WriteLine("Status      :{0}", status);
            Console.WriteLine();
        }
    }
}



