using SudokuSolverWindowsForms.Helpers;
using SudokuSolverWindowsForms.Strategies;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuSolverWindowsForms
{
    public partial class Form1 : Form
    {

        OpenFileDialog openFile = new OpenFileDialog();
        SudokuMapper sudokuMapper;
        SudokuStateManager sudokuStateManager;
        SudokuSolverEngine sudokuSolverEngine;
        SudokuFileInput sudokuFileInput;
        
        int[,] sudokuBoard;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sudokuMapper = new SudokuMapper();
            sudokuStateManager = new SudokuStateManager();
            sudokuSolverEngine = new SudokuSolverEngine(sudokuStateManager, sudokuMapper);
            sudokuFileInput = new SudokuFileInput();
        }

        private void BtnFileUpload_Click(object sender, EventArgs e)
        {
            openFile.Filter = "Text files (*.txt)|*.txt";
            //openFile.
            if(openFile.ShowDialog() == DialogResult.OK)
            {
                sudokuBoard = sudokuFileInput.ReadFile(openFile.FileName);
                DisplayOnForm(sudokuBoard, 0, "Initial");
                bool isSudokuSolved = sudokuSolverEngine.Solve(sudokuBoard);
                DisplayOnForm(sudokuBoard, 15, "Solved");
                MessageBox.Show(isSudokuSolved ? "You have successfully solved the puzzle" : "Unfortunately current algorithms were not sufficient to solve the sudoku puzzle");

            }
            else
            {
                MessageBox.Show("File was not selected");
                Close();
            }
        }

        public void DisplayOnForm(int[,] board, int position, string title)
        {
            Label[,] labels = new Label[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    labels[i, j] = new Label();
                    labels[i, j].Location = new Point((i + 2 + position) * 30, (j + 4) * 30);
                    labels[i, j].Width = 20;
                    labels[i, j].Height = 20;
                    labels[i, j].ForeColor = Color.White;
                    labels[i, j].BackColor = (board[i, j] == 0) ? Color.Red : Color.Green;
                    labels[i, j].Text = board[i, j].ToString();
                    labels[i, j].TextAlign = ContentAlignment.MiddleCenter;
                    this.Controls.Add(labels[i, j]);
                }
            }

            Label titleForSudoku = new Label();
            titleForSudoku.Location = new Point((position+1) * 30, (position + 50) * 30);
            titleForSudoku.Width = 20;
            titleForSudoku.Height = 20;
            titleForSudoku.ForeColor = Color.Blue;
            titleForSudoku.Text = title;
            titleForSudoku.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(titleForSudoku);
        }
    }
}
