using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Curse_2_1
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
                        else
                        {
                            var time = recs.ListOfRecords[i].Time;
                            var hours = (time - (time % (60 * 60))) / (60 * 60);
                            var minutes = (time - time % 60) / 60 - hours * 60;
                            var seconds = time - hours * 60 * 60 - minutes * 60;
                            label.Text = String.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
                        }
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