using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuSolverWindowsForms.Helpers
{
    class SudokuDisplay
    {
        public void Display(string title, int[,] board)
        {
            if (!title.Equals(string.Empty))
                Console.WriteLine(title + Environment.NewLine);

            for (int row = 0; row < board.GetLength(0) ; row++)
            {
                Console.Write('|');

                for (int column = 0; column < board.GetLength(1) ; column++)
                {
                    Console.Write(board[row, column] + "|");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

    }
}
