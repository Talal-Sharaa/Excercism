class Lasagna
{
    // TODO: define the 'ExpectedMinutesInOven()' method
    public int ExpectedMinutesInOven() => 40;
    // TODO: define the 'RemainingMinutesInOven()' method
    public int RemainingMinutesInOven(int vElapsedTime) => 40-vElapsedTime;
    // TODO: define the 'PreparationTimeInMinutes()' method
    public int PreparationTimeInMinutes(int vNumberOfLayers) => 2 * vNumberOfLayers;
    // TODO: define the 'ElapsedTimeInMinutes()' method
            public int ElapsedTimeInMinutes(int vNumberOfLayers, int vElapsedTime) => 2 * vNumberOfLayers +  vElapsedTime;

}
