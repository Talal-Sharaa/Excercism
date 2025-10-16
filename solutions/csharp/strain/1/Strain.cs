public static class Strain
{
    public static IEnumerable<T> Keep<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
    {
       foreach(var iItem in collection){
           if(predicate(iItem)){
               yield return iItem;
           }
       }
    }

    public static IEnumerable<T> Discard<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
    {
        foreach(var iItem in collection){
           if(!predicate(iItem)){
               yield return iItem;
           }
        }   
    }
}