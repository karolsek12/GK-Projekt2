using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GK_Projekt2.Components;

namespace GK_Projekt2.Algorithms
{
    public static class MatrixCreation
    {
        public static Matrix3<double> GetXRot(double alpha)
        {
            Matrix3<double> matrix = new Matrix3<double>();

            matrix[0, 0] = 1;
            double sin = Math.Sin(alpha);
            double cos = Math.Cos(alpha);

            matrix[1, 1] = cos;
            matrix[2, 2] = cos;

            matrix[1, 2] = -sin;
            matrix[2, 1] = sin;

            return matrix;
        }

        public static Matrix3<double> GetYRot(double beta)
        {
            Matrix3<double> matrix = new Matrix3<double>();
            double sin = Math.Sin(beta);
            double cos = Math.Cos(beta);


            matrix[0, 0] = cos;
            matrix[1, 1] = 1;
            matrix[2, 2] = cos;

            matrix[0,2] = sin;
            matrix[2, 0] = -sin;

            return matrix;
        }

        public static Matrix3<double> GetZRot(double gamma)
        {
            Matrix3<double> matrix = new Matrix3<double>();
            double sin = Math.Sin(gamma);
            double cos = Math.Cos(gamma);


            matrix[0, 0] = cos;
            matrix[1, 1] = cos;
            matrix[2, 2] = 1;

            matrix[0, 1] = -sin;
            matrix[1, 0] = sin;

            return matrix;
        }

        public static Matrix3<double> GetRot(double alpha, double beta, double gamma)
        {
            Matrix3<double> ma = GetXRot(alpha);

            Matrix3<double> mb = GetYRot(beta);

            Matrix3<double> mg = GetZRot(gamma);

            Matrix3<double> result = ma * mb;

            result = result * mg;
            return result;
        }

    }
}
