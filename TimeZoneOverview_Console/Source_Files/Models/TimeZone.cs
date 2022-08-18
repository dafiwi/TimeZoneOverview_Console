namespace TimeZoneOverview.Models
{
    internal class TimeZone
    {
        public string TimeZoneName;
        public string TimeZoneTime;

        public TimeZone(string timeZoneName, string timeZoneTime)
        {
            TimeZoneName = timeZoneName;
            TimeZoneTime = timeZoneTime;
        }
    }
}