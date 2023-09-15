using System.Windows.Forms;
using System.Collections;

namespace Try_project
{
    class trafficlight
    {
        public PictureBox y;
        public int yellowtime = 2;
        public int total;
        public PictureBox r;
        public PictureBox g;
        public int redtime = 8;
        public int greentime = 5;
        public int counter = 0;
        public trafficlight(PictureBox red1, PictureBox green1, PictureBox yellow1, Queue queue)
        {
            r = red1;
            g= green1;
            y = yellow1;
            total = yellowtime + greentime;
            y.Visible = false;
        }
        public virtual void turnongreen()
        {
            r.Visible = false;
            g.Visible = true;
            y.Visible = false;
        }
        public virtual void turnonred()
        {
            r.Visible = true;
            g.Visible = false;
            y.Visible = false;
        }
        public void turnonyellow()
        {
            r.Visible = false;
            g.Visible = false;
            y.Visible = true;
        }
        public void switchcolor1(pedestrialight ps1, pedestrialight ps2)
        {
            if (r.Visible == true && redtime <= counter && ps1.r.Visible == true && ps2.r.Visible == true)
            {
                turnongreen();
                counter = 0;
            }
            else
            {
                if (g.Visible == true && counter >= greentime)
                {
                    turnonyellow();                   
                    counter = 0;
                }
                else
                {
                    if (y.Visible == true && counter >= yellowtime)
                    {
                        turnonred();                     
                        counter = 0;
                    }
                }
            }
        }
    }
}

