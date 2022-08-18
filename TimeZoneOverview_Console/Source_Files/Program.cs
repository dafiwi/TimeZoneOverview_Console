using TimeZoneOverview.Models;

namespace TimeZoneOverview
{
    internal class Program
    {
        public static List<TimeZoneListEntry> timeZoneListEntries;

        // Change the time zones for the predefined TimeZone objects manually here if you want to show other time zone info
        // A TimeZone object needs two parameters: "TIME ZONE NAME", local time in the string format (DateTime.ToShortTimeString)

        public static Models.TimeZone localTimeZone = new Models.TimeZone("Local Time", DateTime.Now.ToShortTimeString());
        public static Models.TimeZone timeZone1 = new Models.TimeZone("India Standard Time", TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time")).ToShortTimeString());
        public static Models.TimeZone timeZone2 = new Models.TimeZone("Universal Coordinated Time", DateTime.UtcNow.ToShortTimeString());
        
        static void Main(string[] args)
        {
            Console.WriteLine("Time Zone Overview\n");
            ShowTimeZoneInfo();

            Console.WriteLine("\nDo you want to list all time zones which are available in the system? y/n");
            char input = Console.ReadKey().KeyChar;
            if (input == 'y')
            {
                ListTimeZones();
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nPlease press any key to quit the program.");
            Console.ReadKey();
            Environment.Exit(0);
        }

        static void ShowTimeZoneInfo()
        {
            Console.WriteLine($"{localTimeZone.TimeZoneName}: {localTimeZone.TimeZoneTime} ({TimeZoneInfo.Local.StandardName})");
            Console.WriteLine($"{timeZone1.TimeZoneName}: {timeZone1.TimeZoneTime}");
            Console.WriteLine($"{timeZone2.TimeZoneName}: {timeZone2.TimeZoneTime}");
        }

        static void ListTimeZones()
        {
            timeZoneListEntries = new List<TimeZoneListEntry>();
            Console.WriteLine("\nList of all time zones in the system:\n");

            foreach (TimeZoneInfo timeZone in TimeZoneInfo.GetSystemTimeZones())
            {
                Console.WriteLine(timeZone.StandardName + "\tUTC Offset: " + timeZone.BaseUtcOffset);
                TimeZoneListEntry timeZoneListEntry = new TimeZoneListEntry(Convert.ToString(timeZone.StandardName), Convert.ToString(timeZone.BaseUtcOffset));
                timeZoneListEntries.Add(timeZoneListEntry);
            }
            Console.WriteLine($"\nThere are {timeZoneListEntries.Count} time zones in this list.");

            Console.WriteLine("\nDo you want to export this list as a text file? y/n");
            char input = Console.ReadKey().KeyChar;
            if (input == 'y')
            {
                ExportTimeZoneListAsTextFile();
            }
        }

        static void ExportTimeZoneListAsTextFile()
        {
            string fileName = @".\TimeZoneList";
            string fileType = ".txt";
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            using (StreamWriter file = new StreamWriter(filePath + fileName + fileType))
            {
                foreach (TimeZoneListEntry timeZoneListEntry in timeZoneListEntries)
                {
                    file.WriteLine(timeZoneListEntry);
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\nThe list of available time zones was exported to your desktop as a text file.");
        }
    }
}