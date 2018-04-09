using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
namespace Paint
{
    public partial class Form1 : Form
    {
        Graphics g;
        public enum Tool
        {
            Rectangle,
            Ellipse,
            Pen,
            Pouring,
            Right_Triangle,
            Isosceles_Triangle,
            Rubber,
            Pail,
            Pipette
        };
        Point prev, cur;
        Bitmap bmp;
        Pen pen;
        bool clicked, k;
        Tool tool;
        public Form1()
        {
            InitializeComponent();
            pen = new Pen(Color.Black, 2);
            pictureBox1.Size = new Size(this.Width, this.Height);
            bmp = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
            g = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;
            tool = Tool.Pen;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            int x = Math.Min(prev.X, cur.X);
            int y = Math.Min(prev.Y, cur.Y);
            int w = Math.Abs(prev.X - cur.X);
            int h = Math.Abs(prev.Y - cur.Y);
            if (clicked)
            {
                if (tool == Tool.Rectangle)
                    e.Graphics.DrawRectangle(pen, x, y, w, h);
                if (tool == Tool.Ellipse)
                    e.Graphics.DrawEllipse(pen, x, y, w, h);
                Point point1 = new Point(prev.X, prev.Y);
                Point point2 = new Point(cur.X, prev.Y);
                Point point3 = new Point((prev.X + cur.X) / 2, cur.Y);
                Point[] curvePoints =
                {
                     point1,
                     point2,
                     point3
                };
                if (tool == Tool.Isosceles_Triangle)
                    e.Graphics.DrawPolygon(pen, curvePoints);
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            cur = e.Location;
            if (clicked && tool == Tool.Pen)
            {
                g.DrawLine(pen, prev, cur);
                prev = cur;
            }
            if (clicked && tool == Tool.Rubber)
            {
                g.DrawLine(new Pen(pictureBox1.BackColor, 7), prev, cur);
                prev = cur;
            }
            pictureBox1.Refresh();
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            int x = Math.Min(prev.X, cur.X);
            int y = Math.Min(prev.Y, cur.Y);
            int w = Math.Abs(prev.X - cur.X);
            int h = Math.Abs(prev.Y - cur.Y);
            clicked = false;
            if (tool == Tool.Rectangle)
                g.DrawRectangle(pen, x, y, w, h);
            if (tool == Tool.Ellipse)
                g.DrawEllipse(pen, x, y, w, h);
            Point point1 = new Point(prev.X, prev.Y);
            Point point2 = new Point(cur.X, prev.Y);
            Point point3 = new Point((prev.X + cur.X) / 2, cur.Y);
            Point[] curvePoints =
             {
                 point1,
                 point2,
                 point3
             };
            if (tool == Tool.Isosceles_Triangle)
                g.DrawPolygon(pen, curvePoints);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (tool == Tool.Pipette)
            {
                pen.Color = bmp.GetPixel(e.Location.X, e.Location.Y);
                button19.BackColor = bmp.GetPixel(e.Location.X, e.Location.Y);
            }
            if (tool == Tool.Pail)
            {
                
                Color color = new Color();
                color = bmp.GetPixel(e.Location.X, e.Location.Y);
                Queue<Point> queue = new Queue<Point>();
                queue.Enqueue(e.Location);
                bmp.SetPixel(e.Location.X, e.Location.Y, pen.Color);
                while (queue.Count > 0)
                {
                    Point p = queue.Dequeue();

                    if (bmp.GetPixel(Math.Min(p.X + 1, pictureBox1.Width - 1), p.Y) == color)
                    {
                        queue.Enqueue(new Point(Math.Min(p.X + 1, pictureBox1.Width - 1), p.Y));
                        bmp.SetPixel(p.X + 1, p.Y, pen.Color);
                    }
                    if (bmp.GetPixel(p.X, Math.Min(p.Y + 1, pictureBox1.Height - 1)) == color)
                    {
                        queue.Enqueue(new Point(p.X, Math.Min(p.Y + 1, pictureBox1.Height - 1)));
                        bmp.SetPixel(p.X, p.Y + 1, pen.Color);
                    }
                    if (bmp.GetPixel(Math.Max(p.X - 1, 0), p.Y) == color)
                    {
                        queue.Enqueue(new Point(Math.Max(p.X - 1, 0), p.Y));
                        bmp.SetPixel(p.X - 1, p.Y, pen.Color);
                    }
                    if (bmp.GetPixel(p.X, Math.Max(p.Y - 1, 0)) == color)
                    {
                        queue.Enqueue(new Point(p.X, Math.Max(p.Y - 1, 0)));
                        bmp.SetPixel(p.X, p.Y - 1, pen.Color);
                    }
                }
            }
            pictureBox1.Refresh();
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            clicked = true;
            prev = e.Location;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            tool = Tool.Right_Triangle;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            tool = Tool.Pen;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            tool = Tool.Rectangle;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            tool = Tool.Ellipse;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            tool = Tool.Isosceles_Triangle;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            pen = new Pen(pen.Color, 1);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            button6.Visible = true;
            button7.Visible = true;
            button8.Visible = true;
            button9.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            pen = new Pen(pen.Color, 3);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            pen = new Pen(pen.Color, 5);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            pen = new Pen(pen.Color, 7);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            tool = Tool.Rubber;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            tool = Tool.Pail;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            pen.Color = button.BackColor;
            button19.BackColor = button.BackColor;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            tool = Tool.Pipette;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
