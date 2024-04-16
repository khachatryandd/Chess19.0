using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessLibrary19._2;

namespace Chess19._2;

internal class Board
{
    public string[,] array = new string[8, 8];
    public int a = 0;
    /// <summary>
    /// Creates and prints the chess board.
    /// </summary>
    public void CreateBoard(Coordinates first,Coordinates second, Symbols symbol)
    {
        PrintLettersNextToBoard();
        for (int i = 0; i < 8; i++)
        {
            PrintNumbersNextToBoard();
            for (int j = 0; j < 8; j++)
            {
                if ((i + j) % 2 == 0)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                }

                if (i == first.number - 1 && j == (int)first.letter)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write($" {symbol} ");
                }
                else if (i == second.number - 1 && j == (int)second.letter)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($" {symbol} ");
                }
                else
                {
                    Console.Write("   ");
                }
            }
            Console.ResetColor();
            Console.WriteLine();
        }
    }
    /// <summary>
    /// Prints numbers next to the board(1-8).
    /// </summary>
    public void PrintNumbersNextToBoard()
    {
        Console.Write(++a + " ");
    }
    /// <summary>
    /// Prints letters next to the board (A-H).
    /// </summary>
    public void PrintLettersNextToBoard()
    {
        for (char k = 'A'; k <= 'H'; k++)
        {
            if (k == 'A')
            {
                Console.Write("  ");
            }
            Console.Write(" " + k + " ");
        }
        Console.WriteLine();
    }
    /// <summary>
    /// Prints Figure's letter on the board.
    /// </summary>
    /// <param name="coordR1">Rook1's coordinates</param>
    /// <param name="coordR2">Rook2's coordinates</param>
    /// <param name="coordQ">Queen's coordinates</param>
    /// <param name="coordBK">Black King's coordinates</param>
    /// <param name="coordWK">White King's coordinates</param>
    public void PrintFiguresLetterOnTheBoard(Coordinates coordR1, Coordinates coordR2,
        Coordinates coordQ, Coordinates coordBK, Coordinates coordWK)
    {
        PrintLettersNextToBoard();
        for (int i = 0; i < 8; i++)
        {
            PrintNumbersNextToBoard();
            for (int j = 0; j < 8; j++)
            {
                for (int index = 0; index < 5; index++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    }
                }
                if (i == coordR1.number - 1 && j == (int)coordR1.letter)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write($" {Symbols.R} ");
                }
                else if (i == coordR2.number - 1 && j == (int)coordR2.letter)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write($" {Symbols.R} ");
                }
                else if (i == coordQ.number - 1 && j == (int)coordQ.letter)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write($" {Symbols.Q} ");
                }
               else  if (i == coordBK.number - 1 && j == (int)coordBK.letter)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write($" {Symbols.K} ");
                }
                else if (i == coordWK.number - 1 && j == (int)coordWK.letter)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($" {Symbols.K} ");
                }
                else
                {
                    Console.Write("   ");
                }
            }
            Console.ResetColor();
            Console.WriteLine();
        }
        a = 0;
    }
}

