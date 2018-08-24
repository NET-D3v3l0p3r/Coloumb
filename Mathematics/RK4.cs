using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColoumbForce.Mathematics
{
    public class RK4 : IApproximation
    {

        public RK4(Vector2 _0, double delta)
        {
            Output = _0;
            Delta = delta;
        }

        public override Vector2 Run(Vector2 y)
        {
            Vector2 k1 = Delta * f(Time, y);
            Vector2 k2 = Delta * f(Time + .5 * Delta, y + .5 * k1);
            Vector2 k3 = Delta * f(Time + .5 * Delta, y + .5 * k2);
            Vector2 k4 = Delta * f(Time + Delta, y + k3);

            Time += Delta;
            Output += 1.0 / 6.0 * (k1 + 2 * k2 + 2 * k3 + k4);
            return Output;
        }
    }
}
