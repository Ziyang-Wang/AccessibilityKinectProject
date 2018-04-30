using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;

namespace AccessibilityProject
{
    class MathCalculation
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        internal static double[] turn_campts_to_vector(CameraSpacePoint p1, CameraSpacePoint p2)
        {
            return new double[] { p2.X - p1.X, p2.Y - p1.Y, p2.Z - p1.Z };
        }

        /// <summary>
        /// get the length(double) of the vector
        /// </summary>
        /// <param name="v"></param>
        /// <returns length></returns>
        internal static double length_of_vector(double[] vector)
        {
            double length = 0.0F;
            for (int i = 0; i < vector.Length; i++)
            {
                length += vector[i] * vector[i];
            }
            return Math.Sqrt(length);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        internal static double Distance_between_two_points(CameraSpacePoint p1, CameraSpacePoint p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2) + Math.Pow(p1.Z - p2.Z, 2));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <returns></returns>
        internal static double Dot_Product(double[] vector1, double[] vector2)
        {
            return vector1[0] * vector2[0] + vector1[1] * vector2[1] + vector1[2] * vector2[2];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector1_start"></param>
        /// <param name="vector1_end"></param>
        /// <param name="vector2_start"></param>
        /// <param name="vector2_end"></param>
        /// <returns></returns>
        internal static double angle_between_two_vectors(double[] vector1, double[] vector2)
        {
            double dot_product = Dot_Product(vector1, vector2);
            double len_vector1 = length_of_vector(vector1);
            double len_vector2 = length_of_vector(vector2);
            return (180*Math.Acos(dot_product/(len_vector1*len_vector2)))/Math.PI;
        }
    }
}
