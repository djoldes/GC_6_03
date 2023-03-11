using System.DirectoryServices.ActiveDirectory;
using System.Windows.Forms;

namespace GC_6_03
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //problema1(e);
            //problema2(e);
            //problema3(e);
        }

        private void problema3(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Red);
            Random rnd = new Random();

            int n = 50;
            PointF[] m = new PointF[n];

            float raza_m = 5;

            for (int i = 0; i < n; i++)
            {
                m[i].X = rnd.Next(200, this.ClientSize.Width - 200);
                m[i].Y = rnd.Next(200, this.ClientSize.Height - 200);
                g.DrawEllipse(p, m[i].X - raza_m, m[i].Y - raza_m, raza_m * 2, raza_m * 2);
            }

            int mid_W = 0;
            int mid_H = 0;
            mid_W = this.ClientSize.Width / 2;
            mid_H = this.ClientSize.Height / 2;
            Point mid = new Point(mid_W, mid_H);
            p = new Pen(Color.Blue); //centrul formularului
            g.DrawEllipse(p, mid_W, mid_H, 10, 10);
            float d_min = float.MaxValue;
            float d;
            int i1 = 0;
            for (int i = 0; i < n; i++)
            {
                d = (float)Math.Sqrt(Math.Pow(m[i].X - mid.X, 2) + Math.Pow(m[i].Y - mid.Y, 2));
                if (d < d_min)
                {
                    d_min = d;
                    i1 = i;
                }
            }
            p = new Pen(Color.Green); //centrul cercului incercuit
            g.DrawEllipse(p, m[i1].X - 10, m[i1].Y - 10, 20, 20);
            float d_max = 0;
            int i2 = 0;
            for (int i = 0; i < n; i++)
            {
                d = (float)Math.Sqrt(Math.Pow(m[i].X - m[i1].X, 2) + Math.Pow(m[i].Y - m[i1].Y, 2));
                if (d > d_max)
                {
                    d_max = d;
                    i2 = i;
                }
            }
            p = new Pen(Color.Black);
            g.DrawEllipse(p, m[i1].X - d_max, m[i1].Y - d_max, d_max * 2, d_max * 2);
        }

        private void problema2(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Red);
            Random rnd = new Random();

            int n = 50;
            PointF[] m = new PointF[n];

            float raza_m = 5;

            for (int i = 0; i < n; i++)
            {
                m[i].X = rnd.Next(10, this.ClientSize.Width - 10);
                m[i].Y = rnd.Next(10, this.ClientSize.Height - 10);
                g.DrawEllipse(p, m[i].X - raza_m, m[i].Y - raza_m, raza_m * 2, raza_m * 2);
            }
            double aria_min = double.MaxValue;
            int i1 = 0, i2 = 0, i3 = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n - 1; j++)
                {
                    for (int k = j + 1; k < n - 2; k++)
                    {
                        //aria =(float)(0.5 * (m[i].X * m[j].Y + m[j].X * m[k].Y + m[k].X * m[i].Y - m[k].X * m[j].Y - m[i].X * m[k].Y - m[j].X * m[i].Y));
                        double ab = Math.Sqrt(Math.Pow(m[j].X - m[i].X, 2) + Math.Pow(m[j].Y - m[i].Y, 2));
                        double bc = Math.Sqrt(Math.Pow(m[k].X - m[j].X, 2) + Math.Pow(m[k].Y - m[j].Y, 2));
                        double ca = Math.Sqrt(Math.Pow(m[i].X - m[k].X, 2) + Math.Pow(m[i].Y - m[k].Y, 2));

                        double sper = (ab + bc + ca) / 2;

                        double aria = Math.Sqrt(sper * (sper - ab) * (sper - bc) * (sper - ca));

                        if (aria < aria_min)
                        {
                            aria_min = aria;
                            i1 = i;
                            i2 = j;
                            i3 = k;
                        }
                    }
                }
            }
            g.DrawLine(p, m[i1].X, m[i1].Y, m[i2].X, m[i2].Y);
            g.DrawLine(p, m[i2].X, m[i2].Y, m[i3].X, m[i3].Y);
            g.DrawLine(p, m[i3].X, m[i3].Y, m[i1].X, m[i1].Y);
        }

    private void problema1(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Red);
            Random rnd = new Random();

            int n1 = rnd.Next(50);
            PointF[] m1 = new PointF[n1];

            float raza1 = 5;

            for (int i = 0; i < n1; i++)
            {
                m1[i].X = rnd.Next(10, this.ClientSize.Width - 10);
                m1[i].Y = rnd.Next(10, this.ClientSize.Height - 10);
                g.DrawEllipse(p, m1[i].X - raza1, m1[i].Y -raza1, raza1 * 2, raza1 * 2);
            }
            int x = rnd.Next(10, this.ClientSize.Width - 10);
            int y = rnd.Next(10, this.ClientSize.Height - 10);
            Point q = new Point(x, y);
            p.Color = Color.Green;
            g.DrawEllipse(p, x, y, 5, 5);

            int distanta_maxima = 200;
            float distanta;

            for (int i = 0; i < n1; i++)
            {
                distanta = (float)Math.Sqrt(Math.Pow(m1[i].X - q.X, 2) + Math.Pow(m1[i].Y - q.Y, 2));
                if (distanta <= distanta_maxima)
                {
                    Pen p_line = new Pen(Color.Black, 2);
                    g.DrawLine(p_line, m1[i].X, m1[i].Y, q.X, q.Y);
                }
            }
        }

    }
}