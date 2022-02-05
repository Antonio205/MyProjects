using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace flags
{
    public partial class Form1 : Form
    {
        bool svg = false;
        bool fl;
        public Form1()
        {
            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.Clear(Color.Gray);
            if (svg)
            {
                DrawFlag_SVG(ClientRectangle, e.Graphics);
            }
            else
            {
                DrawFlag_Libya(ClientRectangle, e.Graphics);
            }
        }
        private void DrawFlag_SVG(Rectangle r, Graphics g)
        {
            const int PROPX = 7, PROPY = 11;
            g.Clear(Color.Gray);

            int H = r.Height, W = r.Width;
            Point WN = new Point(0, 0);
            if (PROPX * r.Width > PROPY * r.Height) // широкое поле
            {
                W = H * PROPY / PROPX;
                WN.X = (r.Width - W) / 2;
            }
            else if (PROPX * r.Width < PROPY * r.Height) // высокое поле
            {
                H = W * PROPX / PROPY;
                WN.Y = (r.Height - H) / 2;
            }
             Point WS = new Point(WN.X, WN.Y + H);
             Point ES = new Point(WN.X + W, WN.Y + H);
             Point EN = new Point(WN.X + W, WN.Y);
             Point A = new Point(WN.X, ES.Y - 3 * H / 25);
             Point B = new Point(WN.X, ES.Y - H / 5);
             Point C = new Point(WN.X, WN.Y + H / 5);
             Point D = new Point(WN.X, WN.Y + 3 * H / 25);
            /*Point E = new Point(WN.X + 3 * W / 25, WN.Y);
            Point F = new Point(WN.X + W / 5, WN.Y);
            Point L = new Point(WN.X + 3 * W / 25, ES.Y);
            Point K = new Point(WN.X + W / 5, ES.Y);*/

            Point E = new Point(WS.X, WS.Y);
            Point F = new Point(WN.X, WN.Y);
            Point L = new Point((ES.X - WS.X)  / 4 + WS.X, WS.Y);
            Point K = new Point((ES.X - WS.X) / 4 + WS.X, WN.Y);


            Point M = new Point((ES.X - WS.X) * 3 / 4 + WS.X, WS.Y);
            Point N = new Point((ES.X - WS.X) * 3 / 4 + WS.X, WN.Y);


            Point r1 = new Point((EN.X - WN.X) / 2 + WN.X, (WN.Y - WS.Y) * 7 / 15 + WS.Y );
            Point r3 = new Point((EN.X - WN.X) / 2 + WN.X, (WN.Y - WS.Y) * 2 / 15 + WS.Y);
            Point r2 = new Point((EN.X - WN.X) / 2 + WN.X + ((ES.X - WN.X) * 3/ 60), (r1.Y - r3.Y) / 2 + r3.Y /*+ WS.Y*/);
            Point r4 = new Point((EN.X - WN.X) / 2 + WN.X - ((ES.X - WN.X) *3/60), (r1.Y - r3.Y) / 2 + r3.Y /*+ WS.Y*/);

            Point ro1 = new Point(r2.X+((ES.X - WS.X) / 60 ), r2.Y - ((ES.X-WS.X)/ 60));
            Point ro3 = new Point(r2.X + ((ES.X - WS.X) / 60), r2.Y  -  ((ES.X - WS.X) / 60) + r1.Y-r3.Y);
            Point ro2 = new Point(r1.X + ((ES.X - WS.X) / 60), r1.Y-((ES.X - WS.X) / 60));
            Point ro4 = new Point(ro2.X + r2.X-r4.X, ro2.Y);
            
            Point rom1 = new Point(r4.X - ((ES.X - WS.X) / 60), ro1.Y/*r4.Y + ((ES.X - WS.X) / 60)*/);
            Point rom3 = new Point(rom1.X, ro3.Y/*r4.Y + ((ES.X - WS.X) / 60) + r1.Y - r3.Y*/);
            Point rom2 = new Point(r1.X - ((ES.X - WS.X) / 60),ro2.Y /*r1.Y + ((ES.X - WS.X) / 60)*/);
            Point rom4 = new Point(rom2.X - r2.X + r4.X, rom2.Y);


            Point[] blue_part = new Point[4];
            Point[] green_part = new Point[4];
            Point[] yellow_part = new Point[4];
            Point[] romb1 = new Point[4];
            Point[] romb2 = new Point[4];
            Point[] romb3 = new Point[4];

            blue_part[0] = A;
            blue_part[1] = B;
            blue_part[2] = C;
            blue_part[3] = D;
            green_part[0] = E;
            green_part[1] = L;
            green_part[2] = K;
            green_part[3] = F;
            yellow_part[0] = L;
            yellow_part[1] = K;
            yellow_part[2] = N;
            yellow_part[3] = M;
            romb1[0] = r1;
            romb1[1] = r2;
            romb1[2] = r3;
            romb1[3] = r4;

            romb2[0] = ro1;
            romb2[1] = ro2;
            romb2[2] = ro3;
            romb2[3] = ro4;

            romb3[0] = rom1;
            romb3[1] = rom2;
            romb3[2] = rom3;
            romb3[3] = rom4;

            SolidBrush brush = new SolidBrush(Color.Blue);
            Pen pen = new Pen(brush);
            brush.Color = Color.Green;
            g.FillRectangle(brush, WN.X, WN.Y, W, H);
            g.FillPolygon(brush, blue_part);
            brush.Color = Color.DarkBlue;
            g.FillPolygon(brush, green_part);
            brush.Color = Color.Yellow;
            g.FillPolygon(brush, yellow_part);
            /*
            brush.Color = Color.FromArgb(255, 184, 28);
            g.FillPolygon(brush, yellow_part);*/
            brush.Color = Color.Green;
            g.FillPolygon(brush, romb1);
            g.FillPolygon(brush, romb2);
            g.FillPolygon(brush, romb3);
            //svg = false;
            brush.Color = Color.Black;
            brush.Dispose();
            pen.Dispose();
        }

        private void DrawFlag_Libya(Rectangle r, Graphics g)
        {
            const int PROPX = 1, PROPY = 2;
            g.Clear(Color.Gray);

            int H = r.Height, W = r.Width;
            Point WN = new Point(0, 0);
            if (PROPX * r.Width > PROPY * r.Height) // широкое поле
            {
                W = H * PROPY / PROPX;
                WN.X = (r.Width - W) / 2;
            }
            else if (PROPX * r.Width < PROPY * r.Height) // высокое поле
            {
                H = W * PROPX / PROPY;
                WN.Y = (r.Height - H) / 2;
            }
            Point WS = new Point(WN.X, WN.Y + H);
            Point ES = new Point(WN.X + W, WN.Y + H);
            Point EN = new Point(WN.X + W, WN.Y);
            Point A = new Point(WN.X, WN.Y);
            Point B = new Point(WN.X, WN.Y - ((WN.Y - WS.Y) / 4));
            Point C = new Point(EN.X, EN.Y);
            Point D = new Point(EN.X, EN.Y - ((EN.Y - WS.Y) / 4));

            Point E = new Point(WS.X, WS.Y);
            Point F = new Point(WS.X, WS.Y + ((WN.Y - WS.Y) / 4));
            Point G = new Point(ES.X, ES.Y);
            Point U = new Point(ES.X, ES.Y + ((EN.Y - WS.Y) / 4));

            Point[] red_part = new Point[4];
            Point[] green_part = new Point[4];


            red_part[0] = A;
            red_part[1] = C;
            red_part[2] = D;
            red_part[3] = B;

            green_part[0] = E;
            green_part[1] = G;
            green_part[2] = U;
            green_part[3] = F;

            SolidBrush brush = new SolidBrush(Color.Blue);
            Pen pen = new Pen(brush);
            brush.Color = Color.Black;
            g.FillRectangle(brush, WN.X, WN.Y, W, H);
            brush.Color = Color.Red;
            g.FillPolygon(brush, red_part); 
            brush.Color = Color.Green;
            g.FillPolygon(brush, green_part);
            brush.Color = Color.White;

            float rad = (ES.X - WS.X) * 3 / 48;
            Point po1 = new Point((ES.X - WS.X) / 2 + WN.X - (ES.X - WS.X) / 16, (WN.Y - WS.Y) / 2 + WS.Y + ((EN.Y - WS.Y) / 8));
            g.FillEllipse(brush, po1.X, po1.Y, rad * 2 , rad * 2);
            brush.Color = Color.Black;
            rad = (ES.X - WS.X) * 5 / 96;
            g.FillEllipse(brush, po1.X + (rad / 2), po1.Y + (rad *17 / 90), rad * 2, rad * 2);
            brush.Color = Color.White;

            int n = 5;
            double R = (H+W)/67/*(ES.X - WS.X) * 1 / 48 + WS.X*/, re = (H + W) / 30/*(ES.X - WS.X) * 5 / 96 + WS.X*/;
           
            double alpha = 47.15;        
            double x0 = (ES.X-WS.X)*28/48 + WS.X  , y0 = (WN.Y-WS.Y)/2 + WS.Y; 

            PointF[] points = new PointF[2 * n + 1];

            double a = alpha, da = Math.PI / n, l;
            for (int k = 0; k < 2 * n + 1; k++)
            {
                l = k % 2 == 0 ? re : R;
                points[k] = new PointF((float)(x0 + l * Math.Cos(a)), (float)(y0 + l * Math.Sin(a)));
                a += da;
            }

            g.FillPolygon(new System.Drawing.SolidBrush(Color.White), points); //цвет
            brush.Dispose();
            pen.Dispose();
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (fl)
            {
                svg = true;
            }
            else
            {
                svg = false;
            }
           
            Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (svg)
            {
                fl = false;
                svg = false;
            }
            else
            {
                fl = true;
                svg = true;

            }
            Invalidate();
        }

    }
}
