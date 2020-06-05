using System;
using System.IO;
using System.Linq;

namespace Sudoku
{
    public class ClassicSudoku : BaseSudoku
    {
        public string FilePath { get; set; }
        public ClassicSudoku(string filePath)
        {
            FilePath = filePath;
        }
        public override byte[,] ProcessAndValidateRawSudokuGrid(string[] rawGrid)
        {
            if (rawGrid == null || rawGrid.Length != 9)
            {
                //Sudoku grid must have loaded and have 9 rows
                return null;
            }
            var file = new byte[9, 9];
            var y = 0;

            foreach (string rowFromFile in rawGrid)
            {
                //Validate each row from the file before attempting to put into a more performant data structure
                var row = rowFromFile.Split(",", StringSplitOptions.None).ToList()[0].Split(' ');

                if (row.Length != 9)
                {
                    //Sudoku grid must have 9 columns per row, otherwise it can't be valid
                    return null;
                }

                var x = 0;
                var item = new byte();

                for (var i = 0; i < row.Length; i++)
                {
                    if (String.IsNullOrEmpty(row[i]))
                    {
                        //Sudoku grid must have all values filled out to be valid
                        return null;
                    }
                    else
                    {
                        if (!byte.TryParse(row[i], out item) && item >= 1 && item <= 9)
                        {
                            //Sudoku grid must have all integer values between 1 and 9 to be valid
                            return null;
                        }
                        else
                        {
                            file[y, x++] = item; //Add items in correct order 0,1 - 0,2 - 0,3 - 0,4
                        }
                    }
                }
                y++;
            }
            return file;
        }
        public override bool ValidateGrid(byte[,] grid)
        {
            /*
             * Use the grid value as a x cordinate check for each row and column. Essentially.. 
             * Has this value been used before in this row? True or False. 
             * Has this value been used before in this column? True or False
             * If it already been used, then the grid isn't valid
             *It's not technically the fastest method of determining sudoku but it's readable and maintainable
             */
            if (grid == null)
            {
                return false;
            }
            for (int x = 0; x < 9; x++)
            {
                bool[] row = new bool[10];
                bool[] col = new bool[10];
                
                for (int y = 0; y < 9; y++)
                {
                    if (row[grid[x, y]])
                    {
                        return false;
                    }
                    
                    row[grid[x, y]] = true;

                    if (col[grid[y, x]])
                    {
                        return false;
                    }
                    col[grid[y, x]] = true;

                    //Check the squares as needed
                    if ((x + 3) % 3 == 0 && (y + 3) % 3 == 0)
                    {
                        bool[] sqr = new bool[10];
                        for (int m = x; m < x + 3; m++)
                        {
                            for (int n = y; n < y + 3; n++)
                            {
                                if (sqr[grid[m, n]])
                                {
                                    return false;
                                }
                                sqr[grid[m, n]] = true;
                            }
                        }
                    }

                }
            }
            return true;
        }
    }
}
