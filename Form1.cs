using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuSolverWindowsForms
{
    public partial class Form1 : Form
    {
        OpenFileDialog openFile = new OpenFileDialog();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*Label[,] labels = new Label[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    labels[i, j] = new Label();
                    //labels[i, j].Top = 20;
                    //labels[i, j].Left = 30;
                    labels[i, j].Location = new Point((i + 2) * 30, (j + 2) * 30);
                    labels[i, j].Width = 20;
                    labels[i, j].Height = 20;
                    labels[i, j].BackColor = (i >= 0 && i<3 && j>=0 && j<3) ? SystemColors.ActiveCaption : SystemColors.ActiveCaption;
                    labels[i, j].Text = String.Format("{0}", i + j);
                    labels[i, j].TextAlign = ContentAlignment.MiddleCenter;
                    this.Controls.Add(labels[i, j]);
                }
            }*/
        }

        private void BtnFileUpload_Click(object sender, EventArgs e)
        {
            openFile.Filter = "Text files (*.txt)|*.txt";
            //openFile.
            openFile.ShowDialog();
        }
    }
}
