using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RougeLike
{
    public partial class Form1 : Form
    {
        int _point = 0;
        private PictureBox[] enemy = new PictureBox[400];
        private int[] enemyHP = new int[400];
        public Form1()
        {

            InitializeComponent();
            this.KeyDown += new KeyEventHandler(WASD);
            //враг
            enemy[0] = new PictureBox();
            enemy[0].BackColor = Color.Gray;
            enemy[0].Size = new Size(20, 40);
            enemy[0].Location = new Point(100, 100);
            enemyHP[0] = 2;
            //отоброжение врага
            this.Controls.Add(enemy[0]);
            //таймер
            timer.Tick += new EventHandler(_update);
            timer.Interval = 1;
            timer.Start();
        }
        
        //движение врага
        public void _update(Object ObjectEnemy, EventArgs eventAgr)
        {
            for (int i = _point; i >= 0; --i)
            {
                // Следование
                if(enemyHP[i] == 2)
                {
                    // X
                    if (enemy[i].Location.X > _knight.Location.X)
                    {
                        enemy[i].Location = new Point(enemy[i].Location.X - 2, enemy[i].Location.Y);
                    }
                    else if (enemy[i].Location.X < _knight.Location.X)
                    {
                        enemy[i].Location = new Point(enemy[i].Location.X + 2, enemy[i].Location.Y);
                    }
                    // Y
                    if (enemy[i].Location.Y > _knight.Location.Y)
                    {
                        enemy[i].Location = new Point(enemy[i].Location.X, enemy[i].Location.Y - 2);
                    }
                    else if (enemy[i].Location.Y < _knight.Location.Y)
                    {
                        enemy[i].Location = new Point(enemy[i].Location.X, enemy[i].Location.Y + 2);
                    }
                }
                // Побег
                if (enemyHP[i] == 1)
                {
                    // X
                    if (enemy[i].Location.X > _knight.Location.X)
                    {
                        enemy[i].Location = new Point(enemy[i].Location.X + 1, enemy[i].Location.Y);
                    }
                    else if (enemy[i].Location.X < _knight.Location.X)
                    {
                        enemy[i].Location = new Point(enemy[i].Location.X - 1, enemy[i].Location.Y);
                    }
                    // Y
                    if (enemy[i].Location.Y > _knight.Location.Y)
                    {
                        enemy[i].Location = new Point(enemy[i].Location.X, enemy[i].Location.Y + 1);
                    }
                    else if (enemy[i].Location.Y < _knight.Location.Y)
                    {
                        enemy[i].Location = new Point(enemy[i].Location.X, enemy[i].Location.Y - 1);
                    }
                }
            }
        }
        //движение персонажа
        private void WASD(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "D":
                    _knight.Location = new Point(_knight.Location.X + 50, _knight.Location.Y);
                    break;
                case "A":
                    _knight.Location = new Point(_knight.Location.X - 50, _knight.Location.Y);
                    break;
                case "W":
                    _knight.Location = new Point(_knight.Location.X, _knight.Location.Y - 50);
                    break;
                case "S":
                    _knight.Location = new Point(_knight.Location.X, _knight.Location.Y + 50);
                    break;
            }
        }
    }
}