using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing;
namespace AccessibilityProject
{
    internal static class DrawingHelper
    {
        /// <summary>
        /// draw all the tracked joints(green)
        /// </summary>
        /// <param name="joints_to_draw"></param>
        /// <param name="image"></param>
        internal static void draw_tracked_joints(ColorSpacePoint[] joints_to_draw, Image<Bgr, byte> image)
        {
            foreach(var joint_clrspace in joints_to_draw)
            {
                if(joint_clrspace.X >= 0.0 && joint_clrspace.X <= 1920.0 && joint_clrspace.Y >= 0.0 && joint_clrspace.Y <= 1080.0)
                {
                    CvInvoke.Circle(image,
                        new Point((int)joint_clrspace.X / 2, (int)joint_clrspace.Y / 2), 5,
                        new MCvScalar(0, 255, 0), -1);
                }
            }
        }

        /// <summary>
        /// draw all the inferred joints(red)
        /// </summary>
        /// <param name="joints_to_draw"></param>
        /// <param name="image"></param>
        internal static void draw_inferred_joints(ColorSpacePoint[] joints_to_draw, Image<Bgr, byte> image)
        {
            foreach(var joint_clrspace in joints_to_draw)
            {
                if(joint_clrspace.X >= 0.0 && joint_clrspace.X <= 1920.0 && joint_clrspace.Y >= 0.0 && joint_clrspace.Y <= 1080.0)
                {
                    CvInvoke.Circle(image,
                        new Point((int)joint_clrspace.X / 2, (int)joint_clrspace.Y / 2), 5,
                        new MCvScalar(0, 0, 255), -1);
                }
            }
        }
    }
}
