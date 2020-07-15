using SudokuSolverWindowsForms.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolverWindowsForms.Strategies
{
    class NakedPairStrategy : IStrategy
    {
        private readonly SudokuMapper _sudokuMapper;

        public NakedPairStrategy(SudokuMapper sudokuMapper)
        {
            _sudokuMapper = sudokuMapper;
        }

        public int[,] Solve(int[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int column = 0; column < board.GetLength(1); column++)
                {
                    EliminateNakedPairsInRows( board, row, column );
                    EliminateNakedPairsInColumns(board, row, column);
                    EliminateNakedPairsInBlock(board, row, column);
                }
            }

            return board;
        }

        private void EliminateNakedPairsInRows(int[,] board, int givenRow, int givenColumn)
        {
            if (!HasNakedPairInRow(board, givenRow, givenColumn)) return;

            for (int column = 0; column < board.GetLength(1) ; column++)
            {
                if (board[givenRow, column] != board[givenRow, givenColumn] && board[givenRow, column].ToString().Length > 1)
                    EliminateNakedPair(board, board[givenRow, givenColumn], givenRow, column);
            }
        }

        private bool HasNakedPairInRow(int[,] board, int givenRow, int givenColumn)
        {
            for (int column = 0; column < board.GetLength(1); column++)
            {
                if (givenColumn != column && IsNakedPAir(board[givenRow, column], board[givenRow, givenColumn]))
                    return true;
            }
            return false;
        }

        private void EliminateNakedPairsInColumns(int[,] board, int givenRow, int givenColumn)
        {
            if (!HasNakedPairInColumns(board, givenRow, givenColumn)) return;

            for (int row = 0; row < board.GetLength(0); row++)
            {
                if (board[row, givenColumn] != board[givenRow, givenColumn] && board[row, givenColumn].ToString().Length > 1)
                    EliminateNakedPair(board, board[givenRow, givenColumn], row, givenColumn);
            }
        }

        private bool HasNakedPairInColumns(int[,] board, int givenRow, int givenColumn)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                if (givenRow != row && IsNakedPAir(board[row, givenColumn], board[givenRow, givenColumn]))
                    return true;
            }
            return false;
        }

        private void EliminateNakedPairsInBlock(int[,] board, int givenRow, int givenColumn)
        {
            if (!HasNakedPairInBlock(board, givenRow, givenColumn)) return;

            var sudokuMap = _sudokuMapper.Find(givenRow, givenColumn);

            for (int row = sudokuMap.StartRow ; row <= sudokuMap.StartRow + 2 ; row++)
            {
                for (int column = sudokuMap.StartColumn ; column <= sudokuMap.StartColumn+2 ; column++)
                {
                    if ((board[row, column].ToString().Length > 1) && (board[row, column] != board[givenRow, givenColumn]))
                        EliminateNakedPair(board, board[givenRow, givenColumn], row, column);
                }
            }
        }

        private bool HasNakedPairInBlock(int[,] board, int givenRow, int givenColumn)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int column = 0; column < board.GetLength(1); column++)
                {
                    var sameElement = row == givenRow && column == givenColumn;
                    var elementInSameBlock = _sudokuMapper.Find(givenRow, givenColumn).StartRow == _sudokuMapper.Find(row, column).StartRow &&
                                            _sudokuMapper.Find(givenRow, givenColumn).StartColumn == _sudokuMapper.Find(row, column).StartColumn;

                    if (!sameElement && elementInSameBlock && IsNakedPAir(board[givenRow, givenColumn], board[row, column]))
                        return true;
                }
            }

            return false;

        }

        private void EliminateNakedPair(int[,] board, int values, int eliminateFromRow, int eliminateFromColumn)
        {
            var valuesToEliminate = values.ToString().ToCharArray();

            foreach (var valueToEliminate in valuesToEliminate)
            {
                board[eliminateFromRow, eliminateFromColumn] = Convert.ToInt32(board[eliminateFromRow, eliminateFromColumn].ToString().Replace(valueToEliminate.ToString(), string.Empty));
            }
        }

        private bool IsNakedPAir(int pair1, int pair2)
        {
            return pair1.ToString().Length == 2 && pair1 == pair2;
        }
    }
}
