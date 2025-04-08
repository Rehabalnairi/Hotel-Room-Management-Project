using System.Xml.Linq;

namespace Hotel_Room_Management_Project
{
    internal class Program
    {
        const int MAX_ROOMS = 14;
        static int[] RoomNum = new int[MAX_ROOMS];
        static double[] Rate = new double[MAX_ROOMS];
        static string[] guestNames = new string[MAX_ROOMS];
        static bool[] Reserved = new bool[MAX_ROOMS];
        static int[] nights = new int[MAX_ROOMS];
        static DateTime[] dates = new DateTime[MAX_ROOMS];
        static int RoomCounter = 0;

        //declare array and varbiles 
        static void Main(string[] args)
        {
            while (true) //switch statment inside while statment for create mune 
            {
                Console.Clear();
                Console.WriteLine("1.Add a new room");
                Console.WriteLine("2. View all rooms .  ");
                Console.WriteLine("3.Reserve a room for a guest");
                Console.WriteLine("4.View all reservations with total cost ");
                Console.WriteLine("5.Search reservation by guest name (case-insensitive) ");
                Console.WriteLine("6Find the highest-paying guest");
                Console.WriteLine("7.Cancel a reservation by room number");
                Console.WriteLine("0.Exit");
                Console.Write("Enter your choice: ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        addRoom();
                        break;

                    case 2:
                        view();
                        break;
                    case 3:
                        ReserveRoom();
                        break;
                    case 4:
                        viewReserve();
                        break;
                    case 5:
                        SearchReserve();
                        break;
                    case 6:
                        Findhighest();
                        break;
                    case 7:
                        CancelReser();
                        break;

                    case 0: return;
                    default:
                        Console.WriteLine("Invalid choice! Try again.");
                        break;
                }

                Console.ReadLine();


                static void addRoom()
                {
                    if (RoomCounter >= MAX_ROOMS) //if statment for check if there rooms 

                    {
                        Console.WriteLine("no more rooms!");
                        return;

                    }
                    Console.WriteLine("Enter room Numbers:");
                    int RoomNumber = int.Parse(Console.ReadLine()); //create new int fore store numbers of room

                    for (int i = 0; i < RoomCounter; i++) //loop for check if there any recored save 
                    {
                        if (RoomNum[i] == RoomNumber)// if funaction to chcek if the user add unique room number
                        {

                            Console.WriteLine(" Please enter a unique room number.");

                            return;
                        }
                    }
                    //store new room number
                    RoomNum[RoomCounter] = RoomNumber;
                    Console.WriteLine("Enter daily rate:");
                    double dailyRate = double.Parse(Console.ReadLine());

                    if (dailyRate < 100) //Rate must be >= 100
                    {
                        Console.WriteLine("Daily rate must be at least 100.");
                        return;
                    }
                    //save all data in array and print it
                    RoomNum[RoomCounter] = RoomNumber;
                    Rate[RoomCounter] = dailyRate;
                    Reserved[RoomCounter] = false;
                    RoomCounter++;
                    Console.WriteLine("Room added successfully!!!");
                }


            }
        }
        static void view()
        {
            Console.WriteLine("Room Number\tDaily Rate\tStatus");
            for (int i = 0; i < RoomCounter; i++) //loop for check if there any recored 
            {

                string status = Reserved[i] ? "Reserved" : "Available"; //use Ternary oprator to check if room Reserved or no 


                string guestName = Reserved[i] ? guestNames[i] : "N/A";// if yes Print guestNames
                double totalCost = Reserved[i] ? Rate[i] * nights[i] : 0; // if no show total cost 

                Console.WriteLine($"{RoomNum[i]}\t\t{Rate[i]}\t\t{status}\t\t{guestName}\t\t{totalCost}");

            }
        }
        static void ReserveRoom()
        {
            Console.WriteLine("Enter Guest name ");
            string guestName = Console.ReadLine();
            Console.WriteLine("Enter room number: ");
            int roomNumber = int.Parse(Console.ReadLine());
            int roomIndex = -1;

            for (int i = 0; i < RoomCounter; i++)
            {
                if (RoomNum[i] == roomNumber)
                {
                    roomIndex = i;
                    break;
                }
                if (roomIndex == -1)
                {
                    Console.WriteLine("Room does not exist.");
                    return;
                }
                Console.WriteLine("Enter Number of nighet ");
                int Numnights = int.Parse(Console.ReadLine());
                if (Numnights <= 0)
                {
                    Console.WriteLine("Number of Nights Musct be grater than 0");
                }
                //reserve Room
                guestNames[roomIndex] = guestName;
                nights[roomIndex] = Numnights;
                dates[roomIndex] = DateTime.Now;
                Reserved[roomIndex] = true;
                Console.WriteLine("Room reserved successfully.");


            }

        }
        static void viewReserve()
        {
            Console.WriteLine("guest name,\troom Numbers\tnights\trate\tcost");
            for (int i = 0; i < RoomCounter; i++)
            {
                if (Reserved[i])
                {
                    double TotalCOst = Rate[i] * nights[i];
                    Console.WriteLine($"{guestNames[i]}\t{RoomNum[i]}\t{nights[i]}\t{Rate[i]}\t{TotalCOst}");
                }

            }

        }

        static void SearchReserve()
        {
            {
                Console.Write("Enter guest name to search: ");
                string searchName = Console.ReadLine().ToLower(); // convert the string input to lower case
                bool found = false;

                for (int i = 0; i < RoomCounter; i++)
                {
                    // check if the room is reserved (true) and the guest name is equal to the search name
                    if (Reserved[i] && guestNames[i].ToLower() == searchName)
                    {

                        Console.WriteLine("Room Number : " + RoomNum[i]);
                        Console.WriteLine("Guest Name : " + guestNames[i]);
                        Console.WriteLine("Nights : " + nights[i]);
                        Console.WriteLine("Booking Dates : " + dates[i]);
                        Console.WriteLine("Total Cost : " + (Rate[i] * nights[i]));
                        Console.WriteLine("Room Rate : " + Rate[i]);
                        Console.WriteLine("Room Statuse : Reserved");

                        found = true;
                        break;
                    }
                }

                if (!found)
                    Console.WriteLine("Reservation not found.");
            }

        }
        static void Findhighest()
        {

            double maxCost = 0;
            int maxIndex = -1; // initialize maxIndex variable to -1 --> (-1 is a flag value to mean "No reservation found")

            for (int i = 0; i < RoomCounter; i++)

            {
                // check if the room is reserved (true).
                if (Reserved[i])
                {
                    double totalCost = Rate[i] * nights[i];
                    if (totalCost > maxCost)
                    {

                        maxCost = totalCost; // set maxCost to totalCost
                        maxIndex = i; // set maxIndex to i
                    }
                }
            }

            if (maxIndex != -1)
            {

                Console.WriteLine("Highest Paying Guest: " + guestNames[maxIndex]); // show the guest name has the highest total cost
                Console.WriteLine("Total Amount = " + maxCost); // show the total cost of the highest paying guest


            }
            else
            {
                Console.WriteLine("No reservations found.");
            }
        }


        static void CancelReser()
        {
            {
                //ask and read the room number
                Console.Write("Enter room number to cancel reservation: ");
                int roomNumber = int.Parse(Console.ReadLine());

                for (int i = 0; i < RoomCounter; i++)
                {
                    if (RoomNum[i] == roomNumber)
                    {
                        // check if the room is reserved (true)
                        if (Reserved[i])
                        {
                            Reserved[i] = false; // set the room as not reserved
                            guestNames[i] = "";
                            nights[i] = 0;
                            Console.WriteLine("Reservation cancelled.");
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Room is not reserved.");
                            return;
                        }
                    }
                }

                Console.WriteLine("Room not found.");
            }

        }


    }

}
   

