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
        private const int GridSize = 25;
        private MapFunction Grid { get; set; }
        private Shape CurrentShape { get; set; }
        private GameLogicFunction Logic { get; set; }
        private int[,] Map { get; } = new int[16, 8];

        public Form1()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            Grid = new MapFunction(GridSize, Map);
            CurrentShape = new LShape(3, 0);
            Logic = new GameLogicFunction(CurrentShape, Map);

            this.KeyUp += new KeyEventHandler(Keyfunc);
            timer1.Stop();
            timer1.Interval = 1000;
            timer1.Tick += new EventHandler(Update);
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
                        CurrentShape.MoveLeft();
                    }

                    Logic.Merge();
                    Invalidate();
                    break;

                case Keys.D:
                    Logic.ResetArea();
                    if (Logic.CheckWall(1) == 0)
                    {
                        CurrentShape.MoveRight();
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
                        CurrentShape.MoveDown();
                    }

                    Logic.Merge();
                    Invalidate();
                    break;

                case Keys.W:
                    Logic.ResetArea();
                    CurrentShape.TurnArround();
                    Logic.Merge();
                    Invalidate();
                    break;
            }
        }

        private void Update(object sender, EventArgs e)
        {
            Logic.ResetArea();

            if (Logic.CheckWall() == 0)
            {
                CurrentShape.MoveDown();
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
            Grid.DrawGrid(e.Graphics);
            Grid.DrawMap(e.Graphics);
        }
    }
}
