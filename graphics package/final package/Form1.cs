using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace final_package
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            for (int i = 0; i < panel1.Height; i++)
            {
                g.FillRectangle(Brushes.Black, panel1.Width / 2, i, 2, 2);
            }
            for (int i = 0; i < panel1.Width; i++)
            {
                g.FillRectangle(Brushes.Black, i, panel1.Height / 2, 2, 2);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pen blackPen = new Pen(Color.Black, 3);
            Graphics g = panel1.CreateGraphics();

            int x1, y1, x2, y2, x3, y3, xx1, yy1, xx2, yy2, xx3, yy3;
            x1 = int.Parse(textBox1.Text);
            y1 = int.Parse(textBox3.Text);
            x2 = int.Parse(textBox2.Text);
            y2 = int.Parse(textBox4.Text);
            x3 = int.Parse(textBox6.Text);
            y3 = int.Parse(textBox5.Text);
            xx1 = (panel1.Width / 2) + x1;
            yy1 = (panel1.Height / 2) - y1;
            xx2 = (panel1.Width / 2) + x2;
            yy2 = (panel1.Height / 2) - y2;
            xx3 = (panel1.Width / 2) + x3;
            yy3 = (panel1.Height / 2) - y3;
            Point a = new Point(xx1, yy1);
            Point b = new Point(xx2, yy2);
            Point c = new Point(xx3, yy3);
            Point[] outer = { a, b, c };
            g.DrawPolygon(blackPen, outer);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Pen blackPen = new Pen(Color.Red, 3);
            var g = panel1.CreateGraphics();

            int x, y, x1, y1, x2, y2, x3, y3, xx1, yy1, xx2 = 250, yy2, xx3, yy3, xxx1, yyy1, xxx2, yyy2, xxx3, yyy3;
            x1 = int.Parse(textBox1.Text);
            y1 = int.Parse(textBox3.Text);
            x2 = int.Parse(textBox2.Text);
            y2 = int.Parse(textBox4.Text);
            x3 = int.Parse(textBox6.Text);
            y3 = int.Parse(textBox5.Text);
            x = int.Parse(textBox8.Text);
            y = int.Parse(textBox7.Text);

            xx1 = (panel1.Width / 2) + x1;
            yy1 = (panel1.Height / 2) - y1;
            xx2 = (panel1.Width / 2) + x2;
            yy2 = (panel1.Height / 2) - y2;
            xx3 = (panel1.Width / 2) + x3;
            yy3 = (panel1.Height / 2) - y3;

            xxx1 = xx1 + x;
            xxx2 = xx2 + x;
            xxx3 = xx3 + x;
            yyy1 = yy1 - y;
            yyy2 = yy2 - y;
            yyy3 = yy3 - y;

            Point a = new Point(xxx1, yyy1);
            Point b = new Point(xxx2, yyy2);
            Point c = new Point(xxx3, yyy3);
            Point[] outer = { a, b, c };
            g.DrawPolygon(blackPen, outer);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Point[] Object = new Point[3];

            Object[0] = new Point((panel1.Width / 2) + int.Parse(textBox1.Text), (panel1.Height / 2) - int.Parse(textBox3.Text));
            Object[1] = new Point((panel1.Width / 2) + int.Parse(textBox2.Text), (panel1.Height / 2) - int.Parse(textBox4.Text));
            Object[2] = new Point((panel1.Width / 2) + int.Parse(textBox6.Text), (panel1.Height / 2) - int.Parse(textBox5.Text));

            //-------------------------------------------------------------------
            // around point (composite)
            double T = int.Parse(textBox9.Text);
            double TH = 360 - T;
            double D2R = Math.PI / 180;
            double cos = Math.Cos(TH * D2R);
            double sin = Math.Sin(TH * D2R);


            for (int i = 0; i < Object.Length; i++)
            {
                int X = Object[i].X - (panel1.Width / 2);
                int Y = Object[i].Y - (panel1.Height / 2);
                Object[i].X = (int)((X * cos) - (Y * sin)) + (panel1.Width / 2);
                Object[i].Y = (int)((X * sin) + (Y * cos)) + (panel1.Height / 2);
            }
            panel1.CreateGraphics().DrawPolygon(new Pen(Color.Green, 3), Object);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Point[] Object = new Point[3];

            Object[0] = new Point((panel1.Width / 2) + int.Parse(textBox1.Text), (panel1.Height / 2) - int.Parse(textBox3.Text));
            Object[1] = new Point((panel1.Width / 2) + int.Parse(textBox2.Text), (panel1.Height / 2) - int.Parse(textBox4.Text));
            Object[2] = new Point((panel1.Width / 2) + int.Parse(textBox6.Text), (panel1.Height / 2) - int.Parse(textBox5.Text));


            float sx = int.Parse(textBox8.Text); //1
            float sy = int.Parse(textBox7.Text); //2 , 2.2
            for (int i = 0; i < Object.Length; i++)
            {
                int X = Object[i].X - (panel1.Width / 2);
                int Y = (panel1.Height / 2) - Object[i].Y;
                int xx = (int)(sx * X);
                int yy = (int)(sy * Y);
                Object[i].X = (int)(xx + (panel1.Width / 2));
                Object[i].Y = (int)((panel1.Height / 2) - yy);
            }
            panel1.CreateGraphics().DrawPolygon(new Pen(Color.Green, 3), Object);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Point[] Object = new Point[3];

            Object[0] = new Point((panel1.Width / 2) + int.Parse(textBox1.Text), (panel1.Height / 2) - int.Parse(textBox3.Text));
            Object[1] = new Point((panel1.Width / 2) + int.Parse(textBox2.Text), (panel1.Height / 2) - int.Parse(textBox4.Text));
            Object[2] = new Point((panel1.Width / 2) + int.Parse(textBox6.Text), (panel1.Height / 2) - int.Parse(textBox5.Text));
            float sx = int.Parse(textBox11.Text);
            float shx = sx;
            for (int i = 0; i < Object.Length; i++)
            {
                int X = Object[i].X - (panel1.Width / 2);
                int Y = (panel1.Height / 2) - Object[i].Y;
                int xx = X + (int)(shx * Y);


                Object[i].X = (int)(xx + (panel1.Width / 2));
            }
            panel1.CreateGraphics().DrawPolygon(new Pen(Color.Green, 3), Object);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Point[] Object = new Point[3];

            Object[0] = new Point((panel1.Width / 2) + int.Parse(textBox1.Text), (panel1.Height / 2) - int.Parse(textBox3.Text));
            Object[1] = new Point((panel1.Width / 2) + int.Parse(textBox2.Text), (panel1.Height / 2) - int.Parse(textBox4.Text));
            Object[2] = new Point((panel1.Width / 2) + int.Parse(textBox6.Text), (panel1.Height / 2) - int.Parse(textBox5.Text));
            float sy = int.Parse(textBox10.Text);
            float shy = sy;
            for (int i = 0; i < Object.Length; i++)
            {
                int X = Object[i].X - (panel1.Width / 2);
                int Y = (panel1.Height / 2) - Object[i].Y;
                int yy = Y + (int)(shy * X);


                Object[i].Y = (int)(yy + (panel1.Height / 2));
            }
            panel1.CreateGraphics().DrawPolygon(new Pen(Color.Green, 3), Object);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Point[] Object = new Point[3];

            Object[0] = new Point((panel1.Width / 2) + int.Parse(textBox1.Text), (panel1.Height / 2) - int.Parse(textBox3.Text));
            Object[1] = new Point((panel1.Width / 2) + int.Parse(textBox2.Text), (panel1.Height / 2) - int.Parse(textBox4.Text));
            Object[2] = new Point((panel1.Width / 2) + int.Parse(textBox6.Text), (panel1.Height / 2) - int.Parse(textBox5.Text));
            int x = panel1.Width/2;

            for (int i = 0; i < Object.Length; i++)
            {
                Object[i].X = ((-1)*(Object[i].X - x)) + x;
            }
            panel1.CreateGraphics().DrawPolygon(new Pen(Color.Green, 3), Object);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Point[] Object = new Point[3];

            Object[0] = new Point((panel1.Width / 2) + int.Parse(textBox1.Text), (panel1.Height / 2) - int.Parse(textBox3.Text));
            Object[1] = new Point((panel1.Width / 2) + int.Parse(textBox2.Text), (panel1.Height / 2) - int.Parse(textBox4.Text));
            Object[2] = new Point((panel1.Width / 2) + int.Parse(textBox6.Text), (panel1.Height / 2) - int.Parse(textBox5.Text));
            int y = panel1.Height / 2;

            for (int i = 0; i < Object.Length; i++)
            {
                Object[i].Y = ((-1) * (Object[i].Y - y)) + y;
            }
            panel1.CreateGraphics().DrawPolygon(new Pen(Color.Green, 3), Object);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Point[] Object = new Point[3];

            Object[0] = new Point((panel1.Width / 2) + int.Parse(textBox1.Text), (panel1.Height / 2) - int.Parse(textBox3.Text));
            Object[1] = new Point((panel1.Width / 2) + int.Parse(textBox2.Text), (panel1.Height / 2) - int.Parse(textBox4.Text));
            Object[2] = new Point((panel1.Width / 2) + int.Parse(textBox6.Text), (panel1.Height / 2) - int.Parse(textBox5.Text));
            int y = panel1.Height / 2;
            int x = panel1.Width / 2;

            for (int i = 0; i < Object.Length; i++)
            {
                Object[i].X = ((-1) * (Object[i].X - x)) + x;
                Object[i].Y = ((-1) * (Object[i].Y - y)) + y;
            }
            panel1.CreateGraphics().DrawPolygon(new Pen(Color.Green, 3), Object);
        }
        void clearPanel()
        {
            panel1.CreateGraphics().Clear(Color.White);
            Graphics g = panel1.CreateGraphics();
            for (int i = 0; i < panel1.Height; i++)
            {
                g.FillRectangle(Brushes.Black, panel1.Width / 2, i, 2, 2);
            }
            for (int i = 0; i < panel1.Width; i++)
            {
                g.FillRectangle(Brushes.Black, i, panel1.Height / 2, 2, 2);
            }
        }
        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            clearPanel();
        }
    }

}
