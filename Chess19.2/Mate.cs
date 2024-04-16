using ChessLibrary19._2.Figures;
using ChessLibrary19._2;
using System.Net.NetworkInformation;
namespace Chess19._2;
internal class Mate
{
    Rook rook1 = new Rook();
    Rook rook2 = new Rook();
    Queen queen = new Queen();
    King wKing = new King();
    /// <summary>
    /// Allows the white king to make a move.
    /// </summary>
    /// <param name="current">The current position of the white King.</param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public Coordinates WhiteKingMove(Coordinates current)
    {
        Console.WriteLine("Enter the move coordinate");
        Coordinates destination = new Coordinates(Console.ReadLine());
        if (wKing.Move(current, destination))
        {
            return destination;
        }
        else
        {
            throw new ArgumentException("Invalid move!");
        }
    }
    /// <summary>
    /// Scenario where the black figures mate the white King.
    /// </summary>
    /// <param name="coordinates">List of coordinates for all figures.</param>
    /// <param name="coordR1">Coordinates of the Rook1.</param>
    /// <param name="coordR2">Coordinates of the Rook2.</param>
    /// <param name="coordQ">Coordinates of the Queen.</param>
    /// <param name="coordBK">Coordinates of the black King.</param>
    /// <param name="coordWK">Coordinates of the white King.</param>
    public void Mat(List<Coordinates> coordinates, Coordinates coordR1, Coordinates coordR2, Coordinates coordQ,
        Coordinates coordBK, Coordinates coordWK)
    {
        Board board = new Board();
        bool mate = false;
        coordWK = WhiteKingMove(coordWK);
        do
        {
            List<Coordinates> rook1Steps = rook1.FilterValidMoves(coordR1, coordinates);
            List<Coordinates> rook2Steps = rook2.FilterValidMoves(coordR2, coordinates);
            List<Coordinates> queenSteps = queen.FilterValidMoves(coordQ, coordinates);
            if (Math.Abs(coordR1.number - coordWK.number) != 1)
            {
                if (CheckR1(rook1Steps,ref coordR1, coordWK))
                {
                    board.PrintFiguresLetterOnTheBoard(coordR1, coordR2, coordQ, coordBK, coordWK);
                }
                else if (CheckR2(rook2Steps,ref coordR2, coordWK))
                {
                    board.PrintFiguresLetterOnTheBoard(coordR1, coordR2, coordQ, coordBK, coordWK);
                }
                else
                {
                    coordR1.letter += 1;
                    board.PrintFiguresLetterOnTheBoard(coordR1, coordR2, coordQ, coordBK, coordWK);
                }
            }
            else if (Math.Abs(coordR2.number - coordWK.number) != 1)
            {
                if (CheckR2(rook2Steps,ref coordR2, coordWK))
                {
                    board.PrintFiguresLetterOnTheBoard(coordR1, coordR2, coordQ, coordBK, coordWK);
                }
                else
                {
                    coordR2.letter += 2;
                    board.PrintFiguresLetterOnTheBoard(coordR1, coordR2, coordQ, coordBK, coordWK);
                }
            }
            else if (Math.Abs(coordQ.number - coordWK.number) != 0)
            {
                if (CheckQ(queenSteps,ref coordQ, coordWK))
                {
                    coordQ.number = coordWK.number;
                    board.PrintFiguresLetterOnTheBoard(coordR1, coordR2, coordQ, coordBK, coordWK);
                }
                else
                {
                    coordQ.letter += 3;
                    board.PrintFiguresLetterOnTheBoard(coordR1, coordR2, coordQ, coordBK, coordWK);
                }
            }
            if (Math.Abs(coordR1.number - coordWK.number) == 1 && Math.Abs(coordR2.number - coordWK.number) == 1
                    && Math.Abs(coordQ.number - coordWK.number) == 0)
            {
                mate = true;
                Console.WriteLine("You loose the game!");
                break;
            }
            else
            {
                mate = false;
                coordWK = WhiteKingMove(coordWK);
            }

        } while (!mate);

    }
    /// <summary>
    /// Checks if the Rook can block white King's movement.
    /// </summary>
    /// <param name="rook1Steps">List of valid moves for the Rook1.</param>
    /// <param name="coordR1"></param>
    /// <param name="coordWK"></param>
    /// <returns></returns>
    public bool CheckR1(List<Coordinates> rook1Steps,ref Coordinates coordR1, Coordinates coordWK)
    {
        Coordinates c = new Coordinates();
        if (coordWK.number != 1)
        {
            c.number = coordWK.number - 1;
        }
        else
        {
            c.number = coordWK.number + 1;
        }
        c.letter = coordR1.letter;
        if (rook1Steps.Contains(c))
        {
            coordR1.number = c.number;
            coordR1.letter = c.letter;
            return true;
        }
        return false;
    }
    /// <summary>
    /// Checks if the Rook can block white King's movement.
    /// </summary>
    /// <param name="rook2Steps">List of valid moves for the Rook2.</param>
    /// <param name="coordR2"></param>
    /// <param name="coordWK"></param>
    /// <returns></returns>
    public bool CheckR2(List<Coordinates> rook2Steps,ref Coordinates coordR2, Coordinates coordWK)
    {
        Coordinates c = new Coordinates();
        if (coordWK.number != 8)
        {
            c.number = coordWK.number + 1;
        }
        else
        {
            c.number = coordWK.number - 1;
        }
        c.letter = coordR2.letter;
        if (rook2Steps.Contains(c))
        {
            coordR2.number = c.number;
            coordR2.letter = c.letter;
            return true;
        }
        return false;
    }
    /// <summary>
    /// Checks if the Queen can threaten the white King.
    /// </summary>
    /// <param name="queenSteps">List of valid moves for the Queen.</param>
    /// <param name="coordQ"></param>
    /// <param name="coordWK"></param>
    /// <returns></returns>
    public bool CheckQ(List<Coordinates> queenSteps,ref Coordinates coordQ, Coordinates coordWK)
    {
        Coordinates c = new Coordinates();
        c.number = coordWK.number;
        c.letter = coordQ.letter;
        if(queenSteps.Contains(c))
        {
            return true;
        }
        return false;
    }
}
