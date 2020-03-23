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

        Shape currentShape;
        MapFunction Grid1;
        GameLogicFunction Logic;

        int size;
        int[,] map = new int[16, 8];

        public Form1()
        {

            InitializeComponent();
            this.KeyUp += new KeyEventHandler(Keyfunc);
            Init();
        }

        public void Init()
        {
            size = 25;


            Grid1 = new MapFunction(size, map);
            currentShape = new Shape(3, 0);
            Logic = new GameLogicFunction(currentShape, map);
            //this.KeyUp += new KeyEventHandler(Keyfunc);
            timer1.Stop();
            timer1.Interval = 1000;
            timer1.Tick += new EventHandler(update);
            timer1.Start();
            Invalidate();
        }

        private void Keyfunc(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    Logic.ResetArea();
                    if (Logic.CheckWall(-1) == 0)
                    {
                        currentShape.MoveLeft();
                    }
                    Logic.Merge();
                    Invalidate();
                    break;
                case Keys.D:
                    Logic.ResetArea();

                    if (Logic.CheckWall(1) == 0)
                    {
                        currentShape.MoveRight();
                    }

                    Logic.Merge();
                    Invalidate();
                    break;

                case Keys.S:
                    if (timer1.Interval > 10)
                    {
                        timer1.Interval -= timer1.Interval - timer1.Interval / 2;
                    }

                    Logic.ResetArea();

                    if (Logic.CheckWall() == 0)
                    {
                        currentShape.MoveDown();
                    }

                    Logic.Merge();
                    Invalidate();
                    break;


                case Keys.W:
                    Logic.ResetArea();
                    currentShape.TurnArround();
                    Logic.Merge();
                    Invalidate();
                    break;
            }
        }

        private void update(object sender, EventArgs e)
        {

            Logic.ResetArea();

            if (Logic.CheckWall() == 0)
            {
                currentShape.MoveDown();
                Logic.Merge();
            }
            else
            {
                Logic.ChangeColor();
            }





            Invalidate();
        }


        private void OnPaint(object sender, PaintEventArgs e)
        {


            Grid1.DrawGrid(e.Graphics);
            Grid1.DrawMap(e.Graphics);



        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
     
    
}
