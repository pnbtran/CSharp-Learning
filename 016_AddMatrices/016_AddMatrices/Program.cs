 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _016_AddMatrices
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            int[,] matrixA = { { 2, 2, 4 }, { 5, 4, 7 }, { 9, 2, 8 } };
            int[,] matrixB = { { 1, 1, 2 }, { 5, 6, 3 }, { 5, 7, 4 } };
            
            int rows = matrixA.GetLength(0);
            int columns = matrixA.GetLength(1);

            int[,] result = new int[rows, columns];

            // Add Matrices
            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    result[row, column] = matrixA[row, column] + matrixB[row, column];
                }
            }

            Console.WriteLine("Matrix Addition\n");

            for (int row = 0; row < rows; row++)
            {
                // Matrix A
                Console.Write("|");
                for (int column = 0; column < columns; column++)
                {
                    Console.Write($"{matrixA[row, column],4}");
                }
                Console.Write(" |");

                // Dấu +
                if (row == rows / 2)
                    Console.Write("   +   ");
                else
                    Console.Write("       ");

                // Matrix B
                Console.Write("|");
                for (int column = 0; column < columns; column++)
                {
                    Console.Write($"{matrixB[row, column],4}");
                }
                Console.Write(" |");

                // Dấu =
                if (row == rows / 2)
                    Console.Write("   =   ");
                else
                    Console.Write("       ");

                // Result
                Console.Write("|");
                for (int column = 0; column < columns; column++)
                {
                    Console.Write($"{result[row, column],4}");
                }
                Console.Write(" |");

                Console.WriteLine();
            }
        }      
    }
}