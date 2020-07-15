using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolverWindowsForms.Helpers
{
    class SudokuStateManager
    {
        public string GenerateState(int[,] board)
        {
            StringBuilder key = new StringBuilder();

            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int column = 0; column < board.GetLength(1); column++)
                {
                    key.Append(board[row, column]);
                }
            }

            return key.ToString();
        }

        public bool IsSolved(int[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int column = 0; column < board.GetLength(1); column++)
                {
                    if (board[row, column] == 0 || board[row, column].ToString().Length > 1)
                        return false;
                }
            }
            return true;
        }
    }
}
