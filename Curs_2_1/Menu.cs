using System;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class Menu : Form
    {
        private string nameOfFile = "Records.txt";
        public Records recs = new Records();
        public Menu()
        {
            InitializeComponent();
            recs.ReadRecordsFromFile(nameOfFile);
        }

        private void StartGame(object sender, EventArgs e)
        {
            var game = new Form1(recs);
            Hide();
            game.ShowDialog();
            Show();
            recs.WriteRecordsInFile(nameOfFile);
        }

        private void ViewRecords(object sender, EventArgs e)
        {
            recs.ReadRecordsFromFile(nameOfFile);
            var records = new RecordsForm(recs);
            Hide();
            records.ShowDialog();
            Show();
        }

        private void ExitProgram(object sender, EventArgs e)
        {
            Close();
        }
    }
}