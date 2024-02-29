int row = 8;
int col = 8;

//Ստեղծում ենք մատրից որի յուրաքանչյուր վանդակ կունենա նշանակված թիվ ոռը կլինի ձիու հավանական քայլերի քանակը։
int[, ] chessboard = {
      { 2, 3, 4, 4, 4, 4, 3, 2 }, 
      { 3, 4, 6, 6, 6, 6, 4, 3 }, 
      { 4, 6, 8, 8, 8, 8, 6, 4 }, 
      { 4, 6, 8, 8, 8, 8, 6, 4 },
      { 4, 6, 8, 8, 8, 8, 6, 4 }, 
      { 4, 6, 8, 8, 8, 8, 6, 4 }, 
      { 3, 4, 6, 6, 6, 6, 4, 3 }, 
      { 2, 3, 4, 4, 4, 4, 3, 2 },
};

int a;
int index_i;
int index_j;

Console.ForegroundColor = ConsoleColor.White;
void knight_tour (int row, int col)
{
      a = 9;
      index_i = 4;
      index_j = 3;
      int aa = 0;
      for (int i = 1; i < 9; i++)
            {
                  for (int j = 1; j < 9; j++)
                        {
                              aa++;
                              if (chessboard[i - 1, j - 1] == 9)
                                    {
                                          Console.ForegroundColor = ConsoleColor.Green;
                                          Console.Write ("K ");
                                          Console.ForegroundColor = ConsoleColor.White;
                                    }
                              else if ((Math.Abs (row - i) == 2 && Math.Abs (col - j) == 1) || (Math.Abs (row - i) == 1 && Math.Abs (col - j) == 2))
                                    {
                                          if (chessboard[i - 1, j - 1] < a)
                                                {
                                                      a = chessboard[i - 1, j - 1];
                                                      index_i = i;
                                                      index_j = j;
                                                }

                                          Console.Write (chessboard[i - 1, j - 1] + " ");
                                    }
                              else if (row == i && col == j)
                                    {
                                          chessboard[i - 1, j - 1] = 9;
                                          Console.ForegroundColor = ConsoleColor.Green;
                                          Console.Write ("K ");
                                          Console.ForegroundColor = ConsoleColor.White;
                                    }
                              else
                                    {
                                          Console.Write ("0 ");
                                    }
                        }
                  Console.WriteLine ();
                  if (aa == 8)
                        {
                              Console.WriteLine ();
                              Console.WriteLine ();
                              Console.WriteLine ();
                        }
            }

      if (a != 9)
            {
                  knight_tour (index_i, index_j);
            }
}

knight_tour (row, col);
