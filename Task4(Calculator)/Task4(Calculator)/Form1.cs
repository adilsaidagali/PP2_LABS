using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task4_Calculator_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Text = "0";
            button2.Text = "0";
            button3.Text = "0";
            button4.Text = "0";
            button5.Text = "0";
            button6.Text = "0";
            button7.Text = "0";
            button8.Text = "0";
            button9.Text = "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.Text = (int.Parse(btn.Text) + 1).ToString();
        }
    }
}
