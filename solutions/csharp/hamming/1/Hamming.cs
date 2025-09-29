public static class Hamming
{
    public static int Distance(string firstStrand, string secondStrand)
    {
        int xHammingDistance = 0;
        if(firstStrand.Length == secondStrand.Length){
            for(int i = 0; i< firstStrand.Length; i++){
                if(firstStrand[i] != secondStrand[i]){
                    xHammingDistance++;
                }
            }
        }
        else{
            throw new ArgumentException("Two strings are not equal in length");
        }
        return xHammingDistance;
    }
}