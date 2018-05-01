using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Windows.Forms;

namespace AccessibilityProject
{
    public partial class Display : Form
    {

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


        internal int Set_counter
        {
            set { countLabel.Text = value.ToString(); }
        }

        internal string Program_status
        {
            set { statusLabel.Text = "Status: " + value; }
        }

        internal string Text_box_status
        {
            set { mainTextBox.Text = value; }
        }

        internal void play_audio(System.IO.UnmanagedMemoryStream audio_file_stream)
        {
            SoundPlayer player = new SoundPlayer(audio_file_stream);
            player.Play();
        }

        public Display()
        {
            InitializeComponent();
            MSKinect.setup_kinect(this);
        }
    }
}
