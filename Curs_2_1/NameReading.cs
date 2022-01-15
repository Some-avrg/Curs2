using System;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class NameReading : Form
    {
        private Records _Records;
        private int time;
        public NameReading(Records rec, int t)
        {
            InitializeComponent();
            _Records = rec;
            time = t;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == String.Empty)
            {
                MessageBox.Show("Введите имя!!!");
            }
            else
            {
                MessageBox.Show("Entered name: " + textBox1.Text, "Name entering" );
                _Records.AddRecord(textBox1.Text, time);
                _Records.ListOfRecords.Sort(new BestTime());
                Close();
            }
        }
    }
}