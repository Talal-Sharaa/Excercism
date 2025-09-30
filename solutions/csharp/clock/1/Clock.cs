public class Clock
{
    private int _Hours;
    private int _Minutes;

    public Clock(int hours, int minutes)
    {
        int totalMinutes = hours * 60 + minutes;
        totalMinutes = ((totalMinutes % (24 * 60)) + (24 * 60)) % (24 * 60);

        _Hours = totalMinutes / 60;
        _Minutes = totalMinutes % 60;
    }

    public Clock Add(int minutesToAdd)
    {
        int totalMinutes = _Hours * 60 + _Minutes + minutesToAdd;
        totalMinutes = ((totalMinutes % (24 * 60)) + (24 * 60)) % (24 * 60);

        _Hours = totalMinutes / 60;
        _Minutes = totalMinutes % 60;

        return this;
    }

    public Clock Subtract(int minutesToSubtract)
    {
        return Add(-minutesToSubtract);
    }

    public override string ToString()
    {
        return $"{_Hours:D2}:{_Minutes:D2}";
    }

    public override bool Equals(object obj)
    {
        if (obj is Clock other)
        {
            return _Hours == other._Hours && _Minutes == other._Minutes;
        }
        return false;
    }
}
