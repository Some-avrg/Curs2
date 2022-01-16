using System;
using System.Drawing;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace Sudoku
{
    public partial class Form1 : Form
    {
        private const int N = 3;
        private const int SizeButton = 50;
        private bool _isNoteMode = false;
        private int Difficulty = -1;  //0 - easy, 1 - medium, 2 - hard
         
        private Records recordsList;
        private int[,] map = new int[N * N, N * N];             //map of game
        private Button[,] buttons = new Button[N * N, N * N];   //clickable buttons
        private Timer tm = null; 
        private int _startValue = 0; // time control
        public Form1(Records rec)
        {
            InitializeComponent();
            
            var difChoose = new DifficultyChooseForm();
            difChoose.ShowDialog();
            Difficulty = difChoose.GetDifficulty();
            
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
            _startValue++;
            label1.Text = Int2StringTime(_startValue);
        }

        private void GenerateMap()    
        {
            for(int i = 0; i < N * N; i++)
            {
                for(int j = 0; j < N * N; j++)
                {
                    map[i, j] = (i * N + i / N + j) % (N * N) + 1;
                }
            }
            var r = new Random();
            for(var i = 0; i < 500; i++)
            {
                ShuffleMap(r.Next(0, 5));
            }
           
            CreateMap();
            HideCells();
        }

        private void HideCells()
        {
            var countOfHiddenCells = 20 + 7 * Difficulty;
            var r = new Random();
            
            while (countOfHiddenCells > 0)  //choose buttons, which will be interactive
            {
                //if a==0 then button is enabled and text is covered 
                var i = r.Next(0, N * N);
                var j = r.Next(0, N * N);
                
                if (buttons[i, j].Text != String.Empty)
                {
                    buttons[i, j].Text = "" ;
                    countOfHiddenCells--;
                }
            }

            foreach (var button in buttons)  //coloring buttons
            {
                if (button.Text != String.Empty)
                {
                    button.Enabled = false;
                    button.BackColor = Color.Bisque;
                }
                else button.BackColor = Color.Azure;
            }
        }
        private void ShuffleMap(int i)  //randomizing map
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

        private void SwapBlocksInColumn()
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

        private void SwapBlocksInRow()
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
        
        private void SwapRowsInBlock()
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

        private void SwapColumnsInBlock()
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

        private void MatrixTransposition()
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

        private void CreateMap()   //put buttons on screen
        {
            for (var i = 0; i < N * N; i++)
            {
                for (var j = 0; j < N * N; j++)
                {
                    var button = new Button();
                    buttons[i, j] = button;
                    button.Name = i.ToString() + j.ToString(); //to know what exactly button is pressed
                    button.Size = new Size(SizeButton, SizeButton);
                    button.Text = map[i, j].ToString();
                    button.Click += OnCellPressed;
                    button.Location = new Point(j * SizeButton, i * SizeButton);
                    this.Controls.Add(button);
                }
            }
        }
        
        private void OnCellPressed(object sender, EventArgs e)  //button click handling
        {
            var pressedButton = sender as Button;
            if (!_isNoteMode && pressedButton.BackColor != Color.Aqua)
            {
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
                if (pressedButton.BackColor == Color.Red) pressedButton.BackColor = Color.Snow;
            }

            if (_isNoteMode) //no mistakes mode
            {
                //changing color of button and noteButton
                pressedButton.BackColor = pressedButton.BackColor == Color.Aqua ? Color.Azure : Color.Aqua;
                NoteButton_Click(this.NoteButton, EventArgs.Empty);  
                
                
                if (Difficulty == 0 && pressedButton.Text != "")
                {
                    //get position of pressed button on the map
                    var i = Int32.Parse(pressedButton.Name) / 10;
                    var j = Int32.Parse(pressedButton.Name) % 10;
                    var boxI = i / 3;
                    var boxJ = j / 3;
                    
                    if (pressedButton.BackColor != Color.Aqua) 
                    {
                        //cancel checking for mistakes in lines
                        for (var k = 0; k < N * N; k++)
                        {
                            if (buttons[i, k].BackColor == Color.Red)
                            {
                                if (buttons[i, k].Enabled) buttons[i, k].BackColor = Color.Azure;
                                else buttons[i, k].BackColor = Color.Bisque;
                            }
                            if (buttons[k, j].BackColor == Color.Red)
                            {
                                if (buttons[k, j].Enabled) buttons[k, j].BackColor = Color.Azure;
                                else buttons[k, j].BackColor = Color.Bisque;
                            }
                        }
                        //cancel checking for mistakes in box
                        for (var m = boxI * N; m < boxI * N + N; m++)
                        {
                            for (var n = boxJ * N; n < boxJ * N + N; n++)
                            {
                                if (n == j && m == i) continue;
                                if (buttons[m, n].Enabled) buttons[m, n].BackColor = Color.Snow;
                                else buttons[m, n].BackColor = Color.Bisque;
                            }
                        }
                    }
                    else
                    {
                        //looking for mistakes in lines 
                        for (var k = 0; k < N * N; k++)
                        {
                            if (buttons[i, k].Text == pressedButton.Text && k != j) buttons[i, k].BackColor = Color.Red;
                            if (buttons[k, j].Text == pressedButton.Text && k != i) buttons[k, j].BackColor = Color.Red;
                        }
                        //looking for mistakes in box
                        for (var m = boxI * N; m < boxI * N + N; m++)
                        {
                            for (var n = boxJ * N; n < boxJ * N + N; n++)
                            {
                                if (n == j && m == i) continue;
                                if (buttons[m, n].Text == buttons[i, j].Text) buttons[m, n].BackColor = Color.Red;
                            }
                        }
                        
                    }
                }
            }

        }

        private void CheckButton_Click(object sender, EventArgs e)  //Check if solution is right
        {
            for(int i = 0; i < N * N; i++)
            {
                for(int j = 0; j < N * N; j++)
                {
                    var btnText = buttons[i, j].Text;
                    if(btnText != map[i, j].ToString())
                    {
                        MessageBox.Show("There are still some mistakes");
                        return;
                    }
                }
            }
            MessageBox.Show("Correct!");
            tm.Stop();
            var nameReading = new NameReading(recordsList, _startValue);
            nameReading.ShowDialog();
            Close();
            
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void NoteButton_Click(object sender, EventArgs e)  //switch note mode
        {
            var pressedButton = sender as Button;
            _isNoteMode = !_isNoteMode;
            if(_isNoteMode) pressedButton.BackColor = Color.Crimson;
            else pressedButton.BackColor = Color.Snow;
        }
    }
}