using Rhino.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallaby.Goals
{
    public class CoLinearGoal : GoalObject
    {

        public CoLinearGoal(List<Point3d> points, double strength)
        {
            this.Positions = points;
            this.Strength = strength;

        }

        public override void Calculate()
        {

            Line Ln;
            Line.TryFitLineToPoints(this.Positions, out Ln);

            for (int i = 0; i < this.Positions.Count; i++)
            {
                this.Particles[i].Velocities.Add(Ln.ClosestPoint((Positions[i]), false) - Positions[i]);
                this.Particles[i].Strengths.Add(Strength);
            }
        }
    }
}
