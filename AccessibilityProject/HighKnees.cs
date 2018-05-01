using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;
using System.Diagnostics;
using System.Windows.Forms;

namespace AccessibilityProject
{
    internal static class HighKnees
    {
        internal static bool played_check_for_tutoring = false;

        internal static bool played_curl_right_arm = false;

        internal static bool played_raise_left_knee_up = false;

        internal static bool played_bend_left_arm_backward = false;
        
        internal static bool played_curl_left_arm = false;

        internal static bool played_raise_right_knee_up = false;

        internal static bool played_bend_right_arm_backward = false;

        internal static bool played_third_quarter_tutoring = false;

        internal static bool played_free_mode = false;


        internal static bool ready_for_tutoring = false;

        internal static bool finished_first_quarter = false;

        internal static bool finished_second_quarter = false;

        internal static bool finished_third_quarter = false;

        internal static bool finished_fourth_quarter = false;

        internal static bool finish_first_part_exercise = false;

        internal static bool finish_second_part_exercise = false;

        internal static int count = 0;

        // whether each part of the person's body is placed correctly
        private static bool head_okay = false;

        private static bool back_okay = false;

        private static bool left_arm_okay = false;

        private static bool right_arm_okay = false;

        private static bool left_leg_okay = false;

        private static bool right_leg_okay = false;

        private static bool left_foot_okay = false;

        private static bool right_foot_okay = false;

        /// <summary>
        /// check whether the participant is ready for tutoring
        /// </summary>
        /// <returns></returns>
        internal static bool check_for_tutoring(Display form)
        {
            if (!played_check_for_tutoring)
            {
                form.play_audio(Properties.Resources.check_for_tutoring);
                played_check_for_tutoring = true;
            }
            form.Text_box_status = "Stand straight with your head and back up, arms at two sides, and legs straight";

            head_okay = false;

            back_okay = false;

            left_arm_okay = false;

            right_arm_okay = false;

            left_leg_okay = false;

            right_leg_okay = false;

            left_foot_okay = false;

            right_foot_okay = false;

            if (head_okay && back_okay && left_arm_okay && right_arm_okay && left_leg_okay && right_leg_okay && left_foot_okay && right_foot_okay)
            {
                return true;
            }
            // check for head
            float headX = MSKinect.head.X - MSKinect.neck.X, headZ;
            if (headX > 0.03)
            {
                form.Head_status = "Tilt your head toward your left";
            }
            else if (headX < -0.03)
            {
                form.Head_status = "Tilt your head toward your right";
            }
            else
            {
                headZ = MSKinect.head.Z - MSKinect.neck.Z;
                if (headZ > 0.05)
                {
                    form.Head_status = "Tilt your head forward";
                }
                else if (headZ < 0)
                {
                    form.Head_status = "Tilt your head backward";
                }
                else
                {
                    head_okay = true;
                    form.Head_status = "Okay";
                }
            }

            // check for back
            float backX = MSKinect.shoulder_center.X - MSKinect.hip_center.X, backZ;
            if (backX > 0.05)
            {
                form.Back_status = "Lean sideways toward your left";
            }
            else if (backX < -0.05)
            {
                form.Back_status = "Lean sideways toward your right";
            }
            else
            {
                backZ = MSKinect.shoulder_center.Z - MSKinect.hip_center.Z;
                if (backZ > 0.15)
                {
                    form.Back_status = "Lean forward";
                }
                else if (backZ < -0.04)
                {
                    form.Back_status = "Lean backward";
                }
                else
                {
                    back_okay = true;
                    form.Back_status = "Okay";
                }
            }


            double[] eblow_left_to_shoulder_left = MathCalculation.turn_campts_to_vector(MSKinect.elbow_left, MSKinect.shoulder_left);
            double[] eblow_left_to_wrist_left = MathCalculation.turn_campts_to_vector(MSKinect.elbow_left, MSKinect.wrist_left);
            //form.Left_arm_status = Convert.ToInt32(MathCalculation.angle_between_two_vectors(eblow_left_to_wrist_left, eblow_left_to_shoulder_left));

            double[] eblow_right_to_wrist_right = MathCalculation.turn_campts_to_vector(MSKinect.elbow_right, MSKinect.wrist_right);
            double[] eblow_right_to_shoulder_right = MathCalculation.turn_campts_to_vector(MSKinect.elbow_right, MSKinect.shoulder_right);
            // check for left arm
            if (MathCalculation.angle_between_two_vectors(eblow_left_to_wrist_left, eblow_left_to_shoulder_left) >= 153)
            {
                if (MSKinect.hip_left.X - MSKinect.wrist_left.X <= 0.20)
                {
                    left_arm_okay = true;
                    form.Left_arm_status = "Okay";
                }
                else if (MSKinect.hip_left.X - MSKinect.wrist_left.X > 0.20)
                {
                    form.Left_arm_status = "Lower your left arm down and keep it straight";
                }
                else if (MSKinect.hip_left.X - MSKinect.wrist_left.X < 0)
                {
                    form.Left_arm_status = "Keep your left arm at the left side body";
                }
            }
            else
            {
                form.Left_arm_status = "Straighten your left arm";
            }

            // check for right arm
            if (MathCalculation.angle_between_two_vectors(eblow_right_to_wrist_right, eblow_right_to_shoulder_right) >= 153)
            {
                if (MSKinect.wrist_right.X - MSKinect.hip_right.X <= 0.20)
                {
                    right_arm_okay = true;
                    form.Right_arm_status = "Okay";
                }
                else if (MSKinect.wrist_right.X - MSKinect.hip_right.X > 0.17)
                {
                    form.Right_arm_status = "Lower your right arm down and keep it straight";
                }
                else if (MSKinect.wrist_right.X - MSKinect.hip_right.X < 0)
                {
                    form.Right_arm_status = "Keep your right arm at the right side body";
                }
            }
            else
            {
                form.Right_arm_status = "Straighten your right arm";
            }

            double[] knee_left_to_hip_left = MathCalculation.turn_campts_to_vector(MSKinect.knee_left, MSKinect.hip_left);
            double[] knee_left_to_foot_left = MathCalculation.turn_campts_to_vector(MSKinect.knee_left, MSKinect.foot_left);

            double[] knee_right_to_hip_right = MathCalculation.turn_campts_to_vector(MSKinect.knee_right, MSKinect.hip_right);
            double[] knee_right_to_foot_right = MathCalculation.turn_campts_to_vector(MSKinect.knee_right, MSKinect.foot_right);

            //form.Left_leg_status = Convert.ToInt32(MathCalculation.angle_between_two_vectors(knee_left_to_hip_left, knee_left_to_foot_left));
            // check for left leg
            if (MathCalculation.angle_between_two_vectors(knee_left_to_hip_left, knee_left_to_foot_left) >= 165)
            {
                left_leg_okay = true;
                form.Left_leg_status = "Okay";
            }
            else
            {
                form.Left_leg_status = "Straighten your left leg";
            }

            // check for right leg
            if (MathCalculation.angle_between_two_vectors(knee_right_to_hip_right, knee_right_to_foot_right) >= 165)
            {
                right_leg_okay = true;
                form.Right_leg_status = "Okay";
            }
            else
            {
                form.Right_leg_status = "Straighten your right leg";
            }

            // check for left foot
            if (MSKinect.foot_left.X >= MSKinect.shoulder_left.X)
            {
                left_foot_okay = true;
                form.Left_foot_status = "Okay";
            }
            else
            {
                form.Left_foot_status = "Move your left foot rightward";
            }

            // check for right foot
            if (MSKinect.foot_right.X <= MSKinect.shoulder_right.X)
            {
                right_foot_okay = true;
                form.Right_foot_status = "Okay";
            }
            else
            {
                form.Right_foot_status = "Move your right foot leftward";
            }
            return head_okay && back_okay && left_arm_okay && right_arm_okay && left_leg_okay && right_leg_okay && left_foot_okay && right_foot_okay;
        }

        /// <summary>
        /// first half of the tutoring
        /// </summary>
        /// <param name="form"></param>
        internal static void first_quarter_tutoring(Display form)
        {
            form.Text_box_status = "First, curl your right arm up with your wrist at the chest level";
            if (!played_curl_right_arm)
            {
                form.play_audio(Properties.Resources.curl_right_arm);
                played_curl_right_arm = true;
            }

            head_okay = false;

            back_okay = false;

            left_arm_okay = false;

            right_arm_okay = false;

            left_leg_okay = false;

            right_leg_okay = false;

            left_foot_okay = false;

            right_foot_okay = false;

            form.Right_arm_status = "";
            form.Left_leg_status = "";
            form.Left_arm_status = "";

            // check for head
            float headX = MSKinect.head.X - MSKinect.neck.X, headZ;
            if (headX > 0.03)
            {
                form.Head_status = "Tilt your head toward your left";
            }
            else if (headX < -0.03)
            {
                form.Head_status = "Tilt your head toward your right";
            }
            else
            {
                headZ = MSKinect.head.Z - MSKinect.neck.Z;
                if (headZ > 0.05)
                {
                    form.Head_status = "Tilt your head forward";
                }
                else if (headZ < 0)
                {
                    form.Head_status = "Tilt your head backward";
                }
                else
                {
                    head_okay = true;
                    form.Head_status = "Okay";
                }
            }

            // check for back
            float backX = MSKinect.shoulder_center.X - MSKinect.hip_center.X, backZ;
            if (backX > 0.05)
            {
                form.Back_status = "Lean sideways toward your left";
            }
            else if (backX < -0.05)
            {
                form.Back_status = "Lean sideways toward your right";
            }
            else
            {
                backZ = MSKinect.shoulder_center.Z - MSKinect.hip_center.Z;
                if (backZ > 0.15)
                {
                    form.Back_status = "Lean forward";
                }
                else if (backZ < -0.04)
                {
                    form.Back_status = "Lean backward";
                }
                else
                {
                    back_okay = true;
                    form.Back_status = "Okay";
                }
            }

            double[] knee_right_to_hip_right = MathCalculation.turn_campts_to_vector(MSKinect.knee_right, MSKinect.hip_right);
            double[] knee_right_to_foot_right = MathCalculation.turn_campts_to_vector(MSKinect.knee_right, MSKinect.foot_right);
            // check for right leg
            if (MathCalculation.angle_between_two_vectors(knee_right_to_hip_right, knee_right_to_foot_right) >= 163)
            {
                right_leg_okay = true;
                form.Right_leg_status = "Okay";
            }
            else
            {
                form.Right_leg_status = "Straighten your right leg";
            }
            // check for right foot
            if (MSKinect.foot_right.X <= MSKinect.shoulder_right.X)
            {
                right_foot_okay = true;
                form.Right_foot_status = "Okay";
            }
            else
            {
                form.Right_foot_status = "Move your right foot leftward";
            }



            // check for right arm
            double[] eblow_right_to_wrist_right = MathCalculation.turn_campts_to_vector(MSKinect.elbow_right, MSKinect.wrist_right);
            double[] eblow_right_to_shoulder_right = MathCalculation.turn_campts_to_vector(MSKinect.elbow_right, MSKinect.shoulder_right);

            //form.Right_arm_status = "" + Convert.ToInt32(MathCalculation.angle_between_two_vectors(eblow_right_to_wrist_right, eblow_right_to_shoulder_right));
            //form.Right_arm_status = "" + (MSKinect.elbow_right.X - MSKinect.shoulder_right.X);

            if (MathCalculation.angle_between_two_vectors(eblow_right_to_wrist_right, eblow_right_to_shoulder_right) <= 90.0)
            {
                if (MSKinect.elbow_right.X - MSKinect.shoulder_right.X <= 0)
                {
                    form.Right_arm_status = "Keep your right eblow at the right side body";

                }
                else if (MSKinect.elbow_right.X - MSKinect.shoulder_right.X > 0.15)
                {
                    form.Right_arm_status = "Lower your right elbow down";
                }
                else if (MSKinect.elbow_right.X - MSKinect.shoulder_right.X > 0)
                {
                    if (MSKinect.wrist_right.X - MSKinect.elbow_right.X > 0)
                    {
                        form.Right_arm_status = "Move your right wrist to your left";
                    }
                    else if (MSKinect.shoulder_center.X - MSKinect.wrist_right.X > 0)
                    {
                        form.Right_arm_status = "Move your right wrist to your right";
                    }
                    else
                    {
                        form.Right_arm_status = "Okay";
                        right_arm_okay = true;
                    }
                }
            }
            else
            {
                form.Right_arm_status = "Curl your right arm more";
            }

            if (!right_arm_okay)
            {
                return;
            }

            form.Text_box_status = "Next, raise your left knee up to reach at least waist height and make sure the tip of your toe is pointing downward";
            if (!played_raise_left_knee_up)
            {
                form.play_audio(Properties.Resources.raise_left_knee_up);
                played_raise_left_knee_up = true;
            }

            double[] knee_left_to_hip_left = MathCalculation.turn_campts_to_vector(MSKinect.knee_left, MSKinect.hip_left);
            double[] knee_left_to_foot_left = MathCalculation.turn_campts_to_vector(MSKinect.knee_left, MSKinect.foot_left);

            if (MSKinect.knee_left.Y - MSKinect.hip_center.Y <= -0.04)
            {
                form.Left_leg_status = "Raise your left knee higher";
            }
            else
            {
                if (MathCalculation.angle_between_two_vectors(knee_left_to_hip_left, knee_left_to_foot_left) > 90)
                {
                    form.Left_leg_status = "Bend your lower leg more";
                }
                else
                {
                    form.Left_leg_status = "Okay";
                    left_leg_okay = true;
                }
            }

            if (!left_leg_okay)
            {
                return;
            }

            form.Text_box_status = "Also, slightly bend your left arm backward";
            if (!played_bend_left_arm_backward)
            {
                form.play_audio(Properties.Resources.bend_left_arm_backward);
                played_bend_left_arm_backward = true;
            }

            double[] eblow_left_to_shoulder_left = MathCalculation.turn_campts_to_vector(MSKinect.elbow_left, MSKinect.shoulder_left);
            double[] eblow_left_to_wrist_left = MathCalculation.turn_campts_to_vector(MSKinect.elbow_left, MSKinect.wrist_left);

            if (MathCalculation.angle_between_two_vectors(eblow_left_to_shoulder_left, eblow_left_to_wrist_left) > 145)
            {
                form.Left_arm_status = "bend your left arm backward more";
            }
            else
            {
                if (MSKinect.shoulder_left.X - MSKinect.elbow_left.X <= 0)
                {
                    form.Left_arm_status = "Keep your left eblow at the left side body";

                }
                else if (MSKinect.shoulder_left.X - MSKinect.elbow_left.X > 0.15)
                {
                    form.Left_arm_status = "Lower your left elbow down";
                }
                else
                {
                    form.Left_arm_status = "Okay";
                    left_arm_okay = true;
                }
            }

            if (!left_arm_okay)
            {
                return;
            }

            System.Media.SystemSounds.Beep.Play();

            finished_first_quarter = true;
            ready_for_tutoring = false;
            played_check_for_tutoring = false;
        }

        /// <summary>
        /// second half of the tutoring(similar to the first one)
        /// </summary>
        /// <param name="form"></param>
        internal static void second_quarter_tutoring(Display form)
        {
            form.Text_box_status = "First, curl your left arm up with your wrist at the chest level";
            if (!played_curl_left_arm)
            {
                form.play_audio(Properties.Resources.curl_left_arm);
                played_curl_left_arm = true;
            }

            head_okay = false;

            back_okay = false;

            left_arm_okay = false;

            right_arm_okay = false;

            left_leg_okay = false;

            right_leg_okay = false;

            left_foot_okay = false;

            right_foot_okay = false;

            form.Left_arm_status = "";
            form.Right_leg_status = "";
            form.Right_arm_status = "";

            // check for head
            float headX = MSKinect.head.X - MSKinect.neck.X, headZ;
            if (headX > 0.03)
            {
                form.Head_status = "Tilt your head toward your left";
            }
            else if (headX < -0.03)
            {
                form.Head_status = "Tilt your head toward your right";
            }
            else
            {
                headZ = MSKinect.head.Z - MSKinect.neck.Z;
                if (headZ > 0.05)
                {
                    form.Head_status = "Tilt your head forward";
                }
                else if (headZ < 0)
                {
                    form.Head_status = "Tilt your head backward";
                }
                else
                {
                    head_okay = true;
                    form.Head_status = "Okay";
                }
            }

            // check for back
            float backX = MSKinect.shoulder_center.X - MSKinect.hip_center.X, backZ;
            if (backX > 0.05)
            {
                form.Back_status = "Lean sideways toward your left";
            }
            else if (backX < -0.05)
            {
                form.Back_status = "Lean sideways toward your right";
            }
            else
            {
                backZ = MSKinect.shoulder_center.Z - MSKinect.hip_center.Z;
                if (backZ > 0.15)
                {
                    form.Back_status = "Lean forward";
                }
                else if (backZ < -0.04)
                {
                    form.Back_status = "Lean backward";
                }
                else
                {
                    back_okay = true;
                    form.Back_status = "Okay";
                }
            }

            double[] knee_left_to_hip_left = MathCalculation.turn_campts_to_vector(MSKinect.knee_left, MSKinect.hip_left);
            double[] knee_left_to_foot_left = MathCalculation.turn_campts_to_vector(MSKinect.knee_left, MSKinect.foot_left);
            // check for left leg
            if (MathCalculation.angle_between_two_vectors(knee_left_to_hip_left, knee_left_to_foot_left) >= 163)
            {
                left_leg_okay = true;
                form.Left_leg_status = "Okay";
            }
            else
            {
                form.Left_leg_status = "Straighten your left leg";
            }
            // check for left foot
            if (MSKinect.foot_left.X >= MSKinect.shoulder_left.X)
            {
                left_foot_okay = true;
                form.Left_foot_status = "Okay";
            }
            else
            {
                form.Left_foot_status = "Move your left foot rightward";
            }



            // check for left arm
            double[] eblow_left_to_wrist_left = MathCalculation.turn_campts_to_vector(MSKinect.elbow_left, MSKinect.wrist_left);
            double[] eblow_left_to_shoulder_left = MathCalculation.turn_campts_to_vector(MSKinect.elbow_left, MSKinect.shoulder_left);

            //form.Right_arm_status = "" + Convert.ToInt32(MathCalculation.angle_between_two_vectors(eblow_right_to_wrist_right, eblow_right_to_shoulder_right));
            //form.Right_arm_status = "" + (MSKinect.elbow_right.X - MSKinect.shoulder_right.X);

            if (MathCalculation.angle_between_two_vectors(eblow_left_to_wrist_left, eblow_left_to_shoulder_left) <= 90.0)
            {
                if (MSKinect.elbow_left.X - MSKinect.shoulder_left.X >= 0)
                {
                    form.Left_arm_status = "Keep your left eblow at the left side body";

                }
                else if (MSKinect.elbow_left.X - MSKinect.shoulder_left.X < -0.15)
                {
                    form.Left_arm_status = "Lower your left elbow down";
                }
                else if (MSKinect.elbow_left.X - MSKinect.shoulder_left.X < 0)
                {
                    if (MSKinect.wrist_left.X - MSKinect.elbow_left.X < 0)
                    {
                        form.Left_arm_status = "Move your left wrist to your right";
                    }
                    else if (MSKinect.shoulder_center.X - MSKinect.wrist_left.X < 0)
                    {
                        form.Left_arm_status = "Move your left wrist to your left";
                    }
                    else
                    {
                        form.Left_arm_status = "Okay";
                        left_arm_okay = true;
                    }
                }
            }
            else
            {
                form.Left_arm_status = "Curl your left arm more";
            }

            if (!left_arm_okay)
            {
                return;
            }

            form.Text_box_status = "Next, raise your right knee up to reach at least waist height and make sure the tip of your toe is pointing downward";
            if (!played_raise_right_knee_up)
            {
                form.play_audio(Properties.Resources.raise_right_knee_up);
                played_raise_right_knee_up = true;
            }

            double[] knee_right_to_hip_right = MathCalculation.turn_campts_to_vector(MSKinect.knee_right, MSKinect.hip_right);
            double[] knee_right_to_foot_right = MathCalculation.turn_campts_to_vector(MSKinect.knee_right, MSKinect.foot_right);

            if (MSKinect.knee_right.Y - MSKinect.hip_center.Y <= -0.04)
            {
                form.Right_leg_status = "Raise your right knee higher";
            }
            else
            {
                if (MathCalculation.angle_between_two_vectors(knee_right_to_hip_right, knee_right_to_foot_right) > 90)
                {
                    form.Right_leg_status = "Bend your lower leg more";
                }
                else
                {
                    form.Right_leg_status = "Okay";
                    right_leg_okay = true;
                }
            }

            if (!right_leg_okay)
            {
                return;
            }

            form.Text_box_status = "Also, slightly bend your right arm backward";
            if (!played_bend_right_arm_backward)
            {
                form.play_audio(Properties.Resources.bend_right_arm_backward);
                played_bend_right_arm_backward = true;
            }

            double[] eblow_right_to_shoulder_right = MathCalculation.turn_campts_to_vector(MSKinect.elbow_right, MSKinect.shoulder_right);
            double[] eblow_right_to_wrist_right = MathCalculation.turn_campts_to_vector(MSKinect.elbow_right, MSKinect.wrist_right);

            if (MathCalculation.angle_between_two_vectors(eblow_right_to_shoulder_right, eblow_right_to_wrist_right) > 145)
            {
                form.Right_arm_status = "bend your right arm backward more";
            }
            else
            {
                if (MSKinect.shoulder_right.X - MSKinect.elbow_right.X >= 0)
                {
                    form.Right_arm_status = "Keep your right eblow at the right side body";

                }
                else if (MSKinect.shoulder_right.X - MSKinect.elbow_right.X < -0.15)
                {
                    form.Right_arm_status = "Lower your right elbow down";
                }
                else
                {
                    form.Right_arm_status = "Okay";
                    right_arm_okay = true;
                }
            }

            if (!right_arm_okay)
            {
                return;
            }

            System.Media.SystemSounds.Beep.Play();

            finished_second_quarter = true;
            ready_for_tutoring = false;
            played_check_for_tutoring = false;
        }

        internal static bool third_quarter_tutoring(Display form)
        {
            head_okay = false;

            back_okay = false;

            left_arm_okay = false;

            right_arm_okay = false;

            left_leg_okay = false;

            right_leg_okay = false;

            left_foot_okay = false;

            right_foot_okay = false;

            // check for head
            float headX = MSKinect.head.X - MSKinect.neck.X, headZ;
            if (headX > 0.05)
            {
                form.Head_status = "Tilt your head toward your left";
            }
            else if (headX < -0.05)
            {
                form.Head_status = "Tilt your head toward your right";
            }
            else
            {
                headZ = MSKinect.head.Z - MSKinect.neck.Z;
                if (headZ > 0.07)
                {
                    form.Head_status = "Tilt your head forward";
                }
                else if (headZ < -0.2)
                {
                    form.Head_status = "Tilt your head backward";
                }
                else
                {
                    head_okay = true;
                    form.Head_status = "Okay";
                }
            }

            // check for back
            float backX = MSKinect.shoulder_center.X - MSKinect.hip_center.X, backZ;
            if (backX > 0.05)
            {
                form.Back_status = "Lean sideways toward your left";
            }
            else if (backX < -0.05)
            {
                form.Back_status = "Lean sideways toward your right";
            }
            else
            {
                backZ = MSKinect.shoulder_center.Z - MSKinect.hip_center.Z;
                if (backZ > 0.15)
                {
                    form.Back_status = "Lean forward";
                }
                else if (backZ < -0.04)
                {
                    form.Back_status = "Lean backward";
                }
                else
                {
                    back_okay = true;
                    form.Back_status = "Okay";
                }
            }

            double[] knee_right_to_hip_right = MathCalculation.turn_campts_to_vector(MSKinect.knee_right, MSKinect.hip_right);
            double[] knee_right_to_foot_right = MathCalculation.turn_campts_to_vector(MSKinect.knee_right, MSKinect.foot_right);
            // check for right leg
            if (MathCalculation.angle_between_two_vectors(knee_right_to_hip_right, knee_right_to_foot_right) >= 160)
            {
                right_leg_okay = true;
                form.Right_leg_status = "Okay";
            }
            else
            {
                form.Right_leg_status = "Straighten your right leg";
            }
            // check for right foot
            if (MSKinect.foot_right.X <= MSKinect.shoulder_right.X)
            {
                right_foot_okay = true;
                form.Right_foot_status = "Okay";
            }
            else
            {
                form.Right_foot_status = "Move your right foot leftward";
            }



            // check for right arm
            double[] eblow_right_to_wrist_right = MathCalculation.turn_campts_to_vector(MSKinect.elbow_right, MSKinect.wrist_right);
            double[] eblow_right_to_shoulder_right = MathCalculation.turn_campts_to_vector(MSKinect.elbow_right, MSKinect.shoulder_right);


            if (MathCalculation.angle_between_two_vectors(eblow_right_to_wrist_right, eblow_right_to_shoulder_right) <= 90.0)
            {
                if (MSKinect.elbow_right.X - MSKinect.shoulder_right.X <= 0)
                {
                    form.Right_arm_status = "Keep your right eblow at the right side body";

                }
                else if (MSKinect.elbow_right.X - MSKinect.shoulder_right.X > 0.15)
                {
                    form.Right_arm_status = "Lower your right elbow down";
                }
                else if (MSKinect.elbow_right.X - MSKinect.shoulder_right.X > 0)
                {
                    if (MSKinect.wrist_right.X - MSKinect.elbow_right.X > 0)
                    {
                        form.Right_arm_status = "Move your right wrist to your left";
                    }
                    else if (MSKinect.shoulder_center.X - MSKinect.wrist_right.X > 0)
                    {
                        form.Right_arm_status = "Move your right wrist to your right";
                    }
                    else
                    {
                        form.Right_arm_status = "Okay";
                        right_arm_okay = true;
                    }
                }
            }
            else
            {
                form.Right_arm_status = "Curl your right arm more";
            }

            double[] knee_left_to_hip_left = MathCalculation.turn_campts_to_vector(MSKinect.knee_left, MSKinect.hip_left);
            double[] knee_left_to_foot_left = MathCalculation.turn_campts_to_vector(MSKinect.knee_left, MSKinect.foot_left);

            if (MSKinect.knee_left.Y - MSKinect.hip_center.Y <= -0.06)
            {
                form.Left_leg_status = "Raise your left knee higher";
            }
            else
            {
                if (MathCalculation.angle_between_two_vectors(knee_left_to_hip_left, knee_left_to_foot_left) > 120)
                {
                    form.Left_leg_status = "Bend your lower leg more";
                }
                else
                {
                    form.Left_leg_status = "Okay";
                    left_leg_okay = true;
                }
            }

            double[] eblow_left_to_shoulder_left = MathCalculation.turn_campts_to_vector(MSKinect.elbow_left, MSKinect.shoulder_left);
            double[] eblow_left_to_wrist_left = MathCalculation.turn_campts_to_vector(MSKinect.elbow_left, MSKinect.wrist_left);

            if (MathCalculation.angle_between_two_vectors(eblow_left_to_shoulder_left, eblow_left_to_wrist_left) > 153)
            {
                form.Left_arm_status = "bend your left arm backward more";
            }
            else
            {
                if (MSKinect.shoulder_left.X - MSKinect.elbow_left.X <= 0)
                {
                    form.Left_arm_status = "Keep your left eblow at the left side body";

                }
                else if (MSKinect.shoulder_left.X - MSKinect.elbow_left.X > 0.20)
                {
                    form.Left_arm_status = "Lower your left elbow down";
                }
                else
                {
                    form.Left_arm_status = "Okay";
                    left_arm_okay = true;
                }
            }

            if(!(right_arm_okay && left_leg_okay && left_arm_okay))
            {
                return false;
            }

            finished_third_quarter = true;
            return true;
        }

        internal static bool fourth_quarter_tutoring(Display form)
        {
            head_okay = false;

            back_okay = false;

            left_arm_okay = false;

            right_arm_okay = false;

            left_leg_okay = false;

            right_leg_okay = false;

            left_foot_okay = false;

            right_foot_okay = false;

            // check for head
            float headX = MSKinect.head.X - MSKinect.neck.X, headZ;
            if (headX > 0.05)
            {
                form.Head_status = "Tilt your head toward your left";
            }
            else if (headX < -0.05)
            {
                form.Head_status = "Tilt your head toward your right";
            }
            else
            {
                headZ = MSKinect.head.Z - MSKinect.neck.Z;
                if (headZ > 0.07)
                {
                    form.Head_status = "Tilt your head forward";
                }
                else if (headZ < -0.2)
                {
                    form.Head_status = "Tilt your head backward";
                }
                else
                {
                    head_okay = true;
                    form.Head_status = "Okay";
                }
            }

            // check for back
            float backX = MSKinect.shoulder_center.X - MSKinect.hip_center.X, backZ;
            if (backX > 0.05)
            {
                form.Back_status = "Lean sideways toward your left";
            }
            else if (backX < -0.05)
            {
                form.Back_status = "Lean sideways toward your right";
            }
            else
            {
                backZ = MSKinect.shoulder_center.Z - MSKinect.hip_center.Z;
                if (backZ > 0.15)
                {
                    form.Back_status = "Lean forward";
                }
                else if (backZ < -0.04)
                {
                    form.Back_status = "Lean backward";
                }
                else
                {
                    back_okay = true;
                    form.Back_status = "Okay";
                }
            }

            double[] knee_left_to_hip_left = MathCalculation.turn_campts_to_vector(MSKinect.knee_left, MSKinect.hip_left);
            double[] knee_left_to_foot_left = MathCalculation.turn_campts_to_vector(MSKinect.knee_left, MSKinect.foot_left);
            // check for left leg
            if (MathCalculation.angle_between_two_vectors(knee_left_to_hip_left, knee_left_to_foot_left) >= 160)
            {
                left_leg_okay = true;
                form.Left_leg_status = "Okay";
            }
            else
            {
                form.Left_leg_status = "Straighten your left leg";
            }
            // check for left foot
            if (MSKinect.foot_left.X >= MSKinect.shoulder_left.X)
            {
                left_foot_okay = true;
                form.Left_foot_status = "Okay";
            }
            else
            {
                form.Left_foot_status = "Move your left foot rightward";
            }



            // check for left arm
            double[] eblow_left_to_wrist_left = MathCalculation.turn_campts_to_vector(MSKinect.elbow_left, MSKinect.wrist_left);
            double[] eblow_left_to_shoulder_left = MathCalculation.turn_campts_to_vector(MSKinect.elbow_left, MSKinect.shoulder_left);

            //form.Right_arm_status = "" + Convert.ToInt32(MathCalculation.angle_between_two_vectors(eblow_right_to_wrist_right, eblow_right_to_shoulder_right));
            //form.Right_arm_status = "" + (MSKinect.elbow_right.X - MSKinect.shoulder_right.X);

            if (MathCalculation.angle_between_two_vectors(eblow_left_to_wrist_left, eblow_left_to_shoulder_left) <= 90.0)
            {
                if (MSKinect.elbow_left.X - MSKinect.shoulder_left.X >= 0)
                {
                    form.Left_arm_status = "Keep your left eblow at the left side body";

                }
                else if (MSKinect.elbow_left.X - MSKinect.shoulder_left.X < -0.20)
                {
                    form.Left_arm_status = "Lower your left elbow down";
                }
                else if (MSKinect.elbow_left.X - MSKinect.shoulder_left.X < 0)
                {
                    if (MSKinect.wrist_left.X - MSKinect.elbow_left.X < 0)
                    {
                        form.Left_arm_status = "Move your left wrist to your right";
                    }
                    else if (MSKinect.shoulder_center.X - MSKinect.wrist_left.X < 0)
                    {
                        form.Left_arm_status = "Move your left wrist to your left";
                    }
                    else
                    {
                        form.Left_arm_status = "Okay";
                        left_arm_okay = true;
                    }
                }
            }
            else
            {
                form.Left_arm_status = "Curl your left arm more";
            }

            double[] knee_right_to_hip_right = MathCalculation.turn_campts_to_vector(MSKinect.knee_right, MSKinect.hip_right);
            double[] knee_right_to_foot_right = MathCalculation.turn_campts_to_vector(MSKinect.knee_right, MSKinect.foot_right);

            if (MSKinect.knee_right.Y - MSKinect.hip_center.Y <= -0.06)
            {
                form.Right_leg_status = "Raise your right knee higher";
            }
            else
            {
                if (MathCalculation.angle_between_two_vectors(knee_right_to_hip_right, knee_right_to_foot_right) > 120)
                {
                    form.Right_leg_status = "Bend your lower leg more";
                }
                else
                {
                    form.Right_leg_status = "Okay";
                    right_leg_okay = true;
                }
            }

            double[] eblow_right_to_shoulder_right = MathCalculation.turn_campts_to_vector(MSKinect.elbow_right, MSKinect.shoulder_right);
            double[] eblow_right_to_wrist_right = MathCalculation.turn_campts_to_vector(MSKinect.elbow_right, MSKinect.wrist_right);

            if (MathCalculation.angle_between_two_vectors(eblow_right_to_shoulder_right, eblow_right_to_wrist_right) > 153)
            {
                form.Right_arm_status = "bend your right arm backward more";
            }
            else
            {
                if (MSKinect.shoulder_right.X - MSKinect.elbow_right.X >= 0)
                {
                    form.Right_arm_status = "Keep your right eblow at the right side body";

                }
                else if (MSKinect.shoulder_right.X - MSKinect.elbow_right.X < -0.20)
                {
                    form.Right_arm_status = "Lower your right elbow down";
                }
                else
                {
                    form.Right_arm_status = "Okay";
                    right_arm_okay = true;
                }
            }

            if (!(left_arm_okay && right_leg_okay && right_arm_okay))
            {
                return false;
            }

            finished_fourth_quarter = true;
            return true;
        }
    }
}
