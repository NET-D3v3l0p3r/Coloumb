using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ColoumbForce.Mathematics;
using System.Drawing;

namespace ColoumbForce
{
    public class Atom
    {
        public static double DELTA0 = 5;
        public static double E0 = 8.854187817E-12;
        public static Dictionary<string, SolidBrush> ColorMap;

        public string Name { get; private set; }

        public IApproximation PositionApproximation { get; private set; }
        public IApproximation VelocityApproximation { get; private set; }

        public double Mass { get; set; }
        public double q { get; set; }

        public List<Atom> Atoms { get; private set; }

        public int Radius = 15;

        private int atomID;
        private static int ATOM_ID; 
        
        public Atom(string name, Vector2 p0)
        {
            atomID = ATOM_ID++;

            Name = name;
            if(ColorMap == null)
            {
                ColorMap = new Dictionary<string, SolidBrush>();

                ColorMap.Add("Elektron", new SolidBrush(Color.Blue));
                ColorMap.Add("Proton", new SolidBrush(Color.Red));
                ColorMap.Add("Neutrone", new SolidBrush(Color.DarkGray));
            }

            Atoms = new List<Atom>();

            PositionApproximation = new Euler(p0, DELTA0);
            PositionApproximation.f = (x, y) =>
            {
                return VelocityApproximation.Run(y);
            };

            VelocityApproximation = new Euler(new Vector2(), DELTA0);
            VelocityApproximation.f = (x, y) =>
            {
                Vector2 a = new Vector2();

                for (int i = 0; i < Atoms.Count; i++)
                {
                    Vector2 u = Atoms[i].PositionApproximation.Output;
                    Vector2 v = this.PositionApproximation.Output;

                    double q1 = this.q;
                    double q2 = Atoms[i].q;

                    Vector2 d = u - v;

                    double length = d.Length();
                    d /= length;



                    Vector2 F = (q1 * q2) / (4.0 * Math.PI * E0 * length * length) * d;
                    a += F / Mass;
                    
                }

                return a;
            };
        }


        public bool Intersects(Atom a)
        {
            Vector2 p0 = this.PositionApproximation.Output;
            Vector2 p1 = a.PositionApproximation.Output;

            double l = (p1 - p0).Length();

            return l <= Radius + a.Radius;
        }


        public void AddAtom(Atom a)
        {
            if (Atoms.Contains(a))
                return;
            Atoms.Add(a);
        }

        public void Update()
        {
            PositionApproximation.Run(PositionApproximation.Output);
 
            for (int i = 0; i < Atoms.Count; i++)
            {
                Atom atom = Atoms[i];

                Vector2 p0 = this.PositionApproximation.Output;
                Vector2 p1 = atom.PositionApproximation.Output;

                if (Intersects(atom))
                {
                    if (!Name.Equals("Proton") && !Name.Equals("Neutrone"))
                        VelocityApproximation = new Euler(new Vector2(), DELTA0)
                        {
                            f = VelocityApproximation.f
                        };

                    Vector2 n = p1 - p0;
                    double l = n.Length();
                    n /= l;

                    double overlapped = this.Radius + atom.Radius - l;
                    this.PositionApproximation.Output += n * overlapped;

                }
            }

        }

        public void Render(Graphics g)
        {
            g.FillEllipse(ColorMap[Name], new RectangleF(new PointF((float)PositionApproximation.Output.X - Radius, (float)PositionApproximation.Output.Y - Radius), new SizeF(Radius * 2, Radius * 2)));
        }

        public override bool Equals(object obj)
        {
            return this.GetHashCode() == obj.GetHashCode();
        }

        public override int GetHashCode()
        {
            return atomID;
        }
    }
}
