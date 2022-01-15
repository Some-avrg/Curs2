using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class RecordsForm : Form
    {

        public RecordsForm(Records recs)
        {
            InitializeComponent();
            for (var i = 0; i < 5; i++)
            {
                for (var j = 0; j < 2; j++)
                {
                    TextBox textBox = new TextBox();
                    tableLayoutPanel1.Controls.Add(textBox, j + 1, i);
                    textBox.Multiline = true;
                    textBox.Dock = DockStyle.Fill;
                    textBox.BackColor = tableLayoutPanel1.BackColor;
                    textBox.ReadOnly = true;
                    if (recs.ListOfRecords.Count > i)
                    {
                        if (j == 0) textBox.Text = recs.ListOfRecords[i].Name;
                        else textBox.Text = recs.ListOfRecords[i].Time.ToString();
                    }
                }
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }



}