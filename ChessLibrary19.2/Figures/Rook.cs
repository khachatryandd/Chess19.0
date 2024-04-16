using System.Reflection.Metadata.Ecma335;

namespace ChessLibrary19._2.Figures;
public class Rook
{
    /// <summary>
    /// Checks if the Rook can make a move between two coordinates on the board.
    /// </summary>
    /// <param name="first"></param>
    /// <param name="second"></param>
    /// <returns></returns>
    public bool Move(Coordinates first, Coordinates second)
    {
        int x = Math.Abs(first.number - second.number);
        int y = Math.Abs((int)first.letter - (int)second.letter);

        if (x == 0 || y == 0)
        {
            return true;
        }
        return false;
    }
    /// <summary>
    /// Filters out valid moves from a list of coordinates based on obstruction by other figures.
    /// </summary>
    /// <param name="startCoord"></param>
    /// <param name="coordinates">The list of coordinates representing possible moves.</param>
    /// <returns></returns>
    public List<Coordinates> FilterValidMoves(Coordinates startCoord, List<Coordinates> coordinates)
    {
        List<Coordinates> list = CheckPossibleMoves(startCoord);
        Coordinates coord = new Coordinates();
        foreach (var c in coordinates)
        {
            if (list.Contains(c))
            {
                if (startCoord.number == c.number)
                {
                    coord.number = c.number;
                    if ((int)startCoord.letter > (int)c.letter)
                    {
                        for (int i = (int)c.letter; i >= 0; i--)
                        {
                            coord.letter = (Letters)i;
                            list.Remove(coord);
                        }
                    }
                    else if ((int)startCoord.letter < (int)c.letter)
                    {
                        for (int i = (int)c.letter; i <= 8; i++)
                        {
                            coord.letter = (Letters)i;
                            list.Remove(coord);
                        }
                    }
                }
                else if (startCoord.letter == c.letter)
                {
                    coord.letter = c.letter;
                    if (startCoord.number > c.number)
                    {
                        for(int i = c.number; i >= 1; i--)
                        {
                            coord.number = i;
                            list.Remove(coord);
                        }
                    }
                    else if(startCoord.number < c.number)
                    {
                        for(int i =c.number;i<=8; i++)
                        {
                            coord.number = i;
                            list.Remove(coord);
                        }
                    }
                }
            }
        }
        return list;
    }
    /// <summary>
    /// Generates a list of possible moves from a given starting coordinate.
    /// </summary>
    /// <param name="startCoord"></param>
    /// <returns></returns>
    public List<Coordinates> CheckPossibleMoves(Coordinates startCoord)
    {
        List<Coordinates> steps = new List<Coordinates>();

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Coordinates nextStep = new Coordinates();
                nextStep.number = i + 1;
                nextStep.letter = (Letters)j;
                if (Move(startCoord, nextStep) && nextStep.Equals(startCoord))
                {
                    continue;
                }
                else if (Move(startCoord, nextStep))
                {
                    steps.Add(nextStep);
                }
            }
        }
        return steps;
    }
}

