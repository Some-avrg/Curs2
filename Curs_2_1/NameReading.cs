using System;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class NameReading : Form
    {
        public NameReading()
        {
            InitializeComponent();
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
                
                //write in file there

                Close();
            }
        }
    }
}