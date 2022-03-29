using System;

namespace sr
{
    class Program
    {
        public static int[,] solution = { };
        static void Main()
        {
            Console.Clear();

            var watch = System.Diagnostics.Stopwatch.StartNew();

            int[,] tmp = Sudoku.create2(51); //52>=x Takes longer, x = 55 normal difficulty 

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            DateTime thisDay = DateTime.Today;
            Console.WriteLine("Needed Time: " + (float)elapsedMs / 1000f + "s.\n\n---------\n");

            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    Console.Write(tmp[x, y]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("---------------------\nLösung:");
            int count = 0;
            int[,] tmp2 = Sudoku.solve(tmp, 0, 0, tmp[0, 0], true, ref count, false);
            Console.ReadKey();
            Sudoku.count = 0;
            Main();
        }
    }
}
