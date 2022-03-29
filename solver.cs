using System;

namespace sr
{
    static partial class Sudoku {
        public static int count = 0;
        public static int[,] solve(int[,] field, int px, int py, int value, bool printout, ref int count, bool stopOnOne) {

            if(stopOnOne)if(count > 0) return field;

            int[,] workerField = new int[9,9];
            Array.Copy(field,workerField,field.Length);
            workerField[px,py] = value;
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    if (workerField[x,y] == 0)
                    {
                        for (int val = 1; val <= 9; val++)
                        {
                            if(check(x,y,val,workerField))
                                solve(workerField,x,y, val, printout, ref count,stopOnOne);
                        }
                        return null;
                    }
                }
            }
            if(printout) {
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    Console.Write(workerField[x,y]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("---------");
            }
            count++;
            //Sudoku.outputField = workerField;
            Array.Copy(workerField,Sudoku.outputField,workerField.Length);
            return workerField;
        }
    }
}