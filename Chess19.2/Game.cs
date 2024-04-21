using ChessLibrary19._2;
using ChessLibrary19._2.Figures;
namespace Chess19._2;
internal class Game
{
    public void Choose()
    {
        Console.WriteLine("Welcome to my game! Please, choose the game \n ClassicGame(1)  QueenGame(2)");
        string game = Console.ReadLine();
        if (game == "1")
        {
            ClassicGame classicGame = new ClassicGame();
            classicGame.Run();
        }
        else if (game == "2")
        {
            QueenGame queenGame = new QueenGame();
            queenGame.Run();
        }
        else
        {
            Console.WriteLine("The number you entered is invalid");
        }
    }
}
class ClassicGame
{
    Rook rook = new Rook();
    Queen queen = new Queen();
    King king = new King();
    Bishop bishop = new Bishop();
    Knight knight = new Knight();
    /// <summary>
    /// Checks if the Figure can make a move between two coordinates on the board.
    /// </summary>
    /// <exception cref="ArgumentException"></exception>
    public void Run()
    {
        Board board = new Board();
        Console.WriteLine("Choose the figure");
        string figure = Console.ReadLine();
        Console.WriteLine("Enter the first coordinate");
        Coordinates first = new Coordinates(Console.ReadLine());
        Console.WriteLine("Enter the second coordinate");
        Coordinates second = new Coordinates(Console.ReadLine());
        switch (figure)
        {
            case "Rook":
                if (rook.Move(first, second))
                    board.CreateBoard(first, second, Symbols.R);
                break;
            case "Queen":
                if (queen.Move(first, second))
                    board.CreateBoard(first, second, Symbols.Q);
                break;
            case "Knight":
                if (knight.Move(first, second))
                    board.CreateBoard(first, second, Symbols.N);
                break;
            case "Bishop":
                if (bishop.Move(first, second))
                    board.CreateBoard(first, second, Symbols.B);
                break;
            case "King":
                if (king.Move(first, second))
                    board.CreateBoard(first, second, Symbols.K);
                break;
            default:
                throw new ArgumentException("Invalid figure!");
        }
    }
}
class QueenGame
{
    /// <summary>
    /// Game involving Queen, 2 Rooks, 2 Kings
    /// </summary>
    public void Run()
    {
        Console.WriteLine("Welcome to the Queen Game!\nPlease, enter coordinates for the enemy(B)");
        Console.Write("Rook1: ");
        Coordinates coordR1 = new Coordinates(Console.ReadLine());
        Console.Write("Rook2: ");
        Coordinates coordR2 = new Coordinates(Console.ReadLine());
        Console.Write("Queen: ");
        Coordinates coordQ = new Coordinates(Console.ReadLine());
        Console.Write("King: ");
        Coordinates coordBK = new Coordinates(Console.ReadLine());
        Console.WriteLine("Please, enter coordinates for King(W)");
        Console.Write("King: ");
        Coordinates coordWK = new Coordinates(Console.ReadLine());

        List<Coordinates> coordinates = [coordR1, coordR2, coordQ, coordBK, coordWK];
        Validate validate = new Validate();
        Board board = new Board();
        King wKing = new King();
        Mate mate = new Mate();

        if (validate.EqualCoordinates(coordinates) && validate.IsTheKingUnderAttack(coordR1, coordR2, coordQ, coordBK, coordWK)
            && !validate.CheckPat(coordR1, coordR2, coordQ, coordBK, coordWK))
        {
            board.PrintFiguresLetterOnTheBoard(coordR1, coordR2, coordQ, coordBK, coordWK);
            mate.Mat(coordinates, coordR1, coordR2, coordQ, coordBK, coordWK);
        }
    }
}