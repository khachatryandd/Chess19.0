using ChessLibrary19._2.Figures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary19._2;

public class Validate
{
    /// <summary>
    /// Checks if all coordinates in the list are unique.
    /// </summary>
    /// <param name="coordinates"></param>
    /// <returns></returns>
    public bool EqualCoordinates(List<Coordinates> coordinates)
    {
        if (coordinates.Count == coordinates.Distinct().Count())
        {
            return true;
        }
        return false;
    }
    /// <summary>
    /// Checks if the white king is under attack by any of the black figures.
    /// </summary>
    /// <param name="coordR1"></param>
    /// <param name="coordR2"></param>
    /// <param name="coordQ"></param>
    /// <param name="coordBK"></param>
    /// <param name="coordWK"></param>
    /// <returns></returns>
    public bool IsTheKingUnderAttack(Coordinates coordR1, Coordinates coordR2, Coordinates coordQ,
        Coordinates coordBK, Coordinates coordWK)
    { 
        if ((Math.Abs((int)coordWK.letter - (int)coordQ.letter)) == Math.Abs((coordWK.number - coordQ.number)) ||
           coordWK.number == coordQ.number || coordWK.letter == coordQ.letter)
        {
            return false;
        }
        else if ((coordWK.number == coordR1.number || coordWK.letter == coordR1.letter))
        {
            return false;
        }
        else if ((coordWK.number == coordR2.number || coordWK.letter == coordR2.letter))
        {
            return false;
        }
        else if ((Math.Abs(coordWK.number - coordBK.number) == 1 &&
            Math.Abs((int)coordWK.letter - (int)coordBK.letter) == 1))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    /// <summary>
    /// Checks if the white King is in a stalemate position where it has no legal moves and is not in check.
    /// </summary>
    /// <param name="coordR1"></param>
    /// <param name="coordR2"></param>
    /// <param name="coordQ"></param>
    /// <param name="coordBK"></param>
    /// <param name="coordWKing"></param>
    /// <returns></returns>
    public bool CheckPat(Coordinates coordR1, Coordinates coordR2, Coordinates coordQ,
        Coordinates coordBK, Coordinates coordWKing)
    {
        int num = coordWKing.number;
        Letters let = coordWKing.letter;
        for (int i = num - 1; i <= num + 1; i++)
        {
            for (var j = let - 1; j <= let + 1; j++)
            {
                if (i != num && j != let)
                {
                    coordWKing.number = i;
                    coordWKing.letter = j;
                    if (IsTheKingUnderAttack(coordR1, coordR2, coordQ, coordBK, coordWKing))
                    {
                        return false;
                    }
                }
            }
        }
        return true;
    }
}
