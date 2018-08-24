using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColoumbForce.Mathematics
{
    public class Euler : IApproximation
    {

        public Euler(Vector2 _0, double delta)
        {
            Output = _0;
            Delta = delta;
        }

        public override Vector2 Run(Vector2 y)
        {
            Output += Delta * f(Time, y);
            Time += Delta;

            return Output;
        }
    }
}
