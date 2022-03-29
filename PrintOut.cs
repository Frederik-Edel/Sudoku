using System;

namespace sr
{
    static partial class Sudoku {
        public static void printout(int[,] arr){
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    Console.Write(arr[x,y]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n---------");
        }
    }
}