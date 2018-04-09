using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        double a, b;
        string c;
        bool isClear;
        int equalClick, dout;
        double memory;
        public Form1()
        {
            InitializeComponent();
            isClear = true;
            textBox1.Text = "0";
            equalClick = 0;
            dout = 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isClear)
            {
                textBox1.Text = "";
                isClear = false;
            }
            Button button = new Button();
            button = sender as Button;
            textBox1.Text += button.Text;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            isClear = true;
            textBox1.Text = "0";
            a = 0;
            b = 0;
            c = "";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            isClear = true;
            equalClick++;
            double ans = 0;
            if (equalClick > 1)
                a = double.Parse(textBox1.Text);
            else
                b = double.Parse(textBox1.Text);
            if (c == "+")
                ans = a + b;
            if (c == "-")
                ans = a - b;
            if (c == "X")
                ans = a * b;
            if (c == "/")
                if (b == 0)
                {
                    textBox1.Text = "Error";
                }
                else
                    ans = a / b;
            if (textBox1.Text != "Error")
                textBox1.Text = ans.ToString();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            equalClick = 0;
            isClear = true;
            textBox1.Text = "0";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            equalClick = 0;
            int ans = 1;
            if (textBox1.Text == "0")
                ans = 0;
            a = double.Parse(textBox1.Text);
            if (a - (int)a != 0)
                textBox1.Text = "Error";
            else
            {
                for (int i = 2; i <= a; i++)
                {
                    ans *= i;
                }
                textBox1.Text = ans.ToString();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e)
        {
            equalClick = 0;
            isClear = true;
            a = double.Parse(textBox1.Text);
            textBox1.Text = (Math.Sqrt(a)).ToString();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            equalClick = 0;
            isClear = true;
            a = double.Parse(textBox1.Text);
            textBox1.Text = (a * a).ToString();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            textBox1.Text = (-double.Parse(textBox1.Text)).ToString();
        }

        private void button20_Click_1(object sender, EventArgs e)
        {
            dout = 0;
            for (int i = 0; i < textBox1.Text.Length; i++)
                if (textBox1.Text == ",")
                    dout++;
            if (dout < 1)
                textBox1.Text += ",";
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 1)
                textBox1.Text = "0";
            else
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
        }

        private void button28_Click(object sender, EventArgs e)
        {
            memory = 0;
        }

        private void button25_Click(object sender, EventArgs e)
        {
            isClear = true;
            textBox1.Text = memory.ToString();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            memory += double.Parse(textBox1.Text);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            textBox1.Text = (1 / double.Parse(textBox1.Text)).ToString();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            memory -= double.Parse(textBox1.Text);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            equalClick = 0;
            isClear = true;
            a = double.Parse(textBox1.Text);
            Button button = sender as Button;
            c = button.Text;
        }
    }
}
