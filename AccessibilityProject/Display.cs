using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Windows.Forms;

namespace AccessibilityProject
{
    public partial class Display : Form
    {
        internal Timer count_down_timer = new Timer();
        internal int total_time;

        internal Image<Bgr, byte> setImage
        {
            set => formImageBox.Image = value;
        }

        internal string Head_status
        {
            set { headLabel.Text = "Head: " + value; }
        }

        internal string Back_status
        {
            set { backLabel.Text = "Back: " + value; }
        }

        internal string Left_arm_status
        {
            set { leftArmLabel.Text = "Left Arm: " + value; }
        }

        internal string Right_arm_status
        {
            set { rightArmLabel.Text = "Right Arm: " + value; }
        }

        internal string Left_leg_status
        {
            set { leftLegLabel.Text = "Left Leg: " + value; }
        }

        internal string Right_leg_status
        {
            set { rightLegLabel.Text = "Right Leg: " + value; }
        }

        internal string Left_foot_status
        {
            set { leftFootLabel.Text = "Left Foot: " + value; }
        }

        internal string Right_foot_status
        {
            set { rightFootLabel.Text = "Right Foot: " + value; }
        }

        internal int Set_timer
        {
            set
            {
                total_time = value;
                System.Diagnostics.Debug.WriteLine(value);
                count_down_timer.Interval = 1000;
                count_down_timer.Tick += new EventHandler(one_tick);
                count_down_timer.Enabled = true;
            }
        }

        internal void one_tick(object sender, EventArgs e)
        {
            if(total_time > 0)
            {
                total_time-=1000;
            }else if(total_time == 0)
            {
                count_down_timer.Stop();
            }
            timerLabel.Text = (total_time / 1000).ToString() + "s";
        }

        internal string Program_status
        {
            set { statusLabel.Text = "Status: " + value; }
        }

        internal string Text_box_status
        {
            set { mainTextBox.Text = value; }
        }

        public Display()
        {
            InitializeComponent();
            MSKinect.setup_kinect(this);
        }
    }
}
