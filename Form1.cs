using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test15
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Button[] buttons = new Button[16];

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
            int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            ShuffleArray(array);
            this.Size = new Size(370,390);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    buttons[i + j * 4] = new Button();
                    buttons[i + j * 4].Size = new Size(80, 80);
                    buttons[i + j * 4].Font = new Font("Microsoft Sans Serif", 24.0f);
                    buttons[i + j * 4].Location = new Point(10 + 85 * i, 10 + 85 * j);
                    this.Controls.Add(buttons[i + j * 4]);
                    if (array[i + j * 4] == 16)
                    {
                        buttons[i + j * 4].Text = "";
                    }
                    else
                    {
                        buttons[i + j * 4].Text = array[i + j * 4].ToString();
                    }
                }
            }
        }
    }
}
