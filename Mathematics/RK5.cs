using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColoumbForce.Mathematics
{
    public class RK5 : IApproximation
    {

        public RK5(Vector2 _0, double delta)
        {
            Output = _0;
            Delta = delta;
        }

        public override Vector2 Run(Vector2 y)
        {
            Vector2 k1 = Delta * f(Time, y);
            Vector2 k2 = Delta * f(Time + ((3.0 * Delta) / 5.0), y + ((1 * 3.0) / 5.0) * k1);
            Vector2 k3 = Delta * f(Time + ((2.0 * Delta) / 5.0), y + ((4.0 * 1) / 15.0) * k1 + ((2.0 * 1) / 15.0) * k2);
            Vector2 k4 = Delta * f(Time + (Delta / 5.0), y + ((3.0 * 1) / 20.0) * k1 + (1 / 20.0) * k3);
            Vector2 k5 = Delta * f(Time + ((4.0 * Delta) / 5.0), y + ((-1 / 5.0)) * k1 + ((-2.0 * 1) / 5.0) * k2 + ((7.0 * 1) / 5.0) * k3);
            Vector2 k6 = Delta * f(Time + Delta, y + ((59.0 * 1) / 84.0) * k1 + ((40.0 * 1) / 21.0) * k2 + ((-165.0 * 1) / 28.0) * k3 + ((20.0 * 1) / 7.0) * k4 + ((10.0 * 1) / 7.0) * k5);

            Output += (k1 / 12.0) + ((25.0 * k3) / 72.0) + ((25.0 * k4) / 144.0) + ((25.0 * k5) / 72.0) + ((7.0 * k6) / 144.0);

            Time += Delta;

            return Output;
        }
    }
}
