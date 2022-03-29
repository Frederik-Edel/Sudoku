using System;

namespace sr
{
    static partial class Sudoku {

        public static bool checkLine(int line, int value, int[,] game) {
            for (int x = 0; x < 9; x++)
                if(game[line, x] == value) 
                    return false;
            return true;
        }
        public static bool checkRow(int row, int value, int[,] game) {
            for (int y = 0; y < 9; y++)
                if(game[y, row] == value) 
                    return false;
            return true;
        }
        public static bool checkBlock(int line, int row, int value, int[,] game) {
            for (int x = 0; x < 3; x++)  {
                if(x == line) continue;
                for (int y = 0; y < 3; y++) {
                    if(y == row) continue;
                    if(game[line - line % 3 + x, row - row % 3 + y] == value) return false;
                }
            }
            return true;
        }
        public static bool check(int line, int row, int value, int[,] game) {
            if(checkLine(line, value, game) && checkRow(row,value, game) && checkBlock(line,row,value, game))
                return true;
            return false;
        }

    }
}