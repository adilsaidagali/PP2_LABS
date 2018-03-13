using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    { 
        bool playGame = true;
        List<Button> buttons = new List<Button>();
        public Form1()
        {
            InitializeComponent();
            Timer timer = new Timer();
            timer.Interval = 30;
            timer.Enabled = true;
            timer.Tick += new System.EventHandler(timer_Tick);
            label3.Location = new Point(40, 100);
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (playGame)
            {
                buttons.Add(new Button());
                Random random = new Random();
                buttons[buttons.Count - 1].Location = new Point(random.Next(0, Width), 0);
                buttons[buttons.Count - 1].Size = button1.Size;
                buttons[buttons.Count - 1].UseVisualStyleBackColor = true;
                Controls.Add(buttons[buttons.Count - 1]);
            }
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            if (playGame)
                foreach (Button button in buttons)
                {
                    button.Location = new Point(button.Location.X , button.Location.Y + 1);
                    if (button.Location.Y == Height - 70)
                        label2.Text = (int.Parse(label2.Text) + 1).ToString();
                    if (Math.Abs(button.Location.Y - button1.Location.Y) <= button1.Size.Height && Math.Abs(button.Location.X - button1.Location.X) <= button1.Size.Width)
                    {
                        label3.Text = "Game Over!";
                        playGame = false;
                    }
                }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (playGame)
                button1.Location = new Point(trackBar1.Value, button1.Location.Y);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
