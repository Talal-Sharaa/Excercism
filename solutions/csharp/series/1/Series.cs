public static class Series
{
    public static string[] Slices(string numbers, int sliceLength)
    {
        if(string.IsNullOrEmpty(numbers)){
                       throw new ArgumentException("Number must not be empty"); 
        }
        if(sliceLength>numbers.Length || sliceLength <=0){
            throw new ArgumentException("Slice Length must be a positive number smaller than the number length");
        }
        string[] xSlices = new string[(numbers.Length - sliceLength +1)];
        for(int i = 0; i<=numbers.Length - sliceLength; i++){
            xSlices[i] = (numbers.Substring(i, sliceLength));
        }
        return xSlices;
    }
}