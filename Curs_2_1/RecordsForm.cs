using System;
using System.Data;
using System.Drawing;
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
                    var label = new Label();
                    tableLayoutPanel1.Controls.Add(label, j + 1, i);
                    label.Dock = DockStyle.Fill;
                    label.BackColor = tableLayoutPanel1.BackColor;
                    label.TextAlign = ContentAlignment.MiddleCenter;

                    if (recs.ListOfRecords.Count > i)
                    {
                        if (j == 0) label.Text = recs.ListOfRecords[i].Name;
                        else label.Text = recs.ListOfRecords[i].Time.ToString();
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