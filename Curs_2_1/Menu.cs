using System;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void StartGame(object sender, EventArgs e)
        {
            var game = new Form1();
            Hide();
            game.ShowDialog();
            Show();
        }

        private void ViewRecords(object sender, EventArgs e)
        {
            var records = new RecordsForm(null);
            Hide();
            records.ShowDialog();
            Show();
        }
    }
}