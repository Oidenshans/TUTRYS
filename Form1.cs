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

        MapFunction Draw;

        GameLogicFunction Logic { get; set; }

        const int size = 25;
        const int width = 8;
        const int height = 16;

        int[,] map = new int[height, width];

        public Form1()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {


            Shape currentShape = RandomFigure.GetRandomFigure();

            Draw = new MapFunction(size, map);
            Logic = new GameLogicFunction(currentShape, map);

            timer1.Interval = 1000;

            timer1.Tick += new EventHandler(Update);

            timer1.Start();

            Invalidate();
        }


        private void Update(object sender, EventArgs e)
        {

            Logic.DownDrive();

            //  timer1.Tick -= new EventHandler(Update);

            //Init();

            //Logic.CutLine();

            Invalidate();

        }

        private void Form1KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.A:

                    // Движение фигуры влево
                    Logic.LeftDrive();

                    Invalidate();

                    break;

                case Keys.D:

                    // Движение фигуры вправо
                    Logic.RightDrive();

                    Invalidate();

                    break;


                case Keys.S:

                    // Увеличение скорости падения фигуры
                    if (timer1.Interval > 10)
                    {
                        timer1.Interval -= timer1.Interval - timer1.Interval / 2;
                    }

                    break;


                case Keys.W:

                    // Переворот фигуры
                    Logic.TurnArrounDrive();

                    Invalidate();

                    break;
            }

        }


        private void OnPaint(object sender, PaintEventArgs e)
        {

            Draw.DrawGrid(e.Graphics);

            Draw.DrawMap(e.Graphics);

        }



    }


}
