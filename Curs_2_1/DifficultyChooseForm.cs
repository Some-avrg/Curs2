using System;
using System.Windows.Forms;

namespace Curse_2_1
{
    public partial class DifficultyChooseForm : Form
    {
        private static int _difficulty = -2;
        
        public DifficultyChooseForm()
        {
            InitializeComponent();
        }

        private void EasyMode_Click(object sender, EventArgs e)
        {
            _difficulty = 0;
            Close();
        }

        private void MediumMode_Click(object sender, EventArgs e)
        {
            _difficulty = 1;
            Close();
        }

        private void HardMode_Click(object sender, EventArgs e)
        {
            _difficulty = 2;
            Close();
        }

        public int GetDifficulty()
        {
            return _difficulty;
        }
    }
}