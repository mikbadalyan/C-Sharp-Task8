using System;
using System.Collections.Generic;

KnightTour knight = new KnightTour();

Random random = new Random();
knight.knight_strokes(random.Next(0, 7),random.Next(0, 7),1);

class KnightTour
{
    public static int[] movex = { 1, 2, 2, 1, -1, -2, -2, -1 };
    public static int[] movey = { 2, 1, -1, -2, -2, -1, 1, 2 };

    public static int N = 8; 
    public static int[,] board = new int[N, N];
    
   
    public static bool Validity(int x, int y)
    {
        return (x >= 0 && y >= 0 && x < N && y < N && board[x, y] == 0);
    }
    
    
    public static int find_min(int x, int y)
    {
        int count = 0;
        for (int i = 0; i < 8; i++)
        {
            int newx = x + movex[i];
            int newy = y + movey[i];
            if (Validity(newx, newy))
            {
                count++;
            }
        }
        return count;
    }

    // Function to perform the Knight's Tour using Warnsdorff's Rule
    public bool knight_strokes(int x, int y, int moveCount)
    {
        board[x, y] = moveCount;
        if (moveCount == N * N)
        {
            visual();
            return true; // Knight's Tour completed
        }

        
        List<(int, int, int)> possibleMoves = new List<(int, int, int)>();
        for (int i = 0; i < 8; i++)
        {
            int newX = x + movex[i];
            int newY = y + movey[i];
            if (Validity(newX, newY))
            {
                int onwardMoves = find_min(newX, newY);
                possibleMoves.Add((newX, newY, onwardMoves));
            }
        }

        
        possibleMoves.Sort((a, b) => a.Item3.CompareTo(b.Item3));

        
        foreach (var move in possibleMoves)
        {
            int newX = move.Item1;
            int newY = move.Item2;
            if (knight_strokes(newX, newY, moveCount + 1))
            {
                return true;
            }
        }

     
        board[x, y] = 0;
        return false;
    }


    public static void visual()
    {
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                Console.Write(board[i, j].ToString().PadLeft(3) + " ");
            }
            Console.WriteLine();
        }
    }

    
}
