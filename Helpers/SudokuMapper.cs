using SudokuSolverWindowsForms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolverWindowsForms.Helpers
{
    class SudokuMapper
    {
        public SudokuMap Find(int row, int column)
        {
            SudokuMap sudokuMap = new SudokuMap();
            
            if (row >= 0 && row <= 2)
            {
                sudokuMap.StartRow = 0;

                if (column >=0 && column <= 2)
                    sudokuMap.StartColumn = 0;
                else if (column >= 3 && column <= 5)
                    sudokuMap.StartColumn = 3;
                else if (column >= 6 && column <= 8)
                    sudokuMap.StartColumn = 6;
            }
            else if (row >= 3 && row <= 5)
            {
                sudokuMap.StartRow = 3;

                if (column >= 0 && column <= 2)
                    sudokuMap.StartColumn = 0;
                else if (column >= 3 && column <= 5)
                    sudokuMap.StartColumn = 3;
                else if (column >= 6 && column <= 8)
                    sudokuMap.StartColumn = 6;
            }
            else if (row >= 6 && row <= 8)
            {
                sudokuMap.StartRow = 6;

                if (column >= 0 && column <= 2)
                    sudokuMap.StartColumn = 0;
                else if (column >= 3 && column <= 5)
                    sudokuMap.StartColumn = 3;
                else if (column >= 6 && column <= 8)
                    sudokuMap.StartColumn = 6;
            }

            return sudokuMap;
        }
    }
}
