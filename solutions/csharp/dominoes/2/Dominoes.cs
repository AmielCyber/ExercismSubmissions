using System.Collections.Generic;
using System.Linq;

public static class Dominoes
{
    public static bool CanChain(IEnumerable<(int, int)> dominoes)
    {
        List<(int leftVal, int rightVal)> dominoList = dominoes.ToList();

        if (!dominoList.Any())
        {
            return true;
        }

        var spareDominoesIndices = Enumerable.Range(1, dominoList.Count() - 1).ToHashSet();

        return CanChain(dominoList[0].rightVal, dominoList, spareDominoesIndices);
    }

    private static bool CanChain(int leftDominoRightVal, List<(int leftVal, int rightVal)> dominoList,
        HashSet<int> spareDominoes)
    {
        if (!spareDominoes.Any())
        {
            return IsCircularChain(leftDominoRightVal, dominoList[0].leftVal);
        }

        for (var i = 1; i < dominoList.Count; i++)
        {
            if (!spareDominoes.Contains(i) || !CanChainDomino(leftDominoRightVal, dominoList[i]))
            {
                // Can not chain current domino.
                continue;
            }
            ChainDomino(leftDominoRightVal, i, dominoList, spareDominoes);
            if (CanChain(dominoList[i].rightVal, dominoList, spareDominoes))
            {
                // Recursively chained all dominoes successfully.
                return true;
            }

            UnchainDomino(i, spareDominoes);
        }

        return false;
    }

    private static bool IsCircularChain(int lastDominoRightValue, int firstDominoLeftValue) =>
        lastDominoRightValue == firstDominoLeftValue;
    private static bool CanChainDomino(int lDominoRightVal, (int leftVal, int rightVal) rightDomino) =>
        lDominoRightVal == rightDomino.leftVal || lDominoRightVal == rightDomino.rightVal;

    private static void ChainDomino(int lDominoRVal, int rDominoIndex, List<(int leftVal, int rightVal)> dList,
        HashSet<int> spareDominoes)
    {
        spareDominoes.Remove(rDominoIndex);
        if (lDominoRVal != dList[rDominoIndex].leftVal)
        {
            dList[rDominoIndex] = GetRotatedDomino(dList[rDominoIndex]);
        }
    }
    private static (int, int) GetRotatedDomino((int leftVal, int rightVal) domino) => (domino.rightVal, domino.leftVal);

    private static void UnchainDomino(int rightDominoI, HashSet<int> spareDominoes) => spareDominoes.Add(rightDominoI);
}