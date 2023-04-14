using Rhino.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallaby.Goals
{
    public class CoPlanarGoal : GoalObject
    {

        public CoPlanarGoal(List<Point3d> points, double strength)
        {
            this.Positions = points;
            this.Strength = strength;
        }

        public override void Calculate()
        {
            Plane pln;
            Plane.FitPlaneToPoints(this.Positions, out pln);

            for (int i = 0; i < this.Positions.Count; i++)
            {
                this.Particles[i].Velocities.Add(pln.ClosestPoint(Positions[i]) - Positions[i]);
                this.Particles[i].Strengths.Add(Strength);
            }
        }
    }
}
