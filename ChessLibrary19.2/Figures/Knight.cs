namespace ChessLibrary19._2.Figures;
public class Knight
{
    /// <summary>
    /// Checks if the Knight can make a move between two coordinates on the board.
    /// </summary>
    /// <param name="first"></param>
    /// <param name="second"></param>
    /// <returns></returns>
    public bool Move(Coordinates first, Coordinates second)
    {
        int x = Math.Abs(first.number - second.number);
        int y = Math.Abs((int)first.letter - (int)second.letter);

        if ((x == 1 && y == 2) || (x == 2 && y == 1))
        {
            return true;
        }
            return false;
    }
    /// <summary>
    /// Generates a list of possible moves from a given starting coordinate.
    /// </summary>
    /// <param name="startCoord"></param>
    /// <returns></returns>
    public List<Coordinates> CheckPossibleMoves(Coordinates startCoord)
    {
        int number = startCoord.number;
        Letters letter = startCoord.letter;
        List<Coordinates> steps = new List<Coordinates>();

        for (int i = 1; i <= 8; i++)
        {
            for (int j = 1; j <= 8; j++)
            {
                Coordinates nextStep = new Coordinates();
                nextStep.number = i;
                nextStep.letter = (Letters)j;
                if (Move(startCoord, nextStep))
                {
                    steps.Add(nextStep);
                }
            }
        }
        return steps;
    }

}
