using ColoumbForce.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace ColoumbForce
{
    public class Electron: Atom
    {
        public Electron(string name, Vector2 p0)
            :base(name, p0)
        {
            Mass = 9.10938356E-31;
            q = -1.6021766208E-19;
        }
    }
}
