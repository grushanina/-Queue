using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Queue
{
    public partial class Form1 : Form
    {
        int n = 0;
        List<int> tbl = new List<int>();
        TextBox[] tb = new TextBox[3];
        Timer[] timers = new Timer[3];
        MyQueue<int> SberQueue = new MyQueue<int>(20);
        MyQueue<int> WindiwQueue = new MyQueue<int>(3);
        int[] minutes = new int[] {10, 10, 10 };
        int[] seconds = new int[] {0,  0, 0 };

    public Form1()
        {
            InitializeComponent();
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(tb[0].Text) || string.IsNullOrEmpty(tb[1].Text) || string.IsNullOrEmpty(tb[2].Text))
            {
                
                //tb[n].Text = n.ToString();
                //timers[n].Start();

                Random rnd = new Random();
                int r = rnd.Next(0, tbl.Count());
                tb[tbl[r]].Text = n.ToString();
                timers[tbl[r]].Start();
                tbl.RemoveAt(r);
            }
            else
            {
                SberQueue.Push(n);
                textBox1.Text += n.ToString() + "\r\n";
            }

            n++;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tb[0] = new TextBox();
            tb[0].Location = new Point(12, 262);
            tb[0].Size = new Size(65, 20);
            this.Controls.Add(tb[0]);

            tb[1] = new TextBox();
            tb[1].Location = new Point(84, 262);
            tb[1].Size = new Size(65, 20);
            this.Controls.Add(tb[1]);

            tb[2] = new TextBox();
            tb[2].Location = new Point(157, 262);
            tb[2].Size = new Size(65, 20);
            this.Controls.Add(tb[2]);

            tbl.Insert(0, 0);
            tbl.Insert(1, 1);
            tbl.Insert(2, 2);

            timers[0] = timer1;
            timers[1] = timer2;
            timers[2] = timer3;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            label1.Text = minutes[0].ToString() + ":" + seconds[0].ToString();
            if (seconds[0] == 0)
            {
                minutes[0]--;
                seconds[0] = 59;
            }
            else
            {
                seconds[0]--;
            }
            
            if (minutes[0] == 0 && seconds[0] == 0)
            {
                if (SberQueue.IsEmpty())
                {
                    timers[0].Enabled = false;
                    return;
                }
                minutes[0] = 10;
                seconds[0] = 00;

                tb[0].Text = SberQueue.Pop().ToString();
                textBox1.Text = textBox1.Text.Substring(3);
                label1.Text = minutes[0].ToString() + ":" + seconds[0].ToString();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label2.Text = minutes[1].ToString() + ":" + seconds[1].ToString();
            if (seconds[1] == 0)
            {
                minutes[1]--;
                seconds[1] = 59;
            }
            else
            {
                seconds[1]--;
            }

            if (minutes[1] == 0 && seconds[1] == 0)
            {
                if (SberQueue.IsEmpty())
                {
                    timers[1].Enabled = false;
                    return;
                }
                minutes[1] = 10;
                seconds[1] = 00;

                tb[1].Text = SberQueue.Pop().ToString();
                textBox1.Text = textBox1.Text.Substring(3);
                label2.Text = minutes[1].ToString() + ":" + seconds[1].ToString();
            }
        }


        private void timer3_Tick(object sender, EventArgs e)
        {
            label3.Text = minutes[2].ToString() + ":" + seconds[2].ToString();
            if (seconds[2] == 0)
            {
                minutes[2]--;
                seconds[2] = 59;
            }
            else
            {
                seconds[2]--;
            }

            if (minutes[2] == 0 && seconds[2] == 0)
            {
                if (SberQueue.IsEmpty())
                {
                    timers[2].Enabled = false;
                    return;
                }
                minutes[2] = 10;
                seconds[2] = 00;

                tb[2].Text = SberQueue.Pop().ToString();
                textBox1.Text = textBox1.Text.Substring(3);
                label3.Text = minutes[2].ToString() + ":" + seconds[2].ToString();
            }
        }
    }
}
