using System;

namespace sr
{
    static partial class Sudoku {

        public static Random random = new Random();
        public static int[,] outputField = new int[9,9];
        public static int[,] create2(int fieldsLeft) {
            int[,] inputField = new int[9,9];
            int count = 0;
            
            for (int i = 0; i < 16; i++)
            {
                int posx1 = random.Next(0,9);
                int posy1 = random.Next(0,9);
                int val = random.Next(1,10);
                if (inputField[posx1,posy1] == 0)
                {
                    if(Sudoku.check(posx1,posy1,val,inputField))
                        inputField[posx1,posy1] = val;
                    else
                        i--;
                }else i--;
            }
            Sudoku.solve(inputField,0,0,inputField[0,0],false, ref count,true);
            int[,] tmp = new int[9,9];
            Array.Copy(outputField,tmp,outputField.Length);
            //Sudoku.printout(tmp); //print solution
            int[,] solution = new int[9,9];
            Array.Copy(tmp,solution,solution.Length);
            Array.Copy(tmp,Program.solution, Program.solution.Length);

            spaces:
            Array.Copy(solution,tmp,tmp.Length);
            count = 0;
            for (int i = 0; i < fieldsLeft; i++)
            {
                int posx = random.Next(0,9);
                int posy = random.Next(0,9);
                if(tmp[posx,posy] == 0){ i--; continue;}
                tmp[posx,posy] = 0;
                count = 0;
                Sudoku.solve(tmp,0,0,tmp[0,0],false,ref count, false);

                if(count == 1) Array.Copy(tmp,outputField,tmp.Length);
                else {
                    Array.Copy(outputField,tmp,outputField.Length);
                    i--;
                }
                
            }
            int zeros = 0;
            for (int i = 0; i < 9; i++)
            {
                for (int y = 0; y < 9; y++)
                {
                    if(outputField[i,y] == 0) zeros++;
                }
            }
            if(zeros != fieldsLeft) {
                goto spaces;
            }

            Console.WriteLine("\nDifficulty: " + zeros);
            return outputField;
        }
    }
}