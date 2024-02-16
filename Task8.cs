using System;
using System.Collections.Generic;

knight_64 knight = new knight_64();

Random rnd = new Random();
knight.strokes(rnd.Next(0, 7), rnd.Next(0, 7), 1);

class knight_64
{
    public static int[] dx = { 1, 2, 2, 1, -1, -2, -2, -1 };
    public static int[] dy = { 2, 1, -1, -2, -2, -1, 1, 2 };

    public static int N = 8;
    public static int[,] board = new int[N, N];


    public static bool checking(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < N && y < N && board[x, y] == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public static int find_min(int x, int y)
    {
        int count = 0;
        for (int i = 0; i < 8; i++)
        {
            int nx = x + dx[i];
            int ny = y + dy[i];
            if (checking(nx, ny))
            {
                count++;
            }
        }
        return count;
    }

    public bool strokes(int x, int y, int moveCount)
    {
        board[x, y] = moveCount;
        if (moveCount == N * N)
        {
            Visual();
            return true; // Knight's Tour completed
        }

        List<(int, int, int)> possibleMoves = new List<(int, int, int)>();
        for (int i = 0; i < 8; i++)
        {
            int nx = x + dx[i];
            int ny = y + dy[i];
            if (checking(nx, ny))
            {
                int onwardMoves = find_min(nx, ny);
                possibleMoves.Add((nx, ny, onwardMoves));
            }

        }
        Visual();

        possibleMoves.Sort((a, b) => a.Item3.CompareTo(b.Item3));

        foreach (var move in possibleMoves)
        {
            int nx = move.Item1;
            int ny = move.Item2;
            if (strokes(nx, ny, moveCount + 1))
            {
                return true;
            }

        }

        board[x, y] = 0;
        return false;
    }


    public static void Visual()
    {
        Console.ForegroundColor = ConsoleColor.White;
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (board[i, j] != 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(board[i, j].ToString().PadLeft(3) + " ");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.Write(board[i, j].ToString().PadLeft(3) + " ");
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        Console.WriteLine();
    }
}
