using SudokuSolverWindowsForms.Helpers;
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
        int[,] sudokuBoard;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /**/
        }

        private void BtnFileUpload_Click(object sender, EventArgs e)
        {
            openFile.Filter = "Text files (*.txt)|*.txt";
            //openFile.
            if(openFile.ShowDialog() == DialogResult.OK)
            {
                SudokuFileInput sudokuFileInput = new SudokuFileInput();
                sudokuBoard = sudokuFileInput.ReadFile(openFile.FileName);
                //MessageBox.Show(sudokuBoard[0,0].ToString() + " " + sudokuBoard[7,7].ToString());
                DisplayOnForm(sudokuBoard, 15);
            }
            else
            {
                MessageBox.Show("File was not selected");
                Close();
            }
        }

        public void DisplayOnForm(int[,] board, int position)
        {
            Label[,] labels = new Label[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    labels[i, j] = new Label();
                    labels[i, j].Location = new Point((i + 2 + position) * 30, (j + 2) * 30);
                    labels[i, j].Width = 20;
                    labels[i, j].Height = 20;
                    labels[i, j].ForeColor = Color.White;
                    labels[i, j].BackColor = (board[i, j] == 0) ? Color.Red : Color.Green;
                    labels[i, j].Text = board[i, j].ToString();
                    labels[i, j].TextAlign = ContentAlignment.MiddleCenter;
                    this.Controls.Add(labels[i, j]);
                }
            }
        }
    }
}
