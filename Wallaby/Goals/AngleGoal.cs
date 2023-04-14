using Rhino.ApplicationSettings;
using Rhino.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallaby.Goals
{
    public class AngleGoal : GoalObject
    {
        public double RestAngle;

        public AngleGoal(Line lineA, Line lineB, double restAngle, double strength)
        {
            this.Positions = new List<Point3d>() {  lineA.From, lineA.To, lineB.From, lineB.To };
            this.RestAngle = restAngle;
            this.Strength = strength;
        }

        public override void Calculate()
        {
            Point3d P0 = this.Particles[0].Position;
            Point3d P1 = this.Particles[1].Position;
            Point3d P2 = this.Particles[2].Position;
            Point3d P3 = this.Particles[3].Position;


            Vector3d V01 = P1 - P0;
            Vector3d V23 = P3 - P2;
            double top = 2 * Math.Sin(Vector3d.VectorAngle(V01, V23) - RestAngle);
            double Lc = (V01 + V23).Length;
            double Sa = top / (V01.Length * Lc);
            double Sb = top / (V23.Length * Lc);

            Vector3d Perp = Vector3d.CrossProduct(V01, V23);
            Vector3d ShearA = Vector3d.CrossProduct(V01, Perp);
            Vector3d ShearB = Vector3d.CrossProduct(Perp, V23);

            ShearA.Unitize();
            ShearB.Unitize();

            ShearA *= Sa;
            ShearB *= Sb;

            this.Particles[0].Velocities.Add(ShearA);
            this.Particles[1].Velocities.Add(-ShearA);
            this.Particles[2].Velocities.Add(ShearB);
            this.Particles[3].Velocities.Add(-ShearB);


            this.Particles[0].Strengths.Add(Strength);
            this.Particles[1].Strengths.Add(Strength);
            this.Particles[2].Strengths.Add(Strength);
            this.Particles[3].Strengths.Add(Strength);
        }
    }
}
