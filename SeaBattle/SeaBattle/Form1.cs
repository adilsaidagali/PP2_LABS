using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeaBattle
{
    public partial class Form1 : Form
    {
        Pen pen = new Pen(Color.Black, 2);
        bool clicked;
        bool[][] map;
        Bitmap bmp, bmp1;
        Graphics g, g1;
        Point cur, prev;
        public enum Tool
        {
            boat1,
            boat2,
            boat3,
            boat4
        };
        Tool tool;
        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
            g = Graphics.FromImage(bmp);
            tool = Tool.boat4;
            pictureBox1.Image = bmp;
            bmp1 = new Bitmap(pictureBox2.Size.Width, pictureBox2.Size.Height);
            g1 = Graphics.FromImage(bmp1);
            pictureBox2.Image = bmp1;
            for (int i = 0; i < 11; i++)
                g.DrawLine(pen, 32 * i, 0, 32 * i, 320);
            for (int i = 0; i < 11; i++)
                g.DrawLine(pen, 0, 32 * i, 320, 32 * i);
            pictureBox1.Refresh();
            for (int i = 0; i < 11; i++)
                g1.DrawLine(pen, 32 * i, 0, 32 * i, 320);
            for (int i = 0; i < 11; i++)
                g1.DrawLine(pen, 0, 32 * i, 320, 32 * i);
            pictureBox2.Image = bmp1;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (button1.Text == "Horizontal" && clicked)
            {
                if (tool == Tool.boat4)
                {
                    int x, y;
                    x = cur.X / 32;
                    x *= 32;
                    y = cur.Y / 32;
                    y *= 32;
                    if (cur.X > 192)
                        x = 192;
                    e.Graphics.FillRectangle(new SolidBrush(Color.Red), x, y, 128, 32);
                }
                if (tool == Tool.boat3)
                {
                    int x, y;
                    x = cur.X / 32;
                    x *= 32;
                    y = cur.Y / 32;
                    y *= 32;
                    if (cur.X > 224)
                        x = 224;
                    e.Graphics.FillRectangle(new SolidBrush(Color.Red), x, y, 96, 32);
                }
                if (tool == Tool.boat2)
                {
                    int x, y;
                    x = cur.X / 32;
                    x *= 32;
                    y = cur.Y / 32;
                    y *= 32;
                    if (cur.X > 256)
                        x = 256;
                    e.Graphics.FillRectangle(new SolidBrush(Color.Red), x, y, 64, 32);
                }
                if (tool == Tool.boat1)
                {
                    int x, y;
                    x = cur.X / 32;
                    x *= 32;
                    y = cur.Y / 32;
                    y *= 32;
                    e.Graphics.FillRectangle(new SolidBrush(Color.Red), x, y, 32, 32);
                }
            }
            if (button1.Text == "Vertical" && clicked)
            {
                if (tool == Tool.boat4)
                {
                    int x, y;
                    x = cur.X / 32;
                    x *= 32;
                    y = cur.Y / 32;
                    y *= 32;
                    if (cur.Y > 192)
                        y = 192;
                    e.Graphics.FillRectangle(new SolidBrush(Color.Red), x, y, 32, 128);
                }
                if (tool == Tool.boat3)
                {
                    int x, y;
                    x = cur.X / 32;
                    x *= 32;
                    y = cur.Y / 32;
                    y *= 32;
                    if (cur.Y > 224)
                        y = 224;
                    e.Graphics.FillRectangle(new SolidBrush(Color.Red), x, y, 32, 96);
                }
                if (tool == Tool.boat2)
                {
                    int x, y;
                    x = cur.X / 32;
                    x *= 32;
                    y = cur.Y / 32;
                    y *= 32;
                    if (cur.Y > 256)
                        y = 256;
                    e.Graphics.FillRectangle(new SolidBrush(Color.Red), x, y, 32, 64);
                }
                if (tool == Tool.boat1)
                {
                    int x, y;
                    x = cur.X / 32;
                    x *= 32;
                    y = cur.Y / 32;
                    y *= 32;
                    e.Graphics.FillRectangle(new SolidBrush(Color.Red), x, y, 32, 32);
                }
            }
            pictureBox1.Refresh();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Horizontal")
                button1.Text = "Vertical";
            else
                button1.Text = "Horizontal";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            tool = Tool.boat4;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tool = Tool.boat3;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tool = Tool.boat2;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tool = Tool.boat1;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            clicked = true;
            pen = new Pen(Color.DarkRed, 2);
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            cur = e.Location;
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (button1.Text == "Horizontal" && clicked)
            {
                if (tool == Tool.boat4)
                {
                    int x, y;
                    x = cur.X / 32;
                    x *= 32;
                    y = cur.Y / 32;
                    y *= 32;
                    if (cur.X > 192)
                        x = 192;
                    g.FillRectangle(new SolidBrush(Color.Red), x, y, 128, 32);
                }
                if (tool == Tool.boat3)
                {
                    int x, y;
                    x = cur.X / 32;
                    x *= 32;
                    y = cur.Y / 32;
                    y *= 32;
                    if (cur.X > 224)
                        x = 224;
                    g.FillRectangle(new SolidBrush(Color.Red), x, y, 96, 32);
                }
                if (tool == Tool.boat2)
                {
                    int x, y;
                    x = cur.X / 32;
                    x *= 32;
                    y = cur.Y / 32;
                    y *= 32;
                    if (cur.X > 256)
                        x = 256;
                    g.FillRectangle(new SolidBrush(Color.Red), x, y, 64, 32);
                }
                if (tool == Tool.boat1)
                {
                    int x, y;
                    x = cur.X / 32;
                    x *= 32;
                    y = cur.Y / 32;
                    y *= 32;
                    g.FillRectangle(new SolidBrush(Color.Red), x, y, 32, 32);
                }
            }
            if (button1.Text == "Vertical" && clicked)
            {
                if (tool == Tool.boat4)
                {
                    int x, y;
                    x = cur.X / 32;
                    x *= 32;
                    y = cur.Y / 32;
                    y *= 32;
                    if (cur.Y > 192)
                        y = 192;
                    g.FillRectangle(new SolidBrush(Color.Red), x, y, 32, 128);
                }
                if (tool == Tool.boat3)
                {
                    int x, y;
                    x = cur.X / 32;
                    x *= 32;
                    y = cur.Y / 32;
                    y *= 32;
                    if (cur.Y > 224)
                        y = 224;
                    g.FillRectangle(new SolidBrush(Color.Red), x, y, 32, 96);
                }
                if (tool == Tool.boat2)
                {
                    int x, y;
                    x = cur.X / 32;
                    x *= 32;
                    y = cur.Y / 32;
                    y *= 32;
                    if (cur.Y > 256)
                        y = 256;
                    g.FillRectangle(new SolidBrush(Color.Red), x, y, 32, 64);
                }
                if (tool == Tool.boat1)
                {
                    int x, y;
                    x = cur.X / 32;
                    x *= 32;
                    y = cur.Y / 32;
                    y *= 32;
                    g.FillRectangle(new SolidBrush(Color.Red), x, y, 32, 32);
                }
            }
            clicked = false;
        }
    }
}
