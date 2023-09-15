using System.Windows.Forms;

namespace Try_project
{
    class pedestrialight
    {
        public trafficlight tl;
        public PictureBox r;
        public PictureBox g;
        public int redtime = 8;
        public int greentime = 5;
        public int counter = 0;
        public virtual void turnongreen()
        {
            r.Visible = false;
            g.Visible = true;
        }
        public virtual void turnonred()
        {
            r.Visible = true;
            g.Visible = false;
        }
        public pedestrialight(PictureBox red, PictureBox green, trafficlight traffic)        
        {
            r = red;
            g = green;
            tl = traffic;
            redtime = traffic.greentime + traffic.yellowtime;
            greentime = traffic.redtime;
        }
        public virtual void switchcolor(trafficlight tl1, trafficlight tl2, trafficlight tl3)
        {
            if (r.Visible == true && redtime <= counter && (tl1.r.Visible == true || tl1.y.Visible == true) && (tl2.r.Visible == true || tl2.y.Visible == true) && (tl3.r.Visible == true || tl3.y.Visible == true))
            {
                turnongreen();
                counter = 0;
            }
            else
            {
                if (g.Visible == true && greentime == counter)
                {
                    turnonred();
                    counter = 0;
                }

            }
        }
    }  
}
