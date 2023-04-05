using Rhino.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Wallaby.Goals
{
    [Serializable]
    public class LengthGoal : GoalObject
    {
        double Lenght;

        public LengthGoal(Line line, double length, double strength)
        {
            this.Positions = new List<Point3d>() { line.From, line.To };
            this.Lenght = length;
            this.Strength = strength;
        }

        public override void AddGeometryObjects(List<GeometryObject> geometryObjects)
        {
            GeometryObject ln = new GeometryObject(GeometryObjectType.Line);
            ln.AddLine(this.Particles[0], this.Particles[1]);
            geometryObjects.Add(ln);
        }

        public override void Calculate()
        {
            Vector3d current = this.Particles[1].Position - this.Particles[0].Position;
            double stretchfactor = 1.0 - Lenght / current.Length;
            Vector3d SpringMove = 0.5 * current * stretchfactor;

            this.Particles[0].Velocities.Add(SpringMove);
            this.Particles[0].Strengths.Add(Strength);

            this.Particles[1].Velocities.Add(-SpringMove);
            this.Particles[1].Strengths.Add(Strength);
        }
    }
}
