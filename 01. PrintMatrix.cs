//Write a program that fills and prints a matrix of size (n, n) as shown below: (examples for n = 4)
using System;

namespace FillPrintMatrix
{
    class Program
    {
        static void Main()
        {
            Console.Write("Enter a digit for the matrix size (matrix = digit*digit)");
            string input = Console.ReadLine();
            int N;
            int digit = 1;

            while (int.TryParse(input, out N) == false)
            {
                Console.Write("Please enter a valid integer!: "); // This is entered in order to make sure that the user enters a valid digit.
                input = Console.ReadLine();
            }
            int[,] Matrix = new int[N, N]; //The matrix is with size [digit,digit]
            Console.WriteLine();

            // Variant A:
            for (int col = 0; col < N; col++) 
            {
                for (int row = 0; row < N; row++)
                {
                    Matrix[row, col] = digit;       //Fill in the matrix
                    digit++;
                }
            }
            // 1 5 9  13
            // 2 6 10 14
            // 3 7 11 15
            // 4 8 12 16

            Console.WriteLine("This is variant A:");
            for (int row = 0; row < N; row++)
            {
                for (int col = 0; col < N; col++)
                {
                    Console.Write("{0,4}", Matrix[row, col]);     // Prints beautifully with spaces :)
                }
                Console.WriteLine();
            }
            digit = 1;
            Console.WriteLine();

            // Variant B:
            for (int col = 0; col < N; col++)
            {
                if (col % 2 == 0) //checks whether it is dividable by 2 - if it is then a different direction is selected.
                {
                    for (int row = 0; row < N; row++)
                    {
                        Matrix[row, col] = digit;       //Fill in the matrix
                        digit++;
                    }
                }
                else
                {
                    for (int row = N - 1; row >= 0; row--)
                    {
                        Matrix[row, col] = digit;       //Fill in the matrix
                        digit++;
                    }
                }
            }

            Console.WriteLine("This is variant B:");
            for (int row = 0; row < N; row++)
            {
                for (int col = 0; col < N; col++)
                {
                    Console.Write("{0,4}", Matrix[row, col]);     //Print the matrix
                }
                Console.WriteLine();
            }
            digit = 1;
            Console.WriteLine();

            // Variant C:
            int r = N - 1;
            int c = 0;
            int StartRow = N - 1;
            int StartCol = 0;
            Matrix[r, c] = 1;

            while (digit < N * N)
            {
                //First logic
                //Start position
                if (r == (N - 1) && c < (N - 1))
                {
                    StartRow--;
                    StartCol = 0;
                    r = StartRow;       // Row = (N-1), (N-2), (N-N)
                    c = StartCol;       // Col = 0
                    digit++;
                    Matrix[r, c] = digit;

                    //down-right movement -> row++; col++; until bottom-right is reached
                    while (r < (N - 1) && c < (N - 1))
                    {
                        r++;    //Move down
                        c++;    //Move right
                        digit++;
                        Matrix[r, c] = digit;
                    }
                }
                //Start position, when bottom-right corner reached
                if (r <= (N - 1) && c == (N - 1))
                {
                    StartRow = 0;
                    StartCol++;
                    r = StartRow;   // Row = 0
                    c = StartCol;   // Col = 1,2,3,4...N-1
                    digit++;        // digit = 1,2,3...N*N
                    Matrix[r, c] = digit;

                    //down-right movement -> row++; col++; until rightest column is reached. The bottom is not N-1 anymore!
                    while (c < (N - 1))
                    {
                        r++;    //Move down
                        c++;    //Move right
                        digit++;
                        Matrix[r, c] = digit;
                    }
                }
            }

            Console.WriteLine("This is variant C:");
            for (int row = 0; row < N; row++)
            {
                for (int col = 0; col < N; col++)
                {
                    Console.Write("{0,4}", Matrix[row, col]);     //Print the matrix
                }
                Console.WriteLine();
            }
            digit = 1;
            Console.WriteLine();

            //Variant D:
            int offset = 0;
            int Row = 0;
            int Col = 0;

            while (digit <= N * N)
            {
                //Move down
                for (Row = offset; Row < N - offset; Row++)
                {
                    Col = offset;
                    Matrix[Row, Col] = digit;
                    digit++;
                }
                //Move right
                for (Col = 1 + offset; Col < N - offset; Col++)
                {
                    Row = N - 1 - offset;
                    Matrix[Row, Col] = digit;
                    digit++;
                }
                //Move up
                for (Row = N - 2 - offset; Row >= offset; Row--)
                {
                    Col = N - 1 - offset;
                    Matrix[Row, Col] = digit;
                    digit++;
                }
                //Move left
                for (Col = N - 2 - offset; Col >= offset + 1; Col--)
                {
                    Row = offset;
                    Matrix[Row, Col] = digit;
                    digit++;
                }
                offset++;
            }

            Console.WriteLine("This is variant D:");
            for (int row = 0; row < N; row++)
            {
                for (int col = 0; col < N; col++)
                {
                    Console.Write("{0,4}", Matrix[row, col]);     //Print the matrix
                }
                Console.WriteLine();
            }
            digit = 1;
            Console.WriteLine();
        }
    }
}
