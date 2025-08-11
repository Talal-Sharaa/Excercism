class RemoteControlCar
{
    private int _MetersDriven = 0;
    private int _BatteryPercentage = 100;
    public static RemoteControlCar Buy()
        => new RemoteControlCar();

    public string DistanceDisplay()
        => $"Driven {_MetersDriven} meters";

    public string BatteryDisplay()
    {
        if(_BatteryPercentage == 0)
            return "Battery empty";
        return $"Battery at {_BatteryPercentage}%";
    }
    public void Drive()
    {
        if(_BatteryPercentage>0){
            _MetersDriven += 20;
       _BatteryPercentage--;
        }
        else{
            Console.WriteLine("Battery empty");
        }
    }
}
