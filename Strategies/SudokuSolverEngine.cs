using SudokuSolverWindowsForms.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolverWindowsForms.Strategies
{
    class SudokuSolverEngine
    {
        private readonly SudokuStateManager _sudokuStateManager;
        private readonly SudokuMapper _sudokuMapper;

        public SudokuSolverEngine(SudokuStateManager stateManager, SudokuMapper sudokuMapper)
        {
            _sudokuStateManager = stateManager;
            _sudokuMapper = sudokuMapper;
        }

        public bool Solve(int[,] board)
        {
            List<IStrategy> strategies = new List<IStrategy>()
            {
                new MarkupStrategy(_sudokuMapper),
                new NakedPairStrategy(_sudokuMapper)
            };

            var currentState = _sudokuStateManager.GenerateState(board);
            var nextState = _sudokuStateManager.GenerateState(strategies.First().Solve(board));

            while ((! _sudokuStateManager.IsSolved(board)) && (currentState != nextState))
            {
                currentState = nextState;

                foreach (var strategy in strategies)
                    nextState = _sudokuStateManager.GenerateState(strategy.Solve(board));
                
            }

            return _sudokuStateManager.IsSolved(board);
        }
    }
}
