namespace TimeZoneOverview.Models
{
    internal class TimeZoneListEntry
    {
        public string TimeZoneStandardName;
        public string TimeZoneBaseUtcOffset;

        public TimeZoneListEntry(string timeZoneStandardName, string timeZoneBaseUtcOffset)
        {
            TimeZoneStandardName = timeZoneStandardName;
            TimeZoneBaseUtcOffset = timeZoneBaseUtcOffset;
        }

        public override string ToString()
        { 
            return TimeZoneStandardName + "\t" + TimeZoneBaseUtcOffset;
        }
    }
}
