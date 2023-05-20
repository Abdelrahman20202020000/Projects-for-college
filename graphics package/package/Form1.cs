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

namespace package
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
            
        }
        
        static int x0, y0;
        static int xEnd, yEnd;

        
        private int round(double a)
        {
            return Convert.ToInt32(a);
        }

        private void setPixel(Graphics graphics, int x, int y, Color color)
        {
            Brush brushColor = new SolidBrush(color);
            graphics.FillRectangle(brushColor, x, y, 2, 2);

        }
        static int XCenter, YCenter, radius;
        private void button3_Click(object sender, EventArgs e)
        {            
            XCenter = Int32.Parse(textBox5.Text);
            YCenter = Int32.Parse(textBox6.Text);
            radius = Int32.Parse(textBox7.Text);
            circleMidpoint(XCenter, YCenter, radius);

            


        }
        public void circleMidpoint(int Xcenter, int Ycenter, int radius)
        {
            int x = 0;
            int y = radius;
            int p = 1 - radius;
            int k = 0;
            //void circlePlotPoints(int, int, int,int);
            circlePlotPoints((panel1.Width / 2) + Xcenter, (panel1.Height / 2) - Ycenter, x, y);
            while (x < y)
            {
                x++;
                dataGridView2.ColumnCount = 5;
                dataGridView2.Columns[0].Name = "K";
                dataGridView2.Columns[1].Name = "Pk";

                dataGridView1.ColumnCount = 4;
                dataGridView1.Columns[0].Name = "X";
                dataGridView1.Columns[1].Name = "Y";
                dataGridView1.Columns[2].Name = "2X";
                dataGridView1.Columns[3].Name = "2Y";
                //dataGridView1.Columns[2].Name = "X";
                dataGridView2.Rows.Add(k, p);

                
                if (p < 0) {
                    k++;
                    p = p + (2 * x + 1);

                    
                dataGridView1.Rows.Add(x, y, 2 * x, 2 * y);
                }
                else
                {
                    k++;
                    y--;

                    p = p + (2 * (x - y) + 1);
                    dataGridView1.Rows.Add(x, y,2*x,2*y);
                }
                circlePlotPoints((panel1.Width / 2) + Xcenter, (panel1.Height / 2) - Ycenter, x, y);
            }

        }

        void circlePlotPoints(int Xcenter, int Ycenter, int x, int y)
        {
            Graphics g = panel1.CreateGraphics();
            setPixel(g, Xcenter + x, Ycenter + y, Color.Black);
            setPixel(g, Xcenter - x, Ycenter + y, Color.Black);
            setPixel(g, Xcenter + x, Ycenter - y, Color.Black);
            setPixel(g, Xcenter - x, Ycenter - y, Color.Black);
            setPixel(g, Xcenter + y, Ycenter + x, Color.Black);
            setPixel(g, Xcenter - y, Ycenter + x, Color.Black);
            setPixel(g, Xcenter + y, Ycenter - x, Color.Black);
            setPixel(g, Xcenter - y, Ycenter - x, Color.Black);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //int xCenter, yCenter, Rx, Ry;
            //xCenter = Int32.Parse(textBox10.Text);
            //yCenter = Int32.Parse(textBox9.Text);
            //Rx = Int32.Parse(textBox8.Text);
            //Ry = Int32.Parse(textBox11.Text);
            //ellipseMidpoint(xCenter, yCenter, Rx, Ry);
            int xc, yc, rx, ry, x, y;
            xc = int.Parse(textBox10.Text);
            yc = int.Parse(textBox9.Text);
            rx = int.Parse(textBox8.Text);
            ry = int.Parse(textBox11.Text);
            x =  xc;
            y =  yc;

            ellipseMidpoint( x, y, rx, ry);
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
        void clearPanel()
        {
            dataGridView2.Rows.Clear();
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
        private void button5_Click(object sender, EventArgs e)
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
            dataGridView2.Rows.Clear();
            dataGridView1.Rows.Clear();

        }

        
        void ellipseMidpoint(int xc, int yc, int rx, int ry)
        {
            int rx2 = rx * rx;
            int ry2 = ry * ry;
            int tworx2 = 2 * rx2;
            int twory2 = 2 * ry2;
            int p;
            int x = 0;
            int y = ry;
            int px = 0;
            int py = tworx2 * y;
            int k = 0;

            ellipsePlotPoints((panel1.Width / 2) + xc, (panel1.Height / 2) - yc, x, y);

            /* Region 1 */
            p = (int)(ry2 - (rx2 * ry) + (0.25 * rx2));
            while (px < py)
            {
                x++;
                k++;
                dataGridView2.ColumnCount = 5;
                dataGridView2.Columns[0].Name = "K";
                dataGridView2.Columns[1].Name = "Pk";

                dataGridView1.ColumnCount = 4;
                dataGridView1.Columns[0].Name = "X";
                dataGridView1.Columns[1].Name = "Y";
                dataGridView1.Columns[2].Name = "2X";
                dataGridView1.Columns[3].Name = "2Y";

                dataGridView2.Rows.Add(k, p);

                px += twory2;
                if (p < 0)
                {
                    p = p + ry2 + px;
                    dataGridView1.Rows.Add(x, y, px, tworx2 * y);
                }
                else
                {
                    y--;
                    py = py - tworx2;
                    p = p + ry2 + px - py;
                    dataGridView1.Rows.Add(x, y, px, tworx2 * y);

                }
                ellipsePlotPoints((panel1.Width / 2) + xc, (panel1.Height / 2) - yc, x, y);
            }
            

            /* Region 2 */
            p = ((int)(ry2 * (x + 0.5) * (x + 0.5) + rx2 * (y - 1) * (y - 1) - rx2 * ry2));
            while (y > 0)
            {
                dataGridView2.ColumnCount = 5;
                dataGridView2.Columns[0].Name = "K";
                dataGridView2.Columns[1].Name = "Pk";

                dataGridView1.ColumnCount = 4;
                dataGridView1.Columns[0].Name = "X";
                dataGridView1.Columns[1].Name = "Y";
                dataGridView1.Columns[2].Name = "2r*ryk+1";
                dataGridView1.Columns[3].Name = "2r*rxyk+1";

                dataGridView2.Rows.Add(k, p);
                y--;
                py -= tworx2;
                if (p > 0)
                    p += rx2 - py;
                else
                {
                    x++;
                    px += twory2;
                    p += rx2 - py + px;                    
                }
                ellipsePlotPoints((panel1.Width / 2) + xc, (panel1.Height / 2) - yc, x, y);
            }
        }
        void ellipsePlotPoints(int xCenter, int yCenter, int x, int y)
        {
            Graphics g = panel1.CreateGraphics();
            setPixel(g, xCenter + x, yCenter + y, Color.Black);
            setPixel(g, xCenter - x, yCenter + y, Color.Black);
            setPixel(g, xCenter + x, yCenter - y, Color.Black);
            setPixel(g, xCenter - x, yCenter - y, Color.Black);

        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            {
                
                x0 = Int32.Parse(textBox1.Text);
                y0 = Int32.Parse(textBox2.Text);
                xEnd = Int32.Parse(textBox3.Text);
                yEnd = Int32.Parse(textBox4.Text);

                Graphics g = panel1.CreateGraphics();

                int dx = xEnd - x0, dy = yEnd - y0, steps, k;
                float xIncrement, yIncrement, x = x0, y = y0;

                if (Math.Abs(dx) > Math.Abs(dy))
                    steps = Math.Abs(dx);
                else
                    steps = Math.Abs(dy);

                xIncrement = (float)dx / (float)steps;
                yIncrement = (float)dy / (float)steps;


                setPixel(g, round((panel1.Width / 2) + x), round((panel1.Height / 2) - y), Color.Black);
                dataGridView2.Rows.Clear();
                for (k = 0; k < steps; k++)
                {

                    dataGridView2.ColumnCount= 4;
                    dataGridView2.Columns[0].Name = "P";
                    dataGridView2.Columns[1].Name = "X";
                    dataGridView2.Columns[2].Name = "Y";
                    dataGridView2.Columns[3].Name = "(X,Y)";
                    dataGridView2.Rows.Add(k,x, y, (round(x), round(y)));

                    x += xIncrement;
                    y += yIncrement;
                    setPixel(g, round((panel1.Width / 2) + x), round((panel1.Height / 2 )- y), Color.Black);
                }

            }
            

        }
         static int getOctan(int x1, int y1, int x2, int y2)
        {
            float slope = (float) (y2 - y1) / (x2 - x1);
            int octan;

            if (slope >= 0)
            {
                if(slope <= 1)
                {
                    if (x1 < x2) octan = 1; 
                    else octan=5;
                }
                else
                {
                    if (y1 < y2) octan = 2;
                    else octan = 6;
                }
                    
             }
            else
            {
                if(slope <-1)
                {
                    if(y1<y2) octan = 3;
                    else octan = 7;
                }
                else
                {
                    if (x1 > x2) octan = 4;
                    else octan = 8;
                }
            }
            return octan;
        }
        static int[] swap(int x, int y)
        {
            int [] temp = new int[2];
            temp[0] = y;
            temp[1]= x;
            return temp;

        }

        private void button2_Click(object sender, EventArgs e)
        {
                x0 = Convert.ToInt32(textBox1.Text);
                y0 = Convert.ToInt32(textBox2.Text);
                xEnd = Convert.ToInt32(textBox3.Text);
                yEnd = Convert.ToInt32(textBox4.Text);
            Graphics g = panel1.CreateGraphics();

            int octan = getOctan(x0, y0, xEnd, yEnd);
            
            int dx, dy, p0, dc, xk, yk, pk;
            int k=0;
            dataGridView2.Rows.Clear();
            dataGridView1.Rows.Clear();
            switch (octan)
            {
                case 1:
                    dx = xEnd - x0;
                    dy = yEnd - y0;
                    p0 = 2 * dy - dx;
                    dc = 2*dy - 2 * dx;
                    xk = x0 ; yk= y0 ; pk = p0;
                    while (xk != xEnd)
                    {
                        dataGridView2.ColumnCount = 3;
                        dataGridView2.Columns[0].Name = "K";
                        dataGridView2.Columns[1].Name = "P";

                        



                        dataGridView1.ColumnCount = 3;
                        dataGridView1.Columns[0].Name = "X";
                        dataGridView1.Columns[1].Name = "Y";
                        dataGridView1.Columns[2].Name = "(X,Y)";
                        dataGridView2.Rows.Add(k, pk);
                        g.FillRectangle(Brushes.Red, (panel1.Width / 2 + xk), ((panel1.Height / 2) - yk), 2, 2);
                        if (pk>=0)
                        {
                            k++;
                            xk++;
                            yk++;
                            pk += dc; 
                            dataGridView1.Rows.Add(xk, yk, (round(xk), round(yk)));
                        }
                        
                        else
                        {
                            k++;
                            xk++;
                            pk += 2 * dy;
                            dataGridView1.Rows.Add(xk, yk, (round(xk), round(yk)));
                        }
                    }
                    break;

                    case 2:

                    int[] point1 = swap(x0, y0);
                    int[] point2 = swap(xEnd, yEnd);
                    x0 = point1[0];
                    y0 = point1[1];
                    xEnd = point2[0];
                    yEnd = point2[1];
                    dx = xEnd - x0;
                    dy = yEnd - y0;
                    p0 = 2 * dy - dx;
                    dc = 2 * dy - 2 * dx;
                    xk = x0; yk = y0; pk = p0;

                    while (xk != xEnd)
                    {
                        dataGridView2.ColumnCount = 2;
                        dataGridView2.Columns[0].Name = "K";
                        dataGridView2.Columns[1].Name = "P";

                        dataGridView1.ColumnCount = 3;
                        dataGridView1.Columns[0].Name = "X";
                        dataGridView1.Columns[1].Name = "Y";
                        dataGridView1.Columns[2].Name = "(X,Y)";
                        dataGridView2.Rows.Add(k, pk);

                        g.FillRectangle(Brushes.Red, (panel1.Width / 2 + yk ), ((panel1.Height / 2) - xk), 2, 2);
                        if (pk >= 0)
                        {
                            xk++;
                            yk++;
                            pk += dc;
                            dataGridView1.Rows.Add(yk, xk, (round(yk), round(xk)));
                        }
                        else
                        {
                            xk++;
                            pk += 2 * dy;
                            dataGridView1.Rows.Add(yk, xk, (round(yk), round(xk)));
                        }
                    }
                    break;

                case 3:
                    point1 = swap(x0, y0);
                    point2 = swap(xEnd, yEnd);
                    x0 = point1[0];
                    y0 = point1[1];
                    xEnd = point2[0];
                    yEnd = point2[1];
                    dx = xEnd - x0;
                    dy = yEnd - y0;
                    dy = -dy;
                    p0 = 2 * dy - dx;
                    dc = 2 * dy - 2 * dx;
                    xk = x0; yk = y0; pk = p0;

                    while (xk != xEnd)
                    {
                        dataGridView2.ColumnCount = 2;
                        dataGridView2.Columns[0].Name = "K";
                        dataGridView2.Columns[1].Name = "P";

                        dataGridView1.ColumnCount = 3;
                        dataGridView1.Columns[0].Name = "X";
                        dataGridView1.Columns[1].Name = "Y";
                        dataGridView1.Columns[2].Name = "(X,Y)";
                        dataGridView2.Rows.Add(k, pk);

                        g.FillRectangle(Brushes.Red, (panel1.Width / 2 + yk), ((panel1.Height / 2) - xk), 2, 2);
                        if (pk >= 0)
                        {
                            xk++;
                            yk--;
                            pk += dc;
                            dataGridView1.Rows.Add(yk, xk, (round(yk), round(xk)));
                        }
                        else
                        {
                            xk++;
                            pk += 2 * dy;
                            dataGridView1.Rows.Add(yk, xk, (round(yk), round(xk)));
                        }
                    }
                    break;
                case 4:
                    dx = xEnd - x0;
                    dx = -dx;
                    dy = yEnd - y0;
                    p0 = 2 * dy - dx;
                    dc = 2 * dy - 2 * dx;
                    xk = x0; yk = y0; pk = p0;
                    while (xk != xEnd)
                    {
                        dataGridView2.ColumnCount = 2;
                        dataGridView2.Columns[0].Name = "K";
                        dataGridView2.Columns[1].Name = "P";

                        dataGridView1.ColumnCount = 3;
                        dataGridView1.Columns[0].Name = "X";
                        dataGridView1.Columns[1].Name = "Y";
                        dataGridView1.Columns[2].Name = "(X,Y)";
                        dataGridView2.Rows.Add(k, pk);

                        g.FillRectangle(Brushes.Red, (panel1.Width / 2 + xk), ((panel1.Height / 2) - yk), 2, 2);
                        if (pk >= 0)
                        {
                            xk--;
                            yk++;
                            pk += dc;
                            dataGridView1.Rows.Add(xk, yk, (round(xk), round(yk)));
                        }
                        else
                        {
                            xk--;
                            pk += 2 * dy;
                            dataGridView1.Rows.Add(xk, yk, (round(xk), round(yk)));
                        }
                    }
                    break;

                case 5:
                    dx = xEnd - x0;
                    dx = -dx;
                    dy = yEnd - y0;
                    dy = -dy;
                    p0 = 2 * dy - dx;
                    dc = 2 * dy - 2 * dx;
                    xk = x0; yk = y0; pk = p0;
                    while (xk != xEnd)
                    {
                        dataGridView2.ColumnCount = 2;
                        dataGridView2.Columns[0].Name = "K";
                        dataGridView2.Columns[1].Name = "P";

                        dataGridView1.ColumnCount = 3;
                        dataGridView1.Columns[0].Name = "X";
                        dataGridView1.Columns[1].Name = "Y";
                        dataGridView1.Columns[2].Name = "(X,Y)";
                        dataGridView2.Rows.Add(k, pk);

                        g.FillRectangle(Brushes.Red, (panel1.Width / 2 + xk), ((panel1.Height / 2) - yk), 2, 2);
                        if (pk >= 0)
                        {
                            xk--;
                            yk--;
                            pk += dc;
                            dataGridView1.Rows.Add(xk, yk, (round(xk), round(yk)));
                        }
                        else
                        {
                            xk--;
                            pk += 2 * dy;
                            dataGridView1.Rows.Add(xk, yk, (round(xk), round(yk)));
                        }
                    }
                    break;

                case 6:
                    point1 = swap(x0, y0);
                    point2 = swap(xEnd, yEnd);
                    x0 = point1[0];
                    y0 = point1[1];
                    xEnd = point2[0];
                    yEnd = point2[1];
                    dx = xEnd - x0;
                    dx = -dx;
                    dy = yEnd - y0;
                    dy = -dy;
                    p0 = 2 * dy - dx;
                    dc = 2 * dy - 2 * dx;
                    xk = x0; yk = y0; pk = p0;

                    while (xk != xEnd)
                    {
                        dataGridView2.ColumnCount = 2;
                        dataGridView2.Columns[0].Name = "K";
                        dataGridView2.Columns[1].Name = "P";

                        dataGridView1.ColumnCount = 3;
                        dataGridView1.Columns[0].Name = "X";
                        dataGridView1.Columns[1].Name = "Y";
                        dataGridView1.Columns[2].Name = "(X,Y)";
                        dataGridView2.Rows.Add(k, pk);

                        g.FillRectangle(Brushes.Red, (panel1.Width / 2 + yk), ((panel1.Height / 2) - xk), 2, 2);
                        if (pk >= 0)
                        {
                            xk--;
                            yk--;
                            pk += dc;
                            dataGridView1.Rows.Add(yk, xk, (round(yk), round(xk)));
                        }
                        else
                        {
                            xk--;
                            pk += 2 * dy;
                            dataGridView1.Rows.Add(yk, xk, (round(yk), round(xk)));
                        }
                    }
                    break;

                case 7:
                    point1 = swap(x0, y0);
                    point2 = swap(xEnd, yEnd);
                    x0 = point1[0];
                    y0 = point1[1];
                    xEnd = point2[0];
                    yEnd = point2[1];
                    dx = xEnd - x0;
                    dx = -dx;
                    dy = yEnd - y0;
                    p0 = 2 * dy - dx;
                    dc = 2 * dy - 2 * dx;
                    xk = x0; yk = y0; pk = p0;

                    while (xk != xEnd)
                    {
                        dataGridView2.ColumnCount = 2;
                        dataGridView2.Columns[0].Name = "K";
                        dataGridView2.Columns[1].Name = "P";

                        dataGridView1.ColumnCount = 3;
                        dataGridView1.Columns[0].Name = "X";
                        dataGridView1.Columns[1].Name = "Y";
                        dataGridView1.Columns[2].Name = "(X,Y)";
                        dataGridView2.Rows.Add(k, pk);

                        g.FillRectangle(Brushes.Red, (panel1.Width / 2 + yk), ((panel1.Height / 2) - xk), 2, 2);
                        if (pk >= 0)
                        {
                            xk--;
                            yk++;
                            pk += dc;
                            dataGridView1.Rows.Add(yk, xk, (round(yk), round(xk)));
                        }
                        else
                        {
                            xk--;
                            pk += 2 * dy;
                            dataGridView1.Rows.Add(yk, xk, (round(yk), round(xk)));
                        }
                    }
                    break;

                case 8:
                    dx = xEnd - x0;
                    dy = yEnd - y0;
                    dy = -dy;
                    p0 = 2 * dy - dx;
                    dc = 2 * dy - 2 * dx;
                    xk = x0; yk = y0; pk = p0;
                    while (xk != xEnd)
                    {
                        dataGridView2.ColumnCount = 2;
                        dataGridView2.Columns[0].Name = "K";
                        dataGridView2.Columns[1].Name = "P";

                        dataGridView1.ColumnCount = 3;
                        dataGridView1.Columns[0].Name = "X";
                        dataGridView1.Columns[1].Name = "Y";
                        dataGridView1.Columns[2].Name = "(X,Y)";
                        dataGridView2.Rows.Add(k, pk);

                        g.FillRectangle(Brushes.Red, (panel1.Width / 2 + xk), ((panel1.Height / 2) - yk), 2, 2);
                        if (pk >= 0)
                        {
                            xk++;
                            yk--;
                            pk += dc;
                            dataGridView1.Rows.Add(xk, yk, (round(xk), round(yk)));
                        }
                        else
                        {
                            xk++;
                            pk += 2 * dy; 
                            dataGridView1.Rows.Add(xk, yk, (round(xk), round(yk)));
                        }
                    }
                    break;
            }

        }
    }
}
