public struct Coord
{
    public Coord(ushort x, ushort y)
    {
        X = x;
        Y = y;
    }

    public ushort X { get; }
    public ushort Y { get; }
    public static bool operator==(Coord A, Coord B) => (A.X == B.X && A.Y == B.Y);
    public static bool operator!=(Coord A, Coord B) => !(A.X == B.X && A.Y == B.Y);
}

public struct Plot
{
    public Coord x = new Coord();
    public Coord y = new Coord();
    public Coord z = new Coord();
    public Coord k = new Coord();
    public Plot(Coord A, Coord B, Coord C, Coord D){
        x = A;
        y = B;
        z = C;
        k = D;
    }
    public static bool operator==(Plot A, Plot B) => (A.x == B.x && A.y == B.y && A.z == B.z && A.k == B.k);
    public static bool operator!=(Plot A, Plot B) => !(A.x == B.x && A.y == B.y && A.z == B.z && A.k == B.k);

}


public class ClaimsHandler
{
    List<Plot> xLstStakesClaimed = new List<Plot>();
    public void StakeClaim(Plot plot)
    {
        xLstStakesClaimed.Add(plot);
    }

    public bool IsClaimStaked(Plot plot) => xLstStakesClaimed.Contains(plot);

    public bool IsLastClaim(Plot plot) => xLstStakesClaimed.LastOrDefault() == plot;

      public Plot GetClaimWithLongestSide()
    {
        Plot plotWithLongestSide = xLstStakesClaimed[0];
        double maxSideLength = GetLongestSideLength(plotWithLongestSide);
        
        for (int i = 1; i < xLstStakesClaimed.Count; i++)
        {
            double currentMaxSide = GetLongestSideLength(xLstStakesClaimed[i]);
            if (currentMaxSide > maxSideLength)
            {
                maxSideLength = currentMaxSide;
                plotWithLongestSide = xLstStakesClaimed[i];
            }
        }
        
        return plotWithLongestSide;
    }
    
    private double GetLongestSideLength(Plot plot)
    {
        double[] sideLengths = new double[4];
        
        sideLengths[0] = GetDistance(plot.x, plot.y);
        sideLengths[1] = GetDistance(plot.y, plot.z);
        sideLengths[2] = GetDistance(plot.z, plot.k);
        sideLengths[3] = GetDistance(plot.k, plot.x);
        
        return sideLengths.Max();
    }
    
    private double GetDistance(Coord a, Coord b)
    {
        int dx = a.X - b.X;
        int dy = a.Y - b.Y;
        return Math.Sqrt(dx * dx + dy * dy);
    }
}
