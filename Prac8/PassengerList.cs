using Prac_8;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prac8
{
    internal class PassengerList
    {
        ArrayList List;
        string filename;
        bool sorted=false;
        int SortedState;
        public PassengerList(string File)
        {
            filename = File;
            List = new ArrayList();
            ReadData();
        }
        private void Close()
        {
            WriteData();
        }
        public void Add(Passenger newpassenger)
        {
            List.Add(newpassenger);
            SortedState = 0;
        }
        private int  Count()
        {
            return List.Count;
        }
        public void Display()
        {
            foreach (Passenger currentPassenger in List)
            {
                currentPassenger.DisplayPassengerDetails();
            }
        }
        public void DisplayPassengersByRoute(string wantedRoute)
        {
            bool found = false;
            for (int i = 0; i < List.Count; i++)
            {
                Passenger cur = (Passenger)List[i];

                // If the current passenger's route matches the wanted route
                if (cur.GetRoute().Equals(wantedRoute))
                {
                    cur.DisplayPassengerDetails();
                    found = true;
                }
            }

            // If no passengers were found for the route, display a message
            if (!found)
            {
                Console.WriteLine($"No passengers found for the route: {wantedRoute}");
            }
        }

        public void Delete(int pos)
        {
            List.RemoveAt(pos-1);
        }
        public int FindPassenger(string wanted)
        {
            if (SortedState == 3)

                return BinarySearchPassenger(wanted) + 1;
            else
               return LinearSearch(wanted) + 1;
            
        }
        public int FindRoute(String Wanted)
        {
            if (SortedState == 3)
                return BinarySearchRoute(Wanted) + 1;
            else
                return LinearSearch(Wanted) + 1;
        }

        public void SortPassengerDown()
        {
            BubbleSort();
            SortedState = 1;


        }
        public void SortedPassengerUp()
        {
            SelectionSort();
            SortedState = 2;
        }
        public void SortNameUp()
        {
            InsertionSort();
            SortedState= 3;
        }
        public void SortNameDown()
        {
            SelectionSort();
                SortedState = 4;
        }


        private void SelectionSort()
        {
            for(int pass = 1; pass <= List.Count - 1; pass++)
            {
                int minPos = 0;
                for(int x=1;x<=List.Count - pass; x++)
                
                    if (((Passenger)List[x]).GetPassengerNumber() > ((Passenger)List[minPos]).GetPassengerNumber())
                        minPos = x;
                swop(Count() - pass,minPos);
                
            }

        }
        public void BubbleSort()
        {
            for(int pass = 1;pass<= List.Count - 1; pass++)
            {
                for(int compare=1;compare<=List.Count - pass; compare++)
                {
                    Passenger first = (Passenger)List[compare-1];
                    Passenger second = (Passenger)List[compare];
                    if(first.GetPassengerNumber()<second.GetPassengerNumber())
                        swop(compare-1,compare-1);
                }
            }
        }
        public void InsertionSort()
        {
            for(int x=1;x<=List.Count - 1; x++)
            {
                Passenger newpassenger = (Passenger)List[x];
                List.RemoveAt(x);
                Insert(newpassenger,x-1);
            }
        }
        public void Insert(Passenger newpassenger,int Last)
        {
            int currentPos = Last;
            Passenger currentPassenger = (Passenger)List[currentPos];
            while ((currentPos != -1) && (newpassenger.GetSurname().CompareTo(currentPassenger.GetSurname()) < 0))
            {
                currentPos--;
                if(currentPos!=1)currentPassenger = (Passenger)List[currentPos];
            }
            List.Insert(currentPos+1, newpassenger);
        }
        private int LinearSearch(string wanted)
        {
            for(int x=0;x<=List.Count ;x++)
            {
                Passenger currentPassenger= (Passenger)List[x];
                if(wanted.Equals(currentPassenger.GetSurname()))
                    return x;
            }
            return -1;
        }
        public int BinarySearchPassenger(string wanted)
        {
            int first = 0;int last = List.Count-1;
            while(first<=last)
            {
                int mid=(first+last)/2;
                Passenger currentpassenger= (Passenger)List[mid];
                if (wanted.Equals(currentpassenger.GetSurname())) return mid;
                else if (wanted.CompareTo(currentpassenger.GetPassengerNumber()) < 0) last = mid - 1;
                else
                    first = mid + 1;
            }
            return -1;
        }
        public int BinarySearchRoute(string wanted)
        {
            int first = 0; int last = List.Count - 1;
            while (first <= last)
            {
                int mid = (first + last) / 2;
                Passenger currentpassenger = (Passenger)List[mid];
                if (wanted.Equals(currentpassenger.GetRoute())) return mid;
                else if (wanted.CompareTo(currentpassenger.GetRoute()) < 0) last = mid - 1;
                else
                    first = mid + 1;
            }
            return -1;
        }
        public void ReadData()
        {
            const char DeLim = ',';
            StreamReader sr=new StreamReader(filename);
            string surname, initials, route, date, status;
            int Passengernum;
            double ticketAmount;
            string[] fields;
            string dataLine=sr.ReadLine();
            while(dataLine != null)
            {
                fields = dataLine.Split(DeLim);
                Passengernum = int.Parse(fields[0]);
                surname = fields[1];
                initials = fields[2];
                route = fields[3];
                date = fields[4];
                ticketAmount = double.Parse(fields[5]);
                status = fields[6];
                
                Passenger newpassenger=new Passenger(Passengernum, surname,initials,route,date,ticketAmount,status);    
                List.Add(newpassenger);
                dataLine = sr.ReadLine();

            }
            sr.Close();
        }
        public  Passenger Get(int pos)
        {
            pos--;
            if((pos>=0) &&(pos<=List.Count-1))
                return (Passenger)List[pos];
            else return null;
        }
        public void WriteData()
        {
            StreamWriter sw = new StreamWriter("OutputPassengerData.txt");
            for(int x=0;x<List.Count;x++)
            {
                Passenger tempPassenger = (Passenger)List[x];
                sw.Write(tempPassenger.GetPassengerNumber() + ",");
                sw.Write(tempPassenger.GetSurname()+",");
                sw.Write(tempPassenger.GetInitials() + ",");
                sw.Write(tempPassenger.GetRoute() + ",");
                sw.Write(tempPassenger.GetDate() + ",");
                sw.Write(tempPassenger.GetTicketAmount() + ",");
                sw.Write(tempPassenger.GetStatus() + ",");

            }
            sw.Close();
        }
        public void swop(int x,int y)
        {
            object temp = List[x];
            List[x] = List[y];
            List[y] = temp;
        }



    }
   
}

