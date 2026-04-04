public static class Grains
{
    public static ulong Square(int n){
        if(n>0 && n<65){
            return (ulong)(Math.Pow(2, n)/2);
        }
        else{
            throw new ArgumentOutOfRangeException("n must be a positive integer under 65");
        }
    } 

    public static ulong Total() => ulong.MaxValue;
}