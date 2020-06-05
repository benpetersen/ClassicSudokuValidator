using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku
{
    public interface IBaseSudoku
    {
        string[] GetRawSudokuGrid(string filePath);
        byte[,] ProcessAndValidateRawSudokuGrid(string[] rawGrid);
        bool ValidateGrid(byte[,] grid);
    }
    
}
