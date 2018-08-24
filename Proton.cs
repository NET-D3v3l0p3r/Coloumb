using ColoumbForce.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColoumbForce
{
    public class Proton : Atom
    {
        public Proton(string name, Vector2 p0)
            : base(name, p0)
        {
            Mass = 1.672621898E-27;
            q = +1.602E-19;
        }
    }
}
