namespace ticketing_system
{
    internal class Program
    {
        static void Main()
        {
            string filename = "tickets.csv";
            bool continueRunning = true;
            while (continueRunning)
            {
                continueRunning = DisplayMenu(filename);
            }
        }

        static bool DisplayMenu(string filename)
        {
            Console.WriteLine("1. Read data from file");
            Console.WriteLine("2. Create file from data");
            Console.WriteLine("3. Exit");
            Console.Write("Select an option: ");

            if (int.TryParse(Console.ReadLine(), out int option))
            {
                switch (option)
                {
                    case 1:
                        ReadDataFromFile(filename);
                        return true;
                    case 2:
                        CreateFileFromData(filename);
                        return true;
                    case 3:
                        return false;
                    default:
                        Console.WriteLine("Invalid option");
                        return true;
                }
            }
            else
            {
                Console.WriteLine("Invalid input");
                return true;
            }
        }

        static void ReadDataFromFile(string filename)
        {
            string[] lines = File.ReadAllLines(filename);
            for (int i = 1; i < lines.Length; i++)
            {
                Console.WriteLine(lines[i]);
            }
        }
        static void CreateFileFromData(string filename)
        {
            using (StreamWriter file = new StreamWriter(filename))
            {
                file.WriteLine("TicketID,Summary,Status,Priority,Submitter,Assigned,Watching");
                while (true)
                {
                    Console.Write("Enter TicketID (or 'done' to finish): ");
                    string ticketId = Console.ReadLine();
                    if (ticketId.ToLower() == "done")
                        break;
                    Console.Write("Enter Summary: ");
                    string summary = Console.ReadLine();
                    Console.Write("Enter Status: ");
                    string status = Console.ReadLine();
                    Console.Write("Enter Priority: ");
                    string priority = Console.ReadLine();
                    Console.Write("Enter Submitter: ");
                    string submitter = Console.ReadLine();
                    Console.Write("Enter Assigned: ");
                    string assigned = Console.ReadLine();
                    List<string> watching = new List<string>();
                    while (true)
                    {
                        Console.Write("Enter Watching name (or 'done' to finish): ");
                        string watcher = Console.ReadLine();
                        if (watcher.ToLower() == "done")
                            break;
                        watching.Add(watcher);
                    }
                    string watchingStr = string.Join("|", watching);
                    file.WriteLine($"{ticketId},{summary},{status},{priority},{submitter},{assigned},{watchingStr}");
                }

            }
        }
    }
}
