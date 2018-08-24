using ColoumbForce.Mathematics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColoumbForce
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            DoubleBuffered = true;
            InitializeComponent();
        }

        List<Atom> atoms = new List<Atom>();
        bool electron, neutrone;

        private void Form1_Load(object sender, EventArgs e)
        {
 


        }

        private void simLoop_Tick(object sender, EventArgs e)
        {
            atoms.ForEach(p => p.Update());
            this.Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            atoms.ForEach(p => p.Render(e.Graphics));
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            atoms.Add(electron ? (Atom)new Electron("Elektron", new Vector2(e.X, e.Y)) : neutrone ? (Atom)new Neutrone("Neutrone", new Vector2(e.X, e.Y)) : (Atom)new Proton("Proton", new Vector2(e.X, e.Y)));
            for (int i = 0; i < atoms.Count; i++)
            {
                for (int j = 0; j < atoms.Count; j++)
                {
                    if (i == j) continue;
                    atoms[i].AddAtom(atoms[j]);
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Environment.Exit(Environment.ExitCode);

            electron = e.KeyCode == Keys.E ? !electron : false;
            neutrone = e.KeyCode == Keys.N ? !neutrone : false;
        }
    }
}
