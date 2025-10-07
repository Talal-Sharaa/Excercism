using System;
using System.Collections.Generic;
using System.Linq;

public enum Schedule
{
    Teenth,
    First,
    Second,
    Third,
    Fourth,
    Last
}

public class CalendarDay
{
    public DateTime Date { get; set; }
    public string DayName => Date.DayOfWeek.ToString();
    public int DayNumber => Date.Day;
}

public class Meetup
{
    private readonly IEnumerable<CalendarDay> _Calendar;

    public Meetup(int month, int year)
    {
        int daysInMonth = DateTime.DaysInMonth(year, month);
        _Calendar = Enumerable.Range(1, daysInMonth)
            .Select(day => new CalendarDay
            {
                Date = new DateTime(year, month, day)
            });
    }

    public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule)
    {
        List<CalendarDay> xCertainDays = _Calendar
            .Where(d => d.Date.DayOfWeek == dayOfWeek)
            .ToList();

        switch (schedule)
        {
            case Schedule.First:
                return xCertainDays[0].Date;
            case Schedule.Second:
                return xCertainDays[1].Date;
            case Schedule.Third:
                return xCertainDays[2].Date;
            case Schedule.Fourth:
                return xCertainDays[3].Date;
            case Schedule.Last:
                return xCertainDays[^1].Date; // ^1 = last element
            case Schedule.Teenth:
                return xCertainDays.First(d => d.DayNumber >= 13 && d.DayNumber <= 19).Date;
            default:
                throw new ArgumentException("Invalid schedule");
        }
    }
}
