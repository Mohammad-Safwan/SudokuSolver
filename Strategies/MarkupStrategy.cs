using SudokuSolverWindowsForms.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolverWindowsForms.Strategies
{
    class MarkupStrategy : IStrategy
    {
        private readonly SudokuMapper _sudokuMapper;

        public MarkupStrategy(SudokuMapper sudokuMapper)
        {
            _sudokuMapper = sudokuMapper;
        }

        public int[,] Solve(int[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int column = 0; column < board.GetLength(1); column++)
                {
                    if (board[row, column] == 0 || board[row, column].ToString().Length > 1)
                    {
                        int possibilitiesRowAndColumn = GetPossibilitiesInRowsAndColumns(board, row, column);
                        int possibilitiesBlock = GetPossibilitiesInBlock(board, row, column);

                        board[row, column] = GetPossibilityIntersection(possibilitiesRowAndColumn, possibilitiesBlock);
                    }
                }
            }

            return board;
        }

        private int GetPossibilitiesInRowsAndColumns(int[,] board, int givenRow, int givenColumn)
        {
            int[] possibilities = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            for (int col = 0; col < 9; col++)
                if (IsValidSingle(board[givenRow, col]))
                    possibilities[board[givenRow, col] - 1] = 0;

            for (int row = 0; row < 9; row++)
                if (IsValidSingle(board[row, givenColumn]))
                    possibilities[board[row, givenColumn] - 1] = 0;

            return Convert.ToInt32(String.Join(String.Empty, possibilities.Select(p => p).Where(p => p != 0)));
        }

        private int GetPossibilitiesInBlock(int[,] board, int givenRow, int givenColumn)
        {
            int[] possibilities = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var sudokuMap = _sudokuMapper.Find(givenRow, givenColumn);

            for (int row = sudokuMap.StartRow ; row <= sudokuMap.StartRow + 2; row++)
            {
                for (int column = sudokuMap.StartColumn ; column <= sudokuMap.StartColumn + 2; column++)
                {
                    if (IsValidSingle(board[row, column]))
                        possibilities[board[row, column] - 1] = 0;
                }
            }

            return Convert.ToInt32(String.Join(String.Empty, possibilities.Select(p => p).Where(p => p != 0)));
        }

        private int GetPossibilityIntersection(int possibilitiesRowAndColumn, int possibilitiesBlock)
        {
            char[] rowsAndColumnElements = possibilitiesRowAndColumn.ToString().ToCharArray();
            char[] blockElements = possibilitiesBlock.ToString().ToCharArray();

            var commonElements = rowsAndColumnElements.Intersect(blockElements);

            return Convert.ToInt32(String.Join(String.Empty, commonElements));
        }

        private bool IsValidSingle(int value)
        {
            return ((value != 0) && (value.ToString().Length < 2));
        }

    }
}
