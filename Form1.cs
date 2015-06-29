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

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(370,390);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    buttons[i + j * 4] = new Button();
                    buttons[i + j * 4].Size = new Size(80, 80);
                    buttons[i + j * 4].Location = new Point(10 + 85 * i, 10 + 85 * j);
                    this.Controls.Add(buttons[i + j * 4]);
                    buttons[i + j * 4].Text = (i + 1 + j * 4).ToString();
                }
            }
        }
    }
}
