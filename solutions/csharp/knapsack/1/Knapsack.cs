public static class Knapsack
{
    public static int MaximumValue(int maximumWeight, (int weight, int value)[] items) =>
        ChooseMaxValue(0, 0, maximumWeight, 0, items);

    private static int ChooseMaxValue(
        int totalValue,
        int totalWeight,
        int maxWeight,
        int currentIndex,
        (int weight, int value)[] items
    )
    {
        if (currentIndex >= items.Length)
            return totalValue;

        int chooseCurrent = 0;
        if (items[currentIndex].weight + totalWeight <= maxWeight)
            chooseCurrent = ChooseMaxValue(
                items[currentIndex].value + totalValue,
                items[currentIndex].weight + totalWeight,
                maxWeight,
                currentIndex + 1,
                items
            );
        int skipCurrent = ChooseMaxValue(
            totalValue,
            totalWeight,
            maxWeight,
            currentIndex + 1,
            items
        );

        return Math.Max(chooseCurrent, skipCurrent);
    }
}
