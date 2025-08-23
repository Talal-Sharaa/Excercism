public class WeighingMachine
{
    private int _precision;
    public int Precision{
        get{
            return _precision;
        }
        private set {
            _precision = value;
        }
    }
    // TODO: define the 'Weight' property
    private double _Weight;
    public double Weight{
        get{
            return _Weight;
        }
        set {
            if(value<0)
            {
                throw new ArgumentOutOfRangeException(); 
            }
            _Weight = value;
                
        }
    }
    // TODO: define the 'DisplayWeight' property
    public string DisplayWeight
    {
        get
        {
        double netWeight = Weight - TareAdjustment;
        return $"{netWeight.ToString("F" + Precision)} kg";
        }
    }

    // TODO: define the 'TareAdjustment' property
    private double _TareAdjustment = 5.0;
    public double TareAdjustment{
        get{
            return _TareAdjustment;
        }
        set {
            _TareAdjustment = value;
        }
    }
    public WeighingMachine(int precision){
        Precision = precision;
    }
}
