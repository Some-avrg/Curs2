using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace Sudoku
{
    public partial class Form1 : Form
    {
        const int N = 3;
        const int SizeButton = 50;
        private Records recordsList;
        public int[,] map = new int[N * N, N * N];             //map of game
        public Button[,] buttons = new Button[N * N, N * N];   //clickable buttons
        private Timer tm = null; 
        private int _startValue = 0; // time control
        public Form1(Records rec)
        {
            InitializeComponent();
            GenerateMap();
            recordsList = rec;
            tm = new Timer();
            tm.Tick += new EventHandler(tm_Tick); //refresh timer every second
            tm.Interval = 1000;
            tm.Start();
        }
        
        private string Int2StringTime(int time) 
        {
            int hours = (time - (time % (60 * 60))) / (60 * 60);
            int minutes = (time - time % 60) / 60 - hours * 60;
            int seconds = time - hours * 60 * 60 - minutes * 60;
            return String.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
        }

        void tm_Tick(object sender, EventArgs e)
        {
            label1.Text = Int2StringTime(_startValue);
            _startValue++;
        }

        public void GenerateMap()
        {
            for(int i = 0; i < N * N; i++)
            {
                for(int j = 0; j < N * N; j++)
                {
                    map[i, j] = (i * N + i / N + j) % (N * N) + 1;
                    buttons[i, j] = new Button();
                }
            }
            Random r = new Random();
            for(int i = 0; i < 400; i++)
            {
                ShuffleMap(r.Next(0, 5));
            }
           
            CreateMap();
            HideCells();
        }

        public void HideCells()
        {
            int CountOfHiddenCells = 1;
            Random r = new Random();
            for (int i = 0; i < N * N; i++)
            {
                for (int j = 0; j < N * N; j++)
                {
                    if (!string.IsNullOrEmpty(buttons[i, j].Text))
                    {
                        if (CountOfHiddenCells > 0)
                        {
                            int a = r.Next(0, 3);  //for difficulty it should be changed
                            //if a==0 then button is enabled and text is covered 
                            buttons[i, j].Text = (a == 0) ? "" : buttons[i, j].Text;
                            if (a == 0)
                                CountOfHiddenCells--;
                        }

                        if(buttons[i, j].Text != String.Empty)
                            buttons[i, j].Enabled = false;
                    }
                }
            }
        }
        public void ShuffleMap(int i)  //randomizing map
        {
            switch (i)
            {
                case 0:
                    MatrixTransposition();
                    break;
                case 1:
                    SwapRowsInBlock();
                    break;
                case 2:
                    SwapColumnsInBlock();
                    break;
                case 3:
                    SwapBlocksInRow();
                    break;
                case 4:
                    SwapBlocksInColumn();
                    break;
                default:
                    MatrixTransposition();
                    break;
            }
        }

        public void SwapBlocksInColumn()
        {
            Random r = new Random();
            var block1 = r.Next(0, N);
            var block2 = r.Next(0, N);
            while (block1 == block2)
                block2 = r.Next(0, N);
            block1 *= N;
            block2 *= N;
            for (int i = 0; i < N * N; i++)
            {
                var k = block2;
                for (int j = block1; j < block1 + N; j++)
                {
                    var temp = map[i,j];
                    map[i,j] = map[i,k];
                    map[i,k] = temp;
                    k++;
                }
            }
        }

        public void SwapBlocksInRow()
        {
            Random r = new Random();
            var block1 = r.Next(0, N);
            var block2 = r.Next(0, N);
            while (block1 == block2)
                block2 = r.Next(0, N);
            block1 *= N;
            block2 *= N;
            for(int i = 0; i < N * N; i++)
            {
                var k = block2;
                for(int j = block1; j < block1 + N; j++)
                {
                    var temp = map[j, i];
                    map[j, i] = map[k, i];
                    map[k, i] = temp;
                    k++;
                }
            }
        }
        
        public void SwapRowsInBlock()
        {
            Random r = new Random();
            var block = r.Next(0, N);
            var row1 = r.Next(0, N);
            var line1 = block * N + row1;
            var row2 = r.Next(0, N);
            while (row1 == row2)
                row2 = r.Next(0, N);
            var line2 = block * N + row2;
            for(int i = 0; i < N * N; i++)
            {
                var temp = map[line1, i];
                map[line1, i] = map[line2, i];
                map[line2, i] = temp;
            }
        }

        public void SwapColumnsInBlock()
        {
            Random r = new Random();
            var block = r.Next(0, N);
            var row1 = r.Next(0, N);
            var line1 = block * N + row1;
            var row2 = r.Next(0, N);
            while (row1 == row2)
                row2 = r.Next(0, N);
            var line2 = block * N + row2;
            for (int i = 0; i < N * N; i++)
            {
                var temp = map[i,line1];
                map[ i, line1] = map[i,line2];
                map[i,line2] = temp;
            }
        }

        public void MatrixTransposition()
        {
            int[,] tMap = new int[N * N, N * N];
            for(int i = 0; i < N * N; i++)
            {
                for(int j = 0; j < N * N; j++)
                {
                    tMap[i, j] = map[j, i];
                }
            }
            map = tMap;
        }

        public void CreateMap()
        {
            for (int i = 0; i < N * N; i++)
            {
                for (int j = 0; j < N * N; j++)
                {
                    Button button = new Button();
                    buttons[i, j] = button;
                    button.Size = new Size(SizeButton, SizeButton);
                    button.Text = map[i, j].ToString();
                    button.Click += OnCellPressed;
                    button.Location = new Point(j * SizeButton, i * SizeButton);
                    this.Controls.Add(button);
                }
            }
        }

        public void OnCellPressed(object sender, EventArgs e)
        {
            Button pressedButton = sender as Button;
            string buttonText = pressedButton.Text;
            if (string.IsNullOrEmpty(buttonText))
            {
                pressedButton.Text = "1";
            }
            else
            {
                int num = int.Parse(buttonText);
                num++;
                if (num == 10)
                    num = 1;
                pressedButton.Text = num.ToString();
            }

        }

        private void CheckButton_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < N * N; i++)
            {
                for(int j = 0; j < N * N; j++)
                {
                    var btnText = buttons[i, j].Text;
                    if(btnText != map[i, j].ToString())
                    {
                        MessageBox.Show("Неверно!");
                        return;
                    }
                }
            }
            MessageBox.Show("Верно!");
            tm.Stop();
            var nameReading = new NameReading(recordsList, _startValue);
            nameReading.ShowDialog();
            Close();
            
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

       
    }
}