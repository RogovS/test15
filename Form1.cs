﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace test15
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Button[] buttons = new Button[16];
        Button startButton = new Button();
        int empty;
        bool restart;

        private static void ShuffleArray<T>(T[] array)
        {
            Random r = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                int randomIndex = r.Next(array.Length);
                T temp = array[i];
                array[i] = array[randomIndex];
                array[randomIndex] = temp;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(370,440);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    buttons[i + j * 4] = new Button();
                    buttons[i + j * 4].Size = new Size(80, 80);
                    buttons[i + j * 4].Font = new Font("Microsoft Sans Serif", 24.0f);
                    buttons[i + j * 4].Location = new Point(10 + 85 * i, 10 + 85 * j);
                    this.Controls.Add(buttons[i + j * 4]);
                    buttons[i + j * 4].Text = (i + 1 + j * 4).ToString();
                }
            }
            buttons[15].Visible = false;
            startButton.Location = new Point(10, 350);
            startButton.Size = new Size(335, 40);
            startButton.Text = "Старт/Рестарт";
            startButton.Font = new Font("Microsoft Sans Serif", 24.0f);
            startButton.Click += new EventHandler(Start_Click);
            this.Controls.Add(startButton);
        }

        private void AutoPlay()
        {
                while (finish() == false)
                {
                    for (int i = 0; i < 16; i++)
                    {
                        if (Math.Abs(buttons[i].Location.X - buttons[empty].Location.X) == 85 &&
                            Math.Abs(buttons[i].Location.Y - buttons[empty].Location.Y) == 0 ||
                            Math.Abs(buttons[i].Location.Y - buttons[empty].Location.Y) == 85 &&
                            Math.Abs(buttons[i].Location.X - buttons[empty].Location.X) == 0)
                        {
                            buttons[i].PerformClick();
                            //break;
                        }
                    }
                }
        }

        private void Start_Click(object sender, EventArgs e)
        {
            int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            ShuffleArray(array);
            for (int i = 0; i < 16; i++)
                this.Controls.Remove(buttons[i]);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    buttons[i + j * 4] = new Button();
                    buttons[i + j * 4].Size = new Size(80, 80);
                    buttons[i + j * 4].Font = new Font("Microsoft Sans Serif", 24.0f);
                    buttons[i + j * 4].Location = new Point(10 + 85 * i, 10 + 85 * j);
                    buttons[i + j * 4].Click += new EventHandler(Buttons_Click);
                    this.Controls.Add(buttons[i + j * 4]);
                    if (array[i + j * 4] == 16)
                    {
                        buttons[i + j * 4].Visible = false;
                        empty = i + j * 4;
                    }
                    buttons[i + j * 4].Text = array[i + j * 4].ToString();
                }
            }
            //AutoPlay();
        }

        private void Buttons_Click(object sender, EventArgs e)
        {
            Button Now = (Button)sender;
            int x = Now.Location.X - buttons[empty].Location.X;
            int y = Now.Location.Y - buttons[empty].Location.Y;
            if (Math.Abs(x) == 85 && y == 0)
            {
                Point P = Now.Location;
                for (int i = 0; i < 85; i++)
                {
                    //Thread.Sleep(1);
                    Now.Location = new Point(Now.Location.X - x / 85, Now.Location.Y);
                }
                Now.Location = buttons[empty].Location;
                buttons[empty].Location = P;
            }
            if (x == 0 && Math.Abs(y) == 85)
            {
                Point P = Now.Location;
                for (int i = 0; i < 85; i++)
                {
                    //Thread.Sleep(1);
                    Now.Location = new Point(Now.Location.X, Now.Location.Y - y / 85); 
                }
                Now.Location = buttons[empty].Location;
                buttons[empty].Location = P;
            }
            if (finish()) MessageBox.Show("Победа!");
        }

        private bool finish()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (buttons[i + j * 4].Text != (i + 1 + j * 4).ToString())
                    {
                        return false;
                    }
                }
            }
            return true;
        }

    }
}
