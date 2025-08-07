using System.Collections.Generic;

public static class Dominoes
{
    public static bool CanChain(IEnumerable<(int, int)> dominoes)
    {
        List<(int, int)> dominoList = new(dominoes);
        if (dominoList.Count == 0)
            return true;
        HashSet<int> spareDominosIndices = new();
        for (int i = 1; i < dominoList.Count; i++)
            spareDominosIndices.Add(i);

        return CanChain(dominoList[0].Item2, dominoList, spareDominosIndices);
    }

    public static bool CanChain(int lDominoRightVal, List<(int, int)> dominoList, HashSet<int> spareDominos)
    {
        if (spareDominos.Count == 0)
            return dominoList[0].Item1 == lDominoRightVal;
        for (int i = 1; i < dominoList.Count; i++)
        {
            if (spareDominos.Contains(i) && CanChainDomino(lDominoRightVal, dominoList[i]))
            {
                ChainDomino(lDominoRightVal, i, dominoList, spareDominos);
                if (CanChain(dominoList[i].Item2, dominoList, spareDominos))
                    return true;
                else
                    UnchainDomino(i, spareDominos);
            }
        }
        return false;
    }

    private static bool CanChainDomino(int lDominoRightVal, (int, int) rightDomino) =>
        lDominoRightVal == rightDomino.Item1 || lDominoRightVal == rightDomino.Item2;

    private static void ChainDomino(int lDominoRVal, int rDominoI, List<(int, int)> dList, HashSet<int> spareDominos)
    {
        spareDominos.Remove(rDominoI);
        if (lDominoRVal != dList[rDominoI].Item1)
            dList[rDominoI] = GetRotatedDomino(dList[rDominoI]);
    }

    private static (int, int) GetRotatedDomino((int, int) domino) => (domino.Item2, domino.Item1);

    private static void UnchainDomino(int rightDominoI, HashSet<int> spareDominos) => spareDominos.Add(rightDominoI);
}
