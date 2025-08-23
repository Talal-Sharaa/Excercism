// TODO implement the IRemoteControlCar interface
public interface IRemoteControlCar{
    int DistanceTravelled { get;}
    void Drive();
    
}
public class ProductionRemoteControlCar:IRemoteControlCar, IComparable<ProductionRemoteControlCar>
{
    public int DistanceTravelled { get; private set; }
    public int NumberOfVictories { get; set; }

    public void Drive()
    {
        DistanceTravelled += 10;
    }
    public int CompareTo(ProductionRemoteControlCar other){
        if (other.NumberOfVictories == null)
            return 1;
        else
            return this.NumberOfVictories.CompareTo(other.NumberOfVictories);
    }
}

public class ExperimentalRemoteControlCar:IRemoteControlCar, IComparable<ExperimentalRemoteControlCar>
{
    public int DistanceTravelled { get; private set; }

    public void Drive()
    {
        DistanceTravelled += 20;
    }
    public int CompareTo(ExperimentalRemoteControlCar other){
        if (other.DistanceTravelled == null)
            return 1;
        else
            return this.DistanceTravelled.CompareTo(other.DistanceTravelled);
    }
}

public static class TestTrack
{
    public static void Race(IRemoteControlCar car)
    {
        car.Drive();
    }

    public static List<ProductionRemoteControlCar> GetRankedCars(ProductionRemoteControlCar prc1,
        ProductionRemoteControlCar prc2)
    {
        List<ProductionRemoteControlCar> rankings = new List<ProductionRemoteControlCar>();
        if(prc1.CompareTo(prc2)>0){
            rankings.Add(prc2);
            rankings.Add(prc1);
        }
        else{
            rankings.Add(prc1);
            rankings.Add(prc2);
        }
        return rankings;
    }
}
