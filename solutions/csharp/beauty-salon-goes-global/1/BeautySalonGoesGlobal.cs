using System.Runtime.InteropServices;
using System.Globalization;

public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}

public static class Appointment
{
    public static DateTime ShowLocalTime(DateTime dtUtc) =>  dtUtc.ToLocalTime();

    private static readonly Dictionary<Location, (string, string)> LocationTimeZones = new()
    {
        { Location.NewYork, ("Eastern Standard Time", "America/New_York") },
        { Location.London,  ("GMT Standard Time", "Europe/London") },
        { Location.Paris,   ("W. Europe Standard Time", "Europe/Paris") }
    };
    private static readonly Dictionary<Location, string> LocationCultures = new()
    {
        { Location.NewYork, "en-US"},
        { Location.London,  "en-GB"},
        { Location.Paris,   "fr-FR" }
    };
    private static TimeZoneInfo FindLocalTimeZone(Location location){
        if (!LocationTimeZones.TryGetValue(location, out (string WindowsId, string IanaId) timeZoneIds))
        {
            throw new ArgumentException("The specified location is not supported.", nameof(location));
        }

        string timeZoneId = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
            ? timeZoneIds.WindowsId
            : timeZoneIds.IanaId;
        return TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
    }
    public static DateTime Schedule(string appointmentDateDescription, Location location)
    {
        TimeZoneInfo localTimeZone = FindLocalTimeZone(location);
        DateTime localTime = DateTime.ParseExact(
            appointmentDateDescription, 
            "M/d/yyyy HH:mm:ss",
            CultureInfo.InvariantCulture);
        return TimeZoneInfo.ConvertTimeToUtc(localTime, localTimeZone);
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel)
    {
        switch (alertLevel){
            case AlertLevel.Early:
                return appointment.AddDays(-1);
            case AlertLevel.Standard:
                return appointment.AddHours(-1.75);
            case AlertLevel.Late:
                return appointment.AddMinutes(-30);
        }
        return appointment;
    }

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        TimeZoneInfo localTimeZone = FindLocalTimeZone(location);
        return localTimeZone.IsDaylightSavingTime(dt) ^ localTimeZone.IsDaylightSavingTime(dt.AddDays(-7));
    }

     public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
         if(!LocationCultures.TryGetValue(location, out string cultureName)){
            throw new ArgumentException("The specified location is not supported.", nameof(location));
         }
        CultureInfo culture = new CultureInfo(cultureName);
        
        if (DateTime.TryParse(dtStr, culture, DateTimeStyles.None, out DateTime result))
        {
            return result;
        }
        else
        {
            // Return 1/1/1 for any parsing failures
            return new DateTime(1, 1, 1);
        }
    }
}
