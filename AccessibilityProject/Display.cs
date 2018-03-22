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
        public Image<Bgr, byte> setImage
        {
            set => formImageBox.Image = value;
        }

        public Display()
        {
            InitializeComponent();
            MSKinect.setup_kinect(this);
        }
    }
}
