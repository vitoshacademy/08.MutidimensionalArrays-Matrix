//Write a program that reads a rectangular matrix of size N x M and finds in it the square 3 x 3 that has maximal sum of its elements.
// First I am going to make the matrix by manual entering of indeces and then to check for the square :)
using System;
class rectangularMatrixRead
{
    static void Main()
    {
        int digit = 1;
        //Reading the first digit!
        Console.Write("Enter the first digit for the matrix rows (matrix = rows * columns)");
        Console.WriteLine();
        string FirstDigitString = Console.ReadLine();
        int FirstDigit;

        while ((int.TryParse(FirstDigitString, out FirstDigit) == false) || (FirstDigit<3))
        {
            Console.Write("Please enter a valid integer, bigger than 3!: "); // This is entered in order to make sure that the user enters a valid digit.
            FirstDigitString = Console.ReadLine();
        }

        //Reading the second digit!
        Console.Write("Enter the second digit for the matrix columns (matrix = rows * columns)");
        Console.WriteLine();
        string SecondDigitString = Console.ReadLine();
        int SecondDigit;

        while ((int.TryParse(SecondDigitString, out SecondDigit) == false) ||(SecondDigit<3))
        {
            Console.Write("Please enter a valid integer, bigger than 3!: "); // This is entered in order to make sure that the user enters a valid digit.
            SecondDigitString = Console.ReadLine();
        }


        int[,] Matrix = new int[FirstDigit, SecondDigit]; //The matrix is with size [FirstDigit,SecondDigit]
        Console.WriteLine();


        for (int row = 0; row < FirstDigit; row++)
        {
            for (int col = 0; col < SecondDigit; col++)
            {
                Matrix[row, col] = digit;       //Fill in the matrix
                digit++;
            }
        }


        Console.WriteLine("This is how the matrix you have created looks like:");
        for (int row = 0; row < FirstDigit; row++)
        {
            for (int col = 0; col < SecondDigit; col++)
            {
                Console.Write("{0,4}", Matrix[row, col]);     // Prints beautifully with spaces :)
            }
            Console.WriteLine();
        }

        //Now the interesting part, the checking for the square :)

        int bestSum = int.MinValue;
        int bestRow = 0;
        int bestCol = 0;
        int sum = int.MinValue;

        for (int row = 0; row < Matrix.GetLength(0)-2; row++) //We set minus two, in order to avoid out of array exception, it is a 3x3 platform
        {
            for (int col = 0; col < Matrix.GetLength(1)-2; col++) //Here as well;
            {
                sum = Matrix[row, col] + Matrix[row, col + 1] + Matrix[row, col + 2] +
                    Matrix[row + 1, col] + Matrix[row + 1, col + 1] + Matrix[row + 1, col + 2] +
                    Matrix[row + 2, col] + Matrix[row + 2, col + 1] + Matrix[row + 2, col + 2];
           if (sum >bestSum)
            {
                bestSum=sum;
                bestRow=row;
                bestCol=col;
            }
            }
     }
        //Print Result:
        Console.WriteLine("The best platform is:");
        Console.WriteLine("   {0} {1} {2}", Matrix[bestRow, bestCol], Matrix[bestRow, bestCol + 1], Matrix[bestRow, bestCol + 2]);	  
        Console.WriteLine("   {0} {1} {2}", Matrix[bestRow+1,bestCol],Matrix[bestRow+1,bestCol+1],Matrix[bestRow+1,bestCol+2]);
        Console.WriteLine("   {0} {1} {2}", Matrix[bestRow+2,bestCol],Matrix[bestRow+2,bestCol+1],Matrix[bestRow+2,bestCol+2]);
	    }
}

