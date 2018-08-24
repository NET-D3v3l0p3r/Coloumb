using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColoumbForce.Mathematics
{
    public struct Vector2
    {
        public double X { get; set; }
        public double Y { get; set; }

        public double Length()
        {
            return Math.Sqrt(X * X + Y * Y);
        }

        public Vector2(double x, double y)
        {
            X = x;
            Y = y;
        }

      

        public static Vector2 operator *(int a, Vector2 b)
        {
            return new Vector2(b.X * a, b.Y * a);
        }

        public static Vector2 operator *(double a, Vector2 b)
        {
            return new Vector2(b.X * a, b.Y * a);
        }

        public static Vector2 operator *(Vector2 b, double a)
        {
            return new Vector2(b.X * a, b.Y * a);
        }
        public static Vector2 operator /(Vector2 b, double a)
        {
            return new Vector2(b.X / a, b.Y / a);
        }

        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X + b.X, a.Y + b.Y);
        }

        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            return new Vector2(b.X - a.X, b.Y - a.Y);
        }

        public static Vector2 operator -( Vector2 b)
        {
            return new Vector2(-b.X, -b.Y);
        }



        public override string ToString()
        {
            return "X: " + X + ";" + "Y: " + Y;
        }
        public PointF ToPointF()
        {
            return new PointF((float)X, (float)Y);
        }


    }
}
