using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColoumbForce.Mathematics
{
    public abstract class IApproximation
    {
        public delegate Vector2 f_delegate(double x, Vector2 y);

        public f_delegate f { get; set; }

        public double Delta { get; set; }
        public double Time { get; set; }

        public Vector2 Output { get; set; }

        public abstract Vector2 Run(Vector2 y);
    }
}
