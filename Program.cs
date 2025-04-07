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
                        SearchReserve();
                        break;
                    case 5:
                        Findhighest();
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
                    if (RoomCounter >= MAX_ROOMS)
                    {
                        Console.WriteLine("no more rooms!");
                        return;

                    }
                    Console.WriteLine("Enter room Numbers:");
                    int RoomNumber = int.Parse(Console.ReadLine());

                    for (int i = 0; i < RoomCounter; i++)
                    {
                        if (RoomNum[i] == RoomNumber)
                        {

                            Console.WriteLine(" Please enter a unique room number.");

                            return;
                        }
                    }

                    RoomNum[RoomCounter] = RoomNumber;
                    Console.WriteLine("Enter daily rate:");
                    double dailyRate = double.Parse(Console.ReadLine());

                    if (dailyRate < 100)
                    {
                        Console.WriteLine("Daily rate must be at least 100.");
                        return;
                    }
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
            for (int i = 0; i < RoomCounter; i++)
            {

                string status = Reserved[i] ? "Reserved" : "Available";
               
                string guestName = Reserved[i] ? guestNames[i] : "N/A";
                double totalCost = Reserved[i] ? Rate[i] * nights[i] : 0;

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

                    for (int i = 0;i < RoomCounter; i++)
                    {
                    if (RoomNum[i] == roomNumber)
                      {
                        roomIndex = i;
                        break;
                      }
                         if(roomIndex == -1)
                        {
                             Console.WriteLine("Room does not exist.");
                             return;


                }

            }
          

            


        }
        static void SearchReserve()
                {

                }
                static void Findhighest()
                {

                }
                static void CancelReser()
                {

                }


            }

        }
   

