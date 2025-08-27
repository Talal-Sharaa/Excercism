public class RemoteControlCar
{
    private int batteryPercentage = 100;
    private int distanceDrivenInMeters = 0;
    private string[] sponsors = new string[0];
    private int latestSerialNum = 0;

    public void Drive()
    {
        if (batteryPercentage > 0)
        {
            batteryPercentage -= 10;
            distanceDrivenInMeters += 2;
        }
    }

    public void SetSponsors(params string[] sponsors)
    {
        this.sponsors = sponsors;
    }

    public string DisplaySponsor(int sponsorNum) => sponsors[sponsorNum];

    public bool GetTelemetryData(ref int serialNum,
        out int batteryPercentage, out int distanceDrivenInMeters)
    {
        if(latestSerialNum<=serialNum){
            latestSerialNum = serialNum;
            batteryPercentage = this.batteryPercentage;
            distanceDrivenInMeters = this.distanceDrivenInMeters;
            return true;
        }
        serialNum = latestSerialNum;
        batteryPercentage = -1;
        distanceDrivenInMeters = -1;
        return false;
    }

    public static RemoteControlCar Buy() => new RemoteControlCar();
}

public class TelemetryClient
{
    private RemoteControlCar car;

    public TelemetryClient(RemoteControlCar car)
    {
        this.car = car;
    }

    public string GetBatteryUsagePerMeter(int serialNum)
    {
        int batteryPercentage;
        int distanceDrivenInMeters;
        car.GetTelemetryData(ref serialNum, out batteryPercentage, out distanceDrivenInMeters);
        return  distanceDrivenInMeters>0? $"usage-per-meter={(100-batteryPercentage)/distanceDrivenInMeters}":"no data";
    }
}
