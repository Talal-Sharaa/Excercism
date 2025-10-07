public static class AccumulateExtensions
{
    public static IEnumerable<U> Accumulate<T, U>(this IEnumerable<T> collection, Func<T, U> func)
    {
        List<U> xProducedNumbers = new List<U>();
        foreach(T iItem in collection){
            yield return func(iItem);
        }
    }
}