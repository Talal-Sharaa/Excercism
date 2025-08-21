class RemoteControlCar
{
    private int _DistanceDriven;
    private int _Speed;
    public int Speed => _Speed;
    public int BatteryDrain => _BatteryDrain;
    private int _BatteryDrain;
    private int _BatteryPercentage;
    public RemoteControlCar(int vSpeed, int vBatteryDrain){
        _BatteryPercentage = 100;
        _DistanceDriven = 0;
        _Speed = vSpeed;
        _BatteryDrain = vBatteryDrain; 
    }

    public bool BatteryDrained() => _BatteryPercentage>=_BatteryDrain? false:true;

    public int DistanceDriven() => _DistanceDriven;

    public void Drive()
    {
        if(!BatteryDrained()){
            _DistanceDriven+=_Speed;
            _BatteryPercentage-=_BatteryDrain;
        }
        
    }

    public static RemoteControlCar Nitro() => new RemoteControlCar(50, 4);
}

class RaceTrack
{
    private int _Distance;
    public RaceTrack(int vDistance){
        _Distance = vDistance;
    }

    public bool TryFinishTrack(RemoteControlCar car) =>(((100/car.BatteryDrain)*car.Speed)>=_Distance)? true:false;
}
