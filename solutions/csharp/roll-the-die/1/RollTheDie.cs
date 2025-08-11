public class Player{    public int RollDie()
    {
        Random randomDie = new();
        return randomDie.Next(1, 18);
    }

    public double GenerateSpellStrength()
    {
        Random strength = new();
        return strength.NextDouble() * 100;
    }
}
