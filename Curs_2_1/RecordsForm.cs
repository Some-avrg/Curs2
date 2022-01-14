using System;
using System.Data;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class RecordsForm : Form
    {

        public RecordsForm(Records listRec)
        {
            InitializeComponent();
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    TextBox textBox = new TextBox();
                    tableLayoutPanel1.Controls.Add(textBox, i + 1, j);
                    textBox.Multiline = true;
                    textBox.Dock = DockStyle.Fill;
                    textBox.BackColor = tableLayoutPanel1.BackColor;
                    textBox.ReadOnly = true;
                    textBox.Text = "Test text" + j;
                }
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }



}