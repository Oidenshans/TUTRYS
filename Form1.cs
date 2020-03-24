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

        GameLogicFunction Logic;

        
       
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
            
            Draw = new MapFunction(size, map);

            RandomizeFigure();

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
       
        private void RandomizeFigure()
        {
            Random rnd = new Random();

            int FigureType = rnd.Next(0, 3);

            switch (FigureType)
            {
                case 0:

                    ShapeLine currentShape0 = new ShapeLine(3, 0);

                    Logic = new GameLogicFunction(currentShape0, map);

                    break;

                case 1:
                    
                    ShapeZigZag currentShape1 = new ShapeZigZag(3, 0);

                    Logic = new GameLogicFunction(currentShape1, map);

                    break;

                case 2:

                    ShapeRectangle currentShape2 = new ShapeRectangle(3, 0);

                    Logic = new GameLogicFunction(currentShape2, map);

                    break;

                case 3:

                    ShapeLtype currentShape3 = new ShapeLtype(3, 0);

                    Logic = new GameLogicFunction(currentShape3, map);

                    break;

            }
        }


    }
     
    
}
