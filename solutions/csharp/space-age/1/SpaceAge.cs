public class SpaceAge
{
    private int _SecondsLived = 0;
    public SpaceAge(int seconds)
    {
        _SecondsLived = seconds;
    }

    public double OnEarth() => (double)_SecondsLived/(double)31557600;

    public double OnMercury() => OnEarth()/0.2408467;

    public double OnVenus()  => OnEarth()/0.61519726;

    public double OnMars() => OnEarth()/1.8808158;

    public double OnJupiter() => OnEarth()/11.862615;

    public double OnSaturn() => OnEarth()/29.447498;

    public double OnUranus() => OnEarth()/84.016846;

    public double OnNeptune() => OnEarth()/164.79132;
}