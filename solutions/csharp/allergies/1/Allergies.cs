using System;
using System.Collections.Generic;

public enum Allergen : int
{
    Eggs,
    Peanuts,
    Shellfish,
    Strawberries,
    Tomatoes,
    Chocolate,
    Pollen,
    Cats
}

public class Allergies
{
    private HashSet<Allergen> _allergies = new();

    public Allergies(int mask)
    {
        foreach (Allergen a in Enum.GetValues(typeof(Allergen)))
        {
            int bitResult = (1 << (int)a) & mask;
            if (bitResult > 0)
                _allergies.Add(a);
        }
    }

    public bool IsAllergicTo(Allergen allergen) => _allergies.Contains(allergen);

    public Allergen[] List()
    {
        Allergen[] allergenList = new Allergen[_allergies.Count];
        _allergies.CopyTo(allergenList);

        return allergenList;
    }
}
