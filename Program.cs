using System;

namespace Sudoku
{
    class Program
    {
        static int[,] board = new int[,]
        {
            {0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0}
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido al juego de Sudoku");
            tablero();

            while (!Resolver())
            {
                Console.WriteLine("Ingresa fila, columna y numero separados por espacios:");
                string[] input = Console.ReadLine().Split();

                if (input.Length == 3 && int.TryParse(input[0], out int row) && int.TryParse(input[1], out int col) && int.TryParse(input[2], out int value))
                {
                    if (row >= 1 && row <= 9 && col >= 1 && col <= 9 && value >= 1 && value <= 9)
                    {
                        if (invalid(row - 1, col - 1, value))
                        {
                            board[row - 1, col - 1] = value;
                            tablero();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Datos incorrectos");
                }
            }
        }

        static void tablero()
        {
            Console.WriteLine("Tablero de Sudoku:");
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static bool invalid(int row, int col, int value)
        {

            if (board[row, col] == 0)
            {

                for (int i = 0; i < 9; i++)
                {
                    if (board[row, i] == value || board[i, col] == value)
                    {
                        return false;
                    }
                }


                int subrow = (row / 3) * 3;
                int subcol = (col / 3) * 3;
                for (int i = subrow; i < subrow + 3; i++)
                {
                    for (int j = subcol; j < subcol + 3; j++)
                    {
                        if (board[i, j] == value)
                        {
                            return false;
                        }
                    }
                }

                return true;
            }

            return false;
        }

        static bool Resolver()
        {
            
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i, j] == 0)
                    {
                        return false;
                    }
                }
            }
            Console.WriteLine("¡Felicidades!");
            return true;
        }
    }
}
