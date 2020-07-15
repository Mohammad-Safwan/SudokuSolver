using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolverWindowsForms.Helpers
{
    class SudokuFileInput
    {
        public int [,] ReadFile(string filePath)
        {
            int[,] sudokuBoard = new int[9, 9];
            try
            {
                string[] sudokuRowsFromFile = File.ReadAllLines(filePath);

                for (int row = 0; row < sudokuRowsFromFile.Length ; row++)
                {
                    string[] rowElements = sudokuRowsFromFile[row].Split('|').Skip(1).Take(9).ToArray();
                    
                    for (int column = 0; column < rowElements.Length ; column++)
                    { 
                        sudokuBoard[row, column] = rowElements[column].Equals(" ") ? 0 : Convert.ToInt32(rowElements[column]);
                    }

                }
            }
            catch (Exception e)
            {
                throw new Exception("Failed to read the given file. Error: \n" + e);
            }
            return sudokuBoard;
        }
    }
}
