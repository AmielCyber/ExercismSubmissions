using System;

public class DndCharacter
{
    private static Random random = new Random();
    public int Strength { get; init; }
    public int Dexterity { get; init; }
    public int Constitution { get; init; }
    public int Intelligence { get; init; }
    public int Wisdom { get; init; }
    public int Charisma { get; init; }
    public int Hitpoints { get => Modifier(Constitution) + 10; }

    public static int Modifier(int score) => (int)Math.Floor((score - 10) / 2.0);

    public static int Ability()
    {
        int minScore = int.MaxValue;
        int sum = 0;
        for (int i = 0; i < 4; i++)
        {
            int randomScore = RollDie();
            minScore = randomScore < minScore ? randomScore : minScore;
            sum += randomScore;
        }
        sum -= minScore;
        return sum;
    }

    public static DndCharacter Generate()
    {
        return new DndCharacter()
        {
            Strength = Ability(),
            Dexterity = Ability(),
            Constitution = Ability(),
            Intelligence = Ability(),
            Wisdom = Ability(),
            Charisma = Ability(),
        };
    }

    private static int RollDie() => random.Next(1, 7);
}
