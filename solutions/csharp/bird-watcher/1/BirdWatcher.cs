class BirdCount
{
    private int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek()
        => [0, 2, 5, 3, 7, 8, 4];

    public int Today()
      =>  birdsPerDay[birdsPerDay.Length-1];

    public void IncrementTodaysCount()
       => birdsPerDay[birdsPerDay.Length-1]++;

    public bool HasDayWithoutBirds()
    {
        foreach(int count in birdsPerDay){
            if(count == 0)
                return true;
        }
        return false;
    }

    public int CountForFirstDays(int numberOfDays)
    {
        int count = 0;
        for(int day = 0; day<numberOfDays; day++){
            count += birdsPerDay[day];
        }
        return count;
    }

    public int BusyDays()
    {
        int numberOfBusyDays = 0;
        foreach(int count in birdsPerDay){
            if(count >= 5)
                numberOfBusyDays++;
        }
        return numberOfBusyDays;
    }
}
