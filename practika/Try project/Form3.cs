using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.Diagnostics;

namespace Try_project
{
    public partial class Form3 : Form
    {
        Queue q1 = new Queue();
        Queue q2 = new Queue();
        Queue q3 = new Queue();
        pedestrialight pl1, pl2;
        trafficlight tl1, tl2, tl3;
        Stopwatch stopwatch;
        double direction;

        int carnb = -1;
        car[] cars;

        int carnb2 = -1;
        car[] cars2;

        int carnb3 = -1;
        car[] cars3;

        int[] lst;
        int[] lst2;
        int[] lst3;

        public Form3()
        {
            stopwatch = new Stopwatch();
            InitializeComponent();
            q1 = Expo(10, 10);
            q2 = Expo(10, 10);
            q3 = Expo(10, 10);
            tl1 = new trafficlight(RED1, GREEN1, YELLOW1, q1);
            tl2 = new trafficlight(RED2, GREEN2, YELLOW2, q2);
            tl3 = new trafficlight(RED3, GREEN3, YELLOW3, q3);
            pl1 = new pedestrialight(PRED1, PGREEN1, tl1);
            pl2 = new pedestrialight(PRED2, PGREEN2, tl2);
            tl2.g.Visible = false;
            tl2.r.Visible = true;
            tl2.y.Visible = false;

            tl2.g.Visible = false;
            tl2.r.Visible = true;
            tl2.y.Visible = false;

            tl3.g.Visible = false;
            tl3.r.Visible = true;
            tl3.y.Visible = false;

            pl1.g.Visible = true;
            pl1.r.Visible = false;

            pl2.g.Visible = true;
            pl2.r.Visible = false;

            stopwatch.Start();      

            cars = new car[q1.Count];
            lst = new int[q1.Count];
            for (int i = 0; i < q1.Count; i++) lst[i] = 10000;

            cars2 = new car[q2.Count];
            lst2 = new int[q2.Count];
            for (int i = 0; i < q2.Count; i++) lst2[i] = 10000;

            cars3 = new car[q3.Count];
            lst3 = new int[q3.Count];
            for (int i = 0; i < q3.Count; i++) lst3[i] = 10000;
        }

        public static Queue Expo(double mean, double period)
        {
            Queue q = new Queue();
            Random g = new Random();
            double current_time = 0.0, u, inter;
            while (current_time < period)
            {
                u = g.NextDouble(); // u in [0,1]
                inter = -1.0 / mean * Math.Log(1 - u);
                current_time += inter;
                if (current_time < period) q.Enqueue(current_time);
            }
            return q;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
        } 
        private void timer1_Tick(object sender, EventArgs e)
        {

            mario.Visible = true;
            mario2.Visible = true;

            mario222.Visible = true;          
            mario1.Visible = true;

            pl1.counter++;
            pl1.switchcolor(tl1, tl2, tl3);
            pl2.counter++;
            pl2.switchcolor(tl1, tl2, tl3);

            tl1.counter++;
            tl2.counter++;
            tl3.counter++;
            tl1.switchcolor1(pl1, pl2);
            tl2.switchcolor1(pl1, pl2);
            tl3.switchcolor1(pl1, pl2);

            if (pl2.g.Visible == true)
            {
                mario.Left += 27;
                mario1.Left += 27;          

                if (mario.Left > 650)
                {
                    mario.Visible = false;
                    mario1.Visible = false;
             
                    mario.Left = 458;
               
                    mario1.Left = 458;
                }
            }
            if (pl1.g.Visible == true)
            {
                mario2.Top -= 27;
                mario222.Top -= 27;
                if (mario2.Top < 220)
                {
                    mario2.Visible = false;

                    mario222.Visible = false;
                    mario2.Top = 425;
                    mario222.Top = 425;

                }
            }
        }

        double d2,d,d3;
        Random g2,g, g3;
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (q1.Count != 0)// road 2
            {
                d2 = (double)q1.Peek() * 60000;
                if (stopwatch.ElapsedMilliseconds > (int)(d2))
                {
                    q1.Dequeue();
                    carnb++;
                    g2 = new Random();
                    direction = g2.NextDouble();
                  
                    if (direction >= 0.3)// go left
                    {
                        car aux = new car(1900, 280, 2, 1);
                        aux.mid = 530;
                        aux.XFINAL = 0;
                        aux.YFINAL = aux.mid;
                        aux.road1Ylim = 785;
                        aux.pb.Image = Properties.Resources.rightt;
                        aux.pb.Size = new Size(60, 50);
                      
                        cars[carnb] = aux;
                    }
                    else // go straight
                    {
                        car aux = new car(1900, 280, 2, 3);
                        aux.YFINAL = 2000;
                        aux.XFINAL = 555;
                        aux.road1Ylim = 785;
                        aux.mid = 600;
                        aux.pb.Image = Properties.Resources.taxi;
                        aux.pb.Size = new Size(60, 50);
                        aux.pb.SizeMode = PictureBoxSizeMode.StretchImage;
                        aux.pb.BackColor = Color.Transparent;
                        aux.pb.BackgroundImage = Properties.Resources.b;
                        cars[carnb] = aux;
                    }
                    this.Controls.Add(cars[carnb].pb);
                    cars[carnb].pb.BringToFront();
                }
            }
            if (q2.Count != 0)// road 4
            {
                d = (double)q2.Peek() * 60000;
                if (stopwatch.ElapsedMilliseconds > (int)(d))
                {
                    q2.Dequeue();
                    carnb2++;
                    g = new Random();
                    direction = g.NextDouble();
                    if (direction < 0.3) //go left 
                    {
                        car aux = new car(630, 900, 4, 1);
                        aux.XFINAL = -50;
                        aux.YFINAL = aux.mid;
                        aux.mid = 280;
                        aux.road1Ylim = 500;
                        aux.pb.Image = Properties.Resources.leftt ;
                        aux.pb.Size = new Size(60, 50);
                        aux.pb.BackgroundImage = Properties.Resources.b;
                        aux.pb.BackColor = Color.Transparent;
                        cars2[carnb2] = aux;
                    }                   
                    else// go right
                    {
                        car aux = new car(630, 900, 4, 2);
                        aux.YFINAL = 2000;
                        aux.XFINAL = 555;
                        aux.mid = 350;
                        aux.road1Ylim = 500;
                        aux.pb.Image = Properties.Resources.rightt;
                        aux.pb.Size = new Size(60, 50);
                        aux.pb.SizeMode = PictureBoxSizeMode.StretchImage;
                        aux.pb.BackColor = Color.Transparent;
                        cars2[carnb2] = aux;
                    }
                    this.Controls.Add(cars2[carnb2].pb);
                    cars2[carnb2].pb.BringToFront();
                }
            }
            if (q3.Count != 0)// road 3
            {
                d3 = (double)q3.Peek() * 60000;
                if (stopwatch.ElapsedMilliseconds > (int)(d3))
                {
                    q3.Dequeue();
                    carnb3++;
                    g3 = new Random();
                    direction = g3.NextDouble();
                    if (direction < 0.3) //go straight 
                    {
                        car aux = new car(-60, 350, 3, 3);
                        aux.YFINAL = 2000;
                        aux.XFINAL = 555;
                        aux.road1Ylim = 464;
                        aux.mid = 555;
                        aux.pb.Image = Properties.Resources.leftt;
                        aux.pb.Size = new Size(60, 50);
                        aux.pb.SizeMode = PictureBoxSizeMode.StretchImage;
                        aux.pb.BackColor = Color.Transparent;
                        aux.pb.BackgroundImage = Properties.Resources.b;
                        cars3[carnb3] = aux;
                    }
                    else// go right
                    {
                        car aux = new car(-60, 350, 3, 2);
                        aux.mid = 555;
                        aux.XFINAL = 5000;
                        aux.YFINAL = aux.mid;
                        aux.road1Ylim = 464;
                        aux.pb.Image = Properties.Resources.rightt;
                        aux.pb.Size = new Size(60, 50);
                        aux.pb.SizeMode = PictureBoxSizeMode.StretchImage;
                        aux.pb.BackColor = Color.Transparent;
                        aux.pb.BackgroundImage = Properties.Resources.b;
                        cars3[carnb3] = aux;
                    }
                    this.Controls.Add(cars3[carnb3].pb);
                    cars3[carnb3].pb.BringToFront();
                }
            }
        }
        private void cartimere_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < carnb2 + 1; i++)
                lst2[i] = cars2[i].move(tl2, lst2, i);
            for (int i = 0; i < carnb + 1; i++)
                lst[i] = cars[i].move(tl1, lst, i);
            for (int i = 0; i < carnb3 + 1; i++)
                lst3[i] = cars3[i].move(tl3, lst3, i);
        }
    }
}


    

