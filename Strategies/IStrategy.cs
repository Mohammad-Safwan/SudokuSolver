using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolverWindowsForms.Strategies
{
    interface IStrategy
    {
        int[,] Solve(int[,] board);
    }
}
