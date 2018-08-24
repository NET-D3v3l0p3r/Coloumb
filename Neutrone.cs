using ColoumbForce.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColoumbForce
{
    public class Neutrone : Atom
    {
        public Neutrone(string name, Vector2 p0)
            : base(name, p0)
        {
            Mass = 1.674927471E-27;
            q = 0;
        }
    }
}
