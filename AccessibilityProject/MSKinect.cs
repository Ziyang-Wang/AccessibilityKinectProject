using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Kinect;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace AccessibilityProject
{
    /// <summary>
    /// Kinect attributes and functionalities, where access is limited to current assembly
    /// </summary>
    internal static class MSKinect
    {
        // the Kinect device(sensor)
        private static KinectSensor kinect_sensor = null;
        // reader for color, body, and depth frame
        private static MultiSourceFrameReader multi_source_frame_reader = null;

        private static Image<Bgr, byte> display_kinect_image = new Image<Bgr, byte>(640, 360);

        internal static CameraSpacePoint head;
        internal static CameraSpacePoint neck;
        internal static CameraSpacePoint wrist_left;
        internal static CameraSpacePoint wrist_right;
        internal static CameraSpacePoint shoulder_center;
        internal static CameraSpacePoint shoulder_left;
        internal static CameraSpacePoint shoulder_right;
        internal static CameraSpacePoint elbow_left;
        internal static CameraSpacePoint elbow_right;
        internal static CameraSpacePoint hip_center;
        internal static CameraSpacePoint hip_left;
        internal static CameraSpacePoint hip_right;
        internal static CameraSpacePoint knee_left;
        internal static CameraSpacePoint knee_right;

        //internal static CameraSpacePoint ankle_left;
        //internal static CameraSpacePoint ankle_right;

        internal static CameraSpacePoint foot_left;
        internal static CameraSpacePoint foot_right;

        /// <summary>
        /// set up the kinect if possible and run the multi source frame reader
        /// </summary>
        /// <param name="display_form"></param>
        internal static void setup_kinect(Display display_form)
        {
            // gets the default sensor
            kinect_sensor = KinectSensor.GetDefault();

            display_form.Program_status = "Kinect Not Found";

            kinect_sensor.Open();

            // initialize the frame reader that reads color, body, depth frame
            multi_source_frame_reader = kinect_sensor.OpenMultiSourceFrameReader(FrameSourceTypes.Color |
                                                                                 FrameSourceTypes.Body  |
                                                                                 FrameSourceTypes.Depth);
            
            // Read frames from Kinect and synchronize the display form
            // Anonymous event handler
            multi_source_frame_reader.MultiSourceFrameArrived += delegate(object sender, MultiSourceFrameArrivedEventArgs e)
            {
                MultiSourceFrameArrived(sender, e, display_form);
            };
        }

        /// <summary>
        /// action called by the anonymous event handler for every frame arriving
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="form"></param>
        private static void MultiSourceFrameArrived(object sender, MultiSourceFrameArrivedEventArgs e, Display form)
        {
            // get the current acquired frames
            var multiFrames = e.FrameReference.AcquireFrame();
            // automatic resource management with acquired color, body, depth frames
            using (var color_frame = multiFrames.ColorFrameReference.AcquireFrame())
            using (var body_frame = multiFrames.BodyFrameReference.AcquireFrame())
            using (var depth_frame = multiFrames.DepthFrameReference.AcquireFrame())
            {
                // all the frames have to be acquired
                if (color_frame != null && body_frame != null && depth_frame != null)
                {
                    var color_frame_width = color_frame.FrameDescription.Width;
                    var color_frame_height = color_frame.FrameDescription.Height;
                    var color_frame_pixels = new byte[color_frame_width * color_frame_height * 4];
                    var bitmap = new Bitmap(color_frame_width, color_frame_height, PixelFormat.Format32bppRgb);

                    color_frame.CopyConvertedFrameDataToArray(color_frame_pixels, ColorImageFormat.Bgra);

                    var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                                                    ImageLockMode.WriteOnly, bitmap.PixelFormat);
                    Marshal.Copy(color_frame_pixels, 0, bitmapData.Scan0, color_frame_pixels.Length);
                    bitmap.UnlockBits(bitmapData);

                    // wrap the bitmap data into an image object(1920 x 1080)
                    Image<Bgr, byte> bgr = new Image<Bgr, byte>(bitmap);
                    // resize the image into 960 x 540
                    CvInvoke.Resize(bgr, display_kinect_image, new Size(640, 360));

                    //var depth_width = depth_frame.FrameDescription.Width;
                    //var depth_height = depth_frame.FrameDescription.Height;
                    //var depthData = new ushort[depth_width * depth_height];
                    //depth_frame.CopyFrameDataToArray(depthData);

                    var bodies = new Body[kinect_sensor.BodyFrameSource.BodyCount];

                    body_frame.GetAndRefreshBodyData(bodies);

                    var body = bodies.Where(bd => bd.IsTracked).FirstOrDefault();

                    form.Program_status = "Detecting Body";

                    if (body != null)
                    {
                        form.Program_status = "Body Tracked";
                        head = body.Joints[JointType.Head].Position;
                        neck = body.Joints[JointType.Neck].Position;
                        shoulder_center = body.Joints[JointType.SpineShoulder].Position;
                        hip_center = body.Joints[JointType.SpineBase].Position;
                        wrist_left = body.Joints[JointType.WristLeft].Position;
                        wrist_right = body.Joints[JointType.WristRight].Position;
                        shoulder_left = body.Joints[JointType.ShoulderLeft].Position;
                        shoulder_right = body.Joints[JointType.ShoulderRight].Position;
                        elbow_left = body.Joints[JointType.ElbowLeft].Position;
                        hip_left = body.Joints[JointType.HipLeft].Position;
                        knee_left = body.Joints[JointType.KneeLeft].Position;
                        foot_left = body.Joints[JointType.FootLeft].Position;
                        elbow_right = body.Joints[JointType.ElbowRight].Position;
                        hip_right = body.Joints[JointType.HipRight].Position;
                        knee_right = body.Joints[JointType.KneeRight].Position;
                        foot_right = body.Joints[JointType.FootRight].Position;

                        //ankle_left = body.Joints[JointType.AnkleLeft].Position;
                        //ankle_right = body.Joints[JointType.AnkleRight].Position;


                        var body_joints = body.Joints.Values;

                        var body_joints_Trked = new Joint[body_joints.Count()];
                        var body_joints_Infrd = new Joint[body_joints.Count()];

                        var body_joints_CamSpacePts_Trked = new CameraSpacePoint[body_joints.Count()];
                        var body_joints_ClrSpacePts_Trked = new ColorSpacePoint[body_joints.Count()];

                        var body_joints_CamSpacePts_Infrd = new CameraSpacePoint[body_joints.Count()];
                        var body_joints_ClrSpacePts_Infrd = new ColorSpacePoint[body_joints.Count()];
                        var untracked_joints = new List<Joint>(0);

                        int i = 0, j = 0;
                        foreach(var joint in body_joints)
                        {
                            if (joint.TrackingState == TrackingState.Tracked)
                            {
                                body_joints_Trked[i] = joint;
                                body_joints_CamSpacePts_Trked[i] = joint.Position;
                                i++;
                            }
                            else if(joint.TrackingState == TrackingState.Inferred)
                            {
                                body_joints_Infrd[i] = joint;
                                body_joints_CamSpacePts_Infrd[j] = joint.Position;
                                j++;
                            }
                            else
                            {
                                untracked_joints.Add(joint);
                            }
                        }
                        kinect_sensor.CoordinateMapper.MapCameraPointsToColorSpace(body_joints_CamSpacePts_Trked, body_joints_ClrSpacePts_Trked);
                        kinect_sensor.CoordinateMapper.MapCameraPointsToColorSpace(body_joints_CamSpacePts_Infrd, body_joints_ClrSpacePts_Infrd);

                        DrawingHelper.draw_tracked_joints(body_joints_ClrSpacePts_Trked, display_kinect_image);
                        DrawingHelper.draw_inferred_joints(body_joints_ClrSpacePts_Infrd, display_kinect_image);

                        
                        if (!HighKnees.ready_for_tutoring)
                        {
                            if (HighKnees.check_for_tutoring(form))
                            {
                                HighKnees.ready_for_tutoring = true;
                            } 
                        }else
                        {
                            if (!HighKnees.finished_first_half)
                            {
                                form.Program_status = "First-Half Tutoring";
                                HighKnees.first_half_tutoring(form);
                            }
                            else if(!HighKnees.finished_second_half)
                            {
                                form.Program_status = "Second-Half Tutoring";
                                HighKnees.second_half_tutoring(form);
                            }
                            else
                            {
                                form.Program_status = "Free-mode";
                                form.Text_box_status = "Now you are in execrising mode. Practice more to gain a better skill!";
                            }
                        }
                    }
                    else
                    {
                        HighKnees.ready_for_tutoring = false;
                    }
                }
                form.setImage = display_kinect_image;
            }
        }
    }
}
