using System;
using System.IO;

namespace Sudoku
{
    public abstract class BaseSudoku : IBaseSudoku
    {
        public virtual string[] GetRawSudokuGrid(string filePath){
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                string fileContents = "";

                //Open the file
                using (StreamReader oStreamReader = new StreamReader(File.OpenRead(filePath)))
                {
                    fileContents = oStreamReader.ReadToEnd();
                }

                string[] gridFromFile = fileContents.Trim().Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries); //Allow empty lines before or after grid

                return gridFromFile;

            }
            catch (Exception ex)
            {
                //Outputting the file path to help fix testing issues
                Console.WriteLine("File not found: {0}", filePath);
                return null;
            }
        }
        public abstract byte[,] ProcessAndValidateRawSudokuGrid(string[] rawGrid);
        public abstract bool ValidateGrid(byte[,] grid);
    }
}
