using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Threading;

namespace TUTRYS

{

    public partial class Form1 : Form
    {

        MapPaint Draw;

        GameLogicFunction Logic { get; set; }

        const int sizeCell = 25;
        const int width = 8; 
        const int height = 16;
        int score = 0;

        int[,] map = new int[height, width];
        readonly Region region = new Region(new Rectangle(0, 0, 400, 600));

        public Form1()
        {
            InitializeComponent();                            
            ScoreLabel.Text = "0";
            Init();          
        }

        public void Init()
        {
            Shape currentShape = RandomFigure.GetRandomFigure(); // Создание случайной фигуры
            Draw = new MapPaint(sizeCell, map);
            Logic = new GameLogicFunction(currentShape, map);
            timer1.Interval = 1000;         
            timer1.Tick += new EventHandler(Update);                    
            Invalidate(region);          
        }


        private void Update(object sender, EventArgs e)
        {

            int endMap=Logic.DownDrive();
            if (endMap==1)
            {
                Logic.DownPlaceAction(out int scoreCount, out int endGame);               
                score += scoreCount;
                ScoreLabel.Text = $"{score}";
                if (endGame == 1)
                {
                    timer1.Stop();
                    FinishGame(score);
                }
                else
                {
                    timer1.Tick -= new EventHandler(Update);
                    Init();
                }                                                        
            }
            Invalidate(region);

        }

        private void Form1KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.A:
                    // Движение фигуры влево
                    Logic.LeftDrive();
                    Invalidate(region);

                    break;
                case Keys.D:
                    // Движение фигуры вправо                 
                    Logic.RightDrive();
                    Invalidate(region);

                    break;
                case Keys.S:
                    // Увеличение скорости падения фигуры
                    if (timer1.Interval > 10)
                    {
                        timer1.Interval -= timer1.Interval / 2;
                    }
                    break;
                case Keys.W:
                    // Переворот фигуры
                    Logic.TurnArrounDrive();
                    Invalidate(region);

                    break;
            }

        }


        private void OnPaint(object sender, PaintEventArgs e)
        {
            Draw.DrawGrid(e.Graphics); // Отрисовка Сетки 
            Draw.DrawMap(e.Graphics); //  Отрисовка Карты

        }

        private void BeginGame()
        {
            DialogResult result = MessageBox.Show(
                "START GAME",
                "TUTRYS GAME",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);

            if (result == DialogResult.OK)
            {
                timer1.Start();
               
            }
            else
            {
                Close();
            }
             
            
        }

        private void FinishGame(int count)
        {
            DialogResult result = MessageBox.Show(
                $"Начать новую игру? Ваш счет {count}",
                "GAME OVER",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);

            if (result == DialogResult.Yes)
            {
                Application.Restart();
                
            }
            else
            {
                Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BeginGame();
        }
    }
}
